// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Models.ClientesPimIntegracao
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerImportadorPIM.Models
{
  [Table("clientespimintegracao")]
  public class ClientesPimIntegracao
  {
    public int id { get; set; }

    public string nome { get; set; }

    public string telefone { get; set; }

    public string email { get; set; }

    public DateTime? data_cadastro { get; set; }

    public string anotacoes_internas { get; set; }

    public string tipointegracao { get; set; }
  }
}
