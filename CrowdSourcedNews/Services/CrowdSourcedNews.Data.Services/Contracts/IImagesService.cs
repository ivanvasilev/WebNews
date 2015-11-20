using CrowdSourcedNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcedNews.Data.Services.Contracts
{
    public interface IImagesService
    {
        IQueryable<Image> All();

        int SaveChanges();

        void Add(Image image);

        void Update(Image image);

        Task<string> UploadAsync(byte[] content, string extension);
    }
}
