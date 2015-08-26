using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UnitBehavior
{
	public class UnitLogic : ILogic
	{
		public IUnit Unit { get; private set; }

		public UnitLogic(IUnit unit)
		{
			Unit = unit;
		}

		public void Update()
		{
			switch (Unit.State)
			{
				case UnitState.Idle:
					Unit.OnThink(); 
					break;
				case UnitState.Moving:
					Unit.OnMoving(); 
					break;
				case UnitState.Die:
					Unit.OnDie(); 
					break;
				default:
					break;
			}
		}
	}
}
