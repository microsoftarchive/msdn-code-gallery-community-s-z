using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;

namespace PEJL_WPF_Examples.Helpers
{
    interface IBullet
    {
        BulletDecorator Source { set; }
    }
}
