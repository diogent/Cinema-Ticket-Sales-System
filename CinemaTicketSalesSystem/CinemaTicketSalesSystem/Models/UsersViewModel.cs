using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaTicketSalesSystem.Models
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }   
        
        [NotMapped]
        public IEnumerable<RoleViewModel> Roles { get; set; }
        [NotMapped]
        public string SelectedRole { get; set; }
    }
}