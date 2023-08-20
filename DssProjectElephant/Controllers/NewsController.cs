using DssProjectElephant.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DssProjectElephant.Data;
using DssProjectElephant.ViewModels;

namespace DssProjectElephant.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContent _context;

        public NewsController(ApplicationDbContent context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var newsList = new List<TheNews>
    {
        new News { Id = 1, Title = "News 1", Content = "Content for News 1", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTymg6E5EmfMYyrWQ5SQLI5YnxUPWRA0JkeCA&usqp=CAU" },
        new News { Id = 2, Title = "News 2", Content = "Content for News 2", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTymg6E5EmfMYyrWQ5SQLI5YnxUPWRA0JkeCA&usqp=CAU" },
        new News { Id = 3, Title = "News 3", Content = "Content for News 3", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTymg6E5EmfMYyrWQ5SQLI5YnxUPWRA0JkeCA&usqp=CAU" }
    };

            return View(newsList);
        }


        public IActionResult Details(int id)
        {
            TheNews newsItem = _context.TheNews.FirstOrDefault(n => n.Id == id);

            return View(newsItem);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TheNews news)
        {
            if (!ModelState.IsValid)
            {
                // TODO: Save the club to your data store (e.g., database)

                // Redirect to a different action after successful creation
                return RedirectToAction("Index");
            }

            // If ModelState is not valid, return the view with validation errors
            return View(news);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TheNews newsItem = _context.TheNews.FirstOrDefault(n => n.Id == id);

            if (newsItem == null)
            {
                return NotFound();
            }

            EditNewsViewModel editViewModel = new EditNewsViewModel
            {
                Id = newsItem.Id,
                Name = newsItem.Name,
                Description = newsItem.Description,
                Image = newsItem.Image
                // Add other properties as needed
            };

            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditNewsViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }

            // Update the news item in your data store (e.g., database)
            TheNews existingNewsItem = _context.TheNews.FirstOrDefault(n => n.Id == editViewModel.Id);
            if (existingNewsItem != null)
            {
                existingNewsItem.Name = editViewModel.Name;
                existingNewsItem.Description = editViewModel.Description;
                existingNewsItem.Image = editViewModel.Image;
                // Update other properties as needed
                _context.SaveChanges(); // Save changes to the database
            }

            // Redirect to the Index action after successful edit
            return RedirectToAction("Index");
        }



    }
}






