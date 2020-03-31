using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relations.API.ViewModels
{
    public class RelationDisableParams
    {
        public IEnumerable<Guid> RelationIds { get; set; }
    }
}
