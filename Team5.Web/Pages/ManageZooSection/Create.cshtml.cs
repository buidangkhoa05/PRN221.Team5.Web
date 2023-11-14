using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Team5.Application.Repository;
using Team5.Domain.Common;
using Team5.Infrastructure.Repository;
//using Domain1;

namespace Team5.Web.Pages.ManageZooSection
{
    public class CreateModel : PageModel
    {
        //private readonly Domain1.ZooManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

		public CreateModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

        public IActionResult OnGet()
        {
            var optionsList = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Available" },
                new SelectListItem { Value = "1", Text = "Unavailabe" },
            };
            ViewData["status"] = new SelectList(optionsList, "Value", "Text");
            return Page();
        }

        [BindProperty]
        public ZooSection ZooSection { get; set; } = default!;

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
				Account account = (await _unitOfWork.Account.Get()).ToList()[0];

				Guid isSuccess = await _unitOfWork.ZooSection.CreateAsync(new ZooSection
				{
					Name = ZooSection.Name,
					Description = ZooSection.Description,
					ZooSectionStatus = ZooSection.ZooSectionStatus,
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
