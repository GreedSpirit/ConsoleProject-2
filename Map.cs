using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
	internal class Map
	{
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
