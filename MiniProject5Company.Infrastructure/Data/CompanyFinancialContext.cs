﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MiniProject5Company.Domain.Entities;

namespace MiniProject5Company.Infrastructure.Data;

public partial class CompanyFinancialContext : DbContext
{
    public CompanyFinancialContext()
    {
    }

    public CompanyFinancialContext(DbContextOptions<CompanyFinancialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Dependant> Dependants { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Workson> Worksons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Deptno).HasName("departments_pkey");

            entity.HasOne(d => d.MgrempnoNavigation).WithMany(p => p.Departments)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("departments_mgrempno_fkey");
        });

        modelBuilder.Entity<Dependant>(entity =>
        {
            entity.HasKey(e => e.Dependantno).HasName("dependant_pkey");

            entity.HasOne(d => d.EmpnoNavigation).WithMany(p => p.Dependants)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dependant_empno_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empno).HasName("employees_pkey");

            entity.Property(e => e.Lastupdateddate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.DeptnoNavigation).WithMany(p => p.Employees).HasConstraintName("fk_deptno");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Projno).HasName("projects_pkey");

            entity.HasOne(d => d.DeptnoNavigation).WithMany(p => p.Projects)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("projects_deptno_fkey");
        });

        modelBuilder.Entity<Workson>(entity =>
        {
            entity.HasKey(e => new { e.Empno, e.Projno }).HasName("workson_pkey");

            entity.HasOne(d => d.EmpnoNavigation).WithMany(p => p.Worksons).HasConstraintName("workson_empno_fkey");

            entity.HasOne(d => d.ProjnoNavigation).WithMany(p => p.Worksons).HasConstraintName("workson_projno_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
