using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoFixture;

namespace identityissue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly UserManager<ApplicationUserEntity> _userManager;

        public TestController(UserManager<ApplicationUserEntity> userManager, ILogger<TestController> logger)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            Fixture _fixture = new Fixture();

            var user = _fixture.Create<ApplicationUserEntity>();
            user.DetailsEntityId = 0;
            user.Email = "whatever@gmail.com";        

            var identityResult = await _userManager.CreateAsync(user, "Whatever!1");

            var a = await _userManager.FindByEmailAsync(user.Email);

            var b = await _userManager.FindByIdAsync("1");

            var c = await _userManager.FindByEmailIncludeAsync(user.Email);

            return Ok("1");
        }
    }
}
