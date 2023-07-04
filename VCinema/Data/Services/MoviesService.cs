using VCinema.Data.Base;
using VCinema.Models;

namespace VCinema.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context)
        {
        }
    }
}
