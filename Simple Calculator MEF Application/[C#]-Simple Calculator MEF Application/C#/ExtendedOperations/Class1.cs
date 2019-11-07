using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace ExtendedOperations {

    [Export(typeof(SimpleCalculator3.IOperation))]
    [ExportMetadata("Symbol", '%')]
    public class Mod : SimpleCalculator3.IOperation
    {
        public int Operate(int left, int right)
        {
            return left % right;
        }
    }

}
