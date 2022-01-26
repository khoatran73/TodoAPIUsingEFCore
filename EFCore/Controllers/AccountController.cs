using EFCore.Catalog.AccountCatalog;
using EFCore.Catalog.AccountCatalog.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManagement _iAccountManagement;

        public AccountController(IAccountManagement iAccountManagement)
        {
            _iAccountManagement = iAccountManagement;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountCreateRequest ACRequest) 
        {
            var result = await _iAccountManagement.Create(ACRequest);

            Debug.WriteLine(result);

            if (result == 0)
                return BadRequest("Cant not create account");  

            return Ok(result); 
        }

    }
}
