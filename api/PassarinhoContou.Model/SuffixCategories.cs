using System;
using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class SuffixCategories : BaseModel
    {
        public SuffixCategories()
        {
            MessageSuffixes = new HashSet<MessageSuffixes>();
            SuffixCategoryTranslations = new HashSet<SuffixCategoryTranslations>();
        }

        public string Name { get; set; }
        
        public virtual ICollection<MessageSuffixes> MessageSuffixes { get; set; }
        public virtual ICollection<SuffixCategoryTranslations> SuffixCategoryTranslations { get; set; }
    }
}
