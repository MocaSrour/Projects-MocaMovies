using MocaMovies.Data.Base;
using MocaMovies.Models;

namespace MocaMovies.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {

        }
    }
}
