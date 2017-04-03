using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.Common.Filters
{
    public interface IPagingFilter
    {
        /// <summary>
        /// Gets or sets the search string.
        /// </summary>
        /// <value>The search string.</value>
        string SearchString { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        string SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>The page number.</value>
        int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        /// <value>The page size.</value>
        int PageSize { get; set; }
    }
}
