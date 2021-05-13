using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.database
{
    [Table("Usuario")]
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string Cuenta {set; get;}

        [Column("Clave")]
        public string Clave {set; get;}
        public string NombreCompleto {set; get;}
    }
}
