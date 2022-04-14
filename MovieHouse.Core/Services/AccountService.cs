using Microsoft.EntityFrameworkCore;
using MovieHouse.Core.Contracts;
using MovieHouse.Infrastructure.Data.Common;
using MovieHouse.Infrastructure.Data.Identity;
using MovieHouse.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHouse.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IApplicationDbRepository repo;

        public AccountService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public  async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            var user = await repo.All<ApplicationUser>()
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentNullException("No user found.");
            }
            else
            {
                return user;
            }

        }

        public async Task<ApplicationUser> FindUserByIdAsync(string userId)
        {
            var user = await repo.All<ApplicationUser>()
                .Include(p=> p.Country)
                .Include(p=> p.City)
                .Where(p => p.Id == userId)
                .FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentNullException("No user found.");
            }
            else
            {
                return user;
            }

           

        }
    }
}
