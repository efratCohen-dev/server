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
    public class Photo:IPhoto
    {
        private readonly ProjectContext _projectContext;

        public Photo(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
        public async Task<List<PhotoItem>> GetAll()
        {
            List<PhotoItem> photo = await _projectContext.PhotoItems.ToListAsync();
            return photo;
        }
        public async Task<bool> NewPhoto(PhotoItem photo)
        {
            await _projectContext.PhotoItems.AddAsync(photo);
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> Delete(int id)
        {
            var photoId = _projectContext.PhotoItems.FirstOrDefault(p => p.Id == id);
            _projectContext.PhotoItems.Remove(photoId);
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> Update(int id, PhotoItem photo)
        {
            var photoId = _projectContext.PhotoItems.FirstOrDefault(p => p.Id == id);
            if (photoId == null)
                return false;
            photoId.ImgUrl = photo.ImgUrl;
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;

        }
    }
}
