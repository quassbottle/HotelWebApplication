using System.Reflection;
using System.Text;
using HotelWebApplication.Common.Csv.Attributes;
using HotelWebApplication.Common.Csv.Interfaces;

namespace HotelWebApplication.Common.Csv;

public class CsvExporter<T> : ICsvExporter<T>
{
    public Task<ICollection<string>> SaveAsync(ICollection<T> items)
    {
        ICollection<string> csvItems = new List<string>();
        
        foreach (var item in items)
        {
            var row = new List<string>();
            
            foreach (var prop in typeof(T).GetProperties())
            {
                var attribute = prop.GetCustomAttribute<CsvSerializeAttribute>();
                if (attribute is null) continue;

                var value = prop.GetValue(item);
                if (value is null) continue;
                
                byte[] bytes = Encoding.Default.GetBytes(value.ToString());
                var utf8 = Encoding.UTF8.GetString(bytes);
                
                row.Add(utf8);
            }
            
            csvItems.Add(String.Join(',', row));
        }

        return Task.FromResult(csvItems);
    }
}