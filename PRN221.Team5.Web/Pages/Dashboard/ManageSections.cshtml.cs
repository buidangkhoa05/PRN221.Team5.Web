using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Domain.Common;

namespace PRN221.Team5.Web.Pages.Dashboard
{
    [Authorize(Roles = nameof(Role.Administrator))]
    public class ManageSections : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public ManageSections(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public List<ZooSection> Sections { get; set; }
        [BindProperty]
        public ZooSection iSection { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Sections = (await _unitOfWork.ZooSection.Get(new QueryHelper<ZooSection>()
            {
                OrderByFields = new List<string>
                {
                    $"{nameof(ZooSection.UpdatedDate)}:desc"
                }.ToArray(),
            }
                )).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            try
            {
                Account account = (await _unitOfWork.Account.Get()).ToList()[0];

                Guid isSuccess = await _unitOfWork.ZooSection.CreateAsync(new ZooSection
                {
                    Name = iSection.Name,
                    Description = iSection.Description,
                    ZooSectionStatus = iSection.ZooSectionStatus,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }, true);
                Console.WriteLine(isSuccess);

            }
            catch
            {

            }

            return RedirectToPage("/Dashboard/ManageSections");
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            try
            {
                var oldNews = await _unitOfWork.ZooSection.GetById(iSection.Id);
                var isSuccess = await _unitOfWork.ZooSection.UpdateAsync(new ZooSection
                {
                    Id = iSection.Id,
                    Name = iSection.Name,
                    Description = iSection.Description,
                    CreatedDate = oldNews.CreatedDate,
                    ZooSectionStatus = iSection.ZooSectionStatus,
                    UpdatedDate = DateTime.Now,
                }, true);
                Console.WriteLine(isSuccess);

            }
            catch
            {

            }

            return RedirectToPage("/Dashboard/ManageSections");
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            try
            {
                Expression<Func<ZooSection, bool>> filter = x => x.Id == iSection.Id;
                var isSuccess = await _unitOfWork.ZooSection.DeleteAsync(filter);
                Console.WriteLine(isSuccess);
            }
            catch
            {
                return Page();
            }


            return RedirectToPage("/Dashboard/ManageSections");
        }
    }
}