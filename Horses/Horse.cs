//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Horses
{
    using System;
    using System.Collections.Generic;
    
    public partial class Horse
    {
        public Horse()
        {
            this.Runners = new HashSet<Runner>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Runner> Runners { get; set; }
    }
}
