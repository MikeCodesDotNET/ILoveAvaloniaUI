using System;
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
            get => _loveValue;
            set
            {
                this.RaiseAndSetIfChanged(ref _loveValue, value);
                this.RaisePropertyChanged(nameof(HeartSize));
            }
        }
        
        public double MinLove 
        {
            get => _minLove;
            set => this.RaiseAndSetIfChanged(ref _minLove, value);
        }
        
        public double MaxLove 
        {
            get => _maxLove;
            set => this.RaiseAndSetIfChanged(ref _maxLove, value);
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
            if (Math.Abs(LoveValue - MaxLove) < 0.001)
                return;
            LoveValue++;
        }
       
        private void DecreaseLove()
        {
            if (Math.Abs(LoveValue - MinLove) < 0.001)
                return;
            LoveValue--;
        }

        private double _loveValue;
        private double _minLove;
        private double _maxLove;
    }
}
