namespace Mazes
{
	public static class EmptyMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			MoveRobot(robot,height - 2 - robot.Y, Direction.Down);
			MoveRobot(robot, width - 2 - robot.X, Direction.Right);
		}
		
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
	}
}