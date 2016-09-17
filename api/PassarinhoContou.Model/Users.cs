using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class Users : BaseModel
    {
        public Users()
        {
            ConnectedDevices = new HashSet<ConnectedDevice>();
            MessagesFromUser = new HashSet<Message>();
            MessagesToUser = new HashSet<Message>();
        }

        public string Email { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<ConnectedDevice> ConnectedDevices { get; set; }
        public virtual ICollection<Message> MessagesFromUser { get; set; }
        public virtual ICollection<Message> MessagesToUser { get; set; }
    }
}
