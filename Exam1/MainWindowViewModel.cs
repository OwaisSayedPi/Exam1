using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Exam1
{
    public class MainWindowViewModel:BaseViewModel
    {
        private string _value = "";
        public string Value {
            get
            {
                return _value;
            } 
            set
            {
                if (value.Contains(",") && string.IsNullOrWhiteSpace(value))
                {
                    AddToList(value.Split(',')[0]);
                    _value = "";
                }
                else
                {
                    _value = value;
                }
            } 
        }
        private Item _selectedItem;
        public Item SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
              {
                ColourChange(value);
            }
        }
        private void ColourChange(Item temp)
        {
            var tempList = new ObservableCollection<Item>();
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (temp.Value == ItemList[i].Value)
                {
                    ItemList[i].Colour = Brushes.Green;
                }
                else
                {
                    ItemList[i].Colour = Brushes.Gray;
                }
                tempList.Add(ItemList[i]);
            }
            ItemList.Clear();
            ItemList = tempList;
            OnPropertyChanged(nameof(ItemList));
        }

        public Item Item { get; set; }
        public ObservableCollection<Item> ItemList { get; set; }
        public MainWindowViewModel()
        {
            ItemList = new ObservableCollection<Item>();
        }
        private void RemoveFromList(Item temp)
        {
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (temp.Value == ItemList[i].Value)
                {
                    ItemList.RemoveAt(i);
                }
            }
            OnPropertyChanged(nameof(ItemList));
        }
        private void AddToList(string value)
        {
            if (ItemList.Count != 0)
            {
                for (int i = 0; i < ItemList.Count; i++)
                {
                    if (value.ToLower() == ItemList[i].Value.ToLower())
                    {
                        break;
                    }
                    else
                    {
                        Item = new Item(RemoveFromList) { Value = value };
                        ItemList.Add(Item);
                    }
                }
            }
            else
            {
                Item = new Item(RemoveFromList) { Value = value };
                ItemList.Add(Item);
            }           
        }
    }
}
