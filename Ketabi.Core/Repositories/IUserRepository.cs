using Ketabi.Core.Data;
using Ketabi.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.Repositories
{
    public interface IUserRepository
    {
        public void RegisterUser(UserDTO newUser);
    }
}
