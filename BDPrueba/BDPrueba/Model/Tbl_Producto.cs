using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDPrueba.Model
{
    public class Tbl_Producto
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        
        [MaxLength(255)]
        [Column("Producto")]
        public string Nombre_Producto { get; set; }

        
        [Column("Precio")]
        public double Precio { get; set; }

        
        [Column("Fecha")]
        public DateTime Fecha_ingreso { get; set; }

       [Column("Hora")]
        public DateTime Hora_ingreso { get; set; }

    }
}
