// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Services.ClientesPimPedidoService
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
  public class ClientesPimPedidoService
  {
    private readonly ContextInfotec _context;
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger _logger;
    private readonly CancellationToken _stoppingToken;

    public ClientesPimPedidoService(
      IHttpClientFactory clientFactory,
      ILogger logger,
      CancellationToken stoppingToken)
    {
      this._clientFactory = clientFactory;
      this._logger = logger;
      this._stoppingToken = stoppingToken;
      this._context = new ContextInfotec();
    }

    public async Task ImportarPedidosAsync()
    {
      string uri = Utils_Http.GetURI("https://www.fbdobrasil.com.br/v1/web/api/pedidos?");
      ObjectRetornoPimPedidos.Root pedidos = await Utils_Http.Get<ObjectRetornoPimPedidos.Root>(uri, this._stoppingToken, this._logger, this._clientFactory);
      foreach (ObjectRetornoPimPedidos.Item obj in pedidos._embedded.items)
      {
        ObjectRetornoPimPedidos.Item item = obj;
        Pedido pedido = await this._context.Pedido.FirstOrDefaultAsync<Pedido>((Expression<Func<Pedido, bool>>) (c => object.Equals((object) c.id, (object) item.id)), this._stoppingToken);
        if (pedido == null)
        {
          pedido = new Pedido();
          ClientesPimPedidoService.PreencherPedido(pedido, item);
          EntityEntry<Pedido> entityEntry = await this._context.Pedido.AddAsync(pedido, this._stoppingToken);
        }
        else
        {
          ClientesPimPedidoService.PreencherPedido(pedido, item);
          this._context.Pedido.Update(pedido);
        }
        await this.ImportarPedidosItensAsync(item.pedido_items, item.id);
        await this.ImportarPedidosEtapasAsync(item.etapas, item.id);
        pedido = (Pedido) null;
      }
      int num = await this._context.SaveChangesAsync(this._stoppingToken);
      uri = (string) null;
      pedidos = (ObjectRetornoPimPedidos.Root) null;
    }

    private async Task ImportarPedidosEtapasAsync(
      List<ObjectRetornoPimPedidos.Etapa> itens,
      int pedidoId)
    {
      foreach (ObjectRetornoPimPedidos.Etapa iten in itens)
      {
        ObjectRetornoPimPedidos.Etapa item = iten;
        PedidosEtapas pedidosEtapas = await this._context.PedidosEtapas.FirstOrDefaultAsync<PedidosEtapas>((Expression<Func<PedidosEtapas, bool>>) (c => object.Equals((object) c.id, (object) item.id) && object.Equals((object) c.pedido_id, (object) pedidoId)), this._stoppingToken);
        if (pedidosEtapas == null)
        {
          pedidosEtapas = new PedidosEtapas();
          ClientesPimPedidoService.PreencherPedidoEtapa(pedidosEtapas, item, pedidoId);
          EntityEntry<PedidosEtapas> entityEntry = await this._context.PedidosEtapas.AddAsync(pedidosEtapas, this._stoppingToken);
        }
        else
        {
          ClientesPimPedidoService.PreencherPedidoEtapa(pedidosEtapas, item, pedidoId);
          this._context.PedidosEtapas.Update(pedidosEtapas);
        }
        pedidosEtapas = (PedidosEtapas) null;
      }
    }

    private static void PreencherPedidoEtapa(
      PedidosEtapas pedidoetapa,
      ObjectRetornoPimPedidos.Etapa item,
      int pedidoId)
    {
      pedidoetapa.id = item.id;
      pedidoetapa.pedido_id = pedidoId;
      pedidoetapa.data_atualizacao = new DateTime?(Convert.ToDateTime(item.data_atualizacao));
      pedidoetapa.data_criacao = new DateTime?(Convert.ToDateTime(item.data_criacao));
      pedidoetapa.finalizado = Convert.ToString(item.finalizado);
      pedidoetapa.status = item.status;
    }

    private async Task ImportarPedidosItensAsync(
      List<ObjectRetornoPimPedidos.PedidoItem> itens,
      int pedidoId)
    {
      foreach (ObjectRetornoPimPedidos.PedidoItem iten in itens)
      {
        ObjectRetornoPimPedidos.PedidoItem item = iten;
        PedidoItem pedidoitem = await this._context.PedidoItem.FirstOrDefaultAsync<PedidoItem>((Expression<Func<PedidoItem, bool>>) (c => object.Equals((object) c.id, (object) item.id)), this._stoppingToken);
        if (pedidoitem == null)
        {
          pedidoitem = new PedidoItem();
          ClientesPimPedidoService.PreencherPedidoItem(pedidoitem, item, pedidoId);
          EntityEntry<PedidoItem> entityEntry = await this._context.PedidoItem.AddAsync(pedidoitem, this._stoppingToken);
        }
        else
        {
          ClientesPimPedidoService.PreencherPedidoItem(pedidoitem, item, pedidoId);
          this._context.PedidoItem.Update(pedidoitem);
        }
        pedidoitem = (PedidoItem) null;
      }
    }

    private static void PreencherPedidoItem(
      PedidoItem pedidoitem,
      ObjectRetornoPimPedidos.PedidoItem item,
      int pedidoId)
    {
      pedidoitem.id = item.id;
      pedidoitem.pedido_id = new int?(pedidoId);
      pedidoitem.pedido = item.pedido;
      pedidoitem.produto_nome = item.produto_nome;
      pedidoitem.produto_sku = item.produto_sku;
      pedidoitem.produto_variacao_id = new int?(item.produto_variacao_id);
      pedidoitem.quantidade = new int?(item.quantidade);
      pedidoitem.valor_total = new double?(Convert.ToDouble(item.valor_total));
    }

    private static void PreencherPedido(Pedido pedido, ObjectRetornoPimPedidos.Item item)
    {
      pedido.cliente_id = new int?(item.cliente_id);
      pedido.codigo_faturamento_direto = item.codigo_faturamento_direto;
      pedido.data_atualizacao = new DateTime?(Convert.ToDateTime(item.data_atualizacao));
      pedido.data_criacao = new DateTime?(Convert.ToDateTime(item.data_criacao));
      pedido.endereco_entrega = item.endereco_entrega;
      pedido.forma_pagamento = item.forma_pagamento;
      pedido.frete = item.frete;
      pedido.frete_prazo = item.frete_prazo;
      pedido.id = item.id;
      pedido.status = item.status;
      pedido.valor_desconto = item.valor_desconto;
      pedido.valor_entrega = item.valor_entrega;
      pedido.valor_itens = item.valor_itens;
      pedido.valor_total = item.valor_total;
    }
  }
}
