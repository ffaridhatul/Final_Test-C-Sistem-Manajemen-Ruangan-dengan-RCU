using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest.Model
{
    public interface IDataSource<T>
    {
        void Add(T item);
        void Save(List<T> list);
        Task SaveAsync(List<T> list);
        List<T> Load();
    }
}
