using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Ressarcimento_SAT___SAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            var fileType = Path.GetExtension(file.FileName);
            var filePath = @"\temp\"; 

            if (fileType.ToLower() == ".txt")
            {

                var docName = Path.GetFileName(file.FileName);
                if (file != null && file.Length > 0)
                {

                    string fullPath = Path.Combine(filePath, "Files");
                    string DocUrl = Path.Combine(filePath, "Files", Guid.NewGuid().ToString() + fileType);
                    
                    if (!Directory.Exists(fullPath))
                    {
                        Directory.CreateDirectory(fullPath);
                    }

                    using (var stream = new FileStream(DocUrl, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            return Ok();
        }

    }
}
