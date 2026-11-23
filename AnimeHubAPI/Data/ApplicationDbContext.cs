using AnimeHubAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Mangaka> Mangakas { get; set; } = null!;
        public DbSet<Studio> Studios { get; set; } = null!;
        public DbSet<Anime> Animes { get; set; } = null!;
        public DbSet<Saga> Sagas { get; set; } = null!;
        public DbSet<Episode> Episodes { get; set; } = null!;
        public DbSet<VoiceActor> VoiceActors { get; set; } = null!;
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<Ability> Abilities { get; set; } = null!;
        public DbSet<AnimeVideo> AnimeVideos { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<AnimeCategory> AnimeCategories { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Favorite> Favorites { get; set; } = null!;
        public DbSet<ForumPost> ForumPosts { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- CONFIGURACIÓN DE LLAVES COMPUESTAS (Fluent API) ---

            // Configurar la tabla puente AnimeCategory (Muchos a Muchos entre Anime y Category)
            modelBuilder.Entity<AnimeCategory>()
                .HasKey(ac => new { ac.AnimeId, ac.CategoryId });

            modelBuilder.Entity<AnimeCategory>()
                .HasOne(ac => ac.Anime)
                .WithMany(a => a.AnimeCategories)
                .HasForeignKey(ac => ac.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AnimeCategory>()
                .HasOne(ac => ac.Category)
                .WithMany(c => c.AnimeCategories)
                .HasForeignKey(ac => ac.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- RESTRICCIONES Y CONFIGURACIONES ADICIONALES ---

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Anime>(entity =>
            {
                entity.Property(a => a.Title).IsRequired().HasMaxLength(150);
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            });
        }
    }
}