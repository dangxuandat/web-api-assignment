using AutoMapper;
using Cinema.LoggerService;
using Cinema.Models.DataTransferObject;
using Cinema.Repository.Interfaces;
using Entity;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using web_api_assignment.Helpers;

namespace web_api_assignment.Controllers
{
    [Route("/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public LoginController(IHttpClientFactory httpClientFactory, IUnitOfWork unitOfWork, IMapper mapper, ILoggerManager logger)
        {
           _httpClientFactory = httpClientFactory;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginAccount)
        {
            if (ModelState.IsValid)
            {
                //retreive access token 
                var serverClient = _httpClientFactory.CreateClient();

                var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:44345/");

                var tokenResponse = await serverClient.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    GrantType = "password",
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = "ClientCinema",
                    ClientSecret = "secret",
                    Scope = "Cinema",
                    UserName = loginAccount.Email,
                    Password = loginAccount.Password,
                });
                
                return Ok(tokenResponse.AccessToken);
            }
            IEnumerable<string> modelErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
            return BadRequest(modelErrors);
        }

        [HttpPost("/CreateAccount")]
        public IActionResult CreateAccount(CreateAccountDTO newAccount)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    newAccount.Password = Helper.HashPassword(newAccount.Password);
                    Account account = _mapper.Map<Account>(newAccount);
                    Role role = _unitOfWork.Roles.GetRoleByName("Customer");
                    account.Role = role;
                    _unitOfWork.Accounts.Insert(account);
                    _unitOfWork.Save();
                    return Ok(account);
                }catch(DbUpdateException exception)
                {
                    _logger.LogError($"An Exception {exception.GetType().Name} occurred: \n Message: {exception.Message} \n Stack Trace: {exception.StackTrace} ");
                    return StatusCode(StatusCodes.Status500InternalServerError,exception.Message);
                }
            }
            IEnumerable<string> modelErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
            return BadRequest(modelErrors);
        }
    }
}
