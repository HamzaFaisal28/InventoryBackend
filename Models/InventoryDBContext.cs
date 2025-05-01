#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventoryBackend.Models;

public partial class InventoryDBContext : DbContext
{
    public InventoryDBContext(DbContextOptions<InventoryDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InventoryItem> InventoryItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryItem>(entity =>
        {
            // Set primary key using Fluent API
            entity.HasKey(e => e.Id);

            // Define table name for MySQL
            entity.ToTable("InventoryItem");

            // Set default value for DateAdded to CURRENT_TIMESTAMP for MySQL
            entity.Property(e => e.DateAdded).HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Define a required field for Name with maximum length of 100 characters
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
