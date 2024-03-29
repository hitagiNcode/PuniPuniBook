﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PuniPuniBook.Data.Repository.IRepository;
using System;
using System.Linq;

namespace PuniPuniBook.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(ILogger<SearchController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Index(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return RedirectToAction("Index");
            
            searchString = searchString.ToUpper();
            
            var bookTitles = _unitOfWork.Product.GetAll(u =>
                u.Title.ToUpper().Contains(searchString) || u.Author.ToUpper().Contains(searchString)).ToList();
            return View(bookTitles);
        }
    }
}
