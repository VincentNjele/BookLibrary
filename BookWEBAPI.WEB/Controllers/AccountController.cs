using BookService.DALL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookWEBAPI.WEB.Controllers
{
    
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
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(Register register)

        {
                
            Register newUser = new Register();

            var user = new IdentityUser { UserName = register.UserName };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                return Ok(result);

            }
            return Ok(result.Errors);
        }


      
        [HttpPost]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> LoginUser(LoginModel login)

        {


            var user = new IdentityUser { UserName = login.UserName, PasswordHash = login.Password };

            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok();
        }

    }
}
