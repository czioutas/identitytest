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

            var userA = _fixture.Create<ApplicationUserEntity>();
            userA.DetailsEntityId = 0;
            userA.Email = "withdetails@gmail.com";
            await _userManager.CreateAsync(userA, "Whatever!1");

            var userB = _fixture.Create<ApplicationUserEntity>();
            userB.DetailsEntityId = 0;
            userB.Details = null;
            userB.Email = "nodetails@gmail.com";
            await _userManager.CreateAsync(userB, "Whatever!1");

            var _userA1 = await _userManager.FindByEmailAsync(userA.Email);
            var _userA2 = await _userManager.FindByEmailIncludeAsync(userA.Email);

            var _userB1 = await _userManager.FindByEmailAsync(userB.Email);
            var _userB2 = await _userManager.FindByEmailIncludeAsync(userB.Email);            

            return Ok("1");
        }
    }
}
