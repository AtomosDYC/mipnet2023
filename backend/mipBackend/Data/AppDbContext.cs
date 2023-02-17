using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mipBackend.Models;

namespace mipBackend.Data
{
    public class AppDbContext: IdentityDbContext<Usuario>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            
            modelBuilder.Entity<Blk01Bloqueo>(entity =>
            {
                entity.HasKey(e => e.Blk01Llave);

                entity.ToTable("BLK01_Bloqueos");

                entity.Property(e => e.Blk01Llave)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BLK01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Blk01Activo).HasColumnName("BLK01_Activo");
                entity.Property(e => e.Blk01Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("BLK01_Descripcion");
                entity.Property(e => e.Blk01MaxDuraciondia).HasColumnName("BLK01_MaxDuraciondia");
                entity.Property(e => e.Blk01MinDuraciondia).HasColumnName("BLK01_MinDuraciondia");
                entity.Property(e => e.Blk01NombreBloqueo)
                    .HasMaxLength(500)
                    .HasColumnName("BLK01_NombreBloqueo");
                entity.Property(e => e.Blk01Permanente).HasColumnName("BLK01_Permanente");
                entity.Property(e => e.Blk02Llave)
                    
                    .HasColumnName("BLK02_Llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");

                entity.HasOne(d => d.Blk02LlaveNavigation).WithMany(p => p.Blk01Bloqueos)
                    .HasForeignKey(d => d.Blk02Llave)
                    .HasConstraintName("FK_BLK01_Bloqueos_BLK02_TipoBloqueo");
            });

