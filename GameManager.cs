using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
	public class GameManager
	{
		public int worldX = 42;
		public int worldY = 23;
		public float timer = 30;
		public int difficulty;

		static public GameManager instance = new GameManager();

		
	}
}
