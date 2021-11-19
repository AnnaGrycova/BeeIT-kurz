using BeeIt.TowerDefense.Enemies;
using BeeIt.TowerDefense.Math;
using System.Collections.Generic;

namespace BeeIt.TowerDefense.Towers
{
	internal class Tower
	{
		private class ClosestTarget
		{
			public Enemy Enemy { get; set; }
			public double Distance { get; set; }
		}

		private const double TARGET_DISTANCE = 2.0;
		private const int RELOAD_TIME = 30;
		private const int SHOW_HITMARK_TIME = 5;
		private readonly Vector UpVector = new Vector(0, -1);
		private readonly int _hitValue;
		private int _reload_state;
		private Enemy _hittedEnemy;

		public Vector Position { get; }
		public double Angle { get; private set; }
		public Vector HitTarget { get; private set; }

		public Tower(Vector position, int hitValue)
		{
			Position = position;
			_hitValue = hitValue;
		}

		public void LocateEnemies(IEnumerable<Enemy> enemies)
		{
			if (_reload_state > 0)
			{
				_reload_state--;
			}
			var closestTarget = GetClosestEnemy(enemies);
			if (closestTarget != null && closestTarget.Distance < TARGET_DISTANCE)
			{
				var enemyVector = closestTarget.Enemy.Position - Position;
				var angle = UpVector.Angle(enemyVector);
				if (enemyVector.X <= 0)
				{
					angle = 360 - angle;
				}
				Angle = angle;


				HitTarget = ShowHitmark() ? _hittedEnemy?.Position : null;
				if (ReadyToFire())
				{
					_reload_state = RELOAD_TIME;
					closestTarget.Enemy.Hit(_hitValue);
					_hittedEnemy = closestTarget.Enemy;
				}
			}
			else
			{
				if (!ShowHitmark())
				{
					HitTarget = null;
				}
			}
		}

		private ClosestTarget GetClosestEnemy(IEnumerable<Enemy> enemies)
		{
			var minDistance = null as double?;
			var closestEnemy = null as Enemy;

			foreach (var enemy in enemies)
			{
				if (enemy.Alive)
				{
					var distance = Position.Distance(enemy.Position);
					if (minDistance == null || distance < minDistance)
					{
						minDistance = distance;
						closestEnemy = enemy;
					}
				}
			}

			if (closestEnemy != null)
			{
				return new ClosestTarget
				{
					Enemy = closestEnemy,
					Distance = minDistance ?? 0,
				};
			}
			return null;
		}

		private bool ReadyToFire()
		{
			return _reload_state == 0;
		}

		private bool ShowHitmark()
		{
			return _reload_state > RELOAD_TIME - SHOW_HITMARK_TIME;
		}
	}
}