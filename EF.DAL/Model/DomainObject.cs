using System;
using System.ComponentModel.DataAnnotations;

namespace EF.DAL.Model
{
    public class DomainObject
    {

        [Key]
        public int ID { get; set; }
    }
}
