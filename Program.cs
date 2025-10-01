using System;
using System.Collections.Generic;


namespace Console_Project
{
	internal class Program
	{
		static Player player = new Player();
		public static ConsoleKeyInfo mKey = new ConsoleKeyInfo();
		public static List<Projectile> projectiles = new List<Projectile>();


		static void Main(string[] args)
		{
			Console.SetWindowSize(GameManager.instance.worldX + 6, GameManager.instance.worldY + 6);
			Console.CursorVisible = false;
			SetGameStartRountine();
			SetProjectileRoutine();

			// 메인 메뉴 그리기
			MainMenu.MenuStart();

			Console.Clear(); // 메인 메뉴 화면 지우기

			switch (GameManager.instance.difficulty)
			{
				case 1: //easy 난이도
				case 2: //normal 난이도
					GameManager.stopWatch.Start();
					GameManager.instance.gameStartRoutine?.Invoke(); // 맵과 플레이어 그리기 

					while (GameManager.instance.GameOver() && GameManager.instance.GameClear()) // z입력받으면 강제 종료
					{
						mKey = Console.ReadKey(true);

						player.Crash();

						GameManager.instance.gameStartRoutine?.Invoke();
						GameManager.instance.projectileRoutine?.Invoke();
					}
					if(!GameManager.instance.GameClear()) GameManager.instance.DrawGameClear();
					if (!GameManager.instance.GameOver()) GameManager.instance.DrawGameOver();
						break;

				case 3: //hard 난이도
					GameManager.stopWatch.Start();
					GameManager.instance.gameStartRoutine?.Invoke(); // 맵과 플레이어 그리기 

					while (GameManager.instance.GameOver() && GameManager.instance.GameClear())
					{
						if (GameManager.stopWatch.ElapsedMilliseconds % 150 == 0)
						{

							if (Console.KeyAvailable)
							{
								mKey = Console.ReadKey(true);

								player.HandleInput();
							}
							player.Crash();
							GameManager.instance.ClearScreenByFilling();
							Map.DrawMap();
							player.DrawPlayer();
							GameManager.instance.projectileRoutine?.Invoke();
						}
					}

					break;
				default: //종료
					Console.WriteLine("요청에 의해서 게임을 종료합니다.");
					break;
			}

		}



		static void SetGameStartRountine()
		{
			GameManager.instance.gameStartRoutine += GameManager.instance.ClearScreenByFilling;
			GameManager.instance.gameStartRoutine += Map.DrawMap;

			GameManager.instance.gameStartRoutine += player.HandleInput;
			GameManager.instance.gameStartRoutine += player.DrawPlayer;
		}

		static void SetProjectileRoutine()
		{
			GameManager.instance.projectileRoutine += Projectile.CreateProjectile;
			GameManager.instance.projectileRoutine += Projectile.MoveProjectile;
			GameManager.instance.projectileRoutine += Projectile.DrawProjectile;
		}

		
	}
}
