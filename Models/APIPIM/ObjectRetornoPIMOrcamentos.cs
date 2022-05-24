// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Models.ObjectRetornoPimOrcamentos
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using System.Collections.Generic;

namespace WorkerImportadorPIM.Models
{
  public class ObjectRetornoPimOrcamentos
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

    public class Next
    {
      public string href { get; set; }
    }

    public class Links
    {
      public ObjectRetornoPimOrcamentos.Self self { get; set; }

      public ObjectRetornoPimOrcamentos.First first { get; set; }

      public ObjectRetornoPimOrcamentos.Last last { get; set; }

      public ObjectRetornoPimOrcamentos.Next next { get; set; }

      public ObjectRetornoPimOrcamentos.Cliente cliente { get; set; }
    }

    public class PedidoItem
    {
      public string produto_sku { get; set; }

      public int produto_variacao_id { get; set; }

      public string valor_total { get; set; }

      public int quantidade { get; set; }

      public double? valor_unitario { get; set; }

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
      public double? valor_desconto { get; set; }

      public double? valor_total { get; set; }

      public string endereco_entrega { get; set; }

      public string forma_pagamento { get; set; }

      public int? cliente_id { get; set; }

      public string codigo_faturamento_direto { get; set; }

      public int id { get; set; }

      public string data_criacao { get; set; }

      public string data_atualizacao { get; set; }

      public double? valor_itens { get; set; }

      public double? valor_entrega { get; set; }

      public string frete { get; set; }

      public string frete_prazo { get; set; }

      public string status { get; set; }

      public List<ObjectRetornoPimOrcamentos.PedidoItem> pedido_items { get; set; }

      public int ack { get; set; }

      public ObjectRetornoPimOrcamentos.Links _links { get; set; }
    }

    public class Embedded
    {
      public List<ObjectRetornoPimOrcamentos.Item> items { get; set; }
    }

    public class Root
    {
      public int page { get; set; }

      public int limit { get; set; }

      public int pages { get; set; }

      public int total { get; set; }

      public ObjectRetornoPimOrcamentos.Links _links { get; set; }

      public ObjectRetornoPimOrcamentos.Embedded _embedded { get; set; }
    }
  }
}
