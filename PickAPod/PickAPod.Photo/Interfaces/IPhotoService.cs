public interface IPhotoService
{
    Task<string> GetAPODForDate(string date);
    Task<List<string>> GetAPODs(string startDate, string endDate);
    Task<List<string>> SearchAPOD(string query);
}