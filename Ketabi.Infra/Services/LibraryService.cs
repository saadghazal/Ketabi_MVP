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
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository) { 
            _libraryRepository = libraryRepository;
        }
        public void CreateLibrary(Library newLibrary)
        {
            _libraryRepository.CreateLibrary(newLibrary);
        }

        public void DeleteLibrary(int libraryId)
        {
            _libraryRepository.DeleteLibrary(libraryId);
        }

        public List<Library> GetAllLibraries()
        {
          return _libraryRepository.GetAllLibraries();
        }

        public Library GetLibraryById(int id)
        {
          return  _libraryRepository.GetLibraryById(id);
        }

        public Library GetLibraryByLocation(string lat, string lng)
        {
            return _libraryRepository.GetLibraryByLocation(lat, lng);
        }

        public Library GetLibraryByName(string name)
        {
            return _libraryRepository.GetLibraryByName(name);
        }

        public void UpdateLibrary(Library updatedLibrary)
        {
            _libraryRepository.UpdateLibrary(updatedLibrary);
        }
    }
}
