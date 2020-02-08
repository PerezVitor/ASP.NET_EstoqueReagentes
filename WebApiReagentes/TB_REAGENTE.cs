namespace WebApiReagentes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_REAGENTE
    {
        [Key]
        public int ID_REAGENTE { get; set; }

        [Required]
        [StringLength(50)]
        public string NM_DESCRICAO { get; set; }

        [Required]
        [StringLength(10)]
        public string CD_INTERNO { get; set; }

        [StringLength(15)]
        public string NR_CAS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal QT_PESO { get; set; }

        [Required]
        [StringLength(2)]
        public string UN_MEDIDA { get; set; }

        [StringLength(100)]
        public string DS_OBS { get; set; }

        [Required]
        [StringLength(1)]
        public string DS_STATUS { get; set; }
    }
}
