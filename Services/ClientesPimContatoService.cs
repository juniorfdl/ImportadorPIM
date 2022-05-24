// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Services.ClientesPimContatoService
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WorkerImportadorPIM.Models;
using WorkerImportadorPIM.Utils;

namespace WorkerImportadorPIM.Services
{
  public class ClientesPimContatoService
  {
    private readonly ContextInfotec _context;
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger _logger;
    private readonly CancellationToken _stoppingToken;

    public ClientesPimContatoService(
      IHttpClientFactory clientFactory,
      ILogger logger,
      CancellationToken stoppingToken)
    {
      this._clientFactory = clientFactory;
      this._logger = logger;
      this._stoppingToken = stoppingToken;
      this._context = new ContextInfotec();
    }

    public async Task ImportarContatosAsync()
    {
      string uri = Utils_Http.GetURI("https://www.fbdobrasil.com.br/v1/web/api/contatos?");
      ObjectRetornoPimContatos.Root contatos = await Utils_Http.Get<ObjectRetornoPimContatos.Root>(uri, this._stoppingToken, this._logger, this._clientFactory);
      foreach (ObjectRetornoPimContatos.Item obj in contatos._embedded.items)
      {
        ObjectRetornoPimContatos.Item item = obj;
        ClientesPimContato contato = await this._context.ClientesPimContato.FirstOrDefaultAsync<ClientesPimContato>((Expression<Func<ClientesPimContato, bool>>) (c => object.Equals((object) c.id, (object) item.id)), this._stoppingToken);
        if (contato == null)
        {
          contato = new ClientesPimContato();
          ClientesPimContatoService.PreencherClientesPimContato(contato, item);
          EntityEntry<ClientesPimContato> entityEntry = await this._context.ClientesPimContato.AddAsync(contato, this._stoppingToken);
        }
        else
        {
          ClientesPimContatoService.PreencherClientesPimContato(contato, item);
          this._context.ClientesPimContato.Update(contato);
        }
        contato = (ClientesPimContato) null;
      }
      int num = await this._context.SaveChangesAsync(this._stoppingToken);
      uri = (string) null;
      contatos = (ObjectRetornoPimContatos.Root) null;
    }

    private static void PreencherClientesPimContato(
      ClientesPimContato contato,
      ObjectRetornoPimContatos.Item item)
    {
      contato.cnpj = item.cnpj;
      contato.id = item.id;
      contato.mensagem = item.mensagem;
      contato.nome = item.nome;
      contato.segmento = item.segmento;
      contato.telefone = item.telefone;
    }
  }
}
