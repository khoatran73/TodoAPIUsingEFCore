using EFCore.EF;
using EFCore.Models;
using EFCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        //private IUnitOfWork _unitOfWork;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            //_unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("api/account")]
        public async Task<IActionResult> Create([FromBody] Account account) 
        {
            return Ok(await _accountRepository.Create(account)); 
        }

    }
}
