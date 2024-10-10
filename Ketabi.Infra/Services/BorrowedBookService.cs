using Ketabi.Core.Data;
using Ketabi.Core.DTO;
using Ketabi.Core.Repositories;
using Ketabi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Infra.Services
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly IBorrowedBookRepository _borrowedBookRepository;
        public BorrowedBookService (IBorrowedBookRepository borrowedBookRepository)
        {
            _borrowedBookRepository = borrowedBookRepository;
        }
        public List<Borrowedbook> GetAllBorrowed()
        {
            return _borrowedBookRepository.GetAllBorrowed();
        }
        public void CreateNewBorrow(Borrowedbook borrowedbook)
        {
            _borrowedBookRepository.CreateNewBorrow(borrowedbook);
        }
        public void ChangeStatusToReturned(int id)
        {
            _borrowedBookRepository.ChangeStatusToReturned(id);
        }
        public void ChangeStatusToRequireFees(int id)
        {
            _borrowedBookRepository.ChangeStatusToRequireFees(id);
        }
        public void DeleteBorrowed(int id)
        {
            _borrowedBookRepository.DeleteBorrowed(id);
        }
        public Borrowedbook GetBorrowById(int id)
        {
            return _borrowedBookRepository.GetBorrowById(id);
        }
        public List<HistoryOfBorrowing> GethistoryOfborrowingByuserId(int userid)
        {
            return _borrowedBookRepository.GethistoryOfborrowingByuserId(userid);
        }
    }
}
