using System.ComponentModel.DataAnnotations;

namespace Cards.Dtos;

public class AppUserDto
{
    public int Id { get; set; }
    public string EmailAddress { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
}

public class CardDto
{
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(225)]
    public string? Description { get; set; }

    [StringLength(7)]
    [RegularExpression("^#[a-fA-F0-9]{6}", ErrorMessage = "Color MUST be inform of #FFFACD")]
    public string Color { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [StringLength(30)]
    [AllowedValues("To Do,In Progress,Done")]
    public string Status { get; set; } = "To Do"; //To Do, In Progress and Done
    public int UserId { get; set; }
}

