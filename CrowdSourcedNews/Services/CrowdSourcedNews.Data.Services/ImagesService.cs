using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dropbox.Api;
using Dropbox.Api.Files;

using CrowdSourcedNews.Data.Services.Contracts;
using CrowdSourcedNews.Models;
using System.IO;

namespace CrowdSourcedNews.Data.Services
{
    public class ImagesService : IImagesService
    {
        private const string Token = "_nwK7Bw1b0AAAAAAAAAABex0fnlmhlR0ZUO3Xi4ttoZyxwX7S9lTgFe2iMC4vx2M";

        private readonly IRepository<Image> images;

        public ImagesService(IRepository<Image> images)
        {
            this.images = images;
        }

        public IQueryable<Image> All()
        {
            var result = this.images.All();

            return result;
        }

        public int SaveChanges()
        {
            return this.images.SaveChanges();
        }

        public void Add(Image image)
        {
            this.images.Add(image);
            this.images.SaveChanges();
        }

        public void Update(Image image)
        {
            this.images.Update(image);
            this.images.SaveChanges();
        }

        public async Task<string> UploadAsync(byte[] content, string extension)
        {
            string guid = Guid.NewGuid().ToString();
            string imageUrl = string.Format("/{0}.{1}", guid, extension);

            var dbx = new DropboxClient(Token);

            using (var mem = new MemoryStream(content))
            {
                var image = await dbx.Files.UploadAsync(new CommitInfo(imageUrl), body: mem);
                var shareLink = await dbx.Sharing.CreateSharedLinkAsync(image.PathLower);
                var rawLink = ProcessImageLink(shareLink.Url);

                return rawLink;
            }
        }

        private string ProcessImageLink(string link)
        {
            string rawExtension = "raw=1"; // Magic, don't touch

            string cutLink = link.Remove(link.Length - 4);
            string processedLink = cutLink + rawExtension;

            return processedLink;
        }
    }
}
