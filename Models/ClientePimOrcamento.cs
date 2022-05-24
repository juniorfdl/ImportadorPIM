// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Models.OrcamentoItem
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerImportadorPIM.Models
{
  [Table("clientespimorcamentoitem")]
  public class OrcamentoItem
  {
    public int id { get; set; }

    public string produto_sku { get; set; }

    public int? produto_variacao_id { get; set; }

    public double? valor_total { get; set; }

    public int? quantidade { get; set; }

    public double? valor_unitario { get; set; }

    public string pedido { get; set; }

    public string produto_nome { get; set; }

    public int? orcamento_id { get; set; }
  }
}
