// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Models.ObjectRetornoPimClientes
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using System.Collections.Generic;

namespace WorkerImportadorPIM.Models
{
  public class ObjectRetornoPimClientes
  {
    public class Endereco
    {
      public string municipio { get; set; }

      public string estado { get; set; }

      public int id { get; set; }

      public string cep { get; set; }

      public string logradouro { get; set; }

      public string numero { get; set; }

      public string bairro { get; set; }

      public string complemento { get; set; }

      public string identificacao { get; set; }

      public string nome_destinatario { get; set; }

      public string data_cadastro { get; set; }

      public string data_atualizacao { get; set; }

      public string href { get; set; }
    }

    public class Self
    {
      public string href { get; set; }
    }

    public class Links
    {
      public ObjectRetornoPimClientes.Self self { get; set; }

      public ObjectRetornoPimClientes.Self enderecos { get; set; }
    }

    public class Root
    {
      public int id { get; set; }

      public string nome { get; set; }

      public string cpf { get; set; }

      public string telefone { get; set; }

      public string data_nascimento { get; set; }

      public string razao_social { get; set; }

      public string nome_fantasia { get; set; }

      public string inscricao_estadual { get; set; }

      public string cnpj { get; set; }

      public string email { get; set; }

      public string data_cadastro { get; set; }

      public string data_atualizacao { get; set; }

      public List<ObjectRetornoPimClientes.Endereco> enderecos { get; set; }

      public ObjectRetornoPimClientes.Links _links { get; set; }
    }
  }
}
