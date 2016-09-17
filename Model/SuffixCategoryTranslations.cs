namespace PassarinhoContou.Model
{
    public partial class SuffixCategoryTranslations : BaseModel
    {
        public int PrefixCategoryId { get; set; }
        public int LanguageId { get; set; }
        public string CategoryText { get; set; }

        public virtual SuffixCategory PrefixCategory { get; set; }
    }
}
