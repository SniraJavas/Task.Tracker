using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeBelieveIT.Task.Tracker.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int TittleId { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
