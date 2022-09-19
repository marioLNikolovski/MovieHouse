using Microsoft.EntityFrameworkCore;
using MovieHouse.Core.Contracts;
using MovieHouse.Core.Models;
using MovieHouse.Infrastructure.Data.Identity;
using MovieHouse.Infrastructure.Data.Models;
using MovieHouse.Infrastructure.Data.Repositories;

namespace MovieHouse.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IApplicationDbRepository repo;
        private readonly IMovieService movieService;

        public AccountService(IApplicationDbRepository _repo, IMovieService _movieService)
        {
            repo = _repo;
            movieService = _movieService;
        }

        public async Task FavoriteMovieAsync(string userId, string movieId)
        {
            var user = await FindUserByIdAsync(userId);
            var movie = await movieService.FindMovieByIdAsync(movieId);

            var userMovie = new UserMovies()
            {
                ApplicationUserId = userId,
                MovieId = movieId,
                ApplicationUser = user,
                Movie = movie
            };

            await repo.AddAsync(userMovie);
            await repo.SaveChangesAsync();
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


        public async Task<bool> UpdateUser(UserEditViewModel model)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<ApplicationUser>(model.Id);

                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.CountryId = model.Country;
                    user.CityId = model.City;
                   
                  
                    await repo.SaveChangesAsync();
                    result = true;
                }
            return result;
        }
    }
}
