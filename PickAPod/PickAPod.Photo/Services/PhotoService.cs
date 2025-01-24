using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;

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
            _nasaApiKey = configuration["NASA:ApiKey"];
            _logger = logger;
        }

        public async Task<string> GetAPODForDate(string date)
        {
            var url = $"https://api.nasa.gov/planetary/apod?api_key={_nasaApiKey}&date={date}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(content);
        }

        public async Task<List<string>> GetAPODs(string startDate, string endDate)
        {
            var url = $"https://api.nasa.gov/planetary/apod?api_key={_nasaApiKey}&start_date={startDate}&end_date={endDate}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<string>>(content);
        }

        public async Task<List<string>> SearchAPOD(string query)
        {
            var url = $"https://api.nasa.gov/planetary/apod?api_key={_nasaApiKey}&q={query}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<string>>(content);
        }
    }
}
