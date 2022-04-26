using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Description { get; set; }
}