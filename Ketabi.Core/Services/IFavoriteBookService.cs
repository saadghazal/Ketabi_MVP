using Ketabi.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.Services
{
    public interface IFavoriteBookService
    {
        List<Favoritebook> GetUserFavoriteBooks(int userId);

        void AddToFavorites(int bookId, int userId);

        void RemoveFromFavorites(int bookId, int userId);
    }
}
