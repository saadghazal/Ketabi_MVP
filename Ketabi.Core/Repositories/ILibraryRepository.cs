using Ketabi.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.Repositories
{
    public interface ILibraryRepository
    {
        List<Library> GetAllLibraries();
        Library GetLibraryById(int id);

        void CreateLibrary(Library newLibrary);

        void UpdateLibrary(Library updatedLibrary);

        void DeleteLibrary(int libraryId);

        Library GetLibraryByName(string name);
        Library GetLibraryByLocation(string lat, string lng);


    }
}
