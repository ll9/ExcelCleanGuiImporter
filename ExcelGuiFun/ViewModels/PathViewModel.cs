using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExcelGuiFun.ViewModels
{
    public class PathViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //C# 6 null-safe operator. No need to check for event listeners
            //If there are no listeners, this will be a noop
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // C# 5 - CallMemberName means we don't need to pass the property's name
        protected bool SetField<T>(ref T field, T value,
        [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }


        public PathViewModel()
        {
            PropertyChanged += PathViewModel_PropertyChanged;
        }

        private void PathViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Path))
            {
                HasPath = !string.IsNullOrEmpty(Path) && File.Exists(Path) && System.IO.Path.GetExtension(Path) == ".xlsx";
            }
        }

        private string name;
        public string Path
        {
            get { return name; }
            //C# 5 no need to pass the property name anymore
            set { SetField(ref name, value); }
        }
        private bool hasPath;
        public bool HasPath
        {
            get { return hasPath; }
            set { SetField(ref hasPath, value); }
        }
    }
}
