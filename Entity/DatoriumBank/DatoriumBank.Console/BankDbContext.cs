﻿using DatoriumBank.Console;
using Microsoft.EntityFrameworkCore;

public class BankDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public BankDbContext()
    {
        base.Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=madatabase.db;");
    }
}
