using ApplicationCore;
using DomainModels.Entities;
using DomainModels.ViewModels;
using Repository.Abstruction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class AuthenticationRepository : Repository<User>, IAuthenticationRepository
    {
        private DatabaseContext _context
        {
            get
            {
                return _db as DatabaseContext;
            }
        }
        public AuthenticationRepository(DbContext db):base(db)
        {

        }
        public UserViewModel ValidateUser(LoginViewModel model)
        {
            var data = _context.Users
                .Include("Roles")
                .Where(u => u.UserName == model.UserName && u.Password == model.Password)
                .FirstOrDefault();

            if (data != null)
            {
                var user = new UserViewModel()
                {
                    UserId = data.UserId,
                    Name = data.Name,
                    UserName = data.UserName,
                    Address = data.Address,
                    ContactNo = data.ContactNo,
                    Roles = data.Roles.Select(r => r.Name).ToArray()
                };
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
