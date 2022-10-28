using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ILoveAvaloniaUI.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HeartSize))]
        private double loveValue;
        
        [ObservableProperty] private double minLove;
        [ObservableProperty] private double maxLove;

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
            if (LoveValue == MaxLove)
                return;
            LoveValue++;
        }

        [RelayCommand]
        private void DecreaseLove()
        {
            if (LoveValue == MinLove)
                return;
            LoveValue--;
        }

       
    }
}
