using BeeIt.TowerDefense.Enemies;
using BeeIt.TowerDefense.Towers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BeeIt.TowerDefense.Graphics
{
	internal class Draw : IDisposable
	{
		private const int TILE_SIZE = 64;
		private readonly string _picturesPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\TowerDefense\Graphics\Sprites\";
		private readonly Dictionary<string, Image> _sprites;
		private Bitmap _currentBuffer;

		private readonly Dictionary<string, string> _enemySprite = new Dictionary<string, string>
		{
			{ "Enemy", "Red" },
			{ "ArmoredEnemy", "Red_armor" },
			{ "SlowingEnemy", "Orange" },
			{ "StoppingEnemy", "Blue" },
			{ "ShakyEnemy", "Green" },
			{ "YellowEnemy", "Yellow" },
			{ "BrownEnemy", "Brown" }
		};

		internal Draw(Board board)
		{
			_currentBuffer = new Bitmap(board.Width * TILE_SIZE, board.Height * TILE_SIZE);
			_sprites = LoadSprites(_picturesPath);
		}

		public void DrawBoard(Board board)
		{
			for (var row = 0; row < board.Height; row++)
			{
				for (var column = 0; column < board.Width; column++)
				{
					var tile = board.GetSpriteType(column, row);
					DrawPicture(column, row, $"Ground_{tile}.png");
				}
			}
		}

		public void DrawEnemy(Enemy enemy)
		{
			var enemyType = enemy.GetType().Name;
			var enemyColor = _enemySprite.TryGetValue(enemyType, out var color) ? color : "Red";
			var armorLevel = GetArmor(enemy);

			if (armorLevel == "" && enemyColor.Contains("armor"))
			{
				enemyColor = enemyColor.Replace("_armor", "");
			}

			DrawPicture(enemy.Position.X, enemy.Position.Y, $"Enemy_{enemyColor}{armorLevel}.png", 0);
		}

		public void DrawTower(Tower tower)
		{
			DrawPicture(tower.Position.X, tower.Position.Y, "Tower.png", tower.Angle);

			if (tower.HitTarget != null)
			{
				DrawPicture(tower.HitTarget.X, tower.HitTarget.Y, "Explosion.png", 0);
			}
		}

		public void Refresh()
		{
			using (var g = System.Drawing.Graphics.FromHwnd(GetConsoleWindow()))
			{
				g.DrawImage(_currentBuffer, new Rectangle(0, 0, 10 * TILE_SIZE, 10 * TILE_SIZE));
			}
			_currentBuffer = new Bitmap(10 * TILE_SIZE, 10 * TILE_SIZE);
		}

		public void Dispose()
		{
			_currentBuffer?.Dispose();
		}

		private string GetArmor(Enemy enemy)
		{
			if (enemy.GetType().Name == "ArmoredEnemy" && enemy.GetType().GetProperty("Armor") != null)
			{
				return ((int)enemy.GetType().GetProperty("Armor").GetValue(enemy, null)).ToString();
			}

			return "";
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetConsoleWindow();

		private void DrawPicture(double x, double y, string spriteName, double rotationAngle = 0)
		{
			using (var g = System.Drawing.Graphics.FromImage(_currentBuffer))
			{
				var sprite = _sprites[spriteName];
				g.TranslateTransform((float)x * TILE_SIZE, (float)y * TILE_SIZE);
				g.TranslateTransform((float)TILE_SIZE / 2, (float)TILE_SIZE / 2);
				g.RotateTransform((float)rotationAngle);
				g.InterpolationMode = InterpolationMode.NearestNeighbor;

				var imageRect = new Rectangle(-TILE_SIZE / 2, -TILE_SIZE / 2, TILE_SIZE, TILE_SIZE);
				g.DrawImage(sprite, imageRect);
			}
		}

		private Dictionary<string, Image> LoadSprites(string path)
		{
			var paths = Directory.GetFileSystemEntries(path, "*.png");
			var sprites = new Dictionary<string, Image>();

			foreach (var spritePath in paths)
			{
				using (var stream = new FileStream(spritePath, FileMode.Open, FileAccess.Read))
				{
					var image = Image.FromStream(stream);
					var filename = new FileInfo(spritePath).Name;
					sprites.Add(filename, image);
				}
			}

			return sprites;
		}
	}
}