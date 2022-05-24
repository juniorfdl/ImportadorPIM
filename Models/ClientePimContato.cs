// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Models.ClientesPimContato
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerImportadorPIM.Models
{
  [Table("clientespimcontato")]
  public class ClientesPimContato
  {
    public int id { get; set; }

    public string nome { get; set; }

    public string telefone { get; set; }

    public string cnpj { get; set; }

    public string segmento { get; set; }

    public string mensagem { get; set; }
  }
}
