namespace WebApiReagentes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_USUARIO
    {
        [Key]
        public int ID_USUARIO { get; set; }

        [Required]
        [StringLength(20)]
        public string DS_NOME { get; set; }

        [Required]
        [StringLength(15)]
        public string DS_SENHA { get; set; }

        [Required]
        [StringLength(50)]
        public string DS_EMAIL { get; set; }

        [Required]
        [StringLength(1)]
        public string DS_TIPO { get; set; }

        [Required]
        [StringLength(1)]
        public string DS_STATUS { get; set; }
    }
}
