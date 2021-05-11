namespace ClassLibrary1.database
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public int? IdCategoria { get; set; }

        [StringLength(2000)]
        public string Descripcion { get; set; }

        public int? Precio { get; set; }

        [StringLength(200)]
        public string Imagen { get; set; }

        public int? Destacado { get; set; }

        public int? Estrella { get; set; }

        public string ImagenBinario {set; get;}

   
        public virtual ProductoCategoria ProductoCategoria { get; set; }
    }
}
