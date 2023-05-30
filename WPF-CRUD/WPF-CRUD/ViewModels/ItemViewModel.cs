using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_CRUD.Models;

namespace WPF_CRUD.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Item> items;
        private Item newItem;
        private ApplicationDbContext dbContext;
        private OrderViewModel orderViewModel;
        private Item selectedItem;

        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ObservableCollection<Item> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public Item NewItem
        {
            get { return newItem; }
            set
            {
                newItem = value;
                OnPropertyChanged(nameof(NewItem));
            }
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddToOrderList { get; }

        public ItemViewModel()
        {
            dbContext = new ApplicationDbContext();

            Items = new ObservableCollection<Item>(dbContext.Items);

            NewItem = new Item();

            AddCommand = new RelayCommand(AddItem);
            UpdateCommand = new RelayCommand(UpdateItem);
            DeleteCommand = new RelayCommand(DeleteItem);
            AddToOrderList = new RelayCommand(AddToOrderListItem);
            orderViewModel = new OrderViewModel();
        }

        private void AddItem()
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Name = NewItem.Name,
                UnitPrice = NewItem.UnitPrice,
                Discount = NewItem.Discount,
                Quantity = NewItem.Quantity
            };

            dbContext.Items.Add(item);
            dbContext.SaveChanges();

            Items.Add(item);

            NewItem = new Item();
        }

        private void UpdateItem()
        {
            Item selectedItem = newItem;

            if (selectedItem != null)
            {
                selectedItem.Name = NewItem.Name;
                selectedItem.UnitPrice = NewItem.UnitPrice;
                selectedItem.Discount = NewItem.Discount;
                selectedItem.Quantity = NewItem.Quantity;

                dbContext.SaveChanges();
            }
        }

        private void DeleteItem()
        {
            Item selectedItem = Items.FirstOrDefault();

            if (selectedItem != null)
            {
                dbContext.Items.Remove(selectedItem);
                dbContext.SaveChanges();

                Items.Remove(selectedItem);
            }
        }

        public void AddToOrderListItem()
        {
            if (SelectedItem != null)
            {
                orderViewModel.AddToList(SelectedItem); 
                SelectedItem = null;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
