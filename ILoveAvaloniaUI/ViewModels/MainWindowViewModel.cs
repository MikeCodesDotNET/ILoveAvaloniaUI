using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace ILoveAvaloniaUI.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public double HeartSize => LoveValue * 20;

        public MainWindowViewModel()
        {
            MinLove = 5;
            MaxLove = 12;
            LoveValue = 6;
        }
        
        [RelayCommand]
        private void IncreaseLove()
        {
            if (Math.Abs(LoveValue - MaxLove) < 0.001)
                return;
            LoveValue++;
        }
       
        [RelayCommand]
        private void DecreaseLove()
        {
            if (Math.Abs(LoveValue - MinLove) < 0.001)
                return;
            LoveValue--;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HeartSize))]
        private double _loveValue;
        
        [ObservableProperty]
        private double _minLove;
        
        [ObservableProperty]
        private double _maxLove;
    }
}
