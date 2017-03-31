using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.Repository.Common.Filters
{
    class MakesFilter
    {
         #region Properties 

        public string SearchString { get; set; }
        public string SortOrder { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }

        #endregion Properties

        #region Variables

        public int DefaultPageSize = 15;

        #endregion Variables


        #region Methods

        public MakesFilter(string searchTerm, int pageNumber, int pageSize)
        {
            try
            {
                SearchString = searchTerm;
                SetPageNumberAndSize(pageNumber, pageSize);
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        private void SetPageNumberAndSize(int pageNumber = 1, int pageSize = 0)
        {
            PageNumber = (pageNumber > 0) ? pageNumber : 1;
            PageSize = (pageSize > 0 && pageSize <= DefaultPageSize) ? pageSize : DefaultPageSize;
        }
        #endregion Methods
    }
}