using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ServiceStack.Redis;

namespace UnitTestProject1
{
    public class RedisCaching
    {
        private static readonly string redisHost = ConfigurationManager.AppSettings["redisHost"];
        public static T Get<T>(string key,Func<T> source)
        {
            using (IRedisClient client = new RedisClient(redisHost))
            {
                if(client.ContainsKey(key))
                {
                    return client.Get<T>(key);
                }
                T obj= source();
                client.Set<T>(key, obj);
                return obj;
            }
        }

        public static bool Remove(string key)
        {
            using (IRedisClient client = new RedisClient(redisHost))
            {
                return client.Remove(key);
            }
        }
    }
}
