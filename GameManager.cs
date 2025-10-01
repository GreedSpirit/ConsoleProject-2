using System;
using System.Diagnostics;


namespace Console_Project
{
	public delegate void GameStartRoutine();
	public delegate void ProjectileRoutine();
	public class GameManager
	{
		public GameStartRoutine gameStartRoutine;
		public ProjectileRoutine projectileRoutine;
		public int worldX = 44; // 2로 나누었을 때 짝수가 되도록 설정하기
		public int worldY = 25;
		public float maxTimer = 20;
		public int difficulty;
		public int playerHealth = 3;
		public int score = 0;
		public int playerBomb = 1;

		static public Stopwatch stopWatch = new Stopwatch();

		static public GameManager instance = new GameManager();

		public void ClearScreenByFilling()
		{
			Console.SetCursorPosition(0, 0);
		}

		public bool GameOver()
		{
			return playerHealth > 0;
		}

		public bool HardGameClear()
		{
			return stopWatch.ElapsedMilliseconds < maxTimer * 1000;
		}

		public bool GameClear()
		{
			return score <= 100;
		}
		public void DrawGameClear()
		{
			Console.Clear();
			Console.SetWindowSize(200, 50);
			Console.WriteLine("   ####     ##     #    #   ######  \r\n  ##  ##   #  #    ##  ##   #       \r\n ##       #    #   # ## #   #       \r\n ##  ###  ######   # ## #   ####    \r\n ##   ##  #    #   #    #   #       \r\n  ## ###  #    #   #    #   #       \r\n   ### #  #    #   #    #   ######  \r\n                                    \r\n");  
			Console.WriteLine("   ####   #        ######     ##     #####      ##    \r\n  ##  ##  #        #         #  #    #    #     ##    \r\n ##       #        #        #    #   #    #     ##    \r\n ##       #        ####     ######   #####      ##    \r\n ##       #        #        #    #   #  #             \r\n  ##  ##  #        #        #    #   #   #      ##    \r\n   ####   ######   ######   #    #   #    #     ##    \r\n                                                      \r\n");
		}

		public void DrawGameOver()
		{
			Console.Clear();
			Console.SetWindowSize(200, 50);
			Console.WriteLine("   ####     ##     #    #   ######  \r\n  ##  ##   #  #    ##  ##   #       \r\n ##       #    #   # ## #   #       \r\n ##  ###  ######   # ## #   ####    \r\n ##   ##  #    #   #    #   #       \r\n  ## ###  #    #   #    #   #       \r\n   ### #  #    #   #    #   ######  \r\n                                    \r\n");
			Console.WriteLine("   ###    #    #   ######   #####                              \r\n  ## ##   #    #   #        #    #                             \r\n ##   ##  #    #   #        #    #                             \r\n ##   ##   #  #    ####     #####                              \r\n ##   ##   #  #    #        #  #                               \r\n  ## ##     ##     #        #   #      ##       ##       ##    \r\n   ###      ##     ######   #    #     ##       ##       ##    \r\n                                                               \r\n");
		}


	}
}
