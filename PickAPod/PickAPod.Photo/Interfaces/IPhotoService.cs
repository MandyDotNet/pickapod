using PickAPod.Photo.Services;

public interface IPhotoService
{
    Task<APODResponse> GetAPODForDate(string date);
    Task<List<string>> GetAPODs(string startDate, string endDate);
    Task<List<string>> SearchAPOD(string query);
}