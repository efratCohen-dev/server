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
    public class Post:IPost
    {
        private readonly ProjectContext _projectContext;

        public Post(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
        public async Task<List<PostItem>> GetAll()
        {
            List<PostItem> posts = await _projectContext.PostItems.ToListAsync();
            return posts;
        }
        public async Task<bool> NewPost(PostItem post)
        {
            await _projectContext.PostItems.AddAsync(post);
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> Delete(int id)
        {
            var postId = _projectContext.PostItems.FirstOrDefault(p => p.Id == id);
            _projectContext.PostItems.Remove(postId);
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> Update(int id, PostItem post)
        {
            var postId = _projectContext.PostItems.FirstOrDefault(p => p.Id == id);
            if (postId == null)
                return false;
            postId.Content=post.Content;
            postId.Like = post.Like;
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;

        }
    }
}
