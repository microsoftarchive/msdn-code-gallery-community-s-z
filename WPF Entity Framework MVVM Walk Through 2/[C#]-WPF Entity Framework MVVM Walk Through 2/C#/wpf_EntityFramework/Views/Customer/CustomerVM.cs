using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support;
using wpf_EntityFramework.EntityData;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace wpf_EntityFramework
{
    public class CustomerVM : VMBase
    {
        public Customer TheEntity
        {
            get
            {
                return (Customer)base.theEntity;
            }
            set
            {
                theEntity = value;
                RaisePropertyChanged();
            }
        }
        
        public CustomerVM()
        {
            // Initialise the entity or inserts will fail
            TheEntity = new Customer();
            TheEntity.CreditLimit = 5000;
            TheEntity.Outstanding = 0;
            TheEntity.MetaSetUp();
        }
    }
}
