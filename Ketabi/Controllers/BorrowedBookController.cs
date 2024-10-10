using Ketabi.Core.Data;
using Ketabi.Core.DTO;
using Ketabi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ketabi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedBookController : ControllerBase
    {
        private readonly IBorrowedBookService _borrowedBookService;
        public BorrowedBookController (IBorrowedBookService borrowedBookService)
        {
            _borrowedBookService = borrowedBookService;
        }
        [HttpGet]
        [Route("GetAllBorrowed")]
        public List<Borrowedbook> GetAllBorrowed()
        {
            return _borrowedBookService.GetAllBorrowed();
        }
        [HttpPost]
        [Route("")]
        public void CreateNewBorrow(Borrowedbook borrowedbook)
        {
            _borrowedBookService.CreateNewBorrow(borrowedbook);
        }
        [HttpPut]
        [Route("Returned")]
        public void ChangeStatusToReturned(int id)
        {
            _borrowedBookService.ChangeStatusToReturned(id);
        }
        [HttpPut]
        [Route("RequireFees")]
        public void ChangeStatusToRequireFees(int id)
        {
            _borrowedBookService.ChangeStatusToRequireFees(id);
        }
        [HttpDelete]
        [Route("DeleteBorrowed")]
        public void DeleteBorrowed(int id)
        {
            _borrowedBookService.DeleteBorrowed(id);
        }
        [HttpGet]
        [Route("GetBorrowById")]
        public Borrowedbook GetBorrowById(int id)
        {
            return _borrowedBookService.GetBorrowById(id);
        }
        [HttpGet]
        [Route("HistoryOfBorrowing")]
        public List<HistoryOfBorrowing> GethistoryOfborrowingByuserId(int userid)
        {
            return _borrowedBookService.GethistoryOfborrowingByuserId(userid);
        }
    }
}
