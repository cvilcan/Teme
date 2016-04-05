using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.PresentationModels
{
	[Serializable]
	public class Type
	{
		public int TypeID { get; set; }
		public string TypeName { get; set; }
	}
}
