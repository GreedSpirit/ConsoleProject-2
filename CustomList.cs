using System;

namespace Console_Project
{
	public class CustomList<T>
	{
		private T[] _items;
		private int _count;
		private int _capacity;
		public CustomList()
		{
			_capacity = 80;
			_items = new T[_capacity];
			_count = 0;
		}
		public int Count  // List.Count 구현
		{
			get { return _count; }
		}
		public void Add(T item) // List.Add 구현
		{
			if (_count == _capacity)
			{
				_capacity *= 2;
				T[] newItems = new T[_capacity];

				for (int i = 0; i < _count; i++)
				{
					newItems[i] = _items[i];
				}

				_items = newItems;
			}

			_items[_count] = item;
			_count++;
		}

		public T this[int index] //List 인덱스 접근 구현
		{
			get
			{
				if (index < 0 || index >= _count)
				{
					throw new IndexOutOfRangeException();
				}
				return _items[index];
			}
			set
			{
				if (index < 0 || index >= _count)
				{
					throw new IndexOutOfRangeException();
				}
				_items[index] = value;
			}
		}
	}
}
