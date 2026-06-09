using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecipeApp.Domain.Entities;

[Table("Users")]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Username), IsUnique = true)]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(255)]
    [Required]
    [Column("email")]
    public required string Email { get; set; }

    [MaxLength(255)]
    [Required]
    [Column("username")]
    public required string Username { get; set; }

    [MaxLength(255)]
    [Column("password")]
    public string? Password { get; set; }

    [MaxLength(255)]
    [Column("avatar")]
    public string? Avatar { get; set; }

    // Relaciones
    public List<Recipe> Recipes { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];
    public List<Rating> Ratings { get; set; } = [];
    public List<RecipeFavorite> RecipeFavorites { get; set; } = [];
}