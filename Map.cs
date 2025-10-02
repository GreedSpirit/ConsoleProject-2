using System;

namespace Console_Project
{
	class Map
	{
		//인스턴스 생성 없이 바로 Map.DrawMap으로 만들 수 있도록 static 선언
		static public void DrawMap()
		{
			Console.SetCursorPosition(0, 0);
			for (int i = 0; i < GameManager.instance.worldX / 2; i++)
			{
				Console.Write("▩");
			}
			Console.WriteLine();
			for(int i = 0; i < GameManager.instance.worldY; i++)
			{
				Console.Write("▩");
				for(int j = 0; j < GameManager.instance.worldX - 4; j++)
				{
					Console.Write(" ");
				}
				Console.WriteLine("▩");
			}
			for (int i = 0; i < GameManager.instance.worldX / 2; i++)
			{
				Console.Write("▩");
			}
			DrawState();
			
		}

		static public void DrawState()
		{
			Console.SetCursorPosition(6, GameManager.instance.worldY + 2);
			Console.WriteLine("Score : " + GameManager.instance.score + "      Bomb(B) : " + GameManager.instance.playerBomb
				+ "      Health : " + GameManager.instance.playerHealth);
			if (GameManager.instance.difficulty == 3)
			{
				Console.SetCursorPosition(6, GameManager.instance.worldY + 3);
				Console.WriteLine("Time : " + (GameManager.instance.maxTimer - 1 - GameManager.stopWatch.ElapsedMilliseconds / 1000) + "." + (1000 - GameManager.stopWatch.ElapsedMilliseconds % 1000));
			}
		}
	}
}
