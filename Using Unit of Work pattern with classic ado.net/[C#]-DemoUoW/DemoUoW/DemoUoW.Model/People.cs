
using System.ComponentModel;

namespace DemoUoW.Model
{
    public class People : BaseDb
    {
        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Endereço")]
        public string Address { get; set; }

        [DisplayName("Idade")]
        public int Age { get; set; }
    }
}
