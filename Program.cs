using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MainMenu mainMenu = new MainMenu();
			mainMenu.DrawMenu();
			mainMenu.DifficultyInput();
		}
	}
}
