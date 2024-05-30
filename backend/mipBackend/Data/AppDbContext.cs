using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mipBackend.Models;
using mipBackend.Dtos.UsuarioDtos;
using mipBackend.Dtos.MonitorDtos;
using mipBackend.Dtos.MovilDtos;
using mipBackend.Dtos.ClienteEstacionDtos;

namespace mipBackend.Data
{
    public class AppDbContext: IdentityDbContext<Usuario, Rol, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UsuarioRegistroResponseDto>(entity =>
            { 
                entity.HasNoKey();
                /*
                entity.ToTable("userid");
                entity.ToTable("username");
                entity.ToTable("roleid");
                entity.ToTable("rolename");
                entity.ToTable("per01llave");
                entity.ToTable("per01nombre");
                entity.ToTable("prf03llave");
                entity.ToTable("prf03nombre");
                */
            });

            /*
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);
                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);
                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");
                            j.ToTable("AspNetUserRoles");
                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
            });
            */

            modelBuilder.Entity<Blk01Bloqueo>(entity =>
            {
                entity.HasKey(e => e.Blk01llave);

                entity.ToTable("BLK01_Bloqueos");

                entity.HasIndex(e => e.Blk02llave, "IX_BLK01_Bloqueos_BLK02_llave");

                entity.Property(e => e.Blk01llave).HasColumnName("BLK01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Blk01activo).HasColumnName("BLK01_activo");
                entity.Property(e => e.Blk01descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("BLK01_descripcion");
                entity.Property(e => e.Blk01MaxDuraciondia).HasColumnName("BLK01_MaxDuraciondia");
                entity.Property(e => e.Blk01MinDuraciondia).HasColumnName("BLK01_MinDuraciondia");
                entity.Property(e => e.Blk01nombreBloqueo)
                    .HasMaxLength(500)
                    .HasColumnName("BLK01_nombreBloqueo");
                entity.Property(e => e.Blk01permanente).HasColumnName("BLK01_permanente");
                entity.Property(e => e.Blk02llave).HasColumnName("BLK02_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");

                entity.HasOne(d => d.Blk02llaveNavigation).WithMany(p => p.Blk01Bloqueos)
                    .HasForeignKey(d => d.Blk02llave)
                    .HasConstraintName("FK_BLK01_Bloqueos_BLK02_TipoBloqueo");
            });

            modelBuilder.Entity<Blk02TipoBloqueo>(entity =>
            {
                entity.HasKey(e => e.Blk02llave);

                entity.ToTable("BLK02_TipoBloqueo");

                entity.Property(e => e.Blk02llave).HasColumnName("BLK02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Blk02activo).HasColumnName("BLK02_activo");
                entity.Property(e => e.Blk02descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("BLK02_descripcion");
                entity.Property(e => e.Blk02nombre)
                    .HasMaxLength(250)
                    .HasColumnName("BLK02_nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<Blk03BloqueoUsuario>(entity =>
            {
                entity.HasKey(e => e.Blk03llave);

                entity.ToTable("BLK03_BloqueoUsuario");

                entity.HasIndex(e => e.Blk01llave, "IX_BLK03_BloqueoUsuario_BLK01_llave");

                entity.Property(e => e.Blk03llave).HasColumnName("BLK03_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Blk01llave).HasColumnName("BLK01_llave");
                entity.Property(e => e.Blk03activo).HasColumnName("BLK03_activo");
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
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.userid).HasColumnName("SECU02_llave");

                entity.HasOne(d => d.Blk01llaveNavigation).WithMany(p => p.Blk03BloqueoUsuarios)
                    .HasForeignKey(d => d.Blk01llave)
                    .HasConstraintName("FK_BLK03_BloqueoUsuario_BLK01_Bloqueos");
            });

            modelBuilder.Entity<Clbr01Calibracion>(entity =>
            {
                entity.HasKey(e => e.Clbr01llave);

                entity.ToTable("CLBR01_Calibracion");

                entity.HasIndex(e => e.Clbr02llave, "IX_CLBR01_Calibracion_CLBR02_llave");

                entity.Property(e => e.Clbr01llave).HasColumnName("CLBR01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Clbr01activo).HasColumnName("CLBR01_activo");
                entity.Property(e => e.Clbr01descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("CLBR01_descripcion");
                entity.Property(e => e.Clbr01FechaCalibracion)
                    .HasColumnType("datetime")
                    .HasColumnName("CLBR01_FechaCalibracion");
                entity.Property(e => e.Clbr01nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CLBR01_nombre");
                entity.Property(e => e.Clbr01UrlPdf)
                    .HasMaxLength(1000)
                    .HasColumnName("CLBR01_UrlPdf");
                entity.Property(e => e.Clbr02llave).HasColumnName("CLBR02_llave");
                entity.Property(e => e.cnt01llave).HasColumnName("CNT01_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Sercl01llave).HasColumnName("SERCL01_llave");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");

                entity.HasOne(d => d.Clbr02llaveNavigation).WithMany(p => p.Clbr01Calibracions)
                    .HasForeignKey(d => d.Clbr02llave)
                    .HasConstraintName("FK_CLBR01_Calibracion_CLBR02_TipoCalibracion");
            });

            modelBuilder.Entity<Clbr02TipoCalibracion>(entity =>
            {
                entity.HasKey(e => e.Clbr02llave);

                entity.ToTable("CLBR02_TipoCalibracion");

                entity.Property(e => e.Clbr02llave).HasColumnName("CLBR02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.Clbr02activo).HasColumnName("CLBR02_activo");
                entity.Property(e => e.Clbr02descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("CLBR02_descripcion");
                entity.Property(e => e.Clbr02nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CLBR02_nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<cnt01CuentaCliente>(entity =>
            {
                entity.HasKey(e => e.cnt01llave);

                entity.ToTable("CNT01_CuentaCliente");

                entity.HasIndex(e => e.cnt02llave, "IX_CNT01_CuentaCliente_CNT02_llave");

                entity.HasIndex(e => e.cnt03llave, "IX_CNT01_CuentaCliente_CNT03_llave");

                entity.HasIndex(e => e.per01llave, "IX_CNT01_CuentaCliente_PER01_llave");

                entity.Property(e => e.cnt01llave).HasColumnName("CNT01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt01activo).HasColumnName("CNT01_activo");
                entity.Property(e => e.cnt01AnioIngreso)
                    .HasColumnType("date")
                    .HasColumnName("CNT01_anioIngreso");
                entity.Property(e => e.cnt01CuentaSap).HasColumnName("CNT01_CuentaSap");
                entity.Property(e => e.cnt01FechaIngresoSap)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT01_FechaIngresoSap");
                entity.Property(e => e.cnt01nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CNT01_nombre");
                entity.Property(e => e.cnt01NumeroSap).HasColumnName("CNT01_NumeroSap");
                entity.Property(e => e.cnt02llave).HasColumnName("CNT02_llave");
                entity.Property(e => e.cnt03llave).HasColumnName("CNT03_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per01llave).HasColumnName("PER01_llave");

                entity.HasOne(d => d.cnt02llaveNavigation).WithMany(p => p.cnt01CuentaClientes)
                    .HasForeignKey(d => d.cnt02llave)
                    .HasConstraintName("FK_CNT01_CuentaCliente_CNT02_TipoCuenta");

                entity.HasOne(d => d.cnt03llaveNavigation).WithMany(p => p.cnt01CuentaClientes)
                    .HasForeignKey(d => d.cnt03llave)
                    .HasConstraintName("FK_CNT01_CuentaCliente_CNT03_TipoCliente");

                entity.HasOne(d => d.per01llaveNavigation).WithMany(p => p.cnt01CuentaClientes)
                    .HasForeignKey(d => d.per01llave)
                    .HasConstraintName("FK_CNT01_CuentaCliente_PER01_persona");
            });

            modelBuilder.Entity<cnt02TipoCuenta>(entity =>
            {
                entity.HasKey(e => e.cnt02llave);

                entity.ToTable("CNT02_TipoCuenta");

                entity.Property(e => e.cnt02llave).HasColumnName("CNT02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt02activo).HasColumnName("CNT02_activo");
                entity.Property(e => e.cnt02descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("CNT02_descripcion");
                entity.Property(e => e.cnt02nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CNT02_nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<cnt03TipoCliente>(entity =>
            {
                entity.HasKey(e => e.cnt03llave);

                entity.ToTable("CNT03_TipoCliente");

                entity.HasIndex(e => e.per03llave, "IX_CNT03_TipoCliente_PER03_llave");

                entity.Property(e => e.cnt03llave).HasColumnName("CNT03_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt03activo).HasColumnName("CNT03_activo");
                entity.Property(e => e.cnt03descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT03_descripcion");
                entity.Property(e => e.cnt03nombre)
                    .HasMaxLength(50)
                    .HasColumnName("CNT03_nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per03llave).HasColumnName("PER03_llave");

                entity.HasOne(d => d.per03llaveNavigation).WithMany(p => p.cnt03TipoClientes)
                    .HasForeignKey(d => d.per03llave)
                    .HasConstraintName("FK_CNT03_TipoCliente_PER03_Tipopersona");
            });

            modelBuilder.Entity<cnt04ContactoCliente>(entity =>
            {
                entity.HasKey(e => e.cnt04llave);

                entity.ToTable("CNT04_ContactoCliente");

                entity.HasIndex(e => e.cnt01llave, "IX_CNT04_ContactoCliente_CNT01_llave");

                entity.HasIndex(e => e.cnt05llave, "IX_CNT04_ContactoCliente_CNT05_llave");

                entity.Property(e => e.cnt04llave).HasColumnName("CNT04_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt01llave).HasColumnName("CNT01_llave");
                entity.Property(e => e.cnt04activo).HasColumnName("CNT04_activo");
                entity.Property(e => e.cnt05llave).HasColumnName("CNT05_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per01llave).HasColumnName("PER01_llave");

                entity.HasOne(d => d.cnt01llaveNavigation).WithMany(p => p.cnt04ContactoClientes)
                    .HasForeignKey(d => d.cnt01llave)
                    .HasConstraintName("FK_CNT04_ContactoCliente_CNT01_CuentaCliente1");

                entity.HasOne(d => d.cnt05llaveNavigation).WithMany(p => p.cnt04ContactoClientes)
                    .HasForeignKey(d => d.cnt05llave)
                    .HasConstraintName("FK_CNT04_ContactoCliente_CNT05_TipoContacto");
            });

            modelBuilder.Entity<cnt05TipoContacto>(entity =>
            {
                entity.HasKey(e => e.cnt05llave);

                entity.ToTable("CNT05_TipoContacto");

                entity.Property(e => e.cnt05llave).HasColumnName("CNT05_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt05activo).HasColumnName("CNT05_activo");
                entity.Property(e => e.cnt05descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT05_descripcion");
                entity.Property(e => e.cnt05nombre)
                    .HasMaxLength(50)
                    .HasColumnName("CNT05_nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<cnt06ComunicacionCliente>(entity =>
            {
                entity.HasKey(e => e.cnt06llave);

                entity.ToTable("CNT06_ComunicacionCliente");

                entity.HasIndex(e => e.cnt01llave, "IX_CNT06_ComunicacionCliente_CNT01_llave");

                entity.HasIndex(e => e.cnt08llave, "IX_CNT06_ComunicacionCliente_CNT08_llave");

                entity.HasIndex(e => e.cnt10llave, "IX_CNT06_ComunicacionCliente_CNT10_llave");

                entity.HasIndex(e => e.sist03llave, "IX_CNT06_ComunicacionCliente_SIST03_llave");

                entity.Property(e => e.cnt06llave).HasColumnName("CNT06_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt01llave).HasColumnName("CNT01_llave");
                entity.Property(e => e.cnt06activo).HasColumnName("CNT06_activo");
                entity.Property(e => e.cnt06casilla)
                    .HasMaxLength(500)
                    .HasColumnName("CNT06_casilla");
                entity.Property(e => e.cnt06celular1)
                    .HasMaxLength(50)
                    .HasColumnName("CNT06_Celular1");
                entity.Property(e => e.cnt06celular2)
                    .HasMaxLength(50)
                    .HasColumnName("CNT06_Celular2");
                entity.Property(e => e.cnt06codigopostal)
                    .HasMaxLength(500)
                    .HasColumnName("CNT06_CodigoPostal");
                entity.Property(e => e.cnt06direccion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT06_Direccion");
                entity.Property(e => e.cnt06email)
                    .HasMaxLength(250)
                    .HasColumnName("CNT06_Email");
                entity.Property(e => e.cnt06fax)
                    .HasMaxLength(50)
                    .HasColumnName("CNT06_Fax");
                entity.Property(e => e.cnt06sitioweb)
                    .HasMaxLength(50)
                    .HasColumnName("CNT06_SitioWeb");
                entity.Property(e => e.cnt06telefono1)
                    .HasMaxLength(50)
                    .HasColumnName("CNT06_Telefono1");
                entity.Property(e => e.cnt06telefono2)
                    .HasMaxLength(50)
                    .HasColumnName("CNT06_Telefono2");
                entity.Property(e => e.cnt06tienecasilla).HasColumnName("CNT06_TieneCasilla");
                entity.Property(e => e.cnt06tipomail).HasColumnName("CNT06_TipoMail");
                entity.Property(e => e.cnt08llave).HasColumnName("CNT08_llave");
                entity.Property(e => e.cnt10llave).HasColumnName("CNT10_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.sist03llave).HasColumnName("SIST03_llave");

                entity.HasOne(d => d.cnt01llaveNavigation).WithMany(p => p.cnt06ComunicacionClientes)
                    .HasForeignKey(d => d.cnt01llave)
                    .HasConstraintName("FK_CNT06_ComunicacionCliente_CNT01_CuentaCliente");

                entity.HasOne(d => d.cnt08llaveNavigation).WithMany(p => p.cnt06ComunicacionClientes)
                    .HasForeignKey(d => d.cnt08llave)
                    .HasConstraintName("FK_CNT06_ComunicacionCliente_CNT08_Segmentacion");

                entity.HasOne(d => d.cnt10llaveNavigation).WithMany(p => p.cnt06ComunicacionClientes)
                    .HasForeignKey(d => d.cnt10llave)
                    .HasConstraintName("FK_CNT06_ComunicacionCliente_CNT10_TipoComunicacion");

                entity.HasOne(d => d.sist03llaveNavigation).WithMany(p => p.cnt06ComunicacionClientes)
                    .HasForeignKey(d => d.sist03llave)
                    .HasConstraintName("FK_CNT06_ComunicacionCliente_SIST03_Comuna");
            });

            modelBuilder.Entity<cnt07TipoSegmentacion>(entity =>
            {
                entity.HasKey(e => e.cnt07llave);

                entity.ToTable("CNT07_TipoSegmentacion");

                entity.HasIndex(e => e.cnt18llave, "IX_CNT07_TipoSegmentacion_CNT18_llave");

                entity.Property(e => e.cnt07llave).HasColumnName("CNT07_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt02llave).HasColumnName("CNT02_llave");
                entity.Property(e => e.cnt07activo).HasColumnName("CNT07_activo");
                entity.Property(e => e.cnt07descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT07_descripcion");
                entity.Property(e => e.cnt07nombre)
                    .HasMaxLength(50)
                    .HasColumnName("CNT07_nombre");
                entity.Property(e => e.cnt18llave).HasColumnName("CNT18_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");

                entity.HasOne(d => d.cnt18llaveNavigation).WithMany(p => p.cnt07TipoSegmentacions)
                    .HasForeignKey(d => d.cnt18llave)
                    .HasConstraintName("FK_CNT07_TipoSegmentacion_CNT18_NivelSegmentacion");
            });

            modelBuilder.Entity<cnt08Segmentacion>(entity =>
            {
                entity.HasKey(e => e.cnt08llave);

                entity.ToTable("CNT08_Segmentacion");

                entity.HasIndex(e => e.cnt01llave, "IX_CNT08_Segmentacion_CNT01_llave");

                entity.HasIndex(e => e.cnt07llave, "IX_CNT08_Segmentacion_CNT07_llave");

                entity.HasIndex(e => e.cnt08llavePadre, "IX_CNT08_Segmentacion_CNT08_llavePadre");

                entity.Property(e => e.cnt08llave).HasColumnName("CNT08_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt01llave).HasColumnName("CNT01_llave");
                entity.Property(e => e.cnt07llave).HasColumnName("CNT07_llave");
                entity.Property(e => e.cnt08activo).HasColumnName("CNT08_activo");
                entity.Property(e => e.cnt08llavePadre).HasColumnName("CNT08_llavePadre");
                entity.Property(e => e.cnt08nombre)
                    .HasMaxLength(500)
                    .HasColumnName("CNT08_nombre");
                entity.Property(e => e.cnt21llave)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("CNT21_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.sist03llave).HasColumnName("SIST03_llave");

                entity.HasOne(d => d.cnt01llaveNavigation).WithMany(p => p.cnt08Segmentacions)
                    .HasForeignKey(d => d.cnt01llave)
                    .HasConstraintName("FK_CNT08_Segmentacion_CNT01_CuentaCliente");

                entity.HasOne(d => d.cnt07llaveNavigation).WithMany(p => p.cnt08Segmentacions)
                    .HasForeignKey(d => d.cnt07llave)
                    .HasConstraintName("FK_CNT08_Segmentacion_CNT07_TipoSegmentacion");

                entity.HasOne(d => d.cnt08llavePadreNavigation).WithMany(p => p.Inversecnt08llavePadreNavigation)
                    .HasForeignKey(d => d.cnt08llavePadre)
                    .HasConstraintName("FK_CNT08_Segmentacion_CNT08_Segmentacion");
            });

            modelBuilder.Entity<cnt09ComunicacionSegmentacion>(entity =>
            {
                entity.HasKey(e => e.cnt09llave);

                entity.ToTable("CNT09_ComunicacionSegmentacion");

                entity.HasIndex(e => e.cnt08llave, "IX_CNT09_ComunicacionSegmentacion_CNT08_llave");

                entity.Property(e => e.cnt09llave).HasColumnName("CNT09_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt08llave).HasColumnName("CNT08_llave");
                entity.Property(e => e.cnt09activo).HasColumnName("CNT09_activo");
                entity.Property(e => e.cnt09Casilla)
                    .HasMaxLength(500)
                    .HasColumnName("CNT09_casilla");
                entity.Property(e => e.cnt09Celular1)
                    .HasMaxLength(50)
                    .HasColumnName("CNT09_Celular1");
                entity.Property(e => e.cnt09Celular2)
                    .HasMaxLength(50)
                    .HasColumnName("CNT09_Celular2");
                entity.Property(e => e.cnt09CodigoPostal)
                    .HasMaxLength(500)
                    .HasColumnName("CNT09_CodigoPostal");
                entity.Property(e => e.cnt09Direccion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT09_Direccion");
                entity.Property(e => e.cnt09Email)
                    .HasMaxLength(250)
                    .HasColumnName("CNT09_Email");
                entity.Property(e => e.cnt09Fax)
                    .HasMaxLength(50)
                    .HasColumnName("CNT09_Fax");
                entity.Property(e => e.cnt09SinCasilla).HasColumnName("CNT09_SinCasilla");
                entity.Property(e => e.cnt09SitioWeb)
                    .HasMaxLength(50)
                    .HasColumnName("CNT09_SitioWeb");
                entity.Property(e => e.cnt09Telefono1)
                    .HasMaxLength(50)
                    .HasColumnName("CNT09_Telefono1");
                entity.Property(e => e.cnt09Telefono2)
                    .HasMaxLength(50)
                    .HasColumnName("CNT09_Telefono2");
                entity.Property(e => e.cnt09TipoMail).HasColumnName("CNT09_TipoMail");
                entity.Property(e => e.cnt10llave).HasColumnName("CNT10_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.sist03llave).HasColumnName("SIST03_llave");

                entity.HasOne(d => d.cnt08llaveNavigation).WithMany(p => p.cnt09ComunicacionSegmentacions)
                    .HasForeignKey(d => d.cnt08llave)
                    .HasConstraintName("FK_CNT09_ComunicacionSegmentacion_CNT08_Segmentacion");
            });

            modelBuilder.Entity<cnt10TipoComunicacion>(entity =>
            {
                entity.HasKey(e => e.cnt10llave);

                entity.ToTable("CNT10_TipoComunicacion");

                entity.Property(e => e.cnt10llave).HasColumnName("CNT10_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt10activo).HasColumnName("CNT10_activo");
                entity.Property(e => e.cnt10descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT10_descripcion");
                entity.Property(e => e.cnt10nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CNT10_nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<cnt11ContactoSegmentacion>(entity =>
            {
                entity.HasKey(e => e.cnt11llave);

                entity.ToTable("CNT11_ContactoSegmentacion");

                entity.HasIndex(e => e.cnt08llave, "IX_CNT11_ContactoSegmentacion_CNT08_llave");

                entity.Property(e => e.cnt11llave).HasColumnName("CNT11_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt05llave).HasColumnName("CNT05_llave");
                entity.Property(e => e.cnt08llave).HasColumnName("CNT08_llave");
                entity.Property(e => e.cnt11activo).HasColumnName("CNT11_activo");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per01llave).HasColumnName("PER01_llave");

                entity.HasOne(d => d.cnt08llaveNavigation).WithMany(p => p.cnt11ContactoSegmentacions)
                    .HasForeignKey(d => d.cnt08llave)
                    .HasConstraintName("FK_CNT11_ContactoSegmentacion_CNT08_Segmentacion");
            });

            modelBuilder.Entity<cnt12Empleado>(entity =>
            {
                entity.HasKey(e => e.cnt12llave);

                entity.ToTable("CNT12_Empleados");

                entity.HasIndex(e => e.cnt01llave, "IX_CNT12_Empleados_CNT01_llave");

                entity.HasIndex(e => e.cnt13llave, "IX_CNT12_Empleados_CNT13_llave");

                entity.HasIndex(e => e.per01llave, "IX_CNT12_Empleados_PER01_llave");

                entity.Property(e => e.cnt12llave).HasColumnName("CNT12_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt01llave).HasColumnName("CNT01_llave");
                entity.Property(e => e.cnt08llave).HasColumnName("CNT08_llave");
                entity.Property(e => e.cnt12activo).HasColumnName("CNT12_activo");
                entity.Property(e => e.cnt12Cargo)
                    .HasMaxLength(500)
                    .HasColumnName("CNT12_Cargo");
                entity.Property(e => e.cnt13llave).HasColumnName("CNT13_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per01llave).HasColumnName("PER01_llave");

                entity.HasOne(d => d.cnt01llaveNavigation).WithMany(p => p.cnt12Empleados)
                    .HasForeignKey(d => d.cnt01llave)
                    .HasConstraintName("FK_CNT12_Empleados_CNT01_CuentaCliente");

                entity.HasOne(d => d.cnt13llaveNavigation).WithMany(p => p.cnt12Empleados)
                    .HasForeignKey(d => d.cnt13llave)
                    .HasConstraintName("FK_CNT12_Empleados_CNT13_TipoEmpleado");

                entity.HasOne(d => d.per01llaveNavigation).WithMany(p => p.cnt12Empleados)
                    .HasForeignKey(d => d.per01llave)
                    .HasConstraintName("FK_CNT12_Empleados_PER01_persona");
            });

            modelBuilder.Entity<cnt13TipoEmpleado>(entity =>
            {
                entity.HasKey(e => e.cnt13llave);

                entity.ToTable("CNT13_TipoEmpleado");

                entity.Property(e => e.cnt13llave).HasColumnName("CNT13_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt13activo).HasColumnName("CNT13_activo");
                entity.Property(e => e.cnt13descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT13_descripcion");
                entity.Property(e => e.cnt13nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CNT13_nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<cnt14ClienteLicencia>(entity =>
            {
                entity.HasKey(e => e.cnt14llave);

                entity.ToTable("CNT14_ClienteLicencia");

                entity.HasIndex(e => e.cnt01llave, "IX_CNT14_ClienteLicencia_CNT01_llave");

                entity.Property(e => e.cnt14llave).HasColumnName("CNT14_llave");
                entity.Property(e => e.cnt01llave).HasColumnName("CNT01_llave");
                entity.Property(e => e.cnt14activo).HasColumnName("CNT14_activo");
                entity.Property(e => e.cnt14CantUsuarios).HasColumnName("CNT14_CantUsuarios");
                entity.Property(e => e.cnt14InicioFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT14_InicioFecha");
                entity.Property(e => e.cnt14TerminoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT14_TerminoFecha");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Lnc01llave).HasColumnName("LNC01_llave");

                entity.HasOne(d => d.cnt01llaveNavigation).WithMany(p => p.cnt14ClienteLicencia)
                    .HasForeignKey(d => d.cnt01llave)
                    .HasConstraintName("FK_CNT14_ClienteLicencia_CNT01_CuentaCliente");
            });

            modelBuilder.Entity<cnt15EmpleadoLicencia>(entity =>
            {
                entity.HasKey(e => new { e.cnt19llave, e.cnt12llave }).HasName("PK_CNT15_EmpleadoLicencia_1");

                entity.ToTable("CNT15_EmpleadoLicencia");

                entity.HasIndex(e => e.cnt12llave, "IX_CNT15_EmpleadoLicencia_CNT12_llave");

                entity.Property(e => e.cnt19llave).HasColumnName("CNT19_llave");
                entity.Property(e => e.cnt12llave).HasColumnName("CNT12_llave");
                entity.Property(e => e.cnt15AceptaContrato).HasColumnName("CNT15_AceptaContrato");
                entity.Property(e => e.cnt15Fechafirma)
                    .HasColumnType("date")
                    .HasColumnName("CNT15_fechafirma");

                entity.HasOne(d => d.cnt12llaveNavigation).WithMany(p => p.cnt15EmpleadoLicencia)
                    .HasForeignKey(d => d.cnt12llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT15_EmpleadoLicencia_CNT12_Empleados");

                entity.HasOne(d => d.cnt19llaveNavigation).WithMany(p => p.cnt15EmpleadoLicencia)
                    .HasForeignKey(d => d.cnt19llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT15_EmpleadoLicencia_CNT19_LicenciaCliente");
            });

            modelBuilder.Entity<cnt16TipoBloqueoCliente>(entity =>
            {
                entity.HasKey(e => e.cnt16llave);

                entity.ToTable("CNT16_TipoBloqueoCliente");

                entity.Property(e => e.cnt16llave).HasColumnName("CNT16_llave");
                entity.Property(e => e.cnt16activo).HasColumnName("CNT16_activo");
                entity.Property(e => e.cnt16descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT16_descripcion");
                entity.Property(e => e.cnt16nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CNT16_nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<cnt17Bloqueo>(entity =>
            {
                entity.HasKey(e => e.cnt17llave);

                entity.ToTable("CNT17_Bloqueos");

                entity.HasIndex(e => e.Blk01llave, "IX_CNT17_Bloqueos_BLK01_llave");

                entity.HasIndex(e => e.cnt01llave, "IX_CNT17_Bloqueos_CNT01_llave");

                entity.HasIndex(e => e.cnt08llave, "IX_CNT17_Bloqueos_CNT08_llave");

                entity.HasIndex(e => e.cnt14llave, "IX_CNT17_Bloqueos_CNT14_llave");

                entity.HasIndex(e => e.cnt16llave, "IX_CNT17_Bloqueos_CNT16_llave");

                entity.Property(e => e.cnt17llave).HasColumnName("CNT17_llave");
                entity.Property(e => e.Blk01llave).HasColumnName("BLK01_llave");
                entity.Property(e => e.cnt01llave).HasColumnName("CNT01_llave");
                entity.Property(e => e.cnt08llave).HasColumnName("CNT08_llave");
                entity.Property(e => e.cnt14llave).HasColumnName("CNT14_llave");
                entity.Property(e => e.cnt16llave).HasColumnName("CNT16_llave");
                entity.Property(e => e.cnt17activo).HasColumnName("CNT17_activo");
                entity.Property(e => e.cnt17InicioBloqueo)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT17_InicioBloqueo");
                entity.Property(e => e.cnt17TerminoBloqueo)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT17_TerminoBloqueo");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per01llave).HasColumnName("PER01_llave");

                entity.HasOne(d => d.Blk01llaveNavigation).WithMany(p => p.cnt17Bloqueos)
                    .HasForeignKey(d => d.Blk01llave)
                    .HasConstraintName("FK_CNT17_Bloqueos_BLK01_Bloqueos");

                entity.HasOne(d => d.cnt01llaveNavigation).WithMany(p => p.cnt17Bloqueos)
                    .HasForeignKey(d => d.cnt01llave)
                    .HasConstraintName("FK_CNT17_Bloqueos_CNT01_CuentaCliente");

                entity.HasOne(d => d.cnt08llaveNavigation).WithMany(p => p.cnt17Bloqueos)
                    .HasForeignKey(d => d.cnt08llave)
                    .HasConstraintName("FK_CNT17_Bloqueos_CNT08_Segmentacion");

                entity.HasOne(d => d.cnt14llaveNavigation).WithMany(p => p.cnt17Bloqueos)
                    .HasForeignKey(d => d.cnt14llave)
                    .HasConstraintName("FK_CNT17_Bloqueos_CNT14_ClienteLicencia");

                entity.HasOne(d => d.cnt16llaveNavigation).WithMany(p => p.cnt17Bloqueos)
                    .HasForeignKey(d => d.cnt16llave)
                    .HasConstraintName("FK_CNT17_Bloqueos_CNT16_TipoBloqueoCliente");
            });

            modelBuilder.Entity<cnt18NivelSegmentacion>(entity =>
            {
                entity.HasKey(e => e.cnt18llave);

                entity.ToTable("CNT18_NivelSegmentacion");

                entity.Property(e => e.cnt18llave).HasColumnName("CNT18_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt18activo).HasColumnName("CNT18_activo");
                entity.Property(e => e.cnt18Descripccion)
                    .HasMaxLength(500)
                    .HasColumnName("CNT18_Descripccion");
                entity.Property(e => e.cnt18NivelCapa).HasColumnName("CNT18_NivelCapa");
                entity.Property(e => e.cnt18nombre)
                    .HasMaxLength(500)
                    .HasColumnName("CNT18_nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<cnt19LicenciaCliente>(entity =>
            {
                entity.HasKey(e => e.cnt19llave);

                entity.ToTable("CNT19_LicenciaCliente");

                entity.HasIndex(e => e.cnt01llave, "IX_CNT19_LicenciaCliente_CNT01_llave");

                entity.Property(e => e.cnt19llave).HasColumnName("CNT19_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt01llave).HasColumnName("CNT01_llave");
                entity.Property(e => e.cnt19activo).HasColumnName("CNT19_activo");
                entity.Property(e => e.cnt19FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT19_FechaInicio");
                entity.Property(e => e.cnt19FechaTermino)
                    .HasColumnType("datetime")
                    .HasColumnName("CNT19_FechaTermino");
                entity.Property(e => e.cnt19nombreLicencia)
                    .HasMaxLength(500)
                    .HasColumnName("CNT19_nombreLicencia");
                entity.Property(e => e.cnt19NumeroDias).HasColumnName("CNT19_NumeroDias");
                entity.Property(e => e.cnt19NumeroUsuario).HasColumnName("CNT19_NumeroUsuario");
                entity.Property(e => e.cnt19ValorReferencial).HasColumnName("CNT19_valor_referencial");
                entity.Property(e => e.cnt23llave).HasColumnName("CNT23_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Lnc01llave).HasColumnName("LNC01_llave");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");

                entity.HasOne(d => d.cnt01llaveNavigation).WithMany(p => p.cnt19LicenciaClientes)
                    .HasForeignKey(d => d.cnt01llave)
                    .HasConstraintName("FK_CNT19_LicenciaCliente_CNT01_CuentaCliente");
            });

            modelBuilder.Entity<cnt20LicenciaServicio>(entity =>
            {
                entity.HasKey(e => new { e.cnt19llave, e.Serv01llave });

                entity.ToTable("CNT20_LicenciaServicio");

                entity.Property(e => e.cnt19llave).HasColumnName("CNT19_llave");
                entity.Property(e => e.Serv01llave).HasColumnName("SERV01_llave");
                entity.Property(e => e.cnt20Habilitaservicio).HasColumnName("CNT20_habilitaservicio");
                entity.Property(e => e.cnt20Valor).HasColumnName("CNT20_Valor");

                entity.HasOne(d => d.cnt19llaveNavigation).WithMany(p => p.cnt20LicenciaServicios)
                    .HasForeignKey(d => d.cnt19llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT20_LicenciaServicio_CNT19_LicenciaCliente");
            });

            modelBuilder.Entity<cnt21TipoEstacion>(entity =>
            {
                entity.HasKey(e => e.cnt21llave);

                entity.ToTable("CNT21_TipoEstacion");

                entity.Property(e => e.cnt21llave).HasColumnName("CNT21_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt21activo).HasColumnName("CNT21_activo");
                entity.Property(e => e.cnt21descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("CNT21_descripcion");
                entity.Property(e => e.cnt21nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CNT21_nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<cnt22EstacionTipoEstacion>(entity =>
            {
                entity.HasKey(e => new { e.cnt08llave, e.cnt21llave });

                entity.ToTable("CNT22_Estacion_TipoEstacion");

                entity.HasIndex(e => e.cnt21llave, "IX_CNT22_Estacion_TipoEstacion_CNT21_llave");

                entity.Property(e => e.cnt08llave).HasColumnName("CNT08_llave");
                entity.Property(e => e.cnt21llave).HasColumnName("CNT21_llave");
                entity.Property(e => e.cnt22Estado).HasColumnName("CNT22_estado");

                entity.HasOne(d => d.cnt08llaveNavigation).WithMany(p => p.cnt22EstacionTipoEstacions)
                    .HasForeignKey(d => d.cnt08llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT22_Estacion_TipoEstacion_CNT08_Segmentacion");

                entity.HasOne(d => d.cnt21llaveNavigation).WithMany(p => p.cnt22EstacionTipoEstacions)
                    .HasForeignKey(d => d.cnt21llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CNT22_Estacion_TipoEstacion_CNT21_TipoEstacion");
            });

            modelBuilder.Entity<cnt23Tipocobro>(entity =>
            {
                entity.HasKey(e => e.cnt23llave);

                entity.ToTable("CNT23_Tipocobro");

                entity.Property(e => e.cnt23llave).HasColumnName("CNT23_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt23activo).HasColumnName("CNT23_activo");
                entity.Property(e => e.cnt23descripcion)
                    .HasMaxLength(2000)
                    .HasColumnName("CNT23_descripcion");
                entity.Property(e => e.cnt23nombre)
                    .HasMaxLength(500)
                    .HasColumnName("CNT23_nombre");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<cnt24AsociarCuenta>(entity =>
            {
                entity.HasKey(e => new { e.cnt01llave, e.cnt01Cuentallave });

                entity.ToTable("CNT24_AsociarCuenta");

                entity.Property(e => e.cnt01llave).HasColumnName("CNT01_llave");
                entity.Property(e => e.cnt01Cuentallave).HasColumnName("CNT01_Cuenta_llave");
            });

            modelBuilder.Entity<Comuna>(entity =>
            {
                entity.HasIndex(e => e.RegionId, "IX_Comunas_RegionId");

                entity.Property(e => e.isDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Region).WithMany(p => p.Comunas).HasForeignKey(d => d.RegionId);
            });

            modelBuilder.Entity<Cont01Contacto>(entity =>
            {
                entity.HasKey(e => e.Cont01llave);

                entity.ToTable("CONT01_Contacto");

                entity.HasIndex(e => e.Cont02llave, "IX_CONT01_Contacto_CONT02_llave");

                entity.Property(e => e.Cont01llave).HasColumnName("CONT01_llave");
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
                entity.Property(e => e.Cont01nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CONT01_nombre");
                entity.Property(e => e.Cont01PeticionContacto)
                    .HasMaxLength(500)
                    .HasColumnName("CONT01_PeticionContacto");
                entity.Property(e => e.Cont01Telefono)
                    .HasMaxLength(250)
                    .HasColumnName("CONT01_Telefono");
                entity.Property(e => e.Cont01Titulo).HasColumnName("CONT01_Titulo");
                entity.Property(e => e.Cont02llave).HasColumnName("CONT02_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");

                entity.HasOne(d => d.Cont02llaveNavigation).WithMany(p => p.Cont01Contactos)
                    .HasForeignKey(d => d.Cont02llave)
                    .HasConstraintName("FK_CONT01_Contacto_CONT02_TipoContacto");
            });

            modelBuilder.Entity<Cont02TipoContacto>(entity =>
            {
                entity.HasKey(e => e.Cont02llave);

                entity.ToTable("CONT02_TipoContacto");

                entity.Property(e => e.Cont02llave).HasColumnName("CONT02_llave");
                entity.Property(e => e.Cont02descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("CONT02_descripcion");
                entity.Property(e => e.Cont02nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CONT02_nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<Conteo01Conteo>(entity =>
            {
                entity.HasKey(e => e.Conteo01llave);

                entity.ToTable("CONTEO01_Conteos");

                entity.HasIndex(e => e.Temp02llave, "IX_CONTEO01_Conteos_TEMP02_llave");

                entity.Property(e => e.Conteo01llave).HasColumnName("CONTEO01_llave");
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
                entity.Property(e => e.Conteo01Tiposistema).HasColumnName("CONTEO01_Tiposistema");
                entity.Property(e => e.Conteo01Valor).HasColumnName("CONTEO01_Valor");
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
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHACREACION");
                entity.Property(e => e.Mvl01llave)
                    .HasMaxLength(50)
                    .HasColumnName("MVL01_llave");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");
                entity.Property(e => e.Trp01llave).HasColumnName("TRP01_llave");

                entity.HasOne(d => d.Temp02llaveNavigation).WithMany(p => p.Conteo01Conteos)
                    .HasForeignKey(d => d.Temp02llave)
                    .HasConstraintName("FK_CONTEO01_Conteos_TEMP02_TemporadaBase");
            });

            modelBuilder.Entity<Conteo02Procesado>(entity =>
            {
                entity.HasKey(e => e.Conteo02llave);

                entity.ToTable("CONTEO02_Procesados");

                entity.HasIndex(e => e.cnt08llave, "IX_CONTEO02_Procesados_CNT08_llave");

                entity.Property(e => e.Conteo02llave).HasColumnName("CONTEO02_llave");
                entity.Property(e => e.cnt08llave).HasColumnName("CNT08_llave");
                entity.Property(e => e.Conteo02Cantidad).HasColumnName("CONTEO02_Cantidad");
                entity.Property(e => e.Conteo02Cotatenado)
                    .HasMaxLength(100)
                    .HasColumnName("CONTEO02_Cotatenado");
                entity.Property(e => e.Conteo02FechaProceso)
                    .HasColumnType("datetime")
                    .HasColumnName("CONTEO02_fechaProceso");
                entity.Property(e => e.Conteo02Promedio).HasColumnName("CONTEO02_Promedio");
                entity.Property(e => e.Conteo02Suma).HasColumnName("CONTEO02_Suma");
                entity.Property(e => e.esp01llave).HasColumnName("ESP01_llave");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");

                entity.HasOne(d => d.cnt08llaveNavigation).WithMany(p => p.Conteo02Procesados)
                    .HasForeignKey(d => d.cnt08llave)
                    .HasConstraintName("FK_CONTEO02_Procesados_CNT08_Segmentacion");
            });

            modelBuilder.Entity<Conteo03Resumen>(entity =>
            {
                entity.HasKey(e => e.Conteo03llave);

                entity.ToTable("CONTEO03_Resumen");

                entity.HasIndex(e => e.cnt08llave, "IX_CONTEO03_Resumen_CNT08_llave");

                entity.Property(e => e.Conteo03llave).HasColumnName("CONTEO03_llave");
                entity.Property(e => e.cnt08llave).HasColumnName("CNT08_llave");
                entity.Property(e => e.Conteo03Estado).HasColumnName("CONTEO03_Estado");
                entity.Property(e => e.esp01llave).HasColumnName("ESP01_llave");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");

                entity.HasOne(d => d.cnt08llaveNavigation).WithMany(p => p.Conteo03Resumen)
                    .HasForeignKey(d => d.cnt08llave)
                    .HasConstraintName("FK_CONTEO03_Resumen_CNT08_Segmentacion");
            });

            modelBuilder.Entity<Conteo04ResumenSag>(entity =>
            {
                entity.HasKey(e => e.Conteo04llave);

                entity.ToTable("CONTEO04_ResumenSag");

                entity.HasIndex(e => e.esp01llave, "IX_CONTEO04_ResumenSag_ESP01_llave");

                entity.HasIndex(e => e.sist03llave, "IX_CONTEO04_ResumenSag_SIST03_llave");

                entity.HasIndex(e => e.Temp02llave, "IX_CONTEO04_ResumenSag_TEMP02_llave");

                entity.Property(e => e.Conteo04llave).HasColumnName("CONTEO04_llave");
                entity.Property(e => e.Conteo04Estado).HasColumnName("CONTEO04_Estado");
                entity.Property(e => e.esp01llave).HasColumnName("ESP01_llave");
                entity.Property(e => e.sist03llave).HasColumnName("SIST03_llave");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");

                entity.HasOne(d => d.esp01llaveNavigation).WithMany(p => p.Conteo04ResumenSags)
                    .HasForeignKey(d => d.esp01llave)
                    .HasConstraintName("FK_CONTEO04_ResumenSag_ESP01_especies");

                entity.HasOne(d => d.sist03llaveNavigation).WithMany(p => p.Conteo04ResumenSags)
                    .HasForeignKey(d => d.sist03llave)
                    .HasConstraintName("FK_CONTEO04_ResumenSag_SIST03_Comuna");

                entity.HasOne(d => d.Temp02llaveNavigation).WithMany(p => p.Conteo04ResumenSags)
                    .HasForeignKey(d => d.Temp02llave)
                    .HasConstraintName("FK_CONTEO04_ResumenSag_TEMP02_TemporadaBase");
            });

            modelBuilder.Entity<Conteo05ControlReserva>(entity =>
            {
                entity.HasKey(e => e.Conteo05llave);

                entity.ToTable("CONTEO05_Control_Reserva");

                entity.HasIndex(e => e.userid, "IX_CONTEO05_Control_Reserva_SECU02_llave");

                entity.Property(e => e.Conteo05llave).HasColumnName("CONTEO05_llave");
                entity.Property(e => e.Conteo05ColumnaControl)
                    .HasMaxLength(1000)
                    .HasColumnName("CONTEO05_columna_control");
                entity.Property(e => e.Conteo05Estado)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("CONTEO05_Estado");
                entity.Property(e => e.Conteo05EstadoControl).HasColumnName("CONTEO05_estado_control");
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
                entity.Property(e => e.Conteo05ValorControl).HasColumnName("CONTEO05_valor_control");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.userid).HasColumnName("SECU02_llave");

                entity.HasOne(d => d.useridNavigation).WithMany(p => p.Conteo05ControlReservas)
                    .HasForeignKey(d => d.userid)
                    .HasConstraintName("FK_CONTEO05_Control_Reserva_SECU02_Usuario");
            });

            modelBuilder.Entity<Ctt01Contrato>(entity =>
            {
                entity.HasKey(e => e.Ctt01llave);

                entity.ToTable("CTT01_Contrato");

                entity.HasIndex(e => e.Ctt02llave, "IX_CTT01_Contrato_CTT02_llave");

                entity.Property(e => e.Ctt01llave).HasColumnName("CTT01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.Ctt01activo).HasColumnName("CTT01_activo");
                entity.Property(e => e.Ctt01ContratoHtml).HasColumnName("CTT01_ContratoHtml");
                entity.Property(e => e.Ctt01descripcion).HasColumnName("CTT01_descripcion");
                entity.Property(e => e.Ctt01nombre)
                    .HasMaxLength(500)
                    .HasColumnName("CTT01_nombre");
                entity.Property(e => e.Ctt02llave).HasColumnName("CTT02_llave");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");

                entity.HasOne(d => d.Ctt02llaveNavigation).WithMany(p => p.Ctt01Contratos)
                    .HasForeignKey(d => d.Ctt02llave)
                    .HasConstraintName("FK_CTT01_Contrato_CTT02_TipoContrato");
            });

            modelBuilder.Entity<Ctt02TipoContrato>(entity =>
            {
                entity.HasKey(e => e.Ctt02llave);

                entity.ToTable("CTT02_TipoContrato");

                entity.Property(e => e.Ctt02llave).HasColumnName("CTT02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.Ctt02activo).HasColumnName("CTT02_activo");
                entity.Property(e => e.Ctt02descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("CTT02_descripcion");
                entity.Property(e => e.Ctt02nombre)
                    .HasMaxLength(250)
                    .HasColumnName("CTT02_nombre");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<Ctzr01Cotizacion>(entity =>
            {
                entity.HasKey(e => e.Ctzr01llave);

                entity.ToTable("CTZR01_Cotizacion");

                entity.Property(e => e.Ctzr01llave).HasColumnName("CTZR01_llave");
                entity.Property(e => e.Ctzr01activo).HasColumnName("CTZR01_activo");
                entity.Property(e => e.Ctzr01Comentario).HasColumnName("CTZR01_comentario");
                entity.Property(e => e.Ctzr01Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("CTZR01_fecha");
                entity.Property(e => e.Lnc01llave).HasColumnName("LNC01_llave");
                entity.Property(e => e.userid).HasColumnName("SECU02_llave");
            });

            modelBuilder.Entity<Eml01BitacoraEmailUsuario>(entity =>
            {
                entity.HasKey(e => e.Eml01llave).HasName("PK_EML01_EmailUsuario");

                entity.ToTable("EML01_BitacoraEmailUsuario");

                entity.HasIndex(e => e.Eml02llave, "IX_EML01_BitacoraEmailUsuario_EML02_llave");

                entity.HasIndex(e => e.Eml04llave, "IX_EML01_BitacoraEmailUsuario_EML04_llave");

                entity.HasIndex(e => e.userid, "IX_EML01_BitacoraEmailUsuario_SECU02_llave");

                entity.Property(e => e.Eml01llave).HasColumnName("EML01_llave");
                entity.Property(e => e.Eml01activo).HasColumnName("EML01_activo");
                entity.Property(e => e.Eml01Asunto).HasColumnName("EML01_Asunto");
                entity.Property(e => e.Eml01Contenido)
                    .HasMaxLength(50)
                    .HasColumnName("EML01_Contenido");
                entity.Property(e => e.Eml01De).HasColumnName("EML01_De");
                entity.Property(e => e.Eml01Envio)
                    .HasColumnType("datetime")
                    .HasColumnName("EML01_Envio");
                entity.Property(e => e.Eml01MailPadre).HasColumnName("EML01_MailPAdre");
                entity.Property(e => e.Eml01Para).HasColumnName("EML01_Para");
                entity.Property(e => e.Eml01Text).HasColumnName("EML01_Text");
                entity.Property(e => e.Eml02llave).HasColumnName("EML02_llave");
                entity.Property(e => e.Eml04llave).HasColumnName("EML04_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.userid).HasColumnName("SECU02_llave");

                entity.HasOne(d => d.Eml02llaveNavigation).WithMany(p => p.Eml01BitacoraEmailUsuarios)
                    .HasForeignKey(d => d.Eml02llave)
                    .HasConstraintName("FK_EML01_EmailUsuario_EML02_MailBase");

                entity.HasOne(d => d.Eml04llaveNavigation).WithMany(p => p.Eml01BitacoraEmailUsuarios)
                    .HasForeignKey(d => d.Eml04llave)
                    .HasConstraintName("FK_EML01_EmailUsuario_EML04_ImportanciaMail");

                entity.HasOne(d => d.useridNavigation).WithMany(p => p.Eml01BitacoraEmailUsuarios)
                    .HasForeignKey(d => d.userid)
                    .HasConstraintName("FK_EML01_BitacoraEmailUsuario_SECU02_Usuario");
            });

            modelBuilder.Entity<Eml02MailBase>(entity =>
            {
                entity.HasKey(e => e.Eml02llave);

                entity.ToTable("EML02_MailBase");

                entity.HasIndex(e => e.Eml03llave, "IX_EML02_MailBase_EML03_llave");

                entity.HasIndex(e => e.Eml04llave, "IX_EML02_MailBase_EML04_llave");

                entity.Property(e => e.Eml02llave).HasColumnName("EML02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Eml02activo).HasColumnName("EML02_activo");
                entity.Property(e => e.Eml02Asunto).HasColumnName("EML02_Asunto");
                entity.Property(e => e.Eml02CodigoLlamado)
                    .HasMaxLength(500)
                    .HasColumnName("EML02_CodigoLlamado");
                entity.Property(e => e.Eml02ContenidoHtml).HasColumnName("EML02_ContenidoHtml");
                entity.Property(e => e.Eml02ContenidoText).HasColumnName("EML02_ContenidoText");
                entity.Property(e => e.Eml02descripcion).HasColumnName("EML02_descripcion");
                entity.Property(e => e.Eml03llave).HasColumnName("EML03_llave");
                entity.Property(e => e.Eml04llave).HasColumnName("EML04_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");

                entity.HasOne(d => d.Eml03llaveNavigation).WithMany(p => p.Eml02MailBases)
                    .HasForeignKey(d => d.Eml03llave)
                    .HasConstraintName("FK_EML02_MailBase_EML03_TipoMailAcciones");

                entity.HasOne(d => d.Eml04llaveNavigation).WithMany(p => p.Eml02MailBases)
                    .HasForeignKey(d => d.Eml04llave)
                    .HasConstraintName("FK_EML02_MailBase_EML04_ImportanciaMail");
            });

            modelBuilder.Entity<Eml03TipoMailAccion>(entity =>
            {
                entity.HasKey(e => e.Eml03llave).HasName("PK_EML03_TipoMailAcciones_1");

                entity.ToTable("EML03_TipoMailAcciones");

                entity.Property(e => e.Eml03llave).HasColumnName("EML03_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Eml03activo).HasColumnName("EML03_activo");
                entity.Property(e => e.Eml03descripcion).HasColumnName("EML03_descripcion");
                entity.Property(e => e.Eml03nombre)
                    .HasMaxLength(500)
                    .HasColumnName("EML03_nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<Eml04ImportanciaMail>(entity =>
            {
                entity.HasKey(e => e.Eml04llave);

                entity.ToTable("EML04_ImportanciaMail");

                entity.Property(e => e.Eml04llave).HasColumnName("EML04_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Eml04activo).HasColumnName("EML04_activo");
                entity.Property(e => e.Eml04descripcion).HasColumnName("EML04_descripcion");
                entity.Property(e => e.Eml04nombre)
                    .HasMaxLength(500)
                    .HasColumnName("EML04_nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<Eml05ArchivoMail>(entity =>
            {
                entity.HasKey(e => e.Eml05llave);

                entity.ToTable("EML05_ArchivoMail");

                entity.HasIndex(e => e.Eml01llave, "IX_EML05_ArchivoMail_EML01_llave");

                entity.Property(e => e.Eml05llave)
                    .ValueGeneratedNever()
                    .HasColumnName("EML05_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Eml01llave).HasColumnName("EML01_llave");
                entity.Property(e => e.Eml05activo).HasColumnName("EML05_activo");
                entity.Property(e => e.Eml05Archivo).HasColumnName("EML05_Archivo");
                entity.Property(e => e.Eml05Ruta).HasColumnName("EML05_Ruta");
                entity.Property(e => e.Eml06llave).HasColumnName("EML06_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");

                entity.HasOne(d => d.Eml01llaveNavigation).WithMany(p => p.Eml05ArchivoMails)
                    .HasForeignKey(d => d.Eml01llave)
                    .HasConstraintName("FK_EML05_ArchivoMail_EML01_EmailUsuario");

                entity.HasOne(d => d.Eml05llaveNavigation).WithOne(p => p.Eml05ArchivoMail)
                    .HasForeignKey<Eml05ArchivoMail>(d => d.Eml05llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EML05_ArchivoMail_EML06_TipoArchivo");
            });

            modelBuilder.Entity<Eml06TipoArchivo>(entity =>
            {
                entity.HasKey(e => e.Eml06llave);

                entity.ToTable("EML06_TipoArchivo");

                entity.Property(e => e.Eml06llave).HasColumnName("EML06_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Eml06activo).HasColumnName("EML06_activo");
                entity.Property(e => e.Eml06descripcion).HasColumnName("EML06_descripcion");
                entity.Property(e => e.Eml06nombre)
                    .HasMaxLength(500)
                    .HasColumnName("EML06_nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<esp01especie>(entity =>
            {
                entity.HasKey(e => e.esp01llave);

                entity.ToTable("ESP01_especies");

                entity.HasIndex(e => e.esp03llave, "IX_ESP01_especies_ESP03_llave");

                entity.HasIndex(e => e.esp04llave, "IX_ESP01_especies_ESP04_llave");

                entity.Property(e => e.esp01llave).HasColumnName("ESP01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp01activo).HasColumnName("ESP01_activo");
                entity.Property(e => e.esp03llave).HasColumnName("ESP03_llave");
                entity.Property(e => e.esp04llave).HasColumnName("ESP04_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");

                entity.HasOne(d => d.esp03llaveNavigation).WithMany(p => p.esp01especies)
                    .HasForeignKey(d => d.esp03llave)
                    .HasConstraintName("FK_ESP01_especies_ESP03_especieBase");

                entity.HasOne(d => d.esp04llaveNavigation).WithMany(p => p.esp01especies)
                    .HasForeignKey(d => d.esp04llave)
                    .HasConstraintName("FK_ESP01_especies_ESP04_EstadoDanio");
            });

            modelBuilder.Entity<esp02Temporadaespecie>(entity =>
            {
                entity.HasKey(e => e.esp02llave);

                entity.ToTable("ESP02_Temporadaespecie");

                entity.HasIndex(e => e.esp01llave, "IX_ESP02_Temporadaespecie_ESP01_llave");

                entity.HasIndex(e => e.Temp01llave, "IX_ESP02_Temporadaespecie_TEMP01_llave");

                entity.Property(e => e.esp02llave).HasColumnName("ESP02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp01llave).HasColumnName("ESP01_llave");
                entity.Property(e => e.esp02activo).HasColumnName("ESP02_activo");
                entity.Property(e => e.esp02InicioTemporada)
                    .HasColumnType("datetime")
                    .HasColumnName("ESP02_InicioTemporada");
                entity.Property(e => e.esp02Mexico).HasColumnName("ESP02_Mexico");
                entity.Property(e => e.esp02Sag).HasColumnName("ESP02_Sag");
                entity.Property(e => e.esp02TerminoTemporada)
                    .HasColumnType("datetime")
                    .HasColumnName("ESP02_TerminoTemporada");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Temp01llave).HasColumnName("TEMP01_llave");

                entity.HasOne(d => d.esp01llaveNavigation).WithMany(p => p.esp02Temporadaespecies)
                    .HasForeignKey(d => d.esp01llave)
                    .HasConstraintName("FK_ESP02_Temporadaespecie_ESP01_especies");

                entity.HasOne(d => d.Temp01llaveNavigation).WithMany(p => p.esp02Temporadaespecies)
                    .HasForeignKey(d => d.Temp01llave)
                    .HasConstraintName("FK_ESP02_Temporadaespecie_TEMP01_Temporada");
            });

            modelBuilder.Entity<esp03especieBase>(entity =>
            {
                entity.HasKey(e => e.esp03llave);

                entity.ToTable("ESP03_especieBase");

                entity.HasIndex(e => e.esp08llave, "IX_ESP03_especieBase_ESP08_llave");

                entity.Property(e => e.esp03llave).HasColumnName("ESP03_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp03activo).HasColumnName("ESP03_activo");
                entity.Property(e => e.esp03descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("ESP03_descripcion");
                entity.Property(e => e.esp03EstadoRegistro)
                    .HasMaxLength(50)
                    .HasColumnName("ESP03_EstadoRegistro");
                entity.Property(e => e.esp03ImgGrande).HasColumnName("ESP03_ImgGrande");
                entity.Property(e => e.esp03ImgPequenia).HasColumnName("ESP03_ImgPequenia");
                entity.Property(e => e.esp03nombre)
                    .HasMaxLength(250)
                    .HasColumnName("ESP03_nombre");
                entity.Property(e => e.esp03Union).HasColumnName("ESP03_Union");
                entity.Property(e => e.esp08llave).HasColumnName("ESP08_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");

                entity.HasOne(d => d.esp08llaveNavigation).WithMany(p => p.esp03especieBases)
                    .HasForeignKey(d => d.esp08llave)
                    .HasConstraintName("FK_ESP03_especieBase_ESP08_TipoBase");
            });

            modelBuilder.Entity<esp04EstadoDanio>(entity =>
            {
                entity.HasKey(e => e.esp04llave);

                entity.ToTable("ESP04_EstadoDanio");

                entity.HasIndex(e => e.esp06llave, "IX_ESP04_EstadoDanio_ESP06_llave");

                entity.Property(e => e.esp04llave).HasColumnName("ESP04_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp04activo).HasColumnName("ESP04_activo");
                entity.Property(e => e.esp04descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("ESP04_descripcion");
                entity.Property(e => e.esp04nombre)
                    .HasMaxLength(250)
                    .HasColumnName("ESP04_nombre");
                entity.Property(e => e.esp06llave).HasColumnName("ESP06_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");

                entity.HasOne(d => d.esp06llaveNavigation).WithMany(p => p.esp04EstadoDanios)
                    .HasForeignKey(d => d.esp06llave)
                    .HasConstraintName("FK_ESP04_EstadoDanio_ESP06_MedidaUmbral");
            });

            modelBuilder.Entity<esp05Umbral>(entity =>
            {
                entity.HasKey(e => e.esp05llave);

                entity.ToTable("ESP05_Umbral");

                entity.HasIndex(e => e.esp01llave, "IX_ESP05_Umbral_ESP01_llave");

                entity.HasIndex(e => e.esp09llave, "IX_ESP05_Umbral_ESP09_llave");

                entity.Property(e => e.esp05llave).HasColumnName("ESP05_LLave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp01llave).HasColumnName("ESP01_llave");
                entity.Property(e => e.esp05activo).HasColumnName("ESP05_activo");
                entity.Property(e => e.esp05Color)
                    .HasMaxLength(50)
                    .HasColumnName("ESP05_Color");
                entity.Property(e => e.esp05MaxUmbral).HasColumnName("ESP05_MaxUmbral");
                entity.Property(e => e.esp05MinUmbral).HasColumnName("ESP05_MinUmbral");
                entity.Property(e => e.esp09llave).HasColumnName("ESP09_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");

                entity.HasOne(d => d.esp01llaveNavigation).WithMany(p => p.esp05Umbrals)
                    .HasForeignKey(d => d.esp01llave)
                    .HasConstraintName("FK_ESP05_Umbral_ESP01_especies");

                entity.HasOne(d => d.esp09llaveNavigation).WithMany(p => p.esp05Umbrals)
                    .HasForeignKey(d => d.esp09llave)
                    .HasConstraintName("FK_ESP05_Umbral_ESP09_TipoBaseUmbral");
            });

            modelBuilder.Entity<esp06MedidaUmbral>(entity =>
            {
                entity.HasKey(e => e.esp06llave);

                entity.ToTable("ESP06_MedidaUmbral");

                entity.Property(e => e.esp06llave).HasColumnName("ESP06_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp06activo).HasColumnName("ESP06_activo");
                entity.Property(e => e.esp06descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("ESP06_descripcion");
                entity.Property(e => e.esp06nombre)
                    .HasMaxLength(250)
                    .HasColumnName("ESP06_nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<esp07Union>(entity =>
            {
                entity.HasKey(e => new { e.esp03llave, e.esp03llaveUnion });

                entity.ToTable("ESP07_Union");

                entity.Property(e => e.esp03llave).HasColumnName("ESP03_llave");
                entity.Property(e => e.esp03llaveUnion).HasColumnName("ESP03_llaveUnion");

                entity.HasOne(d => d.esp03llaveNavigation).WithMany(p => p.esp07Unions)
                    .HasForeignKey(d => d.esp03llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESP07_Union_ESP03_especieBase");
            });

            modelBuilder.Entity<esp08TipoBase>(entity =>
            {
                entity.HasKey(e => e.esp08llave);

                entity.ToTable("ESP08_TipoBase");

                entity.Property(e => e.esp08llave).HasColumnName("ESP08_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp08activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("ESP08_activo");
                entity.Property(e => e.esp08descripcion).HasColumnName("ESP08_descripcion");
                entity.Property(e => e.esp08nombre)
                    .HasMaxLength(500)
                    .HasColumnName("ESP08_nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<esp09TipoBaseUmbral>(entity =>
            {
                entity.HasKey(e => e.esp09llave);

                entity.ToTable("ESP09_TipoBaseUmbral");

                entity.Property(e => e.esp09llave).HasColumnName("ESP09_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp09activo).HasColumnName("ESP09_activo");
                entity.Property(e => e.esp09descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("ESP09_descripcion");
                entity.Property(e => e.esp09nombre)
                    .HasMaxLength(250)
                    .HasColumnName("ESP09_nombre");
                entity.Property(e => e.esp09Orden).HasColumnName("ESP09_Orden");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<esp10TipoRegla>(entity =>
            {
                entity.HasKey(e => e.esp10llave);

                entity.ToTable("ESP10_TipoRegla");

                entity.Property(e => e.esp10llave).HasColumnName("ESP10_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp10activo).HasColumnName("ESP10_activo");
                entity.Property(e => e.esp10descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("ESP10_descripcion");
                entity.Property(e => e.esp10nombre)
                    .HasMaxLength(250)
                    .HasColumnName("ESP10_nombre");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
            });

            modelBuilder.Entity<esp11ReglaGrafico>(entity =>
            {
                entity.HasKey(e => e.esp11llave);

                entity.ToTable("ESP11_ReglaGrafico");

                entity.HasIndex(e => e.esp10llave, "IX_ESP11_ReglaGrafico_ESP10_llave");

                entity.Property(e => e.esp11llave).HasColumnName("ESP11_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp03llave).HasColumnName("ESP03_llave");
                entity.Property(e => e.esp10llave).HasColumnName("ESP10_llave");
                entity.Property(e => e.esp11estado).HasColumnName("ESP11_Estado");
                entity.Property(e => e.esp11nombre)
                    .HasMaxLength(250)
                    .HasColumnName("ESP11_nombre");
                entity.Property(e => e.esp11signo1)
                    .HasMaxLength(50)
                    .HasColumnName("ESP11_Signo1");
                entity.Property(e => e.esp11signo2)
                    .HasMaxLength(50)
                    .HasColumnName("ESP11_Signo2");
                entity.Property(e => e.esp11signoresultado)
                    .HasMaxLength(50)
                    .HasColumnName("ESP11_SignoResultado");
                entity.Property(e => e.esp11valor1).HasColumnName("ESP11_Valor1");
                entity.Property(e => e.esp11valor2).HasColumnName("ESP11_Valor2");
                entity.Property(e => e.esp11valorresultado).HasColumnName("ESP11_ValorResultado");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");

                entity.HasOne(d => d.esp10llaveNavigation).WithMany(p => p.esp11ReglaGraficos)
                    .HasForeignKey(d => d.esp10llave)
                    .HasConstraintName("FK_ESP11_ReglaGrafico_ESP10_TipoRegla");
            });

            modelBuilder.Entity<Frm01TipoFormulario>(entity =>
            {
                entity.HasKey(e => e.Frm01llave);

                entity.ToTable("FRM01_TipoFormulario");

                entity.Property(e => e.Frm01llave).HasColumnName("FRM01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Frm01activo).HasColumnName("FRM01_activo");
                entity.Property(e => e.Frm01nombre)
                    .HasMaxLength(255)
                    .HasColumnName("FRM01_nombre");
            });

            modelBuilder.Entity<Frm02Formulario>(entity =>
            {
                entity.HasKey(e => e.Frm02llave);

                entity.ToTable("FRM02_Formulario");

                entity.HasIndex(e => e.Eml01llave, "IX_FRM02_Formulario_EML01_llave");

                entity.HasIndex(e => e.Frm01llave, "IX_FRM02_Formulario_FRM01_llave");

                entity.Property(e => e.Frm02llave).HasColumnName("FRM02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.Eml01llave).HasColumnName("EML01_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Frm01llave).HasColumnName("FRM01_llave");
                entity.Property(e => e.Frm02activo).HasColumnName("FRM02_activo");
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
                entity.Property(e => e.Frm02nombre)
                    .HasMaxLength(250)
                    .HasColumnName("FRM02_nombre");
                entity.Property(e => e.Frm02Telefono)
                    .HasMaxLength(50)
                    .HasColumnName("FRM02_Telefono");

                entity.HasOne(d => d.Eml01llaveNavigation).WithMany(p => p.Frm02Formularios)
                    .HasForeignKey(d => d.Eml01llave)
                    .HasConstraintName("FK_FRM02_Formulario_EML01_BitacoraEmailUsuario");

                entity.HasOne(d => d.Frm01llaveNavigation).WithMany(p => p.Frm02Formularios)
                    .HasForeignKey(d => d.Frm01llave)
                    .HasConstraintName("FK_FRM02_Formulario_FRM01_TipoFormulario");
            });

            modelBuilder.Entity<Grfc01GraficoGenerado>(entity =>
            {
                entity.HasKey(e => e.Grfc01llave);

                entity.ToTable("GRFC01_GraficoGenerado");

                entity.Property(e => e.Grfc01llave).HasColumnName("GRFC01_llave");
                entity.Property(e => e.Grfc01CodigoGrafico)
                    .HasMaxLength(150)
                    .HasColumnName("GRFC01_codigo_grafico");
                entity.Property(e => e.Grfc01Estado).HasColumnName("GRFC01_estado");
                entity.Property(e => e.Grfc01FechaGrafico)
                    .HasColumnType("datetime")
                    .HasColumnName("GRFC01_FechaGrafico");
                entity.Property(e => e.Grfc02llave).HasColumnName("GRFC02_llave");
                entity.Property(e => e.userid).HasColumnName("SECU02_llave");
            });

            modelBuilder.Entity<Grfc02TipoGrafico>(entity =>
            {
                entity.HasKey(e => e.Grfc02llave);

                entity.ToTable("GRFC02_TipoGrafico");

                entity.Property(e => e.Grfc02llave).HasColumnName("GRFC02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Grfc02activo).HasColumnName("GRFC02_activo");
                entity.Property(e => e.Grfc02descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("GRFC02_descripcion");
                entity.Property(e => e.Grfc02nombre)
                    .HasMaxLength(250)
                    .HasColumnName("GRFC02_nombre");
            });

            modelBuilder.Entity<Grfc03RespaldoGrafico>(entity =>
            {
                entity.HasKey(e => e.Grfc03llave);

                entity.ToTable("GRFC03_respaldoGrafico");

                entity.Property(e => e.Grfc03llave).HasColumnName("GRFC03_llave");
                entity.Property(e => e.cnt08llave).HasColumnName("CNT08_llave");
                entity.Property(e => e.esp03llave).HasColumnName("ESP03_llave");
                entity.Property(e => e.Grfc03Estado).HasColumnName("GRFC03_Estado");
                entity.Property(e => e.Grfc03UltimaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("GRFC03_ultimaFecha");
                entity.Property(e => e.Grfc03XmlDatos).HasColumnName("GRFC03_xmlDatos");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");
            });

            modelBuilder.Entity<Ins01Inscripcion>(entity =>
            {
                entity.HasKey(e => e.Ins01llave);

                entity.ToTable("INS01_Inscripcion");

                entity.Property(e => e.Ins01llave).HasColumnName("INS01_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Ins01activo).HasColumnName("INS01_activo");
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
                    .HasColumnName("INS01_FechaActivacion");
                entity.Property(e => e.Ins01FechaInscripcion)
                    .HasColumnType("datetime")
                    .HasColumnName("INS01_FechaInscripcion");
                entity.Property(e => e.Ins01FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("INS01_FechaNacimiento");
                entity.Property(e => e.Ins01nombre)
                    .HasMaxLength(250)
                    .HasColumnName("INS01_nombre");
                entity.Property(e => e.Ins01Password)
                    .HasMaxLength(50)
                    .HasColumnName("INS01_Password");
                entity.Property(e => e.Ins01Rut).HasColumnName("INS01_Rut");
                entity.Property(e => e.Ins01Telefono)
                    .HasMaxLength(250)
                    .HasColumnName("INS01_Telefono");
                entity.Property(e => e.Ins01UserName)
                    .HasMaxLength(250)
                    .HasColumnName("INS01_UserName");
                entity.Property(e => e.per02llave).HasColumnName("PER02_llave");
                entity.Property(e => e.sist03llave).HasColumnName("SIST03_llave");
            });

            modelBuilder.Entity<Ins02RecuperarClave>(entity =>
            {
                entity.HasKey(e => e.Ins02llave);

                entity.ToTable("INS02_RecuperarClave");

                entity.HasIndex(e => e.Ins02Estado, "IX_INS02_RecuperarClave_INS02_Estado");

                entity.Property(e => e.Ins02llave).HasColumnName("INS02_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Ins02ClaveTemporal)
                    .HasMaxLength(10)
                    .HasColumnName("INS02_ClaveTemporal");
                entity.Property(e => e.Ins02Estado).HasColumnName("INS02_Estado");
                entity.Property(e => e.Ins02FechaRecupera)
                    .HasColumnType("datetime")
                    .HasColumnName("INS02_FechaRecupera");
                entity.Property(e => e.userid).HasColumnName("SECU02_llave");

                entity.HasOne(d => d.Ins02EstadoNavigation).WithMany(p => p.Ins02RecuperarClaves)
                    .HasForeignKey(d => d.Ins02Estado)
                    .HasConstraintName("FK_INS02_RecuperarClave_SIST05_EstadoRegistro");
            });

            modelBuilder.Entity<Lnc01Licencia>(entity =>
            {
                entity.HasKey(e => e.Lnc01llave);

                entity.ToTable("LNC01_Licencias");

                entity.Property(e => e.Lnc01llave).HasColumnName("LNC01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Lnc01activo).HasColumnName("LNC01_activo");
                entity.Property(e => e.Lnc01descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("LNC01_descripcion");
                entity.Property(e => e.Lnc01Html).HasColumnName("LNC01_HTML");
                entity.Property(e => e.Lnc01Imagen)
                    .HasMaxLength(500)
                    .HasColumnName("LNC01_Imagen");
                entity.Property(e => e.Lnc01MaximoUsuarios).HasColumnName("LNC01_MaximoUsuarios");
                entity.Property(e => e.Lnc01nombre)
                    .HasMaxLength(250)
                    .HasColumnName("LNC01_nombre");
                entity.Property(e => e.Lnc01NumeroDias).HasColumnName("LNC01_NumeroDias");
                entity.Property(e => e.Lnc01TextoDias)
                    .HasMaxLength(250)
                    .HasColumnName("LNC01_TextoDias");
                entity.Property(e => e.Lnc01VisibleUsuario).HasColumnName("LNC01_VisibleUsuario");
                entity.Property(e => e.Lnc04llave).HasColumnName("LNC04_llave");
            });

            modelBuilder.Entity<Lnc02ServiciosLicencia>(entity =>
            {
                entity.HasKey(e => new { e.Lnc01llave, e.Serv01llave }).HasName("PK_LNC02_ServiciosLicencia_1");

                entity.ToTable("LNC02_ServiciosLicencia");

                entity.HasIndex(e => e.Serv01llave, "IX_LNC02_ServiciosLicencia_SERV01_llave");

                entity.Property(e => e.Lnc01llave).HasColumnName("LNC01_llave");
                entity.Property(e => e.Serv01llave).HasColumnName("SERV01_llave");
                entity.Property(e => e.Lnc02activo).HasColumnName("LNC02_activo");
                entity.Property(e => e.Lnc02EsIlimitado).HasColumnName("LNC02_EsIlimitado");
                entity.Property(e => e.Lnc02NumeroElemento).HasColumnName("LNC02_NumeroElemento");
                entity.Property(e => e.Lnc02permiteComparar).HasColumnName("LNC02_permiteComparar");

                entity.HasOne(d => d.Lnc01llaveNavigation).WithMany(p => p.Lnc02ServiciosLicencia)
                    .HasForeignKey(d => d.Lnc01llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LNC02_ServiciosLicencia_LNC01_Licencias");

                entity.HasOne(d => d.Serv01llaveNavigation).WithMany(p => p.Lnc02ServiciosLicencia)
                    .HasForeignKey(d => d.Serv01llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LNC02_ServiciosLicencia_SERV01_Servicio");
            });

            modelBuilder.Entity<Lnc03LicenciaContrato>(entity =>
            {
                entity.HasKey(e => new { e.Lnc01llave, e.Ctt01llave }).HasName("PK_LNC03_LicenciaContrato_1");

                entity.ToTable("LNC03_LicenciaContrato");

                entity.HasIndex(e => e.Ctt01llave, "IX_LNC03_LicenciaContrato_CTT01_llave");

                entity.Property(e => e.Lnc01llave).HasColumnName("LNC01_llave");
                entity.Property(e => e.Ctt01llave).HasColumnName("CTT01_llave");
                entity.Property(e => e.Lnc03activo).HasColumnName("LNC03_activo");
                entity.Property(e => e.Lnc03FirmaSimpre).HasColumnName("LNC03_FirmaSimpre");

                entity.HasOne(d => d.Ctt01llaveNavigation).WithMany(p => p.Lnc03LicenciaContratos)
                    .HasForeignKey(d => d.Ctt01llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LNC03_LicenciaContrato_CTT01_Contrato");

                entity.HasOne(d => d.Lnc01llaveNavigation).WithMany(p => p.Lnc03LicenciaContratos)
                    .HasForeignKey(d => d.Lnc01llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LNC03_LicenciaContrato_LNC01_Licencias");
            });

            modelBuilder.Entity<Lnc04TipoLicencia>(entity =>
            {
                entity.HasKey(e => e.Lnc04llave);

                entity.ToTable("LNC04_TipoLicencia");

                entity.Property(e => e.Lnc04llave).HasColumnName("LNC04_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Lnc04activo).HasColumnName("LNC04_activo");
                entity.Property(e => e.Lnc04descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("LNC04_descripcion");
                entity.Property(e => e.Lnc04nombre)
                    .HasMaxLength(250)
                    .HasColumnName("LNC04_nombre");
            });

            modelBuilder.Entity<Lnc05ValorLicencia>(entity =>
            {
                entity.HasKey(e => e.Lnc05llave);

                entity.ToTable("LNC05_valorLicencia");

                entity.HasIndex(e => e.Lnc01llave, "IX_LNC05_valorLicencia_LNC01_llave");

                entity.Property(e => e.Lnc05llave).HasColumnName("LNC05_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.Lnc01llave).HasColumnName("LNC01_llave");
                entity.Property(e => e.Lnc05Inicio).HasColumnName("LNC05_Inicio");
                entity.Property(e => e.Lnc05Termino).HasColumnName("LNC05_Termino");
                entity.Property(e => e.Lnc05Valor).HasColumnName("LNC05_Valor");

                entity.HasOne(d => d.Lnc01llaveNavigation).WithMany(p => p.Lnc05ValorLicencia)
                    .HasForeignKey(d => d.Lnc01llave)
                    .HasConstraintName("FK_LNC05_valorLicencia_LNC01_Licencias");
            });

            modelBuilder.Entity<Lnc06Cobertura>(entity =>
            {
                entity.HasKey(e => new { e.Lnc01llave, e.sist03llave }).HasName("PK_LNC05_Cobertura");

                entity.ToTable("LNC06_Cobertura");

                entity.Property(e => e.Lnc01llave).HasColumnName("LNC01_llave");
                entity.Property(e => e.sist03llave).HasColumnName("SIST03_llave");

                entity.HasOne(d => d.Lnc01llaveNavigation).WithMany(p => p.Lnc06Coberturas)
                    .HasForeignKey(d => d.Lnc01llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LNC06_Cobertura_LNC01_Licencias");
            });

            modelBuilder.Entity<Lnc07Control>(entity =>
            {
                entity.HasKey(e => new { e.Lnc01llave, e.esp03llave });

                entity.ToTable("LNC07_Control");

                entity.Property(e => e.Lnc01llave).HasColumnName("LNC01_llave");
                entity.Property(e => e.esp03llave).HasColumnName("ESP03_llave");

                entity.HasOne(d => d.Lnc01llaveNavigation).WithMany(p => p.Lnc07Controls)
                    .HasForeignKey(d => d.Lnc01llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LNC07_Control_LNC01_Licencias");
            });

            modelBuilder.Entity<Log01Bitacora>(entity =>
            {
                entity.HasKey(e => e.Log01llave);

                entity.ToTable("LOG01_Bitacora");

                entity.HasIndex(e => e.Log03llave, "IX_LOG01_Bitacora_LOG03_llave");

                entity.Property(e => e.Log01llave).HasColumnName("LOG01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Log01activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("LOG01_activo");
                entity.Property(e => e.Log01Clase).HasColumnName("LOG01_Clase");
                entity.Property(e => e.Log01Contenido).HasColumnName("LOG01_Contenido");
                entity.Property(e => e.Log01ElementoSerializado).HasColumnName("LOG01_elemento_serializado");
                entity.Property(e => e.Log01Info).HasColumnName("LOG01_Info");
                entity.Property(e => e.Log01Objeto).HasColumnName("LOG01_objeto");
                entity.Property(e => e.Log03llave).HasColumnName("LOG03_llave");
                entity.Property(e => e.userid).HasColumnName("SECU02_llave");

                entity.HasOne(d => d.Log03llaveNavigation).WithMany(p => p.Log01Bitacoras)
                    .HasForeignKey(d => d.Log03llave)
                    .HasConstraintName("FK_LOG01_Bitacora_LOG03_MensajeBitacora");
            });

            modelBuilder.Entity<Log02TipoBitacora>(entity =>
            {
                entity.HasKey(e => e.Log02llave).HasName("PK__LOG02_Ti__EA456AA523FE4082");

                entity.ToTable("LOG02_TipoBitacora");

                entity.Property(e => e.Log02llave)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("LOG02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Log02activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("LOG02_activo");
                entity.Property(e => e.Log02descripcion).HasColumnName("LOG02_descripcion");
                entity.Property(e => e.Log02EsRazor).HasColumnName("LOG02_EsRazor");
                entity.Property(e => e.Log02Essistema)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("LOG02_Essistema");
                entity.Property(e => e.Log02Info).HasColumnName("LOG02_Info");
                entity.Property(e => e.Log02nombre)
                    .HasMaxLength(300)
                    .HasColumnName("LOG02_nombre");
            });

            modelBuilder.Entity<Log03MensajeBitacora>(entity =>
            {
                entity.HasKey(e => e.Log03llave);

                entity.ToTable("LOG03_MensajeBitacora");

                entity.HasIndex(e => e.Log02llave, "IX_LOG03_MensajeBitacora_LOG02_llave");

                entity.Property(e => e.Log03llave).HasColumnName("LOG03_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Log02llave).HasColumnName("LOG02_llave");
                entity.Property(e => e.Log03AccesoRapido)
                    .HasMaxLength(500)
                    .HasColumnName("LOG03_AccesoRapido");
                entity.Property(e => e.Log03activo).HasColumnName("LOG03_activo");
                entity.Property(e => e.Log03descripcion).HasColumnName("LOG03_descripcion");
                entity.Property(e => e.Log03Info).HasColumnName("LOG03_Info");
                entity.Property(e => e.Log03Mensaje).HasColumnName("LOG03_Mensaje");

                entity.HasOne(d => d.Log02llaveNavigation).WithMany(p => p.Log03MensajeBitacoras)
                    .HasForeignKey(d => d.Log02llave)
                    .HasConstraintName("FK_LOG03_MensajeBitacora_LOG02_TipoBitacora");
            });

            modelBuilder.Entity<Men01sistema>(entity =>
            {
                entity.HasKey(e => e.Men01llave).HasName("PK__MEN01_Si__4F35303B75CD617E");

                entity.ToTable("MEN01_sistema");

                entity.Property(e => e.Men01llave).HasColumnName("MEN01_llave");
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
                entity.Property(e => e.Men01descripcion)
                    .HasMaxLength(2000)
                    .HasColumnName("MEN01_descripcion");
                entity.Property(e => e.Men01IconoUrl).HasColumnName("MEN01_IconoUrl");
                entity.Property(e => e.Men01llavePadre).HasColumnName("MEN01_llave_padre");
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
                entity.HasKey(e => e.mnt01llave);

                entity.ToTable("MNT01_Monitores");

                entity.HasIndex(e => e.mnt04llave, "IX_MNT01_Monitores_MNT04_llave");

                entity.Property(e => e.mnt01llave).HasColumnName("MNT01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.mnt01activo).HasColumnName("MNT01_activo");
                entity.Property(e => e.mnt01Cargo)
                    .HasMaxLength(250)
                    .HasColumnName("MNT01_Cargo");
                entity.Property(e => e.mnt01Iniciolabores)
                    .HasColumnType("datetime")
                    .HasColumnName("MNT01_iniciolabores");
                entity.Property(e => e.mnt04llave).HasColumnName("MNT04_llave");
                entity.Property(e => e.per01llave).HasColumnName("PER01_llave");

                entity.HasOne(d => d.Mnt04llaveNavigation).WithMany(p => p.Mnt01Monitores)
                    .HasForeignKey(d => d.mnt04llave)
                    .HasConstraintName("FK_MNT01_Monitores_MNT04_TipoMonitor");

                entity.HasMany(d => d.esp02llaves).WithMany(p => p.Mnt01llaves)
                    .UsingEntity<Dictionary<string, object>>(
                        "Mnt02especiesAsignada",
                        r => r.HasOne<esp02Temporadaespecie>().WithMany()
                            .HasForeignKey("esp02llave")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_MNT02_especiesAsignadas_ESP02_Temporadaespecie"),
                        l => l.HasOne<Mnt01Monitor>().WithMany()
                            .HasForeignKey("Mnt01llave")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_MNT02_especiesAsignadas_MNT01_Monitores"),
                        j =>
                        {
                            j.HasKey("Mnt01llave", "esp02llave").HasName("PK_MNT02_especiesAsignadas_2");
                            j.ToTable("MNT02_especiesAsignadas");
                            j.HasIndex(new[] { "esp02llave" }, "IX_MNT02_especiesAsignadas_esp02llave");
                        });
            });

            modelBuilder.Entity<Mnt02EspeciesAsignada>(entity =>
            {
                entity.HasKey(e => new { e.mnt01llave, e.esp02llave }).HasName("PK_MNT02_especiesAsignadas");

                entity.ToTable("MNT02_EspeciesAsignadas");

                entity.Property(e => e.mnt01llave).HasColumnName("Mnt01Llave");
                entity.Property(e => e.esp02llave).HasColumnName("Esp02Llave");

                entity.HasIndex(new[] { "esp02llave" }, "IX_MNT02_especiesAsignadas_esp02llave");

                entity.HasOne(d => d.Mnt01llaveNavigation).WithMany(p => p.Mnt02EspeciesAsignadas)
                   .HasForeignKey(d => d.mnt01llave)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_MNT02_especiesAsignadas_MNT01_Monitores");

                entity.HasOne(d => d.esp02llaveNavigation).WithMany(p => p.Mnt02EspeciesAsignadas)
                    .HasForeignKey(d => d.esp02llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MNT02_especiesAsignadas_ESP02_TemporadaBase");


            });


            modelBuilder.Entity<Mnt03periodosTrampa>(entity =>
            {
                entity.HasKey(e => new { e.mnt01llave, e.trp01llave, e.temp02llave }).HasName("PK_MNT02_especiesAsignadas");

                entity.ToTable("MNT03_periodosTrampas");

                entity.HasIndex(e => e.temp02llave, "IX_MNT03_periodosTrampas_TEMP02_llave");

                entity.Property(e => e.mnt01llave).HasColumnName("MNT01_llave");
                entity.Property(e => e.trp01llave).HasColumnName("TRP01_llave");
                entity.Property(e => e.temp02llave).HasColumnName("TEMP02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.mnt03activo).HasColumnName("MNT03_activo");

                entity.HasOne(d => d.Mnt01llaveNavigation).WithMany(p => p.Mnt03periodosTrampas)
                    .HasForeignKey(d => d.mnt01llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MNT03_periodosTrampas_MNT01_Monitores");

                entity.HasOne(d => d.Temp02llaveNavigation).WithMany(p => p.Mnt03periodosTrampas)
                    .HasForeignKey(d => d.temp02llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MNT03_periodosTrampas_TEMP02_TemporadaBase");
            });

            modelBuilder.Entity<Mnt04TipoMonitor>(entity =>
            {
                entity.HasKey(e => e.mnt04llave).HasName("PK_MNT05_TipoBase");

                entity.ToTable("MNT04_TipoMonitor");

                entity.Property(e => e.mnt04llave).HasColumnName("MNT04_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.mnt04activo).HasColumnName("MNT04_activo");
                entity.Property(e => e.mnt04descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("MNT04_descripcion");
                entity.Property(e => e.mnt04nombre)
                    .HasMaxLength(250)
                    .HasColumnName("MNT04_nombre");
            });

            modelBuilder.Entity<Mvl01AccesoMovil>(entity =>
            {

                entity.HasKey(e => new { e.Mvl01llave, e.Mvl01IdUsuario}).HasName("PK_MVL01_AccesoMovil");

                entity.ToTable("MVL01_AccesoMovil");

                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Mvl01DiasUmbralEdicion).HasColumnName("MVL01_dias_umbral_edicion");
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
                entity.Property(e => e.Mvl01llave)
                    .HasMaxLength(1000)
                    .HasColumnName("MVL01_llave");
                entity.Property(e => e.Mvl01MensajeMovil).HasColumnName("MVL01_mensaje_movil");
                entity.Property(e => e.Mvl01NumeroMovil)
                    .HasMaxLength(20)
                    .HasColumnName("MVL01_numero_movil");
                entity.Property(e => e.Mvl01sistemaAndroid)
                    .HasMaxLength(100)
                    .HasColumnName("MVL01_sistema_android");
                entity.Property(e => e.Mvl01TamanoBasedatosCliente).HasColumnName("MVL01_tamano_basedatos_cliente");
                entity.Property(e => e.Mvl01UbicacionActividadX).HasColumnName("MVL01_ubicacion_actividad_x");
                entity.Property(e => e.Mvl01UbicacionActividadY).HasColumnName("MVL01_ubicacion_actividad_y");
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
                entity.Property(e => e.nombreTabla)
                    .HasMaxLength(500)
                    .HasColumnName("nombre_Tabla");
                entity.Property(e => e.userid).HasColumnName("SECU02_llave");
            });

            modelBuilder.Entity<Mvl03RegistroAcceso>(entity =>
            {
                entity.HasKey(e => e.Mvl03llave);

                entity.ToTable("MVL03_RegistroAcceso");

                entity.Property(e => e.Mvl03llave).HasColumnName("MVL03_llave");
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
                entity.Property(e => e.nombreUsuario)
                    .HasMaxLength(500)
                    .HasColumnName("nombre_usuario");
                entity.Property(e => e.Password).HasMaxLength(200);
                entity.Property(e => e.PasswordFormat).HasMaxLength(300);
                entity.Property(e => e.per01llave).HasColumnName("PER01_llave");
                entity.Property(e => e.Secu02activo).HasColumnName("SECU02_activo");
                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<Mvl04AliasTablaSinc>(entity =>
            {
                entity.HasKey(e => e.idtabla);

                entity.ToTable("MVL04_AliasTablaSinc");

                entity.Property(e => e.idtabla).HasColumnName("id_tabla");
                entity.Property(e => e.nombretabla).HasMaxLength(300)
                    .HasColumnName("Nombre_Tabla");

                entity.Property(e => e.mvl04aliastabla).HasColumnName("MVL04_AliasTabla");

            });



            modelBuilder.Entity<Obsc01ObservacionCampo>(entity =>
            {
                entity.HasKey(e => e.Obsc01llave);

                entity.ToTable("OBSC01_ObservacionCampo");

                entity.HasIndex(e => e.esp08llave, "IX_OBSC01_ObservacionCampo_ESP08_llave");

                entity.HasIndex(e => e.Temp02llave, "IX_OBSC01_ObservacionCampo_TEMP02_llave");

                entity.Property(e => e.Obsc01llave).HasColumnName("OBSC01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp08llave).HasColumnName("ESP08_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Obsc01activo).HasColumnName("OBSC01_activo");
                entity.Property(e => e.Obsc01FechaObservacion)
                    .HasColumnType("datetime")
                    .HasColumnName("OBSC01_FechaObservacion");
                entity.Property(e => e.Obsc01Interesado)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("OBSC01_interesado");
                entity.Property(e => e.Obsc01nombre)
                    .HasMaxLength(255)
                    .HasColumnName("OBSC01_nombre");
                entity.Property(e => e.Obsc01Resumen)
                    .HasMaxLength(1000)
                    .IsFixedLength()
                    .HasColumnName("OBSC01_Resumen");
                entity.Property(e => e.Obsc01UrlPdf)
                    .HasMaxLength(1000)
                    .HasColumnName("OBSC01_UrlPdf");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");

                entity.HasOne(d => d.esp08llaveNavigation).WithMany(p => p.Obsc01ObservacionCampos)
                    .HasForeignKey(d => d.esp08llave)
                    .HasConstraintName("FK_OBSC01_ObservacionCampo_ESP08_TipoBase");

                entity.HasOne(d => d.Temp02llaveNavigation).WithMany(p => p.Obsc01ObservacionCampos)
                    .HasForeignKey(d => d.Temp02llave)
                    .HasConstraintName("FK_OBSC01_ObservacionCampo_TEMP02_TemporadaBase");
            });

            modelBuilder.Entity<Obsc02ServicioPostcosecha>(entity =>
            {
                entity.HasKey(e => e.Obsc02llave);

                entity.ToTable("OBSC02_ServicioPostcosecha");

                entity.Property(e => e.Obsc02llave).HasColumnName("OBSC02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp08llave).HasColumnName("ESP08_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Obsc02activo).HasColumnName("OBSC02_activo");
                entity.Property(e => e.Obsc02Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("OBSC02_Fecha");
                entity.Property(e => e.Obsc02nombre)
                    .HasMaxLength(255)
                    .HasColumnName("OBSC02_nombre");
                entity.Property(e => e.Obsc02Resumen).HasColumnName("OBSC02_Resumen");
                entity.Property(e => e.Obsc02UrlPdf)
                    .HasMaxLength(1000)
                    .HasColumnName("OBSC02_UrlPdf");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");
            });

            modelBuilder.Entity<Pbcd01Publicidad>(entity =>
            {
                entity.HasKey(e => e.Pbcd01llave);

                entity.ToTable("PBCD01_Publicidad");

                entity.HasIndex(e => e.Pbcd02llave, "IX_PBCD01_Publicidad_PBCD02_llave");

                entity.Property(e => e.Pbcd01llave).HasColumnName("PBCD01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Pbcd01activo).HasColumnName("PBCD01_activo");
                entity.Property(e => e.Pbcd01FrasePrincipal)
                    .HasMaxLength(500)
                    .HasColumnName("PBCD01_FrasePrincipal");
                entity.Property(e => e.Pbcd01FraseSecundaria)
                    .HasMaxLength(500)
                    .HasColumnName("PBCD01_FraseSecundaria");
                entity.Property(e => e.Pbcd01Imagennombre)
                    .HasMaxLength(500)
                    .HasColumnName("PBCD01_Imagennombre");
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
                entity.Property(e => e.Pbcd02llave).HasColumnName("PBCD02_llave");

                entity.HasOne(d => d.Pbcd02llaveNavigation).WithMany(p => p.Pbcd01Publicidads)
                    .HasForeignKey(d => d.Pbcd02llave)
                    .HasConstraintName("FK_PBCD01_Publicidad_PBCD02_TipoPublicidad");
            });

            modelBuilder.Entity<Pbcd02TipoPublicidad>(entity =>
            {
                entity.HasKey(e => e.Pbcd02llave);

                entity.ToTable("PBCD02_TipoPublicidad");

                entity.Property(e => e.Pbcd02llave).HasColumnName("PBCD02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Pbcd02activo).HasColumnName("PBCD02_activo");
                entity.Property(e => e.Pbcd02descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("PBCD02_descripcion");
                entity.Property(e => e.Pbcd02nombre)
                    .HasMaxLength(250)
                    .HasColumnName("PBCD02_nombre");
            });

            modelBuilder.Entity<Pbcd03Programacion>(entity =>
            {
                entity.HasKey(e => e.Pbcd03llave);

                entity.ToTable("PBCD03_Programacion");

                entity.HasIndex(e => e.Pbcd01llave, "IX_PBCD03_Programacion_PBCD01_llave");

                entity.Property(e => e.Pbcd03llave).HasColumnName("PBCD03_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Pbcd01llave).HasColumnName("PBCD01_llave");
                entity.Property(e => e.Pbcd03activo).HasColumnName("PBCD03_activo");
                entity.Property(e => e.Pbcd03InicioFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("PBCD03_InicioFecha");
                entity.Property(e => e.Pbcd03TerminoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("PBCD03_TerminoFecha");

                entity.HasOne(d => d.Pbcd01llaveNavigation).WithMany(p => p.Pbcd03Programacions)
                    .HasForeignKey(d => d.Pbcd01llave)
                    .HasConstraintName("FK_PBCD03_Programacion_PBCD01_Publicidad");
            });

            modelBuilder.Entity<per01persona>(entity =>
            {
                entity.HasKey(e => e.per01llave);

                entity.ToTable("PER01_persona");

                entity.HasIndex(e => e.per02llave, "IX_PER01_persona_PER02_llave");

                entity.HasIndex(e => e.per03llave, "IX_PER01_persona_PER03_llave");

                entity.HasIndex(e => e.per08llave, "IX_PER01_persona_PER08_llave");

                entity.Property(e => e.per01llave).HasColumnName("PER01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per01activo).HasColumnName("PER01_activo");
                entity.Property(e => e.per01anioingreso).HasColumnName("PER01_AnioIngreso");
                entity.Property(e => e.per01cargo)
                    .HasMaxLength(500)
                    .HasColumnName("PER01_Cargo");
                entity.Property(e => e.per01fechanacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("PER01_FechaNacimiento");
                entity.Property(e => e.per01giro)
                    .HasMaxLength(500)
                    .HasColumnName("PER01_Giro");
                entity.Property(e => e.per01nombrefantasia)
                    .HasMaxLength(500)
                    .HasColumnName("PER01_nombreFantasia");
                entity.Property(e => e.per01nombrerazon)
                    .HasMaxLength(500)
                    .HasColumnName("PER01_nombreRazon");
                entity.Property(e => e.per01rut).HasColumnName("PER01_Rut");
                entity.Property(e => e.per02llave).HasColumnName("PER02_llave");
                entity.Property(e => e.per03llave).HasColumnName("PER03_llave");
                entity.Property(e => e.per08llave).HasColumnName("PER08_llave");

                entity.HasOne(d => d.per02llaveNavigation).WithMany(p => p.per01personas)
                    .HasForeignKey(d => d.per02llave)
                    .HasConstraintName("FK_PER01_persona_PER02_Genero");

                entity.HasOne(d => d.per03llaveNavigation).WithMany(p => p.per01personas)
                    .HasForeignKey(d => d.per03llave)
                    .HasConstraintName("FK_PER01_persona_PER03_Tipopersona");

                entity.HasOne(d => d.per08llaveNavigation).WithMany(p => p.per01personas)
                    .HasForeignKey(d => d.per08llave)
                    .HasConstraintName("FK_PER01_persona_PER08_Tipodocumento");
            });

            modelBuilder.Entity<per02Genero>(entity =>
            {
                entity.HasKey(e => e.per02llave);

                entity.ToTable("PER02_Genero");

                entity.Property(e => e.per02llave).HasColumnName("PER02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per02activo).HasColumnName("PER02_activo");
                entity.Property(e => e.per02orden).HasColumnName("PER02_Orden");
                entity.Property(e => e.per02titulo)
                    .HasMaxLength(50)
                    .HasColumnName("PER02_Titulo");
            });

            modelBuilder.Entity<per03Tipopersona>(entity =>
            {
                entity.HasKey(e => e.per03llave);

                entity.ToTable("PER03_Tipopersona");

                entity.Property(e => e.per03llave).HasColumnName("PER03_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per03activo).HasColumnName("PER03_activo");
                entity.Property(e => e.per03descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("PER03_descripcion");
                entity.Property(e => e.per03nombre)
                    .HasMaxLength(250)
                    .HasColumnName("PER03_nombre");
            });

            modelBuilder.Entity<per04TipoComunicacion>(entity =>
            {
                entity.HasKey(e => e.per04llave);

                entity.ToTable("PER04_TipoComunicacion");

                entity.Property(e => e.per04llave).HasColumnName("PER04_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per04activo).HasColumnName("PER04_activo");
                entity.Property(e => e.per04descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("PER04_descripcion");
                entity.Property(e => e.per04nombre)
                    .HasMaxLength(250)
                    .HasColumnName("PER04_nombre");
            });

            modelBuilder.Entity<per05Comunicacion>(entity =>
            {
                entity.HasKey(e => new { e.per01llave, e.per04llave, e.per03llave });

                entity.ToTable("PER05_Comunicacion");

                entity.HasIndex(e => new { e.per03llave, e.per04llave }, "IX_PER05_Comunicacion_PER03_llave_PER04_llave");

                entity.HasIndex(e => e.per04llave, "IX_PER05_Comunicacion_PER04_llave");

                entity.Property(e => e.per01llave).HasColumnName("PER01_llave");
                entity.Property(e => e.per04llave).HasColumnName("PER04_llave");
                entity.Property(e => e.per03llave).HasColumnName("PER03_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per05casilla)
                    .HasMaxLength(500)
                    .HasColumnName("PER05_casilla");
                entity.Property(e => e.per05celular1)
                    .HasMaxLength(50)
                    .HasColumnName("PER05_Celular1");
                entity.Property(e => e.per05celular2)
                    .HasMaxLength(50)
                    .HasColumnName("PER05_Celular2");
                entity.Property(e => e.per05codigopostal)
                    .HasMaxLength(500)
                    .HasColumnName("PER05_CodigoPostal");
                entity.Property(e => e.per05direccion)
                    .HasMaxLength(500)
                    .HasColumnName("PER05_Direccion");
                entity.Property(e => e.per05email)
                    .HasMaxLength(250)
                    .HasColumnName("PER05_Email");
                entity.Property(e => e.per05fax)
                    .HasMaxLength(50)
                    .HasColumnName("PER05_Fax");
                entity.Property(e => e.per05sitioWeb)
                    .HasMaxLength(50)
                    .HasColumnName("PER05_SitioWeb");
                entity.Property(e => e.per05telefono1)
                    .HasMaxLength(50)
                    .HasColumnName("PER05_Telefono1");
                entity.Property(e => e.per05telefono2)
                    .HasMaxLength(50)
                    .HasColumnName("PER05_Telefono2");
                entity.Property(e => e.per05tienecasilla).HasColumnName("PER05_TieneCasilla");
                entity.Property(e => e.sist03llave).HasColumnName("SIST03_llave");

                entity.HasOne(d => d.per01llaveNavigation).WithMany(p => p.per05Comunicacions)
                    .HasForeignKey(d => d.per01llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PER05_Comunicacion_PER01_persona");

                entity.HasOne(d => d.per03llaveNavigation).WithMany(p => p.per05Comunicacions)
                    .HasForeignKey(d => d.per03llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PER05_Comunicacion_PER03_Tipopersona");

                entity.HasOne(d => d.per04llaveNavigation).WithMany(p => p.per05Comunicacions)
                    .HasForeignKey(d => d.per04llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PER05_Comunicacion_PER04_TipoComunicacion");

                entity.HasOne(d => d.per0).WithMany(p => p.per05Comunicacions)
                    .HasForeignKey(d => new { d.per03llave, d.per04llave })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PER05_Comunicacion_PER06_TipopersonaComunicacion");
            });

            modelBuilder.Entity<per06TipopersonaComunicacion>(entity =>
            {
                entity.HasKey(e => new { e.per03llave, e.per04llave });

                entity.ToTable("PER06_TipopersonaComunicacion");

                entity.HasIndex(e => e.per04llave, "IX_PER06_TipopersonaComunicacion_PER04_llave");

                entity.Property(e => e.per03llave).HasColumnName("PER03_llave");
                entity.Property(e => e.per04llave).HasColumnName("PER04_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");

                entity.HasOne(d => d.per03llaveNavigation).WithMany(p => p.per06TipopersonaComunicacions)
                    .HasForeignKey(d => d.per03llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PER06_TipopersonaComunicacion_PER03_Tipopersona");

                entity.HasOne(d => d.per04llaveNavigation).WithMany(p => p.per06TipopersonaComunicacions)
                    .HasForeignKey(d => d.per04llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PER06_TipopersonaComunicacion_PER04_TipoComunicacion");
            });

            modelBuilder.Entity<per07personaUsuario>(entity =>
            {
                entity.HasKey(e => e.per07llave);

                entity.ToTable("PER07_personaUsuario");

                entity.HasIndex(e => e.per01llave, "IX_PER07_personaUsuario_PER01_llave");

                entity.Property(e => e.per07llave).HasColumnName("PER07_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per01llave).HasColumnName("PER01_llave");
                entity.Property(e => e.per07activo).HasColumnName("PER07_activo");
                entity.Property(e => e.userid)
                    .HasMaxLength(450)
                    .HasColumnName("UserId");

                entity.HasOne(d => d.per01llaveNavigation).WithMany(p => p.per07personaUsuarios)
                    .HasForeignKey(d => d.per01llave)
                    .HasConstraintName("FK_PER07_personaUsuario_PER01_persona");
            });

            modelBuilder.Entity<per08TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.per08llave);

                entity.ToTable("PER08_TipoDocumento");

                entity.Property(e => e.per08llave).HasColumnName("PER08_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.per08activo).HasColumnName("PER08_activo");
                entity.Property(e => e.per08descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("PER08_descripcion");
                entity.Property(e => e.per08nombre)
                    .HasMaxLength(250)
                    .HasColumnName("PER08_nombre");
            });

            modelBuilder.Entity<per09DefaultUser>(entity =>
            {
                entity.HasKey(e => e.per09llave);

                entity.ToTable("PER09_DefaultUser");

                entity.Property(e => e.per09llave).HasColumnName("PER09_llave");
                entity.Property(e => e.per09nombre)
                    .HasMaxLength(250)
                    .HasColumnName("PER09_nombre");
                entity.Property(e => e.plantillaid).HasColumnName("Plantilla_id");
                entity.Property(e => e.rolid)
                    .HasMaxLength(50)
                    .HasColumnName("Rol_id");
                entity.Property(e => e.saludoid).HasColumnName("Saludo_id");
                entity.Property(e => e.tipodocumentoid).HasColumnName("TipoDocumento_id");
                entity.Property(e => e.tipopersonaid).HasColumnName("Tipopersona_id");
            });

            modelBuilder.Entity<Pgo01CompraLicencia>(entity =>
            {
                entity.HasKey(e => e.Pgo1llave);

                entity.ToTable("PGO01_CompraLicencia");

                entity.HasIndex(e => e.cnt19llave, "IX_PGO01_CompraLicencia_CNT19_llave");

                entity.HasIndex(e => e.Pgo03llave, "IX_PGO01_CompraLicencia_PGO03_llave");

                entity.Property(e => e.Pgo1llave).HasColumnName("PGO1_llave");
                entity.Property(e => e.cnt19llave).HasColumnName("CNT19_llave");
                entity.Property(e => e.Fechacompra)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHACOMPRA");
                entity.Property(e => e.Pgo01activo).HasColumnName("PGO01_activo");
                entity.Property(e => e.Pgo01TotalCompra).HasColumnName("PGO01_TotalCompra");
                entity.Property(e => e.Pgo03llave).HasColumnName("PGO03_llave");

                entity.HasOne(d => d.cnt19llaveNavigation).WithMany(p => p.Pgo01CompraLicencia)
                    .HasForeignKey(d => d.cnt19llave)
                    .HasConstraintName("FK_PGO01_CompraLicencia_CNT01_CuentaCliente");

                entity.HasOne(d => d.cnt19llave1).WithMany(p => p.Pgo01CompraLicencia)
                    .HasForeignKey(d => d.cnt19llave)
                    .HasConstraintName("FK_PGO01_CompraLicencia_CNT19_LicenciaCliente");

                entity.HasOne(d => d.Pgo03llaveNavigation).WithMany(p => p.Pgo01CompraLicencia)
                    .HasForeignKey(d => d.Pgo03llave)
                    .HasConstraintName("FK_PGO01_CompraLicencia_PGO03_FormaPago1");
            });

            modelBuilder.Entity<Pgo02NotificarPagoLicencia>(entity =>
            {
                entity.HasKey(e => e.Pgo02llave);

                entity.ToTable("PGO02_NotificarPagoLicencia");

                entity.HasIndex(e => e.Pgo01llave, "IX_PGO02_NotificarPagoLicencia_PGO01_llave");

                entity.Property(e => e.Pgo02llave).HasColumnName("PGO02_llave");
                entity.Property(e => e.Fechanotificacionpago)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHANOTIFICACIONPAGO");
                entity.Property(e => e.Pgo01llave).HasColumnName("PGO01_llave");
                entity.Property(e => e.Pgo02activo).HasColumnName("PGO02_activo");
                entity.Property(e => e.Pgo02DocumentoAdjunto).HasColumnName("PGO02_DocumentoAdjunto");

                entity.HasOne(d => d.Pgo01llaveNavigation).WithMany(p => p.Pgo02NotificarPagoLicencia)
                    .HasForeignKey(d => d.Pgo01llave)
                    .HasConstraintName("FK_PGO02_NotificarPagoLicencia_PGO01_CompraLicencia");
            });

            modelBuilder.Entity<Pgo03TipoPagoLicencia>(entity =>
            {
                entity.HasKey(e => e.Pgo03llave).HasName("PK_PGO03_FormaPago");

                entity.ToTable("PGO03_TipoPagoLicencia");

                entity.Property(e => e.Pgo03llave).HasColumnName("PGO03_llave");
                entity.Property(e => e.Pgo03activo).HasColumnName("PGO03_activo");
                entity.Property(e => e.Pgo03descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("PGO03_descripcion");
                entity.Property(e => e.Pgo03nombre)
                    .HasMaxLength(250)
                    .HasColumnName("PGO03_nombre");
            });

            modelBuilder.Entity<prf01perfil>(entity =>
            {
                entity.HasKey(e => e.prf01llave);

                entity.ToTable("PRF01_perfiles");

                entity.HasIndex(e => e.prf03llave, "IX_PRF01_perfiles_PRF05_llave");

                entity.HasIndex(e => e.userid, "IX_PRF01_perfiles_SECU02_llave");

                entity.Property(e => e.prf01llave).HasColumnName("PRF01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.prf01activo).HasColumnName("PRF01_activo");
                entity.Property(e => e.prf03llave).HasColumnName("PRF03_llave");
                entity.Property(e => e.userid).HasColumnName("UserId");

                entity.HasOne(d => d.prf03llavenavigation).WithMany(p => p.prf01perfiles)
                    .HasForeignKey(d => d.prf03llave)
                    .HasConstraintName("FK_PRF01_perfiles_PRF03_Plantilla");

               /* entity.HasOne(d => d.Usr).WithMany(p => p.prf01perfiles)
                    .HasForeignKey(d => d.userid)
                    .HasConstraintName("FK_PRF01_perfiles_AspNetUsers");*/
            });

            modelBuilder.Entity<prf03Plantilla>(entity =>
            {
                entity.HasKey(e => e.prf03llave).HasName("PK_PRF03_Plantillaperfil");

                entity.ToTable("PRF03_Plantilla");

                entity.Property(e => e.prf03llave).HasColumnName("PRF03_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.prf03activo).HasColumnName("PRF03_activo");
                entity.Property(e => e.prf03descripcion).HasColumnName("PRF03_descripcion");
                entity.Property(e => e.prf03nombre)
                    .HasMaxLength(500)
                    .HasColumnName("PRF03_nombre");
            });

            modelBuilder.Entity<prf04PlantillaFlujo>(entity =>
            {
                entity.HasKey(e => e.prf04llave).HasName("PK_PRF04_plantillaFlujo");

                entity.ToTable("PRF04_PlantillaFlujo");

                entity.Property(e => e.prf04llave).HasColumnName("PRF04_llave");
                entity.Property(e => e.prf03llave).HasColumnName("PRF03_llave");
                entity.Property(e => e.wkf01llave).HasColumnName("WKF01_llave");
            });

            modelBuilder.Entity<prf05TipoAsignacionUsuario>(entity =>
            {
                entity.HasKey(e => e.prf05llave);

                entity.ToTable("PRF05_TipoAsignacionUsuario");

                entity.Property(e => e.prf05llave).HasColumnName("PRF05_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.prf05activo).HasColumnName("PRF05_activo");
                entity.Property(e => e.prf05descripcion).HasColumnName("PRF05_descripcion");
                entity.Property(e => e.prf05nombre)
                    .HasMaxLength(500)
                    .HasColumnName("PRF05_nombre");
            });

            modelBuilder.Entity<prf06permisosUsuario>(entity =>
            {
                entity.HasKey(e => new { e.prf01llave, e.wkf06llave });

                entity.ToTable("PRF06_permisosUsuario");

                entity.HasIndex(e => e.wkf06llave, "IX_PRF06_permisosUsuario_WKF06_llave");

                entity.Property(e => e.prf01llave).HasColumnName("PRF01_llave");
                entity.Property(e => e.wkf06llave).HasColumnName("WKF06_llave");
                entity.Property(e => e.prf06activo).HasColumnName("PRF06_activo");

                entity.HasOne(d => d.wkf06llaveNavigation).WithMany(p => p.prf06permisosUsuarios)
                    .HasForeignKey(d => d.wkf06llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRF06_permisosUsuario_WKF06_perfiles");
            });

            modelBuilder.Entity<Prm01Seguridad>(entity =>
            {
                entity.HasKey(e => e.Prm01llave);

                entity.ToTable("PRM01_Seguridad");

                entity.Property(e => e.Prm01llave).HasColumnName("PRM01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Prm01activo).HasColumnName("PRM01_activo");
                entity.Property(e => e.Prm01descripcion).HasColumnName("PRM01_descripcion");
                entity.Property(e => e.Prm01nombre)
                    .HasMaxLength(500)
                    .HasColumnName("PRM01_nombre");
                entity.Property(e => e.Prm01UrlError)
                    .HasMaxLength(500)
                    .HasColumnName("PRM01_UrlError");
                entity.Property(e => e.Prm01Valor).HasColumnName("PRM01_valor");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.isDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<Secu01Rol>(entity =>
            {
                entity.HasKey(e => e.Secu01llave).HasName("PK__SECU01_R__2E718C9349B338EE");

                entity.ToTable("SECU01_Rol");

                entity.Property(e => e.Secu01llave)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("SECU01_llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Secu01activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU01_activo");
                entity.Property(e => e.Secu01descripcion).HasColumnName("SECU01_descripcion");
                entity.Property(e => e.Secu01Info)
                    .HasColumnType("xml")
                    .HasColumnName("SECU01_Info");
                entity.Property(e => e.Secu01nombre)
                    .HasMaxLength(100)
                    .HasColumnName("SECU01_nombre");
                entity.Property(e => e.Secu01Orden).HasColumnName("SECU01_Orden");
            });

            modelBuilder.Entity<Secu02Usuario>(entity =>
            {
                entity.HasKey(e => e.userid).HasName("PK__SECU02_U__B709E3CA34F4CE22");

                entity.ToTable("SECU02_Usuario");

                entity.HasIndex(e => e.Secu04TipoEncriptacion, "IX_SECU02_Usuario_SECU04_TipoEncriptacion");

                entity.Property(e => e.userid)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("SECU02_llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Secu02activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU02_activo");
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
                entity.HasKey(e => e.Secu03llave).HasName("PK__SECU03_T__7B6F14E7DEC70462");

                entity.ToTable("SECU03_TipoAcceso");

                entity.Property(e => e.Secu03llave)
                    .HasDefaultValueSql("(newsequentialid())")
                    .HasColumnName("SECU03_llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Secu03activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU03_activo");
                entity.Property(e => e.Secu03descripcion).HasColumnName("SECU03_descripcion");
                entity.Property(e => e.Secu03Info)
                    .HasColumnType("xml")
                    .HasColumnName("SECU03_Info");
                entity.Property(e => e.Secu03nombre)
                    .HasMaxLength(300)
                    .HasColumnName("SECU03_nombre");
            });

            modelBuilder.Entity<Secu04TipoEncriptacion>(entity =>
            {
                entity.HasKey(e => e.Secu04llave).HasName("PK__SECU04_T__3412AACF89203574");

                entity.ToTable("SECU04_TipoEncriptacion");

                entity.Property(e => e.Secu04llave)
                    .ValueGeneratedNever()
                    .HasColumnName("SECU04_llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Secu04activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU04_activo");
                entity.Property(e => e.Secu04Clase).HasColumnName("SECU04_Clase");
                entity.Property(e => e.Secu04Funcion).HasColumnName("SECU04_Funcion");
                entity.Property(e => e.Secu04Info)
                    .HasColumnType("xml")
                    .HasColumnName("SECU04_Info");
                entity.Property(e => e.Secu04nombre)
                    .HasMaxLength(200)
                    .HasColumnName("SECU04_nombre");
                entity.Property(e => e.Secu04Parametros)
                    .HasColumnType("xml")
                    .HasColumnName("SECU04_Parametros");
                entity.Property(e => e.Secu04Proyecto).HasColumnName("SECU04_Proyecto");
            });

            modelBuilder.Entity<Secu05UsuarioAcceso>(entity =>
            {
                entity.HasKey(e => e.Secu05llave).HasName("PK__SECU05_U__2980F8C26FA412CE");

                entity.ToTable("SECU05_UsuarioAcceso");

                entity.HasIndex(e => e.userid, "IX_SECU05_UsuarioAcceso_SECU02_llave");

                entity.HasIndex(e => e.Secu03TipoAcceso, "IX_SECU05_UsuarioAcceso_SECU03_TipoAcceso");

                entity.Property(e => e.Secu05llave)
                    .HasDefaultValueSql("(newsequentialid())")
                    .HasColumnName("SECU05_llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.userid).HasColumnName("SECU02_llave");
                entity.Property(e => e.Secu03TipoAcceso).HasColumnName("SECU03_TipoAcceso");
                entity.Property(e => e.Secu05activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU05_activo");
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
                entity.Property(e => e.Secu05llaveAcceso)
                    .HasMaxLength(500)
                    .HasColumnName("SECU05_llaveAcceso");
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

                entity.HasOne(d => d.useridNavigation).WithMany(p => p.Secu05UsuarioAccesos)
                    .HasForeignKey(d => d.userid)
                    .HasConstraintName("FK_SECU05_UsuarioAcceso_SECU02_Usuario");

                entity.HasOne(d => d.Secu03TipoAccesoNavigation).WithMany(p => p.Secu05UsuarioAccesos)
                    .HasForeignKey(d => d.Secu03TipoAcceso)
                    .HasConstraintName("FK_SECU05_UsuarioAcceso_SECU03_TipoAcceso");
            });

            modelBuilder.Entity<Secu06UsuarioRol>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("SECU06_UsuarioRol");

                entity.HasIndex(e => e.userid, "IX_SECU06_UsuarioRol_SECU02_llave");

                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Secu01llave).HasColumnName("SECU01_llave");
                entity.Property(e => e.userid).HasColumnName("SECU02_llave");
                entity.Property(e => e.Secu06activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU06_activo");
                /*
                entity.HasOne(d => d.Secu01LlaveNavigation).WithMany()
                    .HasForeignKey(d => d.Secu01llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SECU06_UsuarioRol_SECU01_Rol");

                entity.HasOne(d => d.useridNavigation).WithMany()
                    .HasForeignKey(d => d.userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SECU06_UsuarioRol_SECU02_Usuario");
                */
            });

            modelBuilder.Entity<Secu07Aplicacion>(entity =>
            {
                entity.HasKey(e => e.Secu07llave).HasName("PK__SECU07_A__148FCE85966FFC87");

                entity.ToTable("SECU07_Aplicacion");

                entity.Property(e => e.Secu07llave)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("SECU07_llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Secu07activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU07_activo");
                entity.Property(e => e.Secu07descripcion).HasColumnName("SECU07_descripcion");
                entity.Property(e => e.Secu07Info)
                    .HasColumnType("xml")
                    .HasColumnName("SECU07_Info");
                entity.Property(e => e.Secu07nombre)
                    .HasMaxLength(100)
                    .HasColumnName("SECU07_nombre");
            });

            modelBuilder.Entity<Secu08UsuarioAplicacion>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("SECU08_UsuarioAplicacion");

                entity.HasIndex(e => e.Secu07llave, "IX_SECU08_UsuarioAplicacion_SECU07_llave");

                entity.Property(e => e.fechaactualizacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.userid)
                    .HasMaxLength(450)
                    .HasColumnName("SECU02_llave");
                entity.Property(e => e.Secu07llave).HasColumnName("SECU07_llave");
                entity.Property(e => e.Secu08activo)
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("SECU08_activo");
                entity.Property(e => e.Secu08Info)
                    .HasColumnType("xml")
                    .HasColumnName("SECU08_Info");
                entity.Property(e => e.Secu08Observacion).HasColumnName("SECU08_Observacion");

                entity.HasOne(d => d.useridNavigation).WithMany()
                    .HasForeignKey(d => d.userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioAplicacion_Usuario");

                entity.HasOne(d => d.Secu07llaveNavigation).WithMany()
                    .HasForeignKey(d => d.Secu07llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioAplicacion_Aplicacion");
            });

            modelBuilder.Entity<Secu10Accesopermitido>(entity =>
            {
                entity.HasKey(e => e.Secu10llave);

                entity.ToTable("SECU10_Accesopermitido");

                entity.HasIndex(e => e.userid, "IX_SECU10_Accesopermitido_SECU02_llave");

                entity.HasIndex(e => e.Secu03llave, "IX_SECU10_Accesopermitido_SECU03_llave");

                entity.Property(e => e.Secu10llave).HasColumnName("SECU10_llave");
                entity.Property(e => e.activo).HasColumnName("activo");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.userid).HasColumnName("SECU02_llave");
                entity.Property(e => e.Secu03llave).HasColumnName("SECU03_llave");

                entity.HasOne(d => d.useridNavigation).WithMany(p => p.Secu10Accesopermitidos)
                    .HasForeignKey(d => d.userid)
                    .HasConstraintName("FK_SECU10_Accesopermitido_SECU02_Usuario");

                entity.HasOne(d => d.Secu03llaveNavigation).WithMany(p => p.Secu10Accesopermitidos)
                    .HasForeignKey(d => d.Secu03llave)
                    .HasConstraintName("FK_SECU10_Accesopermitido_SECU03_TipoAcceso");
            });

            modelBuilder.Entity<Secu11Tipoperfil>(entity =>
            {
                entity.HasKey(e => e.prf02llave);

                entity.ToTable("SECU11_Tipoperfil");

                entity.Property(e => e.prf02llave).HasColumnName("PRF02_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.Fechaactulizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTULIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.prf02descripcion)
                    .HasMaxLength(2000)
                    .HasColumnName("PRF02_descripcion");
                entity.Property(e => e.prf02nombre)
                    .HasMaxLength(500)
                    .HasColumnName("PRF02_nombre");
            });

            modelBuilder.Entity<Sercl01ServiciosCliente>(entity =>
            {
                entity.HasKey(e => e.Sercl01llave);

                entity.ToTable("SERCL01_ServiciosClientes");

                entity.Property(e => e.Sercl01llave).HasColumnName("SERCL01_llave");
                entity.Property(e => e.cnt01llave).HasColumnName("CNT01_llave");
                entity.Property(e => e.cnt08llave).HasColumnName("CNT08_llave");
                entity.Property(e => e.cnt19llave).HasColumnName("CNT19_llave");
                entity.Property(e => e.Conteo03llave).HasColumnName("CONTEO03_llave");
                entity.Property(e => e.esp03llave).HasColumnName("ESP03_llave");
                entity.Property(e => e.esp04llave).HasColumnName("ESP04_llave");
                entity.Property(e => e.esp08llave).HasColumnName("ESP08_llave");
                entity.Property(e => e.Sercl01Cantidad).HasColumnName("SERCL01_cantidad");
                entity.Property(e => e.Sercl01Costo).HasColumnName("SERCL01_Costo");
                entity.Property(e => e.Sercl01TipoGrafico).HasColumnName("SERCL01_TipoGrafico");
                entity.Property(e => e.Serv01llave).HasColumnName("SERV01_llave");
                entity.Property(e => e.sist03llave).HasColumnName("SIST03_llave");
                entity.Property(e => e.sist04llave).HasColumnName("SISt04_llave");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");
            });

            modelBuilder.Entity<Sercl02MuestreoFruta>(entity =>
            {
                entity.HasKey(e => e.Sercl02llave);

                entity.ToTable("SERCL02_MuestreoFruta");

                entity.HasIndex(e => e.Sercl01llave, "IX_SERCL02_MuestreoFruta_SERCL01_llave");

                entity.Property(e => e.Sercl02llave).HasColumnName("SERCL02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Sercl01llave).HasColumnName("SERCL01_llave");
                entity.Property(e => e.Sercl02activo).HasColumnName("SERCL02_activo");
                entity.Property(e => e.Sercl02Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("SERCL02_Fecha");
                entity.Property(e => e.Sercl02nombre)
                    .HasMaxLength(500)
                    .HasColumnName("SERCL02_nombre");
                entity.Property(e => e.Sercl02UrlPdf)
                    .HasMaxLength(1000)
                    .HasColumnName("SERCL02_UrlPdf");

                entity.HasOne(d => d.Sercl01llaveNavigation).WithMany(p => p.Sercl02MuestreoFruta)
                    .HasForeignKey(d => d.Sercl01llave)
                    .HasConstraintName("FK_SERCL02_MuestreoFruta_SERCL01_ServiciosClientes");
            });

            modelBuilder.Entity<Sercltemp01ServiciosClientesTemporal>(entity =>
            {
                entity.HasKey(e => e.Sercltemp01llave);

                entity.ToTable("SERCLTEMP01_ServiciosClientes_Temporal");

                entity.HasIndex(e => e.Conteo03llave, "IX_SERCLTEMP01_ServiciosClientes_Temporal_CONTEO03_llave");

                entity.Property(e => e.Sercltemp01llave).HasColumnName("SERCLTEMP01_llave");
                entity.Property(e => e.cntemp01llave).HasColumnName("CNTEMP01_llave");
                entity.Property(e => e.cntemp02llave).HasColumnName("CNTEMP02_llave");
                entity.Property(e => e.Conteo03llave).HasColumnName("CONTEO03_llave");
                entity.Property(e => e.Sercltemp01TipoGrafico).HasColumnName("SERCLTEMP01_TipoGrafico");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");

                entity.HasOne(d => d.Conteo03llaveNavigation).WithMany(p => p.Sercltemp01ServiciosClientesTemporals)
                    .HasForeignKey(d => d.Conteo03llave)
                    .HasConstraintName("FK_SERCLTEMP01_ServiciosClientes_Temporal_CONTEO03_Resumen");
            });

            modelBuilder.Entity<Serv01Servicio>(entity =>
            {
                entity.HasKey(e => e.Serv01llave);

                entity.ToTable("SERV01_Servicio");

                entity.HasIndex(e => e.Serv02llave, "IX_SERV01_Servicio_SERV02_llave");

                entity.Property(e => e.Serv01llave).HasColumnName("SERV01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Serv01activo).HasColumnName("SERV01_activo");
                entity.Property(e => e.Serv01descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("SERV01_descripcion");
                entity.Property(e => e.Serv01nombre)
                    .HasMaxLength(250)
                    .HasColumnName("SERV01_nombre");
                entity.Property(e => e.Serv02llave).HasColumnName("SERV02_llave");

                entity.HasOne(d => d.Serv02llaveNavigation).WithMany(p => p.Serv01Servicios)
                    .HasForeignKey(d => d.Serv02llave)
                    .HasConstraintName("FK_SERV01_Servicio_SERV02_TipoServicio");
            });

            modelBuilder.Entity<Serv02TipoServicio>(entity =>
            {
                entity.HasKey(e => e.Serv02llave);

                entity.ToTable("SERV02_TipoServicio");

                entity.Property(e => e.Serv02llave).HasColumnName("SERV02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Serv02activo).HasColumnName("SERV02_activo");
                entity.Property(e => e.Serv02descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("SERV02_descripcion");
                entity.Property(e => e.Serv02nombre)
                    .HasMaxLength(50)
                    .HasColumnName("SERV02_nombre");
            });

            modelBuilder.Entity<setSelect>(entity =>
            {
                entity.HasKey(e => e.Value);
            });

            modelBuilder.Entity<sist01sistema>(entity =>
            {
                entity.HasKey(e => e.sist01llave);

                entity.ToTable("SIST01_sistema");

                entity.Property(e => e.sist01llave).HasColumnName("SIST01_llave");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.sist01activo).HasColumnName("SIST01_activo");
                entity.Property(e => e.sist01descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("SIST01_descripcion");
                entity.Property(e => e.sist01EsPublica).HasColumnName("SIST01_EsPublica");
                entity.Property(e => e.sist01EsServicios).HasColumnName("SIST01_EsServicios");
                entity.Property(e => e.sist01nombre)
                    .HasMaxLength(250)
                    .HasColumnName("SIST01_nombre");
            });

            modelBuilder.Entity<sist02Zona>(entity =>
            {
                entity.HasKey(e => e.sist02llave);

                entity.ToTable("SIST02_Zona");

                entity.Property(e => e.sist02llave).HasColumnName("SIST02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.sist02activo).HasColumnName("SIST02_activo");
                entity.Property(e => e.sist02descripcion).HasColumnName("SIST02_descripcion");
                entity.Property(e => e.sist02estadoregistro)
                    .HasMaxLength(50)
                    .HasColumnName("SIST02_estadoregistro");
                entity.Property(e => e.sist02nombre)
                    .HasMaxLength(500)
                    .HasColumnName("SIST02_nombre");

                entity.HasMany(d => d.sist03llaves).WithMany(p => p.sist02llaves)
                    .UsingEntity<Dictionary<string, object>>(
                        "sist07ZonaComuna",
                        r => r.HasOne<sist03Comuna>().WithMany()
                            .HasForeignKey("sist03llave")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_SIST07_ZonaComuna_SIST03_Comuna"),
                        l => l.HasOne<sist02Zona>().WithMany()
                            .HasForeignKey("sist02llave")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_SIST07_ZonaComuna_SIST02_Zona"),
                        j =>
                        {
                            j.HasKey("sist02llave", "sist03llave");
                            j.ToTable("SIST07_ZonaComuna");
                            j.HasIndex(new[] { "sist03llave" }, "IX_SIST07_ZonaComuna_sist03llave");
                        });
            });

            modelBuilder.Entity<sist03Comuna>(entity =>
            {
                entity.HasKey(e => e.sist03llave);

                entity.ToTable("SIST03_Comuna");

                entity.HasIndex(e => e.sist04llave, "IX_SIST03_Comuna_SIST04_llave");

                entity.Property(e => e.sist03llave).HasColumnName("SIST03_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.sist03activo).HasColumnName("SIST03_activo");
                entity.Property(e => e.sist03capital).HasColumnName("SIST03_Capital");
                entity.Property(e => e.sist03descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("SIST03_descripcion");
                entity.Property(e => e.sist03nombre)
                    .HasMaxLength(250)
                    .HasColumnName("SIST03_nombre");
                entity.Property(e => e.sist04llave).HasColumnName("SIST04_llave");

                entity.HasOne(d => d.sist04llaveNavigation).WithMany(p => p.sist03Comunas)
                    .HasForeignKey(d => d.sist04llave)
                    .HasConstraintName("FK_SIST03_Comuna_SIST04_Region");
            });

            modelBuilder.Entity<sist04Region>(entity =>
            {
                entity.HasKey(e => e.sist04llave);

                entity.ToTable("SIST04_Region");

                entity.Property(e => e.sist04llave).HasColumnName("SIST04_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.sist04activo).HasColumnName("SIST04_activo");
                entity.Property(e => e.sist04descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("SIST04_descripcion");
                entity.Property(e => e.sist04nombre)
                    .HasMaxLength(250)
                    .HasColumnName("SIST04_nombre");
                entity.Property(e => e.sist04orden).HasColumnName("SIST04_Orden");
            });

            modelBuilder.Entity<sist05EstadoRegistro>(entity =>
            {
                entity.HasKey(e => e.sist05llave);

                entity.ToTable("SIST05_EstadoRegistro");

                entity.Property(e => e.sist05llave).HasColumnName("SIST05_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.sist03activo).HasColumnName("SIST03_activo");
                entity.Property(e => e.sist03descripcion).HasColumnName("SIST03_descripcion");
                entity.Property(e => e.sist05nombre)
                    .HasMaxLength(500)
                    .HasColumnName("SIST05_nombre");
            });

            modelBuilder.Entity<sist06EstadoGrid>(entity =>
            {
                entity.HasKey(e => e.sist06llave);

                entity.ToTable("SIST06_EstadoGrid");

                entity.Property(e => e.sist06llave).HasColumnName("SIST06_llave");
                entity.Property(e => e.sist06activo).HasColumnName("SIST06_activo");
                entity.Property(e => e.sist06nombre)
                    .HasMaxLength(50)
                    .HasColumnName("SIST06_nombre");
            });

            modelBuilder.Entity<sist08ContactoUsuario>(entity =>
            {
                entity.HasKey(e => e.sist08llave);

                entity.ToTable("SIST08_ContactoUsuario");

                entity.HasIndex(e => e.per02llave, "IX_SIST08_ContactoUsuario_PER02_llave");

                entity.Property(e => e.sist08llave).HasColumnName("SIST08_llave");
                entity.Property(e => e.per02llave).HasColumnName("PER02_llave");
                entity.Property(e => e.sist08Celular)
                    .HasMaxLength(15)
                    .HasColumnName("SIST08_Celular");
                entity.Property(e => e.sist08Comentario).HasColumnName("SIST08_Comentario");
                entity.Property(e => e.sist08Correo)
                    .HasMaxLength(50)
                    .HasColumnName("SIST08_Correo");
                entity.Property(e => e.sist08Empresa)
                    .HasMaxLength(250)
                    .HasColumnName("SIST08_Empresa");
                entity.Property(e => e.sist08Estado).HasColumnName("SIST08_Estado");
                entity.Property(e => e.sist08Fechacreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("SIST08_FECHACREACION");
                entity.Property(e => e.sist08nombre)
                    .HasMaxLength(250)
                    .HasColumnName("SIST08_nombre");
                entity.Property(e => e.sist08Telefono)
                    .HasMaxLength(15)
                    .HasColumnName("SIST08_Telefono");

                entity.HasOne(d => d.per02llaveNavigation).WithMany(p => p.sist08ContactoUsuarios)
                    .HasForeignKey(d => d.per02llave)
                    .HasConstraintName("FK_SIST08_ContactoUsuario_PER02_Genero");
            });

            modelBuilder.Entity<Temp01Temporada>(entity =>
            {
                entity.HasKey(e => e.temp01llave);

                entity.ToTable("TEMP01_Temporada");

                entity.HasIndex(e => e.temp02llave, "IX_TEMP01_Temporada_TEMP02_llave");

                entity.HasIndex(e => e.temp03llave, "IX_TEMP01_Temporada_TEMP03_llave");

                entity.Property(e => e.temp01llave).HasColumnName("TEMP01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.temp01activo).HasColumnName("TEMP01_activo");
                entity.Property(e => e.temp01descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("TEMP01_descripcion");
                entity.Property(e => e.temp01maxfecha)
                    .HasColumnType("datetime")
                    .HasColumnName("TEMP01_MaxFecha");
                entity.Property(e => e.temp01maxmes).HasColumnName("TEMP01_MaxMes");
                entity.Property(e => e.temp01minfecha)
                    .HasColumnType("datetime")
                    .HasColumnName("TEMP01_MinFecha");
                entity.Property(e => e.temp01minmes).HasColumnName("TEMP01_MinMes");
                entity.Property(e => e.temp01nombre)
                    .HasMaxLength(250)
                    .HasColumnName("TEMP01_nombre");
                entity.Property(e => e.temp01periodo).HasColumnName("TEMP01_periodo");
                entity.Property(e => e.temp02llave).HasColumnName("TEMP02_llave");
                entity.Property(e => e.temp03llave).HasColumnName("TEMP03_llave");

                entity.HasOne(d => d.Temp02llaveNavigation).WithMany(p => p.Temp01Temporada)
                    .HasForeignKey(d => d.temp02llave)
                    .HasConstraintName("FK_TEMP01_Temporada_TEMP02_TemporadaBase");

                entity.HasOne(d => d.Temp03llaveNavigation).WithMany(p => p.Temp01Temporada)
                    .HasForeignKey(d => d.temp03llave)
                    .HasConstraintName("FK_TEMP01_Temporada_TEMP03_Segmentacion");
            });

            modelBuilder.Entity<Temp02TemporadaBase>(entity =>
            {
                entity.HasKey(e => e.temp02llave);

                entity.ToTable("TEMP02_TemporadaBase");

                entity.Property(e => e.temp02llave).HasColumnName("TEMP02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.temp02activo).HasColumnName("TEMP02_activo");
                entity.Property(e => e.temp02descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("TEMP02_descripcion");
                entity.Property(e => e.temp02nombre)
                    .HasMaxLength(250)
                    .HasColumnName("TEMP02_nombre");
                entity.Property(e => e.temp02predeterminada).HasColumnName("TEMP02_Predeterminada");
            });

            modelBuilder.Entity<Temp03Segmentacion>(entity =>
            {
                entity.HasKey(e => e.temp03llave);

                entity.ToTable("TEMP03_Segmentacion");

                entity.Property(e => e.temp03llave).HasColumnName("TEMP03_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.temp03activo).HasColumnName("TEMP03_activo");
                entity.Property(e => e.temp03descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("TEMP03_descripcion");
                entity.Property(e => e.temp03nombre)
                    .HasMaxLength(250)
                    .HasColumnName("TEMP03_nombre");
                entity.Property(e => e.temp03numeromeses).HasColumnName("TEMP03_NumeroMeses");
                entity.Property(e => e.temp03numerosegmentostotal).HasColumnName("TEMP03_NumeroSegmentosTotal");
            });

            modelBuilder.Entity<Trp01Trampa>(entity =>
            {
                entity.HasKey(e => e.Trp01llave);

                entity.ToTable("TRP01_Trampa");

                entity.HasIndex(e => e.cnt08llave, "IX_TRP01_Trampa_CNT08_llave");

                entity.HasIndex(e => e.esp01llave, "IX_TRP01_Trampa_ESP01_llave");

                entity.Property(e => e.Trp01llave).HasColumnName("TRP01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.cnt08llave).HasColumnName("CNT08_llave");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.esp01llave).HasColumnName("ESP01_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Trp01activo).HasColumnName("TRP01_activo");
                entity.Property(e => e.Trp01nombre)
                    .HasMaxLength(250)
                    .HasColumnName("TRP01_nombre");
                entity.Property(e => e.Trp01Numero).HasColumnName("TRP01_Numero");

                entity.HasOne(d => d.cnt08llaveNavigation).WithMany(p => p.Trp01Trampas)
                    .HasForeignKey(d => d.cnt08llave)
                    .HasConstraintName("FK_TRP01_Trampa_CNT08_Segmentacion");

                entity.HasOne(d => d.esp01llaveNavigation).WithMany(p => p.Trp01Trampas)
                    .HasForeignKey(d => d.esp01llave)
                    .HasConstraintName("FK_TRP01_Trampa_ESP01_especies");
            });

            modelBuilder.Entity<Trp02Temporada>(entity =>
            {
                entity.HasKey(e => e.Trp02llave);

                entity.ToTable("TRP02_Temporada");

                entity.HasIndex(e => e.Temp02llave, "IX_TRP02_Temporada_TEMP02_llave");

                entity.HasIndex(e => e.Trp01llave, "IX_TRP02_Temporada_TRP01_llave");

                entity.Property(e => e.Trp02llave).HasColumnName("TRP02_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.Temp02activo).HasColumnName("TEMP02_activo");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");
                entity.Property(e => e.Trp01llave).HasColumnName("TRP01_llave");

                entity.HasOne(d => d.Temp02llaveNavigation).WithMany(p => p.Trp02Temporada)
                    .HasForeignKey(d => d.Temp02llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRP02_Temporada_TEMP02_TemporadaBase");

                entity.HasOne(d => d.Trp01llaveNavigation).WithMany(p => p.Trp02Temporada)
                    .HasForeignKey(d => d.Trp01llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRP02_Temporada_TRP01_Trampa");
            });

            modelBuilder.Entity<Trp03Geocordenada>(entity =>
            {
                entity.HasKey(e => new { e.Trp01llave, e.Temp02llave });

                entity.ToTable("TRP03_geocordenadas");

                entity.Property(e => e.Trp01llave).HasColumnName("TRP01_llave");
                entity.Property(e => e.Temp02llave).HasColumnName("TEMP02_llave");
                entity.Property(e => e.X)
                    .HasMaxLength(50)
                    .HasColumnName("x");
                entity.Property(e => e.Y)
                    .HasMaxLength(50)
                    .HasColumnName("y");
            });

            modelBuilder.Entity<wkf01Flujo>(entity =>
            {
                entity.HasKey(e => e.wkf01llave);

                entity.ToTable("WKF01_Flujo");

                entity.HasIndex(e => e.wkf03llave, "IX_WKF01_Flujo_WKF03_llave");

                entity.Property(e => e.wkf01llave).HasColumnName("WKF01_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.wkf01activo).HasColumnName("WKF01_activo");
                entity.Property(e => e.wkf01descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("WKF01_descripcion");
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
                entity.Property(e => e.wkf01llavepadre).HasColumnName("WKF01_llavePadre");
                entity.Property(e => e.wkf01nombre)
                    .HasMaxLength(250)
                    .HasColumnName("WKF01_nombre");
                entity.Property(e => e.wkf01orden).HasColumnName("WKF01_Orden");
                entity.Property(e => e.wkf01prioridad).HasColumnName("WKF01_Prioridad");
                entity.Property(e => e.wkf01url).HasColumnName("WKF01_url");
                entity.Property(e => e.wkf01visiblemenu).HasColumnName("WKF01_visibleMenu");
                entity.Property(e => e.wkf03llave).HasColumnName("WKF03_llave");

                entity.HasOne(d => d.wkf03llaveNavigation).WithMany(p => p.wkf01Flujos)
                    .HasForeignKey(d => d.wkf03llave)
                    .HasConstraintName("FK_WKF01_Flujo_WKF03_Nivel");
            });

            modelBuilder.Entity<wkf02TipoFlujo>(entity =>
            {
                entity.HasKey(e => e.wkf02llave);

                entity.ToTable("WKF02_TipoFlujo");

                entity.Property(e => e.wkf02llave).HasColumnName("WKF02_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.wkf02activo).HasColumnName("WKF02_activo");
                entity.Property(e => e.wkf02descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("WKF02_descripcion");
                entity.Property(e => e.wkf02nombre)
                    .HasMaxLength(250)
                    .HasColumnName("WKF02_nombre");
                entity.Property(e => e.wkf02orden).HasColumnName("WKF02_orden");
            });

            modelBuilder.Entity<wkf03Nivel>(entity =>
            {
                entity.HasKey(e => e.wkf03llave);

                entity.ToTable("WKF03_Nivel");

                entity.HasIndex(e => e.wkf02llave, "IX_WKF03_Nivel_WKF02_llave");

                entity.Property(e => e.wkf03llave).HasColumnName("WKF03_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.wkf02llave).HasColumnName("WKF02_llave");
                entity.Property(e => e.wkf03activo).HasColumnName("WKF03_activo");
                entity.Property(e => e.wkf03descripcion).HasColumnName("WKF03_descripcion");
                entity.Property(e => e.wkf03nivel1).HasColumnName("WKF03_Nivel");
                entity.Property(e => e.wkf03nombre)
                    .HasMaxLength(250)
                    .HasColumnName("WKF03_nombre");

                entity.HasOne(d => d.wkf02llaveNavigation).WithMany(p => p.wkf03Nivels)
                    .HasForeignKey(d => d.wkf02llave)
                    .HasConstraintName("FK_WKF03_Nivel_WKF02_TipoFlujo");
            });

            modelBuilder.Entity<wkf04Nivelpermiso>(entity =>
            {
                entity.HasKey(e => e.wkf04llave).HasName("PK_WKF04_NivelPremiso");

                entity.ToTable("WKF04_Nivelpermiso");

                entity.HasIndex(e => e.wkf03llave, "IX_WKF04_Nivelpermiso_WKF03_llave");

                entity.HasIndex(e => e.wkf05llave, "IX_WKF04_Nivelpermiso_WKF05_llave");

                entity.Property(e => e.wkf04llave).HasColumnName("WKF04_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.wkf03llave).HasColumnName("WKF03_llave");
                entity.Property(e => e.wkf04activo).HasColumnName("WKF04_activo");
                entity.Property(e => e.wkf05llave).HasColumnName("WKF05_llave");

                entity.HasOne(d => d.wkf03llaveNavigation).WithMany(p => p.wkf04Nivelpermisos)
                    .HasForeignKey(d => d.wkf03llave)
                    .HasConstraintName("FK_WKF04_Nivelpermiso_WKF03_Nivel");

                entity.HasOne(d => d.wkf05llaveNavigation).WithMany(p => p.wkf04Nivelpermisos)
                    .HasForeignKey(d => d.wkf05llave)
                    .HasConstraintName("FK_WKF04_Nivelpermiso_WKF05_Tipopermiso");
            });

            modelBuilder.Entity<wkf05Tipopermiso>(entity =>
            {
                entity.HasKey(e => e.wkf05llave).HasName("PK_WKF05_Tipoperfil");

                entity.ToTable("WKF05_Tipopermiso");

                entity.Property(e => e.wkf05llave).HasColumnName("WKF05_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.wkf05activo).HasColumnName("WKF05_activo");
                entity.Property(e => e.wkf05descripcion).HasColumnName("WKF05_descripcion");
                entity.Property(e => e.wkf05nombre)
                    .HasMaxLength(500)
                    .HasColumnName("WKF05_nombre");
                entity.Property(e => e.wkf05sigla)
                    .HasMaxLength(2)
                    .HasColumnName("WKF05_sigla");
            });

            modelBuilder.Entity<wkf06perfil>(entity =>
            {
                entity.HasKey(e => e.wkf06llave);

                entity.ToTable("WKF06_perfiles");

                entity.HasIndex(e => e.wkf01llave, "IX_WKF06_perfiles_WKF01_llave");

                entity.Property(e => e.wkf06llave).HasColumnName("WKF06_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.wkf01llave).HasColumnName("WKF01_llave");
                entity.Property(e => e.wkf06activo).HasColumnName("WKF06_activo");
                entity.Property(e => e.wkf06descripcion).HasColumnName("WKF06_descripcion");
                entity.Property(e => e.wkf06nombre)
                    .HasMaxLength(500)
                    .HasColumnName("WKF06_nombre");

                entity.HasOne(d => d.wkf01llaveNavigation).WithMany(p => p.wkf06perfiles)
                    .HasForeignKey(d => d.wkf01llave)
                    .HasConstraintName("FK_WKF06_perfiles_WKF01_Flujo");
            });

            modelBuilder.Entity<wkf07perfilespermiso>(entity =>
            {
                entity.HasKey(e => new { e.wkf06llave, e.wkf05llave });

                entity.ToTable("WKF07_perfilespermiso");

                entity.HasIndex(e => e.wkf05llave, "IX_WKF07_perfilespermiso_WKF05_llave");

                entity.Property(e => e.wkf06llave).HasColumnName("WKF06_llave");
                entity.Property(e => e.wkf05llave).HasColumnName("WKF05_llave");
                entity.Property(e => e.wkf07activo).HasColumnName("WKF07_activo");

                entity.HasOne(d => d.wkf05llaveNavigation).WithMany(p => p.wkf07perfilespermisos)
                    .HasForeignKey(d => d.wkf05llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WKF07_perfilespermiso_WKF05_Tipopermiso");

                entity.HasOne(d => d.wkf06llaveNavigation).WithMany(p => p.wkf07perfilespermisos)
                    .HasForeignKey(d => d.wkf06llave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WKF07_perfilespermiso_WKF06_perfiles");
            });

            modelBuilder.Entity<wkf08Area>(entity =>
            {
                entity.HasKey(e => e.wfk08llave).HasName("PK_wfk08_Area");

                entity.ToTable("WKF08_Area");

                entity.Property(e => e.wfk08llave).HasColumnName("wfk08_llave");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.wfk08activo).HasColumnName("wfk08_activo");
                entity.Property(e => e.wfk08descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("wfk08_descripcion");
                entity.Property(e => e.wfk08nombre)
                    .HasMaxLength(50)
                    .HasColumnName("wfk08_nombre");
            });

            modelBuilder.Entity<wkf09Parametro>(entity =>
            {
                entity.HasKey(e => e.wkf09llave);

                entity.ToTable("WKF09_Parametro");

                entity.HasIndex(e => e.wkf01llave, "IX_WKF09_Parametro_WKF01_llave");

                entity.HasIndex(e => e.wkf10llave, "IX_WKF09_Parametro_WKF10_llave");

                entity.Property(e => e.wkf09llave).HasColumnName("WKF09_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.wkf01llave).HasColumnName("WKF01_llave");
                entity.Property(e => e.wkf09activo).HasColumnName("WKF09_activo");
                entity.Property(e => e.wkf09valor)
                    .HasMaxLength(500)
                    .HasColumnName("WKF09_Valor");
                entity.Property(e => e.wkf09variable)
                    .HasMaxLength(500)
                    .HasColumnName("WKF09_Variable");
                entity.Property(e => e.wkf10llave).HasColumnName("WKF10_llave");

                entity.HasOne(d => d.wkf01llaveNavigation).WithMany(p => p.wkf09Parametros)
                    .HasForeignKey(d => d.wkf01llave)
                    .HasConstraintName("FK_WKF09_Parametro_WKF01_Flujo");

                entity.HasOne(d => d.wkf10llaveNavigation).WithMany(p => p.wkf09Parametros)
                    .HasForeignKey(d => d.wkf10llave)
                    .HasConstraintName("FK_WKF09_Parametro_WKF10_TipoParametro");
            });

            modelBuilder.Entity<wkf10TipoParametro>(entity =>
            {
                entity.HasKey(e => e.wkf10llave);

                entity.ToTable("WKF10_TipoParametro");

                entity.Property(e => e.wkf10llave).HasColumnName("WKF10_llave");
                entity.Property(e => e.approveby).HasColumnName("APPROVE_BY");
                entity.Property(e => e.createby).HasColumnName("CREATE_BY");
                entity.Property(e => e.deleteby).HasColumnName("DELETE_BY");
                entity.Property(e => e.fechaactivacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTIVACION");
                entity.Property(e => e.fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAACTUALIZACION");
                entity.Property(e => e.fechaeliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAELIMINACION");
                entity.Property(e => e.wkf10activo).HasColumnName("WKF10_activo");
                entity.Property(e => e.wkf10descripcion).HasColumnName("WKF10_descripcion");
                entity.Property(e => e.wkf10nombre)
                    .HasMaxLength(500)
                    .HasColumnName("WKF10_nombre");
            });

            modelBuilder.Entity<Zona>(entity =>
            {
                entity.Property(e => e.isDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<MonitorTrampaBuscarResponseDto>().HasNoKey();

            modelBuilder.Entity<MovilAccesoResponseDto>().HasNoKey();

            modelBuilder.Entity<MovilPeriodoResponseDto>().HasNoKey();

            modelBuilder.Entity<MovilControlReservaResponseDto>().HasNoKey();

            modelBuilder.Entity<ClienteEstacionActivaResponseDto>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<UsuarioRegistroResponseDto> UsuarioRegistros { get; set; }

        public DbSet<Inmueble>? Inmuebles { get; set; }

        public DbSet<Region>? Regiones{ get; set; }   
        
        public DbSet<Comuna>? Comunas{ get; set; }

        public DbSet<Zona>? Zonas { get; set; }

        public virtual DbSet<Blk01Bloqueo>? Blk01Bloqueos { get; set; }

        public virtual DbSet<Blk02TipoBloqueo>? Blk02TipoBloqueos { get; set; }

        public virtual DbSet<Blk03BloqueoUsuario>? Blk03BloqueoUsuarios { get; set; }

        public virtual DbSet<Clbr01Calibracion>? Clbr01Calibraciones { get; set; }

        public virtual DbSet<Clbr02TipoCalibracion>? Clbr02TipoCalibraciones { get; set; }

        public virtual DbSet<cnt01CuentaCliente>? cnt01CuentaClientes { get; set; }

        public virtual DbSet<cnt02TipoCuenta>? cnt02TipoCuentas { get; set; }

        public virtual DbSet<cnt03TipoCliente>? cnt03TipoClientes { get; set; }

        public virtual DbSet<cnt04ContactoCliente>? cnt04ContactoClientes { get; set; }

        public virtual DbSet<cnt05TipoContacto>? cnt05TipoContactos { get; set; }

        public virtual DbSet<cnt06ComunicacionCliente>? cnt06ComunicacionClientes { get; set; }

        public virtual DbSet<cnt07TipoSegmentacion>? cnt07TipoSegmentaciones { get; set; }

        public virtual DbSet<cnt08Segmentacion>? cnt08Segmentaciones { get; set; }

        public virtual DbSet<cnt09ComunicacionSegmentacion>? cnt09ComunicacionSegmentaciones { get; set; }

        public virtual DbSet<cnt10TipoComunicacion>? cnt10TipoComunicaciones { get; set; }

        public virtual DbSet<cnt11ContactoSegmentacion>? cnt11ContactoSegmentaciones { get; set; }

        public virtual DbSet<cnt12Empleado>? cnt12Empleados { get; set; }

        public virtual DbSet<cnt13TipoEmpleado>? cnt13TipoEmpleados { get; set; }

        public virtual DbSet<cnt14ClienteLicencia>? cnt14ClienteLicencias { get; set; }

        public virtual DbSet<cnt15EmpleadoLicencia>? cnt15EmpleadoLicencias { get; set; }

        public virtual DbSet<cnt16TipoBloqueoCliente>? cnt16TipoBloqueoClientes { get; set; }

        public virtual DbSet<cnt17Bloqueo>? cnt17Bloqueos { get; set; }

        public virtual DbSet<cnt18NivelSegmentacion>? cnt18NivelSegmentaciones { get; set; }

        public virtual DbSet<cnt19LicenciaCliente>? cnt19LicenciaClientes { get; set; }

        public virtual DbSet<cnt20LicenciaServicio>? cnt20LicenciaServicios { get; set; }

        public virtual DbSet<cnt21TipoEstacion>? cnt21TipoEstaciones { get; set; }

        public virtual DbSet<cnt22EstacionTipoEstacion>? cnt22EstacionTipoEstaciones { get; set; }

        public virtual DbSet<cnt23Tipocobro>? cnt23Tipocobros { get; set; }

        public virtual DbSet<cnt24AsociarCuenta>? cnt24AsociarCuentas { get; set; }

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

        public virtual DbSet<esp01especie>? esp01especies { get; set; }

        public virtual DbSet<esp02Temporadaespecie>? esp02Temporadaespecies { get; set; }

        public virtual DbSet<esp03especieBase>? esp03especieBases { get; set; }

        public virtual DbSet<esp04EstadoDanio>? esp04EstadoDanios { get; set; }

        public virtual DbSet<esp05Umbral>? esp05Umbrales { get; set; }

        public virtual DbSet<esp06MedidaUmbral>? esp06MedidaUmbrales { get; set; }

        public virtual DbSet<esp07Union>? esp07Uniones { get; set; }

        public virtual DbSet<esp08TipoBase>? esp08TipoBases { get; set; }

        public virtual DbSet<esp09TipoBaseUmbral>? esp09TipoBaseUmbrales { get; set; }

        public virtual DbSet<esp10TipoRegla>? esp10TipoReglas { get; set; }

        public virtual DbSet<esp11ReglaGrafico>? esp11ReglaGraficos { get; set; }

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

        public virtual DbSet<Men01sistema>? Men01sistemas { get; set; }

        public virtual DbSet<Mnt01Monitor>? Mnt01Monitores { get; set; }

        public virtual DbSet<Mnt02EspeciesAsignada>? Mnt02EspeciesAsignadas { get; set; }

        public virtual DbSet<Mnt03periodosTrampa>? Mnt03periodosTrampas { get; set; }

        public virtual DbSet<Mnt04TipoMonitor>? Mnt04TipoMonitores { get; set; }

        public virtual DbSet<Mvl01AccesoMovil>? Mvl01AccesoMoviles { get; set; }

        public virtual DbSet<Mvl02TablaSincronizacion>? Mvl02TablaSincronizaciones { get; set; }

        public virtual DbSet<Mvl03RegistroAcceso>? Mvl03RegistroAccesos { get; set; }

        public virtual DbSet<Mvl04AliasTablaSinc>? Mvl04AliasTablaSincas { get; set; }

        public virtual DbSet<Obsc01ObservacionCampo>? Obsc01ObservacionCampos { get; set; }

        public virtual DbSet<Obsc02ServicioPostcosecha>? Obsc02ServicioPostcosechas { get; set; }

        public virtual DbSet<Pbcd01Publicidad>? Pbcd01Publicidades { get; set; }

        public virtual DbSet<Pbcd02TipoPublicidad>? Pbcd02TipoPublicidades { get; set; }

        public virtual DbSet<Pbcd03Programacion>? Pbcd03Programaciones { get; set; }

        public virtual DbSet<per01persona>? per01personas { get; set; }

        public virtual DbSet<per02Genero>? per02Generos { get; set; }

        public virtual DbSet<per03Tipopersona>? per03Tipopersonas { get; set; }

        public virtual DbSet<per04TipoComunicacion>? per04TipoComunicaciones { get; set; }

        public virtual DbSet<per05Comunicacion>? per05Comunicaciones { get; set; }

        public virtual DbSet<per06TipopersonaComunicacion>? per06TipopersonaComunicaciones { get; set; }

        public virtual DbSet<per07personaUsuario>? per07personaUsuarios { get; set; }

        public virtual DbSet<per08TipoDocumento>? per08TipoDocumentos { get; set; }

        public virtual DbSet<per09DefaultUser>? per09DefaultUsers { get; set; }

        public virtual DbSet<Pgo01CompraLicencia>? Pgo01CompraLicencias { get; set; }

        public virtual DbSet<Pgo02NotificarPagoLicencia>? Pgo02NotificarPagoLicencias { get; set; }

        public virtual DbSet<Pgo03TipoPagoLicencia>? Pgo03TipoPagoLicencias { get; set; }

        public virtual DbSet<prf01perfil>? prf01perfiles { get; set; }

        public virtual DbSet<prf03Plantilla>? prf03Plantillas { get; set; }


        public virtual DbSet<prf04PlantillaFlujo> prf04PlantillaFlujos { get; set; }

        public virtual DbSet<prf05TipoAsignacionUsuario>? prf05TipoAsignacionUsuarios { get; set; }

        public virtual DbSet<prf06permisosUsuario>? prf06permisosUsuarios { get; set; }

        public virtual DbSet<Prm01Seguridad>? Prm01Seguridades { get; set; }

        public virtual DbSet<Secu01Rol>? Secu01Rols { get; set; }

        public virtual DbSet<Secu02Usuario>? Secu02Usuarios { get; set; }

        public virtual DbSet<Secu03TipoAcceso>? Secu03TipoAccesos { get; set; }

        public virtual DbSet<Secu04TipoEncriptacion>? Secu04TipoEncriptaciones { get; set; }

        public virtual DbSet<Secu05UsuarioAcceso>? Secu05UsuarioAccesos { get; set; }

        public virtual DbSet<Secu06UsuarioRol>? Secu06UsuarioRoles { get; set; }

        public virtual DbSet<Secu07Aplicacion>? Secu07Aplicaciones { get; set; }

        public virtual DbSet<Secu08UsuarioAplicacion>? Secu08UsuarioAplicaciones { get; set; }

        public virtual DbSet<Secu10Accesopermitido>? Secu10Accesopermitidos { get; set; }

        public virtual DbSet<Secu11Tipoperfil>? Secu11Tipoperfiles { get; set; }

        public virtual DbSet<Sercl01ServiciosCliente>? Sercl01ServiciosClientes { get; set; }

        public virtual DbSet<Sercl02MuestreoFruta>? Sercl02MuestreoFrutas { get; set; }

        public virtual DbSet<Serv01Servicio>? Serv01Servicios { get; set; }

        public virtual DbSet<Serv02TipoServicio>? Serv02TipoServicios { get; set; }

        public virtual DbSet<sist01sistema>? sist01sistemas { get; set; }

        public virtual DbSet<sist02Zona>? sist02Zonas { get; set; }

        public virtual DbSet<sist03Comuna>? sist03Comunas { get; set; }

        public virtual DbSet<sist04Region>? sist04Regiones { get; set; }

        public virtual DbSet<sist05EstadoRegistro>? sist05EstadoRegistros { get; set; }

        public virtual DbSet<sist06EstadoGrid>? sist06EstadoGrids { get; set; }

        public virtual DbSet<sist08ContactoUsuario>? sist08ContactoUsuarios { get; set; }

        public virtual DbSet<Temp01Temporada>? Temp01Temporadas { get; set; }

        public virtual DbSet<Temp02TemporadaBase>? Temp02TemporadaBases { get; set; }

        public virtual DbSet<Temp03Segmentacion>? Temp03Segmentaciones { get; set; }

        public virtual DbSet<Trp01Trampa>? Trp01Trampas { get; set; }

        public virtual DbSet<Trp02Temporada>? Trp02Temporadas { get; set; }

        public virtual DbSet<Trp03Geocordenada>? Trp03Geocordenadas { get; set; }

        public virtual DbSet<wkf01Flujo>? wkf01Flujos { get; set; }

        public virtual DbSet<wkf02TipoFlujo>? wkf02TipoFlujos { get; set; }

        public virtual DbSet<wkf03Nivel>? wkf03Niveles { get; set; }

        public virtual DbSet<wkf04Nivelpermiso>? wkf04Nivelpermisos { get; set; }

        public virtual DbSet<wkf05Tipopermiso>? wkf05Tipopermisos { get; set; }

        public virtual DbSet<wkf06perfil>? wkf06perfiles { get; set; }

        public virtual DbSet<wkf07perfilespermiso>? wkf07perfilespermisos { get; set; }

        public virtual DbSet<wkf08Area>? wkf08Areas { get; set; }

        public virtual DbSet<wkf09Parametro>? wkf09Parametros { get; set; }

        public virtual DbSet<wkf10TipoParametro>? wkf10TipoParametros { get; set; }

        public DbSet<setSelect>? SetSelects { get; set; }

        public DbSet<MonitorTrampaBuscarResponseDto> MonitorTrampaBuscarResponse { get; set; }

        public DbSet<MovilAccesoResponseDto> MovilAccesoResponse { get; set; }

        public DbSet<MovilPeriodoResponseDto> MovilPeriodoResponse { get; set; }

        public DbSet<MovilControlReservaResponseDto> MovilControlReservaResponse { get; set; }

        public DbSet<ClienteEstacionActivaResponseDto> ClienteEstacionActivaResponse { get; set; }

    }
}
    