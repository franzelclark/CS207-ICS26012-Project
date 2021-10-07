using System.ComponentModel.DataAnnotations;
using OS.Helpers;

namespace OS.Models
{
    public class SystemProcess : Observable
    {
        #region Backing Fields

        private int _arrivalTime;
        private int _burstTime;
        private int _completionTime;
        private bool _isCompleted;
        private int _startingBurstTime;

        #endregion

        [Key]
        public int ProcessId { get; set; }
        public int ArrivalTime
        {
            get => _arrivalTime;
            set => Set(ref _arrivalTime, value);
        }
        public int BurstTime
        {
            get => _burstTime;
            set => Set(ref _burstTime, value);
        }
        public int CompletionTime
        {
            get => _completionTime;
            set => Set(ref _completionTime, value);
        }
        public bool IsCompleted
        {
            get => _isCompleted;
            set => Set(ref _isCompleted, value);
        }
        public int StartingBurstTime
        {
            get => _startingBurstTime;
            set
            {
                Set(ref _startingBurstTime, value);
                BurstTime = value;
            }
        }
        public int TurnaroundTime => CompletionTime - ArrivalTime;
        public int WaitingTime => TurnaroundTime - StartingBurstTime;

        public void RefreshBindings()
        {
            OnPropertyChanged(string.Empty);
        }

        public SystemProcess(int processId) 
        {
            ProcessId = processId;
        }
    }
}
