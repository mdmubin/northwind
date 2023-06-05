using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities;

[Table("Reviews")]
public class Review
{
    [Key]
    public Guid Id { get; set; }

    //

    public int Rating { get; set; }

    [StringLength(500)]
    public string Content { get; set; } = string.Empty;

    //

    [ForeignKey(nameof(Item))]
    public Guid ItemId { get; set; }

    public Item Item { get; set; }


    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public User User { get; set; }
}