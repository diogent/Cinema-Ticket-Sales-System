using CinemaTicketSalesSystem.Constants;
using CinemaTicketSalesSystem.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace CinemaTicketSalesSystem.Helpers
{
    public static class NavigationLinkHelper
    {
        public static IEnumerable<LinksViewModel> GetNavigationLinks(string role)
        {
            switch (role)
            {
                case Roles.Admin:
                    {
                        IEnumerable<LinksViewModel> links = new List<LinksViewModel>
                        {
                            new LinksViewModel { Label = "Set Roles", Method = "SetRoles", Controller = "Admin" },
                            new LinksViewModel { Label = "Create Movie", Method = "CreateNewMovie", Controller = "EditMovie" },                            
                            new LinksViewModel { Label = "Logout", Method = "Logout", Controller = "Account" }
                        };
                        return links;
                    }
                case Roles.Moderator:
                    {
                        IEnumerable<LinksViewModel> links = new List<LinksViewModel>
                        {
                            new LinksViewModel { Label = "Create Movie", Method = "CreateNewMovie", Controller = "EditMovie" },                            
                            new LinksViewModel { Label = "Logout", Method = "Logout", Controller = "Account" }
                        };
                        return links;
                    }
                case Roles.User:
                    {
                        IEnumerable<LinksViewModel> links = new List<LinksViewModel>
                        {                            
                            new LinksViewModel { Label = "Logout", Method = "Logout", Controller = "Account" }
                        };
                        return links;
                    }
                default:
                    {
                        IEnumerable<LinksViewModel> links = new List<LinksViewModel>
                        {
                            new LinksViewModel { Label = "Login", Method = "Login", Controller = "Account" },
                            new LinksViewModel { Label = "Sign Up", Method = "Register", Controller = "Account" }
                        };
                        return links;
                    }
            }                
        }
    }
}