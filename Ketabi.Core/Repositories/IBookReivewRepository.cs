using Ketabi.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.Repositories
{
    public interface IBookReivewRepository
    {
        List<Bookreview> GetAllReview();
        void AddReview(Bookreview review);
        public void UpdateReview(Bookreview review);
        void DeleteReview(int id);
        Bookreview GetReviewById(int id);
        List<Bookreview> GetReviewByrating(int rating);
    }
}
