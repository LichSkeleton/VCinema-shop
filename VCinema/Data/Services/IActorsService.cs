using VCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VCinema.Data.Base;

namespace VCinema.Data.Services
{
    public interface IActorsService:IEntityBaseRepository<Actor>
    {
    }
}
