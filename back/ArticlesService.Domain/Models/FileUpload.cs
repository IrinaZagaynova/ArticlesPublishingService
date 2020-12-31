using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Models
{
    public class FileUpload
    {
        public List<IFormFile> Files { get; set; }
    }
}
