using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeBelieveIT.Task.Tracker.Models
{
    public class Job
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Estimation { get; set; }
        public decimal? Remaining { get; set; }
        public int ProgressId { get; set; }
        public string? UserId { get; set; }
    }
}
