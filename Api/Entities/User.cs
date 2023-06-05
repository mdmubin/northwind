using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities;

public class User : IdentityUser<Guid>
{
    [StringLength(500)]
    public string ProfilePicture { get; set; } = string.Empty;

    [StringLength(500)]
    public string BannerPicture { get; set; } = string.Empty;

    public AddressInfo DeliveryAddress { get; set; }

    [StringLength(100)]
    public string OrganizationName { get; set; } = string.Empty;

    [StringLength(100)]
    public string BusinessEmail { get; set; } = string.Empty;

    //

    public ICollection<Order> AllOrders { get; set; }

    public ICollection<Review> ItemReviews { get; set; }

    public ICollection<Item> ItemsOnSale { get; set; }
}

[Owned]
public class AddressInfo
{
    [StringLength(100)]
    public string HomeNumber { get; set; }

    [StringLength(100)]
    public string StreetName { get; set; }

    [StringLength(100)]
    public string District { get; set; }

    [StringLength(100)]
    public string CityName { get; set; }

    [StringLength(100)]
    public uint PostalCode { get; set; }
}