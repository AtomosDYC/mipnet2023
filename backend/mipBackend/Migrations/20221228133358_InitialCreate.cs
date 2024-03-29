﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mipBackend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BLK02_TipoBloqueo",
                columns: table => new
                {
                    BLK02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BLK02_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BLK02_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BLK02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLK02_TipoBloqueo", x => x.BLK02_llave);
                });

            migrationBuilder.CreateTable(
                name: "CLBR02_TipoCalibracion",
                columns: table => new
                {
                    CLBR02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLBR02_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CLBR02_descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CLBR02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLBR02_TipoCalibracion", x => x.CLBR02_llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT02_TipoCuenta",
                columns: table => new
                {
                    CNT02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT02_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT02_descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT02_TipoCuenta", x => x.CNT02_llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT05_TipoContacto",
                columns: table => new
                {
                    CNT05_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT05_nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT05_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT05_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT05_TipoContacto", x => x.CNT05_llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT10_TipoComunicacion",
                columns: table => new
                {
                    CNT10_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT10_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT10_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT10_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT10_TipoComunicacion", x => x.CNT10_llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT13_TipoEmpleado",
                columns: table => new
                {
                    CNT13_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT13_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT13_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT13_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT13_TipoEmpleado", x => x.CNT13_llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT16_TipoBloqueoCliente",
                columns: table => new
                {
                    CNT16_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT16_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT16_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT16_activo = table.Column<bool>(type: "bit", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT16_TipoBloqueoCliente", x => x.CNT16_llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT18_NivelSegmentacion",
                columns: table => new
                {
                    CNT18_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT18_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT18_Descripccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT18_NivelCapa = table.Column<int>(type: "int", nullable: true),
                    CNT18_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT18_NivelSegmentacion", x => x.CNT18_llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT21_TipoEstacion",
                columns: table => new
                {
                    CNT21_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT21_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT21_descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT21_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT21_TipoEstacion", x => x.CNT21_llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT23_Tipocobro",
                columns: table => new
                {
                    CNT23_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT23_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT23_descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CNT23_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT23_Tipocobro", x => x.CNT23_llave);
                });

            migrationBuilder.CreateTable(
                name: "CNT24_AsociarCuenta",
                columns: table => new
                {
                    CNT01_llave = table.Column<int>(type: "int", nullable: false),
                    CNT01_Cuenta_llave = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT24_AsociarCuenta", x => new { x.CNT01_llave, x.CNT01_Cuenta_llave });
                });

            migrationBuilder.CreateTable(
                name: "CONT02_TipoContacto",
                columns: table => new
                {
                    CONT02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONT02_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONT02_descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONT02_TipoContacto", x => x.CONT02_llave);
                });

            migrationBuilder.CreateTable(
                name: "CTT02_TipoContrato",
                columns: table => new
                {
                    CTT02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTT02_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CTT02_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CTT02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTT02_TipoContrato", x => x.CTT02_llave);
                });

            migrationBuilder.CreateTable(
                name: "CTZR01_Cotizacion",
                columns: table => new
                {
                    CTZR01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LNC01_llave = table.Column<int>(type: "int", nullable: true),
                    CTZR01_fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    CTZR01_comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CTZR01_activo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTZR01_Cotizacion", x => x.CTZR01_llave);
                });

            migrationBuilder.CreateTable(
                name: "EML03_TipoMailAcciones",
                columns: table => new
                {
                    EML03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EML03_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EML03_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML03_activo = table.Column<int>(type: "int", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EML03_TipoMailAcciones_1", x => x.EML03_llave);
                });

            migrationBuilder.CreateTable(
                name: "EML04_ImportanciaMail",
                columns: table => new
                {
                    EML04_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EML04_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EML04_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML04_activo = table.Column<int>(type: "int", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EML04_ImportanciaMail", x => x.EML04_llave);
                });

            migrationBuilder.CreateTable(
                name: "EML06_TipoArchivo",
                columns: table => new
                {
                    EML06_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EML06_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EML06_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML06_activo = table.Column<int>(type: "int", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EML06_TipoArchivo", x => x.EML06_llave);
                });

            migrationBuilder.CreateTable(
                name: "ESP06_MedidaUmbral",
                columns: table => new
                {
                    ESP06_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP06_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP06_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ESP06_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP06_MedidaUmbral", x => x.ESP06_llave);
                });

            migrationBuilder.CreateTable(
                name: "ESP08_TipoBase",
                columns: table => new
                {
                    ESP08_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP08_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ESP08_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESP08_activo = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP08_TipoBase", x => x.ESP08_llave);
                });

            migrationBuilder.CreateTable(
                name: "ESP09_TipoBaseUmbral",
                columns: table => new
                {
                    ESP09_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP09_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP09_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ESP09_activo = table.Column<int>(type: "int", nullable: true),
                    ESP09_Orden = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP09_TipoBaseUmbral", x => x.ESP09_llave);
                });

            migrationBuilder.CreateTable(
                name: "ESP10_TipoRegla",
                columns: table => new
                {
                    ESP10_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP10_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP10_descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP10_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP10_TipoRegla", x => x.ESP10_llave);
                });

            migrationBuilder.CreateTable(
                name: "FRM01_TipoFormulario",
                columns: table => new
                {
                    FRM01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FRM01_nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FRM01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FRM01_TipoFormulario", x => x.FRM01_llave);
                });

            migrationBuilder.CreateTable(
                name: "GRFC01_GraficoGenerado",
                columns: table => new
                {
                    GRFC01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GRFC01_FechaGrafico = table.Column<DateTime>(type: "datetime", nullable: true),
                    GRFC01_codigo_grafico = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    GRFC02_llave = table.Column<int>(type: "int", nullable: true),
                    GRFC01_estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRFC01_GraficoGenerado", x => x.GRFC01_llave);
                });

            migrationBuilder.CreateTable(
                name: "GRFC02_TipoGrafico",
                columns: table => new
                {
                    GRFC02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GRFC02_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GRFC02_descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GRFC02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRFC02_TipoGrafico", x => x.GRFC02_llave);
                });

            migrationBuilder.CreateTable(
                name: "GRFC03_respaldoGrafico",
                columns: table => new
                {
                    GRFC03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: true),
                    ESP03_llave = table.Column<int>(type: "int", nullable: true),
                    CNT08_llave = table.Column<int>(type: "int", nullable: true),
                    GRFC03_ultimaFecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    GRFC03_xmlDatos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GRFC03_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRFC03_respaldoGrafico", x => x.GRFC03_llave);
                });

            migrationBuilder.CreateTable(
                name: "Inmuebles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmuebles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "INS01_Inscripcion",
                columns: table => new
                {
                    INS01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INS01_Rut = table.Column<int>(type: "int", nullable: true),
                    PER02_llave = table.Column<int>(type: "int", nullable: true),
                    INS01_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    INS01_Apellido = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    INS01_Empresa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SIST03_llave = table.Column<int>(type: "int", nullable: true),
                    INS01_Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    INS01_Telefono = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    INS01_FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    INS01_Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    INS01_FechaInscripcion = table.Column<DateTime>(type: "datetime", nullable: true),
                    INS01_activo = table.Column<int>(type: "int", nullable: true),
                    INS01_fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    INS01_UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    INS01_Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INS01_Inscripcion", x => x.INS01_llave);
                });

            migrationBuilder.CreateTable(
                name: "LNC01_Licencias",
                columns: table => new
                {
                    LNC01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LNC01_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LNC01_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LNC04_llave = table.Column<int>(type: "int", nullable: true),
                    LNC01_MaximoUsuarios = table.Column<int>(type: "int", nullable: true),
                    LNC01_NumeroDias = table.Column<int>(type: "int", nullable: true),
                    LNC01_TextoDias = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LNC01_VisibleUsuario = table.Column<int>(type: "int", nullable: true),
                    LNC01_Imagen = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LNC01_HTML = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LNC01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC01_Licencias", x => x.LNC01_llave);
                });

            migrationBuilder.CreateTable(
                name: "LNC04_TipoLicencia",
                columns: table => new
                {
                    LNC04_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LNC04_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LNC04_descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LNC04_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC04_TipoLicencia", x => x.LNC04_llave);
                });

            migrationBuilder.CreateTable(
                name: "LOG02_TipoBitacora",
                columns: table => new
                {
                    LOG02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    LOG02_nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    LOG02_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOG02_Essistema = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    LOG02_EsRazor = table.Column<int>(type: "int", nullable: true),
                    LOG02_Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOG02_activo = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOG02_Ti__EA456AA523FE4082", x => x.LOG02_llave);
                });

            migrationBuilder.CreateTable(
                name: "MEN01_sistema",
                columns: table => new
                {
                    MEN01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MEN01_url = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MEN01_titulo = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MEN01_descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MEN01_tooltip = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MEN01_Area = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MEN01_Control = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MEN01_Accion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MEN01_llave_padre = table.Column<int>(type: "int", nullable: true),
                    MEN01_IconoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MEN01_principal = table.Column<bool>(type: "bit", nullable: false),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MEN01_Si__4F35303B75CD617E", x => x.MEN01_llave);
                });

            migrationBuilder.CreateTable(
                name: "MNT04_TipoMonitor",
                columns: table => new
                {
                    MNT04_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MNT04_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MNT04_descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MNT04_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MNT05_TipoBase", x => x.MNT04_llave);
                });

            migrationBuilder.CreateTable(
                name: "MVL01_AccesoMovil",
                columns: table => new
                {
                    MVL01_llave = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MVL01_id_usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MVL01_numero_movil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MVL01_sistema_android = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MVL01_version_android = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MVL01_version_aplicacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MVL01_version_descarga = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MVL01_esta_bloqueado = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    MVL01_mensaje_movil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MVL01_fecha_mensaje = table.Column<DateTime>(type: "datetime", nullable: true),
                    MVL01_fecha_registro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    MVL01_fecha_ultimo_acceso = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    MVL01_fecha_ultima_actividad = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    MVL01_fecha_ultima_sincro = table.Column<DateTime>(type: "datetime", nullable: true),
                    MVL01_tamano_basedatos_cliente = table.Column<int>(type: "int", nullable: true),
                    MVL01_ubicacion_actividad_x = table.Column<int>(type: "int", nullable: true),
                    MVL01_ubicacion_actividad_y = table.Column<int>(type: "int", nullable: true),
                    MVL01_edita_fecha_monitoreo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    MVL01_dias_umbral_edicion = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MVL02_TablaSincronizacion",
                columns: table => new
                {
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_Tabla = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Fecha_UltimaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MVL03_RegistroAcceso",
                columns: table => new
                {
                    MVL03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PER01_llave = table.Column<int>(type: "int", nullable: true),
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
                    SECU02_activo = table.Column<bool>(type: "bit", nullable: true),
                    nombre_usuario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    email_usuario = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    estado_usuario = table.Column<int>(type: "int", nullable: true),
                    MVL03_FECHACREACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MVL03_RegistroAcceso", x => x.MVL03_llave);
                });

            migrationBuilder.CreateTable(
                name: "OBSC02_ServicioPostcosecha",
                columns: table => new
                {
                    OBSC02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP08_llave = table.Column<int>(type: "int", nullable: true),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: true),
                    OBSC02_nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OBSC02_Resumen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OBSC02_activo = table.Column<int>(type: "int", nullable: true),
                    OBSC02_Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    OBSC02_UrlPdf = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OBSC02_ServicioPostcosecha", x => x.OBSC02_llave);
                });

            migrationBuilder.CreateTable(
                name: "PBCD02_TipoPublicidad",
                columns: table => new
                {
                    PBCD02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PBCD02_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PBCD02_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PBCD02_TipoPublicidad", x => x.PBCD02_llave);
                });

            migrationBuilder.CreateTable(
                name: "PER02_Genero",
                columns: table => new
                {
                    PER02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER02_Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER02_Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER02_Sexo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER02_Orden = table.Column<int>(type: "int", nullable: true),
                    PER02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER02_Genero", x => x.PER02_llave);
                });

            migrationBuilder.CreateTable(
                name: "PER03_Tipopersona",
                columns: table => new
                {
                    PER03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER03_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PER03_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER03_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER03_Tipopersona", x => x.PER03_llave);
                });

            migrationBuilder.CreateTable(
                name: "PER04_TipoComunicacion",
                columns: table => new
                {
                    PER04_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER04_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PER04_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER04_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER04_TipoComunicacion", x => x.PER04_llave);
                });

            migrationBuilder.CreateTable(
                name: "PGO03_TipoPagoLicencia",
                columns: table => new
                {
                    PGO03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PGO03_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PGO03_descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PGO03_activo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PGO03_FormaPago", x => x.PGO03_llave);
                });

            migrationBuilder.CreateTable(
                name: "PRF03_Plantilla",
                columns: table => new
                {
                    PRF03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRF03_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PRF03_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRF03_estadoRegistro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PRF03_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRF03_PlantillaFlujo", x => x.PRF03_llave);
                });

            migrationBuilder.CreateTable(
                name: "PRF05_TipoAsignacionUsuario",
                columns: table => new
                {
                    PRF05_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRF05_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PRF05_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRF05_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRF05_TipoAsignacionUsuario", x => x.PRF05_llave);
                });

            migrationBuilder.CreateTable(
                name: "PRM01_Seguridad",
                columns: table => new
                {
                    PRM01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRM01_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PRM01_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRM01_valor = table.Column<int>(type: "int", nullable: true),
                    PRM01_UrlError = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PRM01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRM01_Seguridad", x => x.PRM01_llave);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SECU01_Rol",
                columns: table => new
                {
                    SECU01_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SECU01_nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SECU01_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECU01_Orden = table.Column<int>(type: "int", nullable: true),
                    SECU01_Info = table.Column<string>(type: "xml", nullable: true),
                    SECU01_activo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SECU01_R__2E718C9349B338EE", x => x.SECU01_llave);
                });

            migrationBuilder.CreateTable(
                name: "SECU03_TipoAcceso",
                columns: table => new
                {
                    SECU03_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    SECU03_nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SECU03_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECU03_Info = table.Column<string>(type: "xml", nullable: true),
                    SECU03_activo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SECU03_T__7B6F14E7DEC70462", x => x.SECU03_llave);
                });

            migrationBuilder.CreateTable(
                name: "SECU04_TipoEncriptacion",
                columns: table => new
                {
                    SECU04_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SECU04_nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SECU04_Proyecto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECU04_Clase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECU04_Funcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECU04_Parametros = table.Column<string>(type: "xml", nullable: true),
                    SECU04_Info = table.Column<string>(type: "xml", nullable: true),
                    SECU04_activo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SECU04_T__3412AACF89203574", x => x.SECU04_llave);
                });

            migrationBuilder.CreateTable(
                name: "SECU07_Aplicacion",
                columns: table => new
                {
                    SECU07_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SECU07_nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SECU07_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECU07_Info = table.Column<string>(type: "xml", nullable: true),
                    SECU07_activo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SECU07_A__148FCE85966FFC87", x => x.SECU07_llave);
                });

            migrationBuilder.CreateTable(
                name: "SECU11_Tipoperfil",
                columns: table => new
                {
                    PRF02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRF02_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PRF02_descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FECHAACTULIZACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SECU11_Tipoperfil", x => x.PRF02_llave);
                });

            migrationBuilder.CreateTable(
                name: "SERCL01_ServiciosClientes",
                columns: table => new
                {
                    SERCL01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT19_llave = table.Column<int>(type: "int", nullable: true),
                    SERV01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT08_llave = table.Column<int>(type: "int", nullable: true),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: true),
                    ESP03_llave = table.Column<int>(type: "int", nullable: true),
                    ESP04_llave = table.Column<int>(type: "int", nullable: true),
                    ESP08_llave = table.Column<int>(type: "int", nullable: true),
                    SISt04_llave = table.Column<int>(type: "int", nullable: true),
                    SIST03_llave = table.Column<int>(type: "int", nullable: true),
                    SERCL01_TipoGrafico = table.Column<int>(type: "int", nullable: true),
                    CONTEO03_llave = table.Column<int>(type: "int", nullable: true),
                    SERCL01_Costo = table.Column<int>(type: "int", nullable: true),
                    SERCL01_cantidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERCL01_ServiciosClientes", x => x.SERCL01_llave);
                });

            migrationBuilder.CreateTable(
                name: "SERV02_TipoServicio",
                columns: table => new
                {
                    SERV02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERV02_nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SERV02_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SERV02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERV02_TipoServicio", x => x.SERV02_llave);
                });

            migrationBuilder.CreateTable(
                name: "SIST01_sistema",
                columns: table => new
                {
                    SIST01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST01_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SIST01_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST01_EsPublica = table.Column<bool>(type: "bit", nullable: true),
                    SIST01_EsServicios = table.Column<bool>(type: "bit", nullable: true),
                    SIST01_activo = table.Column<bool>(type: "bit", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST01_sistema", x => x.SIST01_llave);
                });

            migrationBuilder.CreateTable(
                name: "SIST02_Zona",
                columns: table => new
                {
                    SIST02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST02_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST02_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIST02_estadoregistro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SIST02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST02_Zona", x => x.SIST02_llave);
                });

            migrationBuilder.CreateTable(
                name: "SIST04_Region",
                columns: table => new
                {
                    SIST04_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST04_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SIST04_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST04_Orden = table.Column<int>(type: "int", nullable: true),
                    SIST04_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST04_Region", x => x.SIST04_llave);
                });

            migrationBuilder.CreateTable(
                name: "SIST05_EstadoRegistro",
                columns: table => new
                {
                    SIST05_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST05_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST03_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIST03_activo = table.Column<int>(type: "int", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST05_EstadoRegistro", x => x.SIST05_llave);
                });

            migrationBuilder.CreateTable(
                name: "SIST06_EstadoGrid",
                columns: table => new
                {
                    SIST06_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST06_nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SIST06_activo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST06_EstadoGrid", x => x.SIST06_llave);
                });

            migrationBuilder.CreateTable(
                name: "TEMP02_TemporadaBase",
                columns: table => new
                {
                    TEMP02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMP02_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TEMP02_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TEMP02_Predeterminada = table.Column<int>(type: "int", nullable: true),
                    TEMP02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEMP02_TemporadaBase", x => x.TEMP02_llave);
                });

            migrationBuilder.CreateTable(
                name: "TEMP03_Segmentacion",
                columns: table => new
                {
                    TEMP03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMP03_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TEMP03_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TEMP03_NumeroMeses = table.Column<int>(type: "int", nullable: true),
                    TEMP03_NumeroSegmentosTotal = table.Column<int>(type: "int", nullable: true),
                    TEMP03_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEMP03_Segmentacion", x => x.TEMP03_llave);
                });

            migrationBuilder.CreateTable(
                name: "TRP03_geocordenadas",
                columns: table => new
                {
                    TRP01_llave = table.Column<int>(type: "int", nullable: false),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: false),
                    x = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    y = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRP03_geocordenadas", x => new { x.TRP01_llave, x.TEMP02_llave });
                });

            migrationBuilder.CreateTable(
                name: "WKF02_TipoFlujo",
                columns: table => new
                {
                    WKF02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF02_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WKF02_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF02_orden = table.Column<int>(type: "int", nullable: true),
                    WKF02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF02_TipoFlujo", x => x.WKF02_llave);
                });

            migrationBuilder.CreateTable(
                name: "WKF05_Tipopermiso",
                columns: table => new
                {
                    WKF05_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF05_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF05_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WKF05_sigla = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    WKF05_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF05_Tipoperfil", x => x.WKF05_llave);
                });

            migrationBuilder.CreateTable(
                name: "WKF08_Area",
                columns: table => new
                {
                    wfk08_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wfk08_nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    wfk08_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    wfk08_activo = table.Column<bool>(type: "bit", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wfk08_Area", x => x.wfk08_llave);
                });

            migrationBuilder.CreateTable(
                name: "WKF10_TipoParametro",
                columns: table => new
                {
                    WKF10_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF10_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF10_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WKF10_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF10_TipoParametro", x => x.WKF10_llave);
                });

            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BLK01_Bloqueos",
                columns: table => new
                {
                    BLK01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BLK02_llave = table.Column<int>(type: "int", nullable: true),
                    BLK01_nombreBloqueo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BLK01_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BLK01_permanente = table.Column<int>(type: "int", nullable: true),
                    BLK01_MinDuraciondia = table.Column<int>(type: "int", nullable: true),
                    BLK01_MaxDuraciondia = table.Column<int>(type: "int", nullable: true),
                    BLK01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLK01_Bloqueos", x => x.BLK01_llave);
                    table.ForeignKey(
                        name: "FK_BLK01_Bloqueos_BLK02_TipoBloqueo",
                        column: x => x.BLK02_llave,
                        principalTable: "BLK02_TipoBloqueo",
                        principalColumn: "BLK02_llave");
                });

            migrationBuilder.CreateTable(
                name: "CLBR01_Calibracion",
                columns: table => new
                {
                    CLBR01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERCL01_llave = table.Column<int>(type: "int", nullable: true),
                    CLBR02_llave = table.Column<int>(type: "int", nullable: true),
                    CNT01_llave = table.Column<int>(type: "int", nullable: true),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: true),
                    CLBR01_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CLBR01_UrlPdf = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CLBR01_descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CLBR01_FechaCalibracion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLBR01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLBR01_Calibracion", x => x.CLBR01_llave);
                    table.ForeignKey(
                        name: "FK_CLBR01_Calibracion_CLBR02_TipoCalibracion",
                        column: x => x.CLBR02_llave,
                        principalTable: "CLBR02_TipoCalibracion",
                        principalColumn: "CLBR02_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT07_TipoSegmentacion",
                columns: table => new
                {
                    CNT07_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT07_nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT07_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT18_llave = table.Column<int>(type: "int", nullable: true),
                    CNT02_llave = table.Column<int>(type: "int", nullable: true),
                    CNT07_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT07_TipoSegmentacion", x => x.CNT07_llave);
                    table.ForeignKey(
                        name: "FK_CNT07_TipoSegmentacion_CNT18_NivelSegmentacion",
                        column: x => x.CNT18_llave,
                        principalTable: "CNT18_NivelSegmentacion",
                        principalColumn: "CNT18_llave");
                });

            migrationBuilder.CreateTable(
                name: "CONT01_Contacto",
                columns: table => new
                {
                    CONT01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONT02_llave = table.Column<int>(type: "int", nullable: true),
                    CONT01_Titulo = table.Column<int>(type: "int", nullable: true),
                    CONT01_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONT01_Apellido = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONT01_Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONT01_Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONT01_Telefono = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONT01_PeticionContacto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CONT01_CodigoValidacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONT01_Contacto", x => x.CONT01_llave);
                    table.ForeignKey(
                        name: "FK_CONT01_Contacto_CONT02_TipoContacto",
                        column: x => x.CONT02_llave,
                        principalTable: "CONT02_TipoContacto",
                        principalColumn: "CONT02_llave");
                });

            migrationBuilder.CreateTable(
                name: "CTT01_Contrato",
                columns: table => new
                {
                    CTT01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTT02_llave = table.Column<int>(type: "int", nullable: true),
                    CTT01_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CTT01_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CTT01_ContratoHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CTT01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTT01_Contrato", x => x.CTT01_llave);
                    table.ForeignKey(
                        name: "FK_CTT01_Contrato_CTT02_TipoContrato",
                        column: x => x.CTT02_llave,
                        principalTable: "CTT02_TipoContrato",
                        principalColumn: "CTT02_llave");
                });

            migrationBuilder.CreateTable(
                name: "EML02_MailBase",
                columns: table => new
                {
                    EML02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EML03_llave = table.Column<int>(type: "int", nullable: true),
                    EML02_CodigoLlamado = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EML02_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML02_Asunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML02_ContenidoHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML02_ContenidoText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML02_activo = table.Column<int>(type: "int", nullable: true),
                    EML04_llave = table.Column<int>(type: "int", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EML02_MailBase", x => x.EML02_llave);
                    table.ForeignKey(
                        name: "FK_EML02_MailBase_EML03_TipoMailAcciones",
                        column: x => x.EML03_llave,
                        principalTable: "EML03_TipoMailAcciones",
                        principalColumn: "EML03_llave");
                    table.ForeignKey(
                        name: "FK_EML02_MailBase_EML04_ImportanciaMail",
                        column: x => x.EML04_llave,
                        principalTable: "EML04_ImportanciaMail",
                        principalColumn: "EML04_llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP04_EstadoDanio",
                columns: table => new
                {
                    ESP04_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP04_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP04_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ESP06_llave = table.Column<int>(type: "int", nullable: true),
                    ESP04_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP04_EstadoDanio", x => x.ESP04_llave);
                    table.ForeignKey(
                        name: "FK_ESP04_EstadoDanio_ESP06_MedidaUmbral",
                        column: x => x.ESP06_llave,
                        principalTable: "ESP06_MedidaUmbral",
                        principalColumn: "ESP06_llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP03_especieBase",
                columns: table => new
                {
                    ESP03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP03_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP03_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ESP08_llave = table.Column<int>(type: "int", nullable: true),
                    ESP03_ImgGrande = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESP03_ImgPequenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESP03_Union = table.Column<int>(type: "int", nullable: true),
                    ESP03_EstadoRegistro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ESP03_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP03_especieBase", x => x.ESP03_llave);
                    table.ForeignKey(
                        name: "FK_ESP03_especieBase_ESP08_TipoBase",
                        column: x => x.ESP08_llave,
                        principalTable: "ESP08_TipoBase",
                        principalColumn: "ESP08_llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP11_ReglaGrafico",
                columns: table => new
                {
                    ESP11_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP03_llave = table.Column<int>(type: "int", nullable: true),
                    ESP10_llave = table.Column<int>(type: "int", nullable: true),
                    ESP11_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ESP11_Signo1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ESP11_Valor1 = table.Column<int>(type: "int", nullable: true),
                    ESP11_Signo2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ESP11_Valor2 = table.Column<int>(type: "int", nullable: true),
                    ESP11_SignoResultado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ESP11_ValorResultado = table.Column<int>(type: "int", nullable: true),
                    ESP11_Estado = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP11_ReglaGrafico", x => x.ESP11_llave);
                    table.ForeignKey(
                        name: "FK_ESP11_ReglaGrafico_ESP10_TipoRegla",
                        column: x => x.ESP10_llave,
                        principalTable: "ESP10_TipoRegla",
                        principalColumn: "ESP10_llave");
                });

            migrationBuilder.CreateTable(
                name: "LNC05_valorLicencia",
                columns: table => new
                {
                    LNC05_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LNC01_llave = table.Column<int>(type: "int", nullable: true),
                    LNC05_Inicio = table.Column<int>(type: "int", nullable: true),
                    LNC05_Termino = table.Column<int>(type: "int", nullable: true),
                    LNC05_Valor = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC05_valorLicencia", x => x.LNC05_llave);
                    table.ForeignKey(
                        name: "FK_LNC05_valorLicencia_LNC01_Licencias",
                        column: x => x.LNC01_llave,
                        principalTable: "LNC01_Licencias",
                        principalColumn: "LNC01_llave");
                });

            migrationBuilder.CreateTable(
                name: "LNC06_Cobertura",
                columns: table => new
                {
                    LNC01_llave = table.Column<int>(type: "int", nullable: false),
                    SIST03_llave = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC05_Cobertura", x => new { x.LNC01_llave, x.SIST03_llave });
                    table.ForeignKey(
                        name: "FK_LNC06_Cobertura_LNC01_Licencias",
                        column: x => x.LNC01_llave,
                        principalTable: "LNC01_Licencias",
                        principalColumn: "LNC01_llave");
                });

            migrationBuilder.CreateTable(
                name: "LNC07_Control",
                columns: table => new
                {
                    LNC01_llave = table.Column<int>(type: "int", nullable: false),
                    ESP03_llave = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC07_Control", x => new { x.LNC01_llave, x.ESP03_llave });
                    table.ForeignKey(
                        name: "FK_LNC07_Control_LNC01_Licencias",
                        column: x => x.LNC01_llave,
                        principalTable: "LNC01_Licencias",
                        principalColumn: "LNC01_llave");
                });

            migrationBuilder.CreateTable(
                name: "LOG03_MensajeBitacora",
                columns: table => new
                {
                    LOG03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOG02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LOG03_AccesoRapido = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LOG03_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOG03_Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOG03_activo = table.Column<int>(type: "int", nullable: true),
                    LOG03_Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG03_MensajeBitacora", x => x.LOG03_llave);
                    table.ForeignKey(
                        name: "FK_LOG03_MensajeBitacora_LOG02_TipoBitacora",
                        column: x => x.LOG02_llave,
                        principalTable: "LOG02_TipoBitacora",
                        principalColumn: "LOG02_llave");
                });

            migrationBuilder.CreateTable(
                name: "MNT01_Monitores",
                columns: table => new
                {
                    MNT01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER01_llave = table.Column<int>(type: "int", nullable: true),
                    MNT04_llave = table.Column<int>(type: "int", nullable: true),
                    MNT01_Cargo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MNT01_iniciolabores = table.Column<DateTime>(type: "datetime", nullable: true),
                    MNT01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MNT01_Monitores", x => x.MNT01_llave);
                    table.ForeignKey(
                        name: "FK_MNT01_Monitores_MNT04_TipoMonitor",
                        column: x => x.MNT04_llave,
                        principalTable: "MNT04_TipoMonitor",
                        principalColumn: "MNT04_llave");
                });

            migrationBuilder.CreateTable(
                name: "PBCD01_Publicidad",
                columns: table => new
                {
                    PBCD01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PBCD02_llave = table.Column<int>(type: "int", nullable: true),
                    PBCD01_Objetico = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01_FrasePrincipal = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01_FraseSecundaria = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01_SecuenciaHtml = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01_Imagennombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01_Producto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01_Problema = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PBCD01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PBCD01_Publicidad", x => x.PBCD01_llave);
                    table.ForeignKey(
                        name: "FK_PBCD01_Publicidad_PBCD02_TipoPublicidad",
                        column: x => x.PBCD02_llave,
                        principalTable: "PBCD02_TipoPublicidad",
                        principalColumn: "PBCD02_llave");
                });

            migrationBuilder.CreateTable(
                name: "SIST08_ContactoUsuario",
                columns: table => new
                {
                    SIST08_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER02_llave = table.Column<int>(type: "int", nullable: true),
                    SIST08_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SIST08_Empresa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SIST08_Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SIST08_Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIST08_Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SIST08_Celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SIST08_Estado = table.Column<int>(type: "int", nullable: true),
                    SIST08_FECHACREACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST08_ContactoUsuario", x => x.SIST08_llave);
                    table.ForeignKey(
                        name: "FK_SIST08_ContactoUsuario_PER02_Genero",
                        column: x => x.PER02_llave,
                        principalTable: "PER02_Genero",
                        principalColumn: "PER02_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT03_TipoCliente",
                columns: table => new
                {
                    CNT03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER03_llave = table.Column<int>(type: "int", nullable: true),
                    CNT03_nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT03_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT03_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT03_TipoCliente", x => x.CNT03_llave);
                    table.ForeignKey(
                        name: "FK_CNT03_TipoCliente_PER03_Tipopersona",
                        column: x => x.PER03_llave,
                        principalTable: "PER03_Tipopersona",
                        principalColumn: "PER03_llave");
                });

            migrationBuilder.CreateTable(
                name: "PER01_persona",
                columns: table => new
                {
                    PER01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER01_Rut = table.Column<int>(type: "int", nullable: true),
                    PER03_llave = table.Column<int>(type: "int", nullable: true),
                    PER02_llave = table.Column<int>(type: "int", nullable: true),
                    PER01_nombreRazon = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER01_nombreFantasia = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER01_Giro = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER01_Cargo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER01_FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    PER01_AnioIngreso = table.Column<int>(type: "int", nullable: true),
                    PER01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER01_persona", x => x.PER01_llave);
                    table.ForeignKey(
                        name: "FK_PER01_persona_PER02_Genero",
                        column: x => x.PER02_llave,
                        principalTable: "PER02_Genero",
                        principalColumn: "PER02_llave");
                    table.ForeignKey(
                        name: "FK_PER01_persona_PER03_Tipopersona",
                        column: x => x.PER03_llave,
                        principalTable: "PER03_Tipopersona",
                        principalColumn: "PER03_llave");
                });

            migrationBuilder.CreateTable(
                name: "PER06_TipopersonaComunicacion",
                columns: table => new
                {
                    PER03_llave = table.Column<int>(type: "int", nullable: false),
                    PER04_llave = table.Column<int>(type: "int", nullable: false),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER06_TipopersonaComunicacion", x => new { x.PER03_llave, x.PER04_llave });
                    table.ForeignKey(
                        name: "FK_PER06_TipopersonaComunicacion_PER03_Tipopersona",
                        column: x => x.PER03_llave,
                        principalTable: "PER03_Tipopersona",
                        principalColumn: "PER03_llave");
                    table.ForeignKey(
                        name: "FK_PER06_TipopersonaComunicacion_PER04_TipoComunicacion",
                        column: x => x.PER04_llave,
                        principalTable: "PER04_TipoComunicacion",
                        principalColumn: "PER04_llave");
                });

            migrationBuilder.CreateTable(
                name: "Comunas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCapital = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comunas_Regiones_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regiones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SECU02_Usuario",
                columns: table => new
                {
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SECU02_Usuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SECU02_Clave = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SECU02_ComplementoClave = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SECU04_TipoEncriptacion = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SECU02_Movil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SECU02_Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SECU02_Pregunta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECU02_Respuesta = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    SECU02_Bloqueado = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    SECU02_FechaBloqueo = table.Column<DateTime>(type: "datetime", nullable: true),
                    SECU02_FechaCambioPass = table.Column<DateTime>(type: "datetime", nullable: true),
                    SECU02_activo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SECU02_U__B709E3CA34F4CE22", x => x.SECU02_llave);
                    table.ForeignKey(
                        name: "FK_SECU02_Usuario_SECU04_TipoEncriptacion1",
                        column: x => x.SECU04_TipoEncriptacion,
                        principalTable: "SECU04_TipoEncriptacion",
                        principalColumn: "SECU04_llave");
                });

            migrationBuilder.CreateTable(
                name: "SERCL02_MuestreoFruta",
                columns: table => new
                {
                    SERCL02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERCL01_llave = table.Column<int>(type: "int", nullable: true),
                    SERCL02_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SERCL02_UrlPdf = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SERCL02_Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    SERCL02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERCL02_MuestreoFruta", x => x.SERCL02_llave);
                    table.ForeignKey(
                        name: "FK_SERCL02_MuestreoFruta_SERCL01_ServiciosClientes",
                        column: x => x.SERCL01_llave,
                        principalTable: "SERCL01_ServiciosClientes",
                        principalColumn: "SERCL01_llave");
                });

            migrationBuilder.CreateTable(
                name: "SERV01_Servicio",
                columns: table => new
                {
                    SERV01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERV02_llave = table.Column<int>(type: "int", nullable: true),
                    SERV01_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SERV01_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SERV01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERV01_Servicio", x => x.SERV01_llave);
                    table.ForeignKey(
                        name: "FK_SERV01_Servicio_SERV02_TipoServicio",
                        column: x => x.SERV02_llave,
                        principalTable: "SERV02_TipoServicio",
                        principalColumn: "SERV02_llave");
                });

            migrationBuilder.CreateTable(
                name: "SIST03_Comuna",
                columns: table => new
                {
                    SIST03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST04_llave = table.Column<int>(type: "int", nullable: true),
                    SIST03_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SIST03_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST03_Capital = table.Column<int>(type: "int", nullable: true),
                    SIST03_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST03_Comuna", x => x.SIST03_llave);
                    table.ForeignKey(
                        name: "FK_SIST03_Comuna_SIST04_Region",
                        column: x => x.SIST04_llave,
                        principalTable: "SIST04_Region",
                        principalColumn: "SIST04_llave");
                });

            migrationBuilder.CreateTable(
                name: "INS02_RecuperarClave",
                columns: table => new
                {
                    INS02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    INS02_ClaveTemporal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    INS02_FechaRecupera = table.Column<DateTime>(type: "datetime", nullable: true),
                    INS02_Estado = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INS02_RecuperarClave", x => x.INS02_llave);
                    table.ForeignKey(
                        name: "FK_INS02_RecuperarClave_SIST05_EstadoRegistro",
                        column: x => x.INS02_Estado,
                        principalTable: "SIST05_EstadoRegistro",
                        principalColumn: "SIST05_llave");
                });

            migrationBuilder.CreateTable(
                name: "CONTEO01_Conteos",
                columns: table => new
                {
                    CONTEO01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRP01_llave = table.Column<int>(type: "int", nullable: true),
                    CONTEO01_Valor = table.Column<int>(type: "int", nullable: true),
                    CONTEO01_FechaIngreso = table.Column<DateTime>(type: "datetime", nullable: true),
                    CONTEO01_HoraIngreso = table.Column<DateTime>(type: "datetime", nullable: true),
                    CONTEO01_EstadoVisado = table.Column<int>(type: "int", nullable: true),
                    CONTEO01_x = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CONTEO01_y = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CONTEO01_observacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CONTEO01_EstadoConteo = table.Column<int>(type: "int", nullable: true),
                    CONTEO01_Tiposistema = table.Column<int>(type: "int", nullable: true),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: true),
                    MVL01_llave = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FECHACREACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTEO01_Conteos", x => x.CONTEO01_llave);
                    table.ForeignKey(
                        name: "FK_CONTEO01_Conteos_TEMP02_TemporadaBase",
                        column: x => x.TEMP02_llave,
                        principalTable: "TEMP02_TemporadaBase",
                        principalColumn: "TEMP02_llave");
                });

            migrationBuilder.CreateTable(
                name: "OBSC01_ObservacionCampo",
                columns: table => new
                {
                    OBSC01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP08_llave = table.Column<int>(type: "int", nullable: true),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: true),
                    OBSC01_nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OBSC01_Resumen = table.Column<string>(type: "nchar(1000)", fixedLength: true, maxLength: 1000, nullable: true),
                    OBSC01_activo = table.Column<int>(type: "int", nullable: true),
                    OBSC01_FechaObservacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    OBSC01_UrlPdf = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OBSC01_interesado = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OBSC01_ObservacionCampo", x => x.OBSC01_llave);
                    table.ForeignKey(
                        name: "FK_OBSC01_ObservacionCampo_ESP08_TipoBase",
                        column: x => x.ESP08_llave,
                        principalTable: "ESP08_TipoBase",
                        principalColumn: "ESP08_llave");
                    table.ForeignKey(
                        name: "FK_OBSC01_ObservacionCampo_TEMP02_TemporadaBase",
                        column: x => x.TEMP02_llave,
                        principalTable: "TEMP02_TemporadaBase",
                        principalColumn: "TEMP02_llave");
                });

            migrationBuilder.CreateTable(
                name: "TEMP01_Temporada",
                columns: table => new
                {
                    TEMP01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMP01_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TEMP01_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: true),
                    TEMP03_llave = table.Column<int>(type: "int", nullable: true),
                    TEMP01_MinFecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    TEMP01_MaxFecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    TEMP01_MinMes = table.Column<int>(type: "int", nullable: true),
                    TEMP01_MaxMes = table.Column<int>(type: "int", nullable: true),
                    TEMP01_periodo = table.Column<int>(type: "int", nullable: true),
                    TEMP01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEMP01_Temporada", x => x.TEMP01_llave);
                    table.ForeignKey(
                        name: "FK_TEMP01_Temporada_TEMP02_TemporadaBase",
                        column: x => x.TEMP02_llave,
                        principalTable: "TEMP02_TemporadaBase",
                        principalColumn: "TEMP02_llave");
                    table.ForeignKey(
                        name: "FK_TEMP01_Temporada_TEMP03_Segmentacion",
                        column: x => x.TEMP03_llave,
                        principalTable: "TEMP03_Segmentacion",
                        principalColumn: "TEMP03_llave");
                });

            migrationBuilder.CreateTable(
                name: "WKF03_Nivel",
                columns: table => new
                {
                    WKF03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF02_llave = table.Column<int>(type: "int", nullable: true),
                    WKF03_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WKF03_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WKF03_activo = table.Column<int>(type: "int", nullable: true),
                    WKF03_Nivel = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF03_Nivel", x => x.WKF03_llave);
                    table.ForeignKey(
                        name: "FK_WKF03_Nivel_WKF02_TipoFlujo",
                        column: x => x.WKF02_llave,
                        principalTable: "WKF02_TipoFlujo",
                        principalColumn: "WKF02_llave");
                });

            migrationBuilder.CreateTable(
                name: "BLK03_BloqueoUsuario",
                columns: table => new
                {
                    BLK03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BLK01_llave = table.Column<int>(type: "int", nullable: true),
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BLK03_FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    BLK03_FechaTermino = table.Column<DateTime>(type: "datetime", nullable: true),
                    BLK03_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLK03_BloqueoUsuario", x => x.BLK03_llave);
                    table.ForeignKey(
                        name: "FK_BLK03_BloqueoUsuario_BLK01_Bloqueos",
                        column: x => x.BLK01_llave,
                        principalTable: "BLK01_Bloqueos",
                        principalColumn: "BLK01_llave");
                });

            migrationBuilder.CreateTable(
                name: "LNC03_LicenciaContrato",
                columns: table => new
                {
                    LNC01_llave = table.Column<int>(type: "int", nullable: false),
                    CTT01_llave = table.Column<int>(type: "int", nullable: false),
                    LNC03_FirmaSimpre = table.Column<int>(type: "int", nullable: true),
                    LNC03_activo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC03_LicenciaContrato_1", x => new { x.LNC01_llave, x.CTT01_llave });
                    table.ForeignKey(
                        name: "FK_LNC03_LicenciaContrato_CTT01_Contrato",
                        column: x => x.CTT01_llave,
                        principalTable: "CTT01_Contrato",
                        principalColumn: "CTT01_llave");
                    table.ForeignKey(
                        name: "FK_LNC03_LicenciaContrato_LNC01_Licencias",
                        column: x => x.LNC01_llave,
                        principalTable: "LNC01_Licencias",
                        principalColumn: "LNC01_llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP01_especies",
                columns: table => new
                {
                    ESP01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP03_llave = table.Column<int>(type: "int", nullable: true),
                    ESP04_llave = table.Column<int>(type: "int", nullable: true),
                    ESP01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP01_especies", x => x.ESP01_llave);
                    table.ForeignKey(
                        name: "FK_ESP01_especies_ESP03_especieBase",
                        column: x => x.ESP03_llave,
                        principalTable: "ESP03_especieBase",
                        principalColumn: "ESP03_llave");
                    table.ForeignKey(
                        name: "FK_ESP01_especies_ESP04_EstadoDanio",
                        column: x => x.ESP04_llave,
                        principalTable: "ESP04_EstadoDanio",
                        principalColumn: "ESP04_llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP07_Union",
                columns: table => new
                {
                    ESP03_llave = table.Column<int>(type: "int", nullable: false),
                    ESP03_llaveUnion = table.Column<int>(type: "int", nullable: false),
                    esp07llave = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP07_Union", x => new { x.ESP03_llave, x.ESP03_llaveUnion });
                    table.ForeignKey(
                        name: "FK_ESP07_Union_ESP03_especieBase",
                        column: x => x.ESP03_llave,
                        principalTable: "ESP03_especieBase",
                        principalColumn: "ESP03_llave");
                });

            migrationBuilder.CreateTable(
                name: "LOG01_Bitacora",
                columns: table => new
                {
                    LOG01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOG03_llave = table.Column<int>(type: "int", nullable: true),
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LOG01_Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOG01_objeto = table.Column<int>(type: "int", nullable: true),
                    LOG01_Clase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOG01_elemento_serializado = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LOG01_Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOG01_activo = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG01_Bitacora", x => x.LOG01_llave);
                    table.ForeignKey(
                        name: "FK_LOG01_Bitacora_LOG03_MensajeBitacora",
                        column: x => x.LOG03_llave,
                        principalTable: "LOG03_MensajeBitacora",
                        principalColumn: "LOG03_llave");
                });

            migrationBuilder.CreateTable(
                name: "MNT03_periodosTrampas",
                columns: table => new
                {
                    MNT01_llave = table.Column<int>(type: "int", nullable: false),
                    TRP01_llave = table.Column<int>(type: "int", nullable: false),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: false),
                    MNT03_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MNT02_especiesAsignadas", x => new { x.MNT01_llave, x.TRP01_llave, x.TEMP02_llave });
                    table.ForeignKey(
                        name: "FK_MNT03_periodosTrampas_MNT01_Monitores",
                        column: x => x.MNT01_llave,
                        principalTable: "MNT01_Monitores",
                        principalColumn: "MNT01_llave");
                    table.ForeignKey(
                        name: "FK_MNT03_periodosTrampas_TEMP02_TemporadaBase",
                        column: x => x.TEMP02_llave,
                        principalTable: "TEMP02_TemporadaBase",
                        principalColumn: "TEMP02_llave");
                });

            migrationBuilder.CreateTable(
                name: "PBCD03_Programacion",
                columns: table => new
                {
                    PBCD03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PBCD01_llave = table.Column<int>(type: "int", nullable: true),
                    PBCD03_InicioFecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    PBCD03_TerminoFecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    PBCD03_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PBCD03_Programacion", x => x.PBCD03_llave);
                    table.ForeignKey(
                        name: "FK_PBCD03_Programacion_PBCD01_Publicidad",
                        column: x => x.PBCD01_llave,
                        principalTable: "PBCD01_Publicidad",
                        principalColumn: "PBCD01_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT01_CuentaCliente",
                columns: table => new
                {
                    CNT01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT02_llave = table.Column<int>(type: "int", nullable: true),
                    PER01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT01_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT03_llave = table.Column<int>(type: "int", nullable: true),
                    CNT01_CuentaSap = table.Column<int>(type: "int", nullable: true),
                    CNT01_NumeroSap = table.Column<int>(type: "int", nullable: true),
                    CNT01_FechaIngresoSap = table.Column<DateTime>(type: "datetime", nullable: true),
                    CNT01_anioIngreso = table.Column<DateTime>(type: "date", nullable: true),
                    CNT01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT01_CuentaCliente", x => x.CNT01_llave);
                    table.ForeignKey(
                        name: "FK_CNT01_CuentaCliente_CNT02_TipoCuenta",
                        column: x => x.CNT02_llave,
                        principalTable: "CNT02_TipoCuenta",
                        principalColumn: "CNT02_llave");
                    table.ForeignKey(
                        name: "FK_CNT01_CuentaCliente_CNT03_TipoCliente",
                        column: x => x.CNT03_llave,
                        principalTable: "CNT03_TipoCliente",
                        principalColumn: "CNT03_llave");
                    table.ForeignKey(
                        name: "FK_CNT01_CuentaCliente_PER01_persona",
                        column: x => x.PER01_llave,
                        principalTable: "PER01_persona",
                        principalColumn: "PER01_llave");
                });

            migrationBuilder.CreateTable(
                name: "PER07_personaUsuario",
                columns: table => new
                {
                    PER07_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PER01_llave = table.Column<int>(type: "int", nullable: true),
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PER07_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER07_personaUsuario", x => x.PER07_llave);
                    table.ForeignKey(
                        name: "FK_PER07_personaUsuario_PER01_persona",
                        column: x => x.PER01_llave,
                        principalTable: "PER01_persona",
                        principalColumn: "PER01_llave");
                });

            migrationBuilder.CreateTable(
                name: "PER05_Comunicacion",
                columns: table => new
                {
                    PER01_llave = table.Column<int>(type: "int", nullable: false),
                    PER04_llave = table.Column<int>(type: "int", nullable: false),
                    PER03_llave = table.Column<int>(type: "int", nullable: false),
                    PER05_Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST03_llave = table.Column<int>(type: "int", nullable: true),
                    PER05_casilla = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER05_TieneCasilla = table.Column<int>(type: "int", nullable: true),
                    PER05_CodigoPostal = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PER05_Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PER05_Telefono1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER05_Telefono2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER05_Celular1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER05_Celular2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER05_Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PER05_SitioWeb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PER05_Comunicacion", x => new { x.PER01_llave, x.PER04_llave, x.PER03_llave });
                    table.ForeignKey(
                        name: "FK_PER05_Comunicacion_PER01_persona",
                        column: x => x.PER01_llave,
                        principalTable: "PER01_persona",
                        principalColumn: "PER01_llave");
                    table.ForeignKey(
                        name: "FK_PER05_Comunicacion_PER03_Tipopersona",
                        column: x => x.PER03_llave,
                        principalTable: "PER03_Tipopersona",
                        principalColumn: "PER03_llave");
                    table.ForeignKey(
                        name: "FK_PER05_Comunicacion_PER04_TipoComunicacion",
                        column: x => x.PER04_llave,
                        principalTable: "PER04_TipoComunicacion",
                        principalColumn: "PER04_llave");
                    table.ForeignKey(
                        name: "FK_PER05_Comunicacion_PER06_TipopersonaComunicacion",
                        columns: x => new { x.PER03_llave, x.PER04_llave },
                        principalTable: "PER06_TipopersonaComunicacion",
                        principalColumns: new[] { "PER03_llave", "PER04_llave" });
                });

            migrationBuilder.CreateTable(
                name: "CONTEO05_Control_Reserva",
                columns: table => new
                {
                    CONTEO05_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTEO05_tabla_control = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CONTEO05_columna_control = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CONTEO05_valor_control = table.Column<int>(type: "int", nullable: true),
                    CONTEO05_id_movil = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CONTEO05_estado_control = table.Column<int>(type: "int", nullable: true),
                    CONTEO05_Estado = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CONTEO05_primer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CONTEO05_segundo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CONTEO05_tercer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CONTEO05_fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTEO05_Control_Reserva", x => x.CONTEO05_llave);
                    table.ForeignKey(
                        name: "FK_CONTEO05_Control_Reserva_SECU02_Usuario",
                        column: x => x.SECU02_llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_llave");
                });

            migrationBuilder.CreateTable(
                name: "EML01_BitacoraEmailUsuario",
                columns: table => new
                {
                    EML01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EML02_llave = table.Column<int>(type: "int", nullable: true),
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EML01_Envio = table.Column<DateTime>(type: "datetime", nullable: true),
                    EML01_De = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML01_Para = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML01_Asunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML01_Contenido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EML01_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML04_llave = table.Column<int>(type: "int", nullable: true),
                    EML01_activo = table.Column<int>(type: "int", nullable: true),
                    EML01_MailPAdre = table.Column<int>(type: "int", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EML01_EmailUsuario", x => x.EML01_llave);
                    table.ForeignKey(
                        name: "FK_EML01_BitacoraEmailUsuario_SECU02_Usuario",
                        column: x => x.SECU02_llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_llave");
                    table.ForeignKey(
                        name: "FK_EML01_EmailUsuario_EML02_MailBase",
                        column: x => x.EML02_llave,
                        principalTable: "EML02_MailBase",
                        principalColumn: "EML02_llave");
                    table.ForeignKey(
                        name: "FK_EML01_EmailUsuario_EML04_ImportanciaMail",
                        column: x => x.EML04_llave,
                        principalTable: "EML04_ImportanciaMail",
                        principalColumn: "EML04_llave");
                });

            migrationBuilder.CreateTable(
                name: "PRF01_perfiles",
                columns: table => new
                {
                    PRF01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRF05_llave = table.Column<int>(type: "int", nullable: true),
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PRF01_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRF01_perfiles", x => x.PRF01_llave);
                    table.ForeignKey(
                        name: "FK_PRF01_perfiles_PRF05_TipoAsignacionUsuario",
                        column: x => x.PRF05_llave,
                        principalTable: "PRF05_TipoAsignacionUsuario",
                        principalColumn: "PRF05_llave");
                    table.ForeignKey(
                        name: "FK_PRF01_perfiles_SECU02_Usuario",
                        column: x => x.SECU02_llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_llave");
                });

            migrationBuilder.CreateTable(
                name: "SECU05_UsuarioAcceso",
                columns: table => new
                {
                    SECU05_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SECU03_TipoAcceso = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SECU05_llaveAcceso = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SECU05_SOAcceso = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SECU05_VersionActual = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SECU05_VersionDescarga = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SECU05_ForzarDescarga = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    SECU05_FechaUltAcceso = table.Column<DateTime>(type: "datetime", nullable: true),
                    SECU05_FechaUltActividad = table.Column<DateTime>(type: "datetime", nullable: true),
                    SECU05_FechaUltDescarga = table.Column<DateTime>(type: "datetime", nullable: true),
                    SECU05_Bloqueado = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    SECU05_FechaBloqueo = table.Column<DateTime>(type: "datetime", nullable: true),
                    SECU05_Mensaje = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SECU05_FechaMensaje = table.Column<DateTime>(type: "datetime", nullable: true),
                    SECU05_Info = table.Column<string>(type: "xml", nullable: true),
                    SECU05_activo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SECU05_U__2980F8C26FA412CE", x => x.SECU05_llave);
                    table.ForeignKey(
                        name: "FK_SECU05_UsuarioAcceso_SECU02_Usuario",
                        column: x => x.SECU02_llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_llave");
                    table.ForeignKey(
                        name: "FK_SECU05_UsuarioAcceso_SECU03_TipoAcceso",
                        column: x => x.SECU03_TipoAcceso,
                        principalTable: "SECU03_TipoAcceso",
                        principalColumn: "SECU03_llave");
                });

            migrationBuilder.CreateTable(
                name: "SECU06_UsuarioRol",
                columns: table => new
                {
                    SECU01_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SECU06_activo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SECU06_UsuarioRol", x => new { x.SECU01_llave, x.SECU02_llave });
                    table.ForeignKey(
                        name: "FK_SECU06_UsuarioRol_SECU01_Rol",
                        column: x => x.SECU01_llave,
                        principalTable: "SECU01_Rol",
                        principalColumn: "SECU01_llave");
                    table.ForeignKey(
                        name: "FK_SECU06_UsuarioRol_SECU02_Usuario",
                        column: x => x.SECU02_llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_llave");
                });

            migrationBuilder.CreateTable(
                name: "SECU08_UsuarioAplicacion",
                columns: table => new
                {
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SECU07_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SECU08_Info = table.Column<string>(type: "xml", nullable: true),
                    SECU08_Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECU08_activo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAplicacion", x => new { x.SECU02_llave, x.SECU07_llave });
                    table.ForeignKey(
                        name: "FK_UsuarioAplicacion_Aplicacion",
                        column: x => x.SECU07_llave,
                        principalTable: "SECU07_Aplicacion",
                        principalColumn: "SECU07_llave");
                    table.ForeignKey(
                        name: "FK_UsuarioAplicacion_Usuario",
                        column: x => x.SECU02_llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_llave");
                });

            migrationBuilder.CreateTable(
                name: "SECU10_Accesopermitido",
                columns: table => new
                {
                    SECU10_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SECU02_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SECU03_llave = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SECU10_Accesopermitido", x => x.SECU10_llave);
                    table.ForeignKey(
                        name: "FK_SECU10_Accesopermitido_SECU02_Usuario",
                        column: x => x.SECU02_llave,
                        principalTable: "SECU02_Usuario",
                        principalColumn: "SECU02_llave");
                    table.ForeignKey(
                        name: "FK_SECU10_Accesopermitido_SECU03_TipoAcceso",
                        column: x => x.SECU03_llave,
                        principalTable: "SECU03_TipoAcceso",
                        principalColumn: "SECU03_llave");
                });

            migrationBuilder.CreateTable(
                name: "LNC02_ServiciosLicencia",
                columns: table => new
                {
                    LNC01_llave = table.Column<int>(type: "int", nullable: false),
                    SERV01_llave = table.Column<int>(type: "int", nullable: false),
                    LNC02_NumeroElemento = table.Column<int>(type: "int", nullable: true),
                    LNC02_EsIlimitado = table.Column<int>(type: "int", nullable: true),
                    LNC02_activo = table.Column<int>(type: "int", nullable: true),
                    LNC02_permiteComparar = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LNC02_ServiciosLicencia_1", x => new { x.LNC01_llave, x.SERV01_llave });
                    table.ForeignKey(
                        name: "FK_LNC02_ServiciosLicencia_LNC01_Licencias",
                        column: x => x.LNC01_llave,
                        principalTable: "LNC01_Licencias",
                        principalColumn: "LNC01_llave");
                    table.ForeignKey(
                        name: "FK_LNC02_ServiciosLicencia_SERV01_Servicio",
                        column: x => x.SERV01_llave,
                        principalTable: "SERV01_Servicio",
                        principalColumn: "SERV01_llave");
                });

            migrationBuilder.CreateTable(
                name: "SIST07_ZonaComuna",
                columns: table => new
                {
                    sist02llave = table.Column<int>(type: "int", nullable: false),
                    sist03llave = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIST07_ZonaComuna", x => new { x.sist02llave, x.sist03llave });
                    table.ForeignKey(
                        name: "FK_SIST07_ZonaComuna_SIST02_Zona",
                        column: x => x.sist02llave,
                        principalTable: "SIST02_Zona",
                        principalColumn: "SIST02_llave");
                    table.ForeignKey(
                        name: "FK_SIST07_ZonaComuna_SIST03_Comuna",
                        column: x => x.sist03llave,
                        principalTable: "SIST03_Comuna",
                        principalColumn: "SIST03_llave");
                });

            migrationBuilder.CreateTable(
                name: "WKF01_Flujo",
                columns: table => new
                {
                    WKF01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF01_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WKF01_descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF01_llavePadre = table.Column<int>(type: "int", nullable: true),
                    WKF03_llave = table.Column<int>(type: "int", nullable: true),
                    WKF01_EsInicio = table.Column<int>(type: "int", nullable: true),
                    WKF01_Orden = table.Column<int>(type: "int", nullable: true),
                    WKF01_Prioridad = table.Column<int>(type: "int", nullable: true),
                    WKF01_activo = table.Column<int>(type: "int", nullable: false),
                    WKF01_Directorio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WKF01_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WKF01_iconoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF01_visibleMenu = table.Column<int>(type: "int", nullable: true),
                    WKF01_ImagenGrande = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF01_ImagenPequena = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF01_estadoRegistro = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF01_Flujo", x => x.WKF01_llave);
                    table.ForeignKey(
                        name: "FK_WKF01_Flujo_WKF03_Nivel",
                        column: x => x.WKF03_llave,
                        principalTable: "WKF03_Nivel",
                        principalColumn: "WKF03_llave");
                });

            migrationBuilder.CreateTable(
                name: "WKF04_Nivelpermiso",
                columns: table => new
                {
                    WKF04_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF03_llave = table.Column<int>(type: "int", nullable: true),
                    WKF05_llave = table.Column<int>(type: "int", nullable: true),
                    WKF04_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF04_NivelPremiso", x => x.WKF04_llave);
                    table.ForeignKey(
                        name: "FK_WKF04_Nivelpermiso_WKF03_Nivel",
                        column: x => x.WKF03_llave,
                        principalTable: "WKF03_Nivel",
                        principalColumn: "WKF03_llave");
                    table.ForeignKey(
                        name: "FK_WKF04_Nivelpermiso_WKF05_Tipopermiso",
                        column: x => x.WKF05_llave,
                        principalTable: "WKF05_Tipopermiso",
                        principalColumn: "WKF05_llave");
                });

            migrationBuilder.CreateTable(
                name: "CONTEO04_ResumenSag",
                columns: table => new
                {
                    CONTEO04_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIST03_llave = table.Column<int>(type: "int", nullable: true),
                    ESP01_llave = table.Column<int>(type: "int", nullable: true),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: true),
                    CONTEO04_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTEO04_ResumenSag", x => x.CONTEO04_llave);
                    table.ForeignKey(
                        name: "FK_CONTEO04_ResumenSag_ESP01_especies",
                        column: x => x.ESP01_llave,
                        principalTable: "ESP01_especies",
                        principalColumn: "ESP01_llave");
                    table.ForeignKey(
                        name: "FK_CONTEO04_ResumenSag_SIST03_Comuna",
                        column: x => x.SIST03_llave,
                        principalTable: "SIST03_Comuna",
                        principalColumn: "SIST03_llave");
                    table.ForeignKey(
                        name: "FK_CONTEO04_ResumenSag_TEMP02_TemporadaBase",
                        column: x => x.TEMP02_llave,
                        principalTable: "TEMP02_TemporadaBase",
                        principalColumn: "TEMP02_llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP02_Temporadaespecie",
                columns: table => new
                {
                    ESP02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP01_llave = table.Column<int>(type: "int", nullable: true),
                    TEMP01_llave = table.Column<int>(type: "int", nullable: true),
                    ESP02_InicioTemporada = table.Column<DateTime>(type: "datetime", nullable: true),
                    ESP02_TerminoTemporada = table.Column<DateTime>(type: "datetime", nullable: true),
                    ESP02_Sag = table.Column<int>(type: "int", nullable: true),
                    ESP02_Mexico = table.Column<int>(type: "int", nullable: true),
                    ESP02_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP02_Temporadaespecie", x => x.ESP02_llave);
                    table.ForeignKey(
                        name: "FK_ESP02_Temporadaespecie_ESP01_especies",
                        column: x => x.ESP01_llave,
                        principalTable: "ESP01_especies",
                        principalColumn: "ESP01_llave");
                    table.ForeignKey(
                        name: "FK_ESP02_Temporadaespecie_TEMP01_Temporada",
                        column: x => x.TEMP01_llave,
                        principalTable: "TEMP01_Temporada",
                        principalColumn: "TEMP01_llave");
                });

            migrationBuilder.CreateTable(
                name: "ESP05_Umbral",
                columns: table => new
                {
                    ESP05_LLave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESP01_llave = table.Column<int>(type: "int", nullable: true),
                    ESP05_MinUmbral = table.Column<int>(type: "int", nullable: true),
                    ESP05_MaxUmbral = table.Column<int>(type: "int", nullable: true),
                    ESP05_Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ESP09_llave = table.Column<int>(type: "int", nullable: true),
                    ESP05_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESP05_Umbral", x => x.ESP05_LLave);
                    table.ForeignKey(
                        name: "FK_ESP05_Umbral_ESP01_especies",
                        column: x => x.ESP01_llave,
                        principalTable: "ESP01_especies",
                        principalColumn: "ESP01_llave");
                    table.ForeignKey(
                        name: "FK_ESP05_Umbral_ESP09_TipoBaseUmbral",
                        column: x => x.ESP09_llave,
                        principalTable: "ESP09_TipoBaseUmbral",
                        principalColumn: "ESP09_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT04_ContactoCliente",
                columns: table => new
                {
                    CNT04_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT01_llave = table.Column<int>(type: "int", nullable: true),
                    PER01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT05_llave = table.Column<int>(type: "int", nullable: true),
                    CNT04_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT04_ContactoCliente", x => x.CNT04_llave);
                    table.ForeignKey(
                        name: "FK_CNT04_ContactoCliente_CNT01_CuentaCliente1",
                        column: x => x.CNT01_llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_llave");
                    table.ForeignKey(
                        name: "FK_CNT04_ContactoCliente_CNT05_TipoContacto",
                        column: x => x.CNT05_llave,
                        principalTable: "CNT05_TipoContacto",
                        principalColumn: "CNT05_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT08_Segmentacion",
                columns: table => new
                {
                    CNT08_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT07_llave = table.Column<int>(type: "int", nullable: true),
                    CNT21_llave = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    CNT08_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT08_llavePadre = table.Column<int>(type: "int", nullable: true),
                    SIST03_llave = table.Column<int>(type: "int", nullable: true),
                    CNT08_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT08_Segmentacion", x => x.CNT08_llave);
                    table.ForeignKey(
                        name: "FK_CNT08_Segmentacion_CNT01_CuentaCliente",
                        column: x => x.CNT01_llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_llave");
                    table.ForeignKey(
                        name: "FK_CNT08_Segmentacion_CNT07_TipoSegmentacion",
                        column: x => x.CNT07_llave,
                        principalTable: "CNT07_TipoSegmentacion",
                        principalColumn: "CNT07_llave");
                    table.ForeignKey(
                        name: "FK_CNT08_Segmentacion_CNT08_Segmentacion",
                        column: x => x.CNT08_llavePadre,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT12_Empleados",
                columns: table => new
                {
                    CNT12_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT01_llave = table.Column<int>(type: "int", nullable: true),
                    PER01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT08_llave = table.Column<int>(type: "int", nullable: true),
                    CNT13_llave = table.Column<int>(type: "int", nullable: true),
                    CNT12_Cargo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT12_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT12_Empleados", x => x.CNT12_llave);
                    table.ForeignKey(
                        name: "FK_CNT12_Empleados_CNT01_CuentaCliente",
                        column: x => x.CNT01_llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_llave");
                    table.ForeignKey(
                        name: "FK_CNT12_Empleados_CNT13_TipoEmpleado",
                        column: x => x.CNT13_llave,
                        principalTable: "CNT13_TipoEmpleado",
                        principalColumn: "CNT13_llave");
                    table.ForeignKey(
                        name: "FK_CNT12_Empleados_PER01_persona",
                        column: x => x.PER01_llave,
                        principalTable: "PER01_persona",
                        principalColumn: "PER01_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT14_ClienteLicencia",
                columns: table => new
                {
                    CNT14_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT01_llave = table.Column<int>(type: "int", nullable: true),
                    LNC01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT14_InicioFecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    CNT14_TerminoFecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    CNT14_CantUsuarios = table.Column<int>(type: "int", nullable: true),
                    CNT14_activo = table.Column<bool>(type: "bit", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT14_ClienteLicencia", x => x.CNT14_llave);
                    table.ForeignKey(
                        name: "FK_CNT14_ClienteLicencia_CNT01_CuentaCliente",
                        column: x => x.CNT01_llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT19_LicenciaCliente",
                columns: table => new
                {
                    CNT19_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT01_llave = table.Column<int>(type: "int", nullable: true),
                    LNC01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT19_nombreLicencia = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT19_NumeroUsuario = table.Column<int>(type: "int", nullable: true),
                    CNT19_NumeroDias = table.Column<int>(type: "int", nullable: true),
                    CNT19_FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    CNT19_FechaTermino = table.Column<DateTime>(type: "datetime", nullable: true),
                    CNT19_activo = table.Column<int>(type: "int", nullable: true),
                    CNT23_llave = table.Column<int>(type: "int", nullable: true),
                    CNT19_valor_referencial = table.Column<int>(type: "int", nullable: true),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT19_LicenciaCliente", x => x.CNT19_llave);
                    table.ForeignKey(
                        name: "FK_CNT19_LicenciaCliente_CNT01_CuentaCliente",
                        column: x => x.CNT01_llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_llave");
                });

            migrationBuilder.CreateTable(
                name: "EML05_ArchivoMail",
                columns: table => new
                {
                    EML05_llave = table.Column<int>(type: "int", nullable: false),
                    EML01_llave = table.Column<int>(type: "int", nullable: true),
                    EML06_llave = table.Column<int>(type: "int", nullable: true),
                    EML05_Archivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML05_Ruta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EML05_activo = table.Column<int>(type: "int", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EML05_ArchivoMail", x => x.EML05_llave);
                    table.ForeignKey(
                        name: "FK_EML05_ArchivoMail_EML01_EmailUsuario",
                        column: x => x.EML01_llave,
                        principalTable: "EML01_BitacoraEmailUsuario",
                        principalColumn: "EML01_llave");
                    table.ForeignKey(
                        name: "FK_EML05_ArchivoMail_EML06_TipoArchivo",
                        column: x => x.EML05_llave,
                        principalTable: "EML06_TipoArchivo",
                        principalColumn: "EML06_llave");
                });

            migrationBuilder.CreateTable(
                name: "FRM02_Formulario",
                columns: table => new
                {
                    FRM02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FRM01_llave = table.Column<int>(type: "int", nullable: true),
                    FRM02_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FRM02_Empresa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FRM02_Ciudad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FRM02_Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FRM02_Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FRM02_Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FRM02_Celular = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FRM02_Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FRM02_activo = table.Column<int>(type: "int", nullable: true),
                    FRM02_EstadoRespuesta = table.Column<int>(type: "int", nullable: true),
                    EML01_llave = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FRM02_Formulario", x => x.FRM02_llave);
                    table.ForeignKey(
                        name: "FK_FRM02_Formulario_EML01_BitacoraEmailUsuario",
                        column: x => x.EML01_llave,
                        principalTable: "EML01_BitacoraEmailUsuario",
                        principalColumn: "EML01_llave");
                    table.ForeignKey(
                        name: "FK_FRM02_Formulario_FRM01_TipoFormulario",
                        column: x => x.FRM01_llave,
                        principalTable: "FRM01_TipoFormulario",
                        principalColumn: "FRM01_llave");
                });

            migrationBuilder.CreateTable(
                name: "PRF02_PlantillasUsuario",
                columns: table => new
                {
                    prf01llave = table.Column<int>(type: "int", nullable: false),
                    prf03llave = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRF02_PlantillasUsuario", x => new { x.prf01llave, x.prf03llave });
                    table.ForeignKey(
                        name: "FK_PRF02_PlantillasUsuario_PRF01_perfiles",
                        column: x => x.prf01llave,
                        principalTable: "PRF01_perfiles",
                        principalColumn: "PRF01_llave");
                    table.ForeignKey(
                        name: "FK_PRF02_PlantillasUsuario_PRF03_Plantilla",
                        column: x => x.prf03llave,
                        principalTable: "PRF03_Plantilla",
                        principalColumn: "PRF03_llave");
                });

            migrationBuilder.CreateTable(
                name: "WKF06_perfiles",
                columns: table => new
                {
                    WKF06_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF01_llave = table.Column<int>(type: "int", nullable: true),
                    WKF06_nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF06_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WKF06_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF06_perfiles", x => x.WKF06_llave);
                    table.ForeignKey(
                        name: "FK_WKF06_perfiles_WKF01_Flujo",
                        column: x => x.WKF01_llave,
                        principalTable: "WKF01_Flujo",
                        principalColumn: "WKF01_llave");
                });

            migrationBuilder.CreateTable(
                name: "WKF09_Parametro",
                columns: table => new
                {
                    WKF09_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WKF01_llave = table.Column<int>(type: "int", nullable: true),
                    WKF10_llave = table.Column<int>(type: "int", nullable: true),
                    WKF09_Variable = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF09_Valor = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WKF09_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF09_Parametro", x => x.WKF09_llave);
                    table.ForeignKey(
                        name: "FK_WKF09_Parametro_WKF01_Flujo",
                        column: x => x.WKF01_llave,
                        principalTable: "WKF01_Flujo",
                        principalColumn: "WKF01_llave");
                    table.ForeignKey(
                        name: "FK_WKF09_Parametro_WKF10_TipoParametro",
                        column: x => x.WKF10_llave,
                        principalTable: "WKF10_TipoParametro",
                        principalColumn: "WKF10_llave");
                });

            migrationBuilder.CreateTable(
                name: "MNT02_especiesAsignadas",
                columns: table => new
                {
                    Mnt01llave = table.Column<int>(type: "int", nullable: false),
                    esp02llave = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MNT02_especiesAsignadas_2", x => new { x.Mnt01llave, x.esp02llave });
                    table.ForeignKey(
                        name: "FK_MNT02_especiesAsignadas_ESP02_Temporadaespecie",
                        column: x => x.esp02llave,
                        principalTable: "ESP02_Temporadaespecie",
                        principalColumn: "ESP02_llave");
                    table.ForeignKey(
                        name: "FK_MNT02_especiesAsignadas_MNT01_Monitores",
                        column: x => x.Mnt01llave,
                        principalTable: "MNT01_Monitores",
                        principalColumn: "MNT01_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT06_ComunicacionCliente",
                columns: table => new
                {
                    CNT06_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT08_llave = table.Column<int>(type: "int", nullable: true),
                    CNT10_llave = table.Column<int>(type: "int", nullable: true),
                    CNT06_Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST03_llave = table.Column<int>(type: "int", nullable: true),
                    CNT06_casilla = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT06_TieneCasilla = table.Column<int>(type: "int", nullable: true),
                    CNT06_CodigoPostal = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT06_Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT06_TipoMail = table.Column<int>(type: "int", nullable: true),
                    CNT06_Telefono1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT06_Telefono2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT06_Celular1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT06_Celular2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT06_Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT06_SitioWeb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT06_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT06_ComunicacionCliente", x => x.CNT06_llave);
                    table.ForeignKey(
                        name: "FK_CNT06_ComunicacionCliente_CNT01_CuentaCliente",
                        column: x => x.CNT01_llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_llave");
                    table.ForeignKey(
                        name: "FK_CNT06_ComunicacionCliente_CNT08_Segmentacion",
                        column: x => x.CNT08_llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_llave");
                    table.ForeignKey(
                        name: "FK_CNT06_ComunicacionCliente_CNT10_TipoComunicacion",
                        column: x => x.CNT10_llave,
                        principalTable: "CNT10_TipoComunicacion",
                        principalColumn: "CNT10_llave");
                    table.ForeignKey(
                        name: "FK_CNT06_ComunicacionCliente_SIST03_Comuna",
                        column: x => x.SIST03_llave,
                        principalTable: "SIST03_Comuna",
                        principalColumn: "SIST03_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT09_ComunicacionSegmentacion",
                columns: table => new
                {
                    CNT09_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT08_llave = table.Column<int>(type: "int", nullable: true),
                    CNT10_llave = table.Column<int>(type: "int", nullable: true),
                    CNT09_Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SIST03_llave = table.Column<int>(type: "int", nullable: true),
                    CNT09_casilla = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT09_SinCasilla = table.Column<int>(type: "int", nullable: true),
                    CNT09_CodigoPostal = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CNT09_Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNT09_TipoMail = table.Column<int>(type: "int", nullable: true),
                    CNT09_Telefono1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT09_Telefono2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT09_Celular1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT09_Celular2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT09_Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT09_SitioWeb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CNT09_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT09_ComunicacionSegmentacion", x => x.CNT09_llave);
                    table.ForeignKey(
                        name: "FK_CNT09_ComunicacionSegmentacion_CNT08_Segmentacion",
                        column: x => x.CNT08_llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT11_ContactoSegmentacion",
                columns: table => new
                {
                    CNT11_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT08_llave = table.Column<int>(type: "int", nullable: true),
                    PER01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT05_llave = table.Column<int>(type: "int", nullable: true),
                    CNT11_activo = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT11_ContactoSegmentacion", x => x.CNT11_llave);
                    table.ForeignKey(
                        name: "FK_CNT11_ContactoSegmentacion_CNT08_Segmentacion",
                        column: x => x.CNT08_llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT22_Estacion_TipoEstacion",
                columns: table => new
                {
                    CNT08_llave = table.Column<int>(type: "int", nullable: false),
                    CNT21_llave = table.Column<int>(type: "int", nullable: false),
                    CNT22_estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT22_Estacion_TipoEstacion", x => new { x.CNT08_llave, x.CNT21_llave });
                    table.ForeignKey(
                        name: "FK_CNT22_Estacion_TipoEstacion_CNT08_Segmentacion",
                        column: x => x.CNT08_llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_llave");
                    table.ForeignKey(
                        name: "FK_CNT22_Estacion_TipoEstacion_CNT21_TipoEstacion",
                        column: x => x.CNT21_llave,
                        principalTable: "CNT21_TipoEstacion",
                        principalColumn: "CNT21_llave");
                });

            migrationBuilder.CreateTable(
                name: "CONTEO02_Procesados",
                columns: table => new
                {
                    CONTEO02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT08_llave = table.Column<int>(type: "int", nullable: true),
                    ESP01_llave = table.Column<int>(type: "int", nullable: true),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: true),
                    CONTEO02_fechaProceso = table.Column<DateTime>(type: "datetime", nullable: true),
                    CONTEO02_Promedio = table.Column<int>(type: "int", nullable: true),
                    CONTEO02_Cantidad = table.Column<int>(type: "int", nullable: true),
                    CONTEO02_Cotatenado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CONTEO02_Suma = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTEO02_Procesados", x => x.CONTEO02_llave);
                    table.ForeignKey(
                        name: "FK_CONTEO02_Procesados_CNT08_Segmentacion",
                        column: x => x.CNT08_llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_llave");
                });

            migrationBuilder.CreateTable(
                name: "CONTEO03_Resumen",
                columns: table => new
                {
                    CONTEO03_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT08_llave = table.Column<int>(type: "int", nullable: true),
                    ESP01_llave = table.Column<int>(type: "int", nullable: true),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: true),
                    CONTEO03_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTEO03_Resumen", x => x.CONTEO03_llave);
                    table.ForeignKey(
                        name: "FK_CONTEO03_Resumen_CNT08_Segmentacion",
                        column: x => x.CNT08_llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_llave");
                });

            migrationBuilder.CreateTable(
                name: "TRP01_Trampa",
                columns: table => new
                {
                    TRP01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT08_llave = table.Column<int>(type: "int", nullable: true),
                    ESP01_llave = table.Column<int>(type: "int", nullable: true),
                    TRP01_nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TRP01_activo = table.Column<int>(type: "int", nullable: true),
                    TRP01_Numero = table.Column<int>(type: "int", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    APPROVE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DELETE_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRP01_Trampa", x => x.TRP01_llave);
                    table.ForeignKey(
                        name: "FK_TRP01_Trampa_CNT08_Segmentacion",
                        column: x => x.CNT08_llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_llave");
                    table.ForeignKey(
                        name: "FK_TRP01_Trampa_ESP01_especies",
                        column: x => x.ESP01_llave,
                        principalTable: "ESP01_especies",
                        principalColumn: "ESP01_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT17_Bloqueos",
                columns: table => new
                {
                    CNT17_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BLK01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT16_llave = table.Column<int>(type: "int", nullable: true),
                    CNT01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT08_llave = table.Column<int>(type: "int", nullable: true),
                    CNT14_llave = table.Column<int>(type: "int", nullable: true),
                    PER01_llave = table.Column<int>(type: "int", nullable: true),
                    CNT17_InicioBloqueo = table.Column<DateTime>(type: "datetime", nullable: true),
                    CNT17_TerminoBloqueo = table.Column<DateTime>(type: "datetime", nullable: true),
                    CNT17_activo = table.Column<bool>(type: "bit", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT17_Bloqueos", x => x.CNT17_llave);
                    table.ForeignKey(
                        name: "FK_CNT17_Bloqueos_BLK01_Bloqueos",
                        column: x => x.BLK01_llave,
                        principalTable: "BLK01_Bloqueos",
                        principalColumn: "BLK01_llave");
                    table.ForeignKey(
                        name: "FK_CNT17_Bloqueos_CNT01_CuentaCliente",
                        column: x => x.CNT01_llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_llave");
                    table.ForeignKey(
                        name: "FK_CNT17_Bloqueos_CNT08_Segmentacion",
                        column: x => x.CNT08_llave,
                        principalTable: "CNT08_Segmentacion",
                        principalColumn: "CNT08_llave");
                    table.ForeignKey(
                        name: "FK_CNT17_Bloqueos_CNT14_ClienteLicencia",
                        column: x => x.CNT14_llave,
                        principalTable: "CNT14_ClienteLicencia",
                        principalColumn: "CNT14_llave");
                    table.ForeignKey(
                        name: "FK_CNT17_Bloqueos_CNT16_TipoBloqueoCliente",
                        column: x => x.CNT16_llave,
                        principalTable: "CNT16_TipoBloqueoCliente",
                        principalColumn: "CNT16_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT15_EmpleadoLicencia",
                columns: table => new
                {
                    CNT19_llave = table.Column<int>(type: "int", nullable: false),
                    CNT12_llave = table.Column<int>(type: "int", nullable: false),
                    CNT15_AceptaContrato = table.Column<int>(type: "int", nullable: true),
                    CNT15_fechafirma = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT15_EmpleadoLicencia_1", x => new { x.CNT19_llave, x.CNT12_llave });
                    table.ForeignKey(
                        name: "FK_CNT15_EmpleadoLicencia_CNT12_Empleados",
                        column: x => x.CNT12_llave,
                        principalTable: "CNT12_Empleados",
                        principalColumn: "CNT12_llave");
                    table.ForeignKey(
                        name: "FK_CNT15_EmpleadoLicencia_CNT19_LicenciaCliente",
                        column: x => x.CNT19_llave,
                        principalTable: "CNT19_LicenciaCliente",
                        principalColumn: "CNT19_llave");
                });

            migrationBuilder.CreateTable(
                name: "CNT20_LicenciaServicio",
                columns: table => new
                {
                    CNT19_llave = table.Column<int>(type: "int", nullable: false),
                    SERV01_llave = table.Column<int>(type: "int", nullable: false),
                    CNT20_habilitaservicio = table.Column<int>(type: "int", nullable: true),
                    CNT20_Valor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNT20_LicenciaServicio", x => new { x.CNT19_llave, x.SERV01_llave });
                    table.ForeignKey(
                        name: "FK_CNT20_LicenciaServicio_CNT19_LicenciaCliente",
                        column: x => x.CNT19_llave,
                        principalTable: "CNT19_LicenciaCliente",
                        principalColumn: "CNT19_llave");
                });

            migrationBuilder.CreateTable(
                name: "PGO01_CompraLicencia",
                columns: table => new
                {
                    PGO1_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNT19_llave = table.Column<int>(type: "int", nullable: true),
                    PGO03_llave = table.Column<int>(type: "int", nullable: true),
                    PGO01_activo = table.Column<int>(type: "int", nullable: true),
                    PGO01_TotalCompra = table.Column<int>(type: "int", nullable: true),
                    FECHACOMPRA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PGO01_CompraLicencia", x => x.PGO1_llave);
                    table.ForeignKey(
                        name: "FK_PGO01_CompraLicencia_CNT01_CuentaCliente",
                        column: x => x.CNT19_llave,
                        principalTable: "CNT01_CuentaCliente",
                        principalColumn: "CNT01_llave");
                    table.ForeignKey(
                        name: "FK_PGO01_CompraLicencia_CNT19_LicenciaCliente",
                        column: x => x.CNT19_llave,
                        principalTable: "CNT19_LicenciaCliente",
                        principalColumn: "CNT19_llave");
                    table.ForeignKey(
                        name: "FK_PGO01_CompraLicencia_PGO03_FormaPago1",
                        column: x => x.PGO03_llave,
                        principalTable: "PGO03_TipoPagoLicencia",
                        principalColumn: "PGO03_llave");
                });

            migrationBuilder.CreateTable(
                name: "PRF04_PlantillaFlujo",
                columns: table => new
                {
                    PRF04_llave = table.Column<int>(type: "int", nullable: false),
                    PRF03_llave = table.Column<int>(type: "int", nullable: false),
                    WKF01_llave = table.Column<int>(type: "int", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRF04_PlantillaFlujo", x => new { x.PRF03_llave, x.WKF01_llave });
                    table.ForeignKey(
                        name: "FK_PRF04_PlantillaFlujo_PRF03_Plantilla",
                        column: x => x.PRF03_llave,
                        principalTable: "PRF03_Plantilla",
                        principalColumn: "PRF03_llave");
                    table.ForeignKey(
                        name: "FK_PRF04_PlantillaFlujo_WKF01_Flujo",
                        column: x => x.WKF01_llave,
                        principalTable: "WKF01_Flujos",
                        principalColumn: "WKF01_llave");
                });

            migrationBuilder.CreateTable(
                name: "PRF06_permisosUsuario",
                columns: table => new
                {
                    PRF01_llave = table.Column<int>(type: "int", nullable: false),
                    WKF06_llave = table.Column<int>(type: "int", nullable: false),
                    PRF06_activo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRF06_permisosUsuario", x => new { x.PRF01_llave, x.WKF06_llave });
                    table.ForeignKey(
                        name: "FK_PRF06_permisosUsuario_PRF01_perfiles",
                        column: x => x.PRF01_llave,
                        principalTable: "PRF01_perfiles",
                        principalColumn: "PRF01_llave");
                    table.ForeignKey(
                        name: "FK_PRF06_permisosUsuario_WKF06_perfiles",
                        column: x => x.WKF06_llave,
                        principalTable: "WKF06_perfiles",
                        principalColumn: "WKF06_llave");
                });

            migrationBuilder.CreateTable(
                name: "WKF07_perfilespermiso",
                columns: table => new
                {
                    WKF06_llave = table.Column<int>(type: "int", nullable: false),
                    WKF05_llave = table.Column<int>(type: "int", nullable: false),
                    WKF07_activo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WKF07_perfilespermiso", x => new { x.WKF06_llave, x.WKF05_llave });
                    table.ForeignKey(
                        name: "FK_WKF07_perfilespermiso_WKF05_Tipopermiso",
                        column: x => x.WKF05_llave,
                        principalTable: "WKF05_Tipopermiso",
                        principalColumn: "WKF05_llave");
                    table.ForeignKey(
                        name: "FK_WKF07_perfilespermiso_WKF06_perfiles",
                        column: x => x.WKF06_llave,
                        principalTable: "WKF06_perfiles",
                        principalColumn: "WKF06_llave");
                });

            migrationBuilder.CreateTable(
                name: "SERCLTEMP01_ServiciosClientes_Temporal",
                columns: table => new
                {
                    SERCLTEMP01_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERCLTEMP01_TipoGrafico = table.Column<int>(type: "int", nullable: true),
                    CNTEMP01_llave = table.Column<int>(type: "int", nullable: true),
                    CNTEMP02_llave = table.Column<int>(type: "int", nullable: true),
                    CONTEO03_llave = table.Column<int>(type: "int", nullable: true),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERCLTEMP01_ServiciosClientes_Temporal", x => x.SERCLTEMP01_llave);
                    table.ForeignKey(
                        name: "FK_SERCLTEMP01_ServiciosClientes_Temporal_CONTEO03_Resumen",
                        column: x => x.CONTEO03_llave,
                        principalTable: "CONTEO03_Resumen",
                        principalColumn: "CONTEO03_llave");
                });

            migrationBuilder.CreateTable(
                name: "TRP02_Temporada",
                columns: table => new
                {
                    TRP02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRP01_llave = table.Column<int>(type: "int", nullable: false),
                    TEMP02_llave = table.Column<int>(type: "int", nullable: false),
                    TEMP02_activo = table.Column<bool>(type: "bit", nullable: true),
                    fechaactualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaeliminacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaactivacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRP02_Temporada", x => x.TRP02_llave);
                    table.ForeignKey(
                        name: "FK_TRP02_Temporada_TEMP02_TemporadaBase",
                        column: x => x.TEMP02_llave,
                        principalTable: "TEMP02_TemporadaBase",
                        principalColumn: "TEMP02_llave");
                    table.ForeignKey(
                        name: "FK_TRP02_Temporada_TRP01_Trampa",
                        column: x => x.TRP01_llave,
                        principalTable: "TRP01_Trampa",
                        principalColumn: "TRP01_llave");
                });

            migrationBuilder.CreateTable(
                name: "PGO02_NotificarPagoLicencia",
                columns: table => new
                {
                    PGO02_llave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PGO01_llave = table.Column<int>(type: "int", nullable: true),
                    PGO02_activo = table.Column<int>(type: "int", nullable: true),
                    PGO02_DocumentoAdjunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHANOTIFICACIONPAGO = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PGO02_NotificarPagoLicencia", x => x.PGO02_llave);
                    table.ForeignKey(
                        name: "FK_PGO02_NotificarPagoLicencia_PGO01_CompraLicencia",
                        column: x => x.PGO01_llave,
                        principalTable: "PGO01_CompraLicencia",
                        principalColumn: "PGO1_llave");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BLK01_Bloqueos_BLK02_llave",
                table: "BLK01_Bloqueos",
                column: "BLK02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_BLK03_BloqueoUsuario_BLK01_llave",
                table: "BLK03_BloqueoUsuario",
                column: "BLK01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CLBR01_Calibracion_CLBR02_llave",
                table: "CLBR01_Calibracion",
                column: "CLBR02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT01_CuentaCliente_CNT02_llave",
                table: "CNT01_CuentaCliente",
                column: "CNT02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT01_CuentaCliente_CNT03_llave",
                table: "CNT01_CuentaCliente",
                column: "CNT03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT01_CuentaCliente_PER01_llave",
                table: "CNT01_CuentaCliente",
                column: "PER01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT03_TipoCliente_PER03_llave",
                table: "CNT03_TipoCliente",
                column: "PER03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT04_ContactoCliente_CNT01_llave",
                table: "CNT04_ContactoCliente",
                column: "CNT01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT04_ContactoCliente_CNT05_llave",
                table: "CNT04_ContactoCliente",
                column: "CNT05_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT06_ComunicacionCliente_CNT01_llave",
                table: "CNT06_ComunicacionCliente",
                column: "CNT01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT06_ComunicacionCliente_CNT08_llave",
                table: "CNT06_ComunicacionCliente",
                column: "CNT08_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT06_ComunicacionCliente_CNT10_llave",
                table: "CNT06_ComunicacionCliente",
                column: "CNT10_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT06_ComunicacionCliente_SIST03_llave",
                table: "CNT06_ComunicacionCliente",
                column: "SIST03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT07_TipoSegmentacion_CNT18_llave",
                table: "CNT07_TipoSegmentacion",
                column: "CNT18_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT08_Segmentacion_CNT01_llave",
                table: "CNT08_Segmentacion",
                column: "CNT01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT08_Segmentacion_CNT07_llave",
                table: "CNT08_Segmentacion",
                column: "CNT07_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT08_Segmentacion_CNT08_llavePadre",
                table: "CNT08_Segmentacion",
                column: "CNT08_llavePadre");

            migrationBuilder.CreateIndex(
                name: "IX_CNT09_ComunicacionSegmentacion_CNT08_llave",
                table: "CNT09_ComunicacionSegmentacion",
                column: "CNT08_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT11_ContactoSegmentacion_CNT08_llave",
                table: "CNT11_ContactoSegmentacion",
                column: "CNT08_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT12_Empleados_CNT01_llave",
                table: "CNT12_Empleados",
                column: "CNT01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT12_Empleados_CNT13_llave",
                table: "CNT12_Empleados",
                column: "CNT13_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT12_Empleados_PER01_llave",
                table: "CNT12_Empleados",
                column: "PER01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT14_ClienteLicencia_CNT01_llave",
                table: "CNT14_ClienteLicencia",
                column: "CNT01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT15_EmpleadoLicencia_CNT12_llave",
                table: "CNT15_EmpleadoLicencia",
                column: "CNT12_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT17_Bloqueos_BLK01_llave",
                table: "CNT17_Bloqueos",
                column: "BLK01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT17_Bloqueos_CNT01_llave",
                table: "CNT17_Bloqueos",
                column: "CNT01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT17_Bloqueos_CNT08_llave",
                table: "CNT17_Bloqueos",
                column: "CNT08_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT17_Bloqueos_CNT14_llave",
                table: "CNT17_Bloqueos",
                column: "CNT14_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT17_Bloqueos_CNT16_llave",
                table: "CNT17_Bloqueos",
                column: "CNT16_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT19_LicenciaCliente_CNT01_llave",
                table: "CNT19_LicenciaCliente",
                column: "CNT01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CNT22_Estacion_TipoEstacion_CNT21_llave",
                table: "CNT22_Estacion_TipoEstacion",
                column: "CNT21_llave");

            migrationBuilder.CreateIndex(
                name: "IX_Comunas_RegionId",
                table: "Comunas",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_CONT01_Contacto_CONT02_llave",
                table: "CONT01_Contacto",
                column: "CONT02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO01_Conteos_TEMP02_llave",
                table: "CONTEO01_Conteos",
                column: "TEMP02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO02_Procesados_CNT08_llave",
                table: "CONTEO02_Procesados",
                column: "CNT08_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO03_Resumen_CNT08_llave",
                table: "CONTEO03_Resumen",
                column: "CNT08_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO04_ResumenSag_ESP01_llave",
                table: "CONTEO04_ResumenSag",
                column: "ESP01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO04_ResumenSag_SIST03_llave",
                table: "CONTEO04_ResumenSag",
                column: "SIST03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO04_ResumenSag_TEMP02_llave",
                table: "CONTEO04_ResumenSag",
                column: "TEMP02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEO05_Control_Reserva_SECU02_llave",
                table: "CONTEO05_Control_Reserva",
                column: "SECU02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_CTT01_Contrato_CTT02_llave",
                table: "CTT01_Contrato",
                column: "CTT02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_EML01_BitacoraEmailUsuario_EML02_llave",
                table: "EML01_BitacoraEmailUsuario",
                column: "EML02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_EML01_BitacoraEmailUsuario_EML04_llave",
                table: "EML01_BitacoraEmailUsuario",
                column: "EML04_llave");

            migrationBuilder.CreateIndex(
                name: "IX_EML01_BitacoraEmailUsuario_SECU02_llave",
                table: "EML01_BitacoraEmailUsuario",
                column: "SECU02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_EML02_MailBase_EML03_llave",
                table: "EML02_MailBase",
                column: "EML03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_EML02_MailBase_EML04_llave",
                table: "EML02_MailBase",
                column: "EML04_llave");

            migrationBuilder.CreateIndex(
                name: "IX_EML05_ArchivoMail_EML01_llave",
                table: "EML05_ArchivoMail",
                column: "EML01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP01_especies_ESP03_llave",
                table: "ESP01_especies",
                column: "ESP03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP01_especies_ESP04_llave",
                table: "ESP01_especies",
                column: "ESP04_llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP02_Temporadaespecie_ESP01_llave",
                table: "ESP02_Temporadaespecie",
                column: "ESP01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP02_Temporadaespecie_TEMP01_llave",
                table: "ESP02_Temporadaespecie",
                column: "TEMP01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP03_especieBase_ESP08_llave",
                table: "ESP03_especieBase",
                column: "ESP08_llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP04_EstadoDanio_ESP06_llave",
                table: "ESP04_EstadoDanio",
                column: "ESP06_llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP05_Umbral_ESP01_llave",
                table: "ESP05_Umbral",
                column: "ESP01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP05_Umbral_ESP09_llave",
                table: "ESP05_Umbral",
                column: "ESP09_llave");

            migrationBuilder.CreateIndex(
                name: "IX_ESP11_ReglaGrafico_ESP10_llave",
                table: "ESP11_ReglaGrafico",
                column: "ESP10_llave");

            migrationBuilder.CreateIndex(
                name: "IX_FRM02_Formulario_EML01_llave",
                table: "FRM02_Formulario",
                column: "EML01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_FRM02_Formulario_FRM01_llave",
                table: "FRM02_Formulario",
                column: "FRM01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_INS02_RecuperarClave_INS02_Estado",
                table: "INS02_RecuperarClave",
                column: "INS02_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_LNC02_ServiciosLicencia_SERV01_llave",
                table: "LNC02_ServiciosLicencia",
                column: "SERV01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_LNC03_LicenciaContrato_CTT01_llave",
                table: "LNC03_LicenciaContrato",
                column: "CTT01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_LNC05_valorLicencia_LNC01_llave",
                table: "LNC05_valorLicencia",
                column: "LNC01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_LOG01_Bitacora_LOG03_llave",
                table: "LOG01_Bitacora",
                column: "LOG03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_LOG03_MensajeBitacora_LOG02_llave",
                table: "LOG03_MensajeBitacora",
                column: "LOG02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_MNT01_Monitores_MNT04_llave",
                table: "MNT01_Monitores",
                column: "MNT04_llave");

            migrationBuilder.CreateIndex(
                name: "IX_MNT02_especiesAsignadas_esp02llave",
                table: "MNT02_especiesAsignadas",
                column: "esp02llave");

            migrationBuilder.CreateIndex(
                name: "IX_MNT03_periodosTrampas_TEMP02_llave",
                table: "MNT03_periodosTrampas",
                column: "TEMP02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_OBSC01_ObservacionCampo_ESP08_llave",
                table: "OBSC01_ObservacionCampo",
                column: "ESP08_llave");

            migrationBuilder.CreateIndex(
                name: "IX_OBSC01_ObservacionCampo_TEMP02_llave",
                table: "OBSC01_ObservacionCampo",
                column: "TEMP02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PBCD01_Publicidad_PBCD02_llave",
                table: "PBCD01_Publicidad",
                column: "PBCD02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PBCD03_Programacion_PBCD01_llave",
                table: "PBCD03_Programacion",
                column: "PBCD01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PER01_persona_PER02_llave",
                table: "PER01_persona",
                column: "PER02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PER01_persona_PER03_llave",
                table: "PER01_persona",
                column: "PER03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PER01_persona_PER08_llave",
                table: "PER01_persona",
                column: "PER08_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PER05_Comunicacion_PER03_llave_PER04_llave",
                table: "PER05_Comunicacion",
                columns: new[] { "PER03_llave", "PER04_llave" });

            migrationBuilder.CreateIndex(
                name: "IX_PER05_Comunicacion_PER04_llave",
                table: "PER05_Comunicacion",
                column: "PER04_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PER06_TipopersonaComunicacion_PER04_llave",
                table: "PER06_TipopersonaComunicacion",
                column: "PER04_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PER07_personaUsuario_PER01_llave",
                table: "PER07_personaUsuario",
                column: "PER01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PGO01_CompraLicencia_CNT19_llave",
                table: "PGO01_CompraLicencia",
                column: "CNT19_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PGO01_CompraLicencia_PGO03_llave",
                table: "PGO01_CompraLicencia",
                column: "PGO03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PGO02_NotificarPagoLicencia_PGO01_llave",
                table: "PGO02_NotificarPagoLicencia",
                column: "PGO01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PRF01_perfiles_PRF05_llave",
                table: "PRF01_perfiles",
                column: "PRF05_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PRF01_perfiles_SECU02_llave",
                table: "PRF01_perfiles",
                column: "SECU02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PRF02_PlantillasUsuario_prf03llave",
                table: "PRF02_PlantillasUsuario",
                column: "prf03llave");

            migrationBuilder.CreateIndex(
                name: "IX_PRF04_PlantillaFlujo_WKF01_llave",
                table: "PRF04_PlantillaFlujo",
                column: "WKF01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_PRF06_permisosUsuario_WKF06_llave",
                table: "PRF06_permisosUsuario",
                column: "WKF06_llave");

            migrationBuilder.CreateIndex(
                name: "IX_SECU02_Usuario_SECU04_TipoEncriptacion",
                table: "SECU02_Usuario",
                column: "SECU04_TipoEncriptacion");

            migrationBuilder.CreateIndex(
                name: "IX_SECU05_UsuarioAcceso_SECU02_llave",
                table: "SECU05_UsuarioAcceso",
                column: "SECU02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_SECU05_UsuarioAcceso_SECU03_TipoAcceso",
                table: "SECU05_UsuarioAcceso",
                column: "SECU03_TipoAcceso");

            migrationBuilder.CreateIndex(
                name: "IX_SECU06_UsuarioRol_SECU02_llave",
                table: "SECU06_UsuarioRol",
                column: "SECU02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_SECU08_UsuarioAplicacion_SECU07_llave",
                table: "SECU08_UsuarioAplicacion",
                column: "SECU07_llave");

            migrationBuilder.CreateIndex(
                name: "IX_SECU10_Accesopermitido_SECU02_llave",
                table: "SECU10_Accesopermitido",
                column: "SECU02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_SECU10_Accesopermitido_SECU03_llave",
                table: "SECU10_Accesopermitido",
                column: "SECU03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_SERCL02_MuestreoFruta_SERCL01_llave",
                table: "SERCL02_MuestreoFruta",
                column: "SERCL01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_SERCLTEMP01_ServiciosClientes_Temporal_CONTEO03_llave",
                table: "SERCLTEMP01_ServiciosClientes_Temporal",
                column: "CONTEO03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_SERV01_Servicio_SERV02_llave",
                table: "SERV01_Servicio",
                column: "SERV02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_SIST03_Comuna_SIST04_llave",
                table: "SIST03_Comuna",
                column: "SIST04_llave");

            migrationBuilder.CreateIndex(
                name: "IX_SIST07_ZonaComuna_sist03llave",
                table: "SIST07_ZonaComuna",
                column: "sist03llave");

            migrationBuilder.CreateIndex(
                name: "IX_SIST08_ContactoUsuario_PER02_llave",
                table: "SIST08_ContactoUsuario",
                column: "PER02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_TEMP01_Temporada_TEMP02_llave",
                table: "TEMP01_Temporada",
                column: "TEMP02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_TEMP01_Temporada_TEMP03_llave",
                table: "TEMP01_Temporada",
                column: "TEMP03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_TRP01_Trampa_CNT08_llave",
                table: "TRP01_Trampa",
                column: "CNT08_llave");

            migrationBuilder.CreateIndex(
                name: "IX_TRP01_Trampa_ESP01_llave",
                table: "TRP01_Trampa",
                column: "ESP01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_TRP02_Temporada_TEMP02_llave",
                table: "TRP02_Temporada",
                column: "TEMP02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_TRP02_Temporada_TRP01_llave",
                table: "TRP02_Temporada",
                column: "TRP01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF01_Flujo_WKF03_llave",
                table: "WKF01_Flujo",
                column: "WKF03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF03_Nivel_WKF02_llave",
                table: "WKF03_Nivel",
                column: "WKF02_llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF04_Nivelpermiso_WKF03_llave",
                table: "WKF04_Nivelpermiso",
                column: "WKF03_llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF04_Nivelpermiso_WKF05_llave",
                table: "WKF04_Nivelpermiso",
                column: "WKF05_llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF06_perfiles_WKF01_llave",
                table: "WKF06_perfiles",
                column: "WKF01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF07_perfilespermiso_WKF05_llave",
                table: "WKF07_perfilespermiso",
                column: "WKF05_llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF09_Parametro_WKF01_llave",
                table: "WKF09_Parametro",
                column: "WKF01_llave");

            migrationBuilder.CreateIndex(
                name: "IX_WKF09_Parametro_WKF10_llave",
                table: "WKF09_Parametro",
                column: "WKF10_llave");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "Comunas");

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
                name: "Inmuebles");

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
                name: "MEN01_sistema");

            migrationBuilder.DropTable(
                name: "MNT02_especiesAsignadas");

            migrationBuilder.DropTable(
                name: "MNT03_periodosTrampas");

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
                name: "PER07_personaUsuario");

            migrationBuilder.DropTable(
                name: "PGO02_NotificarPagoLicencia");

            migrationBuilder.DropTable(
                name: "PRF02_PlantillasUsuario");

            migrationBuilder.DropTable(
                name: "PRF04_PlantillaFlujo");

            migrationBuilder.DropTable(
                name: "PRF06_permisosUsuario");

            migrationBuilder.DropTable(
                name: "PRM01_Seguridad");

            migrationBuilder.DropTable(
                name: "SECU05_UsuarioAcceso");

            migrationBuilder.DropTable(
                name: "SECU06_UsuarioRol");

            migrationBuilder.DropTable(
                name: "SECU08_UsuarioAplicacion");

            migrationBuilder.DropTable(
                name: "SECU10_Accesopermitido");

            migrationBuilder.DropTable(
                name: "SECU11_Tipoperfil");

            migrationBuilder.DropTable(
                name: "SERCL02_MuestreoFruta");

            migrationBuilder.DropTable(
                name: "SERCLTEMP01_ServiciosClientes_Temporal");

            migrationBuilder.DropTable(
                name: "SIST01_sistema");

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
                name: "WKF04_Nivelpermiso");

            migrationBuilder.DropTable(
                name: "WKF07_perfilespermiso");

            migrationBuilder.DropTable(
                name: "WKF08_Area");

            migrationBuilder.DropTable(
                name: "WKF09_Parametro");

            migrationBuilder.DropTable(
                name: "Zonas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
                name: "Regiones");

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
                name: "ESP02_Temporadaespecie");

            migrationBuilder.DropTable(
                name: "MNT01_Monitores");

            migrationBuilder.DropTable(
                name: "PBCD01_Publicidad");

            migrationBuilder.DropTable(
                name: "PER06_TipopersonaComunicacion");

            migrationBuilder.DropTable(
                name: "PGO01_CompraLicencia");

            migrationBuilder.DropTable(
                name: "PRF03_Plantilla");

            migrationBuilder.DropTable(
                name: "PRF01_perfiles");

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
                name: "WKF05_Tipopermiso");

            migrationBuilder.DropTable(
                name: "WKF06_perfiles");

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
                name: "ESP01_especies");

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
                name: "ESP03_especieBase");

            migrationBuilder.DropTable(
                name: "ESP04_EstadoDanio");

            migrationBuilder.DropTable(
                name: "WKF03_Nivel");

            migrationBuilder.DropTable(
                name: "CNT02_TipoCuenta");

            migrationBuilder.DropTable(
                name: "CNT03_TipoCliente");

            migrationBuilder.DropTable(
                name: "PER01_persona");

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
                name: "PER03_Tipopersona");
        }
    }
}
