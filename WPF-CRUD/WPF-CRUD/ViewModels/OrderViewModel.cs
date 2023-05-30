using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WPF_CRUD.Models;
using CommunityToolkit.Mvvm.Input;

namespace WPF_CRUD.ViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Item> selectedItems;
        private ObservableCollection<Order> orders;
        private Item selectedListItem;
        private Customer selectedCustomer;
        private ApplicationDbContext dbContext;
        private ObservableCollection<Item> orderItems;

        public ObservableCollection<Item> OrderItems
        {
            get { return orderItems; }
            set
            {
                orderItems = value;
                OnPropertyChanged(nameof(OrderItems));
            }
        }

        public ObservableCollection<Item> SelectedItems
        {
            get { return selectedItems; }
            set
            {
                selectedItems = value;
                OnPropertyChanged(nameof(SelectedItems));
            }
        }

        public ObservableCollection<Order> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public Item SelectedListItem
        {
            get { return selectedListItem; }
            set
            {
                selectedListItem = value;
                OnPropertyChanged(nameof(SelectedListItem));
            }
        }

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        public ICommand MakeOrderCommand { get; }

        public OrderViewModel()
        {
            dbContext = new ApplicationDbContext();

            SelectedItems = new ObservableCollection<Item>();
            Orders = new ObservableCollection<Order>(dbContext.Orders);
            OrderItems = new ObservableCollection<Item>();

            MakeOrderCommand = new RelayCommand(MakeOrder);
        }

        public void AddToList(Item item)
        {
            if (item != null)
            {
                SelectedItems.Add(item);
                UpdateOrderItems();
            }
        }

        private void UpdateOrderItems()
        {
            OrderItems.Clear();
            foreach (var item in SelectedItems)
            {
                OrderItems.Add(item);
            }
        }

        private void MakeOrder()
        {
            if (SelectedCustomer != null && SelectedItems.Count > 0)
            {
                var order = new Order
                {
                    Id = Guid.NewGuid(),
                    OrderInvoiceNo = GenerateInvoiceNumber(),
                    OrderDateTime = DateTime.Now,
                    CustomerId = SelectedCustomer.Id,
                    Customer = SelectedCustomer,
                    TotalPrice = (float)CalculateTotalPrice(),
                    ShippingDate = null
                };

                dbContext.Orders.Add(order);
                dbContext.SaveChanges();

                Orders.Add(order);

                ClearOrderDetails();
            }
        }

        private string GenerateInvoiceNumber()
        {
            string date = DateTime.Now.ToString("yyyyMMddHHmmss");
            string invoiceNumber = "INV-" + date;
            return invoiceNumber;
        }

        private decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (var item in SelectedItems)
            {
                totalPrice += (item.UnitPrice - item.Discount) * item.Quantity;
            }

            return totalPrice;
        }

        private void ClearOrderDetails()
        {
            SelectedItems.Clear();
            SelectedCustomer = null;
            UpdateOrderItems();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
