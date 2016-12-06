using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassarinhoContou.Api.Model
{
    public class ApiResponseList<T>
        where T : class
    {
        public IEnumerable<T> List { get; private set; }
        public int Offset { get; private set; }
        public int Limit { get; private set; }
        public int Count { get; private set; }
        public int TotalCount { get; private set; }

        public ApiResponseList(IEnumerable<T> list, int offset, int limit, int totalCount)
        {
            this.List = list;
            this.Offset = offset;
            this.Limit = limit;
            this.TotalCount = totalCount;
            this.Count = list.Count();
        }
    }
}
