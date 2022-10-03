using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Models.Repositories
{
    public class RepositoriesListingViewModel
    {
        public string Id { get; init; }

        public string Name { get; init; }
        
        public string Owner { get; init; }

        public string CreatedOn { get; init; }

        public int CommitsCount { get; init; }
    }
}
