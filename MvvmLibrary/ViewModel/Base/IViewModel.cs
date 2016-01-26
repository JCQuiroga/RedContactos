using System;
using System.ComponentModel;

namespace MvvmLibrary.ViewModel.Base
{
    public interface IViewModel : INotifyPropertyChanged
    {
        string Titulo { get; set; }
        void SetState<T>(Action<T> action) where T : class, IViewModel;
    }
}