using ApplicationDbMovies.Models;
using Microsoft.AspNet.Identity;

namespace CinemaTicketSalesBusinessLogic.Manager
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, string>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore)
            : base(roleStore)
        {
        }
    }
}
