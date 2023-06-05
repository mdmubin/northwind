using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities;

[Table("OrderEntries")]
public class OrderEntry
{
    [Key]
    public Guid Id { get; set; }

    //

    [Required]
    public int AmountOrdered { get; set; } = 1;

    //

    [ForeignKey(nameof(Order))]
    public Guid OrderId { get; set; }

    public Order Order { get; set; }


    [ForeignKey(nameof(Item))]
    public Guid ItemId { get; set; }

    public Item ItemOrdered { get; set; }
}