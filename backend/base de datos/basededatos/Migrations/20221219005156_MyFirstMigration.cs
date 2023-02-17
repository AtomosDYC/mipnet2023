using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basededatos.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BLK02_TipoBloqueo",
                columns: table => new
                {
                    BLK02Llave = table.Column<decimal>(name: "BLK02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BLK02Nombre = table.Column<string>(name: "BLK02_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BLK02Descripcion = table.Column<string>(name: "BLK02_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BLK02Activo = table.Column<int>(name: "BLK02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLK02_TipoBloqueo", x => x.BLK02Llave);
                });

            migrationBuilder.CreateTable(
                name: "CLBR02_TipoCalibracion",
                columns: table => new
                {
                    CLBR02Llave = table.Column<decimal>(name: "CLBR02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLBR02Nombre = table.Column<string>(name: "CLBR02_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CLBR02Descripcion = table.Column<string>(name: "CLBR02_Descripcion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CLBR02Activo = table.Column<int>(name: "CLBR02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLBR02_TipoCalibracion", x => x.CLBR02Llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT02_TipoCuenta",
                columns: table => new
                {
                    CNT02Llave = table.Column<decimal>(name: "CNT02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT02Nombre = table.Column<string>(name: "CNT02_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT02Descripcion = table.Column<string>(name: "CNT02_Descripcion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT02Activo = table.Column<int>(name: "CNT02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT02_TipoCuenta", x => x.CNT02Llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT05_TipoContacto",
                columns: table => new
                {
                    CNT05Llave = table.Column<decimal>(name: "CNT05_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT05Nombre = table.Column<string>(name: "CNT05_Nombre", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT05descripcion = table.Column<string>(name: "CNT05_descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT05Activo = table.Column<int>(name: "CNT05_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT05_TipoContacto", x => x.CNT05Llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT10_TipoComunicacion",
                columns: table => new
                {
                    CNT10Llave = table.Column<decimal>(name: "CNT10_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT10Nombre = table.Column<string>(name: "CNT10_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT10Descripcion = table.Column<string>(name: "CNT10_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT10Activo = table.Column<int>(name: "CNT10_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT10_TipoComunicacion", x => x.CNT10Llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT13_TipoEmpleado",
                columns: table => new
                {
                    CNT13Llave = table.Column<decimal>(name: "CNT13_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT13Nombre = table.Column<string>(name: "CNT13_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT13Descripcion = table.Column<string>(name: "CNT13_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT13Activo = table.Column<int>(name: "CNT13_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT13_TipoEmpleado", x => x.CNT13Llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT16_TipoBloqueoCliente",
                columns: table => new
                {
                    CNT16Llave = table.Column<decimal>(name: "CNT16_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT16Nombre = table.Column<string>(name: "CNT16_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT16Descripcion = table.Column<string>(name: "CNT16_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT16Activo = table.Column<bool>(name: "CNT16_Activo", type: "bit", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT16_TipoBloqueoCliente", x => x.CNT16Llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT18_NivelSegmentacion",
                columns: table => new
                {
                    CNT18Llave = table.Column<decimal>(name: "CNT18_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT18Nombre = table.Column<string>(name: "CNT18_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT18Descripccion = table.Column<string>(name: "CNT18_Descripccion", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CNT18NivelCapa = table.Column<int>(name: "CNT18_NivelCapa", type: "int", nullable: true),
                    CNT18Activo = table.Column<int>(name: "CNT18_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT18_NivelSegmentacion", x => x.CNT18Llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT21_TipoEstacion",
                columns: table => new
                {
                    CNT21Llave = table.Column<decimal>(name: "CNT21_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT21Nombre = table.Column<string>(name: "CNT21_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT21Descripcion = table.Column<string>(name: "CNT21_Descripcion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT21Activo = table.Column<int>(name: "CNT21_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT21_TipoEstacion", x => x.CNT21Llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT23_Tipocobro",
                columns: table => new
                {
                    CNT23Llave = table.Column<decimal>(name: "CNT23_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT23Nombre = table.Column<string>(name: "CNT23_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT23Descripcion = table.Column<string>(name: "CNT23_Descripcion", type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CNT23Activo = table.Column<int>(name: "CNT23_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT23_Tipocobro", x => x.CNT23Llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT24_AsociarCuenta",
                columns: table => new
                {
                    CNT01Llave = table.Column<decimal>(name: "CNT01_Llave", type: "numeric(18,0)", nullable: false),
                    CNT01CuentaLlave = table.Column<decimal>(name: "CNT01_Cuenta_Llave", type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT24_AsociarCuenta", x => new { x.CNT01Llave, x.CNT01CuentaLlave });
                });

            migrationBuilder.CreateTable(
                name: "CONT02_TipoContacto",
                columns: table => new
                {
                    CONT02Llave = table.Column<decimal>(name: "CONT02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONT02Nombre = table.Column<string>(name: "CONT02_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONT02Descripcion = table.Column<string>(name: "CONT02_Descripcion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONT02_TipoContacto_1", x => x.CONT02Llave);
                });

            migrationBuilder.CreateTable(
                name: "CTT02_TipoContrato",
                columns: table => new
                {
                    CTT02Llave = table.Column<decimal>(name: "CTT02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTT02Nombre = table.Column<string>(name: "CTT02_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CTT02Descripcion = table.Column<string>(name: "CTT02_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CTT02Activo = table.Column<int>(name: "CTT02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTT02_TipoContrato", x => x.CTT02Llave);
                });

            migrationBuilder.CreateTable(
                name: "CTZR01_Cotizacion",
                columns: table => new
                {
                    CTZR01Llave = table.Column<decimal>(name: "CTZR01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: true),
                    LNC01Llave = table.Column<decimal>(name: "LNC01_Llave", type: "numeric(18,0)", nullable: true),
                    CTZR01fecha = table.Column<DateTime>(name: "CTZR01_fecha", type: "datetime", nullable: true),
                    CTZR01comentario = table.Column<string>(name: "CTZR01_comentario", type: "nvarchar(max)", nullable: true),
                    CTZR01Activo = table.Column<int>(name: "CTZR01_Activo", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTZR01_Cotizacion", x => x.CTZR01Llave);
                });

            migrationBuilder.CreateTable(
                name: "EML03_TipoMailAcciones",
                columns: table => new
                {
                    EML03Llave = table.Column<decimal>(name: "EML03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EML03Nombre = table.Column<string>(name: "EML03_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EML03Descripcion = table.Column<string>(name: "EML03_Descripcion", type: "nvarchar(max)", nullable: true),
                    EML03Activo = table.Column<int>(name: "EML03_Activo", type: "int", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EML03_TipoMailAcciones_1", x => x.EML03Llave);
                });

            migrationBuilder.CreateTable(
                name: "EML04_ImportanciaMail",
                columns: table => new
                {
                    EML04Llave = table.Column<decimal>(name: "EML04_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EML04Nombre = table.Column<string>(name: "EML04_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EML04Descripcion = table.Column<string>(name: "EML04_Descripcion", type: "nvarchar(max)", nullable: true),
                    EML04Activo = table.Column<int>(name: "EML04_Activo", type: "int", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EML04_ImportanciaMail", x => x.EML04Llave);
                });

            migrationBuilder.CreateTable(
                name: "EML06_TipoArchivo",
                columns: table => new
                {
                    EML06Llave = table.Column<decimal>(name: "EML06_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EML06Nombre = table.Column<string>(name: "EML06_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EML06Descripcion = table.Column<string>(name: "EML06_Descripcion", type: "nvarchar(max)", nullable: true),
                    EML06Activo = table.Column<int>(name: "EML06_Activo", type: "int", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EML06_TipoArchivo", x => x.EML06Llave);
                });

            migrationBuilder.CreateTable(
                name: "ESP06_MedidaUmbral",
                columns: table => new
                {
                    ESP06Llave = table.Column<decimal>(name: "ESP06_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP06Nombre = table.Column<string>(name: "ESP06_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP06Descripcion = table.Column<string>(name: "ESP06_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ESP06Activo = table.Column<int>(name: "ESP06_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP06_MedidaUmbral", x => x.ESP06Llave);
                });

            migrationBuilder.CreateTable(
                name: "ESP08_TipoBase",
                columns: table => new
                {
                    ESP08Llave = table.Column<decimal>(name: "ESP08_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP08Nombre = table.Column<string>(name: "ESP08_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ESP08Descripcion = table.Column<string>(name: "ESP08_Descripcion", type: "nvarchar(max)", nullable: true),
                    ESP08Activo = table.Column<int>(name: "ESP08_Activo", type: "int", nullable: true, defaultValueSql: "((1))"),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP08_TipoBase", x => x.ESP08Llave);
                });

            migrationBuilder.CreateTable(
                name: "ESP09_TipoBaseUmbral",
                columns: table => new
                {
                    ESP09Llave = table.Column<decimal>(name: "ESP09_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP09Nombre = table.Column<string>(name: "ESP09_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP09Descripcion = table.Column<string>(name: "ESP09_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ESP09Activo = table.Column<int>(name: "ESP09_Activo", type: "int", nullable: true),
                    ESP09Orden = table.Column<int>(name: "ESP09_Orden", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP09_TipoBaseUmbral", x => x.ESP09Llave);
                });

            migrationBuilder.CreateTable(
                name: "ESP10_TipoRegla",
                columns: table => new
                {
                    ESP10Llave = table.Column<decimal>(name: "ESP10_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP10Nombre = table.Column<string>(name: "ESP10_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP10Descripcion = table.Column<string>(name: "ESP10_Descripcion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP10Activo = table.Column<int>(name: "ESP10_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP10_TipoRegla", x => x.ESP10Llave);
                });

            migrationBuilder.CreateTable(
                name: "FRM01_TipoFormulario",
                columns: table => new
                {
                    FRM01Llave = table.Column<decimal>(name: "FRM01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FRM01Nombre = table.Column<string>(name: "FRM01_Nombre", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FRM01Activo = table.Column<int>(name: "FRM01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FRM01_TipoFormulario", x => x.FRM01Llave);
                });

            migrationBuilder.CreateTable(
                name: "GRFC01_GraficoGenerado",
                columns: table => new
                {
                    GRFC01Llave = table.Column<decimal>(name: "GRFC01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: true),
                    GRFC01FechaGrafico = table.Column<DateTime>(name: "GRFC01_FechaGrafico", type: "datetime", nullable: true),
                    GRFC01codigografico = table.Column<string>(name: "GRFC01_codigo_grafico", type: "nvarchar(150)", maxLength: 150, nullable: true),
                    GRFC02Llave = table.Column<decimal>(name: "GRFC02_Llave", type: "numeric(18,0)", nullable: true),
                    GRFC01estado = table.Column<int>(name: "GRFC01_estado", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRFC01_GraficoGenerado", x => x.GRFC01Llave);
                });

            migrationBuilder.CreateTable(
                name: "GRFC02_TipoGrafico",
                columns: table => new
                {
                    GRFC02Llave = table.Column<decimal>(name: "GRFC02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GRFC02Nombre = table.Column<string>(name: "GRFC02_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GRFC02Descripcion = table.Column<string>(name: "GRFC02_Descripcion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GRFC02Activo = table.Column<int>(name: "GRFC02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRFC02_TipoGrafico", x => x.GRFC02Llave);
                });

            migrationBuilder.CreateTable(
                name: "GRFC03_respaldoGrafico",
                columns: table => new
                {
                    GRFC03Llave = table.Column<decimal>(name: "GRFC03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: true),
                    ESP03Llave = table.Column<decimal>(name: "ESP03_Llave", type: "numeric(18,0)", nullable: true),
                    CNT08Llave = table.Column<decimal>(name: "CNT08_Llave", type: "numeric(18,0)", nullable: true),
                    GRFC03ultimaFecha = table.Column<DateTime>(name: "GRFC03_ultimaFecha", type: "datetime", nullable: true),
                    GRFC03xmlDatos = table.Column<string>(name: "GRFC03_xmlDatos", type: "nvarchar(max)", nullable: true),
                    GRFC03Estado = table.Column<int>(name: "GRFC03_Estado", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRFC03_respaldoGrafico", x => x.GRFC03Llave);
                });

            migrationBuilder.CreateTable(
                name: "INS01_Inscripcion",
                columns: table => new
                {
                    INS01Llave = table.Column<decimal>(name: "INS01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INS01Rut = table.Column<decimal>(name: "INS01_Rut", type: "numeric(18,0)", nullable: true),
                    PER02Llave = table.Column<decimal>(name: "PER02_Llave", type: "numeric(18,0)", nullable: true),
                    INS01Nombre = table.Column<string>(name: "INS01_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    INS01Apellido = table.Column<string>(name: "INS01_Apellido", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    INS01Empresa = table.Column<string>(name: "INS01_Empresa", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SIST03Llave = table.Column<decimal>(name: "SIST03_Llave", type: "numeric(18,0)", nullable: true),
                    INS01Direccion = table.Column<string>(name: "INS01_Direccion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    INS01Telefono = table.Column<string>(name: "INS01_Telefono", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    INS01FechaNacimiento = table.Column<DateTime>(name: "INS01_FechaNacimiento", type: "datetime", nullable: true),
                    INS01Email = table.Column<string>(name: "INS01_Email", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    INS01FechaInscripcion = table.Column<DateTime>(name: "INS01_FechaInscripcion", type: "datetime", nullable: true),
                    INS01Activo = table.Column<int>(name: "INS01_Activo", type: "int", nullable: true),
                    INS01FechaActivacion = table.Column<DateTime>(name: "INS01_FechaActivacion", type: "datetime", nullable: true),
                    INS01UserName = table.Column<string>(name: "INS01_UserName", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    INS01Password = table.Column<string>(name: "INS01_Password", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INS01_Inscripcion", x => x.INS01Llave);
                });

            migrationBuilder.CreateTable(
                name: "LNC01_Licencias",
                columns: table => new
                {
                    LNC01Llave = table.Column<decimal>(name: "LNC01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LNC01Nombre = table.Column<string>(name: "LNC01_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LNC01Descripcion = table.Column<string>(name: "LNC01_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LNC04Llave = table.Column<decimal>(name: "LNC04_Llave", type: "numeric(18,0)", nullable: true),
                    LNC01MaximoUsuarios = table.Column<decimal>(name: "LNC01_MaximoUsuarios", type: "numeric(18,0)", nullable: true),
                    LNC01NumeroDias = table.Column<int>(name: "LNC01_NumeroDias", type: "int", nullable: true),
                    LNC01TextoDias = table.Column<string>(name: "LNC01_TextoDias", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LNC01VisibleUsuario = table.Column<int>(name: "LNC01_VisibleUsuario", type: "int", nullable: true),
                    LNC01Imagen = table.Column<string>(name: "LNC01_Imagen", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LNC01HTML = table.Column<string>(name: "LNC01_HTML", type: "nvarchar(max)", nullable: true),
                    LNC01Activo = table.Column<int>(name: "LNC01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC01_Licencias", x => x.LNC01Llave);
                });

            migrationBuilder.CreateTable(
                name: "LNC04_TipoLicencia",
                columns: table => new
                {
                    LNC04Llave = table.Column<decimal>(name: "LNC04_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LNC04Nombre = table.Column<string>(name: "LNC04_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LNC04Descripcion = table.Column<string>(name: "LNC04_Descripcion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LNC04Activo = table.Column<int>(name: "LNC04_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC04_TipoLicencia", x => x.LNC04Llave);
                });

            migrationBuilder.CreateTable(
                name: "LOG02_TipoBitacora",
                columns: table => new
                {
                    LOG02Llave = table.Column<Guid>(name: "LOG02_Llave", type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    LOG02Nombre = table.Column<string>(name: "LOG02_Nombre", type: "nvarchar(300)", maxLength: 300, nullable: true),
                    LOG02Descripcion = table.Column<string>(name: "LOG02_Descripcion", type: "nvarchar(max)", nullable: true),
                    LOG02EsSistema = table.Column<int>(name: "LOG02_EsSistema", type: "int", nullable: true, defaultValueSql: "((0))"),
                    LOG02EsRazor = table.Column<int>(name: "LOG02_EsRazor", type: "int", nullable: true),
                    LOG02Info = table.Column<string>(name: "LOG02_Info", type: "nvarchar(max)", nullable: true),
                    LOG02Activo = table.Column<int>(name: "LOG02_Activo", type: "int", nullable: true, defaultValueSql: "((1))"),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOG02_Ti__EA456AA523FE4082", x => x.LOG02Llave);
                });

            migrationBuilder.CreateTable(
                name: "MEN01_Sistema",
                columns: table => new
                {
                    MEN01Llave = table.Column<decimal>(name: "MEN01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MEN01url = table.Column<string>(name: "MEN01_url", type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MEN01titulo = table.Column<string>(name: "MEN01_titulo", type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MEN01descripcion = table.Column<string>(name: "MEN01_descripcion", type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MEN01tooltip = table.Column<string>(name: "MEN01_tooltip", type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MEN01Area = table.Column<string>(name: "MEN01_Area", type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MEN01Control = table.Column<string>(name: "MEN01_Control", type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MEN01Accion = table.Column<string>(name: "MEN01_Accion", type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MEN01Llavepadre = table.Column<decimal>(name: "MEN01_Llave_padre", type: "numeric(18,0)", nullable: true),
                    MEN01IconoUrl = table.Column<string>(name: "MEN01_IconoUrl", type: "nvarchar(max)", nullable: true),
                    MEN01principal = table.Column<bool>(name: "MEN01_principal", type: "bit", nullable: false),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MEN01_Si__4F35303B75CD617E", x => x.MEN01Llave);
                });

            migrationBuilder.CreateTable(
                name: "MNT04_TipoMonitor",
                columns: table => new
                {
                    MNT04Llave = table.Column<decimal>(name: "MNT04_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MNT04Nombre = table.Column<string>(name: "MNT04_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MNT04Descripcion = table.Column<string>(name: "MNT04_Descripcion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MNT04Activo = table.Column<int>(name: "MNT04_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MNT05_TipoBase", x => x.MNT04Llave);
                });

            migrationBuilder.CreateTable(
                name: "MVL01_AccesoMovil",
                columns: table => new
                {
                    MVL01Llave = table.Column<string>(name: "MVL01_Llave", type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MVL01idusuario = table.Column<Guid>(name: "MVL01_id_usuario", type: "uniqueidentifier", nullable: true),
                    MVL01numeromovil = table.Column<string>(name: "MVL01_numero_movil", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MVL01sistemaandroid = table.Column<string>(name: "MVL01_sistema_android", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MVL01versionandroid = table.Column<string>(name: "MVL01_version_android", type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MVL01versionaplicacion = table.Column<string>(name: "MVL01_version_aplicacion", type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MVL01versiondescarga = table.Column<string>(name: "MVL01_version_descarga", type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MVL01establoqueado = table.Column<bool>(name: "MVL01_esta_bloqueado", type: "bit", nullable: true, defaultValueSql: "((1))"),
                    MVL01mensajemovil = table.Column<string>(name: "MVL01_mensaje_movil", type: "nvarchar(max)", nullable: true),
                    MVL01fechamensaje = table.Column<DateTime>(name: "MVL01_fecha_mensaje", type: "datetime", nullable: true),
                    MVL01fecharegistro = table.Column<DateTime>(name: "MVL01_fecha_registro", type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    MVL01fechaultimoacceso = table.Column<DateTime>(name: "MVL01_fecha_ultimo_acceso", type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    MVL01fechaultimaactividad = table.Column<DateTime>(name: "MVL01_fecha_ultima_actividad", type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    MVL01fechaultimasincro = table.Column<DateTime>(name: "MVL01_fecha_ultima_sincro", type: "datetime", nullable: true),
                    MVL01tamanobasedatoscliente = table.Column<decimal>(name: "MVL01_tamano_basedatos_cliente", type: "numeric(18,3)", nullable: true),
                    MVL01ubicacionactividadx = table.Column<decimal>(name: "MVL01_ubicacion_actividad_x", type: "numeric(18,0)", nullable: true),
                    MVL01ubicacionactividady = table.Column<decimal>(name: "MVL01_ubicacion_actividad_y", type: "numeric(18,0)", nullable: true),
                    MVL01editafechamonitoreo = table.Column<bool>(name: "MVL01_edita_fecha_monitoreo", type: "bit", nullable: true, defaultValueSql: "((1))"),
                    MVL01diasumbraledicion = table.Column<decimal>(name: "MVL01_dias_umbral_edicion", type: "numeric(18,0)", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MVL02_TablaSincronizacion",
                columns: table => new
                {
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: false),
                    NombreTabla = table.Column<string>(name: "Nombre_Tabla", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaUltimaActualizacion = table.Column<DateTime>(name: "Fecha_UltimaActualizacion", type: "datetime", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MVL03_RegistroAcceso",
                columns: table => new
                {
                    MVL03Llave = table.Column<decimal>(name: "MVL03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PER01Llave = table.Column<decimal>(name: "PER01_Llave", type: "numeric(18,0)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LoweredUserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MobileAlias = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsAnonymous = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    LastActivityDate = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PasswordFormat = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PasswordSalt = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    SECU02Activo = table.Column<bool>(name: "SECU02_Activo", type: "bit", nullable: true),
                    nombreusuario = table.Column<string>(name: "nombre_usuario", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    emailusuario = table.Column<string>(name: "email_usuario", type: "nvarchar(300)", maxLength: 300, nullable: true),
                    estadousuario = table.Column<int>(name: "estado_usuario", type: "int", nullable: true),
                    MVL03FECHACREACION = table.Column<DateTime>(name: "MVL03_FECHACREACION", type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MVL03_RegistroAcceso", x => x.MVL03Llave);
                });

            migrationBuilder.CreateTable(
                name: "OBSC02_ServicioPostcosecha",
                columns: table => new
                {
                    OBSC02Llave = table.Column<decimal>(name: "OBSC02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP08Llave = table.Column<decimal>(name: "ESP08_Llave", type: "numeric(18,0)", nullable: true),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: true),
                    OBSC02Nombre = table.Column<string>(name: "OBSC02_Nombre", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OBSC02Resumen = table.Column<string>(name: "OBSC02_Resumen", type: "nvarchar(max)", nullable: true),
                    OBSC02Activo = table.Column<int>(name: "OBSC02_Activo", type: "int", nullable: true),
                    OBSC02Fecha = table.Column<DateTime>(name: "OBSC02_Fecha", type: "datetime", nullable: true),
                    OBSC02UrlPdf = table.Column<string>(name: "OBSC02_UrlPdf", type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OBSC02_ServicioPostcosecha", x => x.OBSC02Llave);
                });

            migrationBuilder.CreateTable(
                name: "PBCD02_TipoPublicidad",
                columns: table => new
                {
                    PBCD02Llave = table.Column<decimal>(name: "PBCD02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PBCD02Nombre = table.Column<string>(name: "PBCD02_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PBCD02Descripcion = table.Column<string>(name: "PBCD02_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD02Activo = table.Column<int>(name: "PBCD02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PBCD02_TipoPublicidad", x => x.PBCD02Llave);
                });

            migrationBuilder.CreateTable(
                name: "PER02_Genero",
                columns: table => new
                {
                    PER02Llave = table.Column<decimal>(name: "PER02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER02Titulo = table.Column<string>(name: "PER02_Titulo", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER02Genero = table.Column<string>(name: "PER02_Genero", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER02Sexo = table.Column<string>(name: "PER02_Sexo", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER02Orden = table.Column<decimal>(name: "PER02_Orden", type: "numeric(18,0)", nullable: true),
                    PER02Activo = table.Column<int>(name: "PER02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER02_Genero", x => x.PER02Llave);
                });

            migrationBuilder.CreateTable(
                name: "PER03_TipoPersona",
                columns: table => new
                {
                    PER03Llave = table.Column<decimal>(name: "PER03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER03Nombre = table.Column<string>(name: "PER03_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PER03Descripcion = table.Column<string>(name: "PER03_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER03Activo = table.Column<int>(name: "PER03_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER03_TipoPersona", x => x.PER03Llave);
                });

            migrationBuilder.CreateTable(
                name: "PER04_TipoComunicacion",
                columns: table => new
                {
                    PER04Llave = table.Column<decimal>(name: "PER04_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER04Nombre = table.Column<string>(name: "PER04_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PER04Descripcion = table.Column<string>(name: "PER04_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER04Activo = table.Column<int>(name: "PER04_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER04_TipoComunicacion", x => x.PER04Llave);
                });

            migrationBuilder.CreateTable(
                name: "PGO03_TipoPagoLicencia",
                columns: table => new
                {
                    PGO03Llave = table.Column<decimal>(name: "PGO03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PGO03Nombre = table.Column<string>(name: "PGO03_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PGO03Descripcion = table.Column<string>(name: "PGO03_Descripcion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PGO03Activo = table.Column<int>(name: "PGO03_Activo", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PGO03_FormaPago", x => x.PGO03Llave);
                });

            migrationBuilder.CreateTable(
                name: "PRF03_Plantilla",
                columns: table => new
                {
                    PRF03Llave = table.Column<decimal>(name: "PRF03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRF03Nombre = table.Column<string>(name: "PRF03_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PRF03Descripcion = table.Column<string>(name: "PRF03_Descripcion", type: "nvarchar(max)", nullable: true),
                    PRF03estadoRegistro = table.Column<string>(name: "PRF03_estadoRegistro", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PRF03Activo = table.Column<int>(name: "PRF03_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRF03_PlantillaPerfil", x => x.PRF03Llave);
                });

            migrationBuilder.CreateTable(
                name: "PRF05_TipoAsignacionUsuario",
                columns: table => new
                {
                    PRF05Llave = table.Column<decimal>(name: "PRF05_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRF05Nombre = table.Column<string>(name: "PRF05_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PRF05Descripcion = table.Column<string>(name: "PRF05_Descripcion", type: "nvarchar(max)", nullable: true),
                    PRF05Activo = table.Column<int>(name: "PRF05_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRF05_TipoAsignacionUsuario", x => x.PRF05Llave);
                });

            migrationBuilder.CreateTable(
                name: "PRM01_Seguridad",
                columns: table => new
                {
                    PRM01Llave = table.Column<decimal>(name: "PRM01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRM01Nombre = table.Column<string>(name: "PRM01_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PRM01Descripcion = table.Column<string>(name: "PRM01_Descripcion", type: "nvarchar(max)", nullable: true),
                    PRM01valor = table.Column<decimal>(name: "PRM01_valor", type: "numeric(18,0)", nullable: true),
                    PRM01UrlError = table.Column<string>(name: "PRM01_UrlError", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PRM01Activo = table.Column<int>(name: "PRM01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRM01_Seguridad", x => x.PRM01Llave);
                });

            migrationBuilder.CreateTable(
                name: "SECU01_Rol",
                columns: table => new
                {
                    SECU01Llave = table.Column<Guid>(name: "SECU01_Llave", type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SECU01Nombre = table.Column<string>(name: "SECU01_Nombre", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SECU01Descripcion = table.Column<string>(name: "SECU01_Descripcion", type: "nvarchar(max)", nullable: true),
                    SECU01Orden = table.Column<int>(name: "SECU01_Orden", type: "int", nullable: true),
                    SECU01Info = table.Column<string>(name: "SECU01_Info", type: "xml", nullable: true),
                    SECU01Activo = table.Column<bool>(name: "SECU01_Activo", type: "bit", nullable: true, defaultValueSql: "((1))"),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SECU01_R__2E718C9349B338EE", x => x.SECU01Llave);
                });

            migrationBuilder.CreateTable(
                name: "SECU02_Usuario20170202",
                columns: table => new
                {
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: false),
                    SECU02Usuario = table.Column<string>(name: "SECU02_Usuario", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SECU02Clave = table.Column<string>(name: "SECU02_Clave", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SECU02ComplementoClave = table.Column<string>(name: "SECU02_ComplementoClave", type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SECU04TipoEncriptacion = table.Column<Guid>(name: "SECU04_TipoEncriptacion", type: "uniqueidentifier", nullable: true),
                    SECU02Movil = table.Column<string>(name: "SECU02_Movil", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SECU02Email = table.Column<string>(name: "SECU02_Email", type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SECU02Pregunta = table.Column<string>(name: "SECU02_Pregunta", type: "nvarchar(max)", nullable: true),
                    SECU02Respuesta = table.Column<string>(name: "SECU02_Respuesta", type: "nvarchar(600)", maxLength: 600, nullable: true),
                    SECU02Bloqueado = table.Column<bool>(name: "SECU02_Bloqueado", type: "bit", nullable: true),
                    SECU02FechaBloqueo = table.Column<DateTime>(name: "SECU02_FechaBloqueo", type: "datetime", nullable: true),
                    SECU02FechaCambioPass = table.Column<DateTime>(name: "SECU02_FechaCambioPass", type: "datetime", nullable: true),
                    SECU02Activo = table.Column<bool>(name: "SECU02_Activo", type: "bit", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SECU03_TipoAcceso",
                columns: table => new
                {
                    SECU03Llave = table.Column<Guid>(name: "SECU03_Llave", type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    SECU03Nombre = table.Column<string>(name: "SECU03_Nombre", type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SECU03Descripcion = table.Column<string>(name: "SECU03_Descripcion", type: "nvarchar(max)", nullable: true),
                    SECU03Info = table.Column<string>(name: "SECU03_Info", type: "xml", nullable: true),
                    SECU03Activo = table.Column<bool>(name: "SECU03_Activo", type: "bit", nullable: true, defaultValueSql: "((1))"),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SECU03_T__7B6F14E7DEC70462", x => x.SECU03Llave);
                });

            migrationBuilder.CreateTable(
                name: "SECU04_TipoEncriptacion",
                columns: table => new
                {
                    SECU04Llave = table.Column<Guid>(name: "SECU04_Llave", type: "uniqueidentifier", nullable: false),
                    SECU04Nombre = table.Column<string>(name: "SECU04_Nombre", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SECU04Proyecto = table.Column<string>(name: "SECU04_Proyecto", type: "nvarchar(max)", nullable: true),
                    SECU04Clase = table.Column<string>(name: "SECU04_Clase", type: "nvarchar(max)", nullable: true),
                    SECU04Funcion = table.Column<string>(name: "SECU04_Funcion", type: "nvarchar(max)", nullable: true),
                    SECU04Parametros = table.Column<string>(name: "SECU04_Parametros", type: "xml", nullable: true),
                    SECU04Info = table.Column<string>(name: "SECU04_Info", type: "xml", nullable: true),
                    SECU04Activo = table.Column<bool>(name: "SECU04_Activo", type: "bit", nullable: true, defaultValueSql: "((1))"),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SECU04_T__3412AACF89203574", x => x.SECU04Llave);
                });

            migrationBuilder.CreateTable(
                name: "SECU07_Aplicacion",
                columns: table => new
                {
                    SECU07Llave = table.Column<Guid>(name: "SECU07_Llave", type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SECU07Nombre = table.Column<string>(name: "SECU07_Nombre", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SECU07Descripcion = table.Column<string>(name: "SECU07_Descripcion", type: "nvarchar(max)", nullable: true),
                    SECU07Info = table.Column<string>(name: "SECU07_Info", type: "xml", nullable: true),
                    SECU07Activo = table.Column<bool>(name: "SECU07_Activo", type: "bit", nullable: true, defaultValueSql: "((1))"),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SECU07_A__148FCE85966FFC87", x => x.SECU07Llave);
                });

            migrationBuilder.CreateTable(
                name: "SECU11_TipoPerfil",
                columns: table => new
                {
                    PRF02Llave = table.Column<decimal>(name: "PRF02_Llave", type: "numeric(18,0)", nullable: false),
                    PRF02Nombre = table.Column<string>(name: "PRF02_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PRF02Descripcion = table.Column<string>(name: "PRF02_Descripcion", type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FECHAACTULIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SECU11_TipoPerfil", x => x.PRF02Llave);
                });

            migrationBuilder.CreateTable(
                name: "SERCL01_ServiciosClientes",
                columns: table => new
                {
                    SERCL01Llave = table.Column<decimal>(name: "SERCL01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT19Llave = table.Column<decimal>(name: "CNT19_Llave", type: "numeric(18,0)", nullable: true),
                    SERV01Llave = table.Column<decimal>(name: "SERV01_Llave", type: "numeric(18,0)", nullable: true),
                    CNT01Llave = table.Column<decimal>(name: "CNT01_Llave", type: "numeric(18,0)", nullable: true),
                    CNT08Llave = table.Column<decimal>(name: "CNT08_Llave", type: "numeric(18,0)", nullable: true),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: true),
                    ESP03Llave = table.Column<decimal>(name: "ESP03_Llave", type: "numeric(18,0)", nullable: true),
                    ESP04Llave = table.Column<decimal>(name: "ESP04_Llave", type: "numeric(18,0)", nullable: true),
                    ESP08Llave = table.Column<decimal>(name: "ESP08_Llave", type: "numeric(18,0)", nullable: true),
                    SISt04Llave = table.Column<decimal>(name: "SISt04_Llave", type: "numeric(18,0)", nullable: true),
                    SIST03Llave = table.Column<decimal>(name: "SIST03_Llave", type: "numeric(18,0)", nullable: true),
                    SERCL01TipoGrafico = table.Column<decimal>(name: "SERCL01_TipoGrafico", type: "numeric(18,0)", nullable: true),
                    CONTEO03Llave = table.Column<decimal>(name: "CONTEO03_Llave", type: "numeric(18,0)", nullable: true),
                    SERCL01Costo = table.Column<decimal>(name: "SERCL01_Costo", type: "numeric(18,2)", nullable: true),
                    SERCL01cantidad = table.Column<decimal>(name: "SERCL01_cantidad", type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERCL01_ServiciosClientes", x => x.SERCL01Llave);
                });

            migrationBuilder.CreateTable(
                name: "SERV02_TipoServicio",
                columns: table => new
                {
                    SERV02Llave = table.Column<decimal>(name: "SERV02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERV02Nombre = table.Column<string>(name: "SERV02_Nombre", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SERV02Descripcion = table.Column<string>(name: "SERV02_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SERV02Activo = table.Column<int>(name: "SERV02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERV02_TipoServicio", x => x.SERV02Llave);
                });

            migrationBuilder.CreateTable(
                name: "SIST01_Sistema",
                columns: table => new
                {
                    SIST01Llave = table.Column<decimal>(name: "SIST01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST01Nombre = table.Column<string>(name: "SIST01_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SIST01Descripcion = table.Column<string>(name: "SIST01_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST01EsPublica = table.Column<bool>(name: "SIST01_EsPublica", type: "bit", nullable: true),
                    SIST01EsServicios = table.Column<bool>(name: "SIST01_EsServicios", type: "bit", nullable: true),
                    SIST01Activo = table.Column<bool>(name: "SIST01_Activo", type: "bit", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST01_Sistema", x => x.SIST01Llave);
                });

            migrationBuilder.CreateTable(
                name: "SIST02_Zona",
                columns: table => new
                {
                    SIST02Llave = table.Column<decimal>(name: "SIST02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST02Nombre = table.Column<string>(name: "SIST02_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST02Descripcion = table.Column<string>(name: "SIST02_Descripcion", type: "nvarchar(max)", nullable: true),
                    SIST02estadoregistro = table.Column<string>(name: "SIST02_estadoregistro", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SIST02Activo = table.Column<int>(name: "SIST02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST02_Zona", x => x.SIST02Llave);
                });

            migrationBuilder.CreateTable(
                name: "SIST04_Region",
                columns: table => new
                {
                    SIST04Llave = table.Column<decimal>(name: "SIST04_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST04Nombre = table.Column<string>(name: "SIST04_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SIST04Descripcion = table.Column<string>(name: "SIST04_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST04Orden = table.Column<decimal>(name: "SIST04_Orden", type: "numeric(18,0)", nullable: true),
                    SIST04Activo = table.Column<int>(name: "SIST04_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST04_Region", x => x.SIST04Llave);
                });

            migrationBuilder.CreateTable(
                name: "SIST05_EstadoRegistro",
                columns: table => new
                {
                    SIST05Llave = table.Column<int>(name: "SIST05_Llave", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST05Nombre = table.Column<string>(name: "SIST05_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST03Descripcion = table.Column<string>(name: "SIST03_Descripcion", type: "nvarchar(max)", nullable: true),
                    SIST03Activo = table.Column<int>(name: "SIST03_Activo", type: "int", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST05_EstadoRegistro", x => x.SIST05Llave);
                });

            migrationBuilder.CreateTable(
                name: "SIST06_EstadoGrid",
                columns: table => new
                {
                    SIST06Llave = table.Column<decimal>(name: "SIST06_Llave", type: "numeric(18,0)", nullable: false),
                    SIST06Nombre = table.Column<string>(name: "SIST06_Nombre", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SIST06Activo = table.Column<int>(name: "SIST06_Activo", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST06_EstadoGrid", x => x.SIST06Llave);
                });

            migrationBuilder.CreateTable(
                name: "TEMP02_TemporadaBase",
                columns: table => new
                {
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMP02Nombre = table.Column<string>(name: "TEMP02_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TEMP02Descripcion = table.Column<string>(name: "TEMP02_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TEMP02Predeterminada = table.Column<int>(name: "TEMP02_Predeterminada", type: "int", nullable: true),
                    TEMP02Activo = table.Column<int>(name: "TEMP02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEMP02_TemporadaBase", x => x.TEMP02Llave);
                });

            migrationBuilder.CreateTable(
                name: "TEMP03_Segmentacion",
                columns: table => new
                {
                    TEMP03Llave = table.Column<decimal>(name: "TEMP03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMP03Nombre = table.Column<string>(name: "TEMP03_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TEMP03Descripcion = table.Column<string>(name: "TEMP03_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TEMP03NumeroMeses = table.Column<int>(name: "TEMP03_NumeroMeses", type: "int", nullable: true),
                    TEMP03NumeroSegmentosTotal = table.Column<int>(name: "TEMP03_NumeroSegmentosTotal", type: "int", nullable: true),
                    TEMP03Activo = table.Column<int>(name: "TEMP03_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEMP03_Segmentacion", x => x.TEMP03Llave);
                });

            migrationBuilder.CreateTable(
                name: "TRP03_geocordenadas",
                columns: table => new
                {
                    TRP01Llave = table.Column<decimal>(name: "TRP01_Llave", type: "numeric(18,0)", nullable: false),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: false),
                    x = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    y = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRP03_geocordenadas", x => new { x.TRP01Llave, x.TEMP02Llave });
                });

            migrationBuilder.CreateTable(
                name: "WKF02_TipoFlujo",
                columns: table => new
                {
                    WKF02Llave = table.Column<decimal>(name: "WKF02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF02Nombre = table.Column<string>(name: "WKF02_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WKF02Descripcion = table.Column<string>(name: "WKF02_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF02orden = table.Column<int>(name: "WKF02_orden", type: "int", nullable: true),
                    WKF02Activo = table.Column<int>(name: "WKF02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF02_TipoFlujo", x => x.WKF02Llave);
                });

            migrationBuilder.CreateTable(
                name: "WKF05_TipoPermiso",
                columns: table => new
                {
                    WKF05Llave = table.Column<decimal>(name: "WKF05_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF05Nombre = table.Column<string>(name: "WKF05_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF05Descripcion = table.Column<string>(name: "WKF05_Descripcion", type: "nvarchar(max)", nullable: true),
                    WKF05sigla = table.Column<string>(name: "WKF05_sigla", type: "nvarchar(2)", maxLength: 2, nullable: true),
                    WKF05Activo = table.Column<int>(name: "WKF05_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF05_TipoPerfil", x => x.WKF05Llave);
                });

            migrationBuilder.CreateTable(
                name: "WKF08_Area",
                columns: table => new
                {
                    WFK08Llave = table.Column<decimal>(name: "WFK08_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WFK08Nombre = table.Column<string>(name: "WFK08_Nombre", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WFK08Descripcion = table.Column<string>(name: "WFK08_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WFK08Activo = table.Column<bool>(name: "WFK08_Activo", type: "bit", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WFK08_Area", x => x.WFK08Llave);
                });

            migrationBuilder.CreateTable(
                name: "WKF10_TipoParametro",
                columns: table => new
                {
                    WKF10Llave = table.Column<decimal>(name: "WKF10_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF10Nombre = table.Column<string>(name: "WKF10_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF10Descripcion = table.Column<string>(name: "WKF10_Descripcion", type: "nvarchar(max)", nullable: true),
                    WKF10Activo = table.Column<int>(name: "WKF10_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF10_TipoParametro", x => x.WKF10Llave);
                });

            migrationBuilder.CreateTable(
                name: "BLK01_Bloqueos",
                columns: table => new
                {
                    BLK01Llave = table.Column<decimal>(name: "BLK01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BLK02Llave = table.Column<decimal>(name: "BLK02_Llave", type: "numeric(18,0)", nullable: true),
                    BLK01NombreBloqueo = table.Column<string>(name: "BLK01_NombreBloqueo", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BLK01Descripcion = table.Column<string>(name: "BLK01_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BLK01Permanente = table.Column<int>(name: "BLK01_Permanente", type: "int", nullable: true),
                    BLK01MinDuraciondia = table.Column<int>(name: "BLK01_MinDuraciondia", type: "int", nullable: true),
                    BLK01MaxDuraciondia = table.Column<int>(name: "BLK01_MaxDuraciondia", type: "int", nullable: true),
                    BLK01Activo = table.Column<int>(name: "BLK01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLK01_Bloqueos", x => x.BLK01Llave);
                    table.ForeignKey(
                        name: "FK_BLK01_Bloqueos_BLK02_TipoBloqueo",
                        column: x => x.BLK02Llave,
                        principalTable: "BLK02_TipoBloqueo",
                        principalColumn: "BLK02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CLBR01_Calibracion",
                columns: table => new
                {
                    CLBR01Llave = table.Column<decimal>(name: "CLBR01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERCL01Llave = table.Column<decimal>(name: "SERCL01_Llave", type: "numeric(18,0)", nullable: true),
                    CLBR02Llave = table.Column<decimal>(name: "CLBR02_Llave", type: "numeric(18,0)", nullable: true),
                    CNT01Llave = table.Column<decimal>(name: "CNT01_Llave", type: "numeric(18,0)", nullable: true),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: true),
                    CLBR01Nombre = table.Column<string>(name: "CLBR01_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CLBR01UrlPdf = table.Column<string>(name: "CLBR01_UrlPdf", type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CLBR01Descripcion = table.Column<string>(name: "CLBR01_Descripcion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CLBR01FechaCalibracion = table.Column<DateTime>(name: "CLBR01_FechaCalibracion", type: "datetime", nullable: true),
                    CLBR01Activo = table.Column<int>(name: "CLBR01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLBR01_TipoCalibracion", x => x.CLBR01Llave);
                    table.ForeignKey(
                        name: "FK_CLBR01_Calibracion_CLBR02_TipoCalibracion",
                        column: x => x.CLBR02Llave,
                        principalTable: "CLBR02_TipoCalibracion",
                        principalColumn: "CLBR02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT07_TipoSegmentacion",
                columns: table => new
                {
                    CNT07Llave = table.Column<decimal>(name: "CNT07_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT07Nombre = table.Column<string>(name: "CNT07_Nombre", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT07Descripcion = table.Column<string>(name: "CNT07_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT18Llave = table.Column<decimal>(name: "CNT18_Llave", type: "numeric(18,0)", nullable: true),
                    CNT02Llave = table.Column<decimal>(name: "CNT02_Llave", type: "numeric(18,0)", nullable: true),
                    CNT07Activo = table.Column<int>(name: "CNT07_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT07_TipoSegmentacion", x => x.CNT07Llave);
                    table.ForeignKey(
                        name: "FK_CNT07_TipoSegmentacion_CNT18_NivelSegmentacion",
                        column: x => x.CNT18Llave,
                        principalTable: "CNT18_NivelSegmentacion",
                        principalColumn: "CNT18_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CONT01_Contacto",
                columns: table => new
                {
                    CONT01Llave = table.Column<decimal>(name: "CONT01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONT02Llave = table.Column<decimal>(name: "CONT02_Llave", type: "numeric(18,0)", nullable: true),
                    CONT01Titulo = table.Column<decimal>(name: "CONT01_Titulo", type: "numeric(18,0)", nullable: true),
                    CONT01Nombre = table.Column<string>(name: "CONT01_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONT01Apellido = table.Column<string>(name: "CONT01_Apellido", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONT01Email = table.Column<string>(name: "CONT01_Email", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONT01Direccion = table.Column<string>(name: "CONT01_Direccion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONT01Telefono = table.Column<string>(name: "CONT01_Telefono", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONT01PeticionContacto = table.Column<string>(name: "CONT01_PeticionContacto", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CONT01CodigoValidacion = table.Column<string>(name: "CONT01_CodigoValidacion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONT01_Contacto", x => x.CONT01Llave);
                    table.ForeignKey(
                        name: "FK_CONT01_Contacto_CONT02_TipoContacto",
                        column: x => x.CONT02Llave,
                        principalTable: "CONT02_TipoContacto",
                        principalColumn: "CONT02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CTT01_Contrato",
                columns: table => new
                {
                    CTT01Llave = table.Column<decimal>(name: "CTT01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTT02Llave = table.Column<decimal>(name: "CTT02_Llave", type: "numeric(18,0)", nullable: true),
                    CTT01Nombre = table.Column<string>(name: "CTT01_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CTT01Descripcion = table.Column<string>(name: "CTT01_Descripcion", type: "nvarchar(max)", nullable: true),
                    CTT01ContratoHtml = table.Column<string>(name: "CTT01_ContratoHtml", type: "nvarchar(max)", nullable: true),
                    CTT01Activo = table.Column<int>(name: "CTT01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTT01_Contrato", x => x.CTT01Llave);
                    table.ForeignKey(
                        name: "FK_CTT01_Contrato_CTT02_TipoContrato",
                        column: x => x.CTT02Llave,
                        principalTable: "CTT02_TipoContrato",
                        principalColumn: "CTT02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "EML02_MailBase",
                columns: table => new
                {
                    EML02Llave = table.Column<decimal>(name: "EML02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EML03Llave = table.Column<decimal>(name: "EML03_Llave", type: "numeric(18,0)", nullable: true),
                    EML02CodigoLlamado = table.Column<string>(name: "EML02_CodigoLlamado", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EML02Descripcion = table.Column<string>(name: "EML02_Descripcion", type: "nvarchar(max)", nullable: true),
                    EML02Asunto = table.Column<string>(name: "EML02_Asunto", type: "nvarchar(max)", nullable: true),
                    EML02ContenidoHtml = table.Column<string>(name: "EML02_ContenidoHtml", type: "nvarchar(max)", nullable: true),
                    EML02ContenidoText = table.Column<string>(name: "EML02_ContenidoText", type: "nvarchar(max)", nullable: true),
                    EML02activo = table.Column<int>(name: "EML02_activo", type: "int", nullable: true),
                    EML04Llave = table.Column<decimal>(name: "EML04_Llave", type: "numeric(18,0)", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EML02_MailBase", x => x.EML02Llave);
                    table.ForeignKey(
                        name: "FK_EML02_MailBase_EML03_TipoMailAcciones",
                        column: x => x.EML03Llave,
                        principalTable: "EML03_TipoMailAcciones",
                        principalColumn: "EML03_Llave");
                    table.ForeignKey(
                        name: "FK_EML02_MailBase_EML04_ImportanciaMail",
                        column: x => x.EML04Llave,
                        principalTable: "EML04_ImportanciaMail",
                        principalColumn: "EML04_Llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP04_EstadoDanio",
                columns: table => new
                {
                    ESP04Llave = table.Column<decimal>(name: "ESP04_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP04Nombre = table.Column<string>(name: "ESP04_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP04Descripcion = table.Column<string>(name: "ESP04_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ESP06Llave = table.Column<decimal>(name: "ESP06_Llave", type: "numeric(18,0)", nullable: true),
                    ESP04Activo = table.Column<int>(name: "ESP04_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP04_EstadoDanio", x => x.ESP04Llave);
                    table.ForeignKey(
                        name: "FK_ESP04_EstadoDanio_ESP06_MedidaUmbral",
                        column: x => x.ESP06Llave,
                        principalTable: "ESP06_MedidaUmbral",
                        principalColumn: "ESP06_Llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP03_EspecieBase",
                columns: table => new
                {
                    ESP03Llave = table.Column<decimal>(name: "ESP03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP03Nombre = table.Column<string>(name: "ESP03_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP03Descripcion = table.Column<string>(name: "ESP03_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ESP08llave = table.Column<decimal>(name: "ESP08_llave", type: "numeric(18,0)", nullable: true),
                    ESP03ImgGrande = table.Column<string>(name: "ESP03_ImgGrande", type: "nvarchar(max)", nullable: true),
                    ESP03ImgPequenia = table.Column<string>(name: "ESP03_ImgPequenia", type: "nvarchar(max)", nullable: true),
                    ESP03Union = table.Column<int>(name: "ESP03_Union", type: "int", nullable: true),
                    ESP03EstadoRegistro = table.Column<string>(name: "ESP03_EstadoRegistro", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ESP03Activo = table.Column<int>(name: "ESP03_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP03_EspecieBase", x => x.ESP03Llave);
                    table.ForeignKey(
                        name: "FK_ESP03_EspecieBase_ESP08_TipoBase",
                        column: x => x.ESP08llave,
                        principalTable: "ESP08_TipoBase",
                        principalColumn: "ESP08_Llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP11_ReglaGrafico",
                columns: table => new
                {
                    ESP11Llave = table.Column<decimal>(name: "ESP11_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP03Llave = table.Column<decimal>(name: "ESP03_Llave", type: "numeric(18,0)", nullable: true),
                    ESP10Llave = table.Column<decimal>(name: "ESP10_Llave", type: "numeric(18,0)", nullable: true),
                    ESP11Nombre = table.Column<string>(name: "ESP11_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP11Signo1 = table.Column<string>(name: "ESP11_Signo1", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ESP11Valor1 = table.Column<int>(name: "ESP11_Valor1", type: "int", nullable: true),
                    ESP11Signo2 = table.Column<string>(name: "ESP11_Signo2", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ESP11Valor2 = table.Column<int>(name: "ESP11_Valor2", type: "int", nullable: true),
                    ESP11SignoResultado = table.Column<string>(name: "ESP11_SignoResultado", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ESP11ValorResultado = table.Column<int>(name: "ESP11_ValorResultado", type: "int", nullable: true),
                    ESP11Estado = table.Column<int>(name: "ESP11_Estado", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP11_ReglaGrafico", x => x.ESP11Llave);
                    table.ForeignKey(
                        name: "FK_ESP11_ReglaGrafico_ESP10_TipoRegla",
                        column: x => x.ESP10Llave,
                        principalTable: "ESP10_TipoRegla",
                        principalColumn: "ESP10_Llave");
                });

            migrationBuilder.CreateTable(
                name: "LNC05_valorLicencia",
                columns: table => new
                {
                    LNC05Llave = table.Column<decimal>(name: "LNC05_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LNC01Llave = table.Column<decimal>(name: "LNC01_Llave", type: "numeric(18,0)", nullable: true),
                    LNC05Inicio = table.Column<decimal>(name: "LNC05_Inicio", type: "decimal(18,2)", nullable: true),
                    LNC05Termino = table.Column<decimal>(name: "LNC05_Termino", type: "decimal(18,2)", nullable: true),
                    LNC05Valor = table.Column<decimal>(name: "LNC05_Valor", type: "decimal(18,2)", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC05_valorLicencia", x => x.LNC05Llave);
                    table.ForeignKey(
                        name: "FK_LNC05_valorLicencia_LNC01_Licencias",
                        column: x => x.LNC01Llave,
                        principalTable: "LNC01_Licencias",
                        principalColumn: "LNC01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "LNC06_Cobertura",
                columns: table => new
                {
                    LNC01Llave = table.Column<decimal>(name: "LNC01_Llave", type: "numeric(18,0)", nullable: false),
                    SIST03Llave = table.Column<decimal>(name: "SIST03_Llave", type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC05_Cobertura", x => new { x.LNC01Llave, x.SIST03Llave });
                    table.ForeignKey(
                        name: "FK_LNC06_Cobertura_LNC01_Licencias",
                        column: x => x.LNC01Llave,
                        principalTable: "LNC01_Licencias",
                        principalColumn: "LNC01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "LNC07_Control",
                columns: table => new
                {
                    LNC01Llave = table.Column<decimal>(name: "LNC01_Llave", type: "numeric(18,0)", nullable: false),
                    ESP03Llave = table.Column<decimal>(name: "ESP03_Llave", type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC07_Control", x => new { x.LNC01Llave, x.ESP03Llave });
                    table.ForeignKey(
                        name: "FK_LNC07_Control_LNC01_Licencias",
                        column: x => x.LNC01Llave,
                        principalTable: "LNC01_Licencias",
                        principalColumn: "LNC01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "LOG03_MensajeBitacora",
                columns: table => new
                {
                    LOG03Llave = table.Column<decimal>(name: "LOG03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOG02Llave = table.Column<Guid>(name: "LOG02_Llave", type: "uniqueidentifier", nullable: true),
                    LOG03AccesoRapido = table.Column<string>(name: "LOG03_AccesoRapido", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LOG03Descripcion = table.Column<string>(name: "LOG03_Descripcion", type: "nvarchar(max)", nullable: true),
                    LOG03Mensaje = table.Column<string>(name: "LOG03_Mensaje", type: "nvarchar(max)", nullable: true),
                    LOG03Activo = table.Column<int>(name: "LOG03_Activo", type: "int", nullable: true),
                    LOG03Info = table.Column<string>(name: "LOG03_Info", type: "nvarchar(max)", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG03_MensajeBitacora", x => x.LOG03Llave);
                    table.ForeignKey(
                        name: "FK_LOG03_MensajeBitacora_LOG02_TipoBitacora",
                        column: x => x.LOG02Llave,
                        principalTable: "LOG02_TipoBitacora",
                        principalColumn: "LOG02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "MNT01_Monitores",
                columns: table => new
                {
                    MNT01Llave = table.Column<decimal>(name: "MNT01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER01Llave = table.Column<decimal>(name: "PER01_Llave", type: "numeric(18,0)", nullable: true),
                    MNT04Llave = table.Column<decimal>(name: "MNT04_Llave", type: "numeric(18,0)", nullable: true),
                    MNT01Cargo = table.Column<string>(name: "MNT01_Cargo", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MNT01iniciolabores = table.Column<DateTime>(name: "MNT01_iniciolabores", type: "datetime", nullable: true),
                    MNT01Activo = table.Column<int>(name: "MNT01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MNT01_Monitores", x => x.MNT01Llave);
                    table.ForeignKey(
                        name: "FK_MNT01_Monitores_MNT04_TipoMonitor",
                        column: x => x.MNT04Llave,
                        principalTable: "MNT04_TipoMonitor",
                        principalColumn: "MNT04_Llave");
                });

            migrationBuilder.CreateTable(
                name: "PBCD01_Publicidad",
                columns: table => new
                {
                    PBCD01Llave = table.Column<decimal>(name: "PBCD01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PBCD02Llave = table.Column<decimal>(name: "PBCD02_Llave", type: "numeric(18,0)", nullable: true),
                    PBCD01Objetico = table.Column<string>(name: "PBCD01_Objetico", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01FrasePrincipal = table.Column<string>(name: "PBCD01_FrasePrincipal", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01FraseSecundaria = table.Column<string>(name: "PBCD01_FraseSecundaria", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01SecuenciaHtml = table.Column<string>(name: "PBCD01_SecuenciaHtml", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01ImagenNombre = table.Column<string>(name: "PBCD01_ImagenNombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01Producto = table.Column<string>(name: "PBCD01_Producto", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01Problema = table.Column<string>(name: "PBCD01_Problema", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01Activo = table.Column<int>(name: "PBCD01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PBCD01_Publicidad", x => x.PBCD01Llave);
                    table.ForeignKey(
                        name: "FK_PBCD01_Publicidad_PBCD02_TipoPublicidad",
                        column: x => x.PBCD02Llave,
                        principalTable: "PBCD02_TipoPublicidad",
                        principalColumn: "PBCD02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "SIST08_ContactoUsuario",
                columns: table => new
                {
                    SIST08Llave = table.Column<decimal>(name: "SIST08_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER02Llave = table.Column<decimal>(name: "PER02_Llave", type: "numeric(18,0)", nullable: true),
                    SIST08Nombre = table.Column<string>(name: "SIST08_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SIST08Empresa = table.Column<string>(name: "SIST08_Empresa", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SIST08Correo = table.Column<string>(name: "SIST08_Correo", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SIST08Comentario = table.Column<string>(name: "SIST08_Comentario", type: "nvarchar(max)", nullable: true),
                    SIST08Telefono = table.Column<string>(name: "SIST08_Telefono", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SIST08Celular = table.Column<string>(name: "SIST08_Celular", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SIST08Estado = table.Column<int>(name: "SIST08_Estado", type: "int", nullable: true),
                    SIST08FECHACREACION = table.Column<DateTime>(name: "SIST08_FECHACREACION", type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST08_ContactoUsuario", x => x.SIST08Llave);
                    table.ForeignKey(
                        name: "FK_SIST08_ContactoUsuario_PER02_Genero",
                        column: x => x.PER02Llave,
                        principalTable: "PER02_Genero",
                        principalColumn: "PER02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT03_TipoCliente",
                columns: table => new
                {
                    CNT03Llave = table.Column<decimal>(name: "CNT03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER03Llave = table.Column<decimal>(name: "PER03_Llave", type: "numeric(18,0)", nullable: true),
                    CNT03Nombre = table.Column<string>(name: "CNT03_Nombre", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT03Descripcion = table.Column<string>(name: "CNT03_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT03Activo = table.Column<decimal>(name: "CNT03_Activo", type: "numeric(18,0)", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT03_TipoCliente", x => x.CNT03Llave);
                    table.ForeignKey(
                        name: "FK_CNT03_TipoCliente_PER03_TipoPersona",
                        column: x => x.PER03Llave,
                        principalTable: "PER03_TipoPersona",
                        principalColumn: "PER03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "PER01_Persona",
                columns: table => new
                {
                    PER01Llave = table.Column<decimal>(name: "PER01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER01Rut = table.Column<decimal>(name: "PER01_Rut", type: "numeric(18,0)", nullable: true),
                    PER03Llave = table.Column<decimal>(name: "PER03_Llave", type: "numeric(18,0)", nullable: true),
                    PER02Llave = table.Column<decimal>(name: "PER02_Llave", type: "numeric(18,0)", nullable: true),
                    PER01NombreRazon = table.Column<string>(name: "PER01_NombreRazon", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER01NombreFantasia = table.Column<string>(name: "PER01_NombreFantasia", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER01Giro = table.Column<string>(name: "PER01_Giro", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER01Cargo = table.Column<string>(name: "PER01_Cargo", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER01FechaNacimiento = table.Column<DateTime>(name: "PER01_FechaNacimiento", type: "datetime", nullable: true),
                    PER01AnioIngreso = table.Column<decimal>(name: "PER01_AnioIngreso", type: "numeric(18,0)", nullable: true),
                    PER01Activo = table.Column<int>(name: "PER01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER01_Persona", x => x.PER01Llave);
                    table.ForeignKey(
                        name: "FK_PER01_Persona_PER02_Genero",
                        column: x => x.PER02Llave,
                        principalTable: "PER02_Genero",
                        principalColumn: "PER02_Llave");
                    table.ForeignKey(
                        name: "FK_PER01_Persona_PER03_TipoPersona",
                        column: x => x.PER03Llave,
                        principalTable: "PER03_TipoPersona",
                        principalColumn: "PER03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "PER06_TipoPersonaComunicacion",
                columns: table => new
                {
                    PER03Llave = table.Column<decimal>(name: "PER03_Llave", type: "numeric(18,0)", nullable: false),
                    PER04Llave = table.Column<decimal>(name: "PER04_Llave", type: "numeric(18,0)", nullable: false),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER06_TipoPersonaComunicacion", x => new { x.PER03Llave, x.PER04Llave });
                    table.ForeignKey(
                        name: "FK_PER06_TipoPersonaComunicacion_PER03_TipoPersona",
                        column: x => x.PER03Llave,
                        principalTable: "PER03_TipoPersona",
                        principalColumn: "PER03_Llave");
                    table.ForeignKey(
                        name: "FK_PER06_TipoPersonaComunicacion_PER04_TipoComunicacion",
                        column: x => x.PER04Llave,
                        principalTable: "PER04_TipoComunicacion",
                        principalColumn: "PER04_Llave");
                });

            migrationBuilder.CreateTable(
                name: "SECU02_Usuario",
                columns: table => new
                {
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SECU02Usuario = table.Column<string>(name: "SECU02_Usuario", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SECU02Clave = table.Column<string>(name: "SECU02_Clave", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SECU02ComplementoClave = table.Column<string>(name: "SECU02_ComplementoClave", type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SECU04TipoEncriptacion = table.Column<Guid>(name: "SECU04_TipoEncriptacion", type: "uniqueidentifier", nullable: true),
                    SECU02Movil = table.Column<string>(name: "SECU02_Movil", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SECU02Email = table.Column<string>(name: "SECU02_Email", type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SECU02Pregunta = table.Column<string>(name: "SECU02_Pregunta", type: "nvarchar(max)", nullable: true),
                    SECU02Respuesta = table.Column<string>(name: "SECU02_Respuesta", type: "nvarchar(600)", maxLength: 600, nullable: true),
                    SECU02Bloqueado = table.Column<bool>(name: "SECU02_Bloqueado", type: "bit", nullable: true, defaultValueSql: "((0))"),
                    SECU02FechaBloqueo = table.Column<DateTime>(name: "SECU02_FechaBloqueo", type: "datetime", nullable: true),
                    SECU02FechaCambioPass = table.Column<DateTime>(name: "SECU02_FechaCambioPass", type: "datetime", nullable: true),
                    SECU02Activo = table.Column<bool>(name: "SECU02_Activo", type: "bit", nullable: true, defaultValueSql: "((1))"),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SECU02_U__B709E3CA34F4CE22", x => x.SECU02Llave);
                    table.ForeignKey(
                        name: "FK_SECU02_Usuario_SECU04_TipoEncriptacion1",
                        column: x => x.SECU04TipoEncriptacion,
                        principalTable: "SECU04_TipoEncriptacion",
                        principalColumn: "SECU04_Llave");
                });

            migrationBuilder.CreateTable(
                name: "SERCL02_MuestreoFruta",
                columns: table => new
                {
                    SERCL02Llave = table.Column<decimal>(name: "SERCL02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERCL01Llave = table.Column<decimal>(name: "SERCL01_Llave", type: "numeric(18,0)", nullable: true),
                    SERCL02Nombre = table.Column<string>(name: "SERCL02_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SERCL02UrlPdf = table.Column<string>(name: "SERCL02_UrlPdf", type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SERCL02Fecha = table.Column<DateTime>(name: "SERCL02_Fecha", type: "datetime", nullable: true),
                    SERCL02Activo = table.Column<int>(name: "SERCL02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERCL02_MuestreoFruta", x => x.SERCL02Llave);
                    table.ForeignKey(
                        name: "FK_SERCL02_MuestreoFruta_SERCL01_ServiciosClientes",
                        column: x => x.SERCL01Llave,
                        principalTable: "SERCL01_ServiciosClientes",
                        principalColumn: "SERCL01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "SERV01_Servicio",
                columns: table => new
                {
                    SERV01Llave = table.Column<decimal>(name: "SERV01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERV02llave = table.Column<decimal>(name: "SERV02_llave", type: "numeric(18,0)", nullable: true),
                    SERV01Nombre = table.Column<string>(name: "SERV01_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SERV01Descripcion = table.Column<string>(name: "SERV01_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SERV01Activo = table.Column<int>(name: "SERV01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERV01_Servicio", x => x.SERV01Llave);
                    table.ForeignKey(
                        name: "FK_SERV01_Servicio_SERV02_TipoServicio",
                        column: x => x.SERV02llave,
                        principalTable: "SERV02_TipoServicio",
                        principalColumn: "SERV02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "SIST03_Comuna",
                columns: table => new
                {
                    SIST03Llave = table.Column<decimal>(name: "SIST03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST04Llave = table.Column<decimal>(name: "SIST04_Llave", type: "numeric(18,0)", nullable: true),
                    SIST03Nombre = table.Column<string>(name: "SIST03_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SIST03Descripcion = table.Column<string>(name: "SIST03_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST03Capital = table.Column<int>(name: "SIST03_Capital", type: "int", nullable: true),
                    SIST03Activo = table.Column<int>(name: "SIST03_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST03_Comuna", x => x.SIST03Llave);
                    table.ForeignKey(
                        name: "FK_SIST03_Comuna_SIST04_Region",
                        column: x => x.SIST04Llave,
                        principalTable: "SIST04_Region",
                        principalColumn: "SIST04_Llave");
                });

            migrationBuilder.CreateTable(
                name: "INS02_RecuperarClave",
                columns: table => new
                {
                    INS02Llave = table.Column<decimal>(name: "INS02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: true),
                    INS02ClaveTemporal = table.Column<string>(name: "INS02_ClaveTemporal", type: "nvarchar(10)", maxLength: 10, nullable: true),
                    INS02FechaRecupera = table.Column<DateTime>(name: "INS02_FechaRecupera", type: "datetime", nullable: true),
                    INS02Estado = table.Column<int>(name: "INS02_Estado", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INS02_RecuperarClave", x => x.INS02Llave);
                    table.ForeignKey(
                        name: "FK_INS02_RecuperarClave_SIST05_EstadoRegistro",
                        column: x => x.INS02Estado,
                        principalTable: "SIST05_EstadoRegistro",
                        principalColumn: "SIST05_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CONTEO01_Conteos",
                columns: table => new
                {
                    CONTEO01Llave = table.Column<decimal>(name: "CONTEO01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRP01Llave = table.Column<decimal>(name: "TRP01_Llave", type: "numeric(18,0)", nullable: true),
                    CONTEO01Valor = table.Column<decimal>(name: "CONTEO01_Valor", type: "numeric(18,0)", nullable: true),
                    CONTEO01FechaIngreso = table.Column<DateTime>(name: "CONTEO01_FechaIngreso", type: "datetime", nullable: true),
                    CONTEO01HoraIngreso = table.Column<DateTime>(name: "CONTEO01_HoraIngreso", type: "datetime", nullable: true),
                    CONTEO01EstadoVisado = table.Column<int>(name: "CONTEO01_EstadoVisado", type: "int", nullable: true),
                    CONTEO01x = table.Column<string>(name: "CONTEO01_x", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CONTEO01y = table.Column<string>(name: "CONTEO01_y", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CONTEO01observacion = table.Column<string>(name: "CONTEO01_observacion", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CONTEO01EstadoConteo = table.Column<int>(name: "CONTEO01_EstadoConteo", type: "int", nullable: true),
                    CONTEO01TipoSistema = table.Column<decimal>(name: "CONTEO01_TipoSistema", type: "numeric(18,0)", nullable: true),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: true),
                    MVL01Llave = table.Column<string>(name: "MVL01_Llave", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHACREACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTEO01_Conteos", x => x.CONTEO01Llave);
                    table.ForeignKey(
                        name: "FK_CONTEO01_Conteos_TEMP02_TemporadaBase",
                        column: x => x.TEMP02Llave,
                        principalTable: "TEMP02_TemporadaBase",
                        principalColumn: "TEMP02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "OBSC01_ObservacionCampo",
                columns: table => new
                {
                    OBSC01Llave = table.Column<decimal>(name: "OBSC01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP08Llave = table.Column<decimal>(name: "ESP08_Llave", type: "numeric(18,0)", nullable: true),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: true),
                    OBSC01Nombre = table.Column<string>(name: "OBSC01_Nombre", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OBSC01Resumen = table.Column<string>(name: "OBSC01_Resumen", type: "nchar(1000)", fixedLength: true, maxLength: 1000, nullable: true),
                    OBSC01Activo = table.Column<int>(name: "OBSC01_Activo", type: "int", nullable: true),
                    OBSC01FechaObservacion = table.Column<DateTime>(name: "OBSC01_FechaObservacion", type: "datetime", nullable: true),
                    OBSC01UrlPdf = table.Column<string>(name: "OBSC01_UrlPdf", type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OBSC01interesado = table.Column<int>(name: "OBSC01_interesado", type: "int", nullable: true, defaultValueSql: "((0))"),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OBSC01_ObservacionCampo", x => x.OBSC01Llave);
                    table.ForeignKey(
                        name: "FK_OBSC01_ObservacionCampo_ESP08_TipoBase",
                        column: x => x.ESP08Llave,
                        principalTable: "ESP08_TipoBase",
                        principalColumn: "ESP08_Llave");
                    table.ForeignKey(
                        name: "FK_OBSC01_ObservacionCampo_TEMP02_TemporadaBase",
                        column: x => x.TEMP02Llave,
                        principalTable: "TEMP02_TemporadaBase",
                        principalColumn: "TEMP02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "TEMP01_Temporada",
                columns: table => new
                {
                    TEMP01Llave = table.Column<decimal>(name: "TEMP01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMP01Nombre = table.Column<string>(name: "TEMP01_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TEMP01Descripcion = table.Column<string>(name: "TEMP01_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: true),
                    TEMP03Llave = table.Column<decimal>(name: "TEMP03_Llave", type: "numeric(18,0)", nullable: true),
                    TEMP01MinFecha = table.Column<DateTime>(name: "TEMP01_MinFecha", type: "datetime", nullable: true),
                    TEMP01MaxFecha = table.Column<DateTime>(name: "TEMP01_MaxFecha", type: "datetime", nullable: true),
                    TEMP01MinMes = table.Column<int>(name: "TEMP01_MinMes", type: "int", nullable: true),
                    TEMP01MaxMes = table.Column<int>(name: "TEMP01_MaxMes", type: "int", nullable: true),
                    TEMP01Periodo = table.Column<int>(name: "TEMP01_Periodo", type: "int", nullable: true),
                    TEMP01Activo = table.Column<int>(name: "TEMP01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEMP01_Temporada", x => x.TEMP01Llave);
                    table.ForeignKey(
                        name: "FK_TEMP01_Temporada_TEMP02_TemporadaBase",
                        column: x => x.TEMP02Llave,
                        principalTable: "TEMP02_TemporadaBase",
                        principalColumn: "TEMP02_Llave");
                    table.ForeignKey(
                        name: "FK_TEMP01_Temporada_TEMP03_Segmentacion",
                        column: x => x.TEMP03Llave,
                        principalTable: "TEMP03_Segmentacion",
                        principalColumn: "TEMP03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "WKF03_Nivel",
                columns: table => new
                {
                    WKF03Llave = table.Column<decimal>(name: "WKF03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF02Llave = table.Column<decimal>(name: "WKF02_Llave", type: "numeric(18,0)", nullable: true),
                    WKF03Nombre = table.Column<string>(name: "WKF03_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WKF03Descripcion = table.Column<string>(name: "WKF03_Descripcion", type: "nvarchar(max)", nullable: true),
                    WKF03Activo = table.Column<int>(name: "WKF03_Activo", type: "int", nullable: true),
                    WKF03Nivel = table.Column<int>(name: "WKF03_Nivel", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF03_Nivel", x => x.WKF03Llave);
                    table.ForeignKey(
                        name: "FK_WKF03_Nivel_WKF02_TipoFlujo",
                        column: x => x.WKF02Llave,
                        principalTable: "WKF02_TipoFlujo",
                        principalColumn: "WKF02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "BLK03_BloqueoUsuario",
                columns: table => new
                {
                    BLK03Llave = table.Column<decimal>(name: "BLK03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BLK01Llave = table.Column<decimal>(name: "BLK01_Llave", type: "numeric(18,0)", nullable: true),
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: true),
                    BLK03FechaInicio = table.Column<DateTime>(name: "BLK03_FechaInicio", type: "datetime", nullable: true),
                    BLK03FechaTermino = table.Column<DateTime>(name: "BLK03_FechaTermino", type: "datetime", nullable: true),
                    BLK03Activo = table.Column<int>(name: "BLK03_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLK03_BloqueoUsuario", x => x.BLK03Llave);
                    table.ForeignKey(
                        name: "FK_BLK03_BloqueoUsuario_BLK01_Bloqueos",
                        column: x => x.BLK01Llave,
                        principalTable: "BLK01_Bloqueos",
                        principalColumn: "BLK01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "LNC03_LicenciaContrato",
                columns: table => new
                {
                    LNC01Llave = table.Column<decimal>(name: "LNC01_Llave", type: "numeric(18,0)", nullable: false),
                    CTT01Llave = table.Column<decimal>(name: "CTT01_Llave", type: "numeric(18,0)", nullable: false),
                    LNC03FirmaSimpre = table.Column<int>(name: "LNC03_FirmaSimpre", type: "int", nullable: true),
                    LNC03Activo = table.Column<int>(name: "LNC03_Activo", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC03_LicenciaContrato_1", x => new { x.LNC01Llave, x.CTT01Llave });
                    table.ForeignKey(
                        name: "FK_LNC03_LicenciaContrato_CTT01_Contrato",
                        column: x => x.CTT01Llave,
                        principalTable: "CTT01_Contrato",
                        principalColumn: "CTT01_Llave");
                    table.ForeignKey(
                        name: "FK_LNC03_LicenciaContrato_LNC01_Licencias",
                        column: x => x.LNC01Llave,
                        principalTable: "LNC01_Licencias",
                        principalColumn: "LNC01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP01_Especies",
                columns: table => new
                {
                    ESP01Llave = table.Column<decimal>(name: "ESP01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP03Llave = table.Column<decimal>(name: "ESP03_Llave", type: "numeric(18,0)", nullable: true),
                    ESP04Llave = table.Column<decimal>(name: "ESP04_Llave", type: "numeric(18,0)", nullable: true),
                    ESP01Activo = table.Column<int>(name: "ESP01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP01_Especies", x => x.ESP01Llave);
                    table.ForeignKey(
                        name: "FK_ESP01_Especies_ESP03_EspecieBase",
                        column: x => x.ESP03Llave,
                        principalTable: "ESP03_EspecieBase",
                        principalColumn: "ESP03_Llave");
                    table.ForeignKey(
                        name: "FK_ESP01_Especies_ESP04_EstadoDanio",
                        column: x => x.ESP04Llave,
                        principalTable: "ESP04_EstadoDanio",
                        principalColumn: "ESP04_Llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP07_Union",
                columns: table => new
                {
                    ESP03Llave = table.Column<decimal>(name: "ESP03_Llave", type: "numeric(18,0)", nullable: false),
                    ESP03LlaveUnion = table.Column<decimal>(name: "ESP03_LlaveUnion", type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP07_Union", x => new { x.ESP03Llave, x.ESP03LlaveUnion });
                    table.ForeignKey(
                        name: "FK_ESP07_Union_ESP03_EspecieBase",
                        column: x => x.ESP03Llave,
                        principalTable: "ESP03_EspecieBase",
                        principalColumn: "ESP03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "LOG01_Bitacora",
                columns: table => new
                {
                    LOG01Llave = table.Column<decimal>(name: "LOG01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOG03Llave = table.Column<decimal>(name: "LOG03_Llave", type: "numeric(18,0)", nullable: true),
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: true),
                    LOG01Contenido = table.Column<string>(name: "LOG01_Contenido", type: "nvarchar(max)", nullable: true),
                    LOG01objeto = table.Column<decimal>(name: "LOG01_objeto", type: "numeric(18,0)", nullable: true),
                    LOG01Clase = table.Column<string>(name: "LOG01_Clase", type: "nvarchar(max)", nullable: true),
                    LOG01elementoserializado = table.Column<byte[]>(name: "LOG01_elemento_serializado", type: "varbinary(max)", nullable: true),
                    LOG01Info = table.Column<string>(name: "LOG01_Info", type: "nvarchar(max)", nullable: true),
                    LOG01Activo = table.Column<int>(name: "LOG01_Activo", type: "int", nullable: true, defaultValueSql: "((1))"),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG01_Bitacora", x => x.LOG01Llave);
                    table.ForeignKey(
                        name: "FK_LOG01_Bitacora_LOG03_MensajeBitacora",
                        column: x => x.LOG03Llave,
                        principalTable: "LOG03_MensajeBitacora",
                        principalColumn: "LOG03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "MNT03_PeriodosTrampas",
                columns: table => new
                {
                    MNT01Llave = table.Column<decimal>(name: "MNT01_Llave", type: "numeric(18,0)", nullable: false),
                    TRP01Llave = table.Column<decimal>(name: "TRP01_Llave", type: "numeric(18,0)", nullable: false),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: false),
                    MNT03Activo = table.Column<int>(name: "MNT03_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MNT02_EspeciesAsignadas", x => new { x.MNT01Llave, x.TRP01Llave, x.TEMP02Llave });
                    table.ForeignKey(
                        name: "FK_MNT03_PeriodosTrampas_MNT01_Monitores",
                        column: x => x.MNT01Llave,
                        principalTable: "MNT01_Monitores",
                        principalColumn: "MNT01_Llave");
                    table.ForeignKey(
                        name: "FK_MNT03_PeriodosTrampas_TEMP02_TemporadaBase",
                        column: x => x.TEMP02Llave,
                        principalTable: "TEMP02_TemporadaBase",
                        principalColumn: "TEMP02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "PBCD03_Programacion",
                columns: table => new
                {
                    PBCD03Llave = table.Column<decimal>(name: "PBCD03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PBCD01Llave = table.Column<decimal>(name: "PBCD01_Llave", type: "numeric(18,0)", nullable: true),
                    PBCD03InicioFecha = table.Column<DateTime>(name: "PBCD03_InicioFecha", type: "datetime", nullable: true),
                    PBCD03TerminoFecha = table.Column<DateTime>(name: "PBCD03_TerminoFecha", type: "datetime", nullable: true),
                    PBCD03Activo = table.Column<int>(name: "PBCD03_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PBCD03_Programacion", x => x.PBCD03Llave);
                    table.ForeignKey(
                        name: "FK_PBCD03_Programacion_PBCD01_Publicidad",
                        column: x => x.PBCD01Llave,
                        principalTable: "PBCD01_Publicidad",
                        principalColumn: "PBCD01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT01_CuentaCliente",
                columns: table => new
                {
                    CNT01Llave = table.Column<decimal>(name: "CNT01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT02Llave = table.Column<decimal>(name: "CNT02_Llave", type: "numeric(18,0)", nullable: true),
                    PER01Llave = table.Column<decimal>(name: "PER01_Llave", type: "numeric(18,0)", nullable: true),
                    CNT01Nombre = table.Column<string>(name: "CNT01_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT03Llave = table.Column<decimal>(name: "CNT03_Llave", type: "numeric(18,0)", nullable: true),
                    CNT01CuentaSap = table.Column<int>(name: "CNT01_CuentaSap", type: "int", nullable: true),
                    CNT01NumeroSap = table.Column<int>(name: "CNT01_NumeroSap", type: "int", nullable: true),
                    CNT01FechaIngresoSap = table.Column<DateTime>(name: "CNT01_FechaIngresoSap", type: "datetime", nullable: true),
                    CNT01anioIngreso = table.Column<DateTime>(name: "CNT01_anioIngreso", type: "date", nullable: true),
                    CNT01Activo = table.Column<int>(name: "CNT01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT01_CuentaCliente", x => x.CNT01Llave);
                    table.ForeignKey(
                        name: "FK_CNT01_CuentaCliente_CNT02_TipoCuenta",
                        column: x => x.CNT02Llave,
                        principalTable: "CNT02_TipoCuenta",
                        principalColumn: "CNT02_Llave");
                    table.ForeignKey(
                        name: "FK_CNT01_CuentaCliente_CNT03_TipoCliente",
                        column: x => x.CNT03Llave,
                        principalTable: "CNT03_TipoCliente",
                        principalColumn: "CNT03_Llave");
                    table.ForeignKey(
                        name: "FK_CNT01_CuentaCliente_PER01_Persona",
                        column: x => x.PER01Llave,
                        principalTable: "PER01_Persona",
                        principalColumn: "PER01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "PER07_PersonaUsuario",
                columns: table => new
                {
                    PER07Llave = table.Column<decimal>(name: "PER07_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER01Llave = table.Column<decimal>(name: "PER01_Llave", type: "numeric(18,0)", nullable: true),
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: true),
                    PER07Activo = table.Column<int>(name: "PER07_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER07_PersonaUsuario", x => x.PER07Llave);
                    table.ForeignKey(
                        name: "FK_PER07_PersonaUsuario_PER01_Persona",
                        column: x => x.PER01Llave,
                        principalTable: "PER01_Persona",
                        principalColumn: "PER01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "PER05_Comunicacion",
                columns: table => new
                {
                    PER01Llave = table.Column<decimal>(name: "PER01_Llave", type: "numeric(18,0)", nullable: false),
                    PER04Llave = table.Column<decimal>(name: "PER04_Llave", type: "numeric(18,0)", nullable: false),
                    PER03Llave = table.Column<decimal>(name: "PER03_Llave", type: "numeric(18,0)", nullable: false),
                    PER05Direccion = table.Column<string>(name: "PER05_Direccion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST03Llave = table.Column<decimal>(name: "SIST03_Llave", type: "numeric(18,0)", nullable: true),
                    PER05casilla = table.Column<string>(name: "PER05_casilla", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER05TieneCasilla = table.Column<int>(name: "PER05_TieneCasilla", type: "int", nullable: true),
                    PER05CodigoPostal = table.Column<string>(name: "PER05_CodigoPostal", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER05Email = table.Column<string>(name: "PER05_Email", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PER05Telefono1 = table.Column<string>(name: "PER05_Telefono1", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER05Telefono2 = table.Column<string>(name: "PER05_Telefono2", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER05Celular1 = table.Column<string>(name: "PER05_Celular1", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER05Celular2 = table.Column<string>(name: "PER05_Celular2", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER05Fax = table.Column<string>(name: "PER05_Fax", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER05SitioWeb = table.Column<string>(name: "PER05_SitioWeb", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER05_Comunicacion", x => new { x.PER01Llave, x.PER04Llave, x.PER03Llave });
                    table.ForeignKey(
                        name: "FK_PER05_Comunicacion_PER01_Persona",
                        column: x => x.PER01Llave,
                        principalTable: "PER01_Persona",
                        principalColumn: "PER01_Llave");
                    table.ForeignKey(
                        name: "FK_PER05_Comunicacion_PER03_TipoPersona",
                        column: x => x.PER03Llave,
                        principalTable: "PER03_TipoPersona",
                        principalColumn: "PER03_Llave");
                    table.ForeignKey(
                        name: "FK_PER05_Comunicacion_PER04_TipoComunicacion",
                        column: x => x.PER04Llave,
                        principalTable: "PER04_TipoComunicacion",
                        principalColumn: "PER04_Llave");
                    table.ForeignKey(
                        name: "FK_PER05_Comunicacion_PER06_TipoPersonaComunicacion",
                        columns: x => new { x.PER03Llave, x.PER04Llave },
                        principalTable: "PER06_TipoPersonaComunicacion",
                        principalColumns: new[] { "PER03_Llave", "PER04_Llave" });
                });

            migrationBuilder.CreateTable(
                name: "CONTEO05_Control_Reserva",
                columns: table => new
                {
                    CONTEO05Llave = table.Column<decimal>(name: "CONTEO05_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTEO05tablacontrol = table.Column<string>(name: "CONTEO05_tabla_control", type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CONTEO05columnacontrol = table.Column<string>(name: "CONTEO05_columna_control", type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CONTEO05valorcontrol = table.Column<decimal>(name: "CONTEO05_valor_control", type: "numeric(18,0)", nullable: true),
                    CONTEO05idmovil = table.Column<string>(name: "CONTEO05_id_movil", type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: true),
                    CONTEO05estadocontrol = table.Column<decimal>(name: "CONTEO05_estado_control", type: "numeric(18,0)", nullable: true),
                    CONTEO05Estado = table.Column<bool>(name: "CONTEO05_Estado", type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CONTEO05primer = table.Column<string>(name: "CONTEO05_primer", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CONTEO05segundo = table.Column<string>(name: "CONTEO05_segundo", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CONTEO05tercer = table.Column<string>(name: "CONTEO05_tercer", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CONTEO05fecha = table.Column<DateTime>(name: "CONTEO05_fecha", type: "datetime", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTEO05_Control_Reserva", x => x.CONTEO05Llave);
                    table.ForeignKey(
                        name: "FK_CONTEO05_Control_Reserva_SECU02_Usuario",
                        column: x => x.SECU02Llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "EML01_BitacoraEmailUsuario",
                columns: table => new
                {
                    EML01Llave = table.Column<decimal>(name: "EML01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EML02Llave = table.Column<decimal>(name: "EML02_Llave", type: "numeric(18,0)", nullable: true),
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: true),
                    EML01Envio = table.Column<DateTime>(name: "EML01_Envio", type: "datetime", nullable: true),
                    EML01De = table.Column<string>(name: "EML01_De", type: "nvarchar(max)", nullable: true),
                    EML01Para = table.Column<string>(name: "EML01_Para", type: "nvarchar(max)", nullable: true),
                    EML01Asunto = table.Column<string>(name: "EML01_Asunto", type: "nvarchar(max)", nullable: true),
                    EML01Contenido = table.Column<string>(name: "EML01_Contenido", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EML01Text = table.Column<string>(name: "EML01_Text", type: "nvarchar(max)", nullable: true),
                    EML04Llave = table.Column<decimal>(name: "EML04_Llave", type: "numeric(18,0)", nullable: true),
                    EML01Activo = table.Column<decimal>(name: "EML01_Activo", type: "numeric(18,0)", nullable: true),
                    EML01MailPAdre = table.Column<decimal>(name: "EML01_MailPAdre", type: "numeric(18,0)", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EML01_EmailUsuario", x => x.EML01Llave);
                    table.ForeignKey(
                        name: "FK_EML01_BitacoraEmailUsuario_SECU02_Usuario",
                        column: x => x.SECU02Llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_Llave");
                    table.ForeignKey(
                        name: "FK_EML01_EmailUsuario_EML02_MailBase",
                        column: x => x.EML02Llave,
                        principalTable: "EML02_MailBase",
                        principalColumn: "EML02_Llave");
                    table.ForeignKey(
                        name: "FK_EML01_EmailUsuario_EML04_ImportanciaMail",
                        column: x => x.EML04Llave,
                        principalTable: "EML04_ImportanciaMail",
                        principalColumn: "EML04_Llave");
                });

            migrationBuilder.CreateTable(
                name: "PRF01_Perfiles",
                columns: table => new
                {
                    PRF01Llave = table.Column<decimal>(name: "PRF01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRF05llave = table.Column<decimal>(name: "PRF05_llave", type: "numeric(18,0)", nullable: true),
                    SECU02llave = table.Column<Guid>(name: "SECU02_llave", type: "uniqueidentifier", nullable: true),
                    PRF01Activo = table.Column<int>(name: "PRF01_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRF01_Perfiles", x => x.PRF01Llave);
                    table.ForeignKey(
                        name: "FK_PRF01_Perfiles_PRF05_TipoAsignacionUsuario",
                        column: x => x.PRF05llave,
                        principalTable: "PRF05_TipoAsignacionUsuario",
                        principalColumn: "PRF05_Llave");
                    table.ForeignKey(
                        name: "FK_PRF01_Perfiles_SECU02_Usuario",
                        column: x => x.SECU02llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "SECU05_UsuarioAcceso",
                columns: table => new
                {
                    SECU05Llave = table.Column<Guid>(name: "SECU05_Llave", type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: true),
                    SECU03TipoAcceso = table.Column<Guid>(name: "SECU03_TipoAcceso", type: "uniqueidentifier", nullable: true),
                    SECU05LlaveAcceso = table.Column<string>(name: "SECU05_LlaveAcceso", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SECU05SOAcceso = table.Column<string>(name: "SECU05_SOAcceso", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SECU05VersionActual = table.Column<string>(name: "SECU05_VersionActual", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SECU05VersionDescarga = table.Column<string>(name: "SECU05_VersionDescarga", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SECU05ForzarDescarga = table.Column<bool>(name: "SECU05_ForzarDescarga", type: "bit", nullable: true, defaultValueSql: "((0))"),
                    SECU05FechaUltAcceso = table.Column<DateTime>(name: "SECU05_FechaUltAcceso", type: "datetime", nullable: true),
                    SECU05FechaUltActividad = table.Column<DateTime>(name: "SECU05_FechaUltActividad", type: "datetime", nullable: true),
                    SECU05FechaUltDescarga = table.Column<DateTime>(name: "SECU05_FechaUltDescarga", type: "datetime", nullable: true),
                    SECU05Bloqueado = table.Column<bool>(name: "SECU05_Bloqueado", type: "bit", nullable: true, defaultValueSql: "((0))"),
                    SECU05FechaBloqueo = table.Column<DateTime>(name: "SECU05_FechaBloqueo", type: "datetime", nullable: true),
                    SECU05Mensaje = table.Column<string>(name: "SECU05_Mensaje", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SECU05FechaMensaje = table.Column<DateTime>(name: "SECU05_FechaMensaje", type: "datetime", nullable: true),
                    SECU05Info = table.Column<string>(name: "SECU05_Info", type: "xml", nullable: true),
                    SECU05Activo = table.Column<bool>(name: "SECU05_Activo", type: "bit", nullable: true, defaultValueSql: "((1))"),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SECU05_U__2980F8C26FA412CE", x => x.SECU05Llave);
                    table.ForeignKey(
                        name: "FK_SECU05_UsuarioAcceso_SECU02_Usuario",
                        column: x => x.SECU02Llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_Llave");
                    table.ForeignKey(
                        name: "FK_SECU05_UsuarioAcceso_SECU03_TipoAcceso",
                        column: x => x.SECU03TipoAcceso,
                        principalTable: "SECU03_TipoAcceso",
                        principalColumn: "SECU03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "SECU06_UsuarioRol",
                columns: table => new
                {
                    SECU01Llave = table.Column<Guid>(name: "SECU01_Llave", type: "uniqueidentifier", nullable: false),
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: false),
                    SECU06Activo = table.Column<bool>(name: "SECU06_Activo", type: "bit", nullable: true, defaultValueSql: "((1))"),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SECU06_UsuarioRol", x => new { x.SECU01Llave, x.SECU02Llave });
                    table.ForeignKey(
                        name: "FK_SECU06_UsuarioRol_SECU01_Rol",
                        column: x => x.SECU01Llave,
                        principalTable: "SECU01_Rol",
                        principalColumn: "SECU01_Llave");
                    table.ForeignKey(
                        name: "FK_SECU06_UsuarioRol_SECU02_Usuario",
                        column: x => x.SECU02Llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "SECU08_UsuarioAplicacion",
                columns: table => new
                {
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: false),
                    SECU07Llave = table.Column<Guid>(name: "SECU07_Llave", type: "uniqueidentifier", nullable: false),
                    SECU08Info = table.Column<string>(name: "SECU08_Info", type: "xml", nullable: true),
                    SECU08Observacion = table.Column<string>(name: "SECU08_Observacion", type: "nvarchar(max)", nullable: true),
                    SECU08Activo = table.Column<bool>(name: "SECU08_Activo", type: "bit", nullable: true, defaultValueSql: "((1))"),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAplicacion", x => new { x.SECU02Llave, x.SECU07Llave });
                    table.ForeignKey(
                        name: "FK_UsuarioAplicacion_Aplicacion",
                        column: x => x.SECU07Llave,
                        principalTable: "SECU07_Aplicacion",
                        principalColumn: "SECU07_Llave");
                    table.ForeignKey(
                        name: "FK_UsuarioAplicacion_Usuario",
                        column: x => x.SECU02Llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "SECU10_AccesoPermitido",
                columns: table => new
                {
                    SECU10Llave = table.Column<decimal>(name: "SECU10_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SECU02Llave = table.Column<Guid>(name: "SECU02_Llave", type: "uniqueidentifier", nullable: true),
                    SECU03Llave = table.Column<Guid>(name: "SECU03_Llave", type: "uniqueidentifier", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SECU10_AccesoPermitido", x => x.SECU10Llave);
                    table.ForeignKey(
                        name: "FK_SECU10_AccesoPermitido_SECU02_Usuario",
                        column: x => x.SECU02Llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_Llave");
                    table.ForeignKey(
                        name: "FK_SECU10_AccesoPermitido_SECU03_TipoAcceso",
                        column: x => x.SECU03Llave,
                        principalTable: "SECU03_TipoAcceso",
                        principalColumn: "SECU03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "LNC02_ServiciosLicencia",
                columns: table => new
                {
                    LNC01Llave = table.Column<decimal>(name: "LNC01_Llave", type: "numeric(18,0)", nullable: false),
                    SERV01Llave = table.Column<decimal>(name: "SERV01_Llave", type: "numeric(18,0)", nullable: false),
                    LNC02NumeroElemento = table.Column<decimal>(name: "LNC02_NumeroElemento", type: "numeric(18,0)", nullable: true),
                    LNC02EsIlimitado = table.Column<int>(name: "LNC02_EsIlimitado", type: "int", nullable: true),
                    LNC02Activo = table.Column<int>(name: "LNC02_Activo", type: "int", nullable: true),
                    LNC02PermiteComparar = table.Column<int>(name: "LNC02_PermiteComparar", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC02_ServiciosLicencia_1", x => new { x.LNC01Llave, x.SERV01Llave });
                    table.ForeignKey(
                        name: "FK_LNC02_ServiciosLicencia_LNC01_Licencias",
                        column: x => x.LNC01Llave,
                        principalTable: "LNC01_Licencias",
                        principalColumn: "LNC01_Llave");
                    table.ForeignKey(
                        name: "FK_LNC02_ServiciosLicencia_SERV01_Servicio",
                        column: x => x.SERV01Llave,
                        principalTable: "SERV01_Servicio",
                        principalColumn: "SERV01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "SIST07_ZonaComuna",
                columns: table => new
                {
                    Sist02Llave = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Sist03Llave = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST07_ZonaComuna", x => new { x.Sist02Llave, x.Sist03Llave });
                    table.ForeignKey(
                        name: "FK_SIST07_ZonaComuna_SIST02_Zona",
                        column: x => x.Sist02Llave,
                        principalTable: "SIST02_Zona",
                        principalColumn: "SIST02_Llave");
                    table.ForeignKey(
                        name: "FK_SIST07_ZonaComuna_SIST03_Comuna",
                        column: x => x.Sist03Llave,
                        principalTable: "SIST03_Comuna",
                        principalColumn: "SIST03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "WKF01_Flujo",
                columns: table => new
                {
                    WKF01Llave = table.Column<decimal>(name: "WKF01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF01Nombre = table.Column<string>(name: "WKF01_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WKF01Descripcion = table.Column<string>(name: "WKF01_Descripcion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF01LlavePadre = table.Column<decimal>(name: "WKF01_LlavePadre", type: "numeric(18,0)", nullable: true),
                    WKF03Llave = table.Column<decimal>(name: "WKF03_Llave", type: "numeric(18,0)", nullable: true),
                    WKF01EsInicio = table.Column<int>(name: "WKF01_EsInicio", type: "int", nullable: true),
                    WKF01Orden = table.Column<decimal>(name: "WKF01_Orden", type: "numeric(18,0)", nullable: true),
                    WKF01Prioridad = table.Column<decimal>(name: "WKF01_Prioridad", type: "numeric(18,0)", nullable: true),
                    WKF01Activo = table.Column<int>(name: "WKF01_Activo", type: "int", nullable: false),
                    WKF01Directorio = table.Column<string>(name: "WKF01_Directorio", type: "nvarchar(max)", nullable: true),
                    WKF01url = table.Column<string>(name: "WKF01_url", type: "nvarchar(max)", nullable: true),
                    WKF01iconoUrl = table.Column<string>(name: "WKF01_iconoUrl", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF01visibleMenu = table.Column<int>(name: "WKF01_visibleMenu", type: "int", nullable: true),
                    WKF01ImagenGrande = table.Column<string>(name: "WKF01_ImagenGrande", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF01ImagenPequena = table.Column<string>(name: "WKF01_ImagenPequena", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF01estadoRegistro = table.Column<string>(name: "WKF01_estadoRegistro", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF01_Flujo", x => x.WKF01Llave);
                    table.ForeignKey(
                        name: "FK_WKF01_Flujo_WKF03_Nivel",
                        column: x => x.WKF03Llave,
                        principalTable: "WKF03_Nivel",
                        principalColumn: "WKF03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "WKF04_NivelPermiso",
                columns: table => new
                {
                    WKF04Llave = table.Column<decimal>(name: "WKF04_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF03llave = table.Column<decimal>(name: "WKF03_llave", type: "numeric(18,0)", nullable: true),
                    WKF05llave = table.Column<decimal>(name: "WKF05_llave", type: "numeric(18,0)", nullable: true),
                    WKF04Activo = table.Column<int>(name: "WKF04_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF04_NivelPremiso", x => x.WKF04Llave);
                    table.ForeignKey(
                        name: "FK_WKF04_NivelPermiso_WKF03_Nivel",
                        column: x => x.WKF03llave,
                        principalTable: "WKF03_Nivel",
                        principalColumn: "WKF03_Llave");
                    table.ForeignKey(
                        name: "FK_WKF04_NivelPermiso_WKF05_TipoPermiso",
                        column: x => x.WKF05llave,
                        principalTable: "WKF05_TipoPermiso",
                        principalColumn: "WKF05_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CONTEO04_ResumenSag",
                columns: table => new
                {
                    CONTEO04Llave = table.Column<decimal>(name: "CONTEO04_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST03Llave = table.Column<decimal>(name: "SIST03_Llave", type: "numeric(18,0)", nullable: true),
                    ESP01Llave = table.Column<decimal>(name: "ESP01_Llave", type: "numeric(18,0)", nullable: true),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: true),
                    CONTEO04Estado = table.Column<decimal>(name: "CONTEO04_Estado", type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTEO04_ResumenSag", x => x.CONTEO04Llave);
                    table.ForeignKey(
                        name: "FK_CONTEO04_ResumenSag_ESP01_Especies",
                        column: x => x.ESP01Llave,
                        principalTable: "ESP01_Especies",
                        principalColumn: "ESP01_Llave");
                    table.ForeignKey(
                        name: "FK_CONTEO04_ResumenSag_SIST03_Comuna",
                        column: x => x.SIST03Llave,
                        principalTable: "SIST03_Comuna",
                        principalColumn: "SIST03_Llave");
                    table.ForeignKey(
                        name: "FK_CONTEO04_ResumenSag_TEMP02_TemporadaBase",
                        column: x => x.TEMP02Llave,
                        principalTable: "TEMP02_TemporadaBase",
                        principalColumn: "TEMP02_Llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP02_TemporadaEspecie",
                columns: table => new
                {
                    ESP02Llave = table.Column<decimal>(name: "ESP02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP01Llave = table.Column<decimal>(name: "ESP01_Llave", type: "numeric(18,0)", nullable: true),
                    TEMP01Llave = table.Column<decimal>(name: "TEMP01_Llave", type: "numeric(18,0)", nullable: true),
                    ESP02InicioTemporada = table.Column<DateTime>(name: "ESP02_InicioTemporada", type: "datetime", nullable: true),
                    ESP02TerminoTemporada = table.Column<DateTime>(name: "ESP02_TerminoTemporada", type: "datetime", nullable: true),
                    ESP02Sag = table.Column<int>(name: "ESP02_Sag", type: "int", nullable: true),
                    ESP02Mexico = table.Column<int>(name: "ESP02_Mexico", type: "int", nullable: true),
                    ESP02Activo = table.Column<int>(name: "ESP02_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP02_TemporadaEspecie", x => x.ESP02Llave);
                    table.ForeignKey(
                        name: "FK_ESP02_TemporadaEspecie_ESP01_Especies",
                        column: x => x.ESP01Llave,
                        principalTable: "ESP01_Especies",
                        principalColumn: "ESP01_Llave");
                    table.ForeignKey(
                        name: "FK_ESP02_TemporadaEspecie_TEMP01_Temporada",
                        column: x => x.TEMP01Llave,
                        principalTable: "TEMP01_Temporada",
                        principalColumn: "TEMP01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP05_Umbral",
                columns: table => new
                {
                    ESP05LLave = table.Column<decimal>(name: "ESP05_LLave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP01Llave = table.Column<decimal>(name: "ESP01_Llave", type: "numeric(18,0)", nullable: true),
                    ESP05MinUmbral = table.Column<decimal>(name: "ESP05_MinUmbral", type: "numeric(18,3)", nullable: true),
                    ESP05MaxUmbral = table.Column<decimal>(name: "ESP05_MaxUmbral", type: "numeric(18,3)", nullable: true),
                    ESP05Color = table.Column<string>(name: "ESP05_Color", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ESP09Llave = table.Column<decimal>(name: "ESP09_Llave", type: "numeric(18,0)", nullable: true),
                    ESP05Activo = table.Column<int>(name: "ESP05_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP05_Umbral", x => x.ESP05LLave);
                    table.ForeignKey(
                        name: "FK_ESP05_Umbral_ESP01_Especies",
                        column: x => x.ESP01Llave,
                        principalTable: "ESP01_Especies",
                        principalColumn: "ESP01_Llave");
                    table.ForeignKey(
                        name: "FK_ESP05_Umbral_ESP09_TipoBaseUmbral",
                        column: x => x.ESP09Llave,
                        principalTable: "ESP09_TipoBaseUmbral",
                        principalColumn: "ESP09_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT04_ContactoCliente",
                columns: table => new
                {
                    CNT04Llave = table.Column<decimal>(name: "CNT04_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT01Llave = table.Column<decimal>(name: "CNT01_Llave", type: "numeric(18,0)", nullable: false),
                    PER01Llave = table.Column<decimal>(name: "PER01_Llave", type: "numeric(18,0)", nullable: false),
                    CNT05llave = table.Column<decimal>(name: "CNT05_llave", type: "numeric(18,0)", nullable: false),
                    CNT04Activo = table.Column<int>(name: "CNT04_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT04_ContactoCliente_1", x => x.CNT04Llave);
                    table.ForeignKey(
                        name: "FK_CNT04_ContactoCliente_CNT01_CuentaCliente1",
                        column: x => x.CNT01Llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_Llave");
                    table.ForeignKey(
                        name: "FK_CNT04_ContactoCliente_CNT05_TipoContacto",
                        column: x => x.CNT05llave,
                        principalTable: "CNT05_TipoContacto",
                        principalColumn: "CNT05_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT08_Segmentacion",
                columns: table => new
                {
                    CNT08Llave = table.Column<decimal>(name: "CNT08_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT01Llave = table.Column<decimal>(name: "CNT01_Llave", type: "numeric(18,0)", nullable: true),
                    CNT07Llave = table.Column<decimal>(name: "CNT07_Llave", type: "numeric(18,0)", nullable: true),
                    CNT21Llave = table.Column<decimal>(name: "CNT21_Llave", type: "numeric(18,0)", nullable: true, defaultValueSql: "((1))"),
                    CNT08Nombre = table.Column<string>(name: "CNT08_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT08LlavePadre = table.Column<decimal>(name: "CNT08_LlavePadre", type: "numeric(18,0)", nullable: true),
                    SIST03Llave = table.Column<decimal>(name: "SIST03_Llave", type: "numeric(18,0)", nullable: true),
                    CNT08Activo = table.Column<int>(name: "CNT08_Activo", type: "int", nullable: false),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT08_Segmentacion", x => x.CNT08Llave);
                    table.ForeignKey(
                        name: "FK_CNT08_Segmentacion_CNT01_CuentaCliente",
                        column: x => x.CNT01Llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_Llave");
                    table.ForeignKey(
                        name: "FK_CNT08_Segmentacion_CNT07_TipoSegmentacion",
                        column: x => x.CNT07Llave,
                        principalTable: "CNT07_TipoSegmentacion",
                        principalColumn: "CNT07_Llave");
                    table.ForeignKey(
                        name: "FK_CNT08_Segmentacion_CNT08_Segmentacion",
                        column: x => x.CNT08LlavePadre,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT12_Empleados",
                columns: table => new
                {
                    CNT12Llave = table.Column<decimal>(name: "CNT12_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT01Llave = table.Column<decimal>(name: "CNT01_Llave", type: "numeric(18,0)", nullable: true),
                    PER01Llave = table.Column<decimal>(name: "PER01_Llave", type: "numeric(18,0)", nullable: true),
                    CNT08Llave = table.Column<decimal>(name: "CNT08_Llave", type: "numeric(18,0)", nullable: true),
                    CNT13Llave = table.Column<decimal>(name: "CNT13_Llave", type: "numeric(18,0)", nullable: true),
                    CNT12Cargo = table.Column<string>(name: "CNT12_Cargo", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT12Activo = table.Column<int>(name: "CNT12_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT12_Empleados_1", x => x.CNT12Llave);
                    table.ForeignKey(
                        name: "FK_CNT12_Empleados_CNT01_CuentaCliente",
                        column: x => x.CNT01Llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_Llave");
                    table.ForeignKey(
                        name: "FK_CNT12_Empleados_CNT13_TipoEmpleado",
                        column: x => x.CNT13Llave,
                        principalTable: "CNT13_TipoEmpleado",
                        principalColumn: "CNT13_Llave");
                    table.ForeignKey(
                        name: "FK_CNT12_Empleados_PER01_Persona",
                        column: x => x.PER01Llave,
                        principalTable: "PER01_Persona",
                        principalColumn: "PER01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT14_ClienteLicencia",
                columns: table => new
                {
                    CNT14Llave = table.Column<decimal>(name: "CNT14_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT01Llave = table.Column<decimal>(name: "CNT01_Llave", type: "numeric(18,0)", nullable: false),
                    LNC01Llave = table.Column<decimal>(name: "LNC01_Llave", type: "numeric(18,0)", nullable: false),
                    CNT14InicioFecha = table.Column<DateTime>(name: "CNT14_InicioFecha", type: "datetime", nullable: true),
                    CNT14TerminoFecha = table.Column<DateTime>(name: "CNT14_TerminoFecha", type: "datetime", nullable: true),
                    CNT14CantUsuarios = table.Column<int>(name: "CNT14_CantUsuarios", type: "int", nullable: true),
                    CNT14Activo = table.Column<bool>(name: "CNT14_Activo", type: "bit", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT14_ClienteLicencia", x => x.CNT14Llave);
                    table.ForeignKey(
                        name: "FK_CNT14_ClienteLicencia_CNT01_CuentaCliente",
                        column: x => x.CNT01Llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT19_LicenciaCliente",
                columns: table => new
                {
                    CNT19Llave = table.Column<decimal>(name: "CNT19_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT01Llave = table.Column<decimal>(name: "CNT01_Llave", type: "numeric(18,0)", nullable: true),
                    LNC01Llave = table.Column<decimal>(name: "LNC01_Llave", type: "numeric(18,0)", nullable: true),
                    CNT19NombreLicencia = table.Column<string>(name: "CNT19_NombreLicencia", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT19NumeroUsuario = table.Column<int>(name: "CNT19_NumeroUsuario", type: "int", nullable: true),
                    CNT19NumeroDias = table.Column<int>(name: "CNT19_NumeroDias", type: "int", nullable: true),
                    CNT19FechaInicio = table.Column<DateTime>(name: "CNT19_FechaInicio", type: "datetime", nullable: true),
                    CNT19FechaTermino = table.Column<DateTime>(name: "CNT19_FechaTermino", type: "datetime", nullable: true),
                    CNT19Activo = table.Column<int>(name: "CNT19_Activo", type: "int", nullable: true),
                    CNT23Llave = table.Column<decimal>(name: "CNT23_Llave", type: "numeric(18,0)", nullable: true),
                    CNT19valorreferencial = table.Column<decimal>(name: "CNT19_valor_referencial", type: "decimal(18,2)", nullable: true),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT19_LicenciaCliente", x => x.CNT19Llave);
                    table.ForeignKey(
                        name: "FK_CNT19_LicenciaCliente_CNT01_CuentaCliente",
                        column: x => x.CNT01Llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "EML05_ArchivoMail",
                columns: table => new
                {
                    EML05Llave = table.Column<decimal>(name: "EML05_Llave", type: "numeric(18,0)", nullable: false),
                    EML01Llave = table.Column<decimal>(name: "EML01_Llave", type: "numeric(18,0)", nullable: true),
                    EML06Llave = table.Column<decimal>(name: "EML06_Llave", type: "numeric(18,0)", nullable: true),
                    EML05Archivo = table.Column<string>(name: "EML05_Archivo", type: "nvarchar(max)", nullable: true),
                    EML05Ruta = table.Column<string>(name: "EML05_Ruta", type: "nvarchar(max)", nullable: true),
                    EML05Activo = table.Column<int>(name: "EML05_Activo", type: "int", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EML05_ArchivoMail", x => x.EML05Llave);
                    table.ForeignKey(
                        name: "FK_EML05_ArchivoMail_EML01_EmailUsuario",
                        column: x => x.EML01Llave,
                        principalTable: "EML01_BitacoraEmailUsuario",
                        principalColumn: "EML01_Llave");
                    table.ForeignKey(
                        name: "FK_EML05_ArchivoMail_EML06_TipoArchivo",
                        column: x => x.EML05Llave,
                        principalTable: "EML06_TipoArchivo",
                        principalColumn: "EML06_Llave");
                });

            migrationBuilder.CreateTable(
                name: "FRM02_Formulario",
                columns: table => new
                {
                    FRM02Llave = table.Column<decimal>(name: "FRM02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FRM01Llave = table.Column<decimal>(name: "FRM01_Llave", type: "numeric(18,0)", nullable: true),
                    FRM02Nombre = table.Column<string>(name: "FRM02_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FRM02Empresa = table.Column<string>(name: "FRM02_Empresa", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FRM02Ciudad = table.Column<string>(name: "FRM02_Ciudad", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FRM02Direccion = table.Column<string>(name: "FRM02_Direccion", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FRM02Mail = table.Column<string>(name: "FRM02_Mail", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FRM02Telefono = table.Column<string>(name: "FRM02_Telefono", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FRM02Celular = table.Column<string>(name: "FRM02_Celular", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FRM02Mensaje = table.Column<string>(name: "FRM02_Mensaje", type: "nvarchar(max)", nullable: true),
                    FRM02Activo = table.Column<int>(name: "FRM02_Activo", type: "int", nullable: true),
                    FRM02EstadoRespuesta = table.Column<int>(name: "FRM02_EstadoRespuesta", type: "int", nullable: true),
                    EML01Llave = table.Column<decimal>(name: "EML01_Llave", type: "numeric(18,0)", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FRM02_Formulario", x => x.FRM02Llave);
                    table.ForeignKey(
                        name: "FK_FRM02_Formulario_EML01_BitacoraEmailUsuario",
                        column: x => x.EML01Llave,
                        principalTable: "EML01_BitacoraEmailUsuario",
                        principalColumn: "EML01_Llave");
                    table.ForeignKey(
                        name: "FK_FRM02_Formulario_FRM01_TipoFormulario",
                        column: x => x.FRM01Llave,
                        principalTable: "FRM01_TipoFormulario",
                        principalColumn: "FRM01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "PRF02_PlantillasUsuario",
                columns: table => new
                {
                    Prf01Llave = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Prf03Llave = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRF02_PlantillasUsuario", x => new { x.Prf01Llave, x.Prf03Llave });
                    table.ForeignKey(
                        name: "FK_PRF02_PlantillasUsuario_PRF01_Perfiles",
                        column: x => x.Prf01Llave,
                        principalTable: "PRF01_Perfiles",
                        principalColumn: "PRF01_Llave");
                    table.ForeignKey(
                        name: "FK_PRF02_PlantillasUsuario_PRF03_Plantilla",
                        column: x => x.Prf03Llave,
                        principalTable: "PRF03_Plantilla",
                        principalColumn: "PRF03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "WKF06_Perfiles",
                columns: table => new
                {
                    WKF06llave = table.Column<decimal>(name: "WKF06_llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF01llave = table.Column<decimal>(name: "WKF01_llave", type: "numeric(18,0)", nullable: true),
                    WKF06Nombre = table.Column<string>(name: "WKF06_Nombre", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF06Descripcion = table.Column<string>(name: "WKF06_Descripcion", type: "nvarchar(max)", nullable: true),
                    WKF06Activo = table.Column<int>(name: "WKF06_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF06_Perfiles", x => x.WKF06llave);
                    table.ForeignKey(
                        name: "FK_WKF06_Perfiles_WKF01_Flujo",
                        column: x => x.WKF01llave,
                        principalTable: "WKF01_Flujo",
                        principalColumn: "WKF01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "WKF09_Parametro",
                columns: table => new
                {
                    WKF09Llave = table.Column<decimal>(name: "WKF09_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF01Llave = table.Column<decimal>(name: "WKF01_Llave", type: "numeric(18,0)", nullable: true),
                    WKF10Llave = table.Column<decimal>(name: "WKF10_Llave", type: "numeric(18,0)", nullable: true),
                    WKF09Variable = table.Column<string>(name: "WKF09_Variable", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF09Valor = table.Column<string>(name: "WKF09_Valor", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF09Activo = table.Column<int>(name: "WKF09_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF09_Parametro", x => x.WKF09Llave);
                    table.ForeignKey(
                        name: "FK_WKF09_Parametro_WKF01_Flujo",
                        column: x => x.WKF01Llave,
                        principalTable: "WKF01_Flujo",
                        principalColumn: "WKF01_Llave");
                    table.ForeignKey(
                        name: "FK_WKF09_Parametro_WKF10_TipoParametro",
                        column: x => x.WKF10Llave,
                        principalTable: "WKF10_TipoParametro",
                        principalColumn: "WKF10_Llave");
                });

            migrationBuilder.CreateTable(
                name: "MNT02_EspeciesAsignadas",
                columns: table => new
                {
                    Mnt01Llave = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Esp02Llave = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MNT02_EspeciesAsignadas_2", x => new { x.Mnt01Llave, x.Esp02Llave });
                    table.ForeignKey(
                        name: "FK_MNT02_EspeciesAsignadas_ESP02_TemporadaEspecie",
                        column: x => x.Esp02Llave,
                        principalTable: "ESP02_TemporadaEspecie",
                        principalColumn: "ESP02_Llave");
                    table.ForeignKey(
                        name: "FK_MNT02_EspeciesAsignadas_MNT01_Monitores",
                        column: x => x.Mnt01Llave,
                        principalTable: "MNT01_Monitores",
                        principalColumn: "MNT01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT06_ComunicacionCliente",
                columns: table => new
                {
                    CNT06Llave = table.Column<decimal>(name: "CNT06_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT01Llave = table.Column<decimal>(name: "CNT01_Llave", type: "numeric(18,0)", nullable: false),
                    CNT08Llave = table.Column<decimal>(name: "CNT08_Llave", type: "numeric(18,0)", nullable: true),
                    CNT10Llave = table.Column<decimal>(name: "CNT10_Llave", type: "numeric(18,0)", nullable: false),
                    CNT06Direccion = table.Column<string>(name: "CNT06_Direccion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST03Llave = table.Column<decimal>(name: "SIST03_Llave", type: "numeric(18,0)", nullable: true),
                    CNT06casilla = table.Column<string>(name: "CNT06_casilla", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT06TieneCasilla = table.Column<int>(name: "CNT06_TieneCasilla", type: "int", nullable: true),
                    CNT06CodigoPostal = table.Column<string>(name: "CNT06_CodigoPostal", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT06Email = table.Column<string>(name: "CNT06_Email", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT06TipoMail = table.Column<decimal>(name: "CNT06_TipoMail", type: "numeric(18,0)", nullable: true),
                    CNT06Telefono1 = table.Column<string>(name: "CNT06_Telefono1", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT06Telefono2 = table.Column<string>(name: "CNT06_Telefono2", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT06Celular1 = table.Column<string>(name: "CNT06_Celular1", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT06Celular2 = table.Column<string>(name: "CNT06_Celular2", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT06Fax = table.Column<string>(name: "CNT06_Fax", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT06SitioWeb = table.Column<string>(name: "CNT06_SitioWeb", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT06Activo = table.Column<int>(name: "CNT06_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT06_ComunicacionCliente", x => x.CNT06Llave);
                    table.ForeignKey(
                        name: "FK_CNT06_ComunicacionCliente_CNT01_CuentaCliente",
                        column: x => x.CNT01Llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_Llave");
                    table.ForeignKey(
                        name: "FK_CNT06_ComunicacionCliente_CNT08_Segmentacion",
                        column: x => x.CNT08Llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_Llave");
                    table.ForeignKey(
                        name: "FK_CNT06_ComunicacionCliente_CNT10_TipoComunicacion",
                        column: x => x.CNT10Llave,
                        principalTable: "CNT10_TipoComunicacion",
                        principalColumn: "CNT10_Llave");
                    table.ForeignKey(
                        name: "FK_CNT06_ComunicacionCliente_SIST03_Comuna",
                        column: x => x.SIST03Llave,
                        principalTable: "SIST03_Comuna",
                        principalColumn: "SIST03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT09_ComunicacionSegmentacion",
                columns: table => new
                {
                    CNT09Llave = table.Column<decimal>(name: "CNT09_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT08Llave = table.Column<decimal>(name: "CNT08_Llave", type: "numeric(18,0)", nullable: false),
                    CNT10Llave = table.Column<decimal>(name: "CNT10_Llave", type: "numeric(18,0)", nullable: false),
                    CNT09Direccion = table.Column<string>(name: "CNT09_Direccion", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST03Llave = table.Column<decimal>(name: "SIST03_Llave", type: "numeric(18,0)", nullable: true),
                    CNT09casilla = table.Column<string>(name: "CNT09_casilla", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT09SinCasilla = table.Column<int>(name: "CNT09_SinCasilla", type: "int", nullable: true),
                    CNT09CodigoPostal = table.Column<string>(name: "CNT09_CodigoPostal", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT09Email = table.Column<string>(name: "CNT09_Email", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT09TipoMail = table.Column<decimal>(name: "CNT09_TipoMail", type: "numeric(18,0)", nullable: true),
                    CNT09Telefono1 = table.Column<string>(name: "CNT09_Telefono1", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT09Telefono2 = table.Column<string>(name: "CNT09_Telefono2", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT09Celular1 = table.Column<string>(name: "CNT09_Celular1", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT09Celular2 = table.Column<string>(name: "CNT09_Celular2", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT09Fax = table.Column<string>(name: "CNT09_Fax", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT09SitioWeb = table.Column<string>(name: "CNT09_SitioWeb", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT09Activo = table.Column<int>(name: "CNT09_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT09_ComunicacionSegmentacion", x => x.CNT09Llave);
                    table.ForeignKey(
                        name: "FK_CNT09_ComunicacionSegmentacion_CNT08_Segmentacion",
                        column: x => x.CNT08Llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT11_ContactoSegmentacion",
                columns: table => new
                {
                    CNT11Llave = table.Column<decimal>(name: "CNT11_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT08Llave = table.Column<decimal>(name: "CNT08_Llave", type: "numeric(18,0)", nullable: false),
                    PER01Llave = table.Column<decimal>(name: "PER01_Llave", type: "numeric(18,0)", nullable: true),
                    CNT05llave = table.Column<decimal>(name: "CNT05_llave", type: "numeric(18,0)", nullable: true),
                    CNT11Activo = table.Column<int>(name: "CNT11_Activo", type: "int", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT11_ContactoSegmentacion", x => x.CNT11Llave);
                    table.ForeignKey(
                        name: "FK_CNT11_ContactoSegmentacion_CNT08_Segmentacion",
                        column: x => x.CNT08Llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT22_Estacion_TipoEstacion",
                columns: table => new
                {
                    CNT08Llave = table.Column<decimal>(name: "CNT08_Llave", type: "numeric(18,0)", nullable: false),
                    CNT21llave = table.Column<decimal>(name: "CNT21_llave", type: "numeric(18,0)", nullable: false),
                    CNT22estado = table.Column<int>(name: "CNT22_estado", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT22_Estacion_TipoEstacion", x => new { x.CNT08Llave, x.CNT21llave });
                    table.ForeignKey(
                        name: "FK_CNT22_Estacion_TipoEstacion_CNT08_Segmentacion",
                        column: x => x.CNT08Llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_Llave");
                    table.ForeignKey(
                        name: "FK_CNT22_Estacion_TipoEstacion_CNT21_TipoEstacion",
                        column: x => x.CNT21llave,
                        principalTable: "CNT21_TipoEstacion",
                        principalColumn: "CNT21_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CONTEO02_Procesados",
                columns: table => new
                {
                    CONTEO02Llave = table.Column<decimal>(name: "CONTEO02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT08Llave = table.Column<decimal>(name: "CNT08_Llave", type: "numeric(18,0)", nullable: true),
                    ESP01Llave = table.Column<decimal>(name: "ESP01_Llave", type: "numeric(18,0)", nullable: true),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: true),
                    CONTEO02fechaProceso = table.Column<DateTime>(name: "CONTEO02_fechaProceso", type: "datetime", nullable: true),
                    CONTEO02Promedio = table.Column<decimal>(name: "CONTEO02_Promedio", type: "numeric(18,2)", nullable: true),
                    CONTEO02Cantidad = table.Column<decimal>(name: "CONTEO02_Cantidad", type: "numeric(18,0)", nullable: true),
                    CONTEO02Cotatenado = table.Column<string>(name: "CONTEO02_Cotatenado", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CONTEO02Suma = table.Column<decimal>(name: "CONTEO02_Suma", type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTEO02_Procesados", x => x.CONTEO02Llave);
                    table.ForeignKey(
                        name: "FK_CONTEO02_Procesados_CNT08_Segmentacion",
                        column: x => x.CNT08Llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CONTEO03_Resumen",
                columns: table => new
                {
                    CONTEO03Llave = table.Column<decimal>(name: "CONTEO03_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT08Llave = table.Column<decimal>(name: "CNT08_Llave", type: "numeric(18,0)", nullable: true),
                    ESP01Llave = table.Column<decimal>(name: "ESP01_Llave", type: "numeric(18,0)", nullable: true),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: true),
                    CONTEO03Estado = table.Column<int>(name: "CONTEO03_Estado", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTEO03_Resumen", x => x.CONTEO03Llave);
                    table.ForeignKey(
                        name: "FK_CONTEO03_Resumen_CNT08_Segmentacion",
                        column: x => x.CNT08Llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_Llave");
                });

            migrationBuilder.CreateTable(
                name: "TRP01_Trampa",
                columns: table => new
                {
                    TRP01Llave = table.Column<decimal>(name: "TRP01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT08Llave = table.Column<decimal>(name: "CNT08_Llave", type: "numeric(18,0)", nullable: true),
                    ESP01Llave = table.Column<decimal>(name: "ESP01_Llave", type: "numeric(18,0)", nullable: true),
                    TRP01Nombre = table.Column<string>(name: "TRP01_Nombre", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TRP01Activo = table.Column<int>(name: "TRP01_Activo", type: "int", nullable: true),
                    TRP01Numero = table.Column<decimal>(name: "TRP01_Numero", type: "numeric(18,0)", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATEBY = table.Column<Guid>(name: "CREATE_BY", type: "uniqueidentifier", nullable: true),
                    APPROVEBY = table.Column<Guid>(name: "APPROVE_BY", type: "uniqueidentifier", nullable: true),
                    DELETEBY = table.Column<Guid>(name: "DELETE_BY", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRP01_Trampa", x => x.TRP01Llave);
                    table.ForeignKey(
                        name: "FK_TRP01_Trampa_CNT08_Segmentacion",
                        column: x => x.CNT08Llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_Llave");
                    table.ForeignKey(
                        name: "FK_TRP01_Trampa_ESP01_Especies",
                        column: x => x.ESP01Llave,
                        principalTable: "ESP01_Especies",
                        principalColumn: "ESP01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT17_Bloqueos",
                columns: table => new
                {
                    CNT17Llave = table.Column<decimal>(name: "CNT17_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BLK01Llave = table.Column<decimal>(name: "BLK01_Llave", type: "numeric(18,0)", nullable: true),
                    CNT16Llave = table.Column<decimal>(name: "CNT16_Llave", type: "numeric(18,0)", nullable: true),
                    CNT01Llave = table.Column<decimal>(name: "CNT01_Llave", type: "numeric(18,0)", nullable: true),
                    CNT08Llave = table.Column<decimal>(name: "CNT08_Llave", type: "numeric(18,0)", nullable: true),
                    CNT14Llave = table.Column<decimal>(name: "CNT14_Llave", type: "numeric(18,0)", nullable: true),
                    PER01Llave = table.Column<decimal>(name: "PER01_Llave", type: "numeric(18,0)", nullable: true),
                    CNT17InicioBloqueo = table.Column<DateTime>(name: "CNT17_InicioBloqueo", type: "datetime", nullable: true),
                    CNT17TerminoBloqueo = table.Column<DateTime>(name: "CNT17_TerminoBloqueo", type: "datetime", nullable: true),
                    CNT17Activo = table.Column<bool>(name: "CNT17_Activo", type: "bit", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT17_Bloqueos", x => x.CNT17Llave);
                    table.ForeignKey(
                        name: "FK_CNT17_Bloqueos_BLK01_Bloqueos",
                        column: x => x.BLK01Llave,
                        principalTable: "BLK01_Bloqueos",
                        principalColumn: "BLK01_Llave");
                    table.ForeignKey(
                        name: "FK_CNT17_Bloqueos_CNT01_CuentaCliente",
                        column: x => x.CNT01Llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_Llave");
                    table.ForeignKey(
                        name: "FK_CNT17_Bloqueos_CNT08_Segmentacion",
                        column: x => x.CNT08Llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_Llave");
                    table.ForeignKey(
                        name: "FK_CNT17_Bloqueos_CNT14_ClienteLicencia",
                        column: x => x.CNT14Llave,
                        principalTable: "CNT14_ClienteLicencia",
                        principalColumn: "CNT14_Llave");
                    table.ForeignKey(
                        name: "FK_CNT17_Bloqueos_CNT16_TipoBloqueoCliente",
                        column: x => x.CNT16Llave,
                        principalTable: "CNT16_TipoBloqueoCliente",
                        principalColumn: "CNT16_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT15_EmpleadoLicencia",
                columns: table => new
                {
                    CNT19Llave = table.Column<decimal>(name: "CNT19_Llave", type: "numeric(18,0)", nullable: false),
                    CNT12Llave = table.Column<decimal>(name: "CNT12_Llave", type: "numeric(18,0)", nullable: false),
                    CNT15AceptaContrato = table.Column<int>(name: "CNT15_AceptaContrato", type: "int", nullable: true),
                    CNT15fechafirma = table.Column<DateTime>(name: "CNT15_fechafirma", type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT15_EmpleadoLicencia_1", x => new { x.CNT19Llave, x.CNT12Llave });
                    table.ForeignKey(
                        name: "FK_CNT15_EmpleadoLicencia_CNT12_Empleados",
                        column: x => x.CNT12Llave,
                        principalTable: "CNT12_Empleados",
                        principalColumn: "CNT12_Llave");
                    table.ForeignKey(
                        name: "FK_CNT15_EmpleadoLicencia_CNT19_LicenciaCliente",
                        column: x => x.CNT19Llave,
                        principalTable: "CNT19_LicenciaCliente",
                        principalColumn: "CNT19_Llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT20_LicenciaServicio",
                columns: table => new
                {
                    CNT19Llave = table.Column<decimal>(name: "CNT19_Llave", type: "numeric(18,0)", nullable: false),
                    SERV01Llave = table.Column<decimal>(name: "SERV01_Llave", type: "numeric(18,0)", nullable: false),
                    CNT20habilitaservicio = table.Column<int>(name: "CNT20_habilitaservicio", type: "int", nullable: true),
                    CNT20Valor = table.Column<decimal>(name: "CNT20_Valor", type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT20_LicenciaServicio", x => new { x.CNT19Llave, x.SERV01Llave });
                    table.ForeignKey(
                        name: "FK_CNT20_LicenciaServicio_CNT19_LicenciaCliente",
                        column: x => x.CNT19Llave,
                        principalTable: "CNT19_LicenciaCliente",
                        principalColumn: "CNT19_Llave");
                });

            migrationBuilder.CreateTable(
                name: "PGO01_CompraLicencia",
                columns: table => new
                {
                    PGO1Llave = table.Column<decimal>(name: "PGO1_Llave", type: "numeric(18,0)", nullable: false),
                    CNT19Llave = table.Column<decimal>(name: "CNT19_Llave", type: "numeric(18,0)", nullable: true),
                    PGO03Llave = table.Column<decimal>(name: "PGO03_Llave", type: "numeric(18,0)", nullable: true),
                    PGO01Activo = table.Column<int>(name: "PGO01_Activo", type: "int", nullable: true),
                    PGO01TotalCompra = table.Column<decimal>(name: "PGO01_TotalCompra", type: "numeric(18,2)", nullable: true),
                    FECHACOMPRA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PGO01_CompraLicencia", x => x.PGO1Llave);
                    table.ForeignKey(
                        name: "FK_PGO01_CompraLicencia_CNT01_CuentaCliente",
                        column: x => x.CNT19Llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_Llave");
                    table.ForeignKey(
                        name: "FK_PGO01_CompraLicencia_CNT19_LicenciaCliente",
                        column: x => x.CNT19Llave,
                        principalTable: "CNT19_LicenciaCliente",
                        principalColumn: "CNT19_Llave");
                    table.ForeignKey(
                        name: "FK_PGO01_CompraLicencia_PGO03_FormaPago1",
                        column: x => x.PGO03Llave,
                        principalTable: "PGO03_TipoPagoLicencia",
                        principalColumn: "PGO03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "PRF04_plantillaPerfil",
                columns: table => new
                {
                    PRF03Llave = table.Column<decimal>(name: "PRF03_Llave", type: "numeric(18,0)", nullable: false),
                    WKF06llave = table.Column<decimal>(name: "WKF06_llave", type: "numeric(18,0)", nullable: false),
                    PRF04activo = table.Column<int>(name: "PRF04_activo", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRF04_plantillaPerfil", x => new { x.PRF03Llave, x.WKF06llave });
                    table.ForeignKey(
                        name: "FK_PRF04_plantillaPerfil_PRF03_Plantilla",
                        column: x => x.PRF03Llave,
                        principalTable: "PRF03_Plantilla",
                        principalColumn: "PRF03_Llave");
                    table.ForeignKey(
                        name: "FK_PRF04_plantillaPerfil_WKF06_Perfiles",
                        column: x => x.WKF06llave,
                        principalTable: "WKF06_Perfiles",
                        principalColumn: "WKF06_llave");
                });

            migrationBuilder.CreateTable(
                name: "PRF06_PermisosUsuario",
                columns: table => new
                {
                    PRF01llave = table.Column<decimal>(name: "PRF01_llave", type: "numeric(18,0)", nullable: false),
                    WKF06llave = table.Column<decimal>(name: "WKF06_llave", type: "numeric(18,0)", nullable: false),
                    PRF06activo = table.Column<int>(name: "PRF06_activo", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRF06_PermisosUsuario", x => new { x.PRF01llave, x.WKF06llave });
                    table.ForeignKey(
                        name: "FK_PRF06_PermisosUsuario_PRF01_Perfiles",
                        column: x => x.PRF01llave,
                        principalTable: "PRF01_Perfiles",
                        principalColumn: "PRF01_Llave");
                    table.ForeignKey(
                        name: "FK_PRF06_PermisosUsuario_WKF06_Perfiles",
                        column: x => x.WKF06llave,
                        principalTable: "WKF06_Perfiles",
                        principalColumn: "WKF06_llave");
                });

            migrationBuilder.CreateTable(
                name: "WKF07_PerfilesPermiso",
                columns: table => new
                {
                    WKF06llave = table.Column<decimal>(name: "WKF06_llave", type: "numeric(18,0)", nullable: false),
                    WKF05llave = table.Column<decimal>(name: "WKF05_llave", type: "numeric(18,0)", nullable: false),
                    WKF07activo = table.Column<int>(name: "WKF07_activo", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF07_PerfilesPermiso", x => new { x.WKF06llave, x.WKF05llave });
                    table.ForeignKey(
                        name: "FK_WKF07_PerfilesPermiso_WKF05_TipoPermiso",
                        column: x => x.WKF05llave,
                        principalTable: "WKF05_TipoPermiso",
                        principalColumn: "WKF05_Llave");
                    table.ForeignKey(
                        name: "FK_WKF07_PerfilesPermiso_WKF06_Perfiles",
                        column: x => x.WKF06llave,
                        principalTable: "WKF06_Perfiles",
                        principalColumn: "WKF06_llave");
                });

            migrationBuilder.CreateTable(
                name: "SERCLTEMP01_ServiciosClientes_Temporal",
                columns: table => new
                {
                    SERCLTEMP01Llave = table.Column<decimal>(name: "SERCLTEMP01_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERCLTEMP01TipoGrafico = table.Column<decimal>(name: "SERCLTEMP01_TipoGrafico", type: "numeric(18,0)", nullable: true),
                    CNTEMP01Llave = table.Column<decimal>(name: "CNTEMP01_Llave", type: "numeric(18,0)", nullable: true),
                    CNTEMP02Llave = table.Column<decimal>(name: "CNTEMP02_Llave", type: "numeric(18,0)", nullable: true),
                    CONTEO03Llave = table.Column<decimal>(name: "CONTEO03_Llave", type: "numeric(18,0)", nullable: true),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERCLTEMP01_ServiciosClientes_Temporal", x => x.SERCLTEMP01Llave);
                    table.ForeignKey(
                        name: "FK_SERCLTEMP01_ServiciosClientes_Temporal_CONTEO03_Resumen",
                        column: x => x.CONTEO03Llave,
                        principalTable: "CONTEO03_Resumen",
                        principalColumn: "CONTEO03_Llave");
                });

            migrationBuilder.CreateTable(
                name: "TRP02_Temporada",
                columns: table => new
                {
                    TRP02Llave = table.Column<decimal>(name: "TRP02_Llave", type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRP01Llave = table.Column<decimal>(name: "TRP01_Llave", type: "numeric(18,0)", nullable: false),
                    TEMP02Llave = table.Column<decimal>(name: "TEMP02_Llave", type: "numeric(18,0)", nullable: false),
                    TEMP02Activo = table.Column<bool>(name: "TEMP02_Activo", type: "bit", nullable: true),
                    FECHAACTUALIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAELIMINACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHAACTIVACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRP02_Temporada", x => x.TRP02Llave);
                    table.ForeignKey(
                        name: "FK_TRP02_Temporada_TEMP02_TemporadaBase",
                        column: x => x.TEMP02Llave,
                        principalTable: "TEMP02_TemporadaBase",
                        principalColumn: "TEMP02_Llave");
                    table.ForeignKey(
                        name: "FK_TRP02_Temporada_TRP01_Trampa",
                        column: x => x.TRP01Llave,
                        principalTable: "TRP01_Trampa",
                        principalColumn: "TRP01_Llave");
                });

            migrationBuilder.CreateTable(
                name: "PGO02_NotificarPagoLicencia",
                columns: table => new
                {
                    PGO02Llave = table.Column<decimal>(name: "PGO02_Llave", type: "numeric(18,0)", nullable: false),
                    PGO01Llave = table.Column<decimal>(name: "PGO01_Llave", type: "numeric(18,0)", nullable: true),
                    PGO02Activo = table.Column<int>(name: "PGO02_Activo", type: "int", nullable: true),
                    PGO02DocumentoAdjunto = table.Column<string>(name: "PGO02_DocumentoAdjunto", type: "nvarchar(max)", nullable: true),
                    FECHANOTIFICACIONPAGO = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PGO02_NotificarPagoLicencia", x => x.PGO02Llave);
                    table.ForeignKey(
                        name: "FK_PGO02_NotificarPagoLicencia_PGO01_CompraLicencia",
                        column: x => x.PGO01Llave,
                        principalTable: "PGO01_CompraLicencia",
                        principalColumn: "PGO1_Llave");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BLK01_Bloqueos_BLK02_Llave",
                table: "BLK01_Bloqueos",
                column: "BLK02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_BLK03_BloqueoUsuario_BLK01_Llave",
                table: "BLK03_BloqueoUsuario",
                column: "BLK01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CLBR01_Calibracion_CLBR02_Llave",
                table: "CLBR01_Calibracion",
                column: "CLBR02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT01_CuentaCliente_CNT02_Llave",
                table: "CNT01_CuentaCliente",
                column: "CNT02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT01_CuentaCliente_CNT03_Llave",
                table: "CNT01_CuentaCliente",
                column: "CNT03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT01_CuentaCliente_PER01_Llave",
                table: "CNT01_CuentaCliente",
                column: "PER01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT03_TipoCliente_PER03_Llave",
                table: "CNT03_TipoCliente",
                column: "PER03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT04_ContactoCliente_CNT01_Llave",
                table: "CNT04_ContactoCliente",
                column: "CNT01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT04_ContactoCliente_CNT05_llave",
                table: "CNT04_ContactoCliente",
                column: "CNT05_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT06_ComunicacionCliente_CNT01_Llave",
                table: "CNT06_ComunicacionCliente",
                column: "CNT01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT06_ComunicacionCliente_CNT08_Llave",
                table: "CNT06_ComunicacionCliente",
                column: "CNT08_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT06_ComunicacionCliente_CNT10_Llave",
                table: "CNT06_ComunicacionCliente",
                column: "CNT10_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT06_ComunicacionCliente_SIST03_Llave",
                table: "CNT06_ComunicacionCliente",
                column: "SIST03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT07_TipoSegmentacion_CNT18_Llave",
                table: "CNT07_TipoSegmentacion",
                column: "CNT18_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT08_Segmentacion_CNT01_Llave",
                table: "CNT08_Segmentacion",
                column: "CNT01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT08_Segmentacion_CNT07_Llave",
                table: "CNT08_Segmentacion",
                column: "CNT07_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT08_Segmentacion_CNT08_LlavePadre",
                table: "CNT08_Segmentacion",
                column: "CNT08_LlavePadre");

            migrationBuilder.CreateIndex(
                name: "IX_CNT09_ComunicacionSegmentacion_CNT08_Llave",
                table: "CNT09_ComunicacionSegmentacion",
                column: "CNT08_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT11_ContactoSegmentacion_CNT08_Llave",
                table: "CNT11_ContactoSegmentacion",
                column: "CNT08_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT12_Empleados_CNT01_Llave",
                table: "CNT12_Empleados",
                column: "CNT01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT12_Empleados_CNT13_Llave",
                table: "CNT12_Empleados",
                column: "CNT13_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT12_Empleados_PER01_Llave",
                table: "CNT12_Empleados",
                column: "PER01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT14_ClienteLicencia_CNT01_Llave",
                table: "CNT14_ClienteLicencia",
                column: "CNT01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT15_EmpleadoLicencia_CNT12_Llave",
                table: "CNT15_EmpleadoLicencia",
                column: "CNT12_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT17_Bloqueos_BLK01_Llave",
                table: "CNT17_Bloqueos",
                column: "BLK01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT17_Bloqueos_CNT01_Llave",
                table: "CNT17_Bloqueos",
                column: "CNT01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT17_Bloqueos_CNT08_Llave",
                table: "CNT17_Bloqueos",
                column: "CNT08_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT17_Bloqueos_CNT14_Llave",
                table: "CNT17_Bloqueos",
                column: "CNT14_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT17_Bloqueos_CNT16_Llave",
                table: "CNT17_Bloqueos",
                column: "CNT16_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT19_LicenciaCliente_CNT01_Llave",
                table: "CNT19_LicenciaCliente",
                column: "CNT01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT22_Estacion_TipoEstacion_CNT21_llave",
                table: "CNT22_Estacion_TipoEstacion",
                column: "CNT21_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONT01_Contacto_CONT02_Llave",
                table: "CONT01_Contacto",
                column: "CONT02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO01_Conteos_TEMP02_Llave",
                table: "CONTEO01_Conteos",
                column: "TEMP02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO02_Procesados_CNT08_Llave",
                table: "CONTEO02_Procesados",
                column: "CNT08_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO03_Resumen_CNT08_Llave",
                table: "CONTEO03_Resumen",
                column: "CNT08_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO04_ResumenSag_ESP01_Llave",
                table: "CONTEO04_ResumenSag",
                column: "ESP01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO04_ResumenSag_SIST03_Llave",
                table: "CONTEO04_ResumenSag",
                column: "SIST03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO04_ResumenSag_TEMP02_Llave",
                table: "CONTEO04_ResumenSag",
                column: "TEMP02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO05_Control_Reserva_SECU02_Llave",
                table: "CONTEO05_Control_Reserva",
                column: "SECU02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_CTT01_Contrato_CTT02_Llave",
                table: "CTT01_Contrato",
                column: "CTT02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_EML01_BitacoraEmailUsuario_EML02_Llave",
                table: "EML01_BitacoraEmailUsuario",
                column: "EML02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_EML01_BitacoraEmailUsuario_EML04_Llave",
                table: "EML01_BitacoraEmailUsuario",
                column: "EML04_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_EML01_BitacoraEmailUsuario_SECU02_Llave",
                table: "EML01_BitacoraEmailUsuario",
                column: "SECU02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_EML02_MailBase_EML03_Llave",
                table: "EML02_MailBase",
                column: "EML03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_EML02_MailBase_EML04_Llave",
                table: "EML02_MailBase",
                column: "EML04_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_EML05_ArchivoMail_EML01_Llave",
                table: "EML05_ArchivoMail",
                column: "EML01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP01_Especies_ESP03_Llave",
                table: "ESP01_Especies",
                column: "ESP03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP01_Especies_ESP04_Llave",
                table: "ESP01_Especies",
                column: "ESP04_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP02_TemporadaEspecie_ESP01_Llave",
                table: "ESP02_TemporadaEspecie",
                column: "ESP01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP02_TemporadaEspecie_TEMP01_Llave",
                table: "ESP02_TemporadaEspecie",
                column: "TEMP01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP03_EspecieBase_ESP08_llave",
                table: "ESP03_EspecieBase",
                column: "ESP08_llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP04_EstadoDanio_ESP06_Llave",
                table: "ESP04_EstadoDanio",
                column: "ESP06_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP05_Umbral_ESP01_Llave",
                table: "ESP05_Umbral",
                column: "ESP01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP05_Umbral_ESP09_Llave",
                table: "ESP05_Umbral",
                column: "ESP09_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP11_ReglaGrafico_ESP10_Llave",
                table: "ESP11_ReglaGrafico",
                column: "ESP10_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_FRM02_Formulario_EML01_Llave",
                table: "FRM02_Formulario",
                column: "EML01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_FRM02_Formulario_FRM01_Llave",
                table: "FRM02_Formulario",
                column: "FRM01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_INS02_RecuperarClave_INS02_Estado",
                table: "INS02_RecuperarClave",
                column: "INS02_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_LNC02_ServiciosLicencia_SERV01_Llave",
                table: "LNC02_ServiciosLicencia",
                column: "SERV01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_LNC03_LicenciaContrato_CTT01_Llave",
                table: "LNC03_LicenciaContrato",
                column: "CTT01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_LNC05_valorLicencia_LNC01_Llave",
                table: "LNC05_valorLicencia",
                column: "LNC01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_LOG01_Bitacora_LOG03_Llave",
                table: "LOG01_Bitacora",
                column: "LOG03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_LOG03_MensajeBitacora_LOG02_Llave",
                table: "LOG03_MensajeBitacora",
                column: "LOG02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_MNT01_Monitores_MNT04_Llave",
                table: "MNT01_Monitores",
                column: "MNT04_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_MNT02_EspeciesAsignadas_Esp02Llave",
                table: "MNT02_EspeciesAsignadas",
                column: "Esp02Llave");

            migrationBuilder.CreateIndex(
                name: "IX_MNT03_PeriodosTrampas_TEMP02_Llave",
                table: "MNT03_PeriodosTrampas",
                column: "TEMP02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_OBSC01_ObservacionCampo_ESP08_Llave",
                table: "OBSC01_ObservacionCampo",
                column: "ESP08_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_OBSC01_ObservacionCampo_TEMP02_Llave",
                table: "OBSC01_ObservacionCampo",
                column: "TEMP02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_PBCD01_Publicidad_PBCD02_Llave",
                table: "PBCD01_Publicidad",
                column: "PBCD02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_PBCD03_Programacion_PBCD01_Llave",
                table: "PBCD03_Programacion",
                column: "PBCD01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_PER01_Persona_PER02_Llave",
                table: "PER01_Persona",
                column: "PER02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_PER01_Persona_PER03_Llave",
                table: "PER01_Persona",
                column: "PER03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_PER05_Comunicacion_PER03_Llave_PER04_Llave",
                table: "PER05_Comunicacion",
                columns: new[] { "PER03_Llave", "PER04_Llave" });

            migrationBuilder.CreateIndex(
                name: "IX_PER05_Comunicacion_PER04_Llave",
                table: "PER05_Comunicacion",
                column: "PER04_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_PER06_TipoPersonaComunicacion_PER04_Llave",
                table: "PER06_TipoPersonaComunicacion",
                column: "PER04_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_PER07_PersonaUsuario_PER01_Llave",
                table: "PER07_PersonaUsuario",
                column: "PER01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_PGO01_CompraLicencia_CNT19_Llave",
                table: "PGO01_CompraLicencia",
                column: "CNT19_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_PGO01_CompraLicencia_PGO03_Llave",
                table: "PGO01_CompraLicencia",
                column: "PGO03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_PGO02_NotificarPagoLicencia_PGO01_Llave",
                table: "PGO02_NotificarPagoLicencia",
                column: "PGO01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_PRF01_Perfiles_PRF05_llave",
                table: "PRF01_Perfiles",
                column: "PRF05_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PRF01_Perfiles_SECU02_llave",
                table: "PRF01_Perfiles",
                column: "SECU02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PRF02_PlantillasUsuario_Prf03Llave",
                table: "PRF02_PlantillasUsuario",
                column: "Prf03Llave");

            migrationBuilder.CreateIndex(
                name: "IX_PRF04_plantillaPerfil_WKF06_llave",
                table: "PRF04_plantillaPerfil",
                column: "WKF06_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PRF06_PermisosUsuario_WKF06_llave",
                table: "PRF06_PermisosUsuario",
                column: "WKF06_llave");

            migrationBuilder.CreateIndex(
                name: "IX_SECU02_Usuario_SECU04_TipoEncriptacion",
                table: "SECU02_Usuario",
                column: "SECU04_TipoEncriptacion");

            migrationBuilder.CreateIndex(
                name: "IX_SECU05_UsuarioAcceso_SECU02_Llave",
                table: "SECU05_UsuarioAcceso",
                column: "SECU02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_SECU05_UsuarioAcceso_SECU03_TipoAcceso",
                table: "SECU05_UsuarioAcceso",
                column: "SECU03_TipoAcceso");

            migrationBuilder.CreateIndex(
                name: "IX_SECU06_UsuarioRol_SECU02_Llave",
                table: "SECU06_UsuarioRol",
                column: "SECU02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_SECU08_UsuarioAplicacion_SECU07_Llave",
                table: "SECU08_UsuarioAplicacion",
                column: "SECU07_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_SECU10_AccesoPermitido_SECU02_Llave",
                table: "SECU10_AccesoPermitido",
                column: "SECU02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_SECU10_AccesoPermitido_SECU03_Llave",
                table: "SECU10_AccesoPermitido",
                column: "SECU03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_SERCL02_MuestreoFruta_SERCL01_Llave",
                table: "SERCL02_MuestreoFruta",
                column: "SERCL01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_SERCLTEMP01_ServiciosClientes_Temporal_CONTEO03_Llave",
                table: "SERCLTEMP01_ServiciosClientes_Temporal",
                column: "CONTEO03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_SERV01_Servicio_SERV02_llave",
                table: "SERV01_Servicio",
                column: "SERV02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_SIST03_Comuna_SIST04_Llave",
                table: "SIST03_Comuna",
                column: "SIST04_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_SIST07_ZonaComuna_Sist03Llave",
                table: "SIST07_ZonaComuna",
                column: "Sist03Llave");

            migrationBuilder.CreateIndex(
                name: "IX_SIST08_ContactoUsuario_PER02_Llave",
                table: "SIST08_ContactoUsuario",
                column: "PER02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_TEMP01_Temporada_TEMP02_Llave",
                table: "TEMP01_Temporada",
                column: "TEMP02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_TEMP01_Temporada_TEMP03_Llave",
                table: "TEMP01_Temporada",
                column: "TEMP03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_TRP01_Trampa_CNT08_Llave",
                table: "TRP01_Trampa",
                column: "CNT08_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_TRP01_Trampa_ESP01_Llave",
                table: "TRP01_Trampa",
                column: "ESP01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_TRP02_Temporada_TEMP02_Llave",
                table: "TRP02_Temporada",
                column: "TEMP02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_TRP02_Temporada_TRP01_Llave",
                table: "TRP02_Temporada",
                column: "TRP01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF01_Flujo_WKF03_Llave",
                table: "WKF01_Flujo",
                column: "WKF03_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF03_Nivel_WKF02_Llave",
                table: "WKF03_Nivel",
                column: "WKF02_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF04_NivelPermiso_WKF03_llave",
                table: "WKF04_NivelPermiso",
                column: "WKF03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF04_NivelPermiso_WKF05_llave",
                table: "WKF04_NivelPermiso",
                column: "WKF05_llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF06_Perfiles_WKF01_llave",
                table: "WKF06_Perfiles",
                column: "WKF01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF07_PerfilesPermiso_WKF05_llave",
                table: "WKF07_PerfilesPermiso",
                column: "WKF05_llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF09_Parametro_WKF01_Llave",
                table: "WKF09_Parametro",
                column: "WKF01_Llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF09_Parametro_WKF10_Llave",
                table: "WKF09_Parametro",
                column: "WKF10_Llave");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BLK03_BloqueoUsuario");

            migrationBuilder.DropTable(
                name: "CLBR01_Calibracion");

            migrationBuilder.DropTable(
                name: "CNT04_ContactoCliente");

            migrationBuilder.DropTable(
                name: "CNT06_ComunicacionCliente");

            migrationBuilder.DropTable(
                name: "CNT09_ComunicacionSegmentacion");

            migrationBuilder.DropTable(
                name: "CNT11_ContactoSegmentacion");

            migrationBuilder.DropTable(
                name: "CNT15_EmpleadoLicencia");

            migrationBuilder.DropTable(
                name: "CNT17_Bloqueos");

            migrationBuilder.DropTable(
                name: "CNT20_LicenciaServicio");

            migrationBuilder.DropTable(
                name: "CNT22_Estacion_TipoEstacion");

            migrationBuilder.DropTable(
                name: "CNT23_Tipocobro");

            migrationBuilder.DropTable(
                name: "CNT24_AsociarCuenta");

            migrationBuilder.DropTable(
                name: "CONT01_Contacto");

            migrationBuilder.DropTable(
                name: "CONTEO01_Conteos");

            migrationBuilder.DropTable(
                name: "CONTEO02_Procesados");

            migrationBuilder.DropTable(
                name: "CONTEO04_ResumenSag");

            migrationBuilder.DropTable(
                name: "CONTEO05_Control_Reserva");

            migrationBuilder.DropTable(
                name: "CTZR01_Cotizacion");

            migrationBuilder.DropTable(
                name: "EML05_ArchivoMail");

            migrationBuilder.DropTable(
                name: "ESP05_Umbral");

            migrationBuilder.DropTable(
                name: "ESP07_Union");

            migrationBuilder.DropTable(
                name: "ESP11_ReglaGrafico");

            migrationBuilder.DropTable(
                name: "FRM02_Formulario");

            migrationBuilder.DropTable(
                name: "GRFC01_GraficoGenerado");

            migrationBuilder.DropTable(
                name: "GRFC02_TipoGrafico");

            migrationBuilder.DropTable(
                name: "GRFC03_respaldoGrafico");

            migrationBuilder.DropTable(
                name: "INS01_Inscripcion");

            migrationBuilder.DropTable(
                name: "INS02_RecuperarClave");

            migrationBuilder.DropTable(
                name: "LNC02_ServiciosLicencia");

            migrationBuilder.DropTable(
                name: "LNC03_LicenciaContrato");

            migrationBuilder.DropTable(
                name: "LNC04_TipoLicencia");

            migrationBuilder.DropTable(
                name: "LNC05_valorLicencia");

            migrationBuilder.DropTable(
                name: "LNC06_Cobertura");

            migrationBuilder.DropTable(
                name: "LNC07_Control");

            migrationBuilder.DropTable(
                name: "LOG01_Bitacora");

            migrationBuilder.DropTable(
                name: "MEN01_Sistema");

            migrationBuilder.DropTable(
                name: "MNT02_EspeciesAsignadas");

            migrationBuilder.DropTable(
                name: "MNT03_PeriodosTrampas");

            migrationBuilder.DropTable(
                name: "MVL01_AccesoMovil");

            migrationBuilder.DropTable(
                name: "MVL02_TablaSincronizacion");

            migrationBuilder.DropTable(
                name: "MVL03_RegistroAcceso");

            migrationBuilder.DropTable(
                name: "OBSC01_ObservacionCampo");

            migrationBuilder.DropTable(
                name: "OBSC02_ServicioPostcosecha");

            migrationBuilder.DropTable(
                name: "PBCD03_Programacion");

            migrationBuilder.DropTable(
                name: "PER05_Comunicacion");

            migrationBuilder.DropTable(
                name: "PER07_PersonaUsuario");

            migrationBuilder.DropTable(
                name: "PGO02_NotificarPagoLicencia");

            migrationBuilder.DropTable(
                name: "PRF02_PlantillasUsuario");

            migrationBuilder.DropTable(
                name: "PRF04_plantillaPerfil");

            migrationBuilder.DropTable(
                name: "PRF06_PermisosUsuario");

            migrationBuilder.DropTable(
                name: "PRM01_Seguridad");

            migrationBuilder.DropTable(
                name: "SECU02_Usuario20170202");

            migrationBuilder.DropTable(
                name: "SECU05_UsuarioAcceso");

            migrationBuilder.DropTable(
                name: "SECU06_UsuarioRol");

            migrationBuilder.DropTable(
                name: "SECU08_UsuarioAplicacion");

            migrationBuilder.DropTable(
                name: "SECU10_AccesoPermitido");

            migrationBuilder.DropTable(
                name: "SECU11_TipoPerfil");

            migrationBuilder.DropTable(
                name: "SERCL02_MuestreoFruta");

            migrationBuilder.DropTable(
                name: "SERCLTEMP01_ServiciosClientes_Temporal");

            migrationBuilder.DropTable(
                name: "SIST01_Sistema");

            migrationBuilder.DropTable(
                name: "SIST06_EstadoGrid");

            migrationBuilder.DropTable(
                name: "SIST07_ZonaComuna");

            migrationBuilder.DropTable(
                name: "SIST08_ContactoUsuario");

            migrationBuilder.DropTable(
                name: "TRP02_Temporada");

            migrationBuilder.DropTable(
                name: "TRP03_geocordenadas");

            migrationBuilder.DropTable(
                name: "WKF04_NivelPermiso");

            migrationBuilder.DropTable(
                name: "WKF07_PerfilesPermiso");

            migrationBuilder.DropTable(
                name: "WKF08_Area");

            migrationBuilder.DropTable(
                name: "WKF09_Parametro");

            migrationBuilder.DropTable(
                name: "CLBR02_TipoCalibracion");

            migrationBuilder.DropTable(
                name: "CNT05_TipoContacto");

            migrationBuilder.DropTable(
                name: "CNT10_TipoComunicacion");

            migrationBuilder.DropTable(
                name: "CNT12_Empleados");

            migrationBuilder.DropTable(
                name: "BLK01_Bloqueos");

            migrationBuilder.DropTable(
                name: "CNT14_ClienteLicencia");

            migrationBuilder.DropTable(
                name: "CNT16_TipoBloqueoCliente");

            migrationBuilder.DropTable(
                name: "CNT21_TipoEstacion");

            migrationBuilder.DropTable(
                name: "CONT02_TipoContacto");

            migrationBuilder.DropTable(
                name: "EML06_TipoArchivo");

            migrationBuilder.DropTable(
                name: "ESP09_TipoBaseUmbral");

            migrationBuilder.DropTable(
                name: "ESP10_TipoRegla");

            migrationBuilder.DropTable(
                name: "EML01_BitacoraEmailUsuario");

            migrationBuilder.DropTable(
                name: "FRM01_TipoFormulario");

            migrationBuilder.DropTable(
                name: "SIST05_EstadoRegistro");

            migrationBuilder.DropTable(
                name: "SERV01_Servicio");

            migrationBuilder.DropTable(
                name: "CTT01_Contrato");

            migrationBuilder.DropTable(
                name: "LNC01_Licencias");

            migrationBuilder.DropTable(
                name: "LOG03_MensajeBitacora");

            migrationBuilder.DropTable(
                name: "ESP02_TemporadaEspecie");

            migrationBuilder.DropTable(
                name: "MNT01_Monitores");

            migrationBuilder.DropTable(
                name: "PBCD01_Publicidad");

            migrationBuilder.DropTable(
                name: "PER06_TipoPersonaComunicacion");

            migrationBuilder.DropTable(
                name: "PGO01_CompraLicencia");

            migrationBuilder.DropTable(
                name: "PRF03_Plantilla");

            migrationBuilder.DropTable(
                name: "PRF01_Perfiles");

            migrationBuilder.DropTable(
                name: "SECU01_Rol");

            migrationBuilder.DropTable(
                name: "SECU07_Aplicacion");

            migrationBuilder.DropTable(
                name: "SECU03_TipoAcceso");

            migrationBuilder.DropTable(
                name: "SERCL01_ServiciosClientes");

            migrationBuilder.DropTable(
                name: "CONTEO03_Resumen");

            migrationBuilder.DropTable(
                name: "SIST02_Zona");

            migrationBuilder.DropTable(
                name: "SIST03_Comuna");

            migrationBuilder.DropTable(
                name: "TRP01_Trampa");

            migrationBuilder.DropTable(
                name: "WKF05_TipoPermiso");

            migrationBuilder.DropTable(
                name: "WKF06_Perfiles");

            migrationBuilder.DropTable(
                name: "WKF10_TipoParametro");

            migrationBuilder.DropTable(
                name: "CNT13_TipoEmpleado");

            migrationBuilder.DropTable(
                name: "BLK02_TipoBloqueo");

            migrationBuilder.DropTable(
                name: "EML02_MailBase");

            migrationBuilder.DropTable(
                name: "SERV02_TipoServicio");

            migrationBuilder.DropTable(
                name: "CTT02_TipoContrato");

            migrationBuilder.DropTable(
                name: "LOG02_TipoBitacora");

            migrationBuilder.DropTable(
                name: "TEMP01_Temporada");

            migrationBuilder.DropTable(
                name: "MNT04_TipoMonitor");

            migrationBuilder.DropTable(
                name: "PBCD02_TipoPublicidad");

            migrationBuilder.DropTable(
                name: "PER04_TipoComunicacion");

            migrationBuilder.DropTable(
                name: "CNT19_LicenciaCliente");

            migrationBuilder.DropTable(
                name: "PGO03_TipoPagoLicencia");

            migrationBuilder.DropTable(
                name: "PRF05_TipoAsignacionUsuario");

            migrationBuilder.DropTable(
                name: "SECU02_Usuario");

            migrationBuilder.DropTable(
                name: "SIST04_Region");

            migrationBuilder.DropTable(
                name: "CNT08_Segmentacion");

            migrationBuilder.DropTable(
                name: "ESP01_Especies");

            migrationBuilder.DropTable(
                name: "WKF01_Flujo");

            migrationBuilder.DropTable(
                name: "EML03_TipoMailAcciones");

            migrationBuilder.DropTable(
                name: "EML04_ImportanciaMail");

            migrationBuilder.DropTable(
                name: "TEMP02_TemporadaBase");

            migrationBuilder.DropTable(
                name: "TEMP03_Segmentacion");

            migrationBuilder.DropTable(
                name: "SECU04_TipoEncriptacion");

            migrationBuilder.DropTable(
                name: "CNT01_CuentaCliente");

            migrationBuilder.DropTable(
                name: "CNT07_TipoSegmentacion");

            migrationBuilder.DropTable(
                name: "ESP03_EspecieBase");

            migrationBuilder.DropTable(
                name: "ESP04_EstadoDanio");

            migrationBuilder.DropTable(
                name: "WKF03_Nivel");

            migrationBuilder.DropTable(
                name: "CNT02_TipoCuenta");

            migrationBuilder.DropTable(
                name: "CNT03_TipoCliente");

            migrationBuilder.DropTable(
                name: "PER01_Persona");

            migrationBuilder.DropTable(
                name: "CNT18_NivelSegmentacion");

            migrationBuilder.DropTable(
                name: "ESP08_TipoBase");

            migrationBuilder.DropTable(
                name: "ESP06_MedidaUmbral");

            migrationBuilder.DropTable(
                name: "WKF02_TipoFlujo");

            migrationBuilder.DropTable(
                name: "PER02_Genero");

            migrationBuilder.DropTable(
                name: "PER03_TipoPersona");
        }
    }
}
