using System.Collections.Generic;

namespace MyProductStore.Application.DTOs.Output
{
    public class PagedListOutputDto<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public PaginationMetadataOutput Metadata { get; set; }
    }
}
