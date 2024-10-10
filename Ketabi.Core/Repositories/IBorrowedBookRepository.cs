using Ketabi.Core.Data;
using Ketabi.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.Repositories
{
    public interface IBorrowedBookRepository
    {
        List<Borrowedbook> GetAllBorrowed();
        void CreateNewBorrow (Borrowedbook borrowedbook);
        void ChangeStatusToReturned(int id);
        void ChangeStatusToRequireFees(int id);
        void DeleteBorrowed(int id);
        Borrowedbook GetBorrowById(int id);
        List<HistoryOfBorrowing> GethistoryOfborrowingByuserId (int userid);
    }
}
