namespace Api.Models.Dto;

public class ReviewRequestDto
{
    public int Rating { get; set; }

    public string Content { get; set; } = string.Empty;

    public Guid ItemId { get; set; }

    public Guid UserId { get; set; }
}

public class ReviewResultDto
{
    public Guid Id { get; set; }

    public int Rating { get; set; }

    public string Content { get; set; } = string.Empty;

    public DateTime DateTimeReviewed { get; set; }

    public Guid ItemId { get; set; }

    public Guid UserId { get; set; }
}
