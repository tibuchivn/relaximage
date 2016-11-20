using System.Collections.Generic;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using VietLottVNAPI.Models;

namespace VietLottVNAPI.Services
{
    public class VietlottvnService
    {
        private readonly IRedisClient _redisClient;
         
        public VietlottvnService(IRedisClient redisClient)
        {
            //string host = "localhost";
            //_redisClient = new RedisClient(host);
            _redisClient = redisClient;
        }

        //public IEnumerable<VietlottvnAppearance> GetAllAppearance()
        //{
        //    //Create a 'strongly-typed' API that makes all Redis Value operations to apply against VietlottvnAppearance
        //    IRedisTypedClient<VietlottvnAppearance> lstAppearance = _redisClient.As<VietlottvnAppearance>();
        //    //Redis lists implement IList<T> while Redis sets implement ICollection<T>
        //    IRedisList<VietlottvnAppearance> lstApp = lstAppearance.Lists["urn:vietlottvnappearance"];
        //    IEnumerable<VietlottvnAppearance> myList = lstApp.GetAll();
        //    return myList;
        //}

        public IEnumerable<VietlottvnAppearance> GetAllAppearance()
        {
            return null;
        }

    }
}