using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF.DAL.Model
{
    public class Category : DomainObject
    {


        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }

    }
}
