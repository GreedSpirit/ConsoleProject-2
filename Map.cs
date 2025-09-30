using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
	internal class Map
	{
		//인스턴스 생성 없이 바로 Map.DrawMap으로 맵을 만들 수 있도록 static 선언
		static public void DrawMap()
		{
			Console.Clear();
			for(int i = 0; i < GameManager.instance.worldX; i++)
			{
				Console.Write("▩");
			}
			Console.WriteLine();
			for(int i = 0; i < GameManager.instance.worldY; i++)
			{
				Console.Write("▩");
				for(int j = 0; j < GameManager.instance.worldX * 2 - 4; j++)
				{
					Console.Write(" ");
				}
				Console.WriteLine("▩");
			}
			for (int i = 0; i < GameManager.instance.worldX; i++)
			{
				Console.Write("▩");
			}
		}
	}
}
