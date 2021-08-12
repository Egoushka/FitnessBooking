using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessBooking.Core.Models.Requests
{
    public class GetUserRequest
    {
        public int? Id { get; set; }
        public int? RoleId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public GetUserRequest(int? id, int? roleId, string email, string name)
        {
            this.Id = id;
            this.RoleId = roleId;
            this.Email = email;
            this.Name = name;
        }
    }
}
