using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWpfApp.Models
{
	public class SampleItem
	{
		private static int lastId = 0;

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate" )]
		public static int GetNewId() {
			SampleItem.lastId += 1;
			return SampleItem.lastId;
		}

		public SampleItem() {
			this.Id = SampleItem.GetNewId();
			this.Name = "New Item";
			this.Description = "";
		}

		public int Id { get; set; }
		public string Name { get; set; } 
		public string Description { get; set; }
	}
}
