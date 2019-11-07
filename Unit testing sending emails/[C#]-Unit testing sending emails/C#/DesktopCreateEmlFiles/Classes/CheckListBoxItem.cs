using System;

namespace DesktopCreateEmlFiles
{
    [Serializable]
    public class CheckListBoxItem
    {
        public string EmailAddress { get; set; }
        public bool Checked { get; set; }
        public override string ToString()
        {
            return EmailAddress;
        }

        internal object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
