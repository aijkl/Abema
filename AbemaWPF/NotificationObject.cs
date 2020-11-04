using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Aijkl.Abema.Apps.VideoViewer
{
    internal abstract class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal bool SetProperty<T>(ref T target, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(target, value)) return false;

            target = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
