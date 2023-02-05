global using MySqlConnector;
global using Dapper;
global using MediatR;
global using AutoMapper;
global using FluentValidation;
global using FluentValidation.AspNetCore;

global using System.Data;
global using System.Text;
global using System.Security.Claims;
global using System.IdentityModel.Tokens.Jwt;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc.Authorization;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

global using Microsoft.Extensions.Options;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.OpenApi.Models;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;


global using ContabilidadWebAPI.Dominio.Configuracion;
global using ContabilidadWebAPI.Dominio.Contabilidad;

global using ContabilidadWebAPI.Persistencia;
global using ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;
global using ContabilidadWebAPI.Persistencia.Mapeo.Configuracion;
global using ContabilidadWebAPI.Persistencia.DapperConexion;
global using ContabilidadWebAPI.Persistencia.DapperConexion.Contabilidad.Pucs;

global using ContabilidadWebAPI.Controllers;
global using ContabilidadWebAPI.Seguridad.TokenSeguridad;

global using ContabilidadWebAPI.Aplicacion.Interfaces;
global using ContabilidadWebAPI.Aplicacion.Seguridad;
global using ContabilidadWebAPI.Aplicacion.Configuracion.Empresas;
global using ContabilidadWebAPI.Aplicacion.Configuracion.Sucursales;
global using ContabilidadWebAPI.Aplicacion.Dapper.Contabilidad.PucsDapper;

global using ContabilidadWebAPI.Aplicacion.Contabilidad.Anos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Bancos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.CategoriaComprobantes;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.CentroCostos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Ciius;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Comprobantes;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.ConceptoCuentas;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Consecutivos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.CuentaImpuestos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Departamentos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.DetalleComprobantes;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Entidades;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaConceptos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaFormatos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Generos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.LiquidaImpuestos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Meses;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Municipios;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaCuentas;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratorias;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaTipos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Pucs;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.PucTipos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Regimenes;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Responsabilidades;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.ResponsabilidadTerceros;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.SeccionCiius;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Terceros;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoCiius;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoComprobantes;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoCuentas;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoDocumentos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoImpuestos;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoOperaciones;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoPersonas;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.Uvts;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoColumnas;
global using ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoConceptos;

global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Bancos;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CategoriaComprobantes;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CentroCostos;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Ciius;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Comprobantes;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CuentaImpuestos;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Departamentos;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Entidades;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Genero;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.LiquidaImpuestos;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Municipios;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.NotaAclaratoria;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.NotaAclaratoriaTipo;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Pucs;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Regimen;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Responsabilidad;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.ResponsabilidadTercero;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.SeccionCiius;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Tercero;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoCiius;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoComprobantes;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoDocumento;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoImpuestos;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoPersona;
global using ContabilidadWebAPI.Aplicacion.Models.Configuracion.Empresas;
global using ContabilidadWebAPI.Aplicacion.Models.Configuracion.Sucursales;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Anos;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Consecutivos;
global using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.DetalleComprobantes;