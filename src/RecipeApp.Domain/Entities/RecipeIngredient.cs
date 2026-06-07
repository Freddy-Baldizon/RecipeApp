using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSW4.Domain.Entities;

[Table("RecipeIngredients")]
[Index(nameof(RecipeId))]
[Index(nameof(IngredientId))]
public class RecipeIngredient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("recipe_id")]
    public int RecipeId { get; set; }

    [Required]
    [Column("ingredient_id")]
    public int IngredientId { get; set; }

    [MaxLength(255)]
    [Column("amount")]
    public string? Amount { get; set; }

    [ForeignKey(nameof(RecipeId))]
    public Recipe Recipe { get; set; } = null!;

    [ForeignKey(nameof(IngredientId))]
    public Ingredient Ingredient { get; set; } = null!;
}