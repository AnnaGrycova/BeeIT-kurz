namespace BeeIt.TowerDefense.Graphics
{
	internal class Board
	{
		public int Width = 10;
		public int Height = 10;
		private SpriteType[][] Sprites { get; }

		public Board()
		{
			Sprites = new[]
			{
				new[] { SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Up_Down,     SpriteType.Grass,   SpriteType.Grass, },
				new[] { SpriteType.Down_Right,  SpriteType.Left_Right,  SpriteType.Left_Right,  SpriteType.Left_Right,  SpriteType.Left_Right,  SpriteType.Down_Left,   SpriteType.Grass,       SpriteType.Up_Down,     SpriteType.Grass,   SpriteType.Grass, },
				new[] { SpriteType.Up_Down,     SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Up_Down,     SpriteType.Grass,       SpriteType.Up_Down,     SpriteType.Grass,   SpriteType.Grass, },
				new[] { SpriteType.Up_Right,    SpriteType.Left_Right,  SpriteType.Left_Right,  SpriteType.Down_Left,   SpriteType.Grass,       SpriteType.Up_Down,     SpriteType.Grass,       SpriteType.Up_Down,     SpriteType.Grass,   SpriteType.Grass, },
				new[] { SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Up_Down,     SpriteType.Grass,       SpriteType.Up_Right,    SpriteType.Left_Right,  SpriteType.Up_Left,     SpriteType.Grass,   SpriteType.Grass, },
				new[] { SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Up_Down,     SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,   SpriteType.Grass, },
				new[] { SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Up_Right,    SpriteType.Left_Right,  SpriteType.Left_Right,  SpriteType.Left_Right,  SpriteType.Down_Left,   SpriteType.Grass,   SpriteType.Grass, },
				new[] { SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Up_Down,     SpriteType.Grass,   SpriteType.Grass, },
				new[] { SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Up_Down,     SpriteType.Grass,   SpriteType.Grass, },
				new[] { SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Grass,       SpriteType.Up_Down,     SpriteType.Grass,   SpriteType.Grass, },
			};
		}

		public SpriteType GetSpriteType(int x, int y)
		{
			return Sprites[y][x];
		}
	}
}