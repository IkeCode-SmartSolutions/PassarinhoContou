using System;
using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class MessageSuffixes : BaseModel
    {
        public MessageSuffixes()
        {
            Messages = new HashSet<Messages>();
            SuffixesTranslations = new HashSet<SuffixesTranslations>();
        }

        public int SuffixCategoryId { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<SuffixesTranslations> SuffixesTranslations { get; set; }
        public virtual SuffixCategories SuffixCategory { get; set; }
    }
}