            modelBuilder.Entity<Blk02TipoBloqueo>(entity =>
            {
                entity.HasKey(e => e.Blk02Llave);

                entity.ToTable("BLK02_TipoBloqueo");

                entity.Property(e => e.Blk02Llave)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BLK02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Blk02Activo).HasColumnName("BLK02_Activo");
                entity.Property(e => e.Blk02Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("BLK02_Descripcion");
                entity.Property(e => e.Blk02Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("BLK02_Nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Blk03BloqueoUsuario>(entity =>
            {
                entity.HasKey(e => e.Blk03Llave);

                entity.ToTable("BLK03_BloqueoUsuario");

                entity.Property(e => e.Blk03Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("BLK03_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Blk01Llave)
                    
                    .HasColumnName("BLK01_Llave");
                entity.Property(e => e.Blk03Activo).HasColumnName("BLK03_Activo");
                entity.Property(e => e.Blk03FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("BLK03_FechaInicio");
                entity.Property(e => e.Blk03FechaTermino)
                    .HasColumnType("datetime")
                    .HasColumnName("BLK03_FechaTermino");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");

                entity.HasOne(d => d.Blk01LlaveNavigation).WithMany(p => p.Blk03BloqueoUsuarios)
                    .HasForeignKey(d => d.Blk01Llave)
                    .HasConstraintName("FK_BLK03_BloqueoUsuario_BLK01_Bloqueos");
            });

            modelBuilder.Entity<Clbr01Calibracion>(entity =>
            {
                entity.HasKey(e => e.Clbr01Llave);

                entity.ToTable("CLBR01_Calibracion");

                entity.Property(e => e.Clbr01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CLBR01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Clbr01Activo).HasColumnName("CLBR01_Activo");
                entity.Property(e => e.Clbr01Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("CLBR01_Descripcion");
                entity.Property(e => e.Clbr01FechaCalibracion)
                    .HasColumnType("datetime")
                    .HasColumnName("CLBR01_FechaCalibracion");
                entity.Property(e => e.Clbr01Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CLBR01_Nombre");
                entity.Property(e => e.Clbr01UrlPdf)
                    .HasMaxLength(1000)
                    .HasColumnName("CLBR01_UrlPdf");
                entity.Property(e => e.Clbr02Llave)
                    
                    .HasColumnName("CLBR02_Llave");
                entity.Property(e => e.Cnt01Llave)
                    
                    .HasColumnName("CNT01_Llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Sercl01Llave)
                    
                    .HasColumnName("SERCL01_Llave");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");

                entity.HasOne(d => d.Clbr02LlaveNavigation).WithMany(p => p.Clbr01Calibracions)
                    .HasForeignKey(d => d.Clbr02Llave)
                    .HasConstraintName("FK_CLBR01_Calibracion_CLBR02_TipoCalibracion");
            });

            modelBuilder.Entity<Clbr02TipoCalibracion>(entity =>
            {
                entity.HasKey(e => e.Clbr02Llave);

                entity.ToTable("CLBR02_TipoCalibracion");

                entity.Property(e => e.Clbr02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CLBR02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Clbr02Activo).HasColumnName("CLBR02_Activo");
                entity.Property(e => e.Clbr02Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("CLBR02_Descripcion");
                entity.Property(e => e.Clbr02Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CLBR02_Nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Cnt01CuentaCliente>(entity =>
            {
                entity.HasKey(e => e.Cnt01Llave);

                entity.ToTable("CNT01_CuentaCliente");

                entity.Property(e => e.Cnt01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt01Activo).HasColumnName("CNT01_Activo");
                entity.Property(e => e.Cnt01AnioIngreso)
                    .HasColumnType("date")
                    .HasColumnName("CNT01_anioIngreso");
                entity.Property(e => e.Cnt01CuentaSap).HasColumnName("CNT01_CuentaSap");
                entity.Property(e => e.Cnt01FechaIngresoSap)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT01_FechaIngresoSap");
                entity.Property(e => e.Cnt01Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CNT01_Nombre");
                entity.Property(e => e.Cnt01NumeroSap).HasColumnName("CNT01_NumeroSap");
                entity.Property(e => e.Cnt02Llave)
                    
                    .HasColumnName("CNT02_Llave");
                entity.Property(e => e.Cnt03Llave)
                    
                    .HasColumnName("CNT03_Llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Per01Llave)
                    
                    .HasColumnName("PER01_Llave");

                entity.HasOne(d => d.Cnt02LlaveNavigation).WithMany(p => p.Cnt01CuentaClientes)
                    .HasForeignKey(d => d.Cnt02Llave)
                    .HasConstraintName("FK_CNT01_CuentaCliente_CNT02_TipoCuenta");

                entity.HasOne(d => d.Cnt03LlaveNavigation).WithMany(p => p.Cnt01CuentaClientes)
                    .HasForeignKey(d => d.Cnt03Llave)
                    .HasConstraintName("FK_CNT01_CuentaCliente_CNT03_TipoCliente");

                entity.HasOne(d => d.Per01LlaveNavigation).WithMany(p => p.Cnt01CuentaClientes)
                    .HasForeignKey(d => d.Per01Llave)
                    .HasConstraintName("FK_CNT01_CuentaCliente_PER01_Persona");
            });

            modelBuilder.Entity<Cnt02TipoCuenta>(entity =>
            {
                entity.HasKey(e => e.Cnt02Llave);

                entity.ToTable("CNT02_TipoCuenta");

                entity.Property(e => e.Cnt02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt02Activo).HasColumnName("CNT02_Activo");
                entity.Property(e => e.Cnt02Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("CNT02_Descripcion");
                entity.Property(e => e.Cnt02Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CNT02_Nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Cnt03TipoCliente>(entity =>
            {
                entity.HasKey(e => e.Cnt03Llave);

                entity.ToTable("CNT03_TipoCliente");

                entity.Property(e => e.Cnt03Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT03_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt03Activo)
                    
                    .HasColumnName("CNT03_Activo");
                entity.Property(e => e.Cnt03Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT03_Descripcion");
                entity.Property(e => e.Cnt03Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("CNT03_Nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Per03Llave)
                    
                    .HasColumnName("PER03_Llave");

                entity.HasOne(d => d.Per03LlaveNavigation).WithMany(p => p.Cnt03TipoClientes)
                    .HasForeignKey(d => d.Per03Llave)
                    .HasConstraintName("FK_CNT03_TipoCliente_PER03_TipoPersona");
            });

            modelBuilder.Entity<Cnt04ContactoCliente>(entity =>
            {
                entity.HasKey(e => e.Cnt04Llave);

                entity.ToTable("CNT04_ContactoCliente");

                entity.Property(e => e.Cnt04Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT04_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt01Llave)
                    
                    .HasColumnName("CNT01_Llave");
                entity.Property(e => e.Cnt04Activo).HasColumnName("CNT04_Activo");
                entity.Property(e => e.Cnt05Llave)
                    
                    .HasColumnName("CNT05_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Per01Llave)
                    
                    .HasColumnName("PER01_Llave");

                entity.HasOne(d => d.Cnt01LlaveNavigation).WithMany(p => p.Cnt04ContactoClientes)
                    .HasForeignKey(d => d.Cnt01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT04_ContactoCliente_CNT01_CuentaCliente1");

                entity.HasOne(d => d.Cnt05LlaveNavigation).WithMany(p => p.Cnt04ContactoClientes)
                    .HasForeignKey(d => d.Cnt05Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT04_ContactoCliente_CNT05_TipoContacto");
            });

            modelBuilder.Entity<Cnt05TipoContacto>(entity =>
            {
                entity.HasKey(e => e.Cnt05Llave);

                entity.ToTable("CNT05_TipoContacto");

                entity.Property(e => e.Cnt05Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT05_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt05Activo).HasColumnName("CNT05_Activo");
                entity.Property(e => e.Cnt05Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT05_descripcion");
                entity.Property(e => e.Cnt05Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("CNT05_Nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Cnt06ComunicacionCliente>(entity =>
            {
                entity.HasKey(e => e.Cnt06Llave);

                entity.ToTable("CNT06_ComunicacionCliente");

                entity.Property(e => e.Cnt06Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT06_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt01Llave)
                    
                    .HasColumnName("CNT01_Llave");
                entity.Property(e => e.Cnt06Activo).HasColumnName("CNT06_Activo");
                entity.Property(e => e.Cnt06Casilla)
                    .HasMaxLength(500)
                    .HasColumnName("CNT06_casilla");
                entity.Property(e => e.Cnt06Celular1)
                    .HasMaxLength(50)
                    .HasColumnName("CNT06_Celular1");
                entity.Property(e => e.Cnt06Celular2)
                    .HasMaxLength(50)
                    .HasColumnName("CNT06_Celular2");
                entity.Property(e => e.Cnt06CodigoPostal)
                    .HasMaxLength(500)
                    .HasColumnName("CNT06_CodigoPostal");
                entity.Property(e => e.Cnt06Direccion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT06_Direccion");
                entity.Property(e => e.Cnt06Email)
                    .HasMaxLength(250)
                    .HasColumnName("CNT06_Email");
                entity.Property(e => e.Cnt06Fax)
                    .HasMaxLength(50)
                    .HasColumnName("CNT06_Fax");
                entity.Property(e => e.Cnt06SitioWeb)
                    .HasMaxLength(50)
                    .HasColumnName("CNT06_SitioWeb");
                entity.Property(e => e.Cnt06Telefono1)
                    .HasMaxLength(50)
                    .HasColumnName("CNT06_Telefono1");
                entity.Property(e => e.Cnt06Telefono2)
                    .HasMaxLength(50)
                    .HasColumnName("CNT06_Telefono2");
                entity.Property(e => e.Cnt06TieneCasilla).HasColumnName("CNT06_TieneCasilla");
                entity.Property(e => e.Cnt06TipoMail)
                    
                    .HasColumnName("CNT06_TipoMail");
                entity.Property(e => e.Cnt08Llave)
                    
                    .HasColumnName("CNT08_Llave");
                entity.Property(e => e.Cnt10Llave)
                    
                    .HasColumnName("CNT10_Llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Sist03Llave)
                    
                    .HasColumnName("SIST03_Llave");

                entity.HasOne(d => d.Cnt01LlaveNavigation).WithMany(p => p.Cnt06ComunicacionClientes)
                    .HasForeignKey(d => d.Cnt01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT06_ComunicacionCliente_CNT01_CuentaCliente");

                entity.HasOne(d => d.Cnt08LlaveNavigation).WithMany(p => p.Cnt06ComunicacionClientes)
                    .HasForeignKey(d => d.Cnt08Llave)
                    .HasConstraintName("FK_CNT06_ComunicacionCliente_CNT08_Segmentacion");

                entity.HasOne(d => d.Cnt10LlaveNavigation).WithMany(p => p.Cnt06ComunicacionClientes)
                    .HasForeignKey(d => d.Cnt10Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT06_ComunicacionCliente_CNT10_TipoComunicacion");

                entity.HasOne(d => d.Sist03LlaveNavigation).WithMany(p => p.Cnt06ComunicacionClientes)
                    .HasForeignKey(d => d.Sist03Llave)
                    .HasConstraintName("FK_CNT06_ComunicacionCliente_SIST03_Comuna");
            });

            modelBuilder.Entity<Cnt07TipoSegmentacion>(entity =>
            {
                entity.HasKey(e => e.Cnt07Llave);

                entity.ToTable("CNT07_TipoSegmentacion");

                entity.Property(e => e.Cnt07Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT07_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt02Llave)
                    
                    .HasColumnName("CNT02_Llave");
                entity.Property(e => e.Cnt07Activo).HasColumnName("CNT07_Activo");
                entity.Property(e => e.Cnt07Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT07_Descripcion");
                entity.Property(e => e.Cnt07Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("CNT07_Nombre");
                entity.Property(e => e.Cnt18Llave)
                    
                    .HasColumnName("CNT18_Llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");

                entity.HasOne(d => d.Cnt18LlaveNavigation).WithMany(p => p.Cnt07TipoSegmentacions)
                    .HasForeignKey(d => d.Cnt18Llave)
                    .HasConstraintName("FK_CNT07_TipoSegmentacion_CNT18_NivelSegmentacion");
            });

            modelBuilder.Entity<Cnt08Segmentacion>(entity =>
            {
                entity.HasKey(e => e.Cnt08Llave);

                entity.ToTable("CNT08_Segmentacion");

                entity.Property(e => e.Cnt08Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT08_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt01Llave)
                    
                    .HasColumnName("CNT01_Llave");
                entity.Property(e => e.Cnt07Llave)
                    
                    .HasColumnName("CNT07_Llave");
                entity.Property(e => e.Cnt08Activo).HasColumnName("CNT08_Activo");
                entity.Property(e => e.Cnt08LlavePadre)
                    
                    .HasColumnName("CNT08_LlavePadre");
                entity.Property(e => e.Cnt08Nombre)
                    .HasMaxLength(500)
                    .HasColumnName("CNT08_Nombre");
                entity.Property(e => e.Cnt21Llave)
                    .HasDefaultValueSql("((1))")
                    
                    .HasColumnName("CNT21_Llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Sist03Llave)
                    
                    .HasColumnName("SIST03_Llave");

                entity.HasOne(d => d.Cnt01LlaveNavigation).WithMany(p => p.Cnt08Segmentacions)
                    .HasForeignKey(d => d.Cnt01Llave)
                    .HasConstraintName("FK_CNT08_Segmentacion_CNT01_CuentaCliente");

                entity.HasOne(d => d.Cnt07LlaveNavigation).WithMany(p => p.Cnt08Segmentacions)
                    .HasForeignKey(d => d.Cnt07Llave)
                    .HasConstraintName("FK_CNT08_Segmentacion_CNT07_TipoSegmentacion");

                entity.HasOne(d => d.Cnt08LlavePadreNavigation).WithMany(p => p.InverseCnt08LlavePadreNavigation)
                    .HasForeignKey(d => d.Cnt08LlavePadre)
                    .HasConstraintName("FK_CNT08_Segmentacion_CNT08_Segmentacion");
            });

            modelBuilder.Entity<Cnt09ComunicacionSegmentacion>(entity =>
            {
                entity.HasKey(e => e.Cnt09Llave);

                entity.ToTable("CNT09_ComunicacionSegmentacion");

                entity.Property(e => e.Cnt09Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT09_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt08Llave)
                    
                    .HasColumnName("CNT08_Llave");
                entity.Property(e => e.Cnt09Activo).HasColumnName("CNT09_Activo");
                entity.Property(e => e.Cnt09Casilla)
                    .HasMaxLength(500)
                    .HasColumnName("CNT09_casilla");
                entity.Property(e => e.Cnt09Celular1)
                    .HasMaxLength(50)
                    .HasColumnName("CNT09_Celular1");
                entity.Property(e => e.Cnt09Celular2)
                    .HasMaxLength(50)
                    .HasColumnName("CNT09_Celular2");
                entity.Property(e => e.Cnt09CodigoPostal)
                    .HasMaxLength(500)
                    .HasColumnName("CNT09_CodigoPostal");
                entity.Property(e => e.Cnt09Direccion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT09_Direccion");
                entity.Property(e => e.Cnt09Email)
                    .HasMaxLength(250)
                    .HasColumnName("CNT09_Email");
                entity.Property(e => e.Cnt09Fax)
                    .HasMaxLength(50)
                    .HasColumnName("CNT09_Fax");
                entity.Property(e => e.Cnt09SinCasilla).HasColumnName("CNT09_SinCasilla");
                entity.Property(e => e.Cnt09SitioWeb)
                    .HasMaxLength(50)
                    .HasColumnName("CNT09_SitioWeb");
                entity.Property(e => e.Cnt09Telefono1)
                    .HasMaxLength(50)
                    .HasColumnName("CNT09_Telefono1");
                entity.Property(e => e.Cnt09Telefono2)
                    .HasMaxLength(50)
                    .HasColumnName("CNT09_Telefono2");
                entity.Property(e => e.Cnt09TipoMail)
                    
                    .HasColumnName("CNT09_TipoMail");
                entity.Property(e => e.Cnt10Llave)
                    
                    .HasColumnName("CNT10_Llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Sist03Llave)
                    
                    .HasColumnName("SIST03_Llave");

                entity.HasOne(d => d.Cnt08LlaveNavigation).WithMany(p => p.Cnt09ComunicacionSegmentacions)
                    .HasForeignKey(d => d.Cnt08Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT09_ComunicacionSegmentacion_CNT08_Segmentacion");
            });

            modelBuilder.Entity<Cnt10TipoComunicacion>(entity =>
            {
                entity.HasKey(e => e.Cnt10Llave);

                entity.ToTable("CNT10_TipoComunicacion");

                entity.Property(e => e.Cnt10Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT10_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt10Activo).HasColumnName("CNT10_Activo");
                entity.Property(e => e.Cnt10Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT10_Descripcion");
                entity.Property(e => e.Cnt10Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CNT10_Nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Cnt11ContactoSegmentacion>(entity =>
            {
                entity.HasKey(e => e.Cnt11Llave);

                entity.ToTable("CNT11_ContactoSegmentacion");

                entity.Property(e => e.Cnt11Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT11_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt05Llave)
                    
                    .HasColumnName("CNT05_llave");
                entity.Property(e => e.Cnt08Llave)
                    
                    .HasColumnName("CNT08_Llave");
                entity.Property(e => e.Cnt11Activo).HasColumnName("CNT11_Activo");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Per01Llave)
                    
                    .HasColumnName("PER01_Llave");

                entity.HasOne(d => d.Cnt08LlaveNavigation).WithMany(p => p.Cnt11ContactoSegmentacions)
                    .HasForeignKey(d => d.Cnt08Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT11_ContactoSegmentacion_CNT08_Segmentacion");
            });

            modelBuilder.Entity<Cnt12Empleado>(entity =>
            {
                entity.HasKey(e => e.Cnt12Llave);

                entity.ToTable("CNT12_Empleados");

                entity.Property(e => e.Cnt12Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT12_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt01Llave)
                    
                    .HasColumnName("CNT01_Llave");
                entity.Property(e => e.Cnt08Llave)
                    
                    .HasColumnName("CNT08_Llave");
                entity.Property(e => e.Cnt12Activo).HasColumnName("CNT12_Activo");
                entity.Property(e => e.Cnt12Cargo)
                    .HasMaxLength(500)
                    .HasColumnName("CNT12_Cargo");
                entity.Property(e => e.Cnt13Llave)
                    
                    .HasColumnName("CNT13_Llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Per01Llave)
                    
                    .HasColumnName("PER01_Llave");

                entity.HasOne(d => d.Cnt01LlaveNavigation).WithMany(p => p.Cnt12Empleados)
                    .HasForeignKey(d => d.Cnt01Llave)
                    .HasConstraintName("FK_CNT12_Empleados_CNT01_CuentaCliente");

                entity.HasOne(d => d.Cnt13LlaveNavigation).WithMany(p => p.Cnt12Empleados)
                    .HasForeignKey(d => d.Cnt13Llave)
                    .HasConstraintName("FK_CNT12_Empleados_CNT13_TipoEmpleado");

                entity.HasOne(d => d.Per01LlaveNavigation).WithMany(p => p.Cnt12Empleados)
                    .HasForeignKey(d => d.Per01Llave)
                    .HasConstraintName("FK_CNT12_Empleados_PER01_Persona");
            });

            modelBuilder.Entity<Cnt13TipoEmpleado>(entity =>
            {
                entity.HasKey(e => e.Cnt13Llave);

                entity.ToTable("CNT13_TipoEmpleado");

                entity.Property(e => e.Cnt13Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT13_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt13Activo).HasColumnName("CNT13_Activo");
                entity.Property(e => e.Cnt13Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT13_Descripcion");
                entity.Property(e => e.Cnt13Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CNT13_Nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Cnt14ClienteLicencia>(entity =>
            {
                entity.HasKey(e => e.Cnt14Llave);

                entity.ToTable("CNT14_ClienteLicencia");

                entity.Property(e => e.Cnt14Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT14_Llave");
                entity.Property(e => e.Cnt01Llave)
                    
                    .HasColumnName("CNT01_Llave");
                entity.Property(e => e.Cnt14Activo).HasColumnName("CNT14_Activo");
                entity.Property(e => e.Cnt14CantUsuarios).HasColumnName("CNT14_CantUsuarios");
                entity.Property(e => e.Cnt14InicioFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT14_InicioFecha");
                entity.Property(e => e.Cnt14TerminoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT14_TerminoFecha");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Lnc01Llave)
                    
                    .HasColumnName("LNC01_Llave");

                entity.HasOne(d => d.Cnt01LlaveNavigation).WithMany(p => p.Cnt14ClienteLicencia)
                    .HasForeignKey(d => d.Cnt01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT14_ClienteLicencia_CNT01_CuentaCliente");
            });

            modelBuilder.Entity<Cnt15EmpleadoLicencia>(entity =>
            {


                entity.HasKey(e => new { e.Cnt19Llave, e.Cnt12Llave }).HasName("PK_CNT15_EmpleadoLicencia_1");

                entity.ToTable("CNT15_EmpleadoLicencia");

                entity.Property(e => e.Cnt19Llave)
                    
                    .HasColumnName("CNT19_Llave");
                entity.Property(e => e.Cnt12Llave)
                    
                    .HasColumnName("CNT12_Llave");
                entity.Property(e => e.Cnt15AceptaContrato).HasColumnName("CNT15_AceptaContrato");
                entity.Property(e => e.Cnt15Fechafirma)
                    .HasColumnType("date")
                    .HasColumnName("CNT15_fechafirma");

                entity.HasOne(d => d.Cnt12LlaveNavigation).WithMany(p => p.Cnt15EmpleadoLicencia)
                    .HasForeignKey(d => d.Cnt12Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT15_EmpleadoLicencia_CNT12_Empleados");

                entity.HasOne(d => d.Cnt19LlaveNavigation).WithMany(p => p.Cnt15EmpleadoLicencia)
                    .HasForeignKey(d => d.Cnt19Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT15_EmpleadoLicencia_CNT19_LicenciaCliente");
            });

            modelBuilder.Entity<Cnt16TipoBloqueoCliente>(entity =>
            {
                entity.HasKey(e => e.Cnt16Llave);

                entity.ToTable("CNT16_TipoBloqueoCliente");

                entity.Property(e => e.Cnt16Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT16_Llave");
                entity.Property(e => e.Cnt16Activo).HasColumnName("CNT16_Activo");
                entity.Property(e => e.Cnt16Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT16_Descripcion");
                entity.Property(e => e.Cnt16Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CNT16_Nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Cnt17Bloqueo>(entity =>
            {
                entity.HasKey(e => e.Cnt17Llave);

                entity.ToTable("CNT17_Bloqueos");

                entity.Property(e => e.Cnt17Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT17_Llave");
                entity.Property(e => e.Blk01Llave)
                    
                    .HasColumnName("BLK01_Llave");
                entity.Property(e => e.Cnt01Llave)
                    
                    .HasColumnName("CNT01_Llave");
                entity.Property(e => e.Cnt08Llave)
                    
                    .HasColumnName("CNT08_Llave");
                entity.Property(e => e.Cnt14Llave)
                    
                    .HasColumnName("CNT14_Llave");
                entity.Property(e => e.Cnt16Llave)
                    
                    .HasColumnName("CNT16_Llave");
                entity.Property(e => e.Cnt17Activo).HasColumnName("CNT17_Activo");
                entity.Property(e => e.Cnt17InicioBloqueo)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT17_InicioBloqueo");
                entity.Property(e => e.Cnt17TerminoBloqueo)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT17_TerminoBloqueo");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Per01Llave)
                    
                    .HasColumnName("PER01_Llave");

                entity.HasOne(d => d.Blk01LlaveNavigation).WithMany(p => p.Cnt17Bloqueos)
                    .HasForeignKey(d => d.Blk01Llave)
                    .HasConstraintName("FK_CNT17_Bloqueos_BLK01_Bloqueos");

                entity.HasOne(d => d.Cnt01LlaveNavigation).WithMany(p => p.Cnt17Bloqueos)
                    .HasForeignKey(d => d.Cnt01Llave)
                    .HasConstraintName("FK_CNT17_Bloqueos_CNT01_CuentaCliente");

                entity.HasOne(d => d.Cnt08LlaveNavigation).WithMany(p => p.Cnt17Bloqueos)
                    .HasForeignKey(d => d.Cnt08Llave)
                    .HasConstraintName("FK_CNT17_Bloqueos_CNT08_Segmentacion");

                entity.HasOne(d => d.Cnt14LlaveNavigation).WithMany(p => p.Cnt17Bloqueos)
                    .HasForeignKey(d => d.Cnt14Llave)
                    .HasConstraintName("FK_CNT17_Bloqueos_CNT14_ClienteLicencia");

                entity.HasOne(d => d.Cnt16LlaveNavigation).WithMany(p => p.Cnt17Bloqueos)
                    .HasForeignKey(d => d.Cnt16Llave)
                    .HasConstraintName("FK_CNT17_Bloqueos_CNT16_TipoBloqueoCliente");
            });

            modelBuilder.Entity<Cnt18NivelSegmentacion>(entity =>
            {
                entity.HasKey(e => e.Cnt18Llave);

                entity.ToTable("CNT18_NivelSegmentacion");

                entity.Property(e => e.Cnt18Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT18_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt18Activo).HasColumnName("CNT18_Activo");
                entity.Property(e => e.Cnt18Descripccion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT18_Descripccion");
                entity.Property(e => e.Cnt18NivelCapa).HasColumnName("CNT18_NivelCapa");
                entity.Property(e => e.Cnt18Nombre)
                    .HasMaxLength(500)
                    .HasColumnName("CNT18_Nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Cnt19LicenciaCliente>(entity =>
            {
                entity.HasKey(e => e.Cnt19Llave);

                entity.ToTable("CNT19_LicenciaCliente");

                entity.Property(e => e.Cnt19Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT19_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt01Llave)
                    
                    .HasColumnName("CNT01_Llave");
                entity.Property(e => e.Cnt19Activo).HasColumnName("CNT19_Activo");
                entity.Property(e => e.Cnt19FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT19_FechaInicio");
                entity.Property(e => e.Cnt19FechaTermino)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT19_FechaTermino");
                entity.Property(e => e.Cnt19NombreLicencia)
                    .HasMaxLength(500)
                    .HasColumnName("CNT19_NombreLicencia");
                entity.Property(e => e.Cnt19NumeroDias).HasColumnName("CNT19_NumeroDias");
                entity.Property(e => e.Cnt19NumeroUsuario).HasColumnName("CNT19_NumeroUsuario");
                entity.Property(e => e.Cnt19ValorReferencial)
                    
                    .HasColumnName("CNT19_valor_referencial");
                entity.Property(e => e.Cnt23Llave)
                    
                    .HasColumnName("CNT23_Llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Lnc01Llave)
                    
                    .HasColumnName("LNC01_Llave");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");

                entity.HasOne(d => d.Cnt01LlaveNavigation).WithMany(p => p.Cnt19LicenciaClientes)
                    .HasForeignKey(d => d.Cnt01Llave)
                    .HasConstraintName("FK_CNT19_LicenciaCliente_CNT01_CuentaCliente");
            });

            modelBuilder.Entity<Cnt20LicenciaServicio>(entity =>
            {
                entity.HasKey(e => new { e.Cnt19Llave, e.Serv01Llave });

                entity.ToTable("CNT20_LicenciaServicio");

                entity.Property(e => e.Cnt19Llave)
                    
                    .HasColumnName("CNT19_Llave");
                entity.Property(e => e.Serv01Llave)
                    
                    .HasColumnName("SERV01_Llave");
                entity.Property(e => e.Cnt20Habilitaservicio).HasColumnName("CNT20_habilitaservicio");
                entity.Property(e => e.Cnt20Valor)
                    
                    .HasColumnName("CNT20_Valor");

                entity.HasOne(d => d.Cnt19LlaveNavigation).WithMany(p => p.Cnt20LicenciaServicios)
                    .HasForeignKey(d => d.Cnt19Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT20_LicenciaServicio_CNT19_LicenciaCliente");
            });

            modelBuilder.Entity<Cnt21TipoEstacion>(entity =>
            {
                entity.HasKey(e => e.Cnt21Llave);

                entity.ToTable("CNT21_TipoEstacion");

                entity.Property(e => e.Cnt21Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT21_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt21Activo).HasColumnName("CNT21_Activo");
                entity.Property(e => e.Cnt21Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("CNT21_Descripcion");
                entity.Property(e => e.Cnt21Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CNT21_Nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Cnt22EstacionTipoEstacion>(entity =>
            {
                entity.HasKey(e => new { e.Cnt08Llave, e.Cnt21Llave });

                entity.ToTable("CNT22_Estacion_TipoEstacion");

                entity.Property(e => e.Cnt08Llave)
                    
                    .HasColumnName("CNT08_Llave");
                entity.Property(e => e.Cnt21Llave)
                    
                    .HasColumnName("CNT21_llave");
                entity.Property(e => e.Cnt22Estado).HasColumnName("CNT22_estado");

                entity.HasOne(d => d.Cnt08LlaveNavigation).WithMany(p => p.Cnt22EstacionTipoEstacions)
                    .HasForeignKey(d => d.Cnt08Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT22_Estacion_TipoEstacion_CNT08_Segmentacion");

                entity.HasOne(d => d.Cnt21LlaveNavigation).WithMany(p => p.Cnt22EstacionTipoEstacions)
                    .HasForeignKey(d => d.Cnt21Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT22_Estacion_TipoEstacion_CNT21_TipoEstacion");
            });

            modelBuilder.Entity<Cnt23Tipocobro>(entity =>
            {
                entity.HasKey(e => e.Cnt23Llave);

                entity.ToTable("CNT23_Tipocobro");

                entity.Property(e => e.Cnt23Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CNT23_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt23Activo).HasColumnName("CNT23_Activo");
                entity.Property(e => e.Cnt23Descripcion)
                    .HasMaxLength(2000)
                    .HasColumnName("CNT23_Descripcion");
                entity.Property(e => e.Cnt23Nombre)
                    .HasMaxLength(500)
                    .HasColumnName("CNT23_Nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Cnt24AsociarCuenta>(entity =>
            {
                entity.HasKey(e => new { e.Cnt01Llave, e.Cnt01CuentaLlave });

                entity.ToTable("CNT24_AsociarCuenta");

                entity.Property(e => e.Cnt01Llave)
                    
                    .HasColumnName("CNT01_Llave");
                entity.Property(e => e.Cnt01CuentaLlave)
                    
                    .HasColumnName("CNT01_Cuenta_Llave");
            });

            modelBuilder.Entity<Cont01Contacto>(entity =>
            {
                entity.HasKey(e => e.Cont01Llave);

                entity.ToTable("CONT01_Contacto");

                entity.Property(e => e.Cont01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CONT01_Llave");
                entity.Property(e => e.Cont01Apellido)
                    .HasMaxLength(250)
                    .HasColumnName("CONT01_Apellido");
                entity.Property(e => e.Cont01CodigoValidacion)
                    .HasMaxLength(250)
                    .HasColumnName("CONT01_CodigoValidacion");
                entity.Property(e => e.Cont01Direccion)
                    .HasMaxLength(250)
                    .HasColumnName("CONT01_Direccion");
                entity.Property(e => e.Cont01Email)
                    .HasMaxLength(250)
                    .HasColumnName("CONT01_Email");
                entity.Property(e => e.Cont01Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CONT01_Nombre");
                entity.Property(e => e.Cont01PeticionContacto)
                    .HasMaxLength(500)
                    .HasColumnName("CONT01_PeticionContacto");
                entity.Property(e => e.Cont01Telefono)
                    .HasMaxLength(250)
                    .HasColumnName("CONT01_Telefono");
                entity.Property(e => e.Cont01Titulo)
                    
                    .HasColumnName("CONT01_Titulo");
                entity.Property(e => e.Cont02Llave)
                    
                    .HasColumnName("CONT02_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");

                entity.HasOne(d => d.Cont02LlaveNavigation).WithMany(p => p.Cont01Contactos)
                    .HasForeignKey(d => d.Cont02Llave)
                    .HasConstraintName("FK_CONT01_Contacto_CONT02_TipoContacto");
            });

            modelBuilder.Entity<Cont02TipoContacto>(entity =>
            {
                entity.HasKey(e => e.Cont02Llave);

                entity.ToTable("CONT02_TipoContacto");

                entity.Property(e => e.Cont02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CONT02_Llave");
                entity.Property(e => e.Cont02Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("CONT02_Descripcion");
                entity.Property(e => e.Cont02Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CONT02_Nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Conteo01Conteo>(entity =>
            {
                entity.HasKey(e => e.Conteo01Llave);

                entity.ToTable("CONTEO01_Conteos");

                entity.Property(e => e.Conteo01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CONTEO01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Conteo01EstadoConteo).HasColumnName("CONTEO01_EstadoConteo");
                entity.Property(e => e.Conteo01EstadoVisado).HasColumnName("CONTEO01_EstadoVisado");
                entity.Property(e => e.Conteo01FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("CONTEO01_FechaIngreso");
                entity.Property(e => e.Conteo01HoraIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("CONTEO01_HoraIngreso");
                entity.Property(e => e.Conteo01Observacion)
                    .HasMaxLength(200)
                    .HasColumnName("CONTEO01_observacion");
                entity.Property(e => e.Conteo01TipoSistema)
                    
                    .HasColumnName("CONTEO01_TipoSistema");
                entity.Property(e => e.Conteo01Valor)
                    
                    .HasColumnName("CONTEO01_Valor");
                entity.Property(e => e.Conteo01X)
                    .HasMaxLength(50)
                    .HasColumnName("CONTEO01_x");
                entity.Property(e => e.Conteo01Y)
                    .HasMaxLength(50)
                    .HasColumnName("CONTEO01_y");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHACREACION");
                entity.Property(e => e.Mvl01Llave)
                    .HasMaxLength(50)
                    .HasColumnName("MVL01_Llave");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");
                entity.Property(e => e.Trp01Llave)
                    
                    .HasColumnName("TRP01_Llave");

                entity.HasOne(d => d.Temp02LlaveNavigation).WithMany(p => p.Conteo01Conteos)
                    .HasForeignKey(d => d.Temp02Llave)
                    .HasConstraintName("FK_CONTEO01_Conteos_TEMP02_TemporadaBase");
            });

            modelBuilder.Entity<Conteo02Procesado>(entity =>
            {
                entity.HasKey(e => e.Conteo02Llave);

                entity.ToTable("CONTEO02_Procesados");

                entity.Property(e => e.Conteo02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CONTEO02_Llave");
                entity.Property(e => e.Cnt08Llave)
                    
                    .HasColumnName("CNT08_Llave");
                entity.Property(e => e.Conteo02Cantidad)
                    
                    .HasColumnName("CONTEO02_Cantidad");
                entity.Property(e => e.Conteo02Cotatenado)
                    .HasMaxLength(100)
                    .HasColumnName("CONTEO02_Cotatenado");
                entity.Property(e => e.Conteo02FechaProceso)
                    .HasColumnType("datetime")
                    .HasColumnName("CONTEO02_fechaProceso");
                entity.Property(e => e.Conteo02Promedio)
                    
                    .HasColumnName("CONTEO02_Promedio");
                entity.Property(e => e.Conteo02Suma)
                    
                    .HasColumnName("CONTEO02_Suma");
                entity.Property(e => e.Esp01Llave)
                    
                    .HasColumnName("ESP01_Llave");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");

                entity.HasOne(d => d.Cnt08LlaveNavigation).WithMany(p => p.Conteo02Procesados)
                    .HasForeignKey(d => d.Cnt08Llave)
                    .HasConstraintName("FK_CONTEO02_Procesados_CNT08_Segmentacion");
            });

            modelBuilder.Entity<Conteo03Resumen>(entity =>
            {
                entity.HasKey(e => e.Conteo03Llave);

                entity.ToTable("CONTEO03_Resumen");

                entity.Property(e => e.Conteo03Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CONTEO03_Llave");
                entity.Property(e => e.Cnt08Llave)
                    
                    .HasColumnName("CNT08_Llave");
                entity.Property(e => e.Conteo03Estado).HasColumnName("CONTEO03_Estado");
                entity.Property(e => e.Esp01Llave)
                    
                    .HasColumnName("ESP01_Llave");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");

                entity.HasOne(d => d.Cnt08LlaveNavigation).WithMany(p => p.Conteo03Resumen)
                    .HasForeignKey(d => d.Cnt08Llave)
                    .HasConstraintName("FK_CONTEO03_Resumen_CNT08_Segmentacion");
            });

            modelBuilder.Entity<Conteo04ResumenSag>(entity =>
            {
                entity.HasKey(e => e.Conteo04Llave);

                entity.ToTable("CONTEO04_ResumenSag");

                entity.Property(e => e.Conteo04Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CONTEO04_Llave");
                entity.Property(e => e.Conteo04Estado)
                    
                    .HasColumnName("CONTEO04_Estado");
                entity.Property(e => e.Esp01Llave)
                    
                    .HasColumnName("ESP01_Llave");
                entity.Property(e => e.Sist03Llave)
                    
                    .HasColumnName("SIST03_Llave");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");

                entity.HasOne(d => d.Esp01LlaveNavigation).WithMany(p => p.Conteo04ResumenSags)
                    .HasForeignKey(d => d.Esp01Llave)
                    .HasConstraintName("FK_CONTEO04_ResumenSag_ESP01_Especies");

                entity.HasOne(d => d.Sist03LlaveNavigation).WithMany(p => p.Conteo04ResumenSags)
                    .HasForeignKey(d => d.Sist03Llave)
                    .HasConstraintName("FK_CONTEO04_ResumenSag_SIST03_Comuna");

                entity.HasOne(d => d.Temp02LlaveNavigation).WithMany(p => p.Conteo04ResumenSags)
                    .HasForeignKey(d => d.Temp02Llave)
                    .HasConstraintName("FK_CONTEO04_ResumenSag_TEMP02_TemporadaBase");
            });

            modelBuilder.Entity<Conteo05ControlReserva>(entity =>
            {
                entity.HasKey(e => e.Conteo05Llave);

                entity.ToTable("CONTEO05_Control_Reserva");

                entity.Property(e => e.Conteo05Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CONTEO05_Llave");
                entity.Property(e => e.Conteo05ColumnaControl)
                    .HasMaxLength(1000)
                    .HasColumnName("CONTEO05_columna_control");
                entity.Property(e => e.Conteo05Estado)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("CONTEO05_Estado");
                entity.Property(e => e.Conteo05EstadoControl)
                    
                    .HasColumnName("CONTEO05_estado_control");
                entity.Property(e => e.Conteo05Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("CONTEO05_fecha");
                entity.Property(e => e.Conteo05IdMovil)
                    .HasMaxLength(1000)
                    .HasColumnName("CONTEO05_id_movil");
                entity.Property(e => e.Conteo05Primer)
                    .HasMaxLength(200)
                    .HasColumnName("CONTEO05_primer");
                entity.Property(e => e.Conteo05Segundo)
                    .HasMaxLength(200)
                    .HasColumnName("CONTEO05_segundo");
                entity.Property(e => e.Conteo05TablaControl)
                    .HasMaxLength(1000)
                    .HasColumnName("CONTEO05_tabla_control");
                entity.Property(e => e.Conteo05Tercer)
                    .HasMaxLength(200)
                    .HasColumnName("CONTEO05_tercer");
                entity.Property(e => e.Conteo05ValorControl)
                    
                    .HasColumnName("CONTEO05_valor_control");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");

                entity.HasOne(d => d.Secu02LlaveNavigation).WithMany(p => p.Conteo05ControlReservas)
                    .HasForeignKey(d => d.Secu02Llave)
                    .HasConstraintName("FK_CONTEO05_Control_Reserva_SECU02_Usuario");
            });

            modelBuilder.Entity<Ctt01Contrato>(entity =>
            {
                entity.HasKey(e => e.Ctt01Llave);

                entity.ToTable("CTT01_Contrato");

                entity.Property(e => e.Ctt01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CTT01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.Ctt01Activo).HasColumnName("CTT01_Activo");
                entity.Property(e => e.Ctt01ContratoHtml).HasColumnName("CTT01_ContratoHtml");
                entity.Property(e => e.Ctt01Descripcion).HasColumnName("CTT01_Descripcion");
                entity.Property(e => e.Ctt01Nombre)
                    .HasMaxLength(500)
                    .HasColumnName("CTT01_Nombre");
                entity.Property(e => e.Ctt02Llave)
                    
                    .HasColumnName("CTT02_Llave");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");

                entity.HasOne(d => d.Ctt02LlaveNavigation).WithMany(p => p.Ctt01Contratos)
                    .HasForeignKey(d => d.Ctt02Llave)
                    .HasConstraintName("FK_CTT01_Contrato_CTT02_TipoContrato");
            });

            modelBuilder.Entity<Ctt02TipoContrato>(entity =>
            {
                entity.HasKey(e => e.Ctt02Llave);

                entity.ToTable("CTT02_TipoContrato");

                entity.Property(e => e.Ctt02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CTT02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.Ctt02Activo).HasColumnName("CTT02_Activo");
                entity.Property(e => e.Ctt02Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CTT02_Descripcion");
                entity.Property(e => e.Ctt02Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CTT02_Nombre");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Ctzr01Cotizacion>(entity =>
            {
                entity.HasKey(e => e.Ctzr01Llave);

                entity.ToTable("CTZR01_Cotizacion");

                entity.Property(e => e.Ctzr01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("CTZR01_Llave");
                entity.Property(e => e.Ctzr01Activo).HasColumnName("CTZR01_Activo");
                entity.Property(e => e.Ctzr01Comentario).HasColumnName("CTZR01_comentario");
                entity.Property(e => e.Ctzr01Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("CTZR01_fecha");
                entity.Property(e => e.Lnc01Llave)
                    
                    .HasColumnName("LNC01_Llave");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");
            });

            modelBuilder.Entity<Eml01BitacoraEmailUsuario>(entity =>
            {
                entity.HasKey(e => e.Eml01Llave).HasName("PK_EML01_EmailUsuario");

                entity.ToTable("EML01_BitacoraEmailUsuario");

                entity.Property(e => e.Eml01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("EML01_Llave");
                entity.Property(e => e.Eml01Activo)
                    
                    .HasColumnName("EML01_Activo");
                entity.Property(e => e.Eml01Asunto).HasColumnName("EML01_Asunto");
                entity.Property(e => e.Eml01Contenido)
                    .HasMaxLength(50)
                    .HasColumnName("EML01_Contenido");
                entity.Property(e => e.Eml01De).HasColumnName("EML01_De");
                entity.Property(e => e.Eml01Envio)
                    .HasColumnType("datetime")
                    .HasColumnName("EML01_Envio");
                entity.Property(e => e.Eml01MailPadre)
                    
                    .HasColumnName("EML01_MailPAdre");
                entity.Property(e => e.Eml01Para).HasColumnName("EML01_Para");
                entity.Property(e => e.Eml01Text).HasColumnName("EML01_Text");
                entity.Property(e => e.Eml02Llave)
                    
                    .HasColumnName("EML02_Llave");
                entity.Property(e => e.Eml04Llave)
                    
                    .HasColumnName("EML04_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");

                entity.HasOne(d => d.Eml02LlaveNavigation).WithMany(p => p.Eml01BitacoraEmailUsuarios)
                    .HasForeignKey(d => d.Eml02Llave)
                    .HasConstraintName("FK_EML01_EmailUsuario_EML02_MailBase");

                entity.HasOne(d => d.Eml04LlaveNavigation).WithMany(p => p.Eml01BitacoraEmailUsuarios)
                    .HasForeignKey(d => d.Eml04Llave)
                    .HasConstraintName("FK_EML01_EmailUsuario_EML04_ImportanciaMail");

                entity.HasOne(d => d.Secu02LlaveNavigation).WithMany(p => p.Eml01BitacoraEmailUsuarios)
                    .HasForeignKey(d => d.Secu02Llave)
                    .HasConstraintName("FK_EML01_BitacoraEmailUsuario_SECU02_Usuario");
            });

            modelBuilder.Entity<Eml02MailBase>(entity =>
            {
                entity.HasKey(e => e.Eml02Llave);

                entity.ToTable("EML02_MailBase");

                entity.Property(e => e.Eml02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("EML02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Eml02Activo).HasColumnName("EML02_activo");
                entity.Property(e => e.Eml02Asunto).HasColumnName("EML02_Asunto");
                entity.Property(e => e.Eml02CodigoLlamado)
                    .HasMaxLength(500)
                    .HasColumnName("EML02_CodigoLlamado");
                entity.Property(e => e.Eml02ContenidoHtml).HasColumnName("EML02_ContenidoHtml");
                entity.Property(e => e.Eml02ContenidoText).HasColumnName("EML02_ContenidoText");
                entity.Property(e => e.Eml02Descripcion).HasColumnName("EML02_Descripcion");
                entity.Property(e => e.Eml03Llave)
                    
                    .HasColumnName("EML03_Llave");
                entity.Property(e => e.Eml04Llave)
                    
                    .HasColumnName("EML04_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");

                entity.HasOne(d => d.Eml03LlaveNavigation).WithMany(p => p.Eml02MailBases)
                    .HasForeignKey(d => d.Eml03Llave)
                    .HasConstraintName("FK_EML02_MailBase_EML03_TipoMailAcciones");

                entity.HasOne(d => d.Eml04LlaveNavigation).WithMany(p => p.Eml02MailBases)
                    .HasForeignKey(d => d.Eml04Llave)
                    .HasConstraintName("FK_EML02_MailBase_EML04_ImportanciaMail");
            });

            modelBuilder.Entity<Eml03TipoMailAccion>(entity =>
            {
                entity.HasKey(e => e.Eml03Llave).HasName("PK_EML03_TipoMailAcciones_1");

                entity.ToTable("EML03_TipoMailAcciones");

                entity.Property(e => e.Eml03Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("EML03_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Eml03Activo).HasColumnName("EML03_Activo");
                entity.Property(e => e.Eml03Descripcion).HasColumnName("EML03_Descripcion");
                entity.Property(e => e.Eml03Nombre)
                    .HasMaxLength(500)
                    .HasColumnName("EML03_Nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Eml04ImportanciaMail>(entity =>
            {
                entity.HasKey(e => e.Eml04Llave);

                entity.ToTable("EML04_ImportanciaMail");

                entity.Property(e => e.Eml04Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("EML04_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Eml04Activo).HasColumnName("EML04_Activo");
                entity.Property(e => e.Eml04Descripcion).HasColumnName("EML04_Descripcion");
                entity.Property(e => e.Eml04Nombre)
                    .HasMaxLength(500)
                    .HasColumnName("EML04_Nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Eml05ArchivoMail>(entity =>
            {
                entity.HasKey(e => e.Eml05Llave);

                entity.ToTable("EML05_ArchivoMail");

                entity.Property(e => e.Eml05Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("EML05_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Eml01Llave)
                    
                    .HasColumnName("EML01_Llave");
                entity.Property(e => e.Eml05Activo).HasColumnName("EML05_Activo");
                entity.Property(e => e.Eml05Archivo).HasColumnName("EML05_Archivo");
                entity.Property(e => e.Eml05Ruta).HasColumnName("EML05_Ruta");
                entity.Property(e => e.Eml06Llave)
                    
                    .HasColumnName("EML06_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");

                entity.HasOne(d => d.Eml01LlaveNavigation).WithMany(p => p.Eml05ArchivoMails)
                    .HasForeignKey(d => d.Eml01Llave)
                    .HasConstraintName("FK_EML05_ArchivoMail_EML01_EmailUsuario");

                entity.HasOne(d => d.Eml05LlaveNavigation).WithOne(p => p.Eml05ArchivoMail)
                    .HasForeignKey<Eml05ArchivoMail>(d => d.Eml05Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EML05_ArchivoMail_EML06_TipoArchivo");
            });

            modelBuilder.Entity<Eml06TipoArchivo>(entity =>
            {
                entity.HasKey(e => e.Eml06Llave);

                entity.ToTable("EML06_TipoArchivo");

                entity.Property(e => e.Eml06Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("EML06_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Eml06Activo).HasColumnName("EML06_Activo");
                entity.Property(e => e.Eml06Descripcion).HasColumnName("EML06_Descripcion");
                entity.Property(e => e.Eml06Nombre)
                    .HasMaxLength(500)
                    .HasColumnName("EML06_Nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Esp01Especie>(entity =>
            {
                entity.HasKey(e => e.Esp01Llave);

                entity.ToTable("ESP01_Especies");

                entity.Property(e => e.Esp01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("ESP01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Esp01Activo).HasColumnName("ESP01_Activo");
                entity.Property(e => e.Esp03Llave)
                    
                    .HasColumnName("ESP03_Llave");
                entity.Property(e => e.Esp04Llave)
                    
                    .HasColumnName("ESP04_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");

                entity.HasOne(d => d.Esp03LlaveNavigation).WithMany(p => p.Esp01Especies)
                    .HasForeignKey(d => d.Esp03Llave)
                    .HasConstraintName("FK_ESP01_Especies_ESP03_EspecieBase");

                entity.HasOne(d => d.Esp04LlaveNavigation).WithMany(p => p.Esp01Especies)
                    .HasForeignKey(d => d.Esp04Llave)
                    .HasConstraintName("FK_ESP01_Especies_ESP04_EstadoDanio");
            });

            modelBuilder.Entity<Esp02TemporadaEspecie>(entity =>
            {
                entity.HasKey(e => e.Esp02Llave);

                entity.ToTable("ESP02_TemporadaEspecie");

                entity.Property(e => e.Esp02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("ESP02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Esp01Llave)
                    
                    .HasColumnName("ESP01_Llave");
                entity.Property(e => e.Esp02Activo).HasColumnName("ESP02_Activo");
                entity.Property(e => e.Esp02InicioTemporada)
                    .HasColumnType("datetime")
                    .HasColumnName("ESP02_InicioTemporada");
                entity.Property(e => e.Esp02Mexico).HasColumnName("ESP02_Mexico");
                entity.Property(e => e.Esp02Sag).HasColumnName("ESP02_Sag");
                entity.Property(e => e.Esp02TerminoTemporada)
                    .HasColumnType("datetime")
                    .HasColumnName("ESP02_TerminoTemporada");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Temp01Llave)
                    
                    .HasColumnName("TEMP01_Llave");

                entity.HasOne(d => d.Esp01LlaveNavigation).WithMany(p => p.Esp02TemporadaEspecies)
                    .HasForeignKey(d => d.Esp01Llave)
                    .HasConstraintName("FK_ESP02_TemporadaEspecie_ESP01_Especies");

                entity.HasOne(d => d.Temp01LlaveNavigation).WithMany(p => p.Esp02TemporadaEspecies)
                    .HasForeignKey(d => d.Temp01Llave)
                    .HasConstraintName("FK_ESP02_TemporadaEspecie_TEMP01_Temporada");
            });

            modelBuilder.Entity<Esp03EspecieBase>(entity =>
            {
                entity.HasKey(e => e.Esp03Llave);

                entity.ToTable("ESP03_EspecieBase");

                entity.Property(e => e.Esp03Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("ESP03_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Esp03Activo).HasColumnName("ESP03_Activo");
                entity.Property(e => e.Esp03Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("ESP03_Descripcion");
                entity.Property(e => e.Esp03EstadoRegistro)
                    .HasMaxLength(50)
                    .HasColumnName("ESP03_EstadoRegistro");
                entity.Property(e => e.Esp03ImgGrande).HasColumnName("ESP03_ImgGrande");
                entity.Property(e => e.Esp03ImgPequenia).HasColumnName("ESP03_ImgPequenia");
                entity.Property(e => e.Esp03Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("ESP03_Nombre");
                entity.Property(e => e.Esp03Union).HasColumnName("ESP03_Union");
                entity.Property(e => e.Esp08Llave)
                    
                    .HasColumnName("ESP08_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");

                entity.HasOne(d => d.Esp08LlaveNavigation).WithMany(p => p.Esp03EspecieBases)
                    .HasForeignKey(d => d.Esp08Llave)
                    .HasConstraintName("FK_ESP03_EspecieBase_ESP08_TipoBase");
            });

            modelBuilder.Entity<Esp04EstadoDanio>(entity =>
            {
                entity.HasKey(e => e.esp04llave);

                entity.ToTable("ESP04_EstadoDanio");

                entity.Property(e => e.esp04llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("ESP04_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp04activo).HasColumnName("ESP04_Activo");
                entity.Property(e => e.esp04descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("ESP04_Descripcion");
                entity.Property(e => e.esp04nombre)
                    .HasMaxLength(250)
                    .HasColumnName("ESP04_Nombre");
                entity.Property(e => e.esp06llave)
                    
                    .HasColumnName("ESP06_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");

                entity.HasOne(d => d.Esp06LlaveNavigation).WithMany(p => p.Esp04EstadoDanios)
                    .HasForeignKey(d => d.esp06llave)
                    .HasConstraintName("FK_ESP04_EstadoDanio_ESP06_MedidaUmbral");
            });

            modelBuilder.Entity<Esp05Umbral>(entity =>
            {
                entity.HasKey(e => e.Esp05Llave);

                entity.ToTable("ESP05_Umbral");

                entity.Property(e => e.Esp05Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("ESP05_LLave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Esp01Llave)
                    
                    .HasColumnName("ESP01_Llave");
                entity.Property(e => e.Esp05Activo).HasColumnName("ESP05_Activo");
                entity.Property(e => e.Esp05Color)
                    .HasMaxLength(50)
                    .HasColumnName("ESP05_Color");
                entity.Property(e => e.Esp05MaxUmbral)
                    
                    .HasColumnName("ESP05_MaxUmbral");
                entity.Property(e => e.Esp05MinUmbral)
                    
                    .HasColumnName("ESP05_MinUmbral");
                entity.Property(e => e.Esp09Llave)
                    
                    .HasColumnName("ESP09_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");

                entity.HasOne(d => d.Esp01LlaveNavigation).WithMany(p => p.Esp05Umbrals)
                    .HasForeignKey(d => d.Esp01Llave)
                    .HasConstraintName("FK_ESP05_Umbral_ESP01_Especies");

                entity.HasOne(d => d.Esp09LlaveNavigation).WithMany(p => p.Esp05Umbrals)
                    .HasForeignKey(d => d.Esp09Llave)
                    .HasConstraintName("FK_ESP05_Umbral_ESP09_TipoBaseUmbral");
            });

            modelBuilder.Entity<Esp06MedidaUmbral>(entity =>
            {
                entity.HasKey(e => e.esp06llave);

                entity.ToTable("ESP06_MedidaUmbral");

                entity.Property(e => e.esp06llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("ESP06_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp06activo).HasColumnName("ESP06_Activo");
                entity.Property(e => e.esp06descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("ESP06_Descripcion");
                entity.Property(e => e.esp06nombre)
                    .HasMaxLength(250)
                    .HasColumnName("ESP06_Nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Esp07Union>(entity =>
            {
                entity.HasKey(e => new { e.Esp03Llave, e.Esp03LlaveUnion });

                entity.ToTable("ESP07_Union");

                entity.Property(e => e.Esp03Llave)
                    
                    .HasColumnName("ESP03_Llave");
                entity.Property(e => e.Esp03LlaveUnion)
                    
                    .HasColumnName("ESP03_LlaveUnion");

                entity.HasOne(d => d.Esp03LlaveNavigation).WithMany(p => p.Esp07Unions)
                    .HasForeignKey(d => d.Esp03Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESP07_Union_ESP03_EspecieBase");
            });

            modelBuilder.Entity<Esp08TipoBase>(entity =>
            {
                entity.HasKey(e => e.esp08llave);

                entity.ToTable("ESP08_TipoBase");

                entity.Property(e => e.esp08llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("ESP08_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp08activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("ESP08_Activo");
                entity.Property(e => e.esp08descripcion).HasColumnName("ESP08_Descripcion");
                entity.Property(e => e.esp08nombre)
                    .HasMaxLength(500)
                    .HasColumnName("ESP08_Nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Esp09TipoBaseUmbral>(entity =>
            {
                entity.HasKey(e => e.Esp09Llave);

                entity.ToTable("ESP09_TipoBaseUmbral");

                entity.Property(e => e.Esp09Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("ESP09_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Esp09Activo).HasColumnName("ESP09_Activo");
                entity.Property(e => e.Esp09Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("ESP09_Descripcion");
                entity.Property(e => e.Esp09Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("ESP09_Nombre");
                entity.Property(e => e.Esp09Orden).HasColumnName("ESP09_Orden");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Esp10TipoRegla>(entity =>
            {
                entity.HasKey(e => e.Esp10Llave);

                entity.ToTable("ESP10_TipoRegla");

                entity.Property(e => e.Esp10Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("ESP10_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Esp10Activo).HasColumnName("ESP10_Activo");
                entity.Property(e => e.Esp10Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("ESP10_Descripcion");
                entity.Property(e => e.Esp10Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("ESP10_Nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
            });

            modelBuilder.Entity<Esp11ReglaGrafico>(entity =>
            {
                entity.HasKey(e => e.Esp11Llave);

                entity.ToTable("ESP11_ReglaGrafico");

                entity.Property(e => e.Esp11Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("ESP11_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Esp03Llave)
                    
                    .HasColumnName("ESP03_Llave");
                entity.Property(e => e.Esp10Llave)
                    
                    .HasColumnName("ESP10_Llave");
                entity.Property(e => e.Esp11Estado).HasColumnName("ESP11_Estado");
                entity.Property(e => e.Esp11Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("ESP11_Nombre");
                entity.Property(e => e.Esp11Signo1)
                    .HasMaxLength(50)
                    .HasColumnName("ESP11_Signo1");
                entity.Property(e => e.Esp11Signo2)
                    .HasMaxLength(50)
                    .HasColumnName("ESP11_Signo2");
                entity.Property(e => e.Esp11SignoResultado)
                    .HasMaxLength(50)
                    .HasColumnName("ESP11_SignoResultado");
                entity.Property(e => e.Esp11Valor1).HasColumnName("ESP11_Valor1");
                entity.Property(e => e.Esp11Valor2).HasColumnName("ESP11_Valor2");
                entity.Property(e => e.Esp11ValorResultado).HasColumnName("ESP11_ValorResultado");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");

                entity.HasOne(d => d.Esp10LlaveNavigation).WithMany(p => p.Esp11ReglaGraficos)
                    .HasForeignKey(d => d.Esp10Llave)
                    .HasConstraintName("FK_ESP11_ReglaGrafico_ESP10_TipoRegla");
            });

            modelBuilder.Entity<Frm01TipoFormulario>(entity =>
            {
                entity.HasKey(e => e.Frm01Llave);

                entity.ToTable("FRM01_TipoFormulario");

                entity.Property(e => e.Frm01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("FRM01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Frm01Activo).HasColumnName("FRM01_Activo");
                entity.Property(e => e.Frm01Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("FRM01_Nombre");
            });

            modelBuilder.Entity<Frm02Formulario>(entity =>
            {
                entity.HasKey(e => e.Frm02Llave);

                entity.ToTable("FRM02_Formulario");

                entity.Property(e => e.Frm02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("FRM02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Eml01Llave)
                    
                    .HasColumnName("EML01_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Frm01Llave)
                    
                    .HasColumnName("FRM01_Llave");
                entity.Property(e => e.Frm02Activo).HasColumnName("FRM02_Activo");
                entity.Property(e => e.Frm02Celular)
                    .HasMaxLength(50)
                    .HasColumnName("FRM02_Celular");
                entity.Property(e => e.Frm02Ciudad)
                    .HasMaxLength(250)
                    .HasColumnName("FRM02_Ciudad");
                entity.Property(e => e.Frm02Direccion)
                    .HasMaxLength(250)
                    .HasColumnName("FRM02_Direccion");
                entity.Property(e => e.Frm02Empresa)
                    .HasMaxLength(250)
                    .HasColumnName("FRM02_Empresa");
                entity.Property(e => e.Frm02EstadoRespuesta).HasColumnName("FRM02_EstadoRespuesta");
                entity.Property(e => e.Frm02Mail)
                    .HasMaxLength(50)
                    .HasColumnName("FRM02_Mail");
                entity.Property(e => e.Frm02Mensaje).HasColumnName("FRM02_Mensaje");
                entity.Property(e => e.Frm02Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("FRM02_Nombre");
                entity.Property(e => e.Frm02Telefono)
                    .HasMaxLength(50)
                    .HasColumnName("FRM02_Telefono");

                entity.HasOne(d => d.Eml01LlaveNavigation).WithMany(p => p.Frm02Formularios)
                    .HasForeignKey(d => d.Eml01Llave)
                    .HasConstraintName("FK_FRM02_Formulario_EML01_BitacoraEmailUsuario");

                entity.HasOne(d => d.Frm01LlaveNavigation).WithMany(p => p.Frm02Formularios)
                    .HasForeignKey(d => d.Frm01Llave)
                    .HasConstraintName("FK_FRM02_Formulario_FRM01_TipoFormulario");
            });

            modelBuilder.Entity<Grfc01GraficoGenerado>(entity =>
            {
                entity.HasKey(e => e.Grfc01Llave);

                entity.ToTable("GRFC01_GraficoGenerado");

                entity.Property(e => e.Grfc01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("GRFC01_Llave");
                entity.Property(e => e.Grfc01CodigoGrafico)
                    .HasMaxLength(150)
                    .HasColumnName("GRFC01_codigo_grafico");
                entity.Property(e => e.Grfc01Estado).HasColumnName("GRFC01_estado");
                entity.Property(e => e.Grfc01FechaGrafico)
                    .HasColumnType("datetime")
                    .HasColumnName("GRFC01_FechaGrafico");
                entity.Property(e => e.Grfc02Llave)
                    
                    .HasColumnName("GRFC02_Llave");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");
            });

            modelBuilder.Entity<Grfc02TipoGrafico>(entity =>
            {
                entity.HasKey(e => e.Grfc02Llave);

                entity.ToTable("GRFC02_TipoGrafico");

                entity.Property(e => e.Grfc02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("GRFC02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Grfc02Activo).HasColumnName("GRFC02_Activo");
                entity.Property(e => e.Grfc02Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("GRFC02_Descripcion");
                entity.Property(e => e.Grfc02Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("GRFC02_Nombre");
            });

            modelBuilder.Entity<Grfc03RespaldoGrafico>(entity =>
            {
                entity.HasKey(e => e.Grfc03Llave);

                entity.ToTable("GRFC03_respaldoGrafico");

                entity.Property(e => e.Grfc03Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("GRFC03_Llave");
                entity.Property(e => e.Cnt08Llave)
                    
                    .HasColumnName("CNT08_Llave");
                entity.Property(e => e.Esp03Llave)
                    
                    .HasColumnName("ESP03_Llave");
                entity.Property(e => e.Grfc03Estado).HasColumnName("GRFC03_Estado");
                entity.Property(e => e.Grfc03UltimaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("GRFC03_ultimaFecha");
                entity.Property(e => e.Grfc03XmlDatos).HasColumnName("GRFC03_xmlDatos");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");
            });

            modelBuilder.Entity<Ins01Inscripcion>(entity =>
            {
                entity.HasKey(e => e.Ins01Llave);

                entity.ToTable("INS01_Inscripcion");

                entity.Property(e => e.Ins01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("INS01_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Ins01Activo).HasColumnName("INS01_Activo");
                entity.Property(e => e.Ins01Apellido)
                    .HasMaxLength(250)
                    .HasColumnName("INS01_Apellido");
                entity.Property(e => e.Ins01Direccion)
                    .HasMaxLength(250)
                    .HasColumnName("INS01_Direccion");
                entity.Property(e => e.Ins01Email)
                    .HasMaxLength(250)
                    .HasColumnName("INS01_Email");
                entity.Property(e => e.Ins01Empresa)
                    .HasMaxLength(250)
                    .HasColumnName("INS01_Empresa");
                entity.Property(e => e.Ins01fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("INS01_fechaactivacion");
                entity.Property(e => e.Ins01FechaInscripcion)
                    .HasColumnType("datetime")
                    .HasColumnName("INS01_FechaInscripcion");
                entity.Property(e => e.Ins01FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("INS01_FechaNacimiento");
                entity.Property(e => e.Ins01Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("INS01_Nombre");
                entity.Property(e => e.Ins01Password)
                    .HasMaxLength(50)
                    .HasColumnName("INS01_Password");
                entity.Property(e => e.Ins01Rut)
                    
                    .HasColumnName("INS01_Rut");
                entity.Property(e => e.Ins01Telefono)
                    .HasMaxLength(250)
                    .HasColumnName("INS01_Telefono");
                entity.Property(e => e.Ins01UserName)
                    .HasMaxLength(250)
                    .HasColumnName("INS01_UserName");
                entity.Property(e => e.Per02Llave)
                    
                    .HasColumnName("PER02_Llave");
                entity.Property(e => e.Sist03Llave)
                    
                    .HasColumnName("SIST03_Llave");
            });

            modelBuilder.Entity<Ins02RecuperarClave>(entity =>
            {
                entity.HasKey(e => e.Ins02Llave);

                entity.ToTable("INS02_RecuperarClave");

                entity.Property(e => e.Ins02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("INS02_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Ins02ClaveTemporal)
                    .HasMaxLength(10)
                    .HasColumnName("INS02_ClaveTemporal");
                entity.Property(e => e.Ins02Estado).HasColumnName("INS02_Estado");
                entity.Property(e => e.Ins02FechaRecupera)
                    .HasColumnType("datetime")
                    .HasColumnName("INS02_FechaRecupera");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");

                entity.HasOne(d => d.Ins02EstadoNavigation).WithMany(p => p.Ins02RecuperarClaves)
                    .HasForeignKey(d => d.Ins02Estado)
                    .HasConstraintName("FK_INS02_RecuperarClave_SIST05_EstadoRegistro");
            });

            modelBuilder.Entity<Lnc01Licencia>(entity =>
            {
                entity.HasKey(e => e.Lnc01Llave);

                entity.ToTable("LNC01_Licencias");

                entity.Property(e => e.Lnc01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("LNC01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Lnc01Activo).HasColumnName("LNC01_Activo");
                entity.Property(e => e.Lnc01Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("LNC01_Descripcion");
                entity.Property(e => e.Lnc01Html).HasColumnName("LNC01_HTML");
                entity.Property(e => e.Lnc01Imagen)
                    .HasMaxLength(500)
                    .HasColumnName("LNC01_Imagen");
                entity.Property(e => e.Lnc01MaximoUsuarios)
                    
                    .HasColumnName("LNC01_MaximoUsuarios");
                entity.Property(e => e.Lnc01Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("LNC01_Nombre");
                entity.Property(e => e.Lnc01NumeroDias).HasColumnName("LNC01_NumeroDias");
                entity.Property(e => e.Lnc01TextoDias)
                    .HasMaxLength(250)
                    .HasColumnName("LNC01_TextoDias");
                entity.Property(e => e.Lnc01VisibleUsuario).HasColumnName("LNC01_VisibleUsuario");
                entity.Property(e => e.Lnc04Llave)
                    
                    .HasColumnName("LNC04_Llave");
            });

            modelBuilder.Entity<Lnc02ServiciosLicencia>(entity =>
            {
                entity.HasKey(e => new { e.Lnc01Llave, e.Serv01Llave }).HasName("PK_LNC02_ServiciosLicencia_1");

                entity.ToTable("LNC02_ServiciosLicencia");

                entity.Property(e => e.Lnc01Llave)
                    
                    .HasColumnName("LNC01_Llave");
                entity.Property(e => e.Serv01Llave)
                    
                    .HasColumnName("SERV01_Llave");
                entity.Property(e => e.Lnc02Activo).HasColumnName("LNC02_Activo");
                entity.Property(e => e.Lnc02EsIlimitado).HasColumnName("LNC02_EsIlimitado");
                entity.Property(e => e.Lnc02NumeroElemento)
                    
                    .HasColumnName("LNC02_NumeroElemento");
                entity.Property(e => e.Lnc02PermiteComparar).HasColumnName("LNC02_PermiteComparar");

                entity.HasOne(d => d.Lnc01LlaveNavigation).WithMany(p => p.Lnc02ServiciosLicencia)
                    .HasForeignKey(d => d.Lnc01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LNC02_ServiciosLicencia_LNC01_Licencias");

                entity.HasOne(d => d.Serv01LlaveNavigation).WithMany(p => p.Lnc02ServiciosLicencia)
                    .HasForeignKey(d => d.Serv01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LNC02_ServiciosLicencia_SERV01_Servicio");
            });

            modelBuilder.Entity<Lnc03LicenciaContrato>(entity =>
            {
                entity.HasKey(e => new { e.Lnc01Llave, e.Ctt01Llave }).HasName("PK_LNC03_LicenciaContrato_1");

                entity.ToTable("LNC03_LicenciaContrato");

                entity.Property(e => e.Lnc01Llave)
                    
                    .HasColumnName("LNC01_Llave");
                entity.Property(e => e.Ctt01Llave)
                    
                    .HasColumnName("CTT01_Llave");
                entity.Property(e => e.Lnc03Activo).HasColumnName("LNC03_Activo");
                entity.Property(e => e.Lnc03FirmaSimpre).HasColumnName("LNC03_FirmaSimpre");

                entity.HasOne(d => d.Ctt01LlaveNavigation).WithMany(p => p.Lnc03LicenciaContratos)
                    .HasForeignKey(d => d.Ctt01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LNC03_LicenciaContrato_CTT01_Contrato");

                entity.HasOne(d => d.Lnc01LlaveNavigation).WithMany(p => p.Lnc03LicenciaContratos)
                    .HasForeignKey(d => d.Lnc01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LNC03_LicenciaContrato_LNC01_Licencias");
            });

            modelBuilder.Entity<Lnc04TipoLicencia>(entity =>
            {
                entity.HasKey(e => e.Lnc04Llave);

                entity.ToTable("LNC04_TipoLicencia");

                entity.Property(e => e.Lnc04Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("LNC04_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Lnc04Activo).HasColumnName("LNC04_Activo");
                entity.Property(e => e.Lnc04Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("LNC04_Descripcion");
                entity.Property(e => e.Lnc04Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("LNC04_Nombre");
            });

            modelBuilder.Entity<Lnc05ValorLicencia>(entity =>
            {
                entity.HasKey(e => e.Lnc05Llave);

                entity.ToTable("LNC05_valorLicencia");

                entity.Property(e => e.Lnc05Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("LNC05_Llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.Lnc01Llave)
                    
                    .HasColumnName("LNC01_Llave");
                entity.Property(e => e.Lnc05Inicio)
                   
                    .HasColumnName("LNC05_Inicio");
                entity.Property(e => e.Lnc05Termino)
                    
                    .HasColumnName("LNC05_Termino");
                entity.Property(e => e.Lnc05Valor)
                   
                    .HasColumnName("LNC05_Valor");

                entity.HasOne(d => d.Lnc01LlaveNavigation).WithMany(p => p.Lnc05ValorLicencia)
                    .HasForeignKey(d => d.Lnc01Llave)
                    .HasConstraintName("FK_LNC05_valorLicencia_LNC01_Licencias");
            });

            modelBuilder.Entity<Lnc06Cobertura>(entity =>
            {
                entity.HasKey(e => new { e.Lnc01Llave, e.Sist03Llave }).HasName("PK_LNC05_Cobertura");

                entity.ToTable("LNC06_Cobertura");

                entity.Property(e => e.Lnc01Llave)
                    
                    .HasColumnName("LNC01_Llave");
                entity.Property(e => e.Sist03Llave)
                    
                    .HasColumnName("SIST03_Llave");

                entity.HasOne(d => d.Lnc01LlaveNavigation).WithMany(p => p.Lnc06Coberturas)
                    .HasForeignKey(d => d.Lnc01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LNC06_Cobertura_LNC01_Licencias");
            });

            modelBuilder.Entity<Lnc07Control>(entity =>
            {
                entity.HasKey(e => new { e.Lnc01Llave, e.Esp03Llave });

                entity.ToTable("LNC07_Control");

                entity.Property(e => e.Lnc01Llave)
                    
                    .HasColumnName("LNC01_Llave");
                entity.Property(e => e.Esp03Llave)
                    
                    .HasColumnName("ESP03_Llave");

                entity.HasOne(d => d.Lnc01LlaveNavigation).WithMany(p => p.Lnc07Controls)
                    .HasForeignKey(d => d.Lnc01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LNC07_Control_LNC01_Licencias");
            });

            modelBuilder.Entity<Log01Bitacora>(entity =>
            {
                entity.HasKey(e => e.Log01Llave);

                entity.ToTable("LOG01_Bitacora");

                entity.Property(e => e.Log01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("LOG01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Log01Activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("LOG01_Activo");
                entity.Property(e => e.Log01Clase).HasColumnName("LOG01_Clase");
                entity.Property(e => e.Log01Contenido).HasColumnName("LOG01_Contenido");
                entity.Property(e => e.Log01ElementoSerializado).HasColumnName("LOG01_elemento_serializado");
                entity.Property(e => e.Log01Info).HasColumnName("LOG01_Info");
                entity.Property(e => e.Log01Objeto)
                    
                    .HasColumnName("LOG01_objeto");
                entity.Property(e => e.Log03Llave)
                    
                    .HasColumnName("LOG03_Llave");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");

                entity.HasOne(d => d.Log03LlaveNavigation).WithMany(p => p.Log01Bitacoras)
                    .HasForeignKey(d => d.Log03Llave)
                    .HasConstraintName("FK_LOG01_Bitacora_LOG03_MensajeBitacora");
            });

            modelBuilder.Entity<Log02TipoBitacora>(entity =>
            {
                entity.HasKey(e => e.Log02Llave).HasName("PK__LOG02_Ti__EA456AA523FE4082");

                entity.ToTable("LOG02_TipoBitacora");

                entity.Property(e => e.Log02Llave)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("LOG02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Log02Activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("LOG02_Activo");
                entity.Property(e => e.Log02Descripcion).HasColumnName("LOG02_Descripcion");
                entity.Property(e => e.Log02EsRazor).HasColumnName("LOG02_EsRazor");
                entity.Property(e => e.Log02EsSistema)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("LOG02_EsSistema");
                entity.Property(e => e.Log02Info).HasColumnName("LOG02_Info");
                entity.Property(e => e.Log02Nombre)
                    .HasMaxLength(300)
                    .HasColumnName("LOG02_Nombre");
            });

            modelBuilder.Entity<Log03MensajeBitacora>(entity =>
            {
                entity.HasKey(e => e.Log03Llave);

                entity.ToTable("LOG03_MensajeBitacora");

                entity.Property(e => e.Log03Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("LOG03_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Log02Llave).HasColumnName("LOG02_Llave");
                entity.Property(e => e.Log03AccesoRapido)
                    .HasMaxLength(500)
                    .HasColumnName("LOG03_AccesoRapido");
                entity.Property(e => e.Log03Activo).HasColumnName("LOG03_Activo");
                entity.Property(e => e.Log03Descripcion).HasColumnName("LOG03_Descripcion");
                entity.Property(e => e.Log03Info).HasColumnName("LOG03_Info");
                entity.Property(e => e.Log03Mensaje).HasColumnName("LOG03_Mensaje");

                entity.HasOne(d => d.Log02LlaveNavigation).WithMany(p => p.Log03MensajeBitacoras)
                    .HasForeignKey(d => d.Log02Llave)
                    .HasConstraintName("FK_LOG03_MensajeBitacora_LOG02_TipoBitacora");
            });

            modelBuilder.Entity<Men01Sistema>(entity =>
            {
                entity.HasKey(e => e.Men01Llave).HasName("PK__MEN01_Si__4F35303B75CD617E");

                entity.ToTable("MEN01_Sistema");

                entity.Property(e => e.Men01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("MEN01_Llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Men01Accion)
                    .HasMaxLength(2000)
                    .HasColumnName("MEN01_Accion");
                entity.Property(e => e.Men01Area)
                    .HasMaxLength(1000)
                    .HasColumnName("MEN01_Area");
                entity.Property(e => e.Men01Control)
                    .HasMaxLength(2000)
                    .HasColumnName("MEN01_Control");
                entity.Property(e => e.Men01Descripcion)
                    .HasMaxLength(2000)
                    .HasColumnName("MEN01_descripcion");
                entity.Property(e => e.Men01IconoUrl).HasColumnName("MEN01_IconoUrl");
                entity.Property(e => e.Men01LlavePadre)
                    
                    .HasColumnName("MEN01_Llave_padre");
                entity.Property(e => e.Men01Principal).HasColumnName("MEN01_principal");
                entity.Property(e => e.Men01Titulo)
                    .HasMaxLength(2000)
                    .HasColumnName("MEN01_titulo");
                entity.Property(e => e.Men01Tooltip)
                    .HasMaxLength(2000)
                    .HasColumnName("MEN01_tooltip");
                entity.Property(e => e.Men01Url)
                    .HasMaxLength(2000)
                    .HasColumnName("MEN01_url");
            });

            modelBuilder.Entity<Mnt01Monitor>(entity =>
            {
                entity.HasKey(e => e.Mnt01Llave);

                entity.ToTable("MNT01_Monitores");

                entity.Property(e => e.Mnt01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("MNT01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Mnt01Activo).HasColumnName("MNT01_Activo");
                entity.Property(e => e.Mnt01Cargo)
                    .HasMaxLength(250)
                    .HasColumnName("MNT01_Cargo");
                entity.Property(e => e.Mnt01Iniciolabores)
                    .HasColumnType("datetime")
                    .HasColumnName("MNT01_iniciolabores");
                entity.Property(e => e.Mnt04Llave)
                    
                    .HasColumnName("MNT04_Llave");
                entity.Property(e => e.Per01Llave)
                    
                    .HasColumnName("PER01_Llave");

                entity.HasOne(d => d.Mnt04LlaveNavigation).WithMany(p => p.Mnt01Monitores)
                    .HasForeignKey(d => d.Mnt04Llave)
                    .HasConstraintName("FK_MNT01_Monitores_MNT04_TipoMonitor");

                entity.HasMany(d => d.Esp02Llaves).WithMany(p => p.Mnt01Llaves)
                    .UsingEntity<Dictionary<string, object>>(
                        "Mnt02EspeciesAsignada",
                        r => r.HasOne<Esp02TemporadaEspecie>().WithMany()
                            .HasForeignKey("Esp02Llave")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_MNT02_EspeciesAsignadas_ESP02_TemporadaEspecie"),
                        l => l.HasOne<Mnt01Monitor>().WithMany()
                            .HasForeignKey("Mnt01Llave")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_MNT02_EspeciesAsignadas_MNT01_Monitores"),
                        j =>
                        {
                            j.HasKey("Mnt01Llave", "Esp02Llave").HasName("PK_MNT02_EspeciesAsignadas_2");
                            j.ToTable("MNT02_EspeciesAsignadas");
                        });
            });

            modelBuilder.Entity<Mnt03PeriodosTrampa>(entity =>
            {
                entity.HasKey(e => new { e.Mnt01Llave, e.Trp01Llave, e.Temp02Llave }).HasName("PK_MNT02_EspeciesAsignadas");

                entity.ToTable("MNT03_PeriodosTrampas");

                entity.Property(e => e.Mnt01Llave)
                    
                    .HasColumnName("MNT01_Llave");
                entity.Property(e => e.Trp01Llave)
                    
                    .HasColumnName("TRP01_Llave");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.Mnt03Activo).HasColumnName("MNT03_Activo");

                entity.HasOne(d => d.Mnt01LlaveNavigation).WithMany(p => p.Mnt03PeriodosTrampas)
                    .HasForeignKey(d => d.Mnt01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MNT03_PeriodosTrampas_MNT01_Monitores");

                entity.HasOne(d => d.Temp02LlaveNavigation).WithMany(p => p.Mnt03PeriodosTrampas)
                    .HasForeignKey(d => d.Temp02Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MNT03_PeriodosTrampas_TEMP02_TemporadaBase");
            });

            modelBuilder.Entity<Mnt04TipoMonitor>(entity =>
            {
                entity.HasKey(e => e.Mnt04Llave).HasName("PK_MNT05_TipoBase");

                entity.ToTable("MNT04_TipoMonitor");

                entity.Property(e => e.Mnt04Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("MNT04_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Mnt04Activo).HasColumnName("MNT04_Activo");
                entity.Property(e => e.Mnt04Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("MNT04_Descripcion");
                entity.Property(e => e.Mnt04Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("MNT04_Nombre");
            });

            modelBuilder.Entity<Mvl01AccesoMovil>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("MVL01_AccesoMovil");

                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Mvl01DiasUmbralEdicion)
                    
                    .HasColumnName("MVL01_dias_umbral_edicion");
                entity.Property(e => e.Mvl01EditaFechaMonitoreo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("MVL01_edita_fecha_monitoreo");
                entity.Property(e => e.Mvl01EstaBloqueado)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("MVL01_esta_bloqueado");
                entity.Property(e => e.Mvl01FechaMensaje)
                    .HasColumnType("datetime")
                    .HasColumnName("MVL01_fecha_mensaje");
                entity.Property(e => e.Mvl01FechaRegistro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("MVL01_fecha_registro");
                entity.Property(e => e.Mvl01FechaUltimaActividad)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("MVL01_fecha_ultima_actividad");
                entity.Property(e => e.Mvl01FechaUltimaSincro)
                    .HasColumnType("datetime")
                    .HasColumnName("MVL01_fecha_ultima_sincro");
                entity.Property(e => e.Mvl01FechaUltimoAcceso)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("MVL01_fecha_ultimo_acceso");
                entity.Property(e => e.Mvl01IdUsuario).HasColumnName("MVL01_id_usuario");
                entity.Property(e => e.Mvl01Llave)
                    .HasMaxLength(1000)
                    .HasColumnName("MVL01_Llave");
                entity.Property(e => e.Mvl01MensajeMovil).HasColumnName("MVL01_mensaje_movil");
                entity.Property(e => e.Mvl01NumeroMovil)
                    .HasMaxLength(20)
                    .HasColumnName("MVL01_numero_movil");
                entity.Property(e => e.Mvl01SistemaAndroid)
                    .HasMaxLength(100)
                    .HasColumnName("MVL01_sistema_android");
                entity.Property(e => e.Mvl01TamanoBasedatosCliente)
                   
                    .HasColumnName("MVL01_tamano_basedatos_cliente");
                entity.Property(e => e.Mvl01UbicacionActividadX)
                    
                    .HasColumnName("MVL01_ubicacion_actividad_x");
                entity.Property(e => e.Mvl01UbicacionActividadY)
                    
                    .HasColumnName("MVL01_ubicacion_actividad_y");
                entity.Property(e => e.Mvl01VersionAndroid)
                    .HasMaxLength(10)
                    .HasColumnName("MVL01_version_android");
                entity.Property(e => e.Mvl01VersionAplicacion)
                    .HasMaxLength(10)
                    .HasColumnName("MVL01_version_aplicacion");
                entity.Property(e => e.Mvl01VersionDescarga)
                    .HasMaxLength(10)
                    .HasColumnName("MVL01_version_descarga");
            });

            modelBuilder.Entity<Mvl02TablaSincronizacion>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("MVL02_TablaSincronizacion");

                entity.Property(e => e.fechaeliminacion).HasColumnType("datetime");
                entity.Property(e => e.FechaUltimaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_UltimaActualizacion");
                entity.Property(e => e.NombreTabla)
                    .HasMaxLength(500)
                    .HasColumnName("Nombre_Tabla");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");
            });

            modelBuilder.Entity<Mvl03RegistroAcceso>(entity =>
            {
                entity.HasKey(e => e.Mvl03Llave);

                entity.ToTable("MVL03_RegistroAcceso");

                entity.Property(e => e.Mvl03Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("MVL03_Llave");
                entity.Property(e => e.Email).HasMaxLength(300);
                entity.Property(e => e.EmailUsuario)
                    .HasMaxLength(300)
                    .HasColumnName("email_usuario");
                entity.Property(e => e.EstadoUsuario).HasColumnName("estado_usuario");
                entity.Property(e => e.IsAnonymous)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.LastActivityDate)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.LoweredUserName).HasMaxLength(100);
                entity.Property(e => e.MobileAlias).HasMaxLength(20);
                entity.Property(e => e.Mvl03Fechacreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("MVL03_FECHACREACION");
                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(500)
                    .HasColumnName("nombre_usuario");
                entity.Property(e => e.Password).HasMaxLength(200);
                entity.Property(e => e.PasswordFormat).HasMaxLength(300);
                entity.Property(e => e.Per01Llave)
                    
                    .HasColumnName("PER01_Llave");
                entity.Property(e => e.Secu02Activo).HasColumnName("SECU02_Activo");
                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<Obsc01ObservacionCampo>(entity =>
            {
                entity.HasKey(e => e.Obsc01Llave);

                entity.ToTable("OBSC01_ObservacionCampo");

                entity.Property(e => e.Obsc01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("OBSC01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Esp08Llave)
                    
                    .HasColumnName("ESP08_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Obsc01Activo).HasColumnName("OBSC01_Activo");
                entity.Property(e => e.Obsc01FechaObservacion)
                    .HasColumnType("datetime")
                    .HasColumnName("OBSC01_FechaObservacion");
                entity.Property(e => e.Obsc01Interesado)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("OBSC01_interesado");
                entity.Property(e => e.Obsc01Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("OBSC01_Nombre");
                entity.Property(e => e.Obsc01Resumen)
                    .HasMaxLength(1000)
                    .IsFixedLength()
                    .HasColumnName("OBSC01_Resumen");
                entity.Property(e => e.Obsc01UrlPdf)
                    .HasMaxLength(1000)
                    .HasColumnName("OBSC01_UrlPdf");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");

                entity.HasOne(d => d.Esp08LlaveNavigation).WithMany(p => p.Obsc01ObservacionCampos)
                    .HasForeignKey(d => d.Esp08Llave)
                    .HasConstraintName("FK_OBSC01_ObservacionCampo_ESP08_TipoBase");

                entity.HasOne(d => d.Temp02LlaveNavigation).WithMany(p => p.Obsc01ObservacionCampos)
                    .HasForeignKey(d => d.Temp02Llave)
                    .HasConstraintName("FK_OBSC01_ObservacionCampo_TEMP02_TemporadaBase");
            });

            modelBuilder.Entity<Obsc02ServicioPostcosecha>(entity =>
            {
                entity.HasKey(e => e.Obsc02Llave);

                entity.ToTable("OBSC02_ServicioPostcosecha");

                entity.Property(e => e.Obsc02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("OBSC02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Esp08Llave)
                    
                    .HasColumnName("ESP08_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Obsc02Activo).HasColumnName("OBSC02_Activo");
                entity.Property(e => e.Obsc02Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("OBSC02_Fecha");
                entity.Property(e => e.Obsc02Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("OBSC02_Nombre");
                entity.Property(e => e.Obsc02Resumen).HasColumnName("OBSC02_Resumen");
                entity.Property(e => e.Obsc02UrlPdf)
                    .HasMaxLength(1000)
                    .HasColumnName("OBSC02_UrlPdf");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");
            });

            modelBuilder.Entity<Pbcd01Publicidad>(entity =>
            {
                entity.HasKey(e => e.Pbcd01Llave);

                entity.ToTable("PBCD01_Publicidad");

                entity.Property(e => e.Pbcd01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PBCD01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Pbcd01Activo).HasColumnName("PBCD01_Activo");
                entity.Property(e => e.Pbcd01FrasePrincipal)
                    .HasMaxLength(500)
                    .HasColumnName("PBCD01_FrasePrincipal");
                entity.Property(e => e.Pbcd01FraseSecundaria)
                    .HasMaxLength(500)
                    .HasColumnName("PBCD01_FraseSecundaria");
                entity.Property(e => e.Pbcd01ImagenNombre)
                    .HasMaxLength(500)
                    .HasColumnName("PBCD01_ImagenNombre");
                entity.Property(e => e.Pbcd01Objetico)
                    .HasMaxLength(500)
                    .HasColumnName("PBCD01_Objetico");
                entity.Property(e => e.Pbcd01Problema)
                    .HasMaxLength(500)
                    .HasColumnName("PBCD01_Problema");
                entity.Property(e => e.Pbcd01Producto)
                    .HasMaxLength(500)
                    .HasColumnName("PBCD01_Producto");
                entity.Property(e => e.Pbcd01SecuenciaHtml)
                    .HasMaxLength(500)
                    .HasColumnName("PBCD01_SecuenciaHtml");
                entity.Property(e => e.Pbcd02Llave)
                    
                    .HasColumnName("PBCD02_Llave");

                entity.HasOne(d => d.Pbcd02LlaveNavigation).WithMany(p => p.Pbcd01Publicidads)
                    .HasForeignKey(d => d.Pbcd02Llave)
                    .HasConstraintName("FK_PBCD01_Publicidad_PBCD02_TipoPublicidad");
            });

            modelBuilder.Entity<Pbcd02TipoPublicidad>(entity =>
            {
                entity.HasKey(e => e.Pbcd02Llave);

                entity.ToTable("PBCD02_TipoPublicidad");

                entity.Property(e => e.Pbcd02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PBCD02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Pbcd02Activo).HasColumnName("PBCD02_Activo");
                entity.Property(e => e.Pbcd02Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("PBCD02_Descripcion");
                entity.Property(e => e.Pbcd02Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("PBCD02_Nombre");
            });

            modelBuilder.Entity<Pbcd03Programacion>(entity =>
            {
                entity.HasKey(e => e.Pbcd03Llave);

                entity.ToTable("PBCD03_Programacion");

                entity.Property(e => e.Pbcd03Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PBCD03_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Pbcd01Llave)
                    
                    .HasColumnName("PBCD01_Llave");
                entity.Property(e => e.Pbcd03Activo).HasColumnName("PBCD03_Activo");
                entity.Property(e => e.Pbcd03InicioFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("PBCD03_InicioFecha");
                entity.Property(e => e.Pbcd03TerminoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("PBCD03_TerminoFecha");

                entity.HasOne(d => d.Pbcd01LlaveNavigation).WithMany(p => p.Pbcd03Programacions)
                    .HasForeignKey(d => d.Pbcd01Llave)
                    .HasConstraintName("FK_PBCD03_Programacion_PBCD01_Publicidad");
            });

            modelBuilder.Entity<Per01Persona>(entity =>
            {
                entity.HasKey(e => e.Per01Llave);

                entity.ToTable("PER01_Persona");

                entity.Property(e => e.Per01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PER01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Per01Activo).HasColumnName("PER01_Activo");
                entity.Property(e => e.Per01AnioIngreso)
                    
                    .HasColumnName("PER01_AnioIngreso");
                entity.Property(e => e.Per01Cargo)
                    .HasMaxLength(500)
                    .HasColumnName("PER01_Cargo");
                entity.Property(e => e.Per01FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("PER01_FechaNacimiento");
                entity.Property(e => e.Per01Giro)
                    .HasMaxLength(500)
                    .HasColumnName("PER01_Giro");
                entity.Property(e => e.Per01NombreFantasia)
                    .HasMaxLength(500)
                    .HasColumnName("PER01_NombreFantasia");
                entity.Property(e => e.Per01NombreRazon)
                    .HasMaxLength(500)
                    .HasColumnName("PER01_NombreRazon");
                entity.Property(e => e.Per01Rut)
                    
                    .HasColumnName("PER01_Rut");
                entity.Property(e => e.Per02Llave)
                    
                    .HasColumnName("PER02_Llave");
                entity.Property(e => e.Per03Llave)
                    
                    .HasColumnName("PER03_Llave");

                entity.HasOne(d => d.Per02LlaveNavigation).WithMany(p => p.Per01Personas)
                    .HasForeignKey(d => d.Per02Llave)
                    .HasConstraintName("FK_PER01_Persona_PER02_Genero");

                entity.HasOne(d => d.Per03LlaveNavigation).WithMany(p => p.Per01Personas)
                    .HasForeignKey(d => d.Per03Llave)
                    .HasConstraintName("FK_PER01_Persona_PER03_TipoPersona");
            });

            modelBuilder.Entity<Per02Genero>(entity =>
            {
                entity.HasKey(e => e.Per02Llave);

                entity.ToTable("PER02_Genero");

                entity.Property(e => e.Per02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PER02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Per02Activo).HasColumnName("PER02_Activo");
                entity.Property(e => e.Per02Genero1)
                    .HasMaxLength(50)
                    .HasColumnName("PER02_Genero");
                entity.Property(e => e.Per02Orden)
                    
                    .HasColumnName("PER02_Orden");
                entity.Property(e => e.Per02Sexo)
                    .HasMaxLength(50)
                    .HasColumnName("PER02_Sexo");
                entity.Property(e => e.Per02Titulo)
                    .HasMaxLength(50)
                    .HasColumnName("PER02_Titulo");
            });

            modelBuilder.Entity<Per03TipoPersona>(entity =>
            {
                entity.HasKey(e => e.Per03Llave);

                entity.ToTable("PER03_TipoPersona");

                entity.Property(e => e.Per03Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PER03_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Per03Activo).HasColumnName("PER03_Activo");
                entity.Property(e => e.Per03Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("PER03_Descripcion");
                entity.Property(e => e.Per03Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("PER03_Nombre");
            });

            modelBuilder.Entity<Per04TipoComunicacion>(entity =>
            {
                entity.HasKey(e => e.Per04Llave);

                entity.ToTable("PER04_TipoComunicacion");

                entity.Property(e => e.Per04Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PER04_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Per04Activo).HasColumnName("PER04_Activo");
                entity.Property(e => e.Per04Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("PER04_Descripcion");
                entity.Property(e => e.Per04Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("PER04_Nombre");
            });

            modelBuilder.Entity<Per05Comunicacion>(entity =>
            {
                entity.HasKey(e => new { e.Per01Llave, e.Per04Llave, e.Per03Llave });

                entity.ToTable("PER05_Comunicacion");

                entity.Property(e => e.Per01Llave)
                    
                    .HasColumnName("PER01_Llave");
                entity.Property(e => e.Per04Llave)
                    
                    .HasColumnName("PER04_Llave");
                entity.Property(e => e.Per03Llave)
                    
                    .HasColumnName("PER03_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Per05Casilla)
                    .HasMaxLength(500)
                    .HasColumnName("PER05_casilla");
                entity.Property(e => e.Per05Celular1)
                    .HasMaxLength(50)
                    .HasColumnName("PER05_Celular1");
                entity.Property(e => e.Per05Celular2)
                    .HasMaxLength(50)
                    .HasColumnName("PER05_Celular2");
                entity.Property(e => e.Per05CodigoPostal)
                    .HasMaxLength(500)
                    .HasColumnName("PER05_CodigoPostal");
                entity.Property(e => e.Per05Direccion)
                    .HasMaxLength(500)
                    .HasColumnName("PER05_Direccion");
                entity.Property(e => e.Per05Email)
                    .HasMaxLength(250)
                    .HasColumnName("PER05_Email");
                entity.Property(e => e.Per05Fax)
                    .HasMaxLength(50)
                    .HasColumnName("PER05_Fax");
                entity.Property(e => e.Per05SitioWeb)
                    .HasMaxLength(50)
                    .HasColumnName("PER05_SitioWeb");
                entity.Property(e => e.Per05Telefono1)
                    .HasMaxLength(50)
                    .HasColumnName("PER05_Telefono1");
                entity.Property(e => e.Per05Telefono2)
                    .HasMaxLength(50)
                    .HasColumnName("PER05_Telefono2");
                entity.Property(e => e.Per05TieneCasilla).HasColumnName("PER05_TieneCasilla");
                entity.Property(e => e.Sist03Llave)
                    
                    .HasColumnName("SIST03_Llave");

                entity.HasOne(d => d.Per01LlaveNavigation).WithMany(p => p.Per05Comunicacions)
                    .HasForeignKey(d => d.Per01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PER05_Comunicacion_PER01_Persona");

                entity.HasOne(d => d.Per03LlaveNavigation).WithMany(p => p.Per05Comunicacions)
                    .HasForeignKey(d => d.Per03Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PER05_Comunicacion_PER03_TipoPersona");

                entity.HasOne(d => d.Per04LlaveNavigation).WithMany(p => p.Per05Comunicacions)
                    .HasForeignKey(d => d.Per04Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PER05_Comunicacion_PER04_TipoComunicacion");

                entity.HasOne(d => d.Per0).WithMany(p => p.Per05Comunicacions)
                    .HasForeignKey(d => new { d.Per03Llave, d.Per04Llave })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PER05_Comunicacion_PER06_TipoPersonaComunicacion");
            });

            modelBuilder.Entity<Per06TipoPersonaComunicacion>(entity =>
            {
                entity.HasKey(e => new { e.Per03Llave, e.Per04Llave });

                entity.ToTable("PER06_TipoPersonaComunicacion");

                entity.Property(e => e.Per03Llave)
                    
                    .HasColumnName("PER03_Llave");
                entity.Property(e => e.Per04Llave)
                    
                    .HasColumnName("PER04_Llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");

                entity.HasOne(d => d.Per03LlaveNavigation).WithMany(p => p.Per06TipoPersonaComunicacions)
                    .HasForeignKey(d => d.Per03Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PER06_TipoPersonaComunicacion_PER03_TipoPersona");

                entity.HasOne(d => d.Per04LlaveNavigation).WithMany(p => p.Per06TipoPersonaComunicacions)
                    .HasForeignKey(d => d.Per04Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PER06_TipoPersonaComunicacion_PER04_TipoComunicacion");
            });

            modelBuilder.Entity<Per07PersonaUsuario>(entity =>
            {
                entity.HasKey(e => e.Per07Llave);

                entity.ToTable("PER07_PersonaUsuario");

                entity.Property(e => e.Per07Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PER07_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Per01Llave)
                    
                    .HasColumnName("PER01_Llave");
                entity.Property(e => e.Per07Activo).HasColumnName("PER07_Activo");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");

                entity.HasOne(d => d.Per01LlaveNavigation).WithMany(p => p.Per07PersonaUsuarios)
                    .HasForeignKey(d => d.Per01Llave)
                    .HasConstraintName("FK_PER07_PersonaUsuario_PER01_Persona");
            });

            modelBuilder.Entity<Pgo01CompraLicencia>(entity =>
            {
                entity.HasKey(e => e.Pgo1Llave);

                entity.ToTable("PGO01_CompraLicencia");

                entity.Property(e => e.Pgo1Llave)
                    
                    .HasColumnName("PGO1_Llave");
                entity.Property(e => e.Cnt19Llave)
                    
                    .HasColumnName("CNT19_Llave");
                entity.Property(e => e.Fechacompra)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHACOMPRA");
                entity.Property(e => e.Pgo01Activo).HasColumnName("PGO01_Activo");
                entity.Property(e => e.Pgo01TotalCompra)
                   
                    .HasColumnName("PGO01_TotalCompra");
                entity.Property(e => e.Pgo03Llave)
                    
                    .HasColumnName("PGO03_Llave");

                entity.HasOne(d => d.Cnt19LlaveNavigation).WithMany(p => p.Pgo01CompraLicencia)
                    .HasForeignKey(d => d.Cnt19Llave)
                    .HasConstraintName("FK_PGO01_CompraLicencia_CNT01_CuentaCliente");

                entity.HasOne(d => d.Cnt19Llave1).WithMany(p => p.Pgo01CompraLicencia)
                    .HasForeignKey(d => d.Cnt19Llave)
                    .HasConstraintName("FK_PGO01_CompraLicencia_CNT19_LicenciaCliente");

                entity.HasOne(d => d.Pgo03LlaveNavigation).WithMany(p => p.Pgo01CompraLicencia)
                    .HasForeignKey(d => d.Pgo03Llave)
                    .HasConstraintName("FK_PGO01_CompraLicencia_PGO03_FormaPago1");
            });

            modelBuilder.Entity<Pgo02NotificarPagoLicencia>(entity =>
            {
                entity.HasKey(e => e.Pgo02Llave);

                entity.ToTable("PGO02_NotificarPagoLicencia");

                entity.Property(e => e.Pgo02Llave)
                    
                    .HasColumnName("PGO02_Llave");
                entity.Property(e => e.Fechanotificacionpago)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHANOTIFICACIONPAGO");
                entity.Property(e => e.Pgo01Llave)
                    
                    .HasColumnName("PGO01_Llave");
                entity.Property(e => e.Pgo02Activo).HasColumnName("PGO02_Activo");
                entity.Property(e => e.Pgo02DocumentoAdjunto).HasColumnName("PGO02_DocumentoAdjunto");

                entity.HasOne(d => d.Pgo01LlaveNavigation).WithMany(p => p.Pgo02NotificarPagoLicencia)
                    .HasForeignKey(d => d.Pgo01Llave)
                    .HasConstraintName("FK_PGO02_NotificarPagoLicencia_PGO01_CompraLicencia");
            });

            modelBuilder.Entity<Pgo03TipoPagoLicencia>(entity =>
            {
                entity.HasKey(e => e.Pgo03Llave).HasName("PK_PGO03_FormaPago");

                entity.ToTable("PGO03_TipoPagoLicencia");

                entity.Property(e => e.Pgo03Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PGO03_Llave");
                entity.Property(e => e.Pgo03Activo).HasColumnName("PGO03_Activo");
                entity.Property(e => e.Pgo03Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("PGO03_Descripcion");
                entity.Property(e => e.Pgo03Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("PGO03_Nombre");
            });

            modelBuilder.Entity<Prf01Perfil>(entity =>
            {
                entity.HasKey(e => e.Prf01Llave);

                entity.ToTable("PRF01_Perfiles");

                entity.Property(e => e.Prf01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PRF01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Prf01Activo).HasColumnName("PRF01_Activo");
                entity.Property(e => e.Prf05Llave)
                    
                    .HasColumnName("PRF05_llave");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_llave");

                entity.HasOne(d => d.Prf05LlaveNavigation).WithMany(p => p.Prf01Perfiles)
                    .HasForeignKey(d => d.Prf05Llave)
                    .HasConstraintName("FK_PRF01_Perfiles_PRF05_TipoAsignacionUsuario");

                entity.HasOne(d => d.Secu02LlaveNavigation).WithMany(p => p.Prf01Perfiles)
                    .HasForeignKey(d => d.Secu02Llave)
                    .HasConstraintName("FK_PRF01_Perfiles_SECU02_Usuario");

                entity.HasMany(d => d.Prf03Llaves).WithMany(p => p.Prf01Llaves)
                    .UsingEntity<Dictionary<string, object>>(
                        "Prf02PlantillasUsuario",
                        r => r.HasOne<Prf03Plantilla>().WithMany()
                            .HasForeignKey("Prf03Llave")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_PRF02_PlantillasUsuario_PRF03_Plantilla"),
                        l => l.HasOne<Prf01Perfil>().WithMany()
                            .HasForeignKey("Prf01Llave")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_PRF02_PlantillasUsuario_PRF01_Perfiles"),
                        j =>
                        {
                            j.HasKey("Prf01Llave", "Prf03Llave");
                            j.ToTable("PRF02_PlantillasUsuario");
                        });
            });

            modelBuilder.Entity<Prf03Plantilla>(entity =>
            {
                entity.HasKey(e => e.prf03llave).HasName("PK_PRF03_PlantillaPerfil");

                entity.ToTable("PRF03_Plantilla");

                entity.Property(e => e.prf03llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PRF03_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.prf03activo).HasColumnName("PRF03_Activo");
                entity.Property(e => e.prf03descripcion).HasColumnName("PRF03_Descripcion");
                entity.Property(e => e.prf03nombre)
                    .HasMaxLength(500)
                    .HasColumnName("PRF03_Nombre");
            });

            modelBuilder.Entity<Prf04PlantillaPerfil>(entity =>
            {
                entity.HasKey(e => new { e.Prf03Llave, e.Wkf06Llave });

                entity.ToTable("PRF04_plantillaPerfil");

                entity.Property(e => e.Prf03Llave)
                    
                    .HasColumnName("PRF03_Llave");
                entity.Property(e => e.Wkf06Llave)
                    
                    .HasColumnName("WKF06_llave");
                entity.Property(e => e.Prf04Activo).HasColumnName("PRF04_activo");

                entity.HasOne(d => d.Prf03LlaveNavigation).WithMany(p => p.Prf04PlantillaPerfils)
                    .HasForeignKey(d => d.Prf03Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRF04_plantillaPerfil_PRF03_Plantilla");

                entity.HasOne(d => d.Wkf06LlaveNavigation).WithMany(p => p.Prf04PlantillaPerfils)
                    .HasForeignKey(d => d.Wkf06Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRF04_plantillaPerfil_WKF06_Perfiles");
            });

            modelBuilder.Entity<Prf05TipoAsignacionUsuario>(entity =>
            {
                entity.HasKey(e => e.Prf05Llave);

                entity.ToTable("PRF05_TipoAsignacionUsuario");

                entity.Property(e => e.Prf05Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PRF05_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Prf05Activo).HasColumnName("PRF05_Activo");
                entity.Property(e => e.Prf05Descripcion).HasColumnName("PRF05_Descripcion");
                entity.Property(e => e.Prf05Nombre)
                    .HasMaxLength(500)
                    .HasColumnName("PRF05_Nombre");
            });

            modelBuilder.Entity<Prf06PermisosUsuario>(entity =>
            {
                entity.HasKey(e => new { e.Prf01Llave, e.Wkf06Llave });

                entity.ToTable("PRF06_PermisosUsuario");

                entity.Property(e => e.Prf01Llave)
                    
                    .HasColumnName("PRF01_llave");
                entity.Property(e => e.Wkf06Llave)
                    
                    .HasColumnName("WKF06_llave");
                entity.Property(e => e.Prf06Activo).HasColumnName("PRF06_activo");

                entity.HasOne(d => d.Prf01LlaveNavigation).WithMany(p => p.Prf06PermisosUsuarios)
                    .HasForeignKey(d => d.Prf01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRF06_PermisosUsuario_PRF01_Perfiles");

                entity.HasOne(d => d.Wkf06LlaveNavigation).WithMany(p => p.Prf06PermisosUsuarios)
                    .HasForeignKey(d => d.Wkf06Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRF06_PermisosUsuario_WKF06_Perfiles");
            });

            modelBuilder.Entity<Prm01Seguridad>(entity =>
            {
                entity.HasKey(e => e.Prm01Llave);

                entity.ToTable("PRM01_Seguridad");

                entity.Property(e => e.Prm01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("PRM01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Prm01Activo).HasColumnName("PRM01_Activo");
                entity.Property(e => e.Prm01Descripcion).HasColumnName("PRM01_Descripcion");
                entity.Property(e => e.Prm01Nombre)
                    .HasMaxLength(500)
                    .HasColumnName("PRM01_Nombre");
                entity.Property(e => e.Prm01UrlError)
                    .HasMaxLength(500)
                    .HasColumnName("PRM01_UrlError");
                entity.Property(e => e.Prm01Valor)
                    
                    .HasColumnName("PRM01_valor");
            });

            modelBuilder.Entity<Secu01Rol>(entity =>
            {
                entity.HasKey(e => e.Secu01Llave).HasName("PK__SECU01_R__2E718C9349B338EE");

                entity.ToTable("SECU01_Rol");

                entity.Property(e => e.Secu01Llave)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("SECU01_Llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Secu01Activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU01_Activo");
                entity.Property(e => e.Secu01Descripcion).HasColumnName("SECU01_Descripcion");
                entity.Property(e => e.Secu01Info)
                    .HasColumnType("xml")
                    .HasColumnName("SECU01_Info");
                entity.Property(e => e.Secu01Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("SECU01_Nombre");
                entity.Property(e => e.Secu01Orden).HasColumnName("SECU01_Orden");
            });

            modelBuilder.Entity<Secu02Usuario>(entity =>
            {
                entity.HasKey(e => e.Secu02Llave).HasName("PK__SECU02_U__B709E3CA34F4CE22");

                entity.ToTable("SECU02_Usuario");

                entity.Property(e => e.Secu02Llave)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("SECU02_Llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Secu02Activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU02_Activo");
                entity.Property(e => e.Secu02Bloqueado)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("SECU02_Bloqueado");
                entity.Property(e => e.Secu02Clave)
                    .HasMaxLength(200)
                    .HasColumnName("SECU02_Clave");
                entity.Property(e => e.Secu02ComplementoClave)
                    .HasMaxLength(300)
                    .HasColumnName("SECU02_ComplementoClave");
                entity.Property(e => e.Secu02Email)
                    .HasMaxLength(300)
                    .HasColumnName("SECU02_Email");
                entity.Property(e => e.Secu02FechaBloqueo)
                    .HasColumnType("datetime")
                    .HasColumnName("SECU02_FechaBloqueo");
                entity.Property(e => e.Secu02FechaCambioPass)
                    .HasColumnType("datetime")
                    .HasColumnName("SECU02_FechaCambioPass");
                entity.Property(e => e.Secu02Movil)
                    .HasMaxLength(20)
                    .HasColumnName("SECU02_Movil");
                entity.Property(e => e.Secu02Pregunta).HasColumnName("SECU02_Pregunta");
                entity.Property(e => e.Secu02Respuesta)
                    .HasMaxLength(600)
                    .HasColumnName("SECU02_Respuesta");
                entity.Property(e => e.Secu02Usuario1)
                    .HasMaxLength(100)
                    .HasColumnName("SECU02_Usuario");
                entity.Property(e => e.Secu04TipoEncriptacion).HasColumnName("SECU04_TipoEncriptacion");

                entity.HasOne(d => d.Secu04TipoEncriptacionNavigation).WithMany(p => p.Secu02Usuarios)
                    .HasForeignKey(d => d.Secu04TipoEncriptacion)
                    .HasConstraintName("FK_SECU02_Usuario_SECU04_TipoEncriptacion1");
            });

            modelBuilder.Entity<Secu03TipoAcceso>(entity =>
            {
                entity.HasKey(e => e.Secu03Llave).HasName("PK__SECU03_T__7B6F14E7DEC70462");

                entity.ToTable("SECU03_TipoAcceso");

                entity.Property(e => e.Secu03Llave)
                    .HasDefaultValueSql("(newsequentialid())")
                    .HasColumnName("SECU03_Llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Secu03Activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU03_Activo");
                entity.Property(e => e.Secu03Descripcion).HasColumnName("SECU03_Descripcion");
                entity.Property(e => e.Secu03Info)
                    .HasColumnType("xml")
                    .HasColumnName("SECU03_Info");
                entity.Property(e => e.Secu03Nombre)
                    .HasMaxLength(300)
                    .HasColumnName("SECU03_Nombre");
            });

            modelBuilder.Entity<Secu04TipoEncriptacion>(entity =>
            {
                entity.HasKey(e => e.Secu04Llave).HasName("PK__SECU04_T__3412AACF89203574");

                entity.ToTable("SECU04_TipoEncriptacion");

                entity.Property(e => e.Secu04Llave)
                    .ValueGeneratedNever()
                    .HasColumnName("SECU04_Llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Secu04Activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU04_Activo");
                entity.Property(e => e.Secu04Clase).HasColumnName("SECU04_Clase");
                entity.Property(e => e.Secu04Funcion).HasColumnName("SECU04_Funcion");
                entity.Property(e => e.Secu04Info)
                    .HasColumnType("xml")
                    .HasColumnName("SECU04_Info");
                entity.Property(e => e.Secu04Nombre)
                    .HasMaxLength(200)
                    .HasColumnName("SECU04_Nombre");
                entity.Property(e => e.Secu04Parametros)
                    .HasColumnType("xml")
                    .HasColumnName("SECU04_Parametros");
                entity.Property(e => e.Secu04Proyecto).HasColumnName("SECU04_Proyecto");
            });

            modelBuilder.Entity<Secu05UsuarioAcceso>(entity =>
            {
                entity.HasKey(e => e.Secu05Llave).HasName("PK__SECU05_U__2980F8C26FA412CE");

                entity.ToTable("SECU05_UsuarioAcceso");

                entity.Property(e => e.Secu05Llave)
                    .HasDefaultValueSql("(newsequentialid())")
                    .HasColumnName("SECU05_Llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");
                entity.Property(e => e.Secu03TipoAcceso).HasColumnName("SECU03_TipoAcceso");
                entity.Property(e => e.Secu05Activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU05_Activo");
                entity.Property(e => e.Secu05Bloqueado)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("SECU05_Bloqueado");
                entity.Property(e => e.Secu05FechaBloqueo)
                    .HasColumnType("datetime")
                    .HasColumnName("SECU05_FechaBloqueo");
                entity.Property(e => e.Secu05FechaMensaje)
                    .HasColumnType("datetime")
                    .HasColumnName("SECU05_FechaMensaje");
                entity.Property(e => e.Secu05FechaUltAcceso)
                    .HasColumnType("datetime")
                    .HasColumnName("SECU05_FechaUltAcceso");
                entity.Property(e => e.Secu05FechaUltActividad)
                    .HasColumnType("datetime")
                    .HasColumnName("SECU05_FechaUltActividad");
                entity.Property(e => e.Secu05FechaUltDescarga)
                    .HasColumnType("datetime")
                    .HasColumnName("SECU05_FechaUltDescarga");
                entity.Property(e => e.Secu05ForzarDescarga)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("SECU05_ForzarDescarga");
                entity.Property(e => e.Secu05Info)
                    .HasColumnType("xml")
                    .HasColumnName("SECU05_Info");
                entity.Property(e => e.Secu05LlaveAcceso)
                    .HasMaxLength(500)
                    .HasColumnName("SECU05_LlaveAcceso");
                entity.Property(e => e.Secu05Mensaje)
                    .HasMaxLength(500)
                    .HasColumnName("SECU05_Mensaje");
                entity.Property(e => e.Secu05Soacceso)
                    .HasMaxLength(200)
                    .HasColumnName("SECU05_SOAcceso");
                entity.Property(e => e.Secu05VersionActual)
                    .HasMaxLength(20)
                    .HasColumnName("SECU05_VersionActual");
                entity.Property(e => e.Secu05VersionDescarga)
                    .HasMaxLength(20)
                    .HasColumnName("SECU05_VersionDescarga");

                entity.HasOne(d => d.Secu02LlaveNavigation).WithMany(p => p.Secu05UsuarioAccesos)
                    .HasForeignKey(d => d.Secu02Llave)
                    .HasConstraintName("FK_SECU05_UsuarioAcceso_SECU02_Usuario");

                entity.HasOne(d => d.Secu03TipoAccesoNavigation).WithMany(p => p.Secu05UsuarioAccesos)
                    .HasForeignKey(d => d.Secu03TipoAcceso)
                    .HasConstraintName("FK_SECU05_UsuarioAcceso_SECU03_TipoAcceso");
            });

            modelBuilder.Entity<Secu06UsuarioRol>(entity =>
            {
                entity.HasKey(e => new { e.Secu01Llave, e.Secu02Llave });

                entity.ToTable("SECU06_UsuarioRol");

                entity.Property(e => e.Secu01Llave).HasColumnName("SECU01_Llave");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Secu06Activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU06_Activo");

                entity.HasOne(d => d.Secu01LlaveNavigation).WithMany(p => p.Secu06UsuarioRols)
                    .HasForeignKey(d => d.Secu01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SECU06_UsuarioRol_SECU01_Rol");

                entity.HasOne(d => d.Secu02LlaveNavigation).WithMany(p => p.Secu06UsuarioRols)
                    .HasForeignKey(d => d.Secu02Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SECU06_UsuarioRol_SECU02_Usuario");
            });

            modelBuilder.Entity<Secu07Aplicacion>(entity =>
            {
                entity.HasKey(e => e.Secu07Llave).HasName("PK__SECU07_A__148FCE85966FFC87");

                entity.ToTable("SECU07_Aplicacion");

                entity.Property(e => e.Secu07Llave)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("SECU07_Llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Secu07Activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU07_Activo");
                entity.Property(e => e.Secu07Descripcion).HasColumnName("SECU07_Descripcion");
                entity.Property(e => e.Secu07Info)
                    .HasColumnType("xml")
                    .HasColumnName("SECU07_Info");
                entity.Property(e => e.Secu07Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("SECU07_Nombre");
            });

            modelBuilder.Entity<Secu08UsuarioAplicacion>(entity =>
            {
                entity.HasKey(e => new { e.Secu02Llave, e.Secu07Llave }).HasName("PK_UsuarioAplicacion");

                entity.ToTable("SECU08_UsuarioAplicacion");

                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");
                entity.Property(e => e.Secu07Llave).HasColumnName("SECU07_Llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Secu08Activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU08_Activo");
                entity.Property(e => e.Secu08Info)
                    .HasColumnType("xml")
                    .HasColumnName("SECU08_Info");
                entity.Property(e => e.Secu08Observacion).HasColumnName("SECU08_Observacion");

                entity.HasOne(d => d.Secu02LlaveNavigation).WithMany(p => p.Secu08UsuarioAplicacions)
                    .HasForeignKey(d => d.Secu02Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioAplicacion_Usuario");

                entity.HasOne(d => d.Secu07LlaveNavigation).WithMany(p => p.Secu08UsuarioAplicacions)
                    .HasForeignKey(d => d.Secu07Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioAplicacion_Aplicacion");
            });

            modelBuilder.Entity<Secu10AccesoPermitido>(entity =>
            {
                entity.HasKey(e => e.Secu10Llave);

                entity.ToTable("SECU10_AccesoPermitido");

                entity.Property(e => e.Secu10Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("SECU10_Llave");
                entity.Property(e => e.Activo).HasColumnName("activo");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Secu02Llave).HasColumnName("SECU02_Llave");
                entity.Property(e => e.Secu03Llave).HasColumnName("SECU03_Llave");

                entity.HasOne(d => d.Secu02LlaveNavigation).WithMany(p => p.Secu10AccesoPermitidos)
                    .HasForeignKey(d => d.Secu02Llave)
                    .HasConstraintName("FK_SECU10_AccesoPermitido_SECU02_Usuario");

                entity.HasOne(d => d.Secu03LlaveNavigation).WithMany(p => p.Secu10AccesoPermitidos)
                    .HasForeignKey(d => d.Secu03Llave)
                    .HasConstraintName("FK_SECU10_AccesoPermitido_SECU03_TipoAcceso");
            });

            modelBuilder.Entity<Secu11TipoPerfil>(entity =>
            {
                entity.HasKey(e => e.Prf02Llave);

                entity.ToTable("SECU11_TipoPerfil");

                entity.Property(e => e.Prf02Llave)
                    
                    .HasColumnName("PRF02_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.Fechaactulizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTULIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Prf02Descripcion)
                    .HasMaxLength(2000)
                    .HasColumnName("PRF02_Descripcion");
                entity.Property(e => e.Prf02Nombre)
                    .HasMaxLength(500)
                    .HasColumnName("PRF02_Nombre");
            });

            modelBuilder.Entity<Sercl01ServiciosCliente>(entity =>
            {
                entity.HasKey(e => e.Sercl01Llave);

                entity.ToTable("SERCL01_ServiciosClientes");

                entity.Property(e => e.Sercl01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("SERCL01_Llave");
                entity.Property(e => e.Cnt01Llave)
                    
                    .HasColumnName("CNT01_Llave");
                entity.Property(e => e.Cnt08Llave)
                    
                    .HasColumnName("CNT08_Llave");
                entity.Property(e => e.Cnt19Llave)
                    
                    .HasColumnName("CNT19_Llave");
                entity.Property(e => e.Conteo03Llave)
                    
                    .HasColumnName("CONTEO03_Llave");
                entity.Property(e => e.Esp03Llave)
                    
                    .HasColumnName("ESP03_Llave");
                entity.Property(e => e.Esp04Llave)
                    
                    .HasColumnName("ESP04_Llave");
                entity.Property(e => e.Esp08Llave)
                    
                    .HasColumnName("ESP08_Llave");
                entity.Property(e => e.Sercl01Cantidad)
                    
                    .HasColumnName("SERCL01_cantidad");
                entity.Property(e => e.Sercl01Costo)
                   
                    .HasColumnName("SERCL01_Costo");
                entity.Property(e => e.Sercl01TipoGrafico)
                    
                    .HasColumnName("SERCL01_TipoGrafico");
                entity.Property(e => e.Serv01Llave)
                    
                    .HasColumnName("SERV01_Llave");
                entity.Property(e => e.Sist03Llave)
                    
                    .HasColumnName("SIST03_Llave");
                entity.Property(e => e.sist04llave)
                    
                    .HasColumnName("SISt04_Llave");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");
            });

            modelBuilder.Entity<Sercl02MuestreoFruta>(entity =>
            {
                entity.HasKey(e => e.Sercl02Llave);

                entity.ToTable("SERCL02_MuestreoFruta");

                entity.Property(e => e.Sercl02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("SERCL02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Sercl01Llave)
                    
                    .HasColumnName("SERCL01_Llave");
                entity.Property(e => e.Sercl02Activo).HasColumnName("SERCL02_Activo");
                entity.Property(e => e.Sercl02Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("SERCL02_Fecha");
                entity.Property(e => e.Sercl02Nombre)
                    .HasMaxLength(500)
                    .HasColumnName("SERCL02_Nombre");
                entity.Property(e => e.Sercl02UrlPdf)
                    .HasMaxLength(1000)
                    .HasColumnName("SERCL02_UrlPdf");

                entity.HasOne(d => d.Sercl01LlaveNavigation).WithMany(p => p.Sercl02MuestreoFruta)
                    .HasForeignKey(d => d.Sercl01Llave)
                    .HasConstraintName("FK_SERCL02_MuestreoFruta_SERCL01_ServiciosClientes");
            });

            modelBuilder.Entity<Sercltemp01ServiciosClientesTemporal>(entity =>
            {
                entity.HasKey(e => e.Sercltemp01Llave);

                entity.ToTable("SERCLTEMP01_ServiciosClientes_Temporal");

                entity.Property(e => e.Sercltemp01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("SERCLTEMP01_Llave");
                entity.Property(e => e.Cntemp01Llave)
                    
                    .HasColumnName("CNTEMP01_Llave");
                entity.Property(e => e.Cntemp02Llave)
                    
                    .HasColumnName("CNTEMP02_Llave");
                entity.Property(e => e.Conteo03Llave)
                    
                    .HasColumnName("CONTEO03_Llave");
                entity.Property(e => e.Sercltemp01TipoGrafico)
                    
                    .HasColumnName("SERCLTEMP01_TipoGrafico");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");

                entity.HasOne(d => d.Conteo03LlaveNavigation).WithMany(p => p.Sercltemp01ServiciosClientesTemporals)
                    .HasForeignKey(d => d.Conteo03Llave)
                    .HasConstraintName("FK_SERCLTEMP01_ServiciosClientes_Temporal_CONTEO03_Resumen");
            });

            modelBuilder.Entity<Serv01Servicio>(entity =>
            {
                entity.HasKey(e => e.Serv01Llave);

                entity.ToTable("SERV01_Servicio");

                entity.Property(e => e.Serv01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("SERV01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Serv01Activo).HasColumnName("SERV01_Activo");
                entity.Property(e => e.Serv01Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("SERV01_Descripcion");
                entity.Property(e => e.Serv01Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("SERV01_Nombre");
                entity.Property(e => e.Serv02Llave)
                    
                    .HasColumnName("SERV02_llave");

                entity.HasOne(d => d.Serv02LlaveNavigation).WithMany(p => p.Serv01Servicios)
                    .HasForeignKey(d => d.Serv02Llave)
                    .HasConstraintName("FK_SERV01_Servicio_SERV02_TipoServicio");
            });

            modelBuilder.Entity<Serv02TipoServicio>(entity =>
            {
                entity.HasKey(e => e.Serv02Llave);

                entity.ToTable("SERV02_TipoServicio");

                entity.Property(e => e.Serv02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("SERV02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Serv02Activo).HasColumnName("SERV02_Activo");
                entity.Property(e => e.Serv02Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("SERV02_Descripcion");
                entity.Property(e => e.Serv02Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("SERV02_Nombre");
            });

            modelBuilder.Entity<Sist01Sistema>(entity =>
            {
                entity.HasKey(e => e.Sist01Llave);

                entity.ToTable("SIST01_Sistema");

                entity.Property(e => e.Sist01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("SIST01_Llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Sist01Activo).HasColumnName("SIST01_Activo");
                entity.Property(e => e.Sist01Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("SIST01_Descripcion");
                entity.Property(e => e.Sist01EsPublica).HasColumnName("SIST01_EsPublica");
                entity.Property(e => e.Sist01EsServicios).HasColumnName("SIST01_EsServicios");
                entity.Property(e => e.Sist01Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("SIST01_Nombre");
            });

            modelBuilder.Entity<Sist02Zona>(entity =>
            {
                entity.HasKey(e => e.sist02llave);

                entity.ToTable("SIST02_Zona");

                entity.Property(e => e.sist02llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("SIST02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.sist02activo).HasColumnName("SIST02_Activo");
                entity.Property(e => e.sist02descripcion).HasColumnName("SIST02_Descripcion");
                entity.Property(e => e.sist02estadoregistro)
                    .HasMaxLength(50)
                    .HasColumnName("SIST02_estadoregistro");
                entity.Property(e => e.sist02nombre)
                    .HasMaxLength(500)
                    .HasColumnName("SIST02_Nombre");

                entity.HasMany(d => d.sist03llaves).WithMany(p => p.Sist02Llaves)
                    .UsingEntity<Dictionary<string, object>>(
                        "Sist07ZonaComuna",
                        r => r.HasOne<Sist03Comuna>().WithMany()
                            .HasForeignKey("Sist03Llave")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_SIST07_ZonaComuna_SIST03_Comuna"),
                        l => l.HasOne<Sist02Zona>().WithMany()
                            .HasForeignKey("Sist02Llave")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_SIST07_ZonaComuna_SIST02_Zona"),
                        j =>
                        {
                            j.HasKey("Sist02Llave", "Sist03Llave");
                            j.ToTable("SIST07_ZonaComuna");
                        });
            });

            modelBuilder.Entity<Sist03Comuna>(entity =>
            {
                entity.HasKey(e => e.sist03llave);

                entity.ToTable("SIST03_Comuna");

                entity.Property(e => e.sist03llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("SIST03_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.sist03activo).HasColumnName("SIST03_Activo");
                entity.Property(e => e.sist03capital).HasColumnName("SIST03_Capital");
                entity.Property(e => e.sist03descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("SIST03_Descripcion");
                entity.Property(e => e.sist03nombre)
                    .HasMaxLength(250)
                    .HasColumnName("SIST03_Nombre");
                entity.Property(e => e.sist04llave)
                    
                    .HasColumnName("SIST04_Llave");

                entity.HasOne(d => d.sist04llaveNavigation).WithMany(p => p.Sist03Comunas)
                    .HasForeignKey(d => d.sist04llave)
                    .HasConstraintName("FK_SIST03_Comuna_SIST04_Region");
            });

            modelBuilder.Entity<Sist04Region>(entity =>
            {
                entity.HasKey(e => e.sist04llave);

                entity.ToTable("SIST04_Region");

                entity.Property(e => e.sist04llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("SIST04_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.sist04activo).HasColumnName("SIST04_Activo");
                entity.Property(e => e.sist04descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("SIST04_Descripcion");
                entity.Property(e => e.sist04nombre)
                    .HasMaxLength(250)
                    .HasColumnName("SIST04_Nombre");
                entity.Property(e => e.sist04orden)
                    
                    .HasColumnName("SIST04_Orden");
            });

            modelBuilder.Entity<Sist05EstadoRegistro>(entity =>
            {
                entity.HasKey(e => e.Sist05Llave);

                entity.ToTable("SIST05_EstadoRegistro");

                entity.Property(e => e.Sist05Llave).HasColumnName("SIST05_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Sist03Activo).HasColumnName("SIST03_Activo");
                entity.Property(e => e.Sist03Descripcion).HasColumnName("SIST03_Descripcion");
                entity.Property(e => e.Sist05Nombre)
                    .HasMaxLength(500)
                    .HasColumnName("SIST05_Nombre");
            });

            modelBuilder.Entity<Sist06EstadoGrid>(entity =>
            {
                entity.HasKey(e => e.Sist06Llave);

                entity.ToTable("SIST06_EstadoGrid");

                entity.Property(e => e.Sist06Llave)
                    
                    .HasColumnName("SIST06_Llave");
                entity.Property(e => e.Sist06Activo).HasColumnName("SIST06_Activo");
                entity.Property(e => e.Sist06Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("SIST06_Nombre");
            });

            modelBuilder.Entity<Sist08ContactoUsuario>(entity =>
            {
                entity.HasKey(e => e.Sist08Llave);

                entity.ToTable("SIST08_ContactoUsuario");

                entity.Property(e => e.Sist08Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("SIST08_Llave");
                entity.Property(e => e.Per02Llave)
                    
                    .HasColumnName("PER02_Llave");
                entity.Property(e => e.Sist08Celular)
                    .HasMaxLength(15)
                    .HasColumnName("SIST08_Celular");
                entity.Property(e => e.Sist08Comentario).HasColumnName("SIST08_Comentario");
                entity.Property(e => e.Sist08Correo)
                    .HasMaxLength(50)
                    .HasColumnName("SIST08_Correo");
                entity.Property(e => e.Sist08Empresa)
                    .HasMaxLength(250)
                    .HasColumnName("SIST08_Empresa");
                entity.Property(e => e.Sist08Estado).HasColumnName("SIST08_Estado");
                entity.Property(e => e.Sist08Fechacreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("SIST08_FECHACREACION");
                entity.Property(e => e.Sist08Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("SIST08_Nombre");
                entity.Property(e => e.Sist08Telefono)
                    .HasMaxLength(15)
                    .HasColumnName("SIST08_Telefono");

                entity.HasOne(d => d.Per02LlaveNavigation).WithMany(p => p.Sist08ContactoUsuarios)
                    .HasForeignKey(d => d.Per02Llave)
                    .HasConstraintName("FK_SIST08_ContactoUsuario_PER02_Genero");
            });

            modelBuilder.Entity<Temp01Temporada>(entity =>
            {
                entity.HasKey(e => e.Temp01Llave);

                entity.ToTable("TEMP01_Temporada");

                entity.Property(e => e.Temp01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("TEMP01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Temp01Activo).HasColumnName("TEMP01_Activo");
                entity.Property(e => e.Temp01Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("TEMP01_Descripcion");
                entity.Property(e => e.Temp01MaxFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("TEMP01_MaxFecha");
                entity.Property(e => e.Temp01MaxMes).HasColumnName("TEMP01_MaxMes");
                entity.Property(e => e.Temp01MinFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("TEMP01_MinFecha");
                entity.Property(e => e.Temp01MinMes).HasColumnName("TEMP01_MinMes");
                entity.Property(e => e.Temp01Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("TEMP01_Nombre");
                entity.Property(e => e.Temp01Periodo).HasColumnName("TEMP01_Periodo");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");
                entity.Property(e => e.Temp03Llave)
                    
                    .HasColumnName("TEMP03_Llave");

                entity.HasOne(d => d.Temp02LlaveNavigation).WithMany(p => p.Temp01Temporada)
                    .HasForeignKey(d => d.Temp02Llave)
                    .HasConstraintName("FK_TEMP01_Temporada_TEMP02_TemporadaBase");

                entity.HasOne(d => d.Temp03LlaveNavigation).WithMany(p => p.Temp01Temporada)
                    .HasForeignKey(d => d.Temp03Llave)
                    .HasConstraintName("FK_TEMP01_Temporada_TEMP03_Segmentacion");
            });

            modelBuilder.Entity<Temp02TemporadaBase>(entity =>
            {
                entity.HasKey(e => e.Temp02Llave);

                entity.ToTable("TEMP02_TemporadaBase");

                entity.Property(e => e.Temp02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("TEMP02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Temp02Activo).HasColumnName("TEMP02_Activo");
                entity.Property(e => e.Temp02Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("TEMP02_Descripcion");
                entity.Property(e => e.Temp02Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("TEMP02_Nombre");
                entity.Property(e => e.Temp02Predeterminada).HasColumnName("TEMP02_Predeterminada");
            });

            modelBuilder.Entity<Temp03Segmentacion>(entity =>
            {
                entity.HasKey(e => e.Temp03Llave);

                entity.ToTable("TEMP03_Segmentacion");

                entity.Property(e => e.Temp03Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("TEMP03_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Temp03Activo).HasColumnName("TEMP03_Activo");
                entity.Property(e => e.Temp03Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("TEMP03_Descripcion");
                entity.Property(e => e.Temp03Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("TEMP03_Nombre");
                entity.Property(e => e.Temp03NumeroMeses).HasColumnName("TEMP03_NumeroMeses");
                entity.Property(e => e.Temp03NumeroSegmentosTotal).HasColumnName("TEMP03_NumeroSegmentosTotal");
            });

            modelBuilder.Entity<Trp01Trampa>(entity =>
            {
                entity.HasKey(e => e.Trp01Llave);

                entity.ToTable("TRP01_Trampa");

                entity.Property(e => e.Trp01Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("TRP01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Cnt08Llave)
                    
                    .HasColumnName("CNT08_Llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Esp01Llave)
                    
                    .HasColumnName("ESP01_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Trp01Activo).HasColumnName("TRP01_Activo");
                entity.Property(e => e.Trp01Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("TRP01_Nombre");
                entity.Property(e => e.Trp01Numero)
                    
                    .HasColumnName("TRP01_Numero");

                entity.HasOne(d => d.Cnt08LlaveNavigation).WithMany(p => p.Trp01Trampas)
                    .HasForeignKey(d => d.Cnt08Llave)
                    .HasConstraintName("FK_TRP01_Trampa_CNT08_Segmentacion");

                entity.HasOne(d => d.Esp01LlaveNavigation).WithMany(p => p.Trp01Trampas)
                    .HasForeignKey(d => d.Esp01Llave)
                    .HasConstraintName("FK_TRP01_Trampa_ESP01_Especies");
            });

            modelBuilder.Entity<Trp02Temporada>(entity =>
            {
                entity.HasKey(e => e.Trp02Llave);

                entity.ToTable("TRP02_Temporada");

                entity.Property(e => e.Trp02Llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("TRP02_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.Temp02Activo).HasColumnName("TEMP02_Activo");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");
                entity.Property(e => e.Trp01Llave)
                    
                    .HasColumnName("TRP01_Llave");

                entity.HasOne(d => d.Temp02LlaveNavigation).WithMany(p => p.Trp02Temporada)
                    .HasForeignKey(d => d.Temp02Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRP02_Temporada_TEMP02_TemporadaBase");

                entity.HasOne(d => d.Trp01LlaveNavigation).WithMany(p => p.Trp02Temporada)
                    .HasForeignKey(d => d.Trp01Llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRP02_Temporada_TRP01_Trampa");
            });

            modelBuilder.Entity<Trp03Geocordenada>(entity =>
            {
                entity.HasKey(e => new { e.Trp01Llave, e.Temp02Llave });

                entity.ToTable("TRP03_geocordenadas");

                entity.Property(e => e.Trp01Llave)
                    
                    .HasColumnName("TRP01_Llave");
                entity.Property(e => e.Temp02Llave)
                    
                    .HasColumnName("TEMP02_Llave");
                entity.Property(e => e.X)
                    .HasMaxLength(50)
                    .HasColumnName("x");
                entity.Property(e => e.Y)
                    .HasMaxLength(50)
                    .HasColumnName("y");
            });

            modelBuilder.Entity<Wkf01Flujo>(entity =>
            {
                entity.HasKey(e => e.wkf01llave);

                entity.ToTable("WKF01_Flujo");

                entity.Property(e => e.wkf01llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("WKF01_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.wkf01activo).HasColumnName("WKF01_Activo");
                entity.Property(e => e.wkf01descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("WKF01_Descripcion");
                entity.Property(e => e.wkf01directorio).HasColumnName("WKF01_Directorio");
                entity.Property(e => e.wkf01esinicio).HasColumnName("WKF01_EsInicio");
                entity.Property(e => e.wkf01estadoregistro)
                    .HasMaxLength(500)
                    .HasColumnName("WKF01_estadoRegistro");
                entity.Property(e => e.wkf01iconourl)
                    .HasMaxLength(500)
                    .HasColumnName("WKF01_iconoUrl");
                entity.Property(e => e.wkf01imagengrande)
                    .HasMaxLength(500)
                    .HasColumnName("WKF01_ImagenGrande");
                entity.Property(e => e.wkf01imagenpequena)
                    .HasMaxLength(500)
                    .HasColumnName("WKF01_ImagenPequena");
                entity.Property(e => e.wkf01llavepadre)
                    
                    .HasColumnName("WKF01_LlavePadre");
                entity.Property(e => e.wkf01nombre)
                    .HasMaxLength(250)
                    .HasColumnName("WKF01_Nombre");
                entity.Property(e => e.wkf01orden)
                    
                    .HasColumnName("WKF01_Orden");
                entity.Property(e => e.wkf01prioridad)
                    
                    .HasColumnName("WKF01_Prioridad");
                entity.Property(e => e.wkf01url).HasColumnName("WKF01_url");
                entity.Property(e => e.wkf01visiblemenu).HasColumnName("WKF01_visibleMenu");
                entity.Property(e => e.wkf03llave)
                    
                    .HasColumnName("WKF03_Llave");

                entity.HasOne(d => d.Wkf03LlaveNavigation).WithMany(p => p.Wkf01Flujos)
                    .HasForeignKey(d => d.wkf03llave)
                    .HasConstraintName("FK_WKF01_Flujo_WKF03_Nivel");
            });

            modelBuilder.Entity<Wkf02TipoFlujo>(entity =>
            {
                entity.HasKey(e => e.wkf02llave);

                entity.ToTable("WKF02_TipoFlujo");

                entity.Property(e => e.wkf02llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("WKF02_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.wkf02activo).HasColumnName("WKF02_Activo");
                entity.Property(e => e.wkf02descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("WKF02_Descripcion");
                entity.Property(e => e.wkf02nombre)
                    .HasMaxLength(250)
                    .HasColumnName("WKF02_Nombre");
                entity.Property(e => e.wkf02orden).HasColumnName("WKF02_orden");
            });

            modelBuilder.Entity<Wkf03Nivel>(entity =>
            {
                entity.HasKey(e => e.wkf03llave);

                entity.ToTable("WKF03_Nivel");

                entity.Property(e => e.wkf03llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("WKF03_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.wkf02llave)
                    
                    .HasColumnName("WKF02_Llave");
                entity.Property(e => e.wkf03activo).HasColumnName("WKF03_Activo");
                entity.Property(e => e.wkf03descripcion).HasColumnName("WKF03_Descripcion");
                entity.Property(e => e.wkf03nivel1).HasColumnName("WKF03_Nivel");
                entity.Property(e => e.wkf03nombre)
                    .HasMaxLength(250)
                    .HasColumnName("WKF03_Nombre");

                entity.HasOne(d => d.Wkf02LlaveNavigation).WithMany(p => p.Wkf03Nivels)
                    .HasForeignKey(d => d.wkf02llave)
                    .HasConstraintName("FK_WKF03_Nivel_WKF02_TipoFlujo");
            });

            modelBuilder.Entity<Wkf04NivelPermiso>(entity =>
            {
                entity.HasKey(e => e.wkf04llave).HasName("PK_WKF04_NivelPremiso");

                entity.ToTable("WKF04_NivelPermiso");

                entity.Property(e => e.wkf04llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("WKF04_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.wkf03llave)
                    
                    .HasColumnName("WKF03_llave");
                entity.Property(e => e.wkf04activo).HasColumnName("WKF04_Activo");
                entity.Property(e => e.wkf05llave)
                    
                    .HasColumnName("WKF05_llave");

                entity.HasOne(d => d.Wkf03LlaveNavigation).WithMany(p => p.Wkf04NivelPermisos)
                    .HasForeignKey(d => d.wkf03llave)
                    .HasConstraintName("FK_WKF04_NivelPermiso_WKF03_Nivel");

                entity.HasOne(d => d.Wkf05LlaveNavigation).WithMany(p => p.Wkf04NivelPermisos)
                    .HasForeignKey(d => d.wkf05llave)
                    .HasConstraintName("FK_WKF04_NivelPermiso_WKF05_TipoPermiso");
            });

            modelBuilder.Entity<Wkf05TipoPermiso>(entity =>
            {
                entity.HasKey(e => e.wkf05llave).HasName("PK_WKF05_TipoPerfil");

                entity.ToTable("WKF05_TipoPermiso");

                entity.Property(e => e.wkf05llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("WKF05_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.wkf05activo).HasColumnName("WKF05_Activo");
                entity.Property(e => e.wkf05descripcion).HasColumnName("WKF05_Descripcion");
                entity.Property(e => e.wkf05nombre)
                    .HasMaxLength(500)
                    .HasColumnName("WKF05_Nombre");
                entity.Property(e => e.wkf05sigla)
                    .HasMaxLength(2)
                    .HasColumnName("WKF05_sigla");
            });

            modelBuilder.Entity<Wkf06Perfil>(entity =>
            {
                entity.HasKey(e => e.wkf06llave);

                entity.ToTable("WKF06_Perfiles");

                entity.Property(e => e.wkf06llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("WKF06_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.wkf01llave)
                    
                    .HasColumnName("WKF01_llave");
                entity.Property(e => e.wkf06activo).HasColumnName("WKF06_Activo");
                entity.Property(e => e.wkf06descripcion).HasColumnName("WKF06_Descripcion");
                entity.Property(e => e.wkf06nombre)
                    .HasMaxLength(500)
                    .HasColumnName("WKF06_Nombre");

                entity.HasOne(d => d.Wkf01LlaveNavigation).WithMany(p => p.Wkf06Perfiles)
                    .HasForeignKey(d => d.wkf01llave)
                    .HasConstraintName("FK_WKF06_Perfiles_WKF01_Flujo");
            });

            modelBuilder.Entity<Wkf07PerfilesPermiso>(entity =>
            {
                entity.HasKey(e => new { e.wkf06llave, e.wkf05llave });

                entity.ToTable("WKF07_PerfilesPermiso");

                entity.Property(e => e.wkf06llave)
                    
                    .HasColumnName("WKF06_llave");
                entity.Property(e => e.wkf05llave)
                    
                    .HasColumnName("WKF05_llave");
                entity.Property(e => e.wkf07activo).HasColumnName("WKF07_activo");

                entity.HasOne(d => d.Wkf05LlaveNavigation).WithMany(p => p.Wkf07PerfilesPermisos)
                    .HasForeignKey(d => d.wkf05llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WKF07_PerfilesPermiso_WKF05_TipoPermiso");

                entity.HasOne(d => d.Wkf06LlaveNavigation).WithMany(p => p.Wkf07PerfilesPermisos)
                    .HasForeignKey(d => d.wkf06llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WKF07_PerfilesPermiso_WKF06_Perfiles");
            });

            modelBuilder.Entity<Wkf08Area>(entity =>
            {
                entity.HasKey(e => e.wfk08llave).HasName("PK_WFK08_Area");

                entity.ToTable("WKF08_Area");

                entity.Property(e => e.wfk08llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("WFK08_Llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.wfk08activo).HasColumnName("WFK08_Activo");
                entity.Property(e => e.wfk08descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("WFK08_Descripcion");
                entity.Property(e => e.wfk08nombre)
                    .HasMaxLength(50)
                    .HasColumnName("WFK08_Nombre");
            });

            modelBuilder.Entity<Wkf09Parametro>(entity =>
            {
                entity.HasKey(e => e.wkf09llave);

                entity.ToTable("WKF09_Parametro");

                entity.Property(e => e.wkf09llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("WKF09_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.wkf01llave)
                    
                    .HasColumnName("WKF01_Llave");
                entity.Property(e => e.wkf09activo).HasColumnName("WKF09_Activo");
                entity.Property(e => e.wkf09valor)
                    .HasMaxLength(500)
                    .HasColumnName("WKF09_Valor");
                entity.Property(e => e.wkf09variable)
                    .HasMaxLength(500)
                    .HasColumnName("WKF09_Variable");
                entity.Property(e => e.wkf10llave)
                    
                    .HasColumnName("WKF10_Llave");

                entity.HasOne(d => d.Wkf01LlaveNavigation).WithMany(p => p.Wkf09Parametros)
                    .HasForeignKey(d => d.wkf01llave)
                    .HasConstraintName("FK_WKF09_Parametro_WKF01_Flujo");

                entity.HasOne(d => d.Wkf10LlaveNavigation).WithMany(p => p.Wkf09Parametros)
                    .HasForeignKey(d => d.wkf10llave)
                    .HasConstraintName("FK_WKF09_Parametro_WKF10_TipoParametro");
            });

            modelBuilder.Entity<Wkf10TipoParametro>(entity =>
            {
                entity.HasKey(e => e.wkf10llave);

                entity.ToTable("WKF10_TipoParametro");

                entity.Property(e => e.wkf10llave)
                    .ValueGeneratedOnAdd()
                    
                    .HasColumnName("WKF10_Llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactivacion");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaeliminacion");
                entity.Property(e => e.wkf10activo).HasColumnName("WKF10_Activo");
                entity.Property(e => e.wkf10descripcion).HasColumnName("WKF10_Descripcion");
                entity.Property(e => e.wkf10nombre)
                    .HasMaxLength(500)
                    .HasColumnName("WKF10_Nombre");
            });

            

                        
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Inmueble>? Inmuebles { get; set; }

        public DbSet<Region>? Regiones{ get; set; }   
        
        public DbSet<Comuna>? Comunas{ get; set; }

        public DbSet<Zona>? Zonas { get; set; }

        public virtual DbSet<Blk01Bloqueo>? Blk01Bloqueos { get; set; }

        public virtual DbSet<Blk02TipoBloqueo>? Blk02TipoBloqueos { get; set; }

        public virtual DbSet<Blk03BloqueoUsuario>? Blk03BloqueoUsuarios { get; set; }

        public virtual DbSet<Clbr01Calibracion>? Clbr01Calibraciones { get; set; }

        public virtual DbSet<Clbr02TipoCalibracion>? Clbr02TipoCalibraciones { get; set; }

        public virtual DbSet<Cnt01CuentaCliente>? Cnt01CuentaClientes { get; set; }

        public virtual DbSet<Cnt02TipoCuenta>? Cnt02TipoCuentas { get; set; }

        public virtual DbSet<Cnt03TipoCliente>? Cnt03TipoClientes { get; set; }

        public virtual DbSet<Cnt04ContactoCliente>? Cnt04ContactoClientes { get; set; }

        public virtual DbSet<Cnt05TipoContacto>? Cnt05TipoContactos { get; set; }

        public virtual DbSet<Cnt06ComunicacionCliente>? Cnt06ComunicacionClientes { get; set; }

        public virtual DbSet<Cnt07TipoSegmentacion>? Cnt07TipoSegmentaciones { get; set; }

        public virtual DbSet<Cnt08Segmentacion>? Cnt08Segmentaciones { get; set; }

        public virtual DbSet<Cnt09ComunicacionSegmentacion>? Cnt09ComunicacionSegmentaciones { get; set; }

        public virtual DbSet<Cnt10TipoComunicacion>? Cnt10TipoComunicaciones { get; set; }

        public virtual DbSet<Cnt11ContactoSegmentacion>? Cnt11ContactoSegmentaciones { get; set; }

        public virtual DbSet<Cnt12Empleado>? Cnt12Empleados { get; set; }

        public virtual DbSet<Cnt13TipoEmpleado>? Cnt13TipoEmpleados { get; set; }

        public virtual DbSet<Cnt14ClienteLicencia>? Cnt14ClienteLicencias { get; set; }

        public virtual DbSet<Cnt15EmpleadoLicencia>? Cnt15EmpleadoLicencias { get; set; }

        public virtual DbSet<Cnt16TipoBloqueoCliente>? Cnt16TipoBloqueoClientes { get; set; }

        public virtual DbSet<Cnt17Bloqueo>? Cnt17Bloqueos { get; set; }

        public virtual DbSet<Cnt18NivelSegmentacion>? Cnt18NivelSegmentaciones { get; set; }

        public virtual DbSet<Cnt19LicenciaCliente>? Cnt19LicenciaClientes { get; set; }

        public virtual DbSet<Cnt20LicenciaServicio>? Cnt20LicenciaServicios { get; set; }

        public virtual DbSet<Cnt21TipoEstacion>? Cnt21TipoEstaciones { get; set; }

        public virtual DbSet<Cnt22EstacionTipoEstacion>? Cnt22EstacionTipoEstaciones { get; set; }

        public virtual DbSet<Cnt23Tipocobro>? Cnt23Tipocobros { get; set; }

        public virtual DbSet<Cnt24AsociarCuenta>? Cnt24AsociarCuentas { get; set; }

        public virtual DbSet<Cont01Contacto>? Cont01Contactos { get; set; }

        public virtual DbSet<Cont02TipoContacto>? Cont02TipoContactos { get; set; }

        public virtual DbSet<Conteo01Conteo>? Conteo01Conteos { get; set; }

        public virtual DbSet<Conteo02Procesado>? Conteo02Procesados { get; set; }

        public virtual DbSet<Conteo03Resumen>? Conteo03Resumenes { get; set; }

        public virtual DbSet<Conteo04ResumenSag>? Conteo04ResumenSags { get; set; }

        public virtual DbSet<Conteo05ControlReserva>? Conteo05ControlReservas { get; set; }

        public virtual DbSet<Ctt01Contrato>? Ctt01Contratos { get; set; }

        public virtual DbSet<Ctt02TipoContrato>? Ctt02TipoContratos { get; set; }

        public virtual DbSet<Ctzr01Cotizacion>? Ctzr01Cotizaciones { get; set; }

        public virtual DbSet<Eml01BitacoraEmailUsuario>? Eml01BitacoraEmailUsuarios { get; set; }

        public virtual DbSet<Eml02MailBase>? Eml02MailBases { get; set; }

        public virtual DbSet<Eml03TipoMailAccion>? Eml03TipoMailAcciones { get; set; }

        public virtual DbSet<Eml04ImportanciaMail>? Eml04ImportanciaMails { get; set; }

        public virtual DbSet<Eml05ArchivoMail>? Eml05ArchivoMails { get; set; }

        public virtual DbSet<Eml06TipoArchivo>? Eml06TipoArchivos { get; set; }

        public virtual DbSet<Esp01Especie>? Esp01Especies { get; set; }

        public virtual DbSet<Esp02TemporadaEspecie>? Esp02TemporadaEspecies { get; set; }

        public virtual DbSet<Esp03EspecieBase>? Esp03EspecieBases { get; set; }

        public virtual DbSet<Esp04EstadoDanio>? Esp04EstadoDanios { get; set; }

        public virtual DbSet<Esp05Umbral>? Esp05Umbrales { get; set; }

        public virtual DbSet<Esp06MedidaUmbral>? Esp06MedidaUmbrales { get; set; }

        public virtual DbSet<Esp07Union>? Esp07Uniones { get; set; }

        public virtual DbSet<Esp08TipoBase>? Esp08TipoBases { get; set; }

        public virtual DbSet<Esp09TipoBaseUmbral>? Esp09TipoBaseUmbrales { get; set; }

        public virtual DbSet<Esp10TipoRegla>? Esp10TipoReglas { get; set; }

        public virtual DbSet<Esp11ReglaGrafico>? Esp11ReglaGraficos { get; set; }

        public virtual DbSet<Frm01TipoFormulario>? Frm01TipoFormularios { get; set; }

        public virtual DbSet<Frm02Formulario>? Frm02Formularios { get; set; }

        public virtual DbSet<Grfc01GraficoGenerado>? Grfc01GraficoGenerados { get; set; }

        public virtual DbSet<Grfc02TipoGrafico>? Grfc02TipoGraficos { get; set; }

        public virtual DbSet<Grfc03RespaldoGrafico>? Grfc03RespaldoGraficos { get; set; }

        public virtual DbSet<Ins01Inscripcion>? Ins01Inscripciones { get; set; }

        public virtual DbSet<Ins02RecuperarClave>? Ins02RecuperarClaves { get; set; }

        public virtual DbSet<Lnc01Licencia>? Lnc01Licencias { get; set; }

        public virtual DbSet<Lnc02ServiciosLicencia>? Lnc02ServiciosLicencias { get; set; }

        public virtual DbSet<Lnc03LicenciaContrato>? Lnc03LicenciaContratos { get; set; }

        public virtual DbSet<Lnc04TipoLicencia>? Lnc04TipoLicencias { get; set; }

        public virtual DbSet<Lnc05ValorLicencia>? Lnc05ValorLicencias { get; set; }

        public virtual DbSet<Lnc06Cobertura>? Lnc06Coberturas { get; set; }

        public virtual DbSet<Lnc07Control>? Lnc07Controles { get; set; }

        public virtual DbSet<Log01Bitacora>? Log01Bitacoras { get; set; }

        public virtual DbSet<Log02TipoBitacora>? Log02TipoBitacoras { get; set; }

        public virtual DbSet<Log03MensajeBitacora>? Log03MensajeBitacoras { get; set; }

        public virtual DbSet<Men01Sistema>? Men01Sistemas { get; set; }

        public virtual DbSet<Mnt01Monitor>? Mnt01Monitores { get; set; }

        public virtual DbSet<Mnt03PeriodosTrampa>? Mnt03PeriodosTrampas { get; set; }

        public virtual DbSet<Mnt04TipoMonitor>? Mnt04TipoMonitores { get; set; }

        public virtual DbSet<Mvl01AccesoMovil>? Mvl01AccesoMoviles { get; set; }

        public virtual DbSet<Mvl02TablaSincronizacion>? Mvl02TablaSincronizaciones { get; set; }

        public virtual DbSet<Mvl03RegistroAcceso>? Mvl03RegistroAccesos { get; set; }

        public virtual DbSet<Obsc01ObservacionCampo>? Obsc01ObservacionCampos { get; set; }

        public virtual DbSet<Obsc02ServicioPostcosecha>? Obsc02ServicioPostcosechas { get; set; }

        public virtual DbSet<Pbcd01Publicidad>? Pbcd01Publicidades { get; set; }

        public virtual DbSet<Pbcd02TipoPublicidad>? Pbcd02TipoPublicidades { get; set; }

        public virtual DbSet<Pbcd03Programacion>? Pbcd03Programaciones { get; set; }

        public virtual DbSet<Per01Persona>? Per01Personas { get; set; }

        public virtual DbSet<Per02Genero>? Per02Generos { get; set; }

        public virtual DbSet<Per03TipoPersona>? Per03TipoPersonas { get; set; }

        public virtual DbSet<Per04TipoComunicacion>? Per04TipoComunicaciones { get; set; }

        public virtual DbSet<Per05Comunicacion>? Per05Comunicaciones { get; set; }

        public virtual DbSet<Per06TipoPersonaComunicacion>? Per06TipoPersonaComunicaciones { get; set; }

        public virtual DbSet<Per07PersonaUsuario>? Per07PersonaUsuarios { get; set; }

        public virtual DbSet<Pgo01CompraLicencia>? Pgo01CompraLicencias { get; set; }

        public virtual DbSet<Pgo02NotificarPagoLicencia>? Pgo02NotificarPagoLicencias { get; set; }

        public virtual DbSet<Pgo03TipoPagoLicencia>? Pgo03TipoPagoLicencias { get; set; }

        public virtual DbSet<Prf01Perfil>? Prf01Perfiles { get; set; }

        public virtual DbSet<Prf03Plantilla>? Prf03Plantillas { get; set; }

        public virtual DbSet<Prf04PlantillaPerfil>? Prf04PlantillaPerfiles { get; set; }

        public virtual DbSet<Prf05TipoAsignacionUsuario>? Prf05TipoAsignacionUsuarios { get; set; }

        public virtual DbSet<Prf06PermisosUsuario>? Prf06PermisosUsuarios { get; set; }

        public virtual DbSet<Prm01Seguridad>? Prm01Seguridades { get; set; }

        public virtual DbSet<Secu01Rol>? Secu01Rols { get; set; }

        public virtual DbSet<Secu02Usuario>? Secu02Usuarios { get; set; }

        public virtual DbSet<Secu03TipoAcceso>? Secu03TipoAccesos { get; set; }

        public virtual DbSet<Secu04TipoEncriptacion>? Secu04TipoEncriptaciones { get; set; }

        public virtual DbSet<Secu05UsuarioAcceso>? Secu05UsuarioAccesos { get; set; }

        public virtual DbSet<Secu06UsuarioRol>? Secu06UsuarioRoles { get; set; }

        public virtual DbSet<Secu07Aplicacion>? Secu07Aplicaciones { get; set; }

        public virtual DbSet<Secu08UsuarioAplicacion>? Secu08UsuarioAplicaciones { get; set; }

        public virtual DbSet<Secu10AccesoPermitido>? Secu10AccesoPermitidos { get; set; }

        public virtual DbSet<Secu11TipoPerfil>? Secu11TipoPerfiles { get; set; }

        public virtual DbSet<Sercl01ServiciosCliente>? Sercl01ServiciosClientes { get; set; }

        public virtual DbSet<Sercl02MuestreoFruta>? Sercl02MuestreoFrutas { get; set; }

        public virtual DbSet<Serv01Servicio>? Serv01Servicios { get; set; }

        public virtual DbSet<Serv02TipoServicio>? Serv02TipoServicios { get; set; }

        public virtual DbSet<Sist01Sistema>? Sist01Sistemas { get; set; }

        public virtual DbSet<Sist02Zona>? Sist02Zonas { get; set; }

        public virtual DbSet<Sist03Comuna>? Sist03Comunas { get; set; }

        public virtual DbSet<Sist04Region>? Sist04Regiones { get; set; }

        public virtual DbSet<Sist05EstadoRegistro>? Sist05EstadoRegistros { get; set; }

        public virtual DbSet<Sist06EstadoGrid>? Sist06EstadoGrids { get; set; }

        public virtual DbSet<Sist08ContactoUsuario>? Sist08ContactoUsuarios { get; set; }

        public virtual DbSet<Temp01Temporada>? Temp01Temporadas { get; set; }

        public virtual DbSet<Temp02TemporadaBase>? Temp02TemporadaBases { get; set; }

        public virtual DbSet<Temp03Segmentacion>? Temp03Segmentaciones { get; set; }

        public virtual DbSet<Trp01Trampa>? Trp01Trampas { get; set; }

        public virtual DbSet<Trp02Temporada>? Trp02Temporadas { get; set; }

        public virtual DbSet<Trp03Geocordenada>? Trp03Geocordenadas { get; set; }

        public virtual DbSet<Wkf01Flujo>? Wkf01Flujos { get; set; }

        public virtual DbSet<Wkf02TipoFlujo>? Wkf02TipoFlujos { get; set; }

        public virtual DbSet<Wkf03Nivel>? Wkf03Niveles { get; set; }

        public virtual DbSet<Wkf04NivelPermiso>? Wkf04NivelPermisos { get; set; }

        public virtual DbSet<Wkf05TipoPermiso>? Wkf05TipoPermisos { get; set; }

        public virtual DbSet<Wkf06Perfil>? Wkf06Perfiles { get; set; }

        public virtual DbSet<Wkf07PerfilesPermiso>? Wkf07PerfilesPermisos { get; set; }

        public virtual DbSet<Wkf08Area>? Wkf08Areas { get; set; }

        public virtual DbSet<Wkf09Parametro>? Wkf09Parametros { get; set; }

        public virtual DbSet<Wkf10TipoParametro>? Wkf10TipoParametros { get; set; }

        public DbSet<setSelect>? SetSelects { get; set; }

    }
}
    