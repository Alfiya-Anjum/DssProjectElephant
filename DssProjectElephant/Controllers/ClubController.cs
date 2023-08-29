//using DssProjectElephant.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using System.Collections.Generic;
//using System.Linq;
//using static DssProjectElephant.ViewModels.EditClubViewModels;

//namespace DssProjectElephant.Controllers
//{
//    public class ClubController : Controller
//    {
//        private readonly List<Club> _clubs = new List<Club>
//        {
//            new Club { Id = 1, Name = "Club 1", Description = "Description for Club 1", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRixaQ96UZlaZntOPkDgF4xiNEnY8LIk9zYNw&usqp=CAU" },
//            new Club { Id = 2, Name = "Club 2", Description = "Description for Club 2", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRixaQ96UZlaZntOPkDgF4xiNEnY8LIk9zYNw&usqp=CAU" },
//            new Club { Id = 3, Name = "Club 3", Description = "Description for Club 3", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRixaQ96UZlaZntOPkDgF4xiNEnY8LIk9zYNw&usqp=CAU" }
//        };

//        public IActionResult Index()
//        {
//            return View(_clubs);
//        }

//        public IActionResult Details(int id)
//        {
//            Club club = _clubs.FirstOrDefault(c => c.Id == id);

//            if (club == null)
//            {
//                return NotFound();
//            }

//            return View(club);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(Club club)
//        {
//            if (!ModelState.IsValid)
//            {
//                // TODO: Save the club to your data store (e.g., database)

//                // Redirect to a different action after successful creation
//                return RedirectToAction("Index");
//            }

//            // If ModelState is not valid, return the view with validation errors
//            return View(club);
//        }

//        [HttpGet]
//        public IActionResult Edit(int id)
//        {
//            Club club = _clubs.FirstOrDefault(c => c.Id == id);

//            if (club == null)
//            {
//                return NotFound();
//            }

//            EditClubViewModel editViewModel = new EditClubViewModel
//            {
//                Id = club.Id,
//                Name = club.Name,
//                Description = club.Description,
//                Image = club.Image
//            };

//            return View(editViewModel);
//        }
//        [HttpPost]
//        public IActionResult Edit(EditClubViewModel editViewModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(editViewModel);
//            }

//            // Update the club in your data store (e.g., database)
//            Club existingClub = _clubs.FirstOrDefault(c => c.Id == editViewModel.Id);
//            if (existingClub != null)
//            {
//                existingClub.Name = editViewModel.Name;
//                existingClub.Description = editViewModel.Description;
//                existingClub.Image = editViewModel.Image;
//            }

//            // Redirect to the Index action after successful edit
//            return RedirectToAction("Index");
//        }

//    }
//}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DssProjectElephant.Interfaces;
using DssProjectElephant.Models;
using DssProjectElephant.ViewModels;
using static DssProjectElephant.ViewModels.EditClubViewModels;

namespace DssProjectElephant.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public async Task<IActionResult> Index()
        {
            var clubs = await _clubRepository.GetAll();
            return View(clubs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var club = await _clubRepository.GetByIdAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Club club)
        {
            if (!ModelState.IsValid)
            {
                return View(club);
            }

            _clubRepository.Add(club);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var club = await _clubRepository.GetByIdAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            var editViewModel = new EditClubViewModel
            {
                Id = club.Id,
                Name = club.Name,
                Description = club.Description,
                Image = club.Image
            };

            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditClubViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                return View(editViewModel);
            }

            var existingClub = _clubRepository.GetByIdAsync(editViewModel.Id).Result;

            if (existingClub != null)
            {
                existingClub.Name = editViewModel.Name;
                existingClub.Description = editViewModel.Description;
                existingClub.Image = editViewModel.Image;

                _clubRepository.Update(existingClub);
            }

            return RedirectToAction("Index");
        }
    }
}



