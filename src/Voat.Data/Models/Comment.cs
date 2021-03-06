//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Voat.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            this.CommentSaveTrackers = new HashSet<CommentSaveTracker>();
            this.CommentVoteTrackers = new HashSet<CommentVoteTracker>();
        }
    
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }
        public Nullable<int> SubmissionID { get; set; }
        public int UpCount { get; set; }
        public int DownCount { get; set; }
        public Nullable<int> ParentID { get; set; }
        public bool IsAnonymized { get; set; }
        public bool IsDistinguished { get; set; }
        public string FormattedContent { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual CommentRemovalLog CommentRemovalLog { get; set; }
        public virtual Submission Submission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentSaveTracker> CommentSaveTrackers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentVoteTracker> CommentVoteTrackers { get; set; }
    }
}
