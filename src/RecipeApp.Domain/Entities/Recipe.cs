using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecipeApp.Domain.Entities;

[Table("Recipes")]
[Index(nameof(UserId))]
[Index(nameof(CountryId))]
[Index(nameof(Name))]
public class Recipe
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(255)]
    [Column("name")]
    public string? Name { get; set; }

    [MaxLength(255)]
    [Column("description")]
    public string? Description { get; set; }

    [Required]
    [Column("country_id")]
    public int CountryId { get; set; }

    [Required]
    [Column("user_id")] 
    public int UserId { get; set; }

    [MaxLength(255)]
    [Column("photo_url")]
    public string? PhotoUrl { get; set; }

    // Propiedades de navegaci�n y llaves for�neas
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    [ForeignKey(nameof(CountryId))]
    public Country Country { get; set; } = null!;

    // Relaciones hijas
    public List<Comment> Comments { get; set; } = [];
    public List<Rating> Ratings { get; set; } = [];
    public List<Step> Steps { get; set; } = [];
    public List<RecipeIngredient> RecipeIngredients { get; set; } = [];
    public List<RecipeFavorite> RecipeFavorites { get; set; } = [];
}