using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Rushtell_Bunk
{
    class ConstructorRepositClients <T> : IEnumerable
    {
        List<T> reposit;
        public ConstructorRepositClients()
        {
            reposit = new List<T>();
        }

        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <param name="obj">Клиент (Worker, VIPworker или Organization)</param>
        /// <returns>Вернет id клиента</returns>
        public int Add(T obj)
        {
            reposit.Add(obj);
            return reposit.Count;
        }

        /// <summary>
        /// Дает длинну репозитория
        /// </summary>
        public int Count { get { return reposit.Count; } }

        public int GetId (T obj)
        {
            return reposit.IndexOf(obj);
        }

        /// <summary>
        /// "Удаляет" клиента из репозитория, ставит вмсето него default значение чтобы длинна коллекции не уменьшалась
        /// </summary>
        /// <param name="Id"></param>
        public void Delete (int Id)
        {
            reposit[Id] = default;
        }

        /// <summary>
        /// Возвращает тип клиента из репозитория по id
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Type GetType (int index)
        {
            return reposit[index].GetType();
        }

        /// <summary>
        /// Индексатор для репозитория
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Перезапись клинта по указанному id
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="Id"></param>
        public void ReWrite(T obj, int Id)
        {
            reposit[Id] = obj;
        }

        /// <summary>
        /// Перезаписывает в репозитории данные
        /// </summary>
        /// <param name="db"></param>
        public void Restory(List<T> db)
        {
            for (int i = 0; i < db.Count; i++)
            {
                reposit.Add(default);
                reposit[i] = db[i];
            }
            Repository.Refresh();
        }
    }
}
