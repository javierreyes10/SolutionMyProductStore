using Microsoft.AspNetCore.Http;
using MyProductStore.Application.DTOs.Output;
using Newtonsoft.Json;

namespace MyProductStore.API.Helpers
{
    public static class HttpResponseHelper
    {
        public static void AddPaginationMetadata(this HttpResponse response, PaginationMetadataOutput metadata)
        {
            response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        }
    }
}
