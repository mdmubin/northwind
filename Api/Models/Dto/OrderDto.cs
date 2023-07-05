namespace Api.Models.Dto;

public class OrderedItemDto
{
    public Guid ItemId { get; set; }
    public int AmountOrdered { get; set; }
}

public class OrderResultDto
{
    public Guid Id { get; set; }

    public DateTime DateTimeOrdered { get; set; }

    public bool Delivered { get; set; }

    public Guid UserId { get; set; }
}

public class OrderResultDetailsDto
{
    public Guid Id { get; set; }

    public DateTime DateTimeOrdered { get; set; }

    public bool Delivered { get; set; }

    public Guid UserId { get; set; }

    public ICollection<OrderedItemDto> OrderedItems { get; set; }
}

public class OrderRequestDto
{
    public DateTime DateTimeOrdered { get; set; }

    public Guid UserId { get; set; }

    public ICollection<OrderedItemDto> OrderedItems { get; set; }
}