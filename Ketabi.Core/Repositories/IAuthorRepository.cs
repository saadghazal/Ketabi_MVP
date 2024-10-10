using Ketabi.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.Repositories
{
    public interface IAuthorRepository
    {

        List<Author> GetAllAuthors();
        Author GetAuthorById(int authorId);
        List<Author> SearchAuthorByName(string authorName);
        void DeleteAuthor(int authorId);
        void CreateAuthor(Author newAuthor);
        void UpdateAuthor(Author newAuthor);
    }
}
