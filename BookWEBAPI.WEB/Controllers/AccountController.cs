using BookService.DALL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookWEBAPI.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
           _userManager = userManager;
            _signInManager = signInManager;

        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(Register register)

        {
                
            Register newUser = new Register();

            var user = new IdentityUser { UserName = register.UserName };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {

                return Ok();

            }
            return Ok("Not successful");
        }
    }
}
