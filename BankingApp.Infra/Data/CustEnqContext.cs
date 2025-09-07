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

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

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

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);

                entity.Property(c => c.CustomerId)
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(c => c.Name)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(c => c.Email)
                      .HasMaxLength(100);

                entity.Property(c => c.Phone)
                      .HasMaxLength(20);

                entity.Property(c => c.IsApproved)
                      .IsRequired();

                // Navigation properties
                entity.HasMany(c => c.Accounts)
                      .WithOne()
                      .HasForeignKey(a => a.CustomerId)
                      .IsRequired(false);

                entity.HasMany(c => c.Loans)
                      .WithOne()
                      .HasForeignKey(l => l.CustomerId)
                      .IsRequired(false);
            });

            modelBuilder.Entity<Account>()
            .HasMany(a => a.Transactions)
            .WithOne(t => t.Account)
            .HasForeignKey(t => t.AccountNumber);
        }
    }
}
