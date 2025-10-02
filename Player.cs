using System;

namespace Console_Project
{
	internal class Player
	{
		private int _x;
		private int _y;
		private char _playerChar;

		private int _ex;
		private int _ey;

		public Player()
		{
			_x = GameManager.instance.worldX / 2;
			_y = GameManager.instance.worldY / 2;
			_playerChar = '⊙';
		}

		public void ErasePlayer()
		{
			Console.SetCursorPosition(_ex, _ey);
			Console.Write("  ");
		}

		public void DrawPlayer()
		{
			Console.SetCursorPosition(_x, _y);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(_playerChar);
			Console.ResetColor();
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
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 2)
						{
							if (_y - Program.projectiles[i].Y == 1 && _x - Program.projectiles[i].X == 1)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 3)
						{
							if (_y - Program.projectiles[i].Y == 1 && _x - Program.projectiles[i].X == -1)
							{
								CrashRoutine(i);
							}
						}
					}
					else if (Program.mKey.Key == ConsoleKey.S)
					{
						if (Program.projectiles[i].Dir == 1)
						{
							if (_x == Program.projectiles[i].X && (Program.projectiles[i].Y - _y == 2 || Program.projectiles[i].Y - _y == 1))
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 2) // ->
						{
							if (_y - Program.projectiles[i].Y == -1 && _x - Program.projectiles[i].X == 2)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 3) // <-
						{
							if (_y - Program.projectiles[i].Y == -1 && _x - Program.projectiles[i].X == -2)
							{
								CrashRoutine(i);
							}
						}
					}
					else if (Program.mKey.Key == ConsoleKey.D)
					{
						if (Program.projectiles[i].Dir == 0)
						{
							if (_x - Program.projectiles[i].X == -2 && Program.projectiles[i].Y - _y == -1)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 1)
						{
							if (_x - Program.projectiles[i].X == -2 && Program.projectiles[i].Y - _y == 1)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 3) // <-
						{
							if (_y == Program.projectiles[i].Y && (Program.projectiles[i].X - _x == 4 || Program.projectiles[i].X - _x == 2))
							{
								CrashRoutine(i);
							}
						}
					}
					else if (Program.mKey.Key == ConsoleKey.A)
					{
						if (Program.projectiles[i].Dir == 0)
						{
							if (_x - Program.projectiles[i].X == 2 && Program.projectiles[i].Y - _y == -1)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 1)
						{
							if (_x - Program.projectiles[i].X == 2 && Program.projectiles[i].Y - _y == 1)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 2)
						{
							if (_y - Program.projectiles[i].Y == 0 && (Program.projectiles[i].X - _x == -4 || Program.projectiles[i].X - _x == -2))
							{
								CrashRoutine(i);
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
			Map.DrawMap();
			GameManager.instance.gameStartRoutine?.Invoke();
		}

		public void Record()
		{
			_ex = _x;
			_ey = _y;
		}

		public void NewCrash() // 입력에 의존하지 않고 update가 갱신되기 전 위치와 현재 위치를 기록하여 그 차이로 충돌 판정 // 플레이어는 움직이고 투사체는 아직 움직이기 전의 상태에서 충돌 판정
		{
			for (int i = 0; i < Program.projectiles.Count; i++)
			{
				if (Program.projectiles[i].IsLive)
				{
					if (_x == _ex && _y - _ey == -1) // W를 눌렀을 때
					{
						if (Program.projectiles[i].Dir == 0)
						{
							if (_x == Program.projectiles[i].X && (_y == Program.projectiles[i].Y || _y - Program.projectiles[i].Y == 1))
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 2)
						{
							if (_y == Program.projectiles[i].Y && _x - Program.projectiles[i].X == 2)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 3)
						{
							if (_y == Program.projectiles[i].Y && _x - Program.projectiles[i].X == -2)
							{
								CrashRoutine(i);
							}
						}
					}
					else if (_x == _ex && _y - _ey == 1) // S를 눌렀을 때
					{
						if (Program.projectiles[i].Dir == 1)
						{
							if (_x == Program.projectiles[i].X && (_y == Program.projectiles[i].Y || _y - Program.projectiles[i].Y == -1))
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 2) // ->
						{
							if (_y == Program.projectiles[i].Y && _x - Program.projectiles[i].X == 2)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 3) // <-
						{
							if (_y == Program.projectiles[i].Y && _x - Program.projectiles[i].X == -2)
							{
								CrashRoutine(i);
							}
						}
					}
					else if (_x - _ex == 2 && _y == _ey) // D를 눌렀을 때
					{
						if (Program.projectiles[i].Dir == 0)
						{
							if (_x == Program.projectiles[i].X && Program.projectiles[i].Y - _y == -1)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 1)
						{
							if (_x == Program.projectiles[i].X && Program.projectiles[i].Y - _y == 1)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 3) // <-
						{
							if (_y == Program.projectiles[i].Y && (Program.projectiles[i].X == _x || Program.projectiles[i].X - _x == 2))
							{
								CrashRoutine(i);
							}
						}
					}
					else if (_x - _ex == -2 && _y == _ey) // A를 눌렀을 때
					{
						if (Program.projectiles[i].Dir == 0)
						{
							if (_x == Program.projectiles[i].X && Program.projectiles[i].Y - _y == -1)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 1)
						{
							if (_x == Program.projectiles[i].X && Program.projectiles[i].Y - _y == 1)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 2)
						{
							if (_y - Program.projectiles[i].Y == 0 && (Program.projectiles[i].X == _x || Program.projectiles[i].X - _x == -2))
							{
								CrashRoutine(i);
							}
						}
					}
					else if (_x == _ex && _y == _ey)
					{
						if (Program.projectiles[i].Dir == 0)
						{
							if (_x == Program.projectiles[i].X && Program.projectiles[i].Y - _y == -1)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 1)
						{
							if (_x == Program.projectiles[i].X && Program.projectiles[i].Y - _y == 1)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 2)
						{
							if (_x - Program.projectiles[i].X == 2 && Program.projectiles[i].Y == _y)
							{
								CrashRoutine(i);
							}
						}
						else if (Program.projectiles[i].Dir == 3)
						{
							if (_x - Program.projectiles[i].X == -2 && Program.projectiles[i].Y == _y)
							{
								CrashRoutine(i);
							}
						}
					}


				}

			}
		}


		public void CrashRoutine(int i)
		{
			GameManager.instance.playerHealth--;
			Program.projectiles[i].IsLive = false;
			Console.SetCursorPosition(Program.projectiles[i].X, Program.projectiles[i].Y);
			Console.Write("  ");
		}
	}
}
