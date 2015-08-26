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
		private int _health;
		private int _id;
		private KeyValuePair<int, int> _unitSize;

		public UnitState State { get; private set; }

		public KeyValuePair<int, int> UnitSize
		{
			get { return _unitSize; }
			private set
			{
				// минимальный размер не может быть меньше 1
				if (value.Key < 1 || value.Value < 1)
					_unitSize = new KeyValuePair<int, int>(1, 1);
				else
					_unitSize = value;
			}
		}

		/// <summary>
		/// Словарь параметров
		/// </summary>
		private Dictionary<string, int> _params;

		/// <summary>
		/// Конструктор юнита
		/// </summary>
		/// <param name="scene">Сцена, в которую помещается юнит</param>
		/// <param name="unitId">Уникальный идентификатор юнита</param>
		/// <param name="parameters">Параметры</param>
		/// <param name="x">X-координата внутри тайла</param>
		/// <param name="y">Y-координата внутри тайла</param>
		/// <param name="tileX">X-координата стартового тайла</param>
		/// <param name="tileY">Y-координата стартового тайла</param>
		/// <param name="unitSize">KeyValuePair, с размером по x и по y соответственно</param>
		protected AUnit(Scene scene, int unitId, Dictionary<string, int> parameters, int x, int y, int tileX, int tileY, KeyValuePair<int, int> unitSize)
		{
			_scene = scene;
			_params = parameters;
			_id = unitId;
			UnitSize = unitSize;
			this.OnInit();
		}

		public ILogic Logic { get; private set; }

		public int GetX()
		{
			return _x;
		}

		public int GetY()
		{
			return _y;
		}

		public int GetTileX()
		{
			return _tileX;
		}

		public int GetTileY()
		{
			return _tileY;
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
			// Проверяем, что тайл соседний (условие задачи)
			if (Math.Abs(_tileX - targettilex) == 1 && Math.Abs(_tileY - targettiley) == 1)
			{
				//TODO Проверяем нет ли барьеров на пути
				//if ()
			}
			return false;
		}

		public void ReceiveDamage(int damage)
		{
			var resultHP = _health - damage;
			if (resultHP < 0)
			{
				_health = 0;
				State = UnitState.Die;
			}
		}

		public int GetHealth()
		{
			return _health;
		}

		public void Die()
		{
			State = UnitState.Die;
		}

		public Scene GetScene()
		{
			return _scene;
		}

		public int GetId()
		{
			return _id;
		}

		public int GetParam(string type)
		{
			int value;
			if (!_params.TryGetValue(type, out value))
				return -1;
			else
				return value;
		}

		public void SetParam(string type, int value)
		{
			if (_params.ContainsKey(type))
				_params[type] = value;
			else
				_params.Add(type, value);
		}

		public abstract void OnInit();

		public abstract void OnThink();

		public abstract void OnMoving();

		public abstract void OnDie();

		public abstract void PlayAnimation(string state, int offset, bool loop);

		public abstract void StopAnimation();

	}
}
