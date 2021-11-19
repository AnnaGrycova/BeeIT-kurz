using System;
using System.Collections.Generic;
using BeeIt.TowerDefence.Enemies;
using BeeIt.TowerDefense.Enemies;
using BeeIt.TowerDefense.Graphics;
using BeeIt.TowerDefense.Math;
using BeeIt.TowerDefense.Towers;

namespace BeeIt.TowerDefense
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			Console.BufferWidth = Console.WindowWidth = 70;
			Console.BufferHeight = Console.WindowHeight = 39;
			Console.CursorVisible = false;

			MainLoop();
		}

		private static void MainLoop()
		{
			while (true)
			{

				var board = new Board();
				var draw = new Draw(board);
				var path = new Path();

				var enemies = new List<Enemy>
				{
					//// A. Obycejna postavicka
					//new Enemy(path, 0.05, 5),
					//new Enemy(path, 0.06, 5),
					//new Enemy(path, 0.07, 5),

					//// B. Obrnena postavicka
					//new ArmoredEnemy(path, 0.017, 5, 3),
     //               new ArmoredEnemy(path, 0.025, 5, 3),
     //               new ArmoredEnemy(path, 0.033, 5, 3),

					//// C. Zpomalující postavička
					//new SlowingEnemy(path, 0.11, 5),
     //               new SlowingEnemy(path, 0.12, 5),
     //               new SlowingEnemy(path, 0.13, 5),

					//// D. Třesoucí se postavička
					//new ShakyEnemy(path, 0.037, 4),
     //               new ShakyEnemy(path, 0.045, 4),
     //               new ShakyEnemy(path, 0.055, 4),

					// D. Zastavující se postavička
					new StoppingEnemy(path, 0.037, 4),
                    new StoppingEnemy(path, 0.045, 4),
                    new StoppingEnemy(path, 0.055, 4),
                };

				var towers = new List<Tower>
				{
					new Tower(new Vector(6, 3), 1),
					new Tower(new Vector(1, 2), 1),
					new Tower(new Vector(6, 7), 1),
					new Tower(new Vector(4, 5), 1),
				};


				for (var i = 0; i < 500; i++)
				{
					draw.DrawBoard(board);

					foreach (var enemy in enemies)
					{
						if (enemy.Alive)
						{
							enemy.Move();
							draw.DrawEnemy(enemy);
						}
					}

					foreach (var tower in towers)
					{
						tower.LocateEnemies(enemies);
						draw.DrawTower(tower);
					}

					draw.Refresh();
				}
			}
		}
	}
}
