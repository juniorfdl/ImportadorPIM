// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Models.ObjectRetornoPIM
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using System.Collections.Generic;

namespace WorkerImportadorPIM.Models
{
  public class ObjectRetornoPIM
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
      public ObjectRetornoPIM.Self self { get; set; }

      public ObjectRetornoPIM.First first { get; set; }

      public ObjectRetornoPIM.Last last { get; set; }
    }

    public class Item
    {
      public string nome { get; set; }

      public string telefone { get; set; }

      public string email { get; set; }

      public string data_cadastro { get; set; }

      public string anotacoes_internas { get; set; }

      public int id { get; set; }
    }

    public class Embedded
    {
      public List<ObjectRetornoPIM.Item> items { get; set; }
    }

    public class Root
    {
      public int page { get; set; }

      public int limit { get; set; }

      public int pages { get; set; }

      public int total { get; set; }

      public ObjectRetornoPIM.Links _links { get; set; }

      public ObjectRetornoPIM.Embedded _embedded { get; set; }
    }
  }
}
