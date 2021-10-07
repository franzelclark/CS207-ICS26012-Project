#nullable enable
using System;
using System.Windows.Input;

namespace OS.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action _callback;
        private readonly Action<Exception> _exceptionCallback;
        private bool _isExecuting;

        public bool CanExecute(object? parameter) => IsExecuting == false;
        public void Execute(object? parameter)
        {
            IsExecuting = true;
            try
            {
                _callback.Invoke();
            }
            catch (Exception exception)
            {
                _exceptionCallback.Invoke(exception);
            }
            IsExecuting = false;
        }

        public bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        public RelayCommand(Action callback, Action<Exception> exceptionCallback)
        {
            _callback = callback;
            _exceptionCallback = exceptionCallback;
        }

        public event EventHandler? CanExecuteChanged;
    }
}
