using System.Collections.Generic;

namespace CinemaTicketSalesBusinessLogic.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        
        public IEnumerable<RoleModel> Roles { get; set; }
    }
}
