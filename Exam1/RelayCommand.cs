using System;
using System.Windows.Input;

namespace Exam1
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action vm;
        Action<Item> vm1;
        public Item temp { get; set; }
        public RelayCommand(Action _vm)
        {
            vm = _vm;
        }
        public RelayCommand(Action<Item> _vm, Item temp)
        {
            vm1 = _vm;
            this.temp = temp;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vm?.Invoke();
            vm1?.Invoke(temp);
        }
    }
}