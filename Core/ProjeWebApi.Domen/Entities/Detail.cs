using ProjeWebApi.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Domen.Entities
{
    public class Detail:Entitybase
    {
        public Detail()
        {
            
        }

        public Detail(string title, string description, int categoryId)
        {
            Title = title;
            Description = description;
            CategoryId = categoryId;
        }


        public  string Title { get; set; }
        public  string Description { get; set; }
        public  int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
