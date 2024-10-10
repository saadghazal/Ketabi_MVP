using Ketabi.Core.Data;
using Ketabi.Core.Repositories;
using Ketabi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Infra.Services
{
    public class FavoriteBookService : IFavoriteBookService
    {
        private readonly IFavoriteBookRepository _favoriteBookRepository;

        public FavoriteBookService(IFavoriteBookRepository favoriteBookRepository)
        {
            _favoriteBookRepository = favoriteBookRepository;
        }

        public void AddToFavorites(int bookId, int userId)
        {
            _favoriteBookRepository.AddToFavorites(bookId, userId);
        }

        public Task<List<Favoritebook>> GetUserFavoriteBooks(int userId)
        {
            return _favoriteBookRepository.GetUserFavoriteBooks(userId);
        }

        public void RemoveFromFavorites(int bookId, int userId)
        {
            _favoriteBookRepository.RemoveFromFavorites(bookId, userId);
        }
    }
}
