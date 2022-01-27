﻿using Forum.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Infrastructure.Repositories
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public AppDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(a => a.UserInfo)
                .WithOne(b => b.User)
                .HasForeignKey<UserInfo>(c => c.UserId);

            modelBuilder.Entity<User>()
                .HasMany(a => a.UserPosts)
                .WithOne(b => b.Author);

            modelBuilder.Entity<Post>()
                .HasOne(a => a.Author)
                .WithMany(b => b.UserPosts);
        }

        public DbSet<Comment> Comment { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

    }
}
