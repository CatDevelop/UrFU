namespace Mazes
{
	public static class DiagonalMazeTask
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
		
		/// <param name="robot">Объект робота</param>
		/// <param name="firstSideStepCount">Количество шагов в первую сторону</param>
		/// <param name="secondSideStepCount">Количество шагов во вторую сторону</param>
		/// <param name="firstMoveDirection">Направление движения, в которое робот будет двигаться сначала</param>
		/// <returns>Двигает робота по диагонали каждый раз на firstSideStepCount в firstMoveDirection сторону
		/// и шаг в другую, пока не пройдёт secondSideStepCount шагов во вторую сторону</returns>
		private static void GoDiagonalMaze(Robot robot, int firstSideStepCount, 
			int secondSideStepCount, Direction firstMoveDirection)
		{
			for (var i=0; i < secondSideStepCount; i++)
			{
				MoveRobot(robot, firstSideStepCount, firstMoveDirection);
				MoveRobot(robot, 1, firstMoveDirection == Direction.Down ? Direction.Right : Direction.Down);
			}
		}
		
		public static void MoveOut(Robot robot, int width, int height)
		{
			if (width > height)
				GoDiagonalMaze(robot, width / (height - 1), 
					height - 2, Direction.Right);
			else
				GoDiagonalMaze(robot, (height - 3) / (width - 2),
					width - 2, Direction.Down);
		}
	}
}