using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQCrossReference;

public class JoinedDataClass
{
    public required Guid ParentId { get; set; }
    public required Guid ChildId { get; set; }
    public required string ParentName { get; set; }
    public required string ChildName { get; set; }
}
