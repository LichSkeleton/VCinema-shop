using Microsoft.EntityFrameworkCore;
using VCinema.Data.Base;
using VCinema.Models;

namespace VCinema.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }
    }
}
