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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void CreateAuthor(Author newAuthor)
        {
            _authorRepository.CreateAuthor(newAuthor);
        }

        public void DeleteAuthor(int authorId)
        {
            _authorRepository.DeleteAuthor(authorId);
        }

        public List<Author> GetAllAuthors()
        {
          return _authorRepository.GetAllAuthors();
        }

        public Author GetAuthorById(int authorId)
        {
            return _authorRepository.GetAuthorById(authorId);
        }

        public List<Author> SearchAuthorByName(string authorName)
        {
            return _authorRepository.SearchAuthorByName(authorName);
        }

        public void UpdateAuthor(Author newAuthor)
        {
            _authorRepository.UpdateAuthor(newAuthor);
        }
    }
}
