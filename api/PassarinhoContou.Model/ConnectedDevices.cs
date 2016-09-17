using System;
using System.Collections.Generic;

namespace PassarinhoContou.Model
{
    public partial class ConnectedDevices : BaseModel
    {
        public int UserId { get; set; }
        public string DeviceId { get; set; }
        public string ConfirmationCode { get; set; }

        public virtual Users User { get; set; }
    }
}
