using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UnitBehavior
{
	public class Scene
	{
		private static long _tick = 0;
		private Timer _timer;
		private int _delay;
		private int _period;
		private List<IUnit> _units;
		private List<BarrierItem> _barriers;

		public int TileSize { get; private set; }

		/// <summary>
		/// Конструктор сцены
		/// </summary>
		/// <param name="x">Размер в тайлах по x</param>
		/// <param name="y">Размер в тайлах по y</param>
		/// <param name="tileSize">Размер тайла</param>
		/// <param name="delay">Задержка таймера</param>
		/// <param name="period">Период таймера</param>
		public Scene(int x, int y, int tileSize, int delay, int period)
		{
			X = x;
			Y = y;
			_units = new List<IUnit>();
			_barriers = new List<BarrierItem>();
		}

		/// <summary>
		/// Запускает сцену
		/// </summary>
		public void Start()
		{
			_timer = new Timer(Tick, null, _delay, _period);
		}

		/// <summary>
		/// Размер сцены в тайлах по X
		/// </summary>
		public int X { get; private set; }

		/// <summary>
		/// Размер сцены в тайлах по Y
		/// </summary>
		public int Y { get; private set; }
		
		/// <summary>
		/// Возвращает текущий тик
		/// </summary>
		/// <returns>Текущий тик</returns>
		private long GetTick()
		{
			return _tick;
		}

		/// <summary>
		/// Добавляет юнит на сцену
		/// </summary>
		/// <param name="newUnit"></param>
		public void AddUnit(IUnit newUnit)
		{
			_units.Add(newUnit);
		}

		/// <summary>
		/// Возвращает ближайшего вражеского юнита или null, если их нет
		/// </summary>
		/// <param name="unit"></param>
		/// <returns></returns>
		IUnit FindNearestEnemyUnit(IUnit unit)
		{
			// Ищем первый попавшийся юнит, находящийся на смежном тайле или null, если таких нет
			return _units.FirstOrDefault(currUnit => Math.Abs(currUnit.GetTileX() - unit.GetTileX()) == 1 
				&& Math.Abs(currUnit.GetTileY() - unit.GetTileY()) == 1);
		}

		/// <summary>
		/// Возвращает квадрат расстояния между точками
		/// </summary>
		/// <param name="x1">Координата х первой точки</param>
		/// <param name="y1">Координата y первой точки</param>
		/// <param name="x2">Координата х второй точки</param>
		/// <param name="y2">Координата y второй точки</param>
		/// <returns>Квадрат расстояния между точками</returns>
		int GetQuadDistance(int x1, int y1, int x2, int y2)
		{
			return (int) (Math.Sqrt(x2 - x1) + Math.Sqrt(y2 - y1));
		}

		/// <summary>
		/// Определяет есть ли прямая линия огня от юнита к юниту
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns>Наличие прямой линии</returns>
		bool CanShoot(IUnit from, IUnit to)
		{
			// Сперва проверяем нет ли юнитов на линии
			foreach (var unit in _units)
			{
				
			}

			// Затем нет ли преград на линии
			foreach (var unit in _units)
			{

			}

			return true;
		}

		/// <summary>
		/// Возвращает список всех вражеских юнитов
		/// </summary>
		/// <param name="unit"></param>
		/// <returns>Список вражеский юнитов</returns>
		IEnumerable<IUnit> GetEnemyUnits(IUnit unit)
		{
			return _units.Where(currUnit => currUnit != unit);
		}

		/// <summary>
		/// Осуществляет тик
		/// </summary>
		/// <param name="o">Необходимый для таймера параметр. 
		/// Оставлять null</param>
		private static void Tick(object o = null)
		{
			_tick++;
		}
	}

	/// <summary>
	/// Препятствие
	/// </summary>
	public class BarrierItem
	{
		private int _x;
		private int _y;
		private int _tileX;
		private int _tileY;

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
	}
}
