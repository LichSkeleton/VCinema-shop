using VCinema.Data.Base;
using VCinema.Data.ViewModels;
using VCinema.Models;

namespace VCinema.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
    }
}
