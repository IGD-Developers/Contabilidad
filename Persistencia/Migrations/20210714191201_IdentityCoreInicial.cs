using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
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
                    id_tercero = table.Column<int>(type: "int", nullable: false),
                    usu_estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    usu_supervisor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    razon_social = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_tercero_gerente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnf_empresa", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnf_usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_tercero = table.Column<int>(type: "int", nullable: false),
                    usu_usuario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    usu_password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    usu_fecha_nacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usu_estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    usu_supervisor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnf_usuario", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_banco",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_banco", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_categoriacomprobante",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_categoriacomprobante", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_centrocosto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cco_estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_centrocosto", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_conceptocuenta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_exogenaconcepto = table.Column<int>(type: "int", nullable: false),
                    id_puc = table.Column<int>(type: "int", nullable: false),
                    id_formatocolumna = table.Column<int>(type: "int", nullable: false),
                    id_tipooperacion = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_conceptocuenta", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_departamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_departamento", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_exogenaconcepto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_exogenaconcepto", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_exogenaformato",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_exogenaformato", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_genero",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_genero", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_notaaclaratoriatipo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_notaaclaratoriatipo", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_puctipo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_puctipo", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_regimen",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_regimen", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_responsabilidad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_responsabilidad", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_seccionciiu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_seccionciiu", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_tipociiu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_tipociiu", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_tipocuenta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_tipocuenta", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_tipodocumento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_tipodocumento", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_tipoimpuesto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_tipoimpuesto", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_tipooperacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    formula = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_tipooperacion", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_tipopersona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_tipopersona", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_uvt",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uvt_ano = table.Column<int>(type: "int", nullable: false),
                    uvt_valor = table.Column<double>(type: "double", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_uvt", x => x.id);
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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_empresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnf_sucursal", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnf_sucursal_cnf_empresa_id_empresa",
                        column: x => x.id_empresa,
                        principalTable: "cnf_empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_mes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mes_ano = table.Column<int>(type: "int", nullable: false),
                    mes_mes = table.Column<int>(type: "int", nullable: false),
                    mes_cerrado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_mes", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_mes_cnf_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "cnf_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_tipocomprobante",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_categoriacomprobante = table.Column<int>(type: "int", nullable: false),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tco_incremento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    editable = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    anulable = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_tipocomprobante", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_tipocomprobante_cnf_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "cnf_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_tipocomprobante_cnt_categoriacomprobante_id_categoriacom~",
                        column: x => x.id_categoriacomprobante,
                        principalTable: "cnt_categoriacomprobante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_municipio",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_departamento = table.Column<int>(type: "int", nullable: false),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_municipio", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_municipio_cnt_departamento_id_departamento",
                        column: x => x.id_departamento,
                        principalTable: "cnt_departamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_formatocolumna",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_exogenaformato = table.Column<int>(type: "int", nullable: false),
                    fco_columna = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fco_campo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fco_tipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_formatocolumna", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_formatocolumna_cnt_exogenaformato_id_exogenaformato",
                        column: x => x.id_exogenaformato,
                        principalTable: "cnt_exogenaformato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_formatoconcepto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_exogenaformato = table.Column<int>(type: "int", nullable: false),
                    id_exogenaconcepto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_formatoconcepto", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_formatoconcepto_cnt_exogenaconcepto_id_exogenaconcepto",
                        column: x => x.id_exogenaconcepto,
                        principalTable: "cnt_exogenaconcepto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_formatoconcepto_cnt_exogenaformato_id_exogenaformato",
                        column: x => x.id_exogenaformato,
                        principalTable: "cnt_exogenaformato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_notaaclaratoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nac_consecutivo = table.Column<int>(type: "int", nullable: false),
                    nac_fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    id_notaaclaratoriatipo = table.Column<int>(type: "int", nullable: false),
                    nac_titulo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nac_detalle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_notaaclaratoria", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_notaaclaratoria_cnt_notaaclaratoriatipo_id_notaaclarator~",
                        column: x => x.id_notaaclaratoriatipo,
                        principalTable: "cnt_notaaclaratoriatipo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_ciiu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_tipociuu = table.Column<int>(type: "int", nullable: false),
                    id_seccionciiu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_ciiu", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_ciiu_cnt_seccionciiu_id_seccionciiu",
                        column: x => x.id_seccionciiu,
                        principalTable: "cnt_seccionciiu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_ciiu_cnt_tipociiu_id_tipociuu",
                        column: x => x.id_tipociuu,
                        principalTable: "cnt_tipociiu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_puc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_puctipo = table.Column<int>(type: "int", nullable: true),
                    id_tipocuenta = table.Column<int>(type: "int", nullable: true),
                    pac_activa = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    pac_base = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    pac_ajusteniif = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_puc", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_puc_cnf_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "cnf_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_puc_cnt_puctipo_id_puctipo",
                        column: x => x.id_puctipo,
                        principalTable: "cnt_puctipo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cnt_puc_cnt_tipocuenta_id_tipocuenta",
                        column: x => x.id_tipocuenta,
                        principalTable: "cnt_tipocuenta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_comprobante",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_sucursal = table.Column<int>(type: "int", nullable: false),
                    id_tipocomprobante = table.Column<int>(type: "int", nullable: false),
                    id_modulo = table.Column<int>(type: "int", nullable: false),
                    id_tercero = table.Column<int>(type: "int", nullable: false),
                    id_reversion = table.Column<int>(type: "int", nullable: true),
                    cco_ano = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cco_mes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cco_consecutivo = table.Column<int>(type: "int", nullable: false),
                    cco_fecha = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    cco_documento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cco_detalle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_comprobante", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_comprobante_cnf_sucursal_id_sucursal",
                        column: x => x.id_sucursal,
                        principalTable: "cnf_sucursal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_comprobante_cnf_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "cnf_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_comprobante_cnt_tipocomprobante_id_tipocomprobante",
                        column: x => x.id_tipocomprobante,
                        principalTable: "cnt_tipocomprobante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_consecutivo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_tipocomprobante = table.Column<int>(type: "int", nullable: false),
                    co_ano = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    co_mes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    co_consecutivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_consecutivo", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_consecutivo_cnt_tipocomprobante_id_tipocomprobante",
                        column: x => x.id_tipocomprobante,
                        principalTable: "cnt_tipocomprobante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_tercero",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_tippersona = table.Column<int>(type: "int", nullable: false),
                    id_genero = table.Column<int>(type: "int", nullable: false),
                    id_tipodocumento = table.Column<int>(type: "int", nullable: false),
                    id_municipio = table.Column<int>(type: "int", nullable: false),
                    id_regimen = table.Column<int>(type: "int", nullable: false),
                    id_ciiu = table.Column<int>(type: "int", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    ter_documento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_digitoverificacion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_prinombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_segnombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_priapellido = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_segapellido = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_razonsocial = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_direccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_barrio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_telfijo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_telcelular = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_email_fe = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ter_contacto_fe = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_tercero", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_tercero_cnt_ciiu_id_ciiu",
                        column: x => x.id_ciiu,
                        principalTable: "cnt_ciiu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_tercero_cnt_genero_id_genero",
                        column: x => x.id_genero,
                        principalTable: "cnt_genero",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_tercero_cnt_municipio_id_municipio",
                        column: x => x.id_municipio,
                        principalTable: "cnt_municipio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_tercero_cnt_regimen_id_regimen",
                        column: x => x.id_regimen,
                        principalTable: "cnt_regimen",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_tercero_cnt_tipodocumento_id_tipodocumento",
                        column: x => x.id_tipodocumento,
                        principalTable: "cnt_tipodocumento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_tercero_cnt_tipopersona_id_tippersona",
                        column: x => x.id_tippersona,
                        principalTable: "cnt_tipopersona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_cuentaimpuesto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_puc = table.Column<int>(type: "int", nullable: false),
                    id_tipoimpuesto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_cuentaimpuesto", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_cuentaimpuesto_cnt_puc_id_puc",
                        column: x => x.id_puc,
                        principalTable: "cnt_puc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_cuentaimpuesto_cnt_tipoimpuesto_id_tipoimpuesto",
                        column: x => x.id_tipoimpuesto,
                        principalTable: "cnt_tipoimpuesto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_notaaclaratoriacuenta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_notaaclaratoria = table.Column<int>(type: "int", nullable: false),
                    id_puc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_notaaclaratoriacuenta", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_notaaclaratoriacuenta_cnt_notaaclaratoria_id_notaaclarat~",
                        column: x => x.id_notaaclaratoria,
                        principalTable: "cnt_notaaclaratoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_notaaclaratoriacuenta_cnt_puc_id_puc",
                        column: x => x.id_puc,
                        principalTable: "cnt_puc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_ano",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_comprobante = table.Column<int>(type: "int", nullable: false),
                    ano_ano = table.Column<int>(type: "int", nullable: false),
                    ano_cerrado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ano_estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_ano", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_ano_cnf_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "cnf_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_ano_cnt_comprobante_id_comprobante",
                        column: x => x.id_comprobante,
                        principalTable: "cnt_comprobante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_detallecomprobante",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_comprobante = table.Column<int>(type: "int", nullable: false),
                    id_centrocosto = table.Column<int>(type: "int", nullable: false),
                    id_puc = table.Column<int>(type: "int", nullable: false),
                    id_tercero = table.Column<int>(type: "int", nullable: false),
                    dco_base = table.Column<double>(type: "double", nullable: false),
                    dco_tarifa = table.Column<double>(type: "double", nullable: false),
                    dco_debito = table.Column<double>(type: "double", nullable: false),
                    dco_credito = table.Column<double>(type: "double", nullable: false),
                    dco_detalle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_detallecomprobante", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_detallecomprobante_cnt_centrocosto_id_centrocosto",
                        column: x => x.id_centrocosto,
                        principalTable: "cnt_centrocosto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_detallecomprobante_cnt_comprobante_id_comprobante",
                        column: x => x.id_comprobante,
                        principalTable: "cnt_comprobante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_detallecomprobante_cnt_puc_id_puc",
                        column: x => x.id_puc,
                        principalTable: "cnt_puc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_entidad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_tercero = table.Column<int>(type: "int", nullable: false),
                    id_tipoimpuesto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_entidad", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_entidad_cnt_tercero_id_tercero",
                        column: x => x.id_tercero,
                        principalTable: "cnt_tercero",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_entidad_cnt_tipoimpuesto_id_tipoimpuesto",
                        column: x => x.id_tipoimpuesto,
                        principalTable: "cnt_tipoimpuesto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_liquidaimpuesto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_tipoimpuesto = table.Column<int>(type: "int", nullable: false),
                    id_comprobante = table.Column<int>(type: "int", nullable: false),
                    id_puc = table.Column<int>(type: "int", nullable: false),
                    id_tercero = table.Column<int>(type: "int", nullable: false),
                    lim_fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    lim_fechainicial = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    lim_fechafinal = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_liquidaimpuesto", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_liquidaimpuesto_cnf_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "cnf_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_liquidaimpuesto_cnt_comprobante_id_comprobante",
                        column: x => x.id_comprobante,
                        principalTable: "cnt_comprobante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_liquidaimpuesto_cnt_puc_id_puc",
                        column: x => x.id_puc,
                        principalTable: "cnt_puc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_liquidaimpuesto_cnt_tercero_id_tercero",
                        column: x => x.id_tercero,
                        principalTable: "cnt_tercero",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_liquidaimpuesto_cnt_tipoimpuesto_id_tipoimpuesto",
                        column: x => x.id_tipoimpuesto,
                        principalTable: "cnt_tipoimpuesto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_responsabilidad_ter",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_tercero = table.Column<int>(type: "int", nullable: false),
                    id_responsabilidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_responsabilidad_ter", x => x.id);
                    table.ForeignKey(
                        name: "FK_cnt_responsabilidad_ter_cnt_responsabilidad_id_responsabilid~",
                        column: x => x.id_responsabilidad,
                        principalTable: "cnt_responsabilidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cnt_responsabilidad_ter_cnt_tercero_id_tercero",
                        column: x => x.id_tercero,
                        principalTable: "cnt_tercero",
                        principalColumn: "id",
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
                column: "id_comprobante");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_ano_id_usuario",
                table: "cnt_ano",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_ciiu_id_seccionciiu",
                table: "cnt_ciiu",
                column: "id_seccionciiu");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_ciiu_id_tipociuu",
                table: "cnt_ciiu",
                column: "id_tipociuu");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_comprobante_id_sucursal",
                table: "cnt_comprobante",
                column: "id_sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_comprobante_id_tipocomprobante",
                table: "cnt_comprobante",
                column: "id_tipocomprobante");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_comprobante_id_usuario",
                table: "cnt_comprobante",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_consecutivo_id_tipocomprobante",
                table: "cnt_consecutivo",
                column: "id_tipocomprobante");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_cuentaimpuesto_id_puc",
                table: "cnt_cuentaimpuesto",
                column: "id_puc");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_cuentaimpuesto_id_tipoimpuesto",
                table: "cnt_cuentaimpuesto",
                column: "id_tipoimpuesto");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_detallecomprobante_id_centrocosto",
                table: "cnt_detallecomprobante",
                column: "id_centrocosto");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_detallecomprobante_id_comprobante",
                table: "cnt_detallecomprobante",
                column: "id_comprobante");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_detallecomprobante_id_puc",
                table: "cnt_detallecomprobante",
                column: "id_puc");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_entidad_id_tercero",
                table: "cnt_entidad",
                column: "id_tercero");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_entidad_id_tipoimpuesto",
                table: "cnt_entidad",
                column: "id_tipoimpuesto");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_formatocolumna_id_exogenaformato",
                table: "cnt_formatocolumna",
                column: "id_exogenaformato");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_formatoconcepto_id_exogenaconcepto",
                table: "cnt_formatoconcepto",
                column: "id_exogenaconcepto");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_formatoconcepto_id_exogenaformato",
                table: "cnt_formatoconcepto",
                column: "id_exogenaformato");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_liquidaimpuesto_id_comprobante",
                table: "cnt_liquidaimpuesto",
                column: "id_comprobante");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_liquidaimpuesto_id_puc",
                table: "cnt_liquidaimpuesto",
                column: "id_puc");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_liquidaimpuesto_id_tercero",
                table: "cnt_liquidaimpuesto",
                column: "id_tercero");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_liquidaimpuesto_id_tipoimpuesto",
                table: "cnt_liquidaimpuesto",
                column: "id_tipoimpuesto");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_liquidaimpuesto_id_usuario",
                table: "cnt_liquidaimpuesto",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_mes_id_usuario",
                table: "cnt_mes",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_municipio_id_departamento",
                table: "cnt_municipio",
                column: "id_departamento");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_notaaclaratoria_id_notaaclaratoriatipo",
                table: "cnt_notaaclaratoria",
                column: "id_notaaclaratoriatipo");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_notaaclaratoriacuenta_id_notaaclaratoria",
                table: "cnt_notaaclaratoriacuenta",
                column: "id_notaaclaratoria");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_notaaclaratoriacuenta_id_puc",
                table: "cnt_notaaclaratoriacuenta",
                column: "id_puc");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_puc_id_puctipo",
                table: "cnt_puc",
                column: "id_puctipo");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_puc_id_tipocuenta",
                table: "cnt_puc",
                column: "id_tipocuenta");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_puc_id_usuario",
                table: "cnt_puc",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_responsabilidad_ter_id_responsabilidad",
                table: "cnt_responsabilidad_ter",
                column: "id_responsabilidad");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_responsabilidad_ter_id_tercero",
                table: "cnt_responsabilidad_ter",
                column: "id_tercero");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_tercero_id_ciiu",
                table: "cnt_tercero",
                column: "id_ciiu");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_tercero_id_genero",
                table: "cnt_tercero",
                column: "id_genero");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_tercero_id_municipio",
                table: "cnt_tercero",
                column: "id_municipio");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_tercero_id_regimen",
                table: "cnt_tercero",
                column: "id_regimen");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_tercero_id_tipodocumento",
                table: "cnt_tercero",
                column: "id_tipodocumento");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_tercero_id_tippersona",
                table: "cnt_tercero",
                column: "id_tippersona");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_tipocomprobante_id_categoriacomprobante",
                table: "cnt_tipocomprobante",
                column: "id_categoriacomprobante");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_tipocomprobante_id_usuario",
                table: "cnt_tipocomprobante",
                column: "id_usuario");
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
}
