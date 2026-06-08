using Microsoft.EntityFrameworkCore;
using ProyectoSW4.Domain.Entities;

namespace RecipeApp.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Comment> Comments { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<Ingredient> Ingredient { get; set; }
    public DbSet<Rating> Rating { get; set; }
    public DbSet<Recipe> Recipe { get; set; }
    public DbSet<RecipeFavorite> RecipeFavorite { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
    public DbSet<Step> Step { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.Avatar)
                .HasMaxLength(500);

            entity.HasIndex(e => e.Email)
                .IsUnique();

            entity.HasIndex(e => e.Username)
                .IsUnique();
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Countries");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.FlagUrl)
                .HasMaxLength(500);

            entity.Property(e => e.IsoAlpha3)
                .IsRequired()
                .HasMaxLength(3);

            entity.HasIndex(e => e.Name)
                .IsUnique();

            entity.HasIndex(e => e.IsoAlpha3)
                .IsUnique();
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.ToTable("Recipes");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Description)
                .HasMaxLength(2000);

            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(500);

            entity.HasIndex(e => e.UserId);

            entity.HasIndex(e => e.CountryId);

            entity.HasIndex(e => e.Name);

            entity.HasOne(e => e.User)
                .WithMany(u => u.Recipes)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Country)
                .WithMany(c => c.Recipes)
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comments");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .HasMaxLength(200);

            entity.Property(e => e.Description)
                .HasMaxLength(2000);

            entity.HasIndex(e => e.RecipeId);

            entity.HasOne(e => e.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Recipe)
                .WithMany(r => r.Comments)
                .HasForeignKey(e => e.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.ToTable("Ratings");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Value)
                .IsRequired();

            entity.HasIndex(e => e.RecipeId);

            entity.HasIndex(e => new { e.UserId, e.RecipeId })
                .IsUnique();

            entity.HasOne(e => e.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Recipe)
                .WithMany(r => r.Ratings)
                .HasForeignKey(e => e.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Step>(entity =>
        {
            entity.ToTable("Steps");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Description)
                .HasMaxLength(4000);

            entity.Property(e => e.Order)
                .IsRequired();

            entity.HasIndex(e => e.RecipeId);

            entity.HasOne(e => e.Recipe)
                .WithMany(r => r.Steps)
                .HasForeignKey(e => e.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("Ingredients");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasIndex(e => e.Name)
                .IsUnique();
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.ToTable("RecipeIngredients");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Amount)
                .HasMaxLength(100);

            entity.HasIndex(e => e.RecipeId);

            entity.HasIndex(e => e.IngredientId);

            entity.HasOne(e => e.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(e => e.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(e => e.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<RecipeFavorite>(entity =>
        {
            entity.ToTable("RecipeFavorites");

            entity.HasKey(e => new { e.UserId, e.RecipeId });

            entity.Property(e => e.CreatedAt)
                .HasColumnType("date");

            entity.HasIndex(e => new { e.UserId, e.RecipeId })
                .IsUnique();

            entity.HasOne(e => e.User)
                .WithMany(u => u.RecipeFavorites)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Recipe)
                .WithMany(r => r.RecipeFavorites)
                .HasForeignKey(e => e.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

}