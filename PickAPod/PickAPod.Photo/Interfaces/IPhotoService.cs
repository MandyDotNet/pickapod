public interface IPhotoService
{
    Task<string> GetAPODForDate(string date);
    Task<string> GetAPODs(string startDate, string endDate);
    Task<string> SearchAPOD(string query);
}
