using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSW4.Domain.Entities;

[Table("Comments")]
[Index(nameof(RecipeId))]
public class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("user_id")]
    public int UserId { get; set; }

    [Required]
    [Column("recipe_id")]
    public int RecipeId { get; set; }

    [MaxLength(255)]
    [Column("title")]
    public string? Title { get; set; }

    [MaxLength(255)]
    [Column("description")]
    public string? Description { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    [ForeignKey(nameof(RecipeId))]
    public Recipe Recipe { get; set; } = null!;
}