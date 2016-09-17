using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class MessagePrefix : BaseModel
    {
        public MessagePrefix()
        {
            Messages = new HashSet<Message>();
            PrefixesTranslations = new HashSet<PrefixTranslation>();
        }

        public int PrefixCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<PrefixTranslation> PrefixesTranslations { get; set; }
        public virtual PrefixCategory PrefixCategory { get; set; }
    }
}
