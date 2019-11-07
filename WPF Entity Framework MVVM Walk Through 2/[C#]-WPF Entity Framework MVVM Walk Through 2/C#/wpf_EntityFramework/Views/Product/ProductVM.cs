using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support;
using wpf_EntityFramework.EntityData;

namespace wpf_EntityFramework
{
    public class ProductVM : VMBase
    {
        public Product TheEntity
        {
            get
            {
                return (Product)base.theEntity;
            }
            set
            {
                theEntity = value;
                RaisePropertyChanged();
            }
        }
        public ProductVM()
        {
            // Initialise the entity or inserts will fail
            TheEntity = new Product();
            TheEntity.MetaSetUp();
        }

    }
}
