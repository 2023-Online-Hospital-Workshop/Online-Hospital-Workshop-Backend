
using System.Text.Json;

namespace test.Models
{
    public class Message
    {
        private readonly Dictionary<string, object> _data = new();

        public void Add(string key, object value)
        {
            _data.Add(key, value);
        }

        public string ReturnJson()
        {
            return JsonSerializer.Serialize(_data);
        }
    }
}
