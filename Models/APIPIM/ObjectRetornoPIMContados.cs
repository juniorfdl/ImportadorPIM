// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Models.ObjectRetornoPimContatos
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using System.Collections.Generic;

namespace WorkerImportadorPIM.Models
{
  public class ObjectRetornoPimContatos
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
      public ObjectRetornoPimContatos.Self self { get; set; }

      public ObjectRetornoPimContatos.First first { get; set; }

      public ObjectRetornoPimContatos.Last last { get; set; }
    }

    public class Item
    {
      public string nome { get; set; }

      public string telefone { get; set; }

      public string email { get; set; }

      public string cnpj { get; set; }

      public string segmento { get; set; }

      public int id { get; set; }

      public string mensagem { get; set; }
    }

    public class Embedded
    {
      public List<ObjectRetornoPimContatos.Item> items { get; set; }
    }

    public class Root
    {
      public int page { get; set; }

      public int limit { get; set; }

      public int pages { get; set; }

      public int total { get; set; }

      public ObjectRetornoPimContatos.Links _links { get; set; }

      public ObjectRetornoPimContatos.Embedded _embedded { get; set; }
    }
  }
}
