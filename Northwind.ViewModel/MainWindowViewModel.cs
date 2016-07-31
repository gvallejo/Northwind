﻿using System.Collections.Generic;
using Northwind.Model;
using Northwind.Application;
using System.Collections.ObjectModel;
using System;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;

namespace Northwind.ViewModel
{
    public class MainWindowViewModel
    {
        private readonly IUIDataProvider _dataProvider;

        public ObservableCollection<ToolViewModel> Tools { get; set; }

        public string Name
        {
            get
            {
                return "Northwind";
            }
        }
        public string ControlPanelName
        {
            get
            {
                return "Control Panel";
            }
        }
        private IList<Customer> _customers;
        public IList<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    GetCustomers();
                }
                return _customers;
            }
        }
       
        private void GetCustomers()
        {
            _customers = _dataProvider.GetCustomers();
        }

        public string SelectedCustomerID
        {
            get;
            set;
        }
        public MainWindowViewModel(IUIDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Tools = new ObservableCollection<ToolViewModel>();
        }
        public void ShowCustomerDetails()
        {
            if (string.IsNullOrEmpty(SelectedCustomerID))
                throw new InvalidOperationException("SelectedCustomerID can't be null");

            //Query the Tools tab control for a CustomerDetailsViewModel that has a customerID == SelectedCustomerID
            CustomerDetailsViewModel customerDetailsViewModel = GetCustomerDetailsTool(SelectedCustomerID);
            if (customerDetailsViewModel == null)
            {
                customerDetailsViewModel = new CustomerDetailsViewModel(_dataProvider, SelectedCustomerID);
                Tools.Add(customerDetailsViewModel);
            }
            SetCurrentTool(customerDetailsViewModel);
        }
        private CustomerDetailsViewModel GetCustomerDetailsTool(string customerID)
        {
            return Tools.OfType<CustomerDetailsViewModel>().FirstOrDefault(c => c.Customer.CustomerID == customerID);
        }
        private void SetCurrentTool(ToolViewModel currentTool)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(Tools);
            if (collectionView != null)
            {
                if (collectionView.MoveCurrentTo(currentTool) != true)
                {
                    throw new InvalidOperationException("Could not find the current tool.");
                }
            }
        }
    }
}