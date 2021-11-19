using BeeIt.TowerDefense.Math;

namespace BeeIt.TowerDefense.Enemies
{
	//====================================================================================================================
	// A. Obyčejná základní postavička
	//====================================================================================================================
	internal class Enemy
	{
		private readonly Path _path;
		private Checkpoint _currentCheckpoint;
		private Vector position;
		private double speed;
		private int health;

		public Vector Position
		{
			get => position;
			protected set => position = value;
		}

		public double Speed
		{
			get => speed;
			protected set => speed = value;
		}

		public int Health
		{
			get => health;
			private set => health = value;
		}

		public bool Finished
		{
			get => _currentCheckpoint.Finish;
		}

		public virtual bool Alive
		{
			get => Health > 0;
		}

		public Enemy(Path path, double speed, int health)
		{
			_path = path;
			Speed = speed;
			_currentCheckpoint = _path.GetStartCheckpoint();
			Health = health;
			Position = _currentCheckpoint.Position;
		}

		public virtual void Move()
		{
			if (!Finished && Alive)
			{
				_currentCheckpoint = _path.GetCurrentCheckpoint(Position, _currentCheckpoint);
				var direction = (_currentCheckpoint.Position - Position).Normalize();

				Position += direction * Speed;
			}
		}

		public virtual void Hit(int hitValue)
		{
			Health -= hitValue;
		}
	}
}