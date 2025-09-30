using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
	internal class Player
	{
		private int _x;
		private int _y;

		private int _health;
		private char _playerChar;

		public int X
		{
			get { return _x; }
			set { _x = value; }
		}
		public int Y
		{
			get { return _y; }
			set { _y = value; }
		}
		public int Health
		{
			get { return _health; }
			set { _health = value; }
		}
		public char PlayerChar
		{
			get { return _playerChar; }
			set { _playerChar = value; }
		}

		public void test()
		{
		}

	}
}
