using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [StringLength(500)]
        [MinLength(1, ErrorMessage = "Team Name cannot be less than 1")]
        public string Content { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
        [Range(0, 5)]
        public double Rating { get; set; }
        public bool WasEdited { get; set; }

        public int CustomerId { get; set; }
        public Person CustomerIdNavigation { get; set; }
        public int InstrumentId { get; set; }
        public Instrument InstrumentIdNavigation { get; set; }


        public static List<Review> GetDummyReviews()
        {
            var reviews = new List<Review>
            {
                new Review
                {
                    ReviewId=1,
                    Content="content1",
                    Image = null,
                    Rating = 4.9,
                    Date = DateTime.Now
                },
                new Review
                {
                    ReviewId=2,
                    Content="content2",
                    Image = null,
                    Rating = 3.0,
                    Date = DateTime.Now.AddDays(-2)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                },
                new Review
                {
                    ReviewId=3,
                    Content="content3",
                    Image = null,
                    Rating = 4.3,
                    Date = DateTime.Now.AddDays(-1)
                }
            };

            return reviews;
        }
    }
}
