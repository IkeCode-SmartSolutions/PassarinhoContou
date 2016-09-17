using System;
using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class Messages : BaseModel
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int Status { get; set; }
        public int SelectedPrefixId { get; set; }
        public int SelectedSuffixId { get; set; }
        public int MessageType { get; set; }
        public int LanguageId { get; set; }
        
        public virtual Users FromUser { get; set; }
        public virtual MessagePrefixes SelectedPrefix { get; set; }
        public virtual MessageSuffixes SelectedSuffix { get; set; }
        public virtual Users ToUser { get; set; }
    }
}
