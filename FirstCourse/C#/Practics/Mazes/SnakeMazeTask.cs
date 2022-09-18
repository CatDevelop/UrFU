namespace Mazes
{
	public static class SnakeMazeTask
	{
		/// <param name="robot">Объект робота</param>
		/// <param name="stepCount">Количество шагов</param>
		/// <param name="moveDirection">Направление движения</param>
		/// <returns>Двигает робота на stepCount шагов в moveDirection сторону,
		/// если он ещё не дошёл до конца</returns>
		private static void MoveRobot(Robot robot, int stepCount, Direction moveDirection)
		{
			if (!robot.Finished)
			{
				for (var i = 0; i < stepCount; i++)
					robot.MoveTo(moveDirection);
			}
		}
		
		public static void MoveOut(Robot robot, int width, int height)
		{
			while (!robot.Finished)
			{
				MoveRobot(robot, width - 3, Direction.Right);
				MoveRobot(robot, 2, Direction.Down);
				MoveRobot(robot, width - 3, Direction.Left);
				MoveRobot(robot, 2, Direction.Down);
			}
		}
	}
}