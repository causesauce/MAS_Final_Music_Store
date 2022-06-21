using MAS_Final_Music_Store.DTOs;
using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public class DbService
    {
        // fetches all the Reviews left by the Customer with speciic id
        public static List<Review> FetchReviewsByCustomerId(int icustomerIdd)
        {
            IReviewRepository rr = new ReviewRepository(new Context());
            return rr.GetAllReviewsByCustomerId(icustomerIdd);
        }

        // simply update a Review using its id and the object itself
        public static Review UpdateReview(int id, Review review)
        {
            IReviewRepository rr = new ReviewRepository(new Context());
            return rr.UpdateReview(id, review);
        }

        // fetches all the Instruments recently bought by the Customer with specified id
        public static List<InstrumentDto> FetchInstrumentsBoughtByCustomerId(int customerId)
        {
            InstrumentRepository ir = new InstrumentRepository(new Context());
            List<InstrumentDto> instrumentDtos = ir.GetAllInstrumentsOwnedByCustomer(customerId);
                                                    
            return instrumentDtos;
        }
    }
}
