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

		/// <summary>
		/// Конструктор сцены
		/// </summary>
		/// <param name="x">Размер в тайлах по x</param>
		/// <param name="y">Размер в тайлах по y</param>
		/// <param name="delay">Задержка перед вызовом таймера сцены</param>
		/// <param name="period">Период таймера сцены</param>
		public Scene(int x, int y, int delay, int period)
		{
			X = x;
			Y = y;
			_units = new List<IUnit>();
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
		AUnit FindNearestEnemyUnit(IUnit unit)
		{
			return null;
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
			return 0;
		}

		/// <summary>
		/// Определяет есть ли прямая линия огня от юнита к юниту
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns>Наличие прямой линии</returns>
		bool CanShoot(IUnit from, IUnit to)
		{
			return false;
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
}
