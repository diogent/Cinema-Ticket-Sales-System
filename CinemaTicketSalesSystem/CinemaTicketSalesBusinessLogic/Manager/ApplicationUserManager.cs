using Microsoft.AspNet.Identity;
using ApplicationDbMovies.Models;

namespace CinemaTicketSalesBusinessLogic.Models
{
    public class ApplicationUserManager : UserManager<ApplicationUser, string>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, string> store) 
            : base(store)
        {

        }
    }
}