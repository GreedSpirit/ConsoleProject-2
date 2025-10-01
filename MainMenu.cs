using System;

namespace Console_Project
{
	class MainMenu
	{
		enum difficulty
		{
			Title, Easy, Normal, Hard
		}
		//인스턴스 생성 없이 MainMenu.GameStart()로 바로 게임이 시작되도록 하기 위해서 static 선언, 이후 한 번의 게임이 끝나고 또 호출해야 함
		static int menuCount = 5;
		static public void MenuStart()
		{
			DrawMenu();
			DifficultyInput();
		}
		static void DrawMenu()
		{
			for (int i = 0; i < menuCount; i++) {
				switch ((difficulty)i)
				{
					case difficulty.Title:
						Console.WriteLine("메인 메뉴");
						break;
					case difficulty.Easy:
						Console.WriteLine("1. Easy");
						break;
					case difficulty.Normal:
						Console.WriteLine("2. Normal");
						break;
					case difficulty.Hard:
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
			
			Console.Write("원하는 난이도 혹은 종료 숫자를 입력해주세요 : ");
			int.TryParse(Console.ReadLine(), out GameManager.instance.difficulty);
			while (!(GameManager.instance.difficulty > 0 && GameManager.instance.difficulty < menuCount))
			{
				Console.SetCursorPosition(0, menuCount);
				Console.Write(new string(' ', Console.WindowWidth));
				Console.SetCursorPosition(0, menuCount);
				Console.Write($"1 ~ {menuCount - 1} 사이의 숫자만 입력해주세요 : ");
				int.TryParse(Console.ReadLine(), out GameManager.instance.difficulty);
			}
		}

	}
}
