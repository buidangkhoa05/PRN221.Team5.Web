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

namespace Team5.Web.Pages.ManageZooNews
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public ZooNews ZooNews { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var item = await _unitOfWork.ZooNews.GetFirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            ZooNews = item;
            var AnimalSpecies = (await _unitOfWork.AnimalSpecie.Get()).ToList();
            var ZooSection = (await _unitOfWork.ZooSection.Get()).ToList();
            ViewData["AnimalSpecieId"] = new SelectList(AnimalSpecies, "Id", "Name");
            ViewData["ZooSectionId"] = new SelectList(ZooSection, "Id", "Name");
            return Page();
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ZooNews.UpdatedDate = DateTime.Now;
            await _unitOfWork.ZooNews.UpdateAsync(ZooNews, true);

            return RedirectToPage("./Index");
        }
        private bool ZooNewsExists(Guid id)
        {
            //return (_context.ZooNewss?.Any(e => e.Id == id)).GetValueOrDefault();
            return false;
        }
    }
}
