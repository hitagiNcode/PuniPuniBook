using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuniPuniBook.Data.Repository.IRepository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PuniPuniBook.Web.Areas.Customer.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Produces("application/json")]
        [HttpGet("search")]
        [Route("api/books/search")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search()
        {
            try
            {
                var term = HttpContext.Request.Query["term"].ToString().ToUpper();
                
                var bookTitles = _unitOfWork.Product
                    .GetAll(u => u.Title.ToUpper().Contains(term) || u.Author.ToUpper().Contains(term))
                    .Select(u => u.Title).ToList();

                return Ok(bookTitles);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
