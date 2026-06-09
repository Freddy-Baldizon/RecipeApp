using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecipeApp.Domain.Entities;

[Table("Countries")]
[Index(nameof(Name), IsUnique = true)]
[Index(nameof(IsoAlpha3), IsUnique = true)]
public class Country
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(255)]
    [Required]
    [Column("name")]
    public required string Name { get; set; }

    [MaxLength(255)]
    [Column("flag_url")] 
    public string? FlagUrl { get; set; }

    [MaxLength(255)]
    [Column("iso_alpha3")]
    public string? IsoAlpha3 { get; set; }

    // Relaciones
    public List<Recipe> Recipes { get; set; } = [];
}