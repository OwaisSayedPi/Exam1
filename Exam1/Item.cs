using System;
using System.Windows.Input;
using System.Windows.Media;

namespace Exam1
{
    public class Item: BaseViewModel
    {
        private Brush _colour = Brushes.Gray;

        public Brush Colour
        {
            get { return _colour; }
            set { 
                _colour = value;
            }
        }

        public Item GetItem {
            get
            {
                return this;
            }
        }
        public string Value { get; set; }
        public ICommand DeleteCommand { get; set; }
        public Item(Action<Item> action)
        {
            DeleteCommand = new RelayCommand(action, GetItem);
        }
    }
}