using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecipeApp.Domain.Entities;

[Table("Steps")]
[Index(nameof(RecipeId))]
public class Step
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("recipe_id")]
    public int RecipeId { get; set; }

    [MaxLength(255)]
    [Column("name")]
    public string? Name { get; set; }

    [MaxLength(255)]
    [Column("description")]
    public string? Description { get; set; }

    [Required]
    [Column("order")]
    public int Order { get; set; }

    [ForeignKey(nameof(RecipeId))]
    public Recipe Recipe { get; set; } = null!;
}