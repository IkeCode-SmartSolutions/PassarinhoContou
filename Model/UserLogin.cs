using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassarinhoContou.Model
{
    public partial class UserLogin : BaseModel
    {
        public UserLogin()
        {
            
        }

        public int UserId { get; set; }
        public string Password { get; set; }

        public virtual User User { get; set; }
    }
}
