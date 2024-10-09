using Ketabi.Core.Data;
using Ketabi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ketabi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;
        public CreditCardController (ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }
        [HttpGet]
        [Route("GetAllCredit")]
        public List<Creditcard> GetAllCredit()
        {
            return _creditCardService.GetAllCredit();
        }
        [HttpPost]
        [Route("AddNewCredit")]
        public void AddNewCredit(Creditcard creditcard)
        {
            _creditCardService.AddNewCredit(creditcard);
        }
        [HttpPut]
        [Route("UpdateCredit")]
        public void UpdateCredit(Creditcard creditcard)
        {
            _creditCardService.UpdateCredit(creditcard);
        }
        [HttpDelete]
        [Route("DeleteCredit")]
        public void DeleteCredit(int id)
        {
            _creditCardService.DeleteCredit(id);
        }
        [HttpGet]
        [Route("GetCreditById")]
        public Creditcard GetCreditById(int id)
        {
            return _creditCardService.GetCreditById(id);
        }
        [HttpGet]
        [Route("GetCreditByUserId")]
        public Creditcard GetCreditByUserId(int userId)
        {
            return _creditCardService.GetCreditByUserId(userId);
        }
    }
}
