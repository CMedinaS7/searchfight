using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using searchfight.Model;
using searchfight.Service;

namespace searchfight
{
    class Program
    {
        static void Main(string[] args)
        {           

            try
            {
                //test
                //string[] arr1 = new string[] { ".net", "java" };

                searchfight(args).Wait();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: {0}", ex.Message); ;
            }

        }

        static async Task searchfight(string[] args)
        {
            List<ResultSearch> resultList = new List<ResultSearch>();

            foreach (var language in args)
            {
                ResultSearch googleResult = await new GoogleSearch().searchAsync(language);
                ResultSearch bingResult = await new BingSearch().searchAsync(language);

                resultList.Add(googleResult);
                resultList.Add(bingResult);

                Console.WriteLine(string.Format("{0} : {1}:{2} {3}:{4}", language, googleResult.Engine, googleResult.Total, bingResult.Engine, bingResult.Total));
            }

            var winnerSearchEngine = resultList.OrderByDescending(x => x.Total).GroupBy(x => x.Engine)
                .Select(e =>
                {
                    var winner = e.FirstOrDefault();
                    return new ResultSearch(e.Key, winner.Language, 1);
                });
                        
            var totalWinner = resultList.GroupBy(e => e.Language)
                .Select(e => new
                {
                    Language = e.Key,
                    Total = e.Sum(m => m.Total)
                })
                .OrderByDescending(e => e.Total)
                .FirstOrDefault();

            foreach (var winner in winnerSearchEngine)
            {
                Console.WriteLine("{0} winner: {1}", winner.Engine, winner.Language);
            }

            if (totalWinner != null)
                Console.WriteLine("Total winner: {0}", totalWinner.Language);
        }
    }
}
