using System.ComponentModel.DataAnnotations;

namespace Student.Api.Models;

public class Person
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
    [Required]
    [MaxLength(50)]
    [EmailAddress]
    public string? Email { get; set; }
}
