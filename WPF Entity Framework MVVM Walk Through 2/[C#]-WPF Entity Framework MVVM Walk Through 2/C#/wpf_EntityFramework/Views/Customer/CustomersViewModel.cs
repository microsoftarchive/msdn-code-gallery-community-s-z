using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data.Entity;
using wpf_EntityFramework.EntityData;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Threading;

namespace wpf_EntityFramework
{
    public class CustomersViewModel : CrudVMBase
    {
        private CustomerVM selectedCustomer;
        public CustomerVM SelectedCustomer
        {
            get
            {
                return selectedCustomer;
            }
            set
            {
                selectedCustomer = value;
                selectedEntity = value;
                RaisePropertyChanged();
            }
        }

        private CustomerVM editVM;
        public CustomerVM EditVM
        {
            get
            {
                return editVM;
            }
            set
            {
                editVM = value;
                editEntity = editVM.TheEntity;
                RaisePropertyChanged();
            }
        }
        
        public ObservableCollection<CustomerVM> Customers { get; set; }
        public CustomersViewModel() 
            :  base()
        {

        }
        protected override void EditCurrent()
        {
            EditVM = SelectedCustomer;
            IsInEditMode = true;
        }
        protected override void InsertNew()
        {
            EditVM = new CustomerVM();
            IsInEditMode = true;
        }
        protected override void CommitUpdates()
        {
            if (EditVM == null || EditVM.TheEntity == null)
            {
                if (db.ChangeTracker.HasChanges())
                {
                    UpdateDB();
                }
                return;
            }
            if (EditVM.TheEntity.IsValid())
            {
                if (EditVM.IsNew)
                {
                    EditVM.IsNew = false;
                    Customers.Add(EditVM);
                    db.Customers.Add(EditVM.TheEntity);
                    UpdateDB();
                }
                else if (db.ChangeTracker.HasChanges())
                {
                    UpdateDB();
                }
                else
                {
                    ShowUserMessage("No changes to save");
                }
            }
            else
            {
                ShowUserMessage("There are problems with the data entered");
            }
        }
        private async void UpdateDB()
        {
            try
            {
                await db.SaveChangesAsync();
                ShowUserMessage("Database Updated");
            }
            catch (Exception e)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    ErrorMessage = e.InnerException.GetBaseException().ToString();
                }
                ShowUserMessage("There was a problem updating the database");
            }
            ReFocusRow();
        }
        protected override void DeleteCurrent()
        {
            int NumOrders = NumberOfOrders();
            if (NumOrders > 0)
            {
                ShowUserMessage( string.Format("Cannot delete - there are {0} Orders for this Customer", NumOrders));
            }
            else
            {
                db.Customers.Remove(SelectedCustomer.TheEntity);
                Customers.Remove(SelectedCustomer);
                RaisePropertyChanged("Customers");
                CommitUpdates();
                selectedEntity = null;
            }
        }
        protected override void Quit()
        {
            if (!EditVM.IsNew)
            {
                ReFocusRow();
            }
        }
        protected async void ReFocusRow(bool withReload  = true)
        {
            int id = EditVM.TheEntity.Id;
            SelectedCustomer = null;
            await db.Entry(EditVM.TheEntity).ReloadAsync();
            await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
                {
                    SelectedCustomer = Customers.Where(e => e.TheEntity.Id == id).FirstOrDefault();
                    SelectedCustomer.TheEntity = SelectedCustomer.TheEntity;
                    SelectedCustomer.TheEntity.ClearErrors();
                }), DispatcherPriority.ContextIdle);
            IsInEditMode = false;
        }

        private int NumberOfOrders()
        {
            var cust = db.Customers.Find(SelectedCustomer.TheEntity.Id);
            // Count how many Order Lines the Product has
            int ordersCount = db.Entry(cust)
                                .Collection(c => c.Orders)
                                .Query()
                                .Count();
            return ordersCount;
        }
        protected async override void GetData()
        {
            ThrobberVisible = Visibility.Visible;

            ObservableCollection<CustomerVM> _customers = new ObservableCollection<CustomerVM>();
            //db.Database.Log =  Console.Write; 

            var customers = await (from c in db.Customers
                                   orderby c.CustomerName
                                   select c)
                                   .Include(x => x.Orders) //.Include("Orders") alternate syntax
                                  
                                   .ToListAsync();
            //   await Task.Delay(9000);
            foreach (Customer cust in customers)
            {
                _customers.Add(new CustomerVM { IsNew = false, TheEntity = cust });
            }
            Customers = _customers;
            RaisePropertyChanged("Customers");
            ThrobberVisible = Visibility.Collapsed;
        }
    }
}

