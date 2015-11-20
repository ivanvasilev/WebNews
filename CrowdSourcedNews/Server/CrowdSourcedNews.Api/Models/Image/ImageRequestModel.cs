using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrowdSourcedNews.Api.Models.Image
{
    public class ImageRequestModel
    {
        [Required]
        public string OriginalFileName { get; set; }

        [Required]
        public string FileExtension { get; set; }

        [Required]
        public string Base64Content { get; set; }

        public byte[] ByteArrayContent
        {
            get
            {
                return Convert.FromBase64String(this.Base64Content);
            }
        }
    }
}