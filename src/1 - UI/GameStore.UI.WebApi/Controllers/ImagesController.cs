using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace GameStore.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        [HttpPost("converttobase64")]
        public dynamic ConvertToBase64()
        {
            string base64file = String.Empty;
            var file = Request.Form.Files[0];
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    base64file = Convert.ToBase64String(fileBytes);
                }
            }

            return new { imageUrl = $"data:{file.ContentType};base64,{base64file}" };
        }
    }
}