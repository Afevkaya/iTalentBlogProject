using iTalentBlogProject.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iTalentBlogProject.API.Controllers
{
    /// <summary>
    /// StatusCode'a göre geri dönüş tipi üreten bir Controller oluşturdum.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomeBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomeResponseDto<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null) {StatusCode = response.StatusCode};
            }

            return new ObjectResult(response) {StatusCode = response.StatusCode};
        }
    }
}
