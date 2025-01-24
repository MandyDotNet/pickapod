using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PhotoController : ControllerBase
{
    private readonly IPhotoService _photoService;
    private readonly ILogger<PhotoController> _logger;

    public PhotoController(IPhotoService photoService, ILogger<PhotoController> logger)
    {
        _photoService = photoService;
        _logger = logger;
    }

    [HttpGet("todaysAPOD")]
    public async Task<IActionResult> GetTodaysAPOD()
    {
        try
        {
            var content = await _photoService.GetAPODForDate(DateTime.UtcNow.ToString("yyyy-MM-dd"));
            return Ok(content);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error fetching today's APOD");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("apod")]
    public async Task<IActionResult> GetAPOD([FromQuery] string date)
    {
        try
        {
            var content = await _photoService.GetAPODForDate(date);
            return Ok(content);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error fetching APOD for date {date}", date);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("apods")]
    public async Task<IActionResult> GetAPODs([FromQuery] string startDate, [FromQuery] string endDate)
    {
        try
        {
            var content = await _photoService.GetAPODs(startDate, endDate);
            return Ok(content);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error fetching APODs for date range {startDate} to {endDate}", startDate, endDate);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchAPOD([FromQuery] string query)
    {
        try
        {
            var content = await _photoService.SearchAPOD(query);
            return Ok(content);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error searching APOD with query {query}", query);
            return StatusCode(500, "Internal server error");
        }
    }
}
