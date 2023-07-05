using Api.Entities;
using Api.Models.Requests;

namespace Api.Data.Repositories;

public class ReviewRepository : BaseRepository<Review>
{
    public ReviewRepository(NorthwindContext context) : base(context)
    {
    }

    public async Task<PagedList<Review>> GetAllUserReviewsAsync(Guid userId, PageSizeRequest sizeRequest,
        bool trackChanges)
    {
        var reviews = FindByCondition(r => r.UserId == userId, trackChanges)
            .OrderBy(r => r.DateTimeReviewed);

        return await PagedList<Review>.ToPagedList(reviews, sizeRequest.PageNumber, sizeRequest.PageSize);
    }

    public async Task<PagedList<Review>> GetAllItemReviewsAsync(Guid itemId, PageSizeRequest sizeRequest,
        bool trackChanges)
    {
        var reviews = FindByCondition(r => r.ItemId == itemId, trackChanges)
            .OrderBy(r => r.DateTimeReviewed);

        return await PagedList<Review>.ToPagedList(reviews, sizeRequest.PageNumber, sizeRequest.PageSize);
    }
}
