using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data.Entity;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Threading;
using wpf_EntityFramework.EntityData;
using System.Windows.Media;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace wpf_EntityFramework
{
    public class ProductsViewModel : CrudVMBase
    {
        private ProductVM selectedProduct;
        public ProductVM SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                selectedProduct = value;
                selectedEntity = value;
                RaisePropertyChanged();
            }
        }

        private ProductVM editVM;
        public ProductVM EditVM
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
        public ObservableCollection<ProductVM> Products { get; set; }
        protected async override void GetData()
        {
            ThrobberVisible = Visibility.Visible;
            ObservableCollection<ProductVM> _products = new ObservableCollection<ProductVM>();
            var products = await (from p in db.Products
                                   orderby p.ProductShortName
                                   select p).ToListAsync();
            foreach (Product prod in products)
            {
                _products.Add(new ProductVM { IsNew = false, TheEntity = prod });
            }
            Products = _products;
            RaisePropertyChanged("Products");
            ThrobberVisible = Visibility.Collapsed;
        }
        protected override void EditCurrent()
        {
            EditVM = SelectedProduct;
            IsInEditMode = true;
        }
        protected override void InsertNew()
        {
            EditVM = new ProductVM();
            IsInEditMode = true;
        }
        protected override void CommitUpdates()
        {
            if (EditVM.TheEntity.IsValid())
            {
                if (EditVM.IsNew)
                {
                    EditVM.IsNew = false;
                    Products.Add(EditVM);
                    db.Products.Add(EditVM.TheEntity);
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
        protected override void Quit()
        {
            if (!EditVM.IsNew)
            {
                ReFocusRow();
            }
        }
        protected async void ReFocusRow(bool withReload = true)
        {
            int id = EditVM.TheEntity.Id;
            SelectedProduct = null;
            await db.Entry(EditVM.TheEntity).ReloadAsync();
            await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
            {
                SelectedProduct = Products.Where(e => e.TheEntity.Id == id).FirstOrDefault();
                SelectedProduct.TheEntity = SelectedProduct.TheEntity;
                SelectedProduct.TheEntity.ClearErrors();
            }), DispatcherPriority.ContextIdle);
            IsInEditMode = false;
        }
        protected override void DeleteCurrent()
        {
            UserMessage msg = new UserMessage();
            if (SelectedProduct != null)
            {
                int NumLines = NumberOfOrderLines();
                if (NumLines > 0)
                {
                    msg.Message = string.Format("Cannot delete - there are {0} Order Lines for this Product", NumLines);
                }
                else
                {
                    db.Products.Remove(SelectedProduct.TheEntity);
                    Products.Remove(SelectedProduct);
                    RaisePropertyChanged("Products");
                    msg.Message = "Deleted";
                }
            }
            else
            {
                msg.Message = "No Product selected to delete";
            }
            Messenger.Default.Send<UserMessage>(msg);
        }
        private int NumberOfOrderLines()
        {
            var prod = db.Products.Find(SelectedProduct.TheEntity.Id);
            // Count how many Order Lines there are for the Product
            int linesCount = db.Entry(prod)
                               .Collection(p => p.OrderLines)
                               .Query()
                               .Count();
            return linesCount;
        }
        public ProductsViewModel()
            : base()
        {
        }
    }
}
