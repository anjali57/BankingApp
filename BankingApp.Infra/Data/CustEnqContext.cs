using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infra.Data
{
    public class CustEnqContext : DbContext
    {
        public CustEnqContext(DbContextOptions<CustEnqContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.Id);

                // Configure AccountNumber as auto-increment starting at 100001
                entity.Property(a => a.AccountNumber)
                      .ValueGeneratedNever();

                entity.Property(a => a.Name)
                      .IsRequired();

                entity.Property(a => a.Balance)
                      .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Loan>()
        .Property(l => l.LoanId)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Loan>()
                .Property(l => l.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Loan>()
                .Property(l => l.Status)
                .HasMaxLength(50);

            modelBuilder.Entity<Loan>()
                .Property(l => l.CustomerId)
                .HasMaxLength(20);
        }
    }
}
