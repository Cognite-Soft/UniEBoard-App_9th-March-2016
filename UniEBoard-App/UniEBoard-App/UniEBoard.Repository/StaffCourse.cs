//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniEBoard.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class StaffCourse
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> EffectiveFrom { get; set; }
        public Nullable<System.DateTime> EffectiveTo { get; set; }
        public int Staff_Id { get; set; }
        public int Course_Id { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Location { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
