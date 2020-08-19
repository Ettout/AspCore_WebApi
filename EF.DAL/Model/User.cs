using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF.DAL.Model
{
    public class User : DomainObject
    {
        public string Name { get; set; }

        public string EmailAdress { get; set; }

        public string Tel { get; set; }

        public string Prename { get; set; }

        public string PassWord { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
