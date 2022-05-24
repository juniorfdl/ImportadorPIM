// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Services.ClientesPimService
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
using WorkerImportadorPIM.Utils;

namespace WorkerImportadorPIM.Services
{
  public class ClientesPimService
  {
    private readonly ContextInfotec _context;
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger _logger;
    private readonly CancellationToken _stoppingToken;

    public ClientesPimService(
      IHttpClientFactory clientFactory,
      ILogger logger,
      CancellationToken stoppingToken)
    {
      this._clientFactory = clientFactory;
      this._logger = logger;
      this._stoppingToken = stoppingToken;
      this._context = new ContextInfotec();
    }

    private async Task AddClientePimAsync(ObjectRetornoPIM.Item item)
    {
      bool novocliente = false;
      ClientesPIM clientepim = await this._context.ClientesPIM.FirstOrDefaultAsync<ClientesPIM>((Expression<Func<ClientesPIM, bool>>) (c => object.Equals((object) c.id, (object) item.id)), this._stoppingToken);
      if (clientepim == null)
      {
        novocliente = true;
        clientepim = new ClientesPIM()
        {
          anotacoes_internas = item.anotacoes_internas,
          data_cadastro = new DateTime?(Convert.ToDateTime(item.data_cadastro)),
          email = item.email,
          id = item.id,
          nome = item.nome,
          telefone = item.telefone
        };
      }
      await this.ImportarDetalheClienteAsync(clientepim, novocliente);
      clientepim = (ClientesPIM) null;
    }

    private async Task ImportarDetalheClienteAsync(ClientesPIM clientepim, bool novocliente)
    {
      string uri = string.Format("https://www.fbdobrasil.com.br/v1/web/api/clientes/{0}?access_token", (object) clientepim.id) + "=" + Domain.Settings.Token;
      ObjectRetornoPimClientes.Root cli = await Utils_Http.Get<ObjectRetornoPimClientes.Root>(uri, this._stoppingToken, this._logger, this._clientFactory);
      clientepim.cnpj = cli.cnpj;
      clientepim.cpf = cli.cpf;
      clientepim.data_atualizacao = new DateTime?(Convert.ToDateTime(cli.data_cadastro));
      clientepim.data_nascimento = new DateTime?(Convert.ToDateTime(cli.data_nascimento));
      clientepim.email = cli.email;
      clientepim.inscricao_estadual = cli.inscricao_estadual;
      clientepim.nome_fantasia = cli.nome_fantasia;
      clientepim.razao_social = cli.razao_social;
      if (novocliente)
      {
        EntityEntry<ClientesPIM> entityEntry = await this._context.ClientesPIM.AddAsync(clientepim, this._stoppingToken);
      }
      else
        this._context.ClientesPIM.Update(clientepim);
      await this.ImportarClientesEnderecoAsync(cli);
      uri = (string) null;
      cli = (ObjectRetornoPimClientes.Root) null;
    }

    private async Task ImportarClientesEnderecoAsync(ObjectRetornoPimClientes.Root cliente)
    {
      foreach (ObjectRetornoPimClientes.Endereco endereco1 in cliente.enderecos)
      {
        ObjectRetornoPimClientes.Endereco item = endereco1;
        ClientesPimEndereco endereco = await this._context.ClientesPimEndereco.FirstOrDefaultAsync<ClientesPimEndereco>((Expression<Func<ClientesPimEndereco, bool>>) (c => c.id == item.id), this._stoppingToken);
        if (endereco == null)
        {
          endereco = new ClientesPimEndereco();
          ClientesPimService.PreencherEndereco(endereco, item);
          EntityEntry<ClientesPimEndereco> entityEntry = await this._context.ClientesPimEndereco.AddAsync(endereco, this._stoppingToken);
        }
        else
        {
          ClientesPimService.PreencherEndereco(endereco, item);
          this._context.ClientesPimEndereco.Update(endereco);
        }
      }
    }

    private static void PreencherEndereco(
      ClientesPimEndereco endereco,
      ObjectRetornoPimClientes.Endereco item)
    {
      endereco.bairro = item.bairro;
      endereco.complemento = item.complemento;
      endereco.cep = item.cep;
      endereco.data_atualizacao = new DateTime?(Convert.ToDateTime(item.data_atualizacao));
      endereco.data_cadastro = new DateTime?(Convert.ToDateTime(item.data_cadastro));
      endereco.estado = item.estado;
      endereco.id = item.id;
      endereco.identificacao = item.identificacao;
      endereco.logradouro = item.logradouro;
      endereco.municipio = item.municipio;
      endereco.nome_destinatario = item.nome_destinatario;
      endereco.numero = item.numero;
    }

    public async Task ImportarClientesAsync(List<ObjectRetornoPIM.Item> items)
    {
      foreach (ObjectRetornoPIM.Item item in items)
        await this.AddClientePimAsync(item);
      int num = await this._context.SaveChangesAsync(this._stoppingToken);
    }
  }
}
