using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPhoto
    {
        Task<List<PhotoItem>> GetAll();
        Task<bool> NewPhoto(PhotoItem photo);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, PhotoItem photo);
    }
}
