using EFCore.Catalog.AccountCatalog;
using EFCore.Catalog.AccountCatalog.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFCore.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManagement _iAccountManagement;

        public AccountController(IAccountManagement iAccountManagement)
        {
            _iAccountManagement = iAccountManagement;
        }

        [HttpPost]
        [Route("api/account")]
        public async Task<IActionResult> Create([FromBody] AccountCreateRequest request) 
        {
            var result = await _iAccountManagement.Create(request);

            if (result == 0)
                return BadRequest("Cant not create account");  

            return Ok(result); 
        }

    }
}
