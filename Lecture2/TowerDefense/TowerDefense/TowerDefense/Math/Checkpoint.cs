namespace BeeIt.TowerDefense.Math
{
	internal class Checkpoint
	{
		public Vector Position { get; }
		public int Index { get; }
		public bool Finish { get; }

		public Checkpoint(Vector position, int index, bool finish = false)
		{
			Position = position;
			Index = index;
			Finish = finish;
		}
	}
}