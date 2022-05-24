// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Models.ClientesPimEndereco
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerImportadorPIM.Models
{
  [Table("clientespimendereco")]
  public class ClientesPimEndereco
  {
    public int id { get; set; }

    public string municipio { get; set; }

    public string estado { get; set; }

    public string cep { get; set; }

    public string logradouro { get; set; }

    public string numero { get; set; }

    public string bairro { get; set; }

    public string complemento { get; set; }

    public string identificacao { get; set; }

    public string nome_destinatario { get; set; }

    public DateTime? data_cadastro { get; set; }

    public DateTime? data_atualizacao { get; set; }
  }
}
