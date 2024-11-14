using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int _currentViewModelIndex;
        private IViewModel _currentViewModel;
        public IViewModel CurrentViewModel 
        { 
            get => _currentViewModel;
            set
            {
                if(value != _currentViewModel)
                {
                    _currentViewModel = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentViewModel)));
                }
            }
        }
        public int CurrentViewModelIndex
        {
            get => _currentViewModelIndex;
            set
            {
                if (value != _currentViewModelIndex)
                {
                    _currentViewModelIndex = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentViewModelIndex)));
                    if(value == 0)
                    {
                        CurrentViewModel = new ViewModel.AViewModel();
                    }
                    else if (value == 1)
                    {
                        CurrentViewModel = new ViewModel.BViewModel();
                    }
                }
            }
        }
        public MainWindowViewModel()
        {
            CurrentViewModel = new ViewModel.AViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
