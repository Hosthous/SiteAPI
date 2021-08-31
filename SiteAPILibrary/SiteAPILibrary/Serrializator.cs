using SiteAPILibrary.Entities;
using System.Text.Json;

namespace SiteAPILibrary
{
    public class Serrializator
    {
        public T JsonToEnt<T>(string Json)
        {

            var entity = JsonSerializer.Deserialize<T>(Json);
            return (T)entity;
        }

        public string EntToJson(EntityBase entity)
        {
            var json = JsonSerializer.Serialize(entity);
            return json;
        }
    }
}
