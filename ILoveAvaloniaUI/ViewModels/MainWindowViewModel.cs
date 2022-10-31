using System.Windows.Input;
using ReactiveUI;

namespace ILoveAvaloniaUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand IncreaseLoveCommand { get; init; }
        public ICommand DecreaseLoveCommand { get; init; }
        
        public double LoveValue
        {
            get => loveValue;
            set
            {
                this.RaiseAndSetIfChanged(ref loveValue, value);
                this.RaisePropertyChanged(nameof(HeartSize));
            }
        }
        
        public double MinLove 
        {
            get => minLove;
            set => this.RaiseAndSetIfChanged(ref minLove, value);
        }
        
        public double MaxLove 
        {
            get => maxLove;
            set => this.RaiseAndSetIfChanged(ref maxLove, value);
        }

        public double HeartSize => LoveValue * 20;

        public MainWindowViewModel()
        {
            MinLove = 5;
            MaxLove = 12;
            LoveValue = 6;

            IncreaseLoveCommand = ReactiveCommand.Create(IncreaseLove);
            DecreaseLoveCommand = ReactiveCommand.Create(DecreaseLove);
            
        }
        
        private void IncreaseLove()
        {
            if (LoveValue == MaxLove)
                return;
            LoveValue++;
        }
       
        private void DecreaseLove()
        {
            if (LoveValue == MinLove)
                return;
            LoveValue--;
        }

        private double loveValue;
        private double minLove;
        private double maxLove;
    }
}
