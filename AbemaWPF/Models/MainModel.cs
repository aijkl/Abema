using Aijkl.Abema.API;
using Aijkl.Abema.API.Models;
using Aijkl.Abema.Apps.VideoViewer.Expansion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aijkl.Abema.Apps.VideoViewer.ViewModels
{
    public class MainModel : IDisposable
    {
        private readonly AbemaClient abemaClient;
        private readonly HttpClient httpClient;
        private Dictionary<string, Bitmap> cacheImages;
        public MainModel(string token)
        {
            abemaClient = new AbemaClient(token);
            httpClient = new HttpClient();
            cacheImages = new Dictionary<string, Bitmap>();
        }
        public List<VideoInfo> FreeVideos { private set; get; }
        public List<VideoInfo> SomeFreeVideos { private set; get; }
        public List<VideoInfo> NewestVideos { private set; get; }
        public List<VideoInfo> AllVideos { private set; get; }        
        public void Dispose()
        {
            cacheImages?.ToList().ForEach(x => x.Value.Dispose());
            cacheImages = null;
        }
        public void Update()
        {            
            var task = abemaClient.Ranking.Fetch(ContentsType.Animation, 99);
            task.Wait();            

            FreeVideos = task.Result.Result.Series.Where(x => x.Label.Free == true).ToList().Select(x =>
            {                
                var task = CreateVideoInfoAsync(x);
                return task.Result;
            }).ToList();
            SomeFreeVideos = task.Result.Result.Series.Where(x => x.Label.SomeFree == true).ToList().Select(x =>
            {                
                var task = CreateVideoInfoAsync(x);
                return task.Result;
            }).ToList();
            NewestVideos = task.Result.Result.Series.Where(x => x.Label.Newest == true).ToList().Select(x =>
            {                
                var task = CreateVideoInfoAsync(x);
                return task.Result;
            }).ToList();
            AllVideos = task.Result.Result.Series.Select(x =>
            {                
                var task = CreateVideoInfoAsync(x);
                return task.Result;
            }).ToList();
            cacheImages.ToList().ForEach(x => x.Value.Dispose());
        }
        private async Task<VideoInfo> CreateVideoInfoAsync(Series series)
        {
            string videoUrl = $"https://abema.tv/video/title/{series.Id}";
            if (!cacheImages.ContainsKey(series.Id))
            {
                Bitmap bitmap = await DownLoadImageAsync(series.Id, new Size(100, 100));
                cacheImages.Add(series.Id, bitmap);
            }
            return new VideoInfo(cacheImages[series.Id].BitmapToBitmapSource(), videoUrl, series.Title, series.Rank);
        }
        private async Task<Bitmap> DownLoadImageAsync(string id, Size size, int quality = 85)
        {
            var res = await httpClient.GetAsync($"https://hayabusa.io/abema/series/{id}/thumb.jpg?width={size.Width}&height={size.Height}&quality={quality}").ConfigureAwait(false);
            return new Bitmap(await res.Content.ReadAsStreamAsync().ConfigureAwait(false));
        }
    }
}
