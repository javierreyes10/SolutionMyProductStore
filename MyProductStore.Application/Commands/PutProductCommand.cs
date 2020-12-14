﻿using MyProductStore.Application.DTOs.Input;

namespace MyProductStore.Application.Commands
{
    public class PutProductCommand : BaseProductCommand
    {
        public int Id { get; set; }
        public PutProductCommand(int id, ProductInputDto product) : base(product)
        {
            Id = id;
        }
    }
}
