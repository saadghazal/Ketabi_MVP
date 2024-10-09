using Ketabi.Core.Data;
using Ketabi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ketabi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReviewController : ControllerBase
    {
        private readonly IBookReviewService _bookReviewService;
        public BookReviewController (IBookReviewService bookReviewService)
        {
            _bookReviewService = bookReviewService;
        }
        [HttpGet]
        [Route("GetAllReview")]
        public List<Bookreview> GetAllReview()
        {
            return _bookReviewService.GetAllReview();
        }
        [HttpPost]
        [Route("AddReview")]
        public void AddReview(Bookreview bookreview)
        {
            _bookReviewService.AddReview(bookreview);
        }
        [HttpPut]
        [Route("UpdateReview")]
        public void UpdateReview(Bookreview bookreview)
        {
            _bookReviewService.UpdateReview(bookreview);
        }
        [HttpDelete]
        [Route("DeleteReview")]
        public void DeleteReview(int id)
        {
            _bookReviewService.DeleteReview(id);
        }
        [HttpGet]
        [Route("GetReviewById")]
        public Bookreview GetReviewById(int id)
        {
            return _bookReviewService.GetReviewById(id);
        }
        [HttpGet]
        [Route("GetReviewByrating")]
        public List<Bookreview> GetReviewByrating(string rating)
        {
            return _bookReviewService.GetReviewByrating(rating);
        }
    }
}
