using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitBehavior
{
	abstract class AUnit : IUnit
	{
		private int _x;
		private int _y;
		private int _tileX;
		private int _tileY;
		private readonly Scene _scene;

		/// <summary>
		/// Словарь параметров
		/// </summary>
		protected Dictionary<string, int> Params;

		/// <summary>
		/// Конструктор юнита
		/// </summary>
		/// <param name="scene">Сцена, в которую помещается юнит</param>
		protected AUnit(Scene scene)
		{
			_scene = scene;
			Params = new Dictionary<string, int>();
			this.OnInit();
		}
		
		public int GetX()
		{
			return _x;
		}

		public int GetY()
		{
			return _x;
		}

		public int GetTileX()
		{
			throw new NotImplementedException();
		}

		public int GetTileY()
		{
			throw new NotImplementedException();
		}

		public bool MoveToTile(int targettilex, int targettiley)
		{
			var result = false;
			//TODO логику движения
			result = true;

			if (result)
				State = UnitState.Moving;

			return result;
		}

		public bool CanMoveToTile(int targettilex, int targettiley)
		{
			throw new NotImplementedException();
		}

		public void ReceiveDamage(int damage)
		{
			throw new NotImplementedException();
		}

		public int GetHealth()
		{
			throw new NotImplementedException();
		}

		public void Die()
		{
			throw new NotImplementedException();
		}

		public abstract void PlayAnimation(string state, int offset, bool loop);

		public abstract void StopAnimation();

		public Scene GetScene()
		{
			return _scene;
		}

		public int GetId()
		{
			throw new NotImplementedException();
		}

		public int GetParam(string type)
		{
			throw new NotImplementedException();
		}

		public void SetParam(string type, int value)
		{
			throw new NotImplementedException();
		}

		public abstract void OnInit();

		public abstract void OnThink();

		public abstract void OnMoving();

		public abstract void OnDie();

		public UnitState State { get; private set; }
	}
}
