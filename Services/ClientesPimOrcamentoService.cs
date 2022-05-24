// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Services.ClientesPimOrcamentoService
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
  public class ClientesPimOrcamentoService
  {
    private readonly ContextInfotec _context;
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger _logger;
    private readonly CancellationToken _stoppingToken;

    public ClientesPimOrcamentoService(
      IHttpClientFactory clientFactory,
      ILogger logger,
      CancellationToken stoppingToken)
    {
      this._clientFactory = clientFactory;
      this._logger = logger;
      this._stoppingToken = stoppingToken;
      this._context = new ContextInfotec();
    }

    public async Task ImportarOrcamentosAsync()
    {
      string uri = Utils_Http.GetURI("https://www.fbdobrasil.com.br/v1/web/api/orcamentos?");
      ObjectRetornoPimOrcamentos.Root orcamentos = await Utils_Http.Get<ObjectRetornoPimOrcamentos.Root>(uri, this._stoppingToken, this._logger, this._clientFactory);
      foreach (ObjectRetornoPimOrcamentos.Item obj in orcamentos._embedded.items)
      {
        ObjectRetornoPimOrcamentos.Item item = obj;
        Orcamento orcamento = await this._context.Orcamento.FirstOrDefaultAsync<Orcamento>((Expression<Func<Orcamento, bool>>) (c => object.Equals((object) c.id, (object) item.id)), this._stoppingToken);
        if (orcamento == null)
        {
          orcamento = new Orcamento();
          ClientesPimOrcamentoService.PreencherOrcamento(orcamento, item);
          EntityEntry<Orcamento> entityEntry = await this._context.Orcamento.AddAsync(orcamento, this._stoppingToken);
        }
        else
        {
          ClientesPimOrcamentoService.PreencherOrcamento(orcamento, item);
          this._context.Orcamento.Update(orcamento);
        }
        await this.ImportarOrcamentosItensAsync(item.pedido_items, item.id);
        orcamento = (Orcamento) null;
      }
      int num = await this._context.SaveChangesAsync(this._stoppingToken);
      uri = (string) null;
      orcamentos = (ObjectRetornoPimOrcamentos.Root) null;
    }

    private async Task ImportarOrcamentosItensAsync(
      List<ObjectRetornoPimOrcamentos.PedidoItem> itens,
      int orcamentoId)
    {
      foreach (ObjectRetornoPimOrcamentos.PedidoItem iten in itens)
      {
        ObjectRetornoPimOrcamentos.PedidoItem item = iten;
        OrcamentoItem orcamentoitem = await this._context.OrcamentoItem.FirstOrDefaultAsync<OrcamentoItem>((Expression<Func<OrcamentoItem, bool>>) (c => object.Equals((object) c.id, (object) item.id)), this._stoppingToken);
        if (orcamentoitem == null)
        {
          orcamentoitem = new OrcamentoItem();
          ClientesPimOrcamentoService.PreencherOrcamentoItem(orcamentoitem, item, orcamentoId);
          EntityEntry<OrcamentoItem> entityEntry = await this._context.OrcamentoItem.AddAsync(orcamentoitem, this._stoppingToken);
        }
        else
        {
          ClientesPimOrcamentoService.PreencherOrcamentoItem(orcamentoitem, item, orcamentoId);
          this._context.OrcamentoItem.Update(orcamentoitem);
        }
        orcamentoitem = (OrcamentoItem) null;
      }
    }

    private static void PreencherOrcamentoItem(
      OrcamentoItem orcamentoitem,
      ObjectRetornoPimOrcamentos.PedidoItem item,
      int orcamentoId)
    {
      orcamentoitem.id = item.id;
      orcamentoitem.orcamento_id = new int?(orcamentoId);
      orcamentoitem.pedido = item.pedido;
      orcamentoitem.produto_nome = item.produto_nome;
      orcamentoitem.produto_sku = item.produto_sku;
      orcamentoitem.produto_variacao_id = new int?(item.produto_variacao_id);
      orcamentoitem.quantidade = new int?(item.quantidade);
      orcamentoitem.valor_total = new double?(Convert.ToDouble(item.valor_total));
    }

    private static void PreencherOrcamento(
      Orcamento orcamento,
      ObjectRetornoPimOrcamentos.Item item)
    {
      orcamento.cliente_id = item.cliente_id;
      orcamento.codigo_faturamento_direto = item.codigo_faturamento_direto;
      orcamento.data_atualizacao = new DateTime?(Convert.ToDateTime(item.data_atualizacao));
      orcamento.data_criacao = new DateTime?(Convert.ToDateTime(item.data_criacao));
      orcamento.endereco_entrega = item.endereco_entrega;
      orcamento.forma_pagamento = item.forma_pagamento;
      orcamento.frete = item.frete;
      orcamento.frete_prazo = item.frete_prazo;
      orcamento.id = item.id;
      orcamento.status = item.status;
      orcamento.valor_desconto = item.valor_desconto;
      orcamento.valor_entrega = item.valor_entrega;
      orcamento.valor_itens = new double?(Convert.ToDouble((object) item.valor_itens));
      orcamento.valor_total = new double?(Convert.ToDouble((object) item.valor_total));
    }
  }
}
