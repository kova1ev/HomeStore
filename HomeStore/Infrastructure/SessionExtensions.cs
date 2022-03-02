using System.Text.Json;

namespace HomeStore.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session,string key)
        {
            var tempData = session.GetString(key);
            return tempData == null ? default(T) : JsonSerializer.Deserialize<T>(tempData);
        }
    }
}
