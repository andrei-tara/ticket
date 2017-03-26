using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Service
{
    public abstract class AbstractEntityService<T>
    {
        public abstract T FindByName(String name);
        public abstract void Create(String name);
        public abstract ICollection<T> FindAll();
        public T FindOrCreate(string name)
        {
            var entity = FindByName(name);
            if (entity == null)
            {
                Create(name);
            }
            return FindByName(name);
        }


    }
}
