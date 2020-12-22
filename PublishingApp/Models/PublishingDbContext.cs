using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PublishingApp
{
    public partial class PublishingDbContext : DbContext
    {
        public PublishingDbContext()
        {
        }

        public PublishingDbContext(DbContextOptions<PublishingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorsTable> AuthorsTables { get; set; }
        public virtual DbSet<BooksTable> BooksTables { get; set; }
        public virtual DbSet<GenresTable> GenresTables { get; set; }
        public virtual DbSet<StateTable> StateTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=VADYMKONDRA;Database=PublishingDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AuthorsTable>(entity =>
            {
                entity.HasKey(e => e.AuthorId);

                entity.ToTable("Authors_Table");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Patronymic).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(20);
            });

            modelBuilder.Entity<BooksTable>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.ToTable("Books_Table");

                entity.HasIndex(e => e.BookName, "IX_Books_Table")
                    .IsUnique();

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cover).HasColumnType("image");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.BooksTables)
                    .HasForeignKey(d => d.Author)
                    .HasConstraintName("FK_Books_Table_Authors_Table");

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.BooksTables)
                    .HasForeignKey(d => d.Genre)
                    .HasConstraintName("FK_Books_Table_Genres_Table");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.BooksTables)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("FK_Books_Table_StateTable");
            });

            modelBuilder.Entity<GenresTable>(entity =>
            {
                entity.HasKey(e => e.GenreId);

                entity.ToTable("Genres_Table");

                entity.Property(e => e.GenreName).HasMaxLength(30);
            });

            modelBuilder.Entity<StateTable>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("StateTable");

                entity.Property(e => e.State).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
