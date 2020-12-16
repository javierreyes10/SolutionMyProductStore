using System;

namespace MyProductStore.Application.DTOs.Output.User
{
    public class UserOutputDto : UserTokenOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthdDate { get; set; }

    }
}
