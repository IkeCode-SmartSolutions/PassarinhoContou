namespace PassarinhoContou.Model
{
    public partial class SuffixTranslation : BaseModel
    {
        public int SuffixId { get; set; }
        public int LanguageId { get; set; }
        public string MessageText { get; set; }

        public virtual MessageSuffix Suffix { get; set; }
    }
}
