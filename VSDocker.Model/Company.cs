using System;
using System.Collections.Generic;
using System.Text;

namespace VSDocker.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAcvite { get; set; }
        public bool IsSoftDelete { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }

    }
}
