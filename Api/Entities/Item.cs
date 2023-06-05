using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities;

[Table("Items")]
public class Item
{
    [Key]
    public Guid Id { get; set; }

    //

    [Required(ErrorMessage = "Item name cannot be empty")]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string DisplayImage { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [StringLength(100)]
    public string Manufacturer { get; set; } = string.Empty;

    [Required]
    public double Price { get; set; }

    public double AverageRating { get; set; } = 0.0;

    public double PercentDiscount { get; set; } = 0.0;

    [Required]
    public int AmountInStock { get; set; } = 0;

    //

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public User User { get; set; }

    public ICollection<Review> UserReviews { get; set; }

    public ICollection<OrderEntry> Orders { get; set; }
}