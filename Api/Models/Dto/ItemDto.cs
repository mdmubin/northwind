namespace Api.Models.Dto;

public class ItemResultDto
{
    public Guid Id { get; set; }

    //

    public string Name { get; set; }

    public string DisplayImage { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Manufacturer { get; set; } = string.Empty;

    public double Price { get; set; }

    public double AverageRating { get; set; } = 0.0;

    public double PercentDiscount { get; set; } = 0.0;

    public int AmountInStock { get; set; } = 0;

    //

    public Guid SellerId { get; set; }
}


public class ItemRequestDto
{
    public string Name { get; set; }

    public string DisplayImage { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Manufacturer { get; set; } = string.Empty;

    public double Price { get; set; }

    public double AverageRating { get; set; } = 0.0;

    public double PercentDiscount { get; set; } = 0.0;

    public int AmountInStock { get; set; } = 0;

    //

    public Guid SellerId { get; set; }
}

public class ItemUpdateDto
{
    public string Name { get; set; }

    public string DisplayImage { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Manufacturer { get; set; } = string.Empty;

    public double Price { get; set; }
    
    public double PercentDiscount { get; set; } = 0.0;

    public int AmountInStock { get; set; } = 0;
}