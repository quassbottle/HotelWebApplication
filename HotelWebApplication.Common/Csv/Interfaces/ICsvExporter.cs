namespace HotelWebApplication.Common.Csv.Interfaces;

public interface ICsvExporter<T>
{
    Task<ICollection<string>> SaveAsync(ICollection<T> items, string delimiter = ";");
}