// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Models.ObjectRetornoPimPedidos
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using System.Collections.Generic;

namespace WorkerImportadorPIM.Models
{
  public class ObjectRetornoPimPedidos
  {
    public class Self
    {
      public string href { get; set; }
    }

    public class First
    {
      public string href { get; set; }
    }

    public class Last
    {
      public string href { get; set; }
    }

    public class Links
    {
      public ObjectRetornoPimPedidos.Self self { get; set; }

      public ObjectRetornoPimPedidos.First first { get; set; }

      public ObjectRetornoPimPedidos.Last last { get; set; }

      public ObjectRetornoPimPedidos.Cliente cliente { get; set; }
    }

    public class Etapa
    {
      public int id { get; set; }

      public string status { get; set; }

      public bool finalizado { get; set; }

      public string data_criacao { get; set; }

      public string data_atualizacao { get; set; }
    }

    public class PedidoItem
    {
      public string produto_sku { get; set; }

      public int produto_variacao_id { get; set; }

      public string valor_total { get; set; }

      public int quantidade { get; set; }

      public double valor_unitario { get; set; }

      public int id { get; set; }

      public string pedido { get; set; }

      public string produto_nome { get; set; }
    }

    public class Cliente
    {
      public string href { get; set; }
    }

    public class Item
    {
      public List<ObjectRetornoPimPedidos.Etapa> etapas { get; set; }

      public double? valor_desconto { get; set; }

      public double? valor_total { get; set; }

      public string endereco_entrega { get; set; }

      public string forma_pagamento { get; set; }

      public int cliente_id { get; set; }

      public string codigo_faturamento_direto { get; set; }

      public int id { get; set; }

      public string data_criacao { get; set; }

      public string data_atualizacao { get; set; }

      public double? valor_itens { get; set; }

      public double? valor_entrega { get; set; }

      public string codigo_rastreio { get; set; }

      public string frete { get; set; }

      public string frete_prazo { get; set; }

      public string status { get; set; }

      public List<ObjectRetornoPimPedidos.PedidoItem> pedido_items { get; set; }

      public int ack { get; set; }

      public ObjectRetornoPimPedidos.Links _links { get; set; }
    }

    public class Embedded
    {
      public List<ObjectRetornoPimPedidos.Item> items { get; set; }
    }

    public class Root
    {
      public int page { get; set; }

      public int limit { get; set; }

      public int pages { get; set; }

      public int total { get; set; }

      public ObjectRetornoPimPedidos.Links _links { get; set; }

      public ObjectRetornoPimPedidos.Embedded _embedded { get; set; }
    }
  }
}
