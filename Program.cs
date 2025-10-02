using System;
using System.Collections.Generic;


namespace Console_Project
{
	internal class Program
	{
		static Player player = new Player();
		public static ConsoleKeyInfo mKey = new ConsoleKeyInfo();
		//public static List<Projectile> projectiles = new List<Projectile>();
		public static CustomList<Projectile> projectiles = new CustomList<Projectile>();
		static bool checkKey;


		static void Main(string[] args)
		{
			Console.SetWindowSize(GameManager.instance.worldX + 6, GameManager.instance.worldY + 6);
			Console.CursorVisible = false;
			SetGameStartRountine();
			SetProjectileRoutine();

			// 메인 메뉴 그리기
			MainMenu.MenuStart();

			Console.Clear(); // 메인 메뉴 화면 지우기
			
			GameManager.stopWatch.Start();
			
			GameManager.instance.gameStartRoutine?.Invoke();
			Map.DrawMap();
			player.DrawPlayer();

			switch (GameManager.instance.difficulty)
			{
				case 1: //easy 난이도
				case 2: //normal 난이도			 
					while (GameManager.instance.GameOver() && GameManager.instance.GameClear())
					{
						mKey = Console.ReadKey(true);
						player.Record();
						player.Crash();

						player.ErasePlayer();
						GameManager.instance.projectileRoutine?.Invoke();
						GameManager.instance.gameStartRoutine?.Invoke();
						Projectile.DrawProjectile();
						player.DrawPlayer();
					}
					if(!GameManager.instance.GameClear()) GameManager.instance.DrawGameClear();
					if (!GameManager.instance.GameOver()) GameManager.instance.DrawGameOver();
						break;

				case 3: //hard 난이도

					while (GameManager.instance.GameOver() && GameManager.instance.HardGameClear())
					{
						if (Console.KeyAvailable)
						{
							mKey = Console.ReadKey(true);
							checkKey = true;
						}
						
						if (GameManager.stopWatch.ElapsedMilliseconds % 150 == 0)
						{
							player.Record();

							if (checkKey)
							{								
								player.HandleInput();
								checkKey = false;
							}
							
							player.NewCrash();
							
							if(GameManager.stopWatch.ElapsedMilliseconds > GameManager.instance.maxTimer / 2 * 1000)
							{
								Projectile.CreateProjectile();
							}
							GameManager.instance.projectileRoutine?.Invoke();
							Map.DrawState();
							player.ErasePlayer();
							Projectile.DrawProjectile();
							player.DrawPlayer();
						}
					}
					if (!GameManager.instance.HardGameClear()) GameManager.instance.DrawGameClear();
					if (!GameManager.instance.GameOver()) GameManager.instance.DrawGameOver();

					break;
				default: //종료
					Console.Clear();
					Console.WriteLine("요청에 의해서 게임을 종료합니다.");
					break;
			}

		}



		static void SetGameStartRountine()
		{
			GameManager.instance.gameStartRoutine += Map.DrawState;
			GameManager.instance.gameStartRoutine += player.HandleInput;
			//GameManager.instance.gameStartRoutine += player.DrawPlayer;
		}

		static void SetProjectileRoutine()
		{
			GameManager.instance.projectileRoutine += Projectile.CreateProjectile;
			GameManager.instance.projectileRoutine += Projectile.MoveProjectile;
		}

		
	}
}
