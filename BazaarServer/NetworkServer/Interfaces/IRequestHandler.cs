﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkServer.Interfaces
{
	public interface IRequestHandler
	{
		string Handle(string message);
	}
}
