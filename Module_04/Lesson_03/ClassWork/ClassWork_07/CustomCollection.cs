using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_07
{
    class CustomCollection : ICollection
    {        
        private Array myArray;

        public CustomCollection(Type type, int length)
        {
            myArray = Array.CreateInstance(type, length);
        }

        public int Count => myArray.Length;

        public object SyncRoot => myArray;

        public bool IsSynchronized => (myArray as ICollection).IsSynchronized;

        public void CopyTo(Array array, int index)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                array.SetValue(myArray.GetValue(i), index);
                index++;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                yield return myArray.GetValue(i);
            }
        }
    }
}
