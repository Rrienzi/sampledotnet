using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAPI.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Fid { get; set; }
        public string FfirstName { get; set; }
        public string FlastName { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
