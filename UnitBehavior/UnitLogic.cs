using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UnitBehavior
{
	class UnitLogic
	{
		private IUnit _unit;

		public UnitLogic(IUnit unit)
		{
			_unit = unit;
		}

		void Update()
		{
			switch (_unit.State)
			{
				case UnitState.Idle:
					_unit.OnThink(); 
					break;
				case UnitState.Moving:
					_unit.OnMoving(); 
					break;
				case UnitState.Die:
					_unit.OnDie(); 
					break;
				default:
					break;
			}
		}
	}
}
