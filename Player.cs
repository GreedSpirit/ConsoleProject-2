using System;

namespace Console_Project
{
	internal class Player
	{
		private int _x;
		private int _y;
		private char _playerChar;

		public Player()
		{
			_x = GameManager.instance.worldX / 2;
			_y = GameManager.instance.worldY / 2;
			_playerChar = '⊙';
		}

		public void DrawPlayer()
		{
			Console.SetCursorPosition(_x, _y);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(_playerChar);
			Console.ResetColor();
		}

		public void HardHandleInput()
		{
			if (Console.KeyAvailable)
			{
				var key = Console.ReadKey(true);

				if (key.Key == ConsoleKey.W && _y > 0) _y--; // 위 이동
				if (key.Key == ConsoleKey.S && _y < Console.WindowHeight - 1) _y++; // 아래 이동
				if (key.Key == ConsoleKey.A && _x > 0) _x--; // 왼쪽 이동
				if (key.Key == ConsoleKey.D && _x < Console.WindowWidth - 1) _x++; // 오른쪽 이동
			}
		}

		public void HandleInput()
		{
			//Program.mKey = Console.ReadKey(true);

			if (Program.mKey.Key == ConsoleKey.W && _y > 1) _y--; // 위 이동
			if (Program.mKey.Key == ConsoleKey.S && _y < GameManager.instance.worldY) _y++; // 아래 이동
			if (Program.mKey.Key == ConsoleKey.A && _x > 2) _x -= 2; // 왼쪽 이동
			if (Program.mKey.Key == ConsoleKey.D && _x < GameManager.instance.worldX - 4) _x += 2; // 오른쪽 이동
			if (Program.mKey.Key == ConsoleKey.B && GameManager.instance.playerBomb > 0)
			{
				GameManager.instance.playerBomb--;
				Bomb();
			}
		}

		public void Crash()
		{
			for (int i = 0; i < Program.projectiles.Count; i++)
			{
				if (Program.projectiles[i].IsLive)
				{
					if (Program.mKey.Key == ConsoleKey.W)
					{
						if (Program.projectiles[i].Dir == 0)
						{
							if (_x == Program.projectiles[i].X && (_y - Program.projectiles[i].Y == 2 || _y - Program.projectiles[i].Y == 1))
							{
								GameManager.instance.playerHealth--;
								Program.projectiles[i].IsLive = false;
							}
						}
						else if (Program.projectiles[i].Dir == 2)
						{
							if (_y - Program.projectiles[i].Y == 1 && _x - Program.projectiles[i].X == 1)
							{
								GameManager.instance.playerHealth--;
								Program.projectiles[i].IsLive = false;
							}
						}
						else if (Program.projectiles[i].Dir == 3)
						{
							if (_y - Program.projectiles[i].Y == 1 && _x - Program.projectiles[i].X == -1)
							{
								GameManager.instance.playerHealth--;
								Program.projectiles[i].IsLive = false;
							}
						}
					}
					else if (Program.mKey.Key == ConsoleKey.S)
					{
						if (Program.projectiles[i].Dir == 1)
						{
							if (_x == Program.projectiles[i].X && (Program.projectiles[i].Y - _y == 2 || Program.projectiles[i].Y - _y == 1))
							{
								GameManager.instance.playerHealth--;
								Program.projectiles[i].IsLive = false;
							}
						}
						else if (Program.projectiles[i].Dir == 2) // ->
						{
							if (_y - Program.projectiles[i].Y == -1 && _x - Program.projectiles[i].X == 2)
							{
								GameManager.instance.playerHealth--;
								Program.projectiles[i].IsLive = false;
							}
						}
						else if (Program.projectiles[i].Dir == 3) // <-
						{
							if (_y - Program.projectiles[i].Y == -1 && _x - Program.projectiles[i].X == -2)
							{
								GameManager.instance.playerHealth--;
								Program.projectiles[i].IsLive = false;
							}
						}
					}
					else if (Program.mKey.Key == ConsoleKey.D)
					{
						if (Program.projectiles[i].Dir == 0)
						{
							if (_x - Program.projectiles[i].X == -2 && Program.projectiles[i].Y - _y == -1)
							{
								GameManager.instance.playerHealth--;
								Program.projectiles[i].IsLive = false;
							}
						}
						else if (Program.projectiles[i].Dir == 1)
						{
							if (_x - Program.projectiles[i].X == -2 && Program.projectiles[i].Y - _y == 1)
							{
								GameManager.instance.playerHealth--;
								Program.projectiles[i].IsLive = false;
							}
						}
						else if (Program.projectiles[i].Dir == 3) // <-
						{
							if (_y == Program.projectiles[i].Y && (Program.projectiles[i].X - _x == 4 || Program.projectiles[i].X - _x == 2))
							{
								GameManager.instance.playerHealth--;
								Program.projectiles[i].IsLive = false;
							}
						}
					}
					else if (Program.mKey.Key == ConsoleKey.A)
					{
						if (Program.projectiles[i].Dir == 0)
						{
							if (_x - Program.projectiles[i].X == 2 && Program.projectiles[i].Y - _y == -1)
							{
								GameManager.instance.playerHealth--;
								Program.projectiles[i].IsLive = false;
							}
						}
						else if (Program.projectiles[i].Dir == 1)
						{
							if (_x - Program.projectiles[i].X == 2 && Program.projectiles[i].Y - _y == 1)
							{
								GameManager.instance.playerHealth--;
								Program.projectiles[i].IsLive = false;
							}
						}
						else if (Program.projectiles[i].Dir == 2)
						{
							if (_y - Program.projectiles[i].Y == 0 && (Program.projectiles[i].X - _x == -4 || Program.projectiles[i].X - _x == -2))
							{
								GameManager.instance.playerHealth--;
								Program.projectiles[i].IsLive = false;
							}
						}
					}

				}

			}
		}

		public void Bomb()
		{
			for (int i = 0; i < Program.projectiles.Count; i++) 
			{
				Program.projectiles [i].IsLive = false;
			}
			Console.Clear();
			GameManager.instance.gameStartRoutine?.Invoke();
		}
	}
}
