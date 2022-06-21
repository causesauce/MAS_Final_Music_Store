using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public interface IReviewRepository
    {
        List<Review> GetAllReviewsByCustomerId(int customerId);
        List<Review> GetAllReviews();
        Review GetReviewById(int id);
        Review UpdateReview(int id, Review review);
        Review CreateReview(Review review);
        bool RemoveReview(int id);
    }
}
