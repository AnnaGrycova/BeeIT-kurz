using System.Collections.Generic;
using System.Linq;

namespace BeeIt.TowerDefense.Math
{
	internal class Path
	{
		class ClosestPoint
		{
			public int PointIndex { get; }
			public double Distance { get; }

			public ClosestPoint(int index, double distance)
			{
				PointIndex = index;
				Distance = distance;
			}
		}

		private const double DISTANCE_EPS = 0.05;

		private readonly IList<Vector> _pathList = new List<Vector>
		{
			new Vector(7, 0),
			new Vector(7, 1),
			new Vector(7, 2),
			new Vector(7, 3),
			new Vector(7, 4),
			new Vector(6, 4),
			new Vector(5, 4),
			new Vector(5, 3),
			new Vector(5, 2),
			new Vector(5, 1),
			new Vector(4, 1),
			new Vector(3, 1),
			new Vector(2, 1),
			new Vector(1, 1),
			new Vector(0, 1),
			new Vector(0, 2),
			new Vector(0, 3),
			new Vector(1, 3),
			new Vector(2, 3),
			new Vector(3, 3),
			new Vector(3, 4),
			new Vector(3, 5),
			new Vector(3, 6),
			new Vector(4, 6),
			new Vector(5, 6),
			new Vector(6, 6),
			new Vector(7, 6),
			new Vector(7, 7),
			new Vector(7, 8),
			new Vector(7, 9),
			new Vector(7, 10),
		};


		public Checkpoint GetStartCheckpoint()
		{
			return new Checkpoint(_pathList.First(), 0);
		}

		public Checkpoint GetFinishPoint()
		{
			return new Checkpoint(_pathList.Last(), _pathList.Count - 1);
		}

		public Checkpoint GetCurrentCheckpoint(Vector enemyPosition, Checkpoint currentCheckpoint)
		{
			var closestPoint = GetClosestPoint(enemyPosition, currentCheckpoint.Index);
			var closestPointIndex = closestPoint.PointIndex;
			var finished = false;

			if (closestPoint.Distance < DISTANCE_EPS && closestPointIndex < _pathList.Count)
			{
				if (closestPointIndex == _pathList.Count - 1)
				{
					finished = true;
				}
				else
				{
					closestPointIndex++;
				}
			}

			return new Checkpoint(_pathList[closestPointIndex], closestPointIndex, finished);
		}

		private ClosestPoint GetClosestPoint(Vector position, int currentCheckpointIndex)
		{
			var minDistance = null as double?;
			var minIndex = 0;

			for (var i = currentCheckpointIndex; i < _pathList.Count; i++)
			{
				var point = _pathList[i];
				var distance = position.Distance(point);
				if (minDistance == null || distance < minDistance)
				{
					minDistance = distance;
					minIndex = i;
				}
			}

			return new ClosestPoint(minIndex, minDistance.Value);
		}
	}
}