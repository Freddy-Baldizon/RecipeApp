using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSW4.Domain.Entities;

[Table("RecipeFavorites")]
[PrimaryKey(nameof(UserId), nameof(RecipeId))]
[Index(nameof(UserId), nameof(RecipeId), IsUnique = true)]
public class RecipeFavorite
{
    [Required]
    [Column("recipe_id")]
    public int RecipeId { get; set; }

    [Required]
    [Column("user_id")] 
    public int UserId { get; set; }

    [Required]
    [Column("created_at", TypeName = "date")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(RecipeId))]
    public Recipe Recipe { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
}