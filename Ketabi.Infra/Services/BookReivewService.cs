using Ketabi.Core.Data;
using Ketabi.Core.Repositories;
using Ketabi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Infra.Services
{
    public class BookReivewService : IBookReivewService
    {
        private readonly IBookReivewRepository _bookReivewRepository;

        public BookReivewService(IBookReivewRepository bookReivewRepository)
        {
            _bookReivewRepository = bookReivewRepository;
        }
        public List<Bookreview> GetAllReview()
        {
            return _bookReivewRepository.GetAllReview();
        }
        public void AddReview(Bookreview review)
        {
            _bookReivewRepository.AddReview(review);
        }
        public void UpdateReview(Bookreview review)
        {
            _bookReivewRepository.UpdateReview(review);
        }
        public void DeleteReview(int id)
        {
            _bookReivewRepository.DeleteReview(id);
        }
        public Bookreview GetReviewById(int id)
        {
            return _bookReivewRepository.GetReviewById(id);
        }
        public List<Bookreview> GetReviewByrating(int rating)
        {
            return _bookReivewRepository.GetReviewByrating(rating);
        }

    }
}
