using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class SuffixCategory : BaseModel
    {
        public SuffixCategory()
        {
            MessageSuffixes = new HashSet<MessageSuffix>();
            SuffixCategoryTranslations = new HashSet<SuffixCategoryTranslations>();
        }

        public string Name { get; set; }
        
        public virtual ICollection<MessageSuffix> MessageSuffixes { get; set; }
        public virtual ICollection<SuffixCategoryTranslations> SuffixCategoryTranslations { get; set; }
    }
}
