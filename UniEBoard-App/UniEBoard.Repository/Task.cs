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
    
    public partial class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public bool IsCompleted { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}