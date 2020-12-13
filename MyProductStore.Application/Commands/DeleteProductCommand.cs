﻿using MediatR;
using MyProductStore.Application.DTOs.Output;

namespace MyProductStore.Application.Commands
{
    public class DeleteProductCommand : IRequest<ProductOutputDto>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }

}
