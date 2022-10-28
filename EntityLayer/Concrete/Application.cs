using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Parent { get; set; }
        public string Href { get; set; }
    }
}
