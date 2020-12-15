using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using MyProductStore.Application.DTOs.Input;
using MyProductStore.Application.DTOs.Output;

namespace MyProductStore.Application.Commands.Products
{
    public class PatchProductCommand : IRequest<ProductOutputDto>
    {
        public int Id { get; set; }

        public JsonPatchDocument<ProductInputDto> JsonPatchDocument { get; set; }

        public PatchProductCommand(int id, JsonPatchDocument<ProductInputDto> jsonPatchDocument)
        {
            Id = id;
            JsonPatchDocument = jsonPatchDocument;
        }
    }
}
