using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities;

[Table("Orders")]
public class Order
{
    [Key]
    public Guid Id { get; set; }

    //

    public DateTime DateTimeOrdered { get; set; }

    public bool Delivered { get; set; }

    //

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public User User { get; set; }

    public ICollection<OrderEntry> OrderedItems { get; set; }
}