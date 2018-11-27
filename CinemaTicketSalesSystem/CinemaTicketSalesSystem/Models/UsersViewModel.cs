using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketSalesSystem.Models
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }   
        
        public IEnumerable<RoleViewModel> Roles { get; set; }
        public string SelectedRole { get; set; }
    }
}