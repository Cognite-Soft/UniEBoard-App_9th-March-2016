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
    
    public partial class Topic : BaseQuestionTopic
    {
        public Topic()
        {
            this.TopicPosts = new HashSet<TopicPost>();
        }
    
        public bool IsPinned { get; set; }
        public int DiscussionId { get; set; }
    
        public virtual ICollection<TopicPost> TopicPosts { get; set; }
        public virtual Discussion Discussion { get; set; }
    }
}