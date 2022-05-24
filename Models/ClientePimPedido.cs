// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Models.PedidosEtapas
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerImportadorPIM.Models
{
  [Table("clientespimpedidoetapas")]
  public class PedidosEtapas
  {
    public int id { get; set; }

    public int pedido_id { get; set; }

    public string status { get; set; }

    public string finalizado { get; set; }

    public DateTime? data_criacao { get; set; }

    public DateTime? data_atualizacao { get; set; }
  }
}
