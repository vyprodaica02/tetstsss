using LoginWithGoogAutheries.Action;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginWithGoogAutheries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly LoginautheriesService _login;

        public ValuesController()
        {
            _login = new LoginautheriesService();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] string idToken)
        {
            if (string.IsNullOrEmpty(idToken))
            {
                // Kiểm tra idToken có null hay không
                return BadRequest(new { message = "ID Token is required." });
            }

            try
            {
                // Gọi phương thức Login từ _login và chờ kết quả
                var result = await _login.login(idToken);

                // Trả về kết quả thành công
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                // Trả về lỗi nếu có exception
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
