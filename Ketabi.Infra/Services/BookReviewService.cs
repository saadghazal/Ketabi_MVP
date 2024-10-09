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
    public class BookReviewService : IBookReviewService
    {
        private readonly IBookReviewRepository _bookReviewRepository;
        public BookReviewService (IBookReviewRepository bookReviewRepository)
        {
            _bookReviewRepository = bookReviewRepository;
        }
        public List<Bookreview> GetAllReview()
        {
            return _bookReviewRepository.GetAllReview();
        }
        public void AddReview(Bookreview bookreview)
        {
            _bookReviewRepository.AddReview(bookreview);
        }
        public void UpdateReview(Bookreview bookreview)
        {
            _bookReviewRepository.UpdateReview(bookreview);
        }
        public void DeleteReview(int id)
        {
            _bookReviewRepository.DeleteReview(id);
        }
        public Bookreview GetReviewById(int id)
        {
            return _bookReviewRepository.GetReviewById(id);
        }
        public List<Bookreview> GetReviewByrating(string rating)
        {
            return _bookReviewRepository.GetReviewByrating(rating);
        }
    }
}
