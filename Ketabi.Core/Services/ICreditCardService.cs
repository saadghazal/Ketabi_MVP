using Ketabi.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.Services
{
    public interface ICreditCardService
    {
        List<Creditcard> GetAllCredit();
        void AddNewCredit(Creditcard creditcard);
        void UpdateCredit(Creditcard creditcard);
        void DeleteCredit(int id);
        Creditcard GetCreditById(int id);
        Creditcard GetCreditByUserId(int userId);
    }
}
