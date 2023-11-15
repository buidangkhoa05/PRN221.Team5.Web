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

namespace Team5.Web.Pages.ManageZooSection
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public ZooSection ZooSection { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var zoosection = await _unitOfWork.ZooSection.GetFirstOrDefaultAsync(m => m.Id == id);
            if (zoosection == null)
            {
                return NotFound();
            }
            ZooSection = zoosection;
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
            try
            {
                ZooSection.UpdatedDate = DateTime.Now;

                Cage? cage = await _unitOfWork.Cage.GetFirstOrDefaultAsync(x => x.ZooSectionId == ZooSection.Id);
                if (cage != null && ZooSection.ZooSectionStatus == ZooSectionStatus.Unavailable)
                {
                    ModelState.AddModelError("ZooSection.ZooSectionStatus",
                        "This section is already used by cage.");
                    return await OnGetAsync(ZooSection.Id);
                }

                await _unitOfWork.ZooSection.UpdateAsync(ZooSection, true);
            }
            catch { }

            return RedirectToPage("./Index");
        }
        private bool ZooSectionExists(Guid id)
        {
          //return (_context.ZooSections?.Any(e => e.Id == id)).GetValueOrDefault();
          return false;
        }
    }
}



