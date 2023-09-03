﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQCrossReference;

public class ChildClass
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required Guid ParentId { get; set; }
    public required ParentClass Parent { get; set; }
}
