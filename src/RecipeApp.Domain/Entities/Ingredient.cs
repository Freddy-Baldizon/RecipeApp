using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSW4.Domain.Entities;

[Table("Ingredients")]
[Index(nameof(Name), IsUnique = true)]
public class Ingredient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(255)]
    [Required]
    [Column("name")]
    public required string Name { get; set; }

    public List<RecipeIngredient> RecipeIngredients { get; set; } = [];
}