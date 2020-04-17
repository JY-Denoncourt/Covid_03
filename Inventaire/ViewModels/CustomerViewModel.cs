using BillingManagement.Business;
using BillingManagement.Models;
using BillingManagement.UI.ViewModels.Commands;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BillingManagement.UI.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        //------------------------------------------------------------------------------Variables 

        readonly CustomersDataService customersDataService = new CustomersDataService();

        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;

        //------------------------------------------------------------------------------Definitions

        public ObservableCollection<Customer> Customers
        {
            get => customers;
            private set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged();
            }
        }


        public ChangeViewCommand ChangeViewCommand { get; set; }

        public RelayCommand DeleteCustomerCommand { get; private set; }

        //------------------------------------------------------------------------------Constructeur

        public CustomerViewModel()
        {
            
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer, canDeleteCustomer);
            
            InitValues();
        }

        //------------------------------------------------------------------------------Methodes

        private void InitValues()
        {
            Customers = new ObservableCollection<Customer>(customersDataService.GetAll());
            Debug.WriteLine(Customers.Count);
        }


        private void DeleteCustomer(Object C)
        {
            Customer customer = (Customer)C;

            var currentIndex = Customers.IndexOf(customer);

            if (currentIndex > 0) currentIndex--;

            SelectedCustomer = Customers[currentIndex];

            Customers.Remove(customer);
        }

       
        private bool canDeleteCustomer(Object C)
        {
            if (C == null) return false;

            Customer customer = (Customer)C;
            return customer.Invoices.Count == 0;
        }
    }
}
