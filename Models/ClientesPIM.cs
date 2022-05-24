// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Models.ClientesPIM
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerImportadorPIM.Models
{
  [Table("clientespim")]
  public class ClientesPIM
  {
    public int id { get; set; }

    public string nome { get; set; }

    public string telefone { get; set; }

    public string email { get; set; }

    public DateTime? data_cadastro { get; set; }

    public string anotacoes_internas { get; set; }

    public string cpf { get; set; }

    public string cnpj { get; set; }

    public DateTime? data_nascimento { get; set; }

    public string razao_social { get; set; }

    public string nome_fantasia { get; set; }

    public string inscricao_estadual { get; set; }

    public DateTime? data_atualizacao { get; set; }
  }
}
