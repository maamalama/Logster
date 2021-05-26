using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Logster.Serialization
{
    public static class Serializer
    {
        public static T Deserialize<T>(string body)
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(body);
                writer.Flush();
                stream.Position = 0;
                return (T) new DataContractJsonSerializer(typeof(T)).ReadObject(stream);
            }
        }
        
        public static string Serialize<T>(T item)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Type t = typeof(T);
                new DataContractJsonSerializer(typeof(T)).WriteObject(ms, item);
                var result = Encoding.Default.GetString(ms.ToArray());
                return string.IsNullOrEmpty(result) ? String.Empty : result;
            }
        }
    }
}