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
    
    public partial class Result
    {
        public int ID { get; set; }
        public int RaceID { get; set; }
        public int RunnerID { get; set; }
        public Nullable<System.TimeSpan> RaceTime { get; set; }
        public int Position { get; set; }
    
        public virtual Runner Runner { get; set; }
    }
}