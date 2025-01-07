using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo19Genericite.Models
{
    public class ArrayListGenerique<T>
    {
        private ArrayList _list;

        public T this[int index]  //indexer
        {
            get
            {
                return (T)_list[index];
            }
            set
            {
                _list[index] = value;
            }
        }

        public ArrayListGenerique()
        {
            _list = new ArrayList();
        }

        public void Add(T value)
        {
            _list.Add(value);
        }

    }
}
