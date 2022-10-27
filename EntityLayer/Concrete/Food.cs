using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int FoodCategoryId { get; set; }
        public virtual FoodCategory FoodCategory { get; set; }
    }
}
