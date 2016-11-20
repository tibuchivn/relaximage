using System;
using System.Collections.Generic;
using System.Linq;
using BOLService;
using ServiceStack.Redis;

namespace DemoRedis
{
    class Program
    {
        static void Main(string[] args)
        {
            InitDataForRedis();
            Console.WriteLine("Hit return to exit!");
            Console.Read();
        }

        private static void InitDataForRedis()
        {
            RedisMemoryProvider<VietlottVNDto> r = new RedisMemoryProvider<VietlottVNDto>();
            
            VietLottVNService vietlottVnService = new VietLottVNService();
            //TODO: Init Vietlott Results
            var lst = vietlottVnService.GetAllVietlottVN();
            foreach (var vlvnDto in lst)
            {
                if (r.FindBy<VietlottVNDto>(o => o.DatePize == vlvnDto.DatePize).Count == 0)
                {
                    r.Create<VietlottVNDto>(vlvnDto);
                }
            }

            //TODO: VietlottVNAppearance
            int[] arr = vietlottVnService.GetFrequencyNumbers();
            for (int i = 0; i < arr.Length; i++)
            {
                var obj = new VietlottVNAppearance()
                {
                    Number = i + 1,
                    Appearance = arr[i]
                };
                var v = r.FindBy<VietlottVNAppearance>(o => o.Number == obj.Number).FirstOrDefault();
                if (v == null)
                {
                    //TODO: Add New
                    r.Create<VietlottVNAppearance>(obj);
                }
                else
                {
                    //TODO: Update
                    r.Update<VietlottVNAppearance>(x => x.Number == v.Number, v);
                }
            }
            //TODO: Init VietlottVNRamdom
            var lstArr = new[]
            {
                1, 2, 3, 4, 5,6,7,8,9,10,
                11,12,13,14,15,16,17,18,19,20,
                21,22,23,24,25,26,27,28,29,30,
                31,32,33,34,35,36,37,38,39,40,
                41,42,43,44,45
            };
            var vRandoms = VietlottCombinations.Combinations(lstArr, 6).ToList();
            for (int j = 0; j < vRandoms.Count(); j++)
            {
                var rs = vRandoms[j].ToList();
                var vVietlootVNRamdom = new VietlottVNRandom()
                {
                    listNumbers = rs,
                    BlogNumber = String.Join("-", vRandoms[j]),
                    NumberOne = rs[0],
                    NumberTwo = rs[1],
                    NumberThree = rs[2],
                    NumberFour = rs[3],
                    NumberFive = rs[4],
                    NumberSix = rs[5],
                };
                var v = r.FindBy<VietlottVNRandom>(o => o.BlogNumber == vVietlootVNRamdom.BlogNumber).FirstOrDefault();
                if (v == null)
                {
                    //TODO: Add New
                    r.Create<VietlottVNRandom>(vVietlootVNRamdom);
                }
            }
        }
    }
}
