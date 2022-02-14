using Cinema.LoggerService;
using Cinema.Models;
using Cinema.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace web_api_assignment.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IUnitOfWork _unitOfWord;
        public CategoryController(ILoggerManager logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWord = unitOfWork;
        }

        [HttpGet("/catgory")]
        [Authorize(Roles = "Content Creator, Manager")]
        public IActionResult GetAllCategory()
        {
            try
            {
                IEnumerable<Category> categories = _unitOfWord.Category.Get();
                return Ok(categories);
            }catch(ArgumentNullException exception)
            {
                _logger.LogError($"An Exception {exception.GetType().Name} occurred: \n Message: {exception.Message} \n Stack Trace: {exception.StackTrace} ");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
