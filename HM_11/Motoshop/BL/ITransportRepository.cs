using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motoshop.BL
{
    interface ITransportRepository<T>
    {
        #region CRUD

        IEnumerable<T> Get();

        void Create(T vehicle);

        //GetById
        //Edit
        //Delete

        #endregion
    }
}
