using MocaMovies.Data.Base;
using MocaMovies.Models;

namespace MocaMovies.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }


    }
}
