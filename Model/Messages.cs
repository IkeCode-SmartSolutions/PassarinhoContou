namespace PassarinhoContou.Model
{
    public partial class Message : BaseModel
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int Status { get; set; }
        public int SelectedPrefixId { get; set; }
        public int SelectedSuffixId { get; set; }
        public int MessageType { get; set; }
        public int LanguageId { get; set; }
        
        public virtual User FromUser { get; set; }
        public virtual MessagePrefix SelectedPrefix { get; set; }
        public virtual MessageSuffix SelectedSuffix { get; set; }
        public virtual User ToUser { get; set; }
    }
}
