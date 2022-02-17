using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCrud.Models
{
    [Table("clients")]
    internal class Client
    {
        [Column("id"), Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
