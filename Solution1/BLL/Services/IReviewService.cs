using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    /// <summary>
    /// Service interface for review operations.
    /// </summary>
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetReviewsByBookIdAsync(int bookId);
        Task<ReviewDto> GetReviewByIdAsync(int id);
        Task AddReviewAsync(ReviewDto reviewDto);
        Task DeleteReviewAsync(int id);
    }
}
