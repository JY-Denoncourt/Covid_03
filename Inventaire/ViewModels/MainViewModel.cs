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

		public ChangeViewCommand ChangeViewCommand { get; set; }
		

		//------------------------------------------------------------Constructeurs

		public MainViewModel()
		{
			ChangeViewCommand = new ChangeViewCommand(ChangeView);


			customerViewModel = new CustomerViewModel();
			invoiceViewModel = new InvoiceViewModel(customerViewModel.Customers);

			VM = customerViewModel;

		}

		//------------------------------------------------------------Methodes


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














		
		public bool DelCustomerCanUse(Object message)
		{
			if (customerViewModel.SelectedCustomer.Invoices == null)
				return false;

			return true;
		}

	}
}
