using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TaskCancellationToken.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetContentAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("--------------------------------------------------------------------");
                _logger.LogInformation("Istek basladi    " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);

                var mytask = new HttpClient().GetAsync("https://jsonplaceholder.typicode.com/todos");

                await Task.Delay(3000,cancellationToken);

                var data = await mytask.Result.Content.ReadAsStringAsync();
                
                _logger.LogInformation("Istek bitti    " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Istek iptal edildi  " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                _logger.LogInformation(ex.Message + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetContent2Async(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("--------------------------------------------------------------------");
                _logger.LogInformation("Istek basladi    " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);

                var mytask = new HttpClient().GetAsync("https://jsonplaceholder.typicode.com/todos");
                

                await Task.Delay(3000);

                cancellationToken.ThrowIfCancellationRequested();

                var data = await mytask.Result.Content.ReadAsStringAsync();

                _logger.LogInformation("Istek bitti    " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Istek iptal edildi  " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                _logger.LogInformation(ex.Message + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                return BadRequest(ex.Message);
            }
        }
    }
}
