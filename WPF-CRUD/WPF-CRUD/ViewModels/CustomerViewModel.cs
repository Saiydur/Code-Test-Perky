using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WPF_CRUD.Models;

namespace WPF_CRUD.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Customer> customers;
        private Customer newCustomer;
        private ApplicationDbContext dbContext;

        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public Customer NewCustomer
        {
            get { return newCustomer; }
            set
            {
                newCustomer = value;
                OnPropertyChanged(nameof(NewCustomer));
            }
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public CustomerViewModel()
        {
            dbContext = new ApplicationDbContext();

            Customers = new ObservableCollection<Customer>(dbContext.Customers);

            NewCustomer = new Customer();

            AddCommand = new RelayCommand(AddCustomer);
            UpdateCommand = new RelayCommand(UpdateCustomer);
            DeleteCommand = new RelayCommand(DeleteCustomer);
        }

        private void AddCustomer()
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = NewCustomer.Name,
                Address = NewCustomer.Address,
                ShippingAddress = NewCustomer.ShippingAddress
            };

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            Customers.Add(customer);

            NewCustomer = new Customer();
        }

        private void UpdateCustomer()
        {
            Customer selectedCustomer = newCustomer;

            if (selectedCustomer != null)
            {
                selectedCustomer.Name = NewCustomer.Name;
                selectedCustomer.Address = NewCustomer.Address;
                selectedCustomer.ShippingAddress = NewCustomer.ShippingAddress;

                dbContext.SaveChanges();
            }
        }

        private void DeleteCustomer()
        {
            Customer selectedCustomer = Customers.FirstOrDefault();

            if (selectedCustomer != null)
            {
                dbContext.Customers.Remove(selectedCustomer);
                dbContext.SaveChanges();

                Customers.Remove(selectedCustomer);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}