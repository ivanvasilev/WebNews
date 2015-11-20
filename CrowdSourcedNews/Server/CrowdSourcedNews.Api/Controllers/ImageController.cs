using System.Web.Http;
using CrowdSourcedNews.Api.Providers;
using Google.Apis.Drive.v2;
using CrowdSourcedNews.Data.Services.Contracts;
using System.Threading.Tasks;
using CrowdSourcedNews.Models;
using CrowdSourcedNews.Api.Models;
using CrowdSourcedNews.Api.Models.Image;

namespace CrowdSourcedNews.Api.Controllers
{
    public class ImagesController : ApiController
    {
        private readonly IImagesService images;

        public ImagesController(IImagesService images)
        {
            this.images = images;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IHttpActionResult> Add(ImageRequestModel model)
        {
            string imageUrl = await images.UploadAsync(model.ByteArrayContent, model.FileExtension);
            this.images.Add(
                new Image
                {
                    Url = imageUrl
                });

            return this.Ok(imageUrl);
        }
    }
}
