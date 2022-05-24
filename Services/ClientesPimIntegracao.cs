// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Services.ClientesPimIntegracaoService
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WorkerImportadorPIM.Models;

namespace WorkerImportadorPIM.Services
{
  public class ClientesPimIntegracaoService
  {
    private readonly ContextInfotec _context;
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger _logger;
    private readonly CancellationToken _stoppingToken;

    public ClientesPimIntegracaoService(
      IHttpClientFactory clientFactory,
      ILogger logger,
      CancellationToken stoppingToken)
    {
      this._clientFactory = clientFactory;
      this._logger = logger;
      this._stoppingToken = stoppingToken;
      this._context = new ContextInfotec();
    }

    private async Task Add(ObjectRetornoPIM.Item item, string ptipointegracao)
    {
      ClientesPimIntegracao clientesPimIntegracao = await this._context.ClientesPimIntegracao.FirstOrDefaultAsync<ClientesPimIntegracao>((Expression<Func<ClientesPimIntegracao, bool>>) (c => object.Equals((object) c.id, (object) item.id)), this._stoppingToken);
      if (clientesPimIntegracao == null)
      {
        clientesPimIntegracao = new ClientesPimIntegracao()
        {
          anotacoes_internas = item.anotacoes_internas,
          data_cadastro = new DateTime?(Convert.ToDateTime(item.data_cadastro)),
          email = item.email,
          id = item.id,
          nome = item.nome,
          telefone = item.telefone,
          tipointegracao = ptipointegracao
        };
        EntityEntry<ClientesPimIntegracao> entityEntry = await this._context.ClientesPimIntegracao.AddAsync(clientesPimIntegracao, this._stoppingToken);
        clientesPimIntegracao = (ClientesPimIntegracao) null;
      }
      else
      {
        this._context.ClientesPimIntegracao.Update(clientesPimIntegracao);
        clientesPimIntegracao = (ClientesPimIntegracao) null;
      }
    }

    public async Task ImportarIntegracaoAsync(
      List<ObjectRetornoPIM.Item> items,
      string ptipointegracao)
    {
      foreach (ObjectRetornoPIM.Item item in items)
        await this.Add(item, ptipointegracao);
      int num = await this._context.SaveChangesAsync(this._stoppingToken);
    }
  }
}
