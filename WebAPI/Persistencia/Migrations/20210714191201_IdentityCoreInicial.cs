using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContabilidadWebAPI.Persistencia.Migrations;

public partial class IdentityCoreInicial : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "AspNetRoles",
            columns: table => new
            {
                Id = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "AspNetUsers",
            columns: table => new
            {
                Id = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IdTercero = table.Column<int>(type: "int", nullable: false),
                usu_estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                usu_supervisor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                update_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnf_empresa",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                nit = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                razon_social = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IdTerceroGerente = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnf_empresa", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnf_usuario",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdTercero = table.Column<int>(type: "int", nullable: false),
                usu_usuario = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                usu_password = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                usu_fecha_nacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                usu_estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                usu_supervisor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                update_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnf_usuario", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_banco",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_banco", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_categoriacomprobante",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_categoriacomprobante", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_centrocosto",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                cco_estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_centrocosto", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_conceptocuenta",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdExogenaconcepto = table.Column<int>(type: "int", nullable: false),
                IdPuc = table.Column<int>(type: "int", nullable: false),
                IdFormatocolumna = table.Column<int>(type: "int", nullable: false),
                IdTipooperacion = table.Column<int>(type: "int", nullable: false),
                Estado = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_conceptocuenta", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_departamento",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_departamento", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_exogenaconcepto",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Estado = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_exogenaconcepto", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_exogenaformato",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_exogenaformato", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_genero",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_genero", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_notaaclaratoriatipo",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_notaaclaratoriatipo", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_puctipo",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_puctipo", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_regimen",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_regimen", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_responsabilidad",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_responsabilidad", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_seccionciiu",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_seccionciiu", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_tipociiu",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_tipociiu", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_tipocuenta",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_tipocuenta", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_tipodocumento",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<int>(type: "int", nullable: false),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                update_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_tipodocumento", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_tipoimpuesto",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_tipoimpuesto", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_tipooperacion",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                formula = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_tipooperacion", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_tipopersona",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_tipopersona", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_uvt",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                uvt_ano = table.Column<int>(type: "int", nullable: false),
                uvt_valor = table.Column<double>(type: "double", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_uvt", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "AspNetRoleClaims",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClaimType = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
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
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "AspNetUserClaims",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClaimType = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
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
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "AspNetUserLogins",
            columns: table => new
            {
                LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4")
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
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "AspNetUserRoles",
            columns: table => new
            {
                UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4")
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
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "AspNetUserTokens",
            columns: table => new
            {
                UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Name = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Value = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
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
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnf_sucursal",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                id_empresa = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnf_sucursal", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnf_sucursal_cnf_empresa_id_empresa",
                    column: x => x.id_empresa,
                    principalTable: "cnf_empresa",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_mes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                mes_ano = table.Column<int>(type: "int", nullable: false),
                mes_mes = table.Column<int>(type: "int", nullable: false),
                mes_cerrado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                IdUsuario = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_mes", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_mes_cnf_usuario_id_usuario",
                    column: x => x.IdUsuario,
                    principalTable: "cnf_usuario",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_tipocomprobante",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdCategoriacomprobante = table.Column<int>(type: "int", nullable: false),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TcoIncremento = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                Editable = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Anulable = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IdUsuario = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_tipocomprobante", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_tipocomprobante_cnf_usuario_id_usuario",
                    column: x => x.IdUsuario,
                    principalTable: "cnf_usuario",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_tipocomprobante_cnt_categoriacomprobante_id_categoriacom~",
                    column: x => x.IdCategoriacomprobante,
                    principalTable: "cnt_categoriacomprobante",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_municipio",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdDepartamento = table.Column<int>(type: "int", nullable: false),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_municipio", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_municipio_cnt_departamento_id_departamento",
                    column: x => x.IdDepartamento,
                    principalTable: "cnt_departamento",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_formatocolumna",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdExogenaformato = table.Column<int>(type: "int", nullable: false),
                FcoColumna = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                FcoCampo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                FcoTipo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_formatocolumna", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_formatocolumna_cnt_exogenaformato_id_exogenaformato",
                    column: x => x.IdExogenaformato,
                    principalTable: "cnt_exogenaformato",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_formatoconcepto",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdExogenaformato = table.Column<int>(type: "int", nullable: false),
                IdExogenaconcepto = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_formatoconcepto", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_formatoconcepto_cnt_exogenaconcepto_id_exogenaconcepto",
                    column: x => x.IdExogenaconcepto,
                    principalTable: "cnt_exogenaconcepto",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_formatoconcepto_cnt_exogenaformato_id_exogenaformato",
                    column: x => x.IdExogenaformato,
                    principalTable: "cnt_exogenaformato",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_notaaclaratoria",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                NacConsecutivo = table.Column<int>(type: "int", nullable: false),
                NacFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                IdNotaaclaratoriatipo = table.Column<int>(type: "int", nullable: false),
                NacTitulo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                NacDetalle = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                IdUsuario = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_notaaclaratoria", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_notaaclaratoria_cnt_notaaclaratoriatipo_id_notaaclarator~",
                    column: x => x.IdNotaaclaratoriatipo,
                    principalTable: "cnt_notaaclaratoriatipo",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_ciiu",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IdTipociuu = table.Column<int>(type: "int", nullable: false),
                IdSeccionciiu = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_ciiu", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_ciiu_cnt_seccionciiu_id_seccionciiu",
                    column: x => x.IdSeccionciiu,
                    principalTable: "cnt_seccionciiu",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_ciiu_cnt_tipociiu_id_tipociuu",
                    column: x => x.IdTipociuu,
                    principalTable: "cnt_tipociiu",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_puc",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IdPuctipo = table.Column<int>(type: "int", nullable: true),
                IdTipocuenta = table.Column<int>(type: "int", nullable: true),
                PacActiva = table.Column<bool>(type: "tinyint(1)", nullable: false),
                PacBase = table.Column<bool>(type: "tinyint(1)", nullable: false),
                PacAjusteniif = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                IdUsuario = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_puc", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_puc_cnf_usuario_id_usuario",
                    column: x => x.IdUsuario,
                    principalTable: "cnf_usuario",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_puc_cnt_puctipo_id_puctipo",
                    column: x => x.IdPuctipo,
                    principalTable: "cnt_puctipo",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_cnt_puc_cnt_tipocuenta_id_tipocuenta",
                    column: x => x.IdTipocuenta,
                    principalTable: "cnt_tipocuenta",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_comprobante",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdSucursal = table.Column<int>(type: "int", nullable: false),
                IdTipocomprobante = table.Column<int>(type: "int", nullable: false),
                IdModulo = table.Column<int>(type: "int", nullable: false),
                IdTercero = table.Column<int>(type: "int", nullable: false),
                IdReversion = table.Column<int>(type: "int", nullable: true),
                CcoAno = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CcoMes = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CcoConsecutivo = table.Column<int>(type: "int", nullable: false),
                CcoFecha = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                CcoDocumento = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CcoDetalle = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                IdUsuario = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_comprobante", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_comprobante_cnf_sucursal_id_sucursal",
                    column: x => x.IdSucursal,
                    principalTable: "cnf_sucursal",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_comprobante_cnf_usuario_id_usuario",
                    column: x => x.IdUsuario,
                    principalTable: "cnf_usuario",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_comprobante_cnt_tipocomprobante_id_tipocomprobante",
                    column: x => x.IdTipocomprobante,
                    principalTable: "cnt_tipocomprobante",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_consecutivo",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdTipocomprobante = table.Column<int>(type: "int", nullable: false),
                CoAno = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CoMes = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CoConsecutivo = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_consecutivo", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_consecutivo_cnt_tipocomprobante_id_tipocomprobante",
                    column: x => x.IdTipocomprobante,
                    principalTable: "cnt_tipocomprobante",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_tercero",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdTippersona = table.Column<int>(type: "int", nullable: false),
                IdGenero = table.Column<int>(type: "int", nullable: false),
                IdTipodocumento = table.Column<int>(type: "int", nullable: false),
                IdMunicipio = table.Column<int>(type: "int", nullable: false),
                IdRegimen = table.Column<int>(type: "int", nullable: false),
                IdCiiu = table.Column<int>(type: "int", nullable: false),
                IdUsuario = table.Column<int>(type: "int", nullable: false),
                TerDocumento = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerDigitoverificacion = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerPrinombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerSegnombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerPriapellido = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerSegapellido = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerRazonsocial = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerDireccion = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerBarrio = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerTelfijo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerTelcelular = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerEmail = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerEmailFe = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TerContactoFe = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_tercero", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_tercero_cnt_ciiu_id_ciiu",
                    column: x => x.IdCiiu,
                    principalTable: "cnt_ciiu",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_tercero_cnt_genero_id_genero",
                    column: x => x.IdGenero,
                    principalTable: "cnt_genero",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_tercero_cnt_municipio_id_municipio",
                    column: x => x.IdMunicipio,
                    principalTable: "cnt_municipio",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_tercero_cnt_regimen_id_regimen",
                    column: x => x.IdRegimen,
                    principalTable: "cnt_regimen",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_tercero_cnt_tipodocumento_id_tipodocumento",
                    column: x => x.IdTipodocumento,
                    principalTable: "cnt_tipodocumento",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_tercero_cnt_tipopersona_id_tippersona",
                    column: x => x.IdTippersona,
                    principalTable: "cnt_tipopersona",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_cuentaimpuesto",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdPuc = table.Column<int>(type: "int", nullable: false),
                IdTipoimpuesto = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_cuentaimpuesto", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_cuentaimpuesto_cnt_puc_id_puc",
                    column: x => x.IdPuc,
                    principalTable: "cnt_puc",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_cuentaimpuesto_cnt_tipoimpuesto_id_tipoimpuesto",
                    column: x => x.IdTipoimpuesto,
                    principalTable: "cnt_tipoimpuesto",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_notaaclaratoriacuenta",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                id_notaaclaratoria = table.Column<int>(type: "int", nullable: false),
                IdPuc = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_notaaclaratoriacuenta", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_notaaclaratoriacuenta_cnt_notaaclaratoria_id_notaaclarat~",
                    column: x => x.id_notaaclaratoria,
                    principalTable: "cnt_notaaclaratoria",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_notaaclaratoriacuenta_cnt_puc_id_puc",
                    column: x => x.IdPuc,
                    principalTable: "cnt_puc",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_ano",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdComprobante = table.Column<int>(type: "int", nullable: false),
                AnoAno = table.Column<int>(type: "int", nullable: false),
                AnoCerrado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                ano_estado = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                IdUsuario = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_ano", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_ano_cnf_usuario_id_usuario",
                    column: x => x.IdUsuario,
                    principalTable: "cnf_usuario",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_ano_cnt_comprobante_id_comprobante",
                    column: x => x.IdComprobante,
                    principalTable: "cnt_comprobante",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_detallecomprobante",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdComprobante = table.Column<int>(type: "int", nullable: false),
                IdCentrocosto = table.Column<int>(type: "int", nullable: false),
                IdPuc = table.Column<int>(type: "int", nullable: false),
                IdTercero = table.Column<int>(type: "int", nullable: false),
                DcoBase = table.Column<double>(type: "double", nullable: false),
                DcoTarifa = table.Column<double>(type: "double", nullable: false),
                DcoDebito = table.Column<double>(type: "double", nullable: false),
                DcoCredito = table.Column<double>(type: "double", nullable: false),
                DcoDetalle = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_detallecomprobante", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_detallecomprobante_cnt_centrocosto_id_centrocosto",
                    column: x => x.IdCentrocosto,
                    principalTable: "cnt_centrocosto",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_detallecomprobante_cnt_comprobante_id_comprobante",
                    column: x => x.IdComprobante,
                    principalTable: "cnt_comprobante",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_detallecomprobante_cnt_puc_id_puc",
                    column: x => x.IdPuc,
                    principalTable: "cnt_puc",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_entidad",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Codigo = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nombre = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IdTercero = table.Column<int>(type: "int", nullable: false),
                IdTipoimpuesto = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_entidad", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_entidad_cnt_tercero_id_tercero",
                    column: x => x.IdTercero,
                    principalTable: "cnt_tercero",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_entidad_cnt_tipoimpuesto_id_tipoimpuesto",
                    column: x => x.IdTipoimpuesto,
                    principalTable: "cnt_tipoimpuesto",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_liquidaimpuesto",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdTipoimpuesto = table.Column<int>(type: "int", nullable: false),
                IdComprobante = table.Column<int>(type: "int", nullable: false),
                IdPuc = table.Column<int>(type: "int", nullable: false),
                IdTercero = table.Column<int>(type: "int", nullable: false),
                LimFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LimFechainicial = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LimFechafinal = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                IdUsuario = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_liquidaimpuesto", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_liquidaimpuesto_cnf_usuario_id_usuario",
                    column: x => x.IdUsuario,
                    principalTable: "cnf_usuario",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_liquidaimpuesto_cnt_comprobante_id_comprobante",
                    column: x => x.IdComprobante,
                    principalTable: "cnt_comprobante",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_liquidaimpuesto_cnt_puc_id_puc",
                    column: x => x.IdPuc,
                    principalTable: "cnt_puc",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_liquidaimpuesto_cnt_tercero_id_tercero",
                    column: x => x.IdTercero,
                    principalTable: "cnt_tercero",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_liquidaimpuesto_cnt_tipoimpuesto_id_tipoimpuesto",
                    column: x => x.IdTipoimpuesto,
                    principalTable: "cnt_tipoimpuesto",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cnt_responsabilidad_ter",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                IdTercero = table.Column<int>(type: "int", nullable: false),
                IdResponsabilidad = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_cnt_responsabilidad_ter", x => x.Id);
                table.ForeignKey(
                    name: "FK_cnt_responsabilidad_ter_cnt_responsabilidad_id_responsabilid~",
                    column: x => x.IdResponsabilidad,
                    principalTable: "cnt_responsabilidad",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_cnt_responsabilidad_ter_cnt_tercero_id_tercero",
                    column: x => x.IdTercero,
                    principalTable: "cnt_tercero",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetRoleClaims_RoleId",
            table: "AspNetRoleClaims",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "RoleNameIndex",
            table: "AspNetRoles",
            column: "NormalizedName",
            unique: true);

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
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_cnf_sucursal_id_empresa",
            table: "cnf_sucursal",
            column: "id_empresa");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_ano_id_comprobante",
            table: "cnt_ano",
            column: "IdComprobante");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_ano_id_usuario",
            table: "cnt_ano",
            column: "IdUsuario");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_ciiu_id_seccionciiu",
            table: "cnt_ciiu",
            column: "IdSeccionciiu");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_ciiu_id_tipociuu",
            table: "cnt_ciiu",
            column: "IdTipociuu");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_comprobante_id_sucursal",
            table: "cnt_comprobante",
            column: "IdSucursal");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_comprobante_id_tipocomprobante",
            table: "cnt_comprobante",
            column: "IdTipocomprobante");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_comprobante_id_usuario",
            table: "cnt_comprobante",
            column: "IdUsuario");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_consecutivo_id_tipocomprobante",
            table: "cnt_consecutivo",
            column: "IdTipocomprobante");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_cuentaimpuesto_id_puc",
            table: "cnt_cuentaimpuesto",
            column: "IdPuc");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_cuentaimpuesto_id_tipoimpuesto",
            table: "cnt_cuentaimpuesto",
            column: "IdTipoimpuesto");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_detallecomprobante_id_centrocosto",
            table: "cnt_detallecomprobante",
            column: "IdCentrocosto");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_detallecomprobante_id_comprobante",
            table: "cnt_detallecomprobante",
            column: "IdComprobante");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_detallecomprobante_id_puc",
            table: "cnt_detallecomprobante",
            column: "IdPuc");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_entidad_id_tercero",
            table: "cnt_entidad",
            column: "IdTercero");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_entidad_id_tipoimpuesto",
            table: "cnt_entidad",
            column: "IdTipoimpuesto");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_formatocolumna_id_exogenaformato",
            table: "cnt_formatocolumna",
            column: "IdExogenaformato");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_formatoconcepto_id_exogenaconcepto",
            table: "cnt_formatoconcepto",
            column: "IdExogenaconcepto");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_formatoconcepto_id_exogenaformato",
            table: "cnt_formatoconcepto",
            column: "IdExogenaformato");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_liquidaimpuesto_id_comprobante",
            table: "cnt_liquidaimpuesto",
            column: "IdComprobante");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_liquidaimpuesto_id_puc",
            table: "cnt_liquidaimpuesto",
            column: "IdPuc");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_liquidaimpuesto_id_tercero",
            table: "cnt_liquidaimpuesto",
            column: "IdTercero");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_liquidaimpuesto_id_tipoimpuesto",
            table: "cnt_liquidaimpuesto",
            column: "IdTipoimpuesto");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_liquidaimpuesto_id_usuario",
            table: "cnt_liquidaimpuesto",
            column: "IdUsuario");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_mes_id_usuario",
            table: "cnt_mes",
            column: "IdUsuario");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_municipio_id_departamento",
            table: "cnt_municipio",
            column: "IdDepartamento");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_notaaclaratoria_id_notaaclaratoriatipo",
            table: "cnt_notaaclaratoria",
            column: "IdNotaaclaratoriatipo");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_notaaclaratoriacuenta_id_notaaclaratoria",
            table: "cnt_notaaclaratoriacuenta",
            column: "id_notaaclaratoria");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_notaaclaratoriacuenta_id_puc",
            table: "cnt_notaaclaratoriacuenta",
            column: "IdPuc");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_puc_id_puctipo",
            table: "cnt_puc",
            column: "IdPuctipo");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_puc_id_tipocuenta",
            table: "cnt_puc",
            column: "IdTipocuenta");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_puc_id_usuario",
            table: "cnt_puc",
            column: "IdUsuario");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_responsabilidad_ter_id_responsabilidad",
            table: "cnt_responsabilidad_ter",
            column: "IdResponsabilidad");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_responsabilidad_ter_id_tercero",
            table: "cnt_responsabilidad_ter",
            column: "IdTercero");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_tercero_id_ciiu",
            table: "cnt_tercero",
            column: "IdCiiu");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_tercero_id_genero",
            table: "cnt_tercero",
            column: "IdGenero");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_tercero_id_municipio",
            table: "cnt_tercero",
            column: "IdMunicipio");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_tercero_id_regimen",
            table: "cnt_tercero",
            column: "IdRegimen");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_tercero_id_tipodocumento",
            table: "cnt_tercero",
            column: "IdTipodocumento");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_tercero_id_tippersona",
            table: "cnt_tercero",
            column: "IdTippersona");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_tipocomprobante_id_categoriacomprobante",
            table: "cnt_tipocomprobante",
            column: "IdCategoriacomprobante");

        migrationBuilder.CreateIndex(
            name: "IX_cnt_tipocomprobante_id_usuario",
            table: "cnt_tipocomprobante",
            column: "IdUsuario");
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
            name: "cnt_ano");

        migrationBuilder.DropTable(
            name: "cnt_banco");

        migrationBuilder.DropTable(
            name: "cnt_conceptocuenta");

        migrationBuilder.DropTable(
            name: "cnt_consecutivo");

        migrationBuilder.DropTable(
            name: "cnt_cuentaimpuesto");

        migrationBuilder.DropTable(
            name: "cnt_detallecomprobante");

        migrationBuilder.DropTable(
            name: "cnt_entidad");

        migrationBuilder.DropTable(
            name: "cnt_formatocolumna");

        migrationBuilder.DropTable(
            name: "cnt_formatoconcepto");

        migrationBuilder.DropTable(
            name: "cnt_liquidaimpuesto");

        migrationBuilder.DropTable(
            name: "cnt_mes");

        migrationBuilder.DropTable(
            name: "cnt_notaaclaratoriacuenta");

        migrationBuilder.DropTable(
            name: "cnt_responsabilidad_ter");

        migrationBuilder.DropTable(
            name: "cnt_tipooperacion");

        migrationBuilder.DropTable(
            name: "cnt_uvt");

        migrationBuilder.DropTable(
            name: "AspNetRoles");

        migrationBuilder.DropTable(
            name: "AspNetUsers");

        migrationBuilder.DropTable(
            name: "cnt_centrocosto");

        migrationBuilder.DropTable(
            name: "cnt_exogenaconcepto");

        migrationBuilder.DropTable(
            name: "cnt_exogenaformato");

        migrationBuilder.DropTable(
            name: "cnt_comprobante");

        migrationBuilder.DropTable(
            name: "cnt_tipoimpuesto");

        migrationBuilder.DropTable(
            name: "cnt_notaaclaratoria");

        migrationBuilder.DropTable(
            name: "cnt_puc");

        migrationBuilder.DropTable(
            name: "cnt_responsabilidad");

        migrationBuilder.DropTable(
            name: "cnt_tercero");

        migrationBuilder.DropTable(
            name: "cnf_sucursal");

        migrationBuilder.DropTable(
            name: "cnt_tipocomprobante");

        migrationBuilder.DropTable(
            name: "cnt_notaaclaratoriatipo");

        migrationBuilder.DropTable(
            name: "cnt_puctipo");

        migrationBuilder.DropTable(
            name: "cnt_tipocuenta");

        migrationBuilder.DropTable(
            name: "cnt_ciiu");

        migrationBuilder.DropTable(
            name: "cnt_genero");

        migrationBuilder.DropTable(
            name: "cnt_municipio");

        migrationBuilder.DropTable(
            name: "cnt_regimen");

        migrationBuilder.DropTable(
            name: "cnt_tipodocumento");

        migrationBuilder.DropTable(
            name: "cnt_tipopersona");

        migrationBuilder.DropTable(
            name: "cnf_empresa");

        migrationBuilder.DropTable(
            name: "cnf_usuario");

        migrationBuilder.DropTable(
            name: "cnt_categoriacomprobante");

        migrationBuilder.DropTable(
            name: "cnt_seccionciiu");

        migrationBuilder.DropTable(
            name: "cnt_tipociiu");

        migrationBuilder.DropTable(
            name: "cnt_departamento");
    }
}
