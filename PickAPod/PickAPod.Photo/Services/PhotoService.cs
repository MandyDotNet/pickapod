namespace PickAPod.Photo.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _nasaApiKey;
        private readonly ILogger<PhotoService> _logger;

        public PhotoService(HttpClient httpClient, IConfiguration configuration, ILogger<PhotoService> logger)
        {
            _httpClient = httpClient;
            _nasaApiKey = configuration["NasaApiKey"];
            _logger = logger;
        }

        public async Task<string> GetAPODForDate(string date)
        {
            var url = $"https://api.nasa.gov/planetary/apod?api_key={_nasaApiKey}&date={date}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAPODs(string startDate, string endDate)
        {
            var url = $"https://api.nasa.gov/planetary/apod?api_key={_nasaApiKey}&start_date={startDate}&end_date={endDate}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> SearchAPOD(string query)
        {
            var url = $"https://api.nasa.gov/planetary/apod?api_key={_nasaApiKey}&q={query}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
