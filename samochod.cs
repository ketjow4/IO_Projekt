//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IO_Projekt
{
    using System;
    using System.Collections.Generic;
    
    public partial class samochod
    {
        public samochod()
        {
            this.wypozyczenia = new HashSet<wypozyczenia>();
            this.zabiegi_konserwacyjne = new HashSet<zabiegi_konserwacyjne>();
        }
    
        public int id { get; set; }
        public string marka { get; set; }
        public string model { get; set; }
        public int kwota { get; set; }
        public string stan { get; set; }
    
        public virtual ICollection<wypozyczenia> wypozyczenia { get; set; }
        public virtual ICollection<zabiegi_konserwacyjne> zabiegi_konserwacyjne { get; set; }
    }
}
