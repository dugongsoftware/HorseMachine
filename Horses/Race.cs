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
    
    public partial class Race
    {
        public Race()
        {
            this.Runners = new HashSet<Runner>();
        }
    
        public int ID { get; set; }
        public int TrackID { get; set; }
        public System.DateTime Start { get; set; }
        public int RaceNumber { get; set; }
        public int TrackCondition { get; set; }
        public int TrackRating { get; set; }
        public int Distance { get; set; }
        public int WeatherCondition { get; set; }
    
        public virtual Track Track { get; set; }
        public virtual ICollection<Runner> Runners { get; set; }
    }
}
