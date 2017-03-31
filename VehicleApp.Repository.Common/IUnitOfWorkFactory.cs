using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Repository.Common;

namespace VehicleApp.Repository
{
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates the unit of work.
        /// </summary>
        /// <returns></returns>
        IUnitOfWork CreateUnitOfWork();
    }
}
