using System.ComponentModel.DataAnnotations;

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

    public double AverageRating { get; set; }

    public double PercentDiscount { get; set; }

    public int AmountInStock { get; set; }

    //

    public Guid SellerId { get; set; }
}

public class ItemRequestDto
{
    [Required(ErrorMessage = "Item name is required")]
    public string Name { get; set; }

    public string DisplayImage { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Item manufacturer name is required")]
    public string Manufacturer { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public double Price { get; set; }

    [Range(0.0, 100.0, ErrorMessage = "Percentage must be between 0 and 100.")]
    public double PercentDiscount { get; set; } = 0.0;

    [Range(0, int.MaxValue, ErrorMessage = "Amount must be greater than zero")]
    public int AmountInStock { get; set; } = 0;

    //

    public Guid SellerId { get; set; }
}

public class ItemUpdateDto
{
    public string Name { get; set; }

    public string DisplayImage { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public double Price { get; set; }

    [Range(0.0, 100.0, ErrorMessage = "Percentage must be between 0 and 100.")]
    public double PercentDiscount { get; set; } = 0.0;

    [Range(0, int.MaxValue, ErrorMessage = "Amount must be greater than zero")]
    public int AmountInStock { get; set; } = 0;
}