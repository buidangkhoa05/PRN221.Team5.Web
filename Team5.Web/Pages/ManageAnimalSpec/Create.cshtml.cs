using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Team5.Application.Repository;
//using Domain1;

namespace Team5.Web.Pages.ManageAnimalSpec
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
            return Page();
        }

        [BindProperty]
        public AnimalSpecie AnimalSpecie { get; set; } = default!;

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
                Guid isSuccess = await _unitOfWork.AnimalSpecie.CreateAsync(new AnimalSpecie
                {
                    Name = AnimalSpecie.Name,
                    Description = AnimalSpecie.Description,
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
