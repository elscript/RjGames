using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitBehavior
{
	public interface IUnit
	{
		ILogic Logic { get; }

		/// <summary>
		/// Возвращает X координату юнита, единицы измерения - одна сотая тайла
		/// </summary>
		/// <returns>X координата юнита</returns>
		int GetX();

		/// <summary>
		/// Возвращает Y координату юнита, единицы измерения - одна сотая тайла
		/// </summary>
		/// <returns>Y координата юнита</returns>
		int GetY();

		/// <summary>
		/// Возвращает X координату текущего тайла юнита
		/// </summary>
		/// <returns>X координата тайла</returns>
		int GetTileX();

		/// <summary>
		/// Возвращает Y координату текущего тайла юнита
		/// </summary>
		/// <returns>Y координата тайла</returns>
		int GetTileY();

		/// <summary>
		/// Начинает движение юнита в указанный тайл, 
		/// если путь построить нельзя, возвращает false. 
		/// Конечная точка может быть любой, 
		/// однако как только юнит пройдет один тайл, 
		/// движение прервется и будет сделан переход в состояние Idle
		/// </summary>
		/// <param name="targettilex"></param>
		/// <param name="targettiley"></param>
		/// <returns>Успешность перемещения юнита</returns>
		bool MoveToTile(int targettilex, int targettiley);

		/// <summary>
		/// Возвращает true если есть путь до тайла
		/// </summary>
		/// <param name="targettilex"></param>
		/// <param name="targettiley"></param>
		/// <returns>Возможность перемещения в указанный тайл</returns>
		bool CanMoveToTile(int targettilex, int targettiley);

		/// <summary>
		/// Cнижает здоровье юнита при получении урона
		/// </summary>
		/// <param name="damage"></param>
		void ReceiveDamage(int damage);

		/// <summary>
		/// Возвращает текущее здоровье юнита
		/// </summary>
		/// <returns></returns>
		int GetHealth();

		/// <summary>
		/// Убрать юнит со сцены
		/// </summary>
		void Die();

		/// <summary>
		/// Hачать проигрывание анимации
		/// </summary>
		/// <param name="state">moving, attack_1, attack_2, idle, die</param>
		/// <param name="offset"></param>
		/// <param name="loop"></param>
		void PlayAnimation(string state, int offset, bool loop);

		/// <summary>
		/// Останавливает проигрывание анимации
		/// </summary>
		void StopAnimation();

		/// <summary>
		/// Возвращает сцену
		/// </summary>
		/// <returns>Сцена, в которой участвует юнит</returns>
		Scene GetScene();

		/// <summary>
		/// Возвращает глобальный Id юнита
		/// </summary>
		/// <returns>Id юнита</returns>
		int GetId();

		/// <summary>
		/// Возвращает значение параметра из словаря юнита
		/// или -1 если такого параметра нет
		/// </summary>
		/// <param name="type"></param>
		/// <returns>Параметр указанного типа</returns>
		int GetParam(string type);

		/// <summary>
		/// Записывает значение параметра в словарь юнита
		/// </summary>
		/// <param name="type"></param>
		/// <param name="value"></param>
		void SetParam(string type, int value);

		/// <summary>
		/// Инициализация юнита
		/// </summary>
		void OnInit();

		/// <summary>
		/// Раздумие
		/// </summary>
		void OnThink();

		/// <summary>
		/// Движение
		/// </summary>
		void OnMoving();

		/// <summary>
		/// Уничтожение
		/// </summary>
		void OnDie();

		/// <summary>
		/// Состояние юнита
		/// </summary>
		UnitState State { get; }

		/// <summary>
		/// Размер юнита (x, y)
		/// </summary>
		KeyValuePair<int, int> UnitSize { get; } 
	}
}
