using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace Aijkl.Abema.Apps.VideoViewer
{
    public class VideoInfo
    {
        public VideoInfo(BitmapSource icon, string url, string title, int rank)
        {
            Icon = icon;
            Url = url;
            Title = title;
            Rank = rank;
        }
        public BitmapSource Icon { private set; get; }
        public string Url { private set; get; }
        public string Title { private set; get; }        
        public int Rank { private set; get; }
    }
}
