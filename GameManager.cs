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
		public int worldX = 52; // 2로 나누었을 때 짝수가 되도록 설정하기
		public int worldY = 25;
		public float maxTimer = 40;
		public int difficulty;
		public int playerHealth = 3;
		public int score = 0;
		public int playerBomb = 1;

		static public Stopwatch stopWatch = new Stopwatch();

		static public GameManager instance = new GameManager();
		public bool GameOver()
		{
			return playerHealth > 0;
		}

		public bool HardGameClear() // 시간을 버티면 되는 조건
		{
			return stopWatch.ElapsedMilliseconds < maxTimer * 1000;
		}

		public bool GameClear() // 100개의 투사체가 사라지면 이기는 조건 (bomb는 제외), 시연 및 테스트는 10
		{
			return score < 10;
		}
		public void DrawGameClear()
		{
			Console.Clear();
			Console.SetWindowSize(100, 30);
			Console.WriteLine("   ####     ##     #    #   ######  \r\n  ##  ##   #  #    ##  ##   #       \r\n ##       #    #   # ## #   #       \r\n ##  ###  ######   # ## #   ####    \r\n ##   ##  #    #   #    #   #       \r\n  ## ###  #    #   #    #   #       \r\n   ### #  #    #   #    #   ######  \r\n                                    \r\n");  
			Console.WriteLine("   ####   #        ######     ##     #####      ##    \r\n  ##  ##  #        #         #  #    #    #     ##    \r\n ##       #        #        #    #   #    #     ##    \r\n ##       #        ####     ######   #####      ##    \r\n ##       #        #        #    #   #  #             \r\n  ##  ##  #        #        #    #   #   #      ##    \r\n   ####   ######   ######   #    #   #    #     ##    \r\n                                                      \r\n");
			Console.Write("클리어를 축하드립니다!! 종료하려면 엔터를 한 번 눌러주세요!");
			Console.ReadLine();
		}

		public void DrawGameOver()
		{
			Console.Clear();
			Console.SetWindowSize(100, 30);
			Console.WriteLine("   ####     ##     #    #   ######  \r\n  ##  ##   #  #    ##  ##   #       \r\n ##       #    #   # ## #   #       \r\n ##  ###  ######   # ## #   ####    \r\n ##   ##  #    #   #    #   #       \r\n  ## ###  #    #   #    #   #       \r\n   ### #  #    #   #    #   ######  \r\n                                    \r\n");
			Console.WriteLine("   ###    #    #   ######   #####                              \r\n  ## ##   #    #   #        #    #                             \r\n ##   ##  #    #   #        #    #                             \r\n ##   ##   #  #    ####     #####                              \r\n ##   ##   #  #    #        #  #                               \r\n  ## ##     ##     #        #   #      ##       ##       ##    \r\n   ###      ##     ######   #    #     ##       ##       ##    \r\n                                                               \r\n");
			Console.Write("아쉽지만 실패하셨습니다... 다음데 또 도전해주세요! 종료를 위해서 엔터를 한 번 눌러주세요!!");
			Console.ReadLine();
		}


	}
}
