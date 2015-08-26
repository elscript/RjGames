using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitBehavior
{
	public interface ILogic
	{
		IUnit Unit { get; }
		void Update();
	}
}
