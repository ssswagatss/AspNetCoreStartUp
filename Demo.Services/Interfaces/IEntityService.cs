using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Services.Interfaces
{
    public interface IEntityService<T>
    {
        IEnumerable<T> GetAll();
    }
}
