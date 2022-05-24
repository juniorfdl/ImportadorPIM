// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Controllers.ProcessarImportacao
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WorkerImportadorPIM.Models;
using WorkerImportadorPIM.Services;
using WorkerImportadorPIM.Utils;

namespace WorkerImportadorPIM.Controllers
{
  public class ProcessarImportacao
  {
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger _logger;
    private readonly CancellationToken _stoppingToken;

    public ProcessarImportacao(
      IHttpClientFactory clientFactory,
      ILogger logger,
      CancellationToken stoppingToken)
    {
      this._clientFactory = clientFactory;
      this._logger = logger;
      this._stoppingToken = stoppingToken;
    }

    private async Task ProcessarApi()
    {
      string uri = Utils_Http.GetURI("https://www.fbdobrasil.com.br/v1/web/api/clientes?");
      ObjectRetornoPIM.Root root = await Utils_Http.Get<ObjectRetornoPIM.Root>(uri, this._stoppingToken, this._logger, this._clientFactory);
      await this.ImportarIntegracao(root, "1");
      await this.ImportarClientes(root);
      uri = Utils_Http.GetURI("https://www.fbdobrasil.com.br/v1/web/api/cadastrorapidos?");
      root = await Utils_Http.Get<ObjectRetornoPIM.Root>(uri, this._stoppingToken, this._logger, this._clientFactory);
      await this.ImportarIntegracao(root, "2");
      await this.ImportarClientes(root);
      uri = Utils_Http.GetURI("https://www.fbdobrasil.com.br/v1/web/api/ligamosvoces?");
      root = await Utils_Http.Get<ObjectRetornoPIM.Root>(uri, this._stoppingToken, this._logger, this._clientFactory);
      await this.ImportarIntegracao(root, "3");
      await this.ImportarClientes(root);
      uri = (string) null;
      root = (ObjectRetornoPIM.Root) null;
    }

    private async Task ImportarIntegracao(ObjectRetornoPIM.Root root, string ptipointegracao)
    {
      ClientesPimIntegracaoService integracao = new ClientesPimIntegracaoService(this._clientFactory, this._logger, this._stoppingToken);
      await integracao.ImportarIntegracaoAsync(root._embedded.items, ptipointegracao);
      integracao = (ClientesPimIntegracaoService) null;
    }

    private async Task ImportarClientes(ObjectRetornoPIM.Root root)
    {
      ClientesPimService cliente = new ClientesPimService(this._clientFactory, this._logger, this._stoppingToken);
      await cliente.ImportarClientesAsync(root._embedded.items);
      cliente = (ClientesPimService) null;
    }

    private async Task ProcessarClientesContato()
    {
      ClientesPimContatoService contato = new ClientesPimContatoService(this._clientFactory, this._logger, this._stoppingToken);
      await contato.ImportarContatosAsync();
      contato = (ClientesPimContatoService) null;
    }

    private async Task ProcessarOrcamentos()
    {
      ClientesPimOrcamentoService contato = new ClientesPimOrcamentoService(this._clientFactory, this._logger, this._stoppingToken);
      await contato.ImportarOrcamentosAsync();
      contato = (ClientesPimOrcamentoService) null;
    }

    private async Task ProcessarPedidos()
    {
      ClientesPimPedidoService pedido = new ClientesPimPedidoService(this._clientFactory, this._logger, this._stoppingToken);
      await pedido.ImportarPedidosAsync();
      pedido = (ClientesPimPedidoService) null;
    }

    public async Task ExecuteAsync()
    {
      await this.ProcessarApi();
      await this.ProcessarClientesContato();
      await this.ProcessarOrcamentos();
      await this.ProcessarPedidos();
    }
  }
}
