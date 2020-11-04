using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aijkl.Abema.API;
using Colorful;
using Console = Colorful.Console;

namespace AbemaCrawler
{
    class Program
    {
        static async Task Main()
        {
            Setting setting = Setting.Load($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}setting.json");
            AbemaClient abemaClient = new AbemaClient(setting.BearerToken);
            FigletFont font = FigletFont.Load("banner.flf");
            Figlet figlet = new Figlet(font);

            var rankingResponse = await abemaClient.Ranking.Fetch(ContentsType.Animation, limit:99) ;
            Console.WriteLine(figlet.ToAscii("All Free"));
            rankingResponse.Result.Series.Where(x => x.Label.Free == true).ToList().ForEach(x => Console.WriteLine($"{x.Title} Ranking:{x.Rank}"));
            Console.WriteLine();
            Console.WriteLine(figlet.ToAscii("Some Free"));
            rankingResponse.Result.Series.Where(x => x.Label.SomeFree == true).ToList().ForEach(x => Console.WriteLine($"{x.Title} Ranking:{x.Rank}"));
            Console.WriteLine(figlet.ToAscii("RwsponseCount"));
            Console.WriteLine(rankingResponse.Result.Series.Count);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
