using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEFFINAL
{
    internal class Produto
    {
        [Key]

        public int ID { get; set; }
        [StringLength(255)]
        public string NOME { get; set; }
        [StringLength(255)]
        public string Marca { get; set; }
        [StringLength(255)]
        public string PRECO { get; set; }
    }
}
