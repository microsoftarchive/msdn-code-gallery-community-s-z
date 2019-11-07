using System.Collections.Generic;
using System.Windows.Forms;

namespace Sample1
{
    public static class LanguageExtenstions
    {
        /// <summary>
        /// Used to case our BindingSource in Form1 to the proper type
        /// so we don't have to in the form. Some may like this, some
        /// may not, everyone is different.
        /// </summary>
        /// <param name="pSender"></param>
        /// <returns></returns>
        public static List<Person> PersonList(this BindingSource pSender)
        {
            return (List<Person>)pSender.DataSource;
        }
        public static Person Person(this BindingSource pSender)
        {
            return pSender.Current != null ? (Person)pSender.Current : null;
        }
        public static bool CurrentIsPerson(this BindingSource pSender)
        {
            return pSender.Current != null;
        }
    }
}
