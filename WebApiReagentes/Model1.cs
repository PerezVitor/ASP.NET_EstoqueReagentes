namespace WebApiReagentes
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=conexaoDb")
        {
        }

        public virtual DbSet<TB_EMPRESTIMO> TB_EMPRESTIMO { get; set; }
        public virtual DbSet<TB_REAGENTE> TB_REAGENTE { get; set; }
        public virtual DbSet<TB_USUARIO> TB_USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_EMPRESTIMO>()
                .Property(e => e.QT_PESO)
                .HasPrecision(7, 2);

            modelBuilder.Entity<TB_EMPRESTIMO>()
                .Property(e => e.DS_STATUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TB_REAGENTE>()
                .Property(e => e.NM_DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REAGENTE>()
                .Property(e => e.CD_INTERNO)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REAGENTE>()
                .Property(e => e.NR_CAS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REAGENTE>()
                .Property(e => e.QT_PESO)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TB_REAGENTE>()
                .Property(e => e.UN_MEDIDA)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REAGENTE>()
                .Property(e => e.DS_OBS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REAGENTE>()
                .Property(e => e.DS_STATUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TB_USUARIO>()
                .Property(e => e.DS_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USUARIO>()
                .Property(e => e.DS_SENHA)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USUARIO>()
                .Property(e => e.DS_EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USUARIO>()
                .Property(e => e.DS_TIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TB_USUARIO>()
                .Property(e => e.DS_STATUS)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
