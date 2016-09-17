using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassarinhoContou.Model
{
    public class BaseModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual int Owner { get; set; }
    }
}
