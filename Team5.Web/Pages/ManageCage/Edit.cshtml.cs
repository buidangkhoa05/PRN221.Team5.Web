using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team5.Application.Repository;
//using Domain1;

namespace Team5.Web.Pages.ManageCage
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Cage Cage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            Cage = await _unitOfWork.Cage.GetFirstOrDefaultAsync(m => m.Id == id);
            if (Cage == null)
            {
                return NotFound();
            }

            var AnimalSpecies = (await _unitOfWork.AnimalSpecie.Get()).ToList();
            var ZooSection = (await _unitOfWork.ZooSection.Get()).ToList();
            ViewData["AnimalSpecieId"] = new SelectList(AnimalSpecies, "Id", "Name");
            ViewData["ZooSectionId"] = new SelectList(ZooSection, "Id", "Name");

            var optionsList = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Available" },
                new SelectListItem { Value = "1", Text = "Unavailabe" },
            };
            ViewData["status"] = new SelectList(optionsList, "Value", "Text");
            return Page();
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Cage.UpdatedDate = DateTime.Now;
            try
            {
                Cage.NumberCage = 0;
                await _unitOfWork.Cage.UpdateAsync(Cage, true);
            }
            catch (Exception)
            {
            }

            return RedirectToPage("./Index");
        }
        private bool CageExists(Guid id)
        {
            //return (_context.Cages?.Any(e => e.Id == id)).GetValueOrDefault();
            return false;
        }
    }
}
