using System;

namespace MyProductStore.Application.DTOs.Input
{
    public class UserInputDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public DateTime BirthdDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
