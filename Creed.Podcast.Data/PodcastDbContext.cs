using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Creed.Podcast.Domain.Entities;

namespace Creed.Podcast.Data
{
    public partial class PodcastDbContext : DbContext
    {
        public PodcastDbContext()
        {
        }

        public PodcastDbContext(DbContextOptions<PodcastDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Domain.Entities.Podcast> Podcasts { get; set; } = null!;
        public virtual DbSet<PodcastGenre> PodcastGenres { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Domain.Entities.Podcast>(entity =>
            {
                entity.Property(e => e.PodcastId).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ExplicitContent).HasDefaultValueSql("((0))");

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.Property(e => e.IsClaimed).HasDefaultValueSql("((0))");

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.ListennotesUrl).HasMaxLength(500);

                entity.Property(e => e.Publisher).HasMaxLength(500);

                entity.Property(e => e.RegionId).HasMaxLength(5);

                entity.Property(e => e.Rss).HasMaxLength(500);

                entity.Property(e => e.Thumbnail).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(500);
            });

            modelBuilder.Entity<PodcastGenre>(entity =>
            {
                entity.HasKey(e => new { e.GenreId, e.PodcastId });

                entity.Property(e => e.PodcastId).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.RegionId).HasMaxLength(5);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
