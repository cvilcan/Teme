using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
	public static class WinformsSession
	{
		public static Dictionary<string, Object> dictionary { get; set; }

		static WinformsSession()
		{
			dictionary = new Dictionary<string, object>();
		}
	}
}
