using DAL.Interfaces;
using Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Users:IUsers
    {
        private readonly ProjectContext _projectContext;

        public Users(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
        public async Task<List<User>> GetAll()
        {
            List<User> users = await _projectContext.Users.ToListAsync();
            return users;
        }
        public async Task<bool> NewUser(User user)
        {
            await _projectContext.Users.AddAsync(user);
            var isOk=_projectContext.SaveChanges()>0;
            return isOk;
        }
        public async Task<bool> Delete(int id)
        {
            var userId=_projectContext.Users.FirstOrDefault(u => u.Id == id);
            _projectContext.Users.Remove(userId);
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> Update(int id, User user)
        {
            var userId=_projectContext.Users.FirstOrDefault(u=>u.Id == id);
            if (userId == null)
                return false;
            userId.phone=user.phone;
            userId.Adress=user.Adress;
            userId.Name=user.Name;
            userId.Email=user.Email;
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;

        }
    }
}
