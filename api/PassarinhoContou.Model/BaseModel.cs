using System;

namespace PassarinhoContou.Model
{
    public class BaseModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual int Owner { get; set; }
    }
}
