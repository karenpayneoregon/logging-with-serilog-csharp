﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using DumpObjectsApp.Data.Configurations;
using DumpObjectsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
#nullable disable

namespace DumpObjectsApp.Data;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactDevices> ContactDevices { get; set; }

    public virtual DbSet<ContactType> ContactType { get; set; }

    public virtual DbSet<Contacts> Contacts { get; set; }

    public virtual DbSet<PhoneType> PhoneType { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NorthWind2024;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.ContactDevicesConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ContactTypeConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ContactsConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.PhoneTypeConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
