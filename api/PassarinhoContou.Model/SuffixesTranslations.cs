using System;
using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class SuffixesTranslations : BaseModel
    {
        public int SuffixId { get; set; }
        public int LanguageId { get; set; }
        public string MessageText { get; set; }

        public virtual MessageSuffixes Suffix { get; set; }
    }
}
