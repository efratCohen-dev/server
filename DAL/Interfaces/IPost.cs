using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPost
    {
        Task<List<PostItem>> GetAll();
        Task<bool> NewPost(PostItem post);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, PostItem post);
    }
}
