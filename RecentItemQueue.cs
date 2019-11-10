    class RecentItemQueue<T> where T : class
    {
        private readonly int _size;
        private int _head;
        private int _tail;
        private readonly T[] _content;

        public RecentItemQueue(int size)
        {
            _head = -1;
            _tail = -1;
            _size = size;
            _content = new T[size];
        }

        public IReadOnlyList<T> GetItems()
        {
            // the latest item (last in) will be in the first place of output list
            List<T> items = new List<T>();

            if (_head == -1)
            {
                return items;
            }

            int index = _head;

            for (int i = 0; i < _size; i++)
            {
                if (index == -1)
                {
                    index = _size - 1;
                }

                if (_content[index] != null)
                {
                    items.Add(_content[index]);
                }

                index--;
            }

            return items;
        }

        public void SetItem(T item)
        {
            // inital case
            if (_head == -1)
            {
                _head = 0;
                _tail = 1;
                _content[_head] = item;
                return;
            }

            if (Contains(item, out int target))
            {
                // when item is in content
                T targetItem = _content[target];

                while (target != _head)
                {
                    if (target + 1 == _size)
                    {
                        _content[target] = _content[0];
                        target = 0;
                        continue;
                    }

                    _content[target] = _content[target + 1];
                    target++;
                }

                _content[_head] = targetItem;

                return;
            }

            // when item is not in content
            _content[_tail] = item;
            _tail++;

            if (_tail == _size)
            {
                _tail = 0;
            }

            _head++;

            if (_head == _size)
            {
                _head = 0;
            }
        }

        private bool Contains(T item, out int location)
        {
            int index = _head;
            location = -1;

            while (index != _tail)
            {
                if (_content[index] != null && item.Equals(_content[index]))
                {
                    location = index;
                    return true;
                }

                index--;

                if (index == -1)
                {
                    index = _size - 1;
                }
            }

            return false;
        }
    }
