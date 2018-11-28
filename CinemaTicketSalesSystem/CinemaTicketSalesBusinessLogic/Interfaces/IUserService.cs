using CinemaTicketSalesBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSalesBusinessLogic.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Gets the list of the roles
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleModel> GetRoles();

        /// <summary>
        /// Gets the info about selected user
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <returns></returns>
        UserModel GetUserInfo(string id);
    }
}
