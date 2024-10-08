using Ketabi.Core.Data;
using Ketabi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ketabi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReivewController : ControllerBase
    {
        private readonly IBookReivewService _bookReivewService;
        public BookReivewController (IBookReivewService bookReivewService)
        {
            _bookReivewService = bookReivewService;
        }
        [HttpGet]
        [Route("GetAllReview")]
        public List<Bookreview> GetAllReview()
        {
            return _bookReivewService.GetAllReview();
        }
        [HttpPost]
        [Route("AddReview")]
        public void AddReview(Bookreview review)
        {
            _bookReivewService.AddReview(review);
        }
        [HttpPut]
        [Route("UpdateReview")]
        public void UpdateReview(Bookreview review)
        {
            _bookReivewService.UpdateReview(review);
        }
        [HttpDelete]
        [Route("DeleteReview")]
        public void DeleteReview(int id)
        {
            _bookReivewService.DeleteReview(id);
        }
        [HttpGet]
        [Route("GetReviewById")]
        public Bookreview GetReviewById(int id)
        {
            return _bookReivewService.GetReviewById(id);
        }
        [HttpGet]
        [Route("GetReviewByrating")]
        public List<Bookreview> GetReviewByrating(int rating)
        {
            return _bookReivewService.GetReviewByrating(rating);
        }
    }
}
