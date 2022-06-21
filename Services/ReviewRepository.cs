using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly Context _context;
        public ReviewRepository(Context context)
        {
            _context = context;
        }

        public Review CreateReview(Review review)
        {
            IPersonRepository pr = new PersonRepository(_context);
            var customerBoughtInstrument = pr.CustomerBoughtInstrumentWithId(review.CustomerId, review.InstrumentId);
            if (!customerBoughtInstrument)
            {
                throw new ArgumentException("Custom constraint violation, Customer haven't bought the Instrument yet");
            }

            var newReview = new Review
            {
                Content = review.Content,
                Image = review.Image,
                Date = review.Date,
                Rating = review.Rating,
                WasEdited = false,
                CustomerId = review.CustomerId,
                InstrumentId = review.InstrumentId
            };

            _context.Reviews.Add(newReview);
            _context.SaveChanges();
            return newReview;
        }

        public List<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }

        public List<Review> GetAllReviewsByCustomerId(int customerId)
        {
            return _context.Reviews.Where(r => r.CustomerId == customerId).ToList();
        }

        public Review GetReviewById(int id)
        {
            return _context.Reviews.Where(r => r.ReviewId == id).FirstOrDefault();
        }

        public bool RemoveReview(int id)
        {
            var review = GetReviewById(id);
            if (review is null)
            {
                return false;
            }

            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return true;
        }

        public Review UpdateReview(int id, Review review)
        {
            var updatedReview = GetReviewById(id);
            if (updatedReview is null)
            {
                return null;
            }

            updatedReview.Content = review.Content;
            updatedReview.Image = review.Image;
            updatedReview.Date = review.Date;
            updatedReview.Rating = review.Rating;
            updatedReview.WasEdited = review.WasEdited;

            _context.SaveChanges();
            return updatedReview;
        }
    }
}
