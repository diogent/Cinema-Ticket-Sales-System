using ApplicationDbMovies.Contexts;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesBusinessLogic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using AutoMapper;
using ApplicationDbMovies.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CinemaTicketSalesBusinessLogic.CRUD
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IEnumerable<RoleModel> GetRoles()
        {
            var roles = _db.Roles.ToList();
            var rolesList = _mapper.Map<IEnumerable<IdentityRole>, IEnumerable<RoleModel>>(roles);
            return rolesList;
        }

        public UserModel GetUserInfo(string id)
        {
            var users =  _db.Users.Find(id);
            var usersList = _mapper.Map<ApplicationUser, UserModel>(users);
            return usersList;
        }
    }
}
