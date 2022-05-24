// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Models.ContextInfotec
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;

namespace WorkerImportadorPIM.Models
{
  public class ContextInfotec : DbContext
  {
    public DbSet<WorkerImportadorPIM.Models.ClientesPimIntegracao> ClientesPimIntegracao { get; set; }

    public DbSet<WorkerImportadorPIM.Models.ClientesPIM> ClientesPIM { get; set; }

    public DbSet<WorkerImportadorPIM.Models.ClientesPimEndereco> ClientesPimEndereco { get; set; }

    public DbSet<WorkerImportadorPIM.Models.ClientesPimContato> ClientesPimContato { get; set; }

    public DbSet<WorkerImportadorPIM.Models.OrcamentoItem> OrcamentoItem { get; set; }

    public DbSet<WorkerImportadorPIM.Models.Orcamento> Orcamento { get; set; }

    public DbSet<WorkerImportadorPIM.Models.PedidosEtapas> PedidosEtapas { get; set; }

    public DbSet<WorkerImportadorPIM.Models.PedidoItem> PedidoItem { get; set; }

    public DbSet<WorkerImportadorPIM.Models.Pedido> Pedido { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      string connectionString = Domain.Settings.ConnectionString;
      optionsBuilder.UseMySQL(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<WorkerImportadorPIM.Models.ClientesPimIntegracao>((Action<EntityTypeBuilder<WorkerImportadorPIM.Models.ClientesPimIntegracao>>) (entity => entity.HasKey((Expression<Func<WorkerImportadorPIM.Models.ClientesPimIntegracao, object>>) (e => (object) e.id))));
      modelBuilder.Entity<WorkerImportadorPIM.Models.ClientesPIM>((Action<EntityTypeBuilder<WorkerImportadorPIM.Models.ClientesPIM>>) (entity => entity.HasKey((Expression<Func<WorkerImportadorPIM.Models.ClientesPIM, object>>) (e => (object) e.id))));
      modelBuilder.Entity<WorkerImportadorPIM.Models.ClientesPimEndereco>((Action<EntityTypeBuilder<WorkerImportadorPIM.Models.ClientesPimEndereco>>) (entity => entity.HasKey((Expression<Func<WorkerImportadorPIM.Models.ClientesPimEndereco, object>>) (e => (object) e.id))));
      modelBuilder.Entity<WorkerImportadorPIM.Models.ClientesPimContato>((Action<EntityTypeBuilder<WorkerImportadorPIM.Models.ClientesPimContato>>) (entity => entity.HasKey((Expression<Func<WorkerImportadorPIM.Models.ClientesPimContato, object>>) (e => (object) e.id))));
      modelBuilder.Entity<WorkerImportadorPIM.Models.OrcamentoItem>((Action<EntityTypeBuilder<WorkerImportadorPIM.Models.OrcamentoItem>>) (entity => entity.HasKey((Expression<Func<WorkerImportadorPIM.Models.OrcamentoItem, object>>) (e => (object) e.id))));
      modelBuilder.Entity<WorkerImportadorPIM.Models.Orcamento>((Action<EntityTypeBuilder<WorkerImportadorPIM.Models.Orcamento>>) (entity => entity.HasKey((Expression<Func<WorkerImportadorPIM.Models.Orcamento, object>>) (e => (object) e.id))));
      modelBuilder.Entity<WorkerImportadorPIM.Models.Pedido>((Action<EntityTypeBuilder<WorkerImportadorPIM.Models.Pedido>>) (entity => entity.HasKey((Expression<Func<WorkerImportadorPIM.Models.Pedido, object>>) (e => (object) e.id))));
      modelBuilder.Entity<WorkerImportadorPIM.Models.PedidoItem>((Action<EntityTypeBuilder<WorkerImportadorPIM.Models.PedidoItem>>) (entity => entity.HasKey((Expression<Func<WorkerImportadorPIM.Models.PedidoItem, object>>) (e => (object) e.id))));
      modelBuilder.Entity<WorkerImportadorPIM.Models.PedidosEtapas>((Action<EntityTypeBuilder<WorkerImportadorPIM.Models.PedidosEtapas>>) (entity => entity.HasKey((Expression<Func<WorkerImportadorPIM.Models.PedidosEtapas, object>>) (e => new
      {
        id = e.id,
        pedido_id = e.pedido_id
      }))));
    }
  }
}
