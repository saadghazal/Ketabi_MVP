using Ketabi.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.Services
{
    public interface IUserService
    {
        void RegisterUser(UserDTO newUser);
    }
}
