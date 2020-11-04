using Aijkl.Abema.Apps.VideoViewer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Aijkl.Abema.Apps.VideoViewer.ViewModels
{
    class MainViewModel : NotificationObject
    {
        private List<VideoInfo> freeVideos;
        private List<VideoInfo> someFreeideos;
        private List<VideoInfo> newestVideos;
        private List<VideoInfo> allVideos;
        private bool isUpdating;
        private readonly MainModel mainModel;        

        public MainViewModel()
        {
            //TODO 
            //GET Token
            mainModel = new MainModel(token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXYiOiIwZTZhYjU3Yy01YTczLTRjYTctOTVhOS05YzFmNWVlZDA2Y2UiLCJleHAiOjIxNDc0ODM2NDcsImlzcyI6ImFiZW1hLmlvL3YxIiwic3ViIjoiRjI3aEFSN29YQzlIVnkifQ.Dku7Iizluti0idQh-zcfcyU_UfgmTdn3_dyq-N1XKsE");
        }
        public List<VideoInfo> FreeVideos 
        {
            set
            {
                SetProperty(ref freeVideos, value);
            }
            get
            {
                return freeVideos;
            }
        }
        public List<VideoInfo> SomeFreeVideos
        {
            set
            {
                SetProperty(ref someFreeideos, value);
            }
            get
            {
                return someFreeideos;
            }
        }
        public List<VideoInfo> NewestVideos
        {
            set
            {
                SetProperty(ref newestVideos, value);
            }
            get
            {
                return newestVideos;
            }
        }
        public List<VideoInfo> AllVideos
        {
            set
            {
                SetProperty(ref allVideos, value);
            }
            get
            {
                return allVideos;
            }
        }
        public bool IsUpdating
        {
            private set
            {
                SetProperty(ref isUpdating, value);
                Debug.WriteLine($"ProgressBar Status:{value}");
            }
            get
            {
                return isUpdating;
            }
        }
        public void Update()
        {
            IsUpdating = true;
            mainModel.Update();
            FreeVideos = mainModel.FreeVideos;
            SomeFreeVideos = mainModel.SomeFreeVideos;
            NewestVideos = mainModel.NewestVideos;
            AllVideos = mainModel.AllVideos;
            IsUpdating = false;
        }
    }
}
