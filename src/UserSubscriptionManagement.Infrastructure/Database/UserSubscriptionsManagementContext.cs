﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UserSubscriptionManagement.Infrastructure.Entities;

namespace UserSubscriptionManagement.Infrastructure.Database;

public partial class UserSubscriptionsManagementContext : DbContext
{
    public UserSubscriptionsManagementContext(DbContextOptions<UserSubscriptionsManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminTypes> AdminTypes { get; set; }

    public virtual DbSet<Subscriptions> Subscriptions { get; set; }

    public virtual DbSet<UserSubscriptions> UserSubscriptions { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<UsersProfile> UsersProfile { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminTypes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__admin_ty__3213E83FFE1E983F");
        });

        modelBuilder.Entity<Subscriptions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subscrip__3213E83FE0F6AA99");

            entity.Property(e => e.Duration).HasDefaultValueSql("((30))");
        });

        modelBuilder.Entity<UserSubscriptions>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.SubscriptionId }).HasName("PK__user_sub__B1DD90E3BAFF299E");

            entity.HasOne(d => d.Subscription).WithMany(p => p.UserSubscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_subs__subsc__59FA5E80");

            entity.HasOne(d => d.User).WithMany(p => p.UserSubscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_subs__user___59063A47");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F7BD11D10");

            entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.AdminType).WithMany(p => p.Users).HasConstraintName("FK__users__admin_typ__5441852A");

            entity.HasOne(d => d.Profile).WithMany(p => p.Users).HasConstraintName("FK__users__profile_i__534D60F1");
        });

        modelBuilder.Entity<UsersProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users_pr__3213E83FDE9F7E2F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}