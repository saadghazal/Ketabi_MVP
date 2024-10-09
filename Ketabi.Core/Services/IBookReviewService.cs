using Ketabi.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.Services
{
    public interface IBookReviewService
    {
        List<Bookreview> GetAllReview();
        void AddReview(Bookreview bookreview);
        void UpdateReview(Bookreview bookreview);
        void DeleteReview(int id);
        Bookreview GetReviewById(int id);
        List<Bookreview> GetReviewByrating(string rating);
    }
}
