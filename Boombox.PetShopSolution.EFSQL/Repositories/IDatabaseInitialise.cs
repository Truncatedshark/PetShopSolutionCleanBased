using Microsoft.EntityFrameworkCore;

namespace Boombox.PetShopSolution.EFSQL.Repositories
{
    public interface IDatabaseInitialise
    {
        void seedDatabase(DbContext ctx);
    }
}