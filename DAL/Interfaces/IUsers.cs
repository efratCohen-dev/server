using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsers
    {
        Task<List<User>> GetAll();
        Task<bool> NewUser(User user);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, User user);
    }
}
