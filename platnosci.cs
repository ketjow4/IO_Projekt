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
    
    public partial class platnosci
    {
        public platnosci()
        {
            this.znizki_platnosci1 = new HashSet<znizki_platnosci>();
        }
    
        public int id { get; set; }
        public int typ_platnosc { get; set; }
        public Nullable<int> id_wypozyczenia { get; set; }
        public Nullable<int> id_czlonka { get; set; }
        public Nullable<int> id_znizki_platnosci { get; set; }
        public int cena_koncowa { get; set; }
        public System.DateTime data_realizacji { get; set; }
    
        public virtual czlonek czlonek { get; set; }
        public virtual znizki_platnosci znizki_platnosci { get; set; }
        public virtual wypozyczenia wypozyczenia { get; set; }
        public virtual typ_platnosci typ_platnosci { get; set; }
        public virtual ICollection<znizki_platnosci> znizki_platnosci1 { get; set; }
    }
}
