using Ketabi.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.DTO
{
    public class FavoriteBookDTO
    {
        public decimal FavoriteBookId { get; set; }
        public Book FavoriteBook { get; set; }
    }
}
