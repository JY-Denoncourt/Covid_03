using BillingManagement.Models;
using BillingManagement.UI.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    class MainViewModel : BaseViewModel
    {
		//------------------------------------------------------------Variables
		
		private BaseViewModel _vm;

		CustomerViewModel customerViewModel;
		InvoiceViewModel invoiceViewModel;
		
		//------------------------------------------------------------Definitions

		public BaseViewModel VM
		{
			get { return _vm; }
			set {
				_vm = value;
				OnPropertyChanged();
			}
		}

		public RelayCommand NewCustomerCommand { get; private set; }
		public RelayCommand DisplayInvoiceCommand { get; private set; }
		public RelayCommand DisplayCustomerCommand { get; private set; }
		public ChangeViewCommand ChangeViewCommand { get; set; }
		

		//------------------------------------------------------------Constructeurs

		public MainViewModel()
		{
			NewCustomerCommand = new RelayCommand(NewCustomer);
			ChangeViewCommand = new ChangeViewCommand(ChangeView);
			DisplayInvoiceCommand = new RelayCommand(DisplayInvoice);


			customerViewModel = new CustomerViewModel();
			invoiceViewModel = new InvoiceViewModel(customerViewModel.Customers);

			VM = customerViewModel;

		}

		//------------------------------------------------------------Methodes


		private void NewCustomer(object c)
		{
			Customer customer = new Customer();

			customerViewModel.Customers.Add(customer);
			customerViewModel.SelectedCustomer = customer;

			VM = customerViewModel;
		}

		public void ChangeView(Object vm)
		{
			switch ((string)vm)
			{
				case "customers":
					VM = customerViewModel;
					break;
				case "invoices":
					VM = invoiceViewModel;
					break;
			}
		}


		private void DisplayInvoice(Object i)
		{
			Invoice invoice = (Invoice)i;

			invoiceViewModel.SelectedInvoice = invoice;
			VM = invoiceViewModel;

		}











		
		
	}
}
