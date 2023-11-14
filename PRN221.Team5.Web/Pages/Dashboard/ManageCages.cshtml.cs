using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Domain.Common;
using static System.Collections.Specialized.BitVector32;

namespace PRN221.Team5.Web.Pages.Dashboard
{
    public class ManageCages : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICageService _cageService;

        public ManageCages(IUnitOfWork unitOfWork, ICageService cageService)
        {
            _unitOfWork = unitOfWork;
            _cageService = cageService;
        }

        [BindProperty]
        public List<Cage> Cages { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var Sections = (await _unitOfWork.ZooSection.Get(new QueryHelper<ZooSection>())).ToList();
            var AnimalSpecie = (await _unitOfWork.AnimalSpecie.Get(new QueryHelper<AnimalSpecie>())).ToList();
            Cages = (await _cageService.GetAll());
            ViewData["Sections"] = new SelectList(Sections, "Id", "Name");
            ViewData["AnimalSpecie"] = new SelectList(AnimalSpecie, "Id", "Name");
            
            return Page();
        }
        
    }
}