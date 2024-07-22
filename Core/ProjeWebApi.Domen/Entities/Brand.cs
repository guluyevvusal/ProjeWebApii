using ProjeWebApi.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Domen.Entities
{
    public class Brand:Entitybase
    {
        public Brand(string name)
        {
            Name = name;
        }

        public Brand()
        {
            
        }

        public  string Name { get; set; }

    }
}
