using System;
using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class Users : BaseModel
    {
        public Users()
        {
            ConnectedDevices = new HashSet<ConnectedDevices>();
            MessagesFromUser = new HashSet<Messages>();
            MessagesToUser = new HashSet<Messages>();
        }

        public string Email { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<ConnectedDevices> ConnectedDevices { get; set; }
        public virtual ICollection<Messages> MessagesFromUser { get; set; }
        public virtual ICollection<Messages> MessagesToUser { get; set; }
    }
}
