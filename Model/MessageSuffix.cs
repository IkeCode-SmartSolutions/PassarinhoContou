using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class MessageSuffix : BaseModel
    {
        public MessageSuffix()
        {
            Messages = new HashSet<Message>();
            SuffixesTranslations = new HashSet<SuffixTranslation>();
        }

        public int SuffixCategoryId { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<SuffixTranslation> SuffixesTranslations { get; set; }
        public virtual SuffixCategory SuffixCategory { get; set; }
    }
}
