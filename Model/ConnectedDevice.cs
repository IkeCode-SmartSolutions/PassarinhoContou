namespace PassarinhoContou.Model
{
    public partial class ConnectedDevice : BaseModel
    {
        public int UserId { get; set; }
        public string DeviceId { get; set; }
        public string ConfirmationCode { get; set; }

        public virtual User User { get; set; }
    }
}
