using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class PrefixCategory : BaseModel
    {
        public PrefixCategory()
        {
            MessagePrefixes = new HashSet<MessagePrefix>();
            PrefixCategoryTranslations = new HashSet<PrefixCategoryTranslations>();
        }

        public string Name { get; set; }

        public virtual ICollection<MessagePrefix> MessagePrefixes { get; set; }
        public virtual ICollection<PrefixCategoryTranslations> PrefixCategoryTranslations { get; set; }
    }
}
