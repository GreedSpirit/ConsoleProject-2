using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
	internal class MainMenu
	{
		int menuCount = 5;
		public void DrawMenu()
		{
			for (int i = 0; i < menuCount; i++) {
				Console.SetCursorPosition(GameManager.instance.worldX / 2, GameManager.instance.worldY / 4 + i);

				switch (i)
				{
					case 0:
						Console.WriteLine("메인 메뉴");
						break;
					case 1:
						Console.WriteLine("1. Easy");
						break;
					case 2:
						Console.WriteLine("2. Normal");
						break;
					case 3:
						Console.WriteLine("3. Hard");
						break;


					default:
						Console.WriteLine($"{i}. 종료");
						break;
				}
			}
		}

		public void DifficultyInput()
		{
			Console.SetCursorPosition(GameManager.instance.worldX / 2, GameManager.instance.worldY / 4 + menuCount);
			Console.Write("원하는 난이도 혹은 종료 숫자를 입력해주세요 : ");
			int.TryParse(Console.ReadLine(), out GameManager.instance.difficulty);
			while (!(GameManager.instance.difficulty > 0 && GameManager.instance.difficulty < menuCount))
			{
				Console.SetCursorPosition(GameManager.instance.worldX / 2, GameManager.instance.worldY / 4 + menuCount);
				Console.WriteLine("                                                      ");
				Console.SetCursorPosition(GameManager.instance.worldX / 2, GameManager.instance.worldY / 4 + menuCount);
				Console.Write($"1 ~ {menuCount - 1} 사이의 숫자만 입력해주세요 : ");
				int.TryParse(Console.ReadLine(), out GameManager.instance.difficulty);
			}
		}
	}
}
