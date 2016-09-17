using System;
using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class MessagePrefixes : BaseModel
    {
        public MessagePrefixes()
        {
            Messages = new HashSet<Messages>();
            PrefixesTranslations = new HashSet<PrefixesTranslations>();
        }

        public int PrefixCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<PrefixesTranslations> PrefixesTranslations { get; set; }
        public virtual PrefixCategories PrefixCategory { get; set; }
    }
}
