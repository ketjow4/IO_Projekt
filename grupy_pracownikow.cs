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
    
    public partial class grupy_pracownikow
    {
        public grupy_pracownikow()
        {
            this.pracownik = new HashSet<pracownik>();
        }
    
        public int id { get; set; }
        public string nazwa { get; set; }
    
        public virtual ICollection<pracownik> pracownik { get; set; }
    }
}
