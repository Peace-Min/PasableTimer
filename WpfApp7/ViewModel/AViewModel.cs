using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp7.ViewModel
{
    public class AViewModel : IViewModel
    {
        private PausableTimer _timer;
        public ICommand Pause => new RelayCommand(Pause1);
        public ICommand Start => new RelayCommand(Pause2);
        public ICommand Resume => new RelayCommand(Pause3);
        public ICommand Stop => new RelayCommand(Pause4);
        private void Pause1()
        {
            ;
            _timer.Pause();

        }
        private void Pause2()
        {
            ;
            _timer.Start();

        }
        private void Pause3()
        {
            ;
            _timer.Resume();

        }
        private void Pause4()
        {
            ;
            _timer.Stop();

        }
        public AViewModel()
        {
            _timer = new PausableTimer(5000);
        }
    }

    public class PausableTimer : Timer
    {
        public double RemainingAfterPause { get; private set; }

        private readonly Stopwatch _stopwatch;
        private readonly double _initialInterval;
        private bool _resumed;

        public PausableTimer(double interval) : base(interval)
        {
            _initialInterval = interval;
            Elapsed += OnElapsed;
            _stopwatch = new Stopwatch();
        }

        public new void Start()
        {
            ResetStopwatch();
            base.Start();
        }

        private void OnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (_resumed)
            {
                _resumed = false;
                Stop();
                Interval = _initialInterval;
                Start();
            }
            Console.WriteLine("Elapsed");
            ResetStopwatch();
        }

        private void ResetStopwatch()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
        }

        public void Pause()
        {
            Stop();
            _stopwatch.Stop();
            RemainingAfterPause = Interval - _stopwatch.Elapsed.TotalMilliseconds;
        }

        public void Resume()
        {
            _resumed = true;
            Interval = RemainingAfterPause;
            RemainingAfterPause = 0;
            Start();
        }
    }
}
