using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
	internal class MainMenu
	{
		//인스턴스 생성 없이 MainMenu.GameStart()로 바로 게임이 시작되도록 하기 위해서 static 선언, 이후 한 번의 게임이 끝나고 또 호출해야 함
		static int menuCount = 5;
		static public void GameStart()
		{
			DrawMenu();
			DifficultyInput();
		}
		static void DrawMenu()
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

		static void DifficultyInput()
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
