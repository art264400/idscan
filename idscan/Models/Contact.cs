using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace idscan.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsDeleted { get; set; }

        public Contact()
        {
            IsDeleted = false;
        }
    }
}
