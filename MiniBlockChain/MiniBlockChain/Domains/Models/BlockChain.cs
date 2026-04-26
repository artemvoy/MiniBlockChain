using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Models
{
    public class BlockChain
    {
        public int Id { get; set; } 
        public string DocumentHash { get; set; } = null!;
        public string PreviousHash { get; set; } = null!;
        public DateTime Timestamp { get; set; }
    }
}
