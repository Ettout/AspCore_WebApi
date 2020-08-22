using System;
using System.Collections.Generic;
using EF.DAL.Model;

namespace projet_WebApi_1.Dtos
{
    public class CategoryReadDto
    {
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }

    }
}
