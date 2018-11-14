using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ApplicationDbMovies.Models;
using ApplicationDbMovies.Contexts;

namespace CinemaTicketSalesBusinessLogic.Models
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store, IdentityFactoryOptions<ApplicationDbContext> options) : base(store)
        {

        }
    }
}