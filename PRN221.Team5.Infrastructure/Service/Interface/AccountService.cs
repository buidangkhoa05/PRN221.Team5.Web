using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PRN221.Team5.Application.Service.Interface
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Account?> Login(string username, string password)
        {
            try
            {
                var queryHelper = new QueryHelper<Account>()
                {
                    Filter = x => x.Username == username && x.Password == password,
                };

                var user = (await _unitOfWork.Account.GetFirstOrDefault(queryHelper));

                return user;               
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PagedList<Account>> GetAll(PagingParameters pagingParam)
        {
            try
            {
                var queryHelper = new QueryHelper<Account>()
                {
                    PagingParams = pagingParam
                };

                var  accounts = await _unitOfWork.Account.GetWithPagination(queryHelper);

                return accounts;
            }
            catch (Exception)
            {
                return new PagedList<Account>();
            }
        }
    }
}
