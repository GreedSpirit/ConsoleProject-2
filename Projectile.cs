using System;
using System.Linq;


namespace Console_Project
{
	internal class Projectile
	{
		int[] dx = { 0, 0, 2, -2 }; //dir을 이용해서 이동시키기 위한 배열
		int[] dy = { 1, -1, 0, 0 };
		private int _ex;
		private int _ey;

		private int _posX; // dir이 1, 2 일 때
		private int _posY; // dir이 0, 1 일 때
		private int _dir;
		private bool _isLive;

		public bool IsLive {  get { return _isLive; } set { _isLive = value; } }

		public int X { get { return _posX; } }
		public int Y { get { return _posY; } }
		public int Dir { get { return _dir; } }


		public void Move()
		{
			if (_isLive) {
				_ex = _posX;
				_ey = _posY;

				_posX += dx[_dir];
				_posY += dy[_dir];

				if(_posY < 1 || _posY > GameManager.instance.worldY)
				{
					_isLive = false;
					Console.SetCursorPosition(_ex, _ey);
					Console.Write("  ");
					GameManager.instance.score++;
				}
				if (_posX < 2 || _posX > GameManager.instance.worldX - 4)
				{
					_isLive = false;
					Console.SetCursorPosition(_ex, _ey);
					Console.Write("  ");
					GameManager.instance.score++;
				}
			}
		}

		public void EasyCreateProjectile()
		{
			_isLive = true;
			Random rnd = new Random();

			_posX = rnd.Next(2, GameManager.instance.worldX - 3);
			while(_posX % 2 != 0)
			{
				_posX = rnd.Next(2, GameManager.instance.worldX - 3);
			}
			_dir = 0;
			_posY = 0;

		}

		public void NormalCreateProjectile()
		{
			_isLive = true;
			Random rnd = new Random();

			_posX = rnd.Next(2, GameManager.instance.worldX - 4);
			while (_posX % 2 != 0)
			{
				_posX = rnd.Next(2, GameManager.instance.worldX - 4);
			}
			_dir = rnd.Next(0, 2);

			if (_dir == 0)
			{
				_posY = 0;
			}
			else
			{
				_posY = GameManager.instance.worldY + 1;
			}
		}

		public void HardCreateProjectile()
		{
			_isLive = true;
			Random rnd = new Random();

			_dir = rnd.Next(0, (int)(GameManager.stopWatch.ElapsedMilliseconds / ((int)(GameManager.instance.maxTimer / 5) * 1000)));
			if (_dir > 3) _dir = 3; // 혹시 모르는 방어코드

			if (_dir == 0 || _dir == 1)
			{
				_posX = rnd.Next(2, GameManager.instance.worldX - 4);
				while (_posX % 2 != 0)
				{
					_posX = rnd.Next(2, GameManager.instance.worldX - 4);
				}

				if (_dir == 0)
				{
					_posY = 0;
				}
				else
				{
					_posY = GameManager.instance.worldY + 1;
				}
			}
			else
			{
				if (_dir == 2)
				{
					_posX = 0;
				}
				else
				{
					_posX = GameManager.instance.worldX - 2;
				}

				_posY = rnd.Next(1, GameManager.instance.worldY + 1);
			}

		}

		public void Draw()
		{
			if (_isLive)
			{
				if(!(_ey < 1 || _ey > GameManager.instance.worldY || _ex < 2 || _ex > GameManager.instance.worldX - 4))
				{
					Console.SetCursorPosition(_ex, _ey);
					Console.Write("  ");
				}
				Console.SetCursorPosition(_posX, _posY);
				if (_dir == 0)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("▽");
					Console.ResetColor();
				}
				else if (_dir == 1)
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.Write("△");
					Console.ResetColor();
				}
				else if (_dir == 2)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.Write("▷");
					Console.ResetColor();
				}
				else if (_dir == 3)
				{
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.Write("◁");
					Console.ResetColor();
				}
			}
		}

		static public void CreateProjectile()
		{
			if(Program.projectiles.Count != 0)
			{
				for(int i = 0; i < Program.projectiles.Count; i++)
				{
					if( Program.projectiles[i]._isLive == false)
					{
						if (GameManager.instance.difficulty == 1)
						{
							Program.projectiles[i].EasyCreateProjectile();
						}
						else if(GameManager.instance.difficulty == 2)
						{
							Program.projectiles[i].NormalCreateProjectile();
						}
						else if (GameManager.instance.difficulty == 3)
						{
							Program.projectiles[i].HardCreateProjectile();
						}

						return;
					}
				}
			}

			Program.projectiles.Add(new Projectile());
			if (GameManager.instance.difficulty == 1)
			{
				Program.projectiles[Program.projectiles.Count - 1].EasyCreateProjectile();
			}
			else if (GameManager.instance.difficulty == 2)
			{
				Program.projectiles[Program.projectiles.Count - 1].NormalCreateProjectile();
			}
			else if (GameManager.instance.difficulty == 3)
			{
				Program.projectiles[Program.projectiles.Count - 1].HardCreateProjectile();
			}

		}

		static public void MoveProjectile()
		{
			for (int i = 0; i < Program.projectiles.Count; i++)
			{
				Program.projectiles[i].Move();
			}
		}
		static public void DrawProjectile()
		{
			for (int i = 0; i < Program.projectiles.Count; i++)
			{
				Program.projectiles[i].Draw();
			}
		}


	}
}
