using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AREA.Membership.Models
{
    public class States
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
    }
}