using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Team5.Application.Repository;
//using Domain1;

namespace Team5.Web.Pages.ManageCage
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var AnimalSpecies = (await _unitOfWork.AnimalSpecie.Get()).ToList();
            var ZooSection = (await _unitOfWork.ZooSection.Get()).ToList();
            ViewData["AnimalSpecie"] = new SelectList(AnimalSpecies, "Id", "Name");
            ViewData["ZooSection"] = new SelectList(ZooSection, "Id", "Name");

            var optionsList = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Available" },
                new SelectListItem { Value = "1", Text = "Unavailabe" },
            };
            ViewData["status"] = new SelectList(optionsList, "Value", "Text");

            return Page();
        }

        [BindProperty]
        public Cage Cage { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || ZooSection == null)
            //{
            //             var errors = ModelState.Values.SelectMany(v => v.Errors);

            //             return Page();
            //}

            //if (!CheckName(CartoonFilmInformation.CartoonFilmName))
            //{
            //    ModelState.AddModelError("CartoonFilmInformation.CartoonFilmName",
            //        "CartoonFilmName from 15 to 120 characters. Each word must begin with capital letter");
            //    return await OnGetAsync();
            //}
            //if (CartoonFilmInformation.Duration <= 0)
            //{
            //    ModelState.AddModelError(nameof(CartoonFilmInformation.Duration),
            //        "Duration must > 0");
            //    return await OnGetAsync();
            //}
            //if (!(CartoonFilmInformation.ReleaseYear <= 2023 && CartoonFilmInformation.ReleaseYear >= 1900))
            //{
            //    ModelState.AddModelError("CartoonFilmInformation.ReleaseYear",
            //        "1900 <= ReleaseYear <=2023");
            //    return await OnGetAsync();
            //}

            try
            {
                Guid isSuccess = await _unitOfWork.Cage.CreateAsync(new Cage
                {
                    NumberCage = Cage.NumberCage,
                    Capacity = Cage.Capacity,
                    ZooSectionId = Cage.ZooSectionId,
                    AnimalSpecieId = Cage.AnimalSpecieId,
                    Status = Cage.Status,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }, true);
            }
            catch
            {

            }
            return RedirectToPage("./Index");
        }
    }
}
