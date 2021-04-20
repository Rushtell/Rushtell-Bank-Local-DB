using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ClientsLibrary
{
    class RepositClients <T> : IEnumerable
    {
        List<T> reposit;
        public RepositClients()
        {
            reposit = new List<T>();
        }

        /// <summary>
        /// Create client
        /// </summary>
        /// <param name="obj">Client type</param>
        /// <returns>Return you Id</returns>
        public int Add(T obj)
        {
            reposit.Add(obj);
            return reposit.Count;
        }

        public int Count { get { return reposit.Count; } }

        public int GetId (T obj)
        {
            return reposit.IndexOf(obj);
        }

        public void Delete (int Id)
        {
            reposit[Id] = default;
        }

        public Type GetType (int index)
        {
            return reposit[index].GetType();
        }

        public T this[int index]
        {
            get { return reposit[index]; }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < reposit.Count; i++)
            {
                yield return reposit[i];
            }
        }

        public void ReWrite(T obj, int Id)
        {
            reposit[Id] = obj;
        }

        public void Restory(List<T> db)
        {
            for (int i = 0; i < db.Count; i++)
            {
                reposit.Add(default);
                reposit[i] = db[i];
            }
            SystemPayments.Refresh();
        }
    }
}
