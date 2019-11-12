using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Company.UI.Control
{
    public class ControlBase
        : WebControl
    {
        public Guid quId;

        public ControlBase()
        {
            quId = System.Guid.NewGuid();
        }
        
        public virtual string PrepareInitializeIMG()
        {
            return "";
        }

        public virtual string PrepareInitializeCSS()
        {
            return "";
        }

        public virtual string PrepareInitializeJS()
        {
            return "";
        }

        public virtual string ToHtml() 
        {
            return "";
        }

    }
}
