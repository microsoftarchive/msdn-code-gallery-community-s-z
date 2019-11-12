using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;
using WpfEfDAL;

namespace WpfEfSampleApp
{
    public abstract class MyBaseCollection<T> : ObservableCollection<T>
    {
        private Boolean _isLoading = false;
        public Boolean IsLoading
        {
            get {
                return _isLoading;
            }
        }

        public Boolean HasChanges
        {
            get {
                IEnumerable<System.Data.Objects.ObjectStateEntry> changed =
                        _context.ObjectStateManager.GetObjectStateEntries(  EntityState.Added |
                                                                            EntityState.Deleted |
                                                                            EntityState.Modified);

                IEnumerable<System.Data.Objects.ObjectStateEntry> entityChanged = from o in changed
                                                                     where (o.Entity is T)
                                                                     select o;

                
                return ((entityChanged != null) && (entityChanged.Count() > 0));
            }
        }

        private OMSEntities _context;
        public OMSEntities Context
        {
            get {
                return _context;
            }
        }

        public MyBaseCollection(IEnumerable<T> query, OMSEntities context)
        {
            _isLoading = true;
            _context = context;
            foreach (T o in query)
            {
                this.Add(o);
            }
    
            _isLoading = false;
        }
    }
}
