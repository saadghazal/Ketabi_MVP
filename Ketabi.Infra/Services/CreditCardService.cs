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
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository _creditCardRepository;
        public CreditCardService (ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }
        public List<Creditcard> GetAllCredit()
        {
            return _creditCardRepository.GetAllCredit();
        }
        public void AddNewCredit(Creditcard creditcard)
        {
            _creditCardRepository.AddNewCredit(creditcard);
        }
        public void UpdateCredit(Creditcard creditcard)
        {
            _creditCardRepository.UpdateCredit(creditcard);
        }
        public void DeleteCredit(int id)
        {
            _creditCardRepository.DeleteCredit(id);
        }
        public Creditcard GetCreditById(int id)
        {
            return _creditCardRepository.GetCreditById(id);
        }
        public Creditcard GetCreditByUserId(int userId)
        {
            return _creditCardRepository.GetCreditByUserId(userId);
        }
    }
}
