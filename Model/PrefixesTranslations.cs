namespace PassarinhoContou.Model
{
    public partial class PrefixTranslation : BaseModel
    {
        public int PrefixId { get; set; }
        public int LanguageId { get; set; }
        public string MessageText { get; set; }

        public virtual MessagePrefix Prefix { get; set; }
    }
}
