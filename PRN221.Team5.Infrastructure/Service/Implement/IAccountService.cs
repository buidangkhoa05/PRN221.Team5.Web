using Microsoft.AspNetCore.Mvc;
using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221.Team5.Application.Service.Implement
{
    public interface IAccountService
    {
        public Task<Account?> Login(string username, string password);
        Task<PagedList<Account>> GetAll(PagingParameters pagingParam);
        Task<bool> Create(Account account);
        Task<Account> GetById(Guid id);
        Task<Account> Get(Expression<Func<Account, bool>> filter);
        Task<bool> Update(Account account);
        Task<bool> Delete(Guid id);
    }
}
