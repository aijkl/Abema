using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Imaging;

namespace Aijkl.Abema.Apps.VideoViewer.Expansion
{
    internal static class BitmapExpansion
    {
        public static BitmapSource BitmapToBitmapSource(this Bitmap bitmap)
        {
            using var ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            BitmapSource bitmapSource = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            return bitmapSource;
        }
    }
}
