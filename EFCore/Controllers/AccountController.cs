using EFCore.EF;
using EFCore.Models;
using EFCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("api/account")]
        public async Task<IActionResult> Create([FromBody] Account account) 
        {
            return Ok(await _unitOfWork.accountRepository.Create(account)); 
        }

    }
}
