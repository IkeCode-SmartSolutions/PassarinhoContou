using System;
using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class PrefixCategories : BaseModel
    {
        public PrefixCategories()
        {
            MessagePrefixes = new HashSet<MessagePrefixes>();
            PrefixCategoryTranslations = new HashSet<PrefixCategoryTranslations>();
        }

        public string Name { get; set; }

        public virtual ICollection<MessagePrefixes> MessagePrefixes { get; set; }
        public virtual ICollection<PrefixCategoryTranslations> PrefixCategoryTranslations { get; set; }
    }
}
