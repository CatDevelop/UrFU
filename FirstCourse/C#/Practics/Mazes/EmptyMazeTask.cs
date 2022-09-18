namespace Mazes
{
	public static class EmptyMazeTask
	{
		/// <param name="robot">Объект робота</param>
		/// <param name="stepCount">Количество шагов</param>
		/// <returns>Двигает робота вправо на stepCount шагов</returns>
		private static void MoveRight(Robot robot, int stepCount)
		{
			for(var i=0; i<stepCount; i++)
				robot.MoveTo(Direction.Right);
		}
		
		/// <param name="robot">Объект робота</param>
		/// <param name="stepCount">Количество шагов</param>
		/// <returns>Двигает робота вниз на stepCount шагов</returns>
		private static void MoveDown(Robot robot, int stepCount)
		{
			for(var i=0; i<stepCount; i++)
				robot.MoveTo(Direction.Down);
		}
		
		public static void MoveOut(Robot robot, int width, int height)
		{
			MoveDown(robot,height - 2 - robot.Y);
			MoveRight(robot, width - 2 - robot.X);
		}
	}
}