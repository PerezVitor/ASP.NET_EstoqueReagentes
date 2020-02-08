namespace WebApiReagentes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_EMPRESTIMO
    {
        [Key]
        public int ID_EMPRESTIMO { get; set; }

        public int ID_USUARIO { get; set; }

        public int ID_REAGENTE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal QT_PESO { get; set; }

        [Column(TypeName = "date")]
        public DateTime DT_EMPRESTIMO { get; set; }

        [Required]
        [StringLength(1)]
        public string DS_STATUS { get; set; }
    }
}
