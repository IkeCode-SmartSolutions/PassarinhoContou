using System;
using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class PrefixesTranslations : BaseModel
    {
        public int PrefixId { get; set; }
        public int LanguageId { get; set; }
        public string MessageText { get; set; }

        public virtual MessagePrefixes Prefix { get; set; }
    }
}
