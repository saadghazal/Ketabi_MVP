using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.DTO
{
    public class HistoryOfBorrowing
    {
        public decimal Id { get; set; }
        public DateTime? Borrowingdate { get; set; }
        public DateTime? Duedate { get; set; }
        public decimal Bookid { get; set; }
        public string? Bookname { get; set; }
        public string? Image { get; set; }
        public string? Languages { get; set; }

    }
}
