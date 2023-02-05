/*
Navicat MySQL Data Transfer

Source Server         : AALocal
Source Server Version : 80019
Source Host           : 127.0.0.1:3306
Source Database       : igdcontador2

Target Server Type    : MYSQL
Target Server Version : 80019
File Encoding         : 65001

Date: 2021-10-24 20:05:06
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for aspnetroleclaims
-- ----------------------------
DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8 COLLATE utf8_general_ci,
  `ClaimValue` longtext CHARACTER SET utf8 COLLATE utf8_general_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `aspnetroleclaims_ibfk_1` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of aspnetroleclaims
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetroles
-- ----------------------------
DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE `aspnetroles` (
  `Id` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8 COLLATE utf8_general_ci,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of aspnetroles
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetuserclaims
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8 COLLATE utf8_general_ci,
  `ClaimValue` longtext CHARACTER SET utf8 COLLATE utf8_general_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `aspnetuserclaims_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of aspnetuserclaims
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetuserlogins
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8 COLLATE utf8_general_ci,
  `UserId` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `aspnetuserlogins_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of aspnetuserlogins
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetuserroles
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `aspnetuserroles_ibfk_1` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `aspnetuserroles_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of aspnetuserroles
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetusers
-- ----------------------------
DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `id_tercero` int NOT NULL,
  `usu_estado` tinyint(1) NOT NULL,
  `usu_supervisor` tinyint(1) NOT NULL,
  `created_at` datetime(6) DEFAULT NULL,
  `update_at` datetime(6) DEFAULT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`),
  KEY `fk_aspnetusers_cnt_tercero_1` (`Id`,`id_tercero`) USING BTREE,
  KEY `usersidteercero` (`id_tercero`),
  CONSTRAINT `usersidteercero` FOREIGN KEY (`id_tercero`) REFERENCES `cnt_tercero` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of aspnetusers
-- ----------------------------
INSERT INTO `aspnetusers` VALUES ('0c93133b-2354-4cc8-9805-4971169ff4b6', '2', '1', '0', null, null, 'meusse', 'MEUSSE', 'meusse@uninorte.com', 'MEUSSE@UNINORTE.COM', '0', 'AQAAAAEAACcQAAAAEE5wj7yXSF8G70J2gzOW4cVGpRabTsNRnCIf9+kNFa7N5ZmlPXvG/Gu4gatXbpEBmA==', 'QW5H5B3CVB362E4Y7CNGWTE4D4GLVZWD', '24d69f19-4682-463b-a09f-89e5f964bdac', null, '0', '0', null, '1', '0');
INSERT INTO `aspnetusers` VALUES ('78bcb9b3-a7ab-4a62-ae60-145372cb37e8', '5', '0', '0', null, null, 'usuario', 'USUARIO', 'usuario@gmail.com', 'USUARIO@GMAIL.COM', '0', 'AQAAAAEAACcQAAAAEPbrN6Z5/i2V2grL9g0tRt1164rJxoXKBxG3R3PyFWJSZJv3s5SPonKrL+FS1/LxjQ==', 'EZ223XGBLXXVE7QGO4PNQ6GO672VSTFX', 'a4e0a212-0172-4cf6-b593-d187c2820ee8', null, '0', '0', null, '1', '0');
INSERT INTO `aspnetusers` VALUES ('cf090fd0-11ca-48b9-b596-480ec320d187', '2', '1', '0', null, null, 'meusse1', 'MEUSSE1', 'meusse1@uninorte.com', 'MEUSSE1@UNINORTE.COM', '0', 'AQAAAAEAACcQAAAAEKfN3cXOrzARNc2SbTSJ9z+d/EX6aMCGVTBAddDgsduL9CsCWu6q0hVvzayZjMaNCg==', 'AAU7GCAYFLAQHKJZIS3SWPPTYAMNYOAV', 'c900c7dd-efa1-43f8-81ab-f4ec996b7f86', null, '0', '0', null, '1', '0');
INSERT INTO `aspnetusers` VALUES ('f0c55475-5fdf-4414-93f6-8dd878adb5fd', '5', '1', '0', null, null, 'angelgil', 'ANGELGIL', 'agd@gmail.com', 'AGD@GMAIL.COM', '0', 'AQAAAAEAACcQAAAAELObPCxDBrx9A99BKlTqAaWBwTL0/oLhYrJQSul4Eje84FKXQNbMGMmxSEoWwD9agA==', 'LVULFITMOIBW5V4ROTQHHDZC5TOJUX4C', '93510f4a-e084-4f21-98c5-e5c314b90e07', null, '0', '0', null, '1', '0');

-- ----------------------------
-- Table structure for aspnetusertokens
-- ----------------------------
DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8 COLLATE utf8_general_ci,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `aspnetusertokens_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of aspnetusertokens
-- ----------------------------

-- ----------------------------
-- Table structure for cnf_empresa
-- ----------------------------
DROP TABLE IF EXISTS `cnf_empresa`;
CREATE TABLE `cnf_empresa` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nit` varchar(12) NOT NULL DEFAULT '',
  `razon_social` varchar(255) NOT NULL DEFAULT '',
  `id_tercero_gerente` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `ind_cnf_empresa_nit` (`nit`) USING BTREE,
  KEY `fk_cnf_empresa_cnt_tercero_1` (`id_tercero_gerente`),
  CONSTRAINT `cnf_empresa_ibfk_1` FOREIGN KEY (`id_tercero_gerente`) REFERENCES `cnt_tercero` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of cnf_empresa
-- ----------------------------
INSERT INTO `cnf_empresa` VALUES ('13', '800123458', 'TODOS LOS RECUERDOS DE ELLA', '2');
INSERT INTO `cnf_empresa` VALUES ('14', '800123400', 'LA VENTANA MARRONCITA', '5');
INSERT INTO `cnf_empresa` VALUES ('16', '800123459', 'TODOS LOS RECUERDOS DE ELLA', null);
INSERT INTO `cnf_empresa` VALUES ('18', '800123499', 'TODOS LOS RECUERDOS DE ELLA', null);

-- ----------------------------
-- Table structure for cnf_permisousuario
-- ----------------------------
DROP TABLE IF EXISTS `cnf_permisousuario`;
CREATE TABLE `cnf_permisousuario` (
  `id` int NOT NULL,
  `pus_ingresar` tinyint(1) NOT NULL DEFAULT '0' COMMENT '1 : si puede ingresar\n0 : no puede ingresar',
  `pus_crear` tinyint(1) NOT NULL DEFAULT '0' COMMENT '1 : si\n2 : no',
  `pus_consultar` tinyint(1) NOT NULL DEFAULT '0' COMMENT '1 : si\n0 : no',
  `pus_actualizar` tinyint(1) NOT NULL DEFAULT '0' COMMENT '1 : si\n0 : no',
  `pus_eliminar` tinyint(1) NOT NULL DEFAULT '0' COMMENT '1 : si\n0 : no',
  `iddetalle_menu` int DEFAULT NULL,
  `idusuarios` int DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnf_permisousuario
-- ----------------------------

-- ----------------------------
-- Table structure for cnf_sucursal
-- ----------------------------
DROP TABLE IF EXISTS `cnf_sucursal`;
CREATE TABLE `cnf_sucursal` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `id_empresa` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `codigo` (`codigo`),
  KEY `fk_cnf_sucursal_cnf_empresa_1` (`id_empresa`),
  CONSTRAINT `cnf_sucursal_ibfk_1` FOREIGN KEY (`id_empresa`) REFERENCES `cnf_empresa` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Records of cnf_sucursal
-- ----------------------------
INSERT INTO `cnf_sucursal` VALUES ('2', 'S01', 'SUCURSAL SOLEDAD MODIFICADA ', '18');
INSERT INTO `cnf_sucursal` VALUES ('4', 'S02', 'SUCURSAL SOLEDAD CALLE 22', '14');

-- ----------------------------
-- Table structure for cnt_ano
-- ----------------------------
DROP TABLE IF EXISTS `cnt_ano`;
CREATE TABLE `cnt_ano` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_comprobante` int NOT NULL,
  `ano_ano` int NOT NULL,
  `ano_cerrado` tinyint(1) NOT NULL DEFAULT '0',
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL,
  `id_usuario` varchar(255) NOT NULL DEFAULT '',
  `estado` varchar(1) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'A',
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_ano_cnf_usuario_1` (`id_usuario`),
  KEY `fk_cnt_ano_cnt_comprobante_1` (`id_comprobante`),
  CONSTRAINT `fk_cnt_ano_cnf_usuario_1` FOREIGN KEY (`id_usuario`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `fk_cnt_ano_cnt_comprobante_1` FOREIGN KEY (`id_comprobante`) REFERENCES `cnt_comprobante` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_ano
-- ----------------------------
INSERT INTO `cnt_ano` VALUES ('1', '7', '2021', '0', '2021-06-29 10:13:41', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');

-- ----------------------------
-- Table structure for cnt_banco
-- ----------------------------
DROP TABLE IF EXISTS `cnt_banco`;
CREATE TABLE `cnt_banco` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(4) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `nombre` char(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`,`codigo`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_banco
-- ----------------------------
INSERT INTO `cnt_banco` VALUES ('1', '1001', 'BANCO DE BOGOTA');
INSERT INTO `cnt_banco` VALUES ('2', '1002', 'BANCO POPULAR');
INSERT INTO `cnt_banco` VALUES ('3', '1006', 'ITAU antes Corpbanca');
INSERT INTO `cnt_banco` VALUES ('4', '1007', 'BANCOLOMBIA');
INSERT INTO `cnt_banco` VALUES ('5', '1009', 'CITIBANK');
INSERT INTO `cnt_banco` VALUES ('6', '1012', 'BANCO GNB SUDAMERIS M');
INSERT INTO `cnt_banco` VALUES ('7', '1013', 'BBVA COLOMBIA');
INSERT INTO `cnt_banco` VALUES ('8', '1014', 'ITAU');
INSERT INTO `cnt_banco` VALUES ('9', '1019', 'SCOTIABANK COLPATRIA S.A');
INSERT INTO `cnt_banco` VALUES ('10', '1023', 'BANCO DE OCCIDENTE');
INSERT INTO `cnt_banco` VALUES ('11', '1031', 'BANCOLDEX S.A.');
INSERT INTO `cnt_banco` VALUES ('12', '1032', 'BANCO CAJA SOCIAL BCSC SA');
INSERT INTO `cnt_banco` VALUES ('13', '1040', 'BANCO AGRARIO');
INSERT INTO `cnt_banco` VALUES ('14', '1047', 'BANCO MUNDO MUJER');
INSERT INTO `cnt_banco` VALUES ('15', '1051', 'BANCO DAVIVIENDA SA');
INSERT INTO `cnt_banco` VALUES ('16', '1052', 'BANCO AV VILLAS');
INSERT INTO `cnt_banco` VALUES ('17', '1053', 'BANCO W S.A.');
INSERT INTO `cnt_banco` VALUES ('18', '1058', 'BANCO PROCREDIT COLOMBIA');
INSERT INTO `cnt_banco` VALUES ('19', '1059', 'BANCAMIA S.A.');
INSERT INTO `cnt_banco` VALUES ('20', '1060', 'BANCO PICHINCHA');
INSERT INTO `cnt_banco` VALUES ('21', '1061', 'BANCOOMEVA');
INSERT INTO `cnt_banco` VALUES ('22', '1062', 'BANCO FALABELLA S.A.');
INSERT INTO `cnt_banco` VALUES ('23', '1063', 'BANCO FINANDINA S.A.');
INSERT INTO `cnt_banco` VALUES ('24', '1064', 'BANCO MULTIBANK S.A.');
INSERT INTO `cnt_banco` VALUES ('25', '1065', 'BANCO SANTANDER DE NEGOCIOS COLOMBIA S.A');
INSERT INTO `cnt_banco` VALUES ('26', '1066', 'BANCO COOPERATIVO COOPCENTRAL');
INSERT INTO `cnt_banco` VALUES ('27', '1067', 'BANCO COMPARTIR S.A');
INSERT INTO `cnt_banco` VALUES ('28', '1069', 'BANCO SERFINANZA S.A');
INSERT INTO `cnt_banco` VALUES ('29', '1121', 'FINANCIERA JURISCOOP S.A. COMPAÑIA DE FINANCIAMIENTO');
INSERT INTO `cnt_banco` VALUES ('30', '1283', 'COOPERATIVA FINANCIERA DE ANTIOQUIA');
INSERT INTO `cnt_banco` VALUES ('31', '1289', 'COOTRAFA COOPERATIVA FINANCIERA');
INSERT INTO `cnt_banco` VALUES ('32', '1292', 'CONFIAR COOPERATIVA FINANCIERA');
INSERT INTO `cnt_banco` VALUES ('33', '1370', 'COLTEFINANCIERA S.A');
INSERT INTO `cnt_banco` VALUES ('34', '1507', 'NEQUI');
INSERT INTO `cnt_banco` VALUES ('35', '1551', 'DAVIPLATA');

-- ----------------------------
-- Table structure for cnt_categoriacomprobante
-- ----------------------------
DROP TABLE IF EXISTS `cnt_categoriacomprobante`;
CREATE TABLE `cnt_categoriacomprobante` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` varchar(3) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `nombre` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_categoriacomprobante
-- ----------------------------
INSERT INTO `cnt_categoriacomprobante` VALUES ('1', 'SI', 'SALDOS INICIALES');
INSERT INTO `cnt_categoriacomprobante` VALUES ('2', 'CC', 'COMPROBANTES CONTABLES');
INSERT INTO `cnt_categoriacomprobante` VALUES ('3', 'FV', 'FACTURA DE VENTA');
INSERT INTO `cnt_categoriacomprobante` VALUES ('4', 'FC', 'FACTURA DE COMPRA');
INSERT INTO `cnt_categoriacomprobante` VALUES ('5', 'CE', 'COMPROBANTE DE EGRESO');
INSERT INTO `cnt_categoriacomprobante` VALUES ('6', 'RC', 'RECIBO DE CAJA');
INSERT INTO `cnt_categoriacomprobante` VALUES ('7', 'CA', 'CIERRE ANUAL');
INSERT INTO `cnt_categoriacomprobante` VALUES ('8', 'NO', 'NOTA CONTABLE');
INSERT INTO `cnt_categoriacomprobante` VALUES ('9', 'RM', 'REMISION');
INSERT INTO `cnt_categoriacomprobante` VALUES ('10', 'RVD', 'REVERSIONES DE DOCUMEMTOS');
INSERT INTO `cnt_categoriacomprobante` VALUES ('11', 'AI', 'AJUSTES DE INVENTARIO');

-- ----------------------------
-- Table structure for cnt_centrocosto
-- ----------------------------
DROP TABLE IF EXISTS `cnt_centrocosto`;
CREATE TABLE `cnt_centrocosto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` varchar(3) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `nombre` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `estado` varchar(1) NOT NULL DEFAULT 'A',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_centrocosto
-- ----------------------------
INSERT INTO `cnt_centrocosto` VALUES ('1', 'S01', 'SOLEDAD BODEGA', '2021-09-01 10:47:40', '2021-09-26 11:29:05', 'A');
INSERT INTO `cnt_centrocosto` VALUES ('2', 'B01', 'BUENAVISTA 11', '2021-09-02 10:47:45', '2021-09-26 11:30:15', 'A');
INSERT INTO `cnt_centrocosto` VALUES ('4', 'BL3', 'BUENAVISTA LOCAL33', '2021-09-25 11:09:25', '2021-09-26 11:29:07', 'A');

-- ----------------------------
-- Table structure for cnt_ciiu
-- ----------------------------
DROP TABLE IF EXISTS `cnt_ciiu`;
CREATE TABLE `cnt_ciiu` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `id_tipociuu` int NOT NULL,
  `id_seccionciiu` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_ciiu_cnt_tipociiu_1` (`id_tipociuu`),
  KEY `seccion_codigo_tipo` (`id_seccionciiu`,`codigo`,`id_tipociuu`) USING BTREE,
  CONSTRAINT `cnt_ciiu_ibfk_1` FOREIGN KEY (`id_seccionciiu`) REFERENCES `cnt_seccionciiu` (`id`),
  CONSTRAINT `cnt_ciiu_ibfk_2` FOREIGN KEY (`id_tipociuu`) REFERENCES `cnt_tipociiu` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=847 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_ciiu
-- ----------------------------
INSERT INTO `cnt_ciiu` VALUES ('1', '01', 'Agricultura, ganadería, caza y actividades de servicios conexas ', '1', '1');
INSERT INTO `cnt_ciiu` VALUES ('2', '02', 'Silvicultura y extracción de madera', '1', '1');
INSERT INTO `cnt_ciiu` VALUES ('3', '03', 'Pesca y acuicultura', '1', '1');
INSERT INTO `cnt_ciiu` VALUES ('4', '05', 'Extracción de carbón de piedra y lignito', '1', '2');
INSERT INTO `cnt_ciiu` VALUES ('5', '06', 'Extracción de petróleo crudo y gas natural', '1', '2');
INSERT INTO `cnt_ciiu` VALUES ('6', '07', 'Extracción de minerales metalíferos', '1', '2');
INSERT INTO `cnt_ciiu` VALUES ('7', '08', 'Extracción de otras minas y canteras', '1', '2');
INSERT INTO `cnt_ciiu` VALUES ('8', '09', 'Actividades de servicios de apoyo para la explotación de minas ', '1', '2');
INSERT INTO `cnt_ciiu` VALUES ('9', '10', 'Elaboración de productos alimenticios', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('10', '11', 'Elaboración de bebidas', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('11', '12', 'Elaboración de productos de tabaco', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('12', '13', 'Fabricación de productos textiles', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('13', '14', 'Confección de prendas de vestir', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('14', '15', 'Curtido y recurtido de cueros; fabricación de calzado; fabricación de artículos de viaje, maletas, bolsos de mano y artículos similares, y fabricación de artículos de talabartería y guarnicionería; adobo y teñido de pieles', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('15', '16', 'Transformación de la madera y fabricación de productos de madera y de corcho, excepto muebles; fabricación de artículos de cestería y espartería', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('16', '17', 'Fabricación de papel, cartón y productos de papel y cartón', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('17', '18', 'Actividades de impresión y de producción de copias a partir de grabaciones originales ', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('18', '19', 'Coquización, fabricación de productos de la refinación del petróleo y actividad de mezcla de combustibles ', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('19', '20', 'Fabricación de sustancias y productos químicos', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('20', '21', 'Fabricación de productos farmacéuticos, sustancias químicas medicinales y productos botánicos de uso farmacéutico', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('21', '22', 'Fabricación de productos de caucho y de plástico', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('22', '23', 'Fabricación de otros productos minerales no metálicos', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('23', '24', 'Fabricación de productos metalúrgicos básicos', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('24', '25', 'Fabricación de productos elaborados de metal, excepto maquinaria y equipo', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('25', '26', 'Fabricación de productos informáticos, electrónicos y ópticos', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('26', '27', 'Fabricación de aparatos y equipo eléctrico', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('27', '28', 'Fabricación de maquinaria y equipo n.c.p.', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('28', '29', 'Fabricación de vehículos automotores, remolques y semirremolques', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('29', '30', 'Fabricación de otros tipos de equipo de transporte', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('30', '31', 'Fabricación de muebles, colchones y somieres', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('31', '32', 'Otras industrias manufactureras', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('32', '33', 'Instalación, mantenimiento y reparación especializado de maquinaria y equipo', '1', '3');
INSERT INTO `cnt_ciiu` VALUES ('33', '35', 'Suministro de electricidad, gas, vapor y aire acondicionado ', '1', '4');
INSERT INTO `cnt_ciiu` VALUES ('34', '36', 'Captación, tratamiento y distribución de agua', '1', '5');
INSERT INTO `cnt_ciiu` VALUES ('35', '37', 'Evacuación y tratamiento de aguas residuales', '1', '5');
INSERT INTO `cnt_ciiu` VALUES ('36', '38', 'Recolección, tratamiento y disposición de desechos, recuperación de materiales', '1', '5');
INSERT INTO `cnt_ciiu` VALUES ('37', '39', 'Actividades de saneamiento ambiental y otros servicios de gestión de desechos', '1', '5');
INSERT INTO `cnt_ciiu` VALUES ('38', '41', 'Construcción de edificios', '1', '6');
INSERT INTO `cnt_ciiu` VALUES ('39', '42', 'Obras de ingeniería civil', '1', '6');
INSERT INTO `cnt_ciiu` VALUES ('40', '43', 'Actividades especializadas para la construcción de edificios y obras de ingeniería civil', '1', '6');
INSERT INTO `cnt_ciiu` VALUES ('41', '45', 'Comercio, mantenimiento y reparación de vehículos automotores y motocicletas, sus partes, piezas y accesorios', '1', '7');
INSERT INTO `cnt_ciiu` VALUES ('42', '46', 'Comercio al por mayor y en comisión o por contrata, excepto el comercio de vehículos automotores y motocicletas', '1', '7');
INSERT INTO `cnt_ciiu` VALUES ('43', '47', 'Comercio al por menor (incluso el comercio al por menor de combustibles), excepto el de vehículos automotores y motocicletas', '1', '7');
INSERT INTO `cnt_ciiu` VALUES ('44', '49', 'Transporte terrestre; transporte por tuberías', '1', '8');
INSERT INTO `cnt_ciiu` VALUES ('45', '50', 'Transporte acuático', '1', '8');
INSERT INTO `cnt_ciiu` VALUES ('46', '51', 'Transporte aéreo', '1', '8');
INSERT INTO `cnt_ciiu` VALUES ('47', '52', 'Almacenamiento y actividades complementarias al transporte', '1', '8');
INSERT INTO `cnt_ciiu` VALUES ('48', '53', 'Correo y servicios de mensajería', '1', '8');
INSERT INTO `cnt_ciiu` VALUES ('49', '55', 'Alojamiento', '1', '9');
INSERT INTO `cnt_ciiu` VALUES ('50', '56', 'Actividades de servicios de comidas y bebidas', '1', '9');
INSERT INTO `cnt_ciiu` VALUES ('51', '58', 'Actividades de edición', '1', '10');
INSERT INTO `cnt_ciiu` VALUES ('52', '59', 'Actividades cinematográficas, de video y producción de programas de televisión, grabación de sonido y edición de música', '1', '10');
INSERT INTO `cnt_ciiu` VALUES ('53', '60', 'Actividades de programación, transmisión y/o difusión', '1', '10');
INSERT INTO `cnt_ciiu` VALUES ('54', '61', 'Telecomunicaciones', '1', '10');
INSERT INTO `cnt_ciiu` VALUES ('55', '62', 'Desarrollo de sistemas informáticos (planificación, análisis, diseño, programación, pruebas), consultoría informática y actividades relacionadas', '1', '10');
INSERT INTO `cnt_ciiu` VALUES ('56', '63', 'Actividades de servicios de información', '1', '10');
INSERT INTO `cnt_ciiu` VALUES ('57', '64', 'Actividades de servicios financieros, excepto las de seguros y de pensiones', '1', '11');
INSERT INTO `cnt_ciiu` VALUES ('58', '65', 'Seguros (incluso el reaseguro), seguros sociales y fondos de pensiones, excepto la seguridad social', '1', '11');
INSERT INTO `cnt_ciiu` VALUES ('59', '66', 'Actividades auxiliares de las actividades de servicios financieros', '1', '11');
INSERT INTO `cnt_ciiu` VALUES ('60', '68', 'Actividades inmobiliarias', '1', '12');
INSERT INTO `cnt_ciiu` VALUES ('61', '69', 'Actividades jurídicas y de contabilidad', '1', '13');
INSERT INTO `cnt_ciiu` VALUES ('62', '70', 'Actividades de administración empresarial; actividades de consultoría de gestión', '1', '13');
INSERT INTO `cnt_ciiu` VALUES ('63', '71', 'Actividades de arquitectura e ingeniería; ensayos y análisis técnicos', '1', '13');
INSERT INTO `cnt_ciiu` VALUES ('64', '72', 'Investigación científica y desarrollo', '1', '13');
INSERT INTO `cnt_ciiu` VALUES ('65', '73', 'Publicidad y estudios de mercado', '1', '13');
INSERT INTO `cnt_ciiu` VALUES ('66', '74', 'Otras actividades profesionales, científicas y técnicas', '1', '13');
INSERT INTO `cnt_ciiu` VALUES ('67', '75', 'Actividades veterinarias', '1', '13');
INSERT INTO `cnt_ciiu` VALUES ('68', '77', 'Actividades de alquiler y arrendamiento', '1', '14');
INSERT INTO `cnt_ciiu` VALUES ('69', '78', 'Actividades de empleo', '1', '14');
INSERT INTO `cnt_ciiu` VALUES ('70', '79', 'Actividades de las agencias de viajes, operadores turísticos, servicios de reserva y actividades relacionadas', '1', '14');
INSERT INTO `cnt_ciiu` VALUES ('71', '80', 'Actividades de seguridad e investigación privada', '1', '14');
INSERT INTO `cnt_ciiu` VALUES ('72', '81', 'Actividades de servicios a edificios y paisajismo (jardines, zonas verdes)', '1', '14');
INSERT INTO `cnt_ciiu` VALUES ('73', '82', 'Actividades administrativas y de apoyo de oficina y otras actividades de apoyo a las empresas', '1', '14');
INSERT INTO `cnt_ciiu` VALUES ('74', '84', 'Administración pública y defensa; planes de seguridad social de afiliación obligatoria', '1', '15');
INSERT INTO `cnt_ciiu` VALUES ('75', '85', 'Educación', '1', '16');
INSERT INTO `cnt_ciiu` VALUES ('76', '86', 'Actividades de atención de la salud humana', '1', '17');
INSERT INTO `cnt_ciiu` VALUES ('77', '87', 'Actividades de atención residencial medicalizada', '1', '17');
INSERT INTO `cnt_ciiu` VALUES ('78', '88', 'Actividades de asistencia social sin alojamiento', '1', '17');
INSERT INTO `cnt_ciiu` VALUES ('79', '90', 'Actividades creativas, artísticas y de entretenimiento', '1', '18');
INSERT INTO `cnt_ciiu` VALUES ('80', '91', 'Actividades de bibliotecas, archivos, museos y otras actividades culturales', '1', '18');
INSERT INTO `cnt_ciiu` VALUES ('81', '92', 'Actividades de juegos de azar y apuestas', '1', '18');
INSERT INTO `cnt_ciiu` VALUES ('82', '93', 'Actividades deportivas y actividades recreativas y de esparcimiento', '1', '18');
INSERT INTO `cnt_ciiu` VALUES ('83', '94', 'Actividades de asociaciones', '1', '19');
INSERT INTO `cnt_ciiu` VALUES ('84', '95', 'Mantenimiento y reparación de computadores, efectos personales y enseres domésticos', '1', '19');
INSERT INTO `cnt_ciiu` VALUES ('85', '96', 'Otras actividades de servicios personales', '1', '19');
INSERT INTO `cnt_ciiu` VALUES ('86', '97', 'Actividades de los hogares individuales como empleadores de personal doméstico', '1', '20');
INSERT INTO `cnt_ciiu` VALUES ('87', '98', 'Actividades no diferenciadas de los hogares individuales como productores de bienes y servicios para uso propio', '1', '20');
INSERT INTO `cnt_ciiu` VALUES ('88', '99', 'Actividades de organizaciones y entidades extraterritoriales', '1', '21');
INSERT INTO `cnt_ciiu` VALUES ('89', '10', 'Asalariados', '1', '22');
INSERT INTO `cnt_ciiu` VALUES ('90', '20', 'Pensionados', '1', '22');
INSERT INTO `cnt_ciiu` VALUES ('91', '81', 'Personas naturales y sucesiones ilíquidas sin actividad económica', '1', '22');
INSERT INTO `cnt_ciiu` VALUES ('92', '82', 'Personas naturales subsidiadas por terceros', '1', '22');
INSERT INTO `cnt_ciiu` VALUES ('93', '90', 'Rentistas de capital, solo para personas naturales y sucesiones ilíquidas', '1', '22');
INSERT INTO `cnt_ciiu` VALUES ('94', '011', 'Cultivos agrícolas transitorios ', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('95', '012', 'Cultivos agrícolas permanentes ', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('96', '013', 'Propagación de plantas (actividades de los viveros, excepto viveros forestales) ', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('97', '014', 'Ganadería ', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('98', '015', 'Explotación mixta (agrícola y pecuaria) ', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('99', '016', 'Actividades de apoyo a la agricultura y la ganadería, y actividades posteriores a la cosecha ', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('100', '017', 'Caza ordinaria y mediante trampas y actividades de servicios conexas ', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('101', '021', 'Silvicultura y otras actividades forestales', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('102', '022', 'Extracción de madera ', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('103', '023', 'Recolección de productos forestales diferentes a la madera', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('104', '024', 'Servicios de apoyo a la silvicultura ', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('105', '031', 'Pesca ', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('106', '032', 'Acuicultura ', '2', '1');
INSERT INTO `cnt_ciiu` VALUES ('107', '051', 'Extracción de hulla (carbón de piedra)', '2', '2');
INSERT INTO `cnt_ciiu` VALUES ('108', '052', 'Extracción de carbón lignito', '2', '2');
INSERT INTO `cnt_ciiu` VALUES ('109', '061', 'Extracción de petróleo crudo', '2', '2');
INSERT INTO `cnt_ciiu` VALUES ('110', '062', 'Extracción de gas natural', '2', '2');
INSERT INTO `cnt_ciiu` VALUES ('111', '071', 'Extracción de minerales de hierro', '2', '2');
INSERT INTO `cnt_ciiu` VALUES ('112', '072', 'Extracción de minerales metalíferos no ferrosos', '2', '2');
INSERT INTO `cnt_ciiu` VALUES ('113', '081', 'Extracción de piedra, arena, arcillas, cal, yeso, caolín, bentonitas y similares', '2', '2');
INSERT INTO `cnt_ciiu` VALUES ('114', '082', 'Extracción de esmeraldas, piedras preciosas y semipreciosas', '2', '2');
INSERT INTO `cnt_ciiu` VALUES ('115', '089', 'Extracción de otros minerales no metálicos n.c.p.', '2', '2');
INSERT INTO `cnt_ciiu` VALUES ('116', '091', 'Actividades de apoyo para la extracción de petróleo y de gas natural', '2', '2');
INSERT INTO `cnt_ciiu` VALUES ('117', '099', 'Actividades de apoyo para otras actividades de explotación de minas y canteras', '2', '2');
INSERT INTO `cnt_ciiu` VALUES ('118', '101', 'Procesamiento y conservación de carne, pescado, crustáceos y moluscos ', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('119', '102', 'Procesamiento y conservación de frutas, legumbres, hortalizas y tubérculos', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('120', '103', 'Elaboración de aceites y grasas de origen vegetal y animal', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('121', '104', 'Elaboración de productos lácteos', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('122', '105', 'Elaboración de productos de molinería, almidones y productos derivados del almidón', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('123', '106', 'Elaboración de productos de café', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('124', '107', 'Elaboración de azúcar y panela', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('125', '108', 'Elaboración de otros productos alimenticios', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('126', '109', 'Elaboración de alimentos preparados para animales', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('127', '110', 'Elaboración de bebidas', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('128', '120', 'Elaboración de productos de tabaco', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('129', '131', 'Preparación, hilatura, tejeduría y acabado de productos textiles', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('130', '139', 'Fabricación de otros productos textiles', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('131', '141', 'Confección de prendas de vestir, excepto prendas de piel', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('132', '142', 'Fabricación de artículos de piel', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('133', '143', 'Fabricación de artículos de punto y ganchillo', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('134', '151', 'Curtido y recurtido de cueros; fabricación de artículos de viaje, bolsos de mano y artículos similares, y fabricación de artículos de talabartería y guarnicionería, adobo y teñido de pieles', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('135', '152', 'Fabricación de calzado', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('136', '161', 'Aserrado, acepillado e impregnación de la madera', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('137', '162', 'Fabricación de hojas de madera para enchapado; fabricación de tableros contrachapados, tableros laminados, tableros de partículas y otros tableros y paneles', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('138', '163', 'Fabricación de partes y piezas de madera, de carpintería y ebanistería para la construcción', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('139', '164', 'Fabricación de recipientes de madera', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('140', '169', 'Fabricación de otros productos de madera; fabricación de artículos de corcho, cestería y espartería', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('141', '170', 'Fabricación de papel, cartón y productos de papel y cartón', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('142', '181', 'Actividades de impresión y actividades de servicios relacionados con la impresión', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('143', '182', 'Producción de copias a partir de grabaciones originales ', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('144', '191', 'Fabricación de productos de hornos de coque', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('145', '192', 'Fabricación de productos de la refinación del petróleo', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('146', '201', 'Fabricación de sustancias químicas básicas, abonos y compuestos inorgánicos nitrogenados, plásticos y caucho sintético en formas primarias', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('147', '202', 'Fabricación de otros productos químicos', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('148', '203', 'Fabricación de fibras sintéticas y artificiales', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('149', '210', 'Fabricación de productos farmacéuticos, sustancias químicas medicinales y productos botánicos de uso farmacéutico', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('150', '221', 'Fabricación de productos de caucho', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('151', '222', 'Fabricación de productos de plástico', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('152', '231', 'Fabricación de vidrio y productos de vidrio', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('153', '239', 'Fabricación de productos minerales no metálicos n.c.p.', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('154', '241', 'Industrias básicas de hierro y de acero', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('155', '242', 'Industrias básicas de metales preciosos y de metales no ferrosos', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('156', '243', 'Fundición de metales', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('157', '251', 'Fabricación de productos metálicos para uso estructural, tanques, depósitos y generadores de vapor', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('158', '252', 'Fabricación de armas y municiones', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('159', '259', 'Fabricación de otros productos elaborados de metal y actividades de servicios relacionadas con el trabajo de metales', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('160', '261', 'Fabricación de componentes y tableros electrónicos', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('161', '262', 'Fabricación de computadoras y de equipo periférico', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('162', '263', 'Fabricación de equipos de comunicación', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('163', '264', 'Fabricación de aparatos electrónicos de consumo', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('164', '265', 'Fabricación de equipo de medición, prueba, navegación y control; fabricación de relojes', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('165', '266', 'Fabricación de equipo de irradiación y equipo electrónico de uso médico y terapéutico', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('166', '267', 'Fabricación de instrumentos ópticos y equipo fotográfico', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('167', '268', 'Fabricación de medios magnéticos y ópticos para almacenamiento de datos', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('168', '271', 'Fabricación de motores, generadores y transformadores eléctricos y de aparatos de distribución y control de la energía eléctrica', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('169', '272', 'Fabricación de pilas, baterías y acumuladores eléctricos', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('170', '273', 'Fabricación de hilos y cables aislados y sus dispositivos', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('171', '274', 'Fabricación de equipos eléctricos de iluminación', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('172', '275', 'Fabricación de aparatos de uso doméstico', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('173', '279', 'Fabricación de otros tipos de equipo eléctrico n.c.p.', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('174', '281', 'Fabricación de maquinaria y equipo de uso general', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('175', '282', 'Fabricación de maquinaria y equipo de uso especial', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('176', '291', 'Fabricación de vehículos automotores y sus motores', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('177', '292', 'Fabricación de carrocerías para vehículos automotores; fabricación de remolques y semirremolques ', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('178', '293', 'Fabricación de partes, piezas (autopartes) y accesorios (lujos) para vehículos automotores', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('179', '301', 'Construcción de barcos y otras embarcaciones', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('180', '302', 'Fabricación de locomotoras y de material rodante para ferrocarriles', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('181', '303', 'Fabricación de aeronaves, naves espaciales y de maquinaria conexa', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('182', '304', 'Fabricación de vehículos militares de combate', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('183', '309', 'Fabricación de otros tipos de equipo de transporte n.c.p.', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('184', '311', 'Fabricación de muebles ', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('185', '312', 'Fabricación de colchones y somieres', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('186', '321', 'Fabricación de joyas, bisutería y artículos conexos', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('187', '322', 'Fabricación de instrumentos musicales', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('188', '323', 'Fabricación de artículos y equipo para la práctica del deporte', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('189', '324', 'Fabricación de juegos, juguetes y rompecabezas', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('190', '325', 'Fabricación de instrumentos, aparatos y materiales médicos y odontológicos (incluido mobiliario)', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('191', '329', 'Otras industrias manufactureras n.c.p.', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('192', '331', 'Mantenimiento y reparación especializado de productos elaborados en metal y de maquinaria y equipo', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('193', '332', 'Instalación especializada de maquinaria y equipo industrial ', '2', '3');
INSERT INTO `cnt_ciiu` VALUES ('194', '351', 'Generación, transmisión, distribución y comercialización de energía eléctrica', '2', '4');
INSERT INTO `cnt_ciiu` VALUES ('195', '352', 'Producción de gas; distribución de combustibles gaseosos por tuberías', '2', '4');
INSERT INTO `cnt_ciiu` VALUES ('196', '353', 'Suministro de vapor y aire acondicionado', '2', '4');
INSERT INTO `cnt_ciiu` VALUES ('197', '360', 'Captación, tratamiento y distribución de agua', '2', '5');
INSERT INTO `cnt_ciiu` VALUES ('198', '370', 'Evacuación y tratamiento de aguas residuales', '2', '5');
INSERT INTO `cnt_ciiu` VALUES ('199', '381', 'Recolección de desechos', '2', '5');
INSERT INTO `cnt_ciiu` VALUES ('200', '382', 'Tratamiento y disposición de desechos', '2', '5');
INSERT INTO `cnt_ciiu` VALUES ('201', '383', 'Recuperación de materiales', '2', '5');
INSERT INTO `cnt_ciiu` VALUES ('202', '390', 'Actividades de saneamiento ambiental y otros servicios de gestión de desechos', '2', '5');
INSERT INTO `cnt_ciiu` VALUES ('203', '411', 'Construcción de edificios', '2', '6');
INSERT INTO `cnt_ciiu` VALUES ('204', '421', 'Construcción de carreteras y vías de ferrocarril', '2', '6');
INSERT INTO `cnt_ciiu` VALUES ('205', '422', 'Construcción de proyectos de servicio público', '2', '6');
INSERT INTO `cnt_ciiu` VALUES ('206', '429', 'Construcción de otras obras de ingeniería civil', '2', '6');
INSERT INTO `cnt_ciiu` VALUES ('207', '431', 'Demolición y preparación del terreno', '2', '6');
INSERT INTO `cnt_ciiu` VALUES ('208', '432', 'Instalaciones eléctricas, de fontanería y otras instalaciones especializadas', '2', '6');
INSERT INTO `cnt_ciiu` VALUES ('209', '433', 'Terminación y acabado de edificios y obras de ingeniería civil', '2', '6');
INSERT INTO `cnt_ciiu` VALUES ('210', '439', 'Otras actividades especializadas para la construcción de edificios y obras de ingeniería civil', '2', '6');
INSERT INTO `cnt_ciiu` VALUES ('211', '451', 'Comercio de vehículos automotores', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('212', '452', 'Mantenimiento y reparación de vehículos automotores', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('213', '453', 'Comercio de partes, piezas (autopartes) y accesorios (lujos) para vehículos automotores', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('214', '454', 'Comercio, mantenimiento y reparación de motocicletas y de sus partes, piezas y accesorios', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('215', '461', 'Comercio al por mayor a cambio de una retribución o por contrata', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('216', '462', 'Comercio al por mayor de materias primas agropecuarias; animales vivos', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('217', '463', 'Comercio al por mayor de alimentos, bebidas y tabaco', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('218', '464', 'Comercio al por mayor de artículos y enseres domésticos (incluidas prendas de vestir)', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('219', '465', 'Comercio al por mayor de maquinaria y equipo ', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('220', '466', 'Comercio al por mayor especializado de otros productos', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('221', '469', 'Comercio al por mayor no especializado', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('222', '471', 'Comercio al por menor en establecimientos no especializados', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('223', '472', 'Comercio al por menor de alimentos (víveres en general), bebidas y tabaco, en establecimientos especializados', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('224', '473', 'Comercio al por menor de combustible, lubricantes, aditivos y productos de limpieza para automotores, en establecimientos especializados', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('225', '474', 'Comercio al por menor de equipos de informática y de comunicaciones, en establecimientos especializados', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('226', '475', 'Comercio al por menor de otros enseres domésticos en establecimientos especializados', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('227', '476', 'Comercio al por menor de artículos culturales y de entretenimiento, en establecimientos especializados', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('228', '477', 'Comercio al por menor de otros productos en establecimientos especializados', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('229', '478', 'Comercio al por menor en puestos de venta móviles', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('230', '479', 'Comercio al por menor no realizado en establecimientos, puestos de venta o mercados', '2', '7');
INSERT INTO `cnt_ciiu` VALUES ('231', '491', 'Transporte férreo', '2', '8');
INSERT INTO `cnt_ciiu` VALUES ('232', '492', 'Transporte terrestre público automotor', '2', '8');
INSERT INTO `cnt_ciiu` VALUES ('233', '493', 'Transporte por tuberías', '2', '8');
INSERT INTO `cnt_ciiu` VALUES ('234', '501', 'Transporte marítimo y de cabotaje', '2', '8');
INSERT INTO `cnt_ciiu` VALUES ('235', '502', 'Transporte fluvial', '2', '8');
INSERT INTO `cnt_ciiu` VALUES ('236', '511', 'Transporte aéreo de pasajeros ', '2', '8');
INSERT INTO `cnt_ciiu` VALUES ('237', '512', 'Transporte aéreo de carga ', '2', '8');
INSERT INTO `cnt_ciiu` VALUES ('238', '521', 'Almacenamiento y depósito', '2', '8');
INSERT INTO `cnt_ciiu` VALUES ('239', '522', 'Actividades de las estaciones, vías y servicios complementarios para el transporte', '2', '8');
INSERT INTO `cnt_ciiu` VALUES ('240', '531', 'Actividades postales nacionales', '2', '8');
INSERT INTO `cnt_ciiu` VALUES ('241', '532', 'Actividades de mensajería', '2', '8');
INSERT INTO `cnt_ciiu` VALUES ('242', '551', 'Actividades de alojamiento de estancias cortas', '2', '9');
INSERT INTO `cnt_ciiu` VALUES ('243', '552', 'Actividades de zonas de camping y parques para vehículos recreacionales', '2', '9');
INSERT INTO `cnt_ciiu` VALUES ('244', '553', 'Servicio por horas ', '2', '9');
INSERT INTO `cnt_ciiu` VALUES ('245', '559', 'Otros tipos de alojamiento n.c.p.', '2', '9');
INSERT INTO `cnt_ciiu` VALUES ('246', '561', 'Actividades de restaurantes, cafeterías y servicio móvil de comidas', '2', '9');
INSERT INTO `cnt_ciiu` VALUES ('247', '562', 'Actividades de catering para eventos y otros servicios de comidas', '2', '9');
INSERT INTO `cnt_ciiu` VALUES ('248', '563', 'Expendio de bebidas alcohólicas para el consumo dentro del establecimiento', '2', '9');
INSERT INTO `cnt_ciiu` VALUES ('249', '581', 'Edición de libros, publicaciones periódicas y otras actividades de edición', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('250', '582', 'Edición de programas de informática (software)', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('251', '591', 'Actividades de producción de películas cinematográficas, video y producción de programas, anuncios y comerciales de televisión', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('252', '592', 'Actividades de grabación de sonido y edición de música', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('253', '601', 'Actividades de programación y transmisión en el servicio de radiodifusión sonora', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('254', '602', 'Actividades de programación y transmisión de televisión', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('255', '611', 'Actividades de telecomunicaciones alámbricas', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('256', '612', 'Actividades de telecomunicaciones inalámbricas', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('257', '613', 'Actividades de telecomunicación satelital', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('258', '619', 'Otras actividades de telecomunicaciones', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('259', '620', 'Desarrollo de sistemas informáticos (planificación, análisis, diseño, programación, pruebas), consultoría informática y actividades relacionadas', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('260', '631', 'Procesamiento de datos, alojamiento (hosting) y actividades relacionadas; portales web', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('261', '639', 'Otras actividades de servicio de información', '2', '10');
INSERT INTO `cnt_ciiu` VALUES ('262', '641', 'Intermediación monetaria', '2', '11');
INSERT INTO `cnt_ciiu` VALUES ('263', '642', 'Otros tipos de intermediación monetaria', '2', '11');
INSERT INTO `cnt_ciiu` VALUES ('264', '643', 'Fideicomisos, fondos (incluye fondos de cesantías) y entidades financieras similares', '2', '11');
INSERT INTO `cnt_ciiu` VALUES ('265', '649', 'Otras actividades de servicio financiero, excepto las de seguros y pensiones', '2', '11');
INSERT INTO `cnt_ciiu` VALUES ('266', '651', 'Seguros y capitalización', '2', '11');
INSERT INTO `cnt_ciiu` VALUES ('267', '652', 'Servicios de seguros sociales de salud y riesgos profesionales', '2', '11');
INSERT INTO `cnt_ciiu` VALUES ('268', '653', 'Servicios de seguros sociales de pensiones', '2', '11');
INSERT INTO `cnt_ciiu` VALUES ('269', '661', 'Actividades auxiliares de las actividades de servicios financieros, excepto las de seguros y pensiones', '2', '11');
INSERT INTO `cnt_ciiu` VALUES ('270', '662', 'Actividades de servicios auxiliares de los servicios de seguros y pensiones', '2', '11');
INSERT INTO `cnt_ciiu` VALUES ('271', '663', 'Actividades de administración de fondos', '2', '11');
INSERT INTO `cnt_ciiu` VALUES ('272', '681', 'Actividades inmobiliarias realizadas con bienes propios o arrendados', '2', '12');
INSERT INTO `cnt_ciiu` VALUES ('273', '682', 'Actividades inmobiliarias realizadas a cambio de una retribución o por contrata', '2', '12');
INSERT INTO `cnt_ciiu` VALUES ('274', '691', 'Actividades jurídicas', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('275', '692', 'Actividades de contabilidad, teneduría de libros, auditoría financiera y asesoría tributaria', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('276', '701', 'Actividades de administración empresarial', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('277', '702', 'Actividades de consultoría de gestión', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('278', '711', 'Actividades de arquitectura e ingeniería y otras actividades conexas de consultoría técnica', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('279', '712', 'Ensayos y análisis técnicos', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('280', '721', 'Investigaciones y desarrollo experimental en el campo de las ciencias naturales y la ingeniería ', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('281', '722', 'Investigaciones y desarrollo experimental en el campo de las ciencias sociales y las humanidades', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('282', '731', 'Publicidad', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('283', '732', 'Estudios de mercado y realización de encuestas de opinión pública', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('284', '741', 'Actividades especializadas de diseño ', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('285', '742', 'Actividades de fotografía', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('286', '749', 'Otras actividades profesionales, científicas y técnicas n.c.p.', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('287', '750', 'Actividades veterinarias', '2', '13');
INSERT INTO `cnt_ciiu` VALUES ('288', '771', 'Alquiler y arrendamiento de vehículos automotores', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('289', '772', 'Alquiler y arrendamiento de efectos personales y enseres domésticos', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('290', '773', 'Alquiler y arrendamiento de otros tipos de maquinaria, equipo y bienes tangibles n.c.p.', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('291', '774', 'Arrendamiento de propiedad intelectual y productos similares, excepto obras protegidas por derechos de autor', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('292', '781', 'Actividades de agencias de gestión y colocación de empleo', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('293', '782', 'Actividades de empresas de servicios temporales', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('294', '783', 'Otras actividades de provisión de talento humano', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('295', '791', 'Actividades de las agencias de viajes y operadores turísticos', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('296', '799', 'Otros servicios de reserva y actividades relacionadas', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('297', '801', 'Actividades de seguridad privada', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('298', '802', 'Actividades de servicios de sistemas de seguridad', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('299', '803', 'Actividades de detectives e investigadores privados', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('300', '811', 'Actividades combinadas de apoyo a instalaciones', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('301', '812', 'Actividades de limpieza', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('302', '813', 'Actividades de paisajismo y servicios de mantenimiento conexos', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('303', '821', 'Actividades administrativas y de apoyo de oficina', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('304', '822', 'Actividades de centros de llamadas (Call center)', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('305', '823', 'Organización de convenciones y eventos comerciales', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('306', '829', 'Actividades de servicios de apoyo a las empresas n.c.p.', '2', '14');
INSERT INTO `cnt_ciiu` VALUES ('307', '841', 'Administración del Estado y aplicación de la política económica y social de la comunidad', '2', '15');
INSERT INTO `cnt_ciiu` VALUES ('308', '842', 'Prestación de servicios a la comunidad en general', '2', '15');
INSERT INTO `cnt_ciiu` VALUES ('309', '843', 'Actividades de planes de seguridad social de afiliación obligatoria', '2', '15');
INSERT INTO `cnt_ciiu` VALUES ('310', '851', 'Educación de la primera infancia, preescolar y básica primaria', '2', '16');
INSERT INTO `cnt_ciiu` VALUES ('311', '852', 'Educación secundaria y de formación laboral', '2', '16');
INSERT INTO `cnt_ciiu` VALUES ('312', '853', 'Establecimientos que combinan diferentes niveles de educación ', '2', '16');
INSERT INTO `cnt_ciiu` VALUES ('313', '854', 'Educación superior', '2', '16');
INSERT INTO `cnt_ciiu` VALUES ('314', '855', 'Otros tipos de educación', '2', '16');
INSERT INTO `cnt_ciiu` VALUES ('315', '856', 'Actividades de apoyo a la educación', '2', '16');
INSERT INTO `cnt_ciiu` VALUES ('316', '861', 'Actividades de hospitales y clínicas, con internación', '2', '17');
INSERT INTO `cnt_ciiu` VALUES ('317', '862', 'Actividades de práctica médica y odontológica, sin internación ', '2', '17');
INSERT INTO `cnt_ciiu` VALUES ('318', '869', 'Otras actividades de atención relacionadas con la salud humana', '2', '17');
INSERT INTO `cnt_ciiu` VALUES ('319', '871', 'Actividades de atención residencial medicalizada de tipo general', '2', '17');
INSERT INTO `cnt_ciiu` VALUES ('320', '872', 'Actividades de atención residencial, para el cuidado de pacientes con retardo mental, enfermedad mental y consumo de sustancias psicoactivas', '2', '17');
INSERT INTO `cnt_ciiu` VALUES ('321', '873', 'Actividades de atención en instituciones para el cuidado de personas mayores y/o discapacitadas', '2', '17');
INSERT INTO `cnt_ciiu` VALUES ('322', '879', 'Otras actividades de atención en instituciones con alojamiento', '2', '17');
INSERT INTO `cnt_ciiu` VALUES ('323', '881', 'Actividades de asistencia social sin alojamiento para personas mayores y discapacitadas', '2', '17');
INSERT INTO `cnt_ciiu` VALUES ('324', '889', 'Otras actividades de asistencia social sin alojamiento', '2', '17');
INSERT INTO `cnt_ciiu` VALUES ('325', '900', 'Actividades creativas, artísticas y de entretenimiento ', '2', '18');
INSERT INTO `cnt_ciiu` VALUES ('326', '910', 'Actividades de bibliotecas, archivos, museos y otras actividades culturales', '2', '18');
INSERT INTO `cnt_ciiu` VALUES ('327', '920', 'Actividades de juegos de azar y apuestas', '2', '18');
INSERT INTO `cnt_ciiu` VALUES ('328', '931', 'Actividades deportivas', '2', '18');
INSERT INTO `cnt_ciiu` VALUES ('329', '932', 'Otras actividades recreativas y de esparcimiento', '2', '18');
INSERT INTO `cnt_ciiu` VALUES ('330', '941', 'Actividades de asociaciones empresariales y de empleadores, y asociaciones profesionales', '2', '19');
INSERT INTO `cnt_ciiu` VALUES ('331', '942', 'Actividades de sindicatos de empleados', '2', '19');
INSERT INTO `cnt_ciiu` VALUES ('332', '949', 'Actividades de otras asociaciones', '2', '19');
INSERT INTO `cnt_ciiu` VALUES ('333', '951', 'Mantenimiento y reparación de computadores y equipo de comunicaciones', '2', '19');
INSERT INTO `cnt_ciiu` VALUES ('334', '952', 'Mantenimiento y reparación de efectos personales y enseres domésticos', '2', '19');
INSERT INTO `cnt_ciiu` VALUES ('335', '960', 'Otras actividades de servicios personales', '2', '19');
INSERT INTO `cnt_ciiu` VALUES ('336', '970', 'Actividades de los hogares individuales como empleadores de personal doméstico', '2', '20');
INSERT INTO `cnt_ciiu` VALUES ('337', '981', 'Actividades no diferenciadas de los hogares individuales como productores de bienes para uso propio', '2', '20');
INSERT INTO `cnt_ciiu` VALUES ('338', '982', 'Actividades no diferenciadas de los hogares individuales como productores de servicios para uso propio', '2', '20');
INSERT INTO `cnt_ciiu` VALUES ('339', '990', 'Actividades de organizaciones y entidades extraterritoriales', '2', '21');
INSERT INTO `cnt_ciiu` VALUES ('343', '0111', 'Cultivo de cereales (excepto arroz), legumbres y semillas oleaginosas ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('344', '0112', 'Cultivo de arroz ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('345', '0113', 'Cultivo de hortalizas, raíces y tubérculos ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('346', '0114', 'Cultivo de tabaco ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('347', '0115', 'Cultivo de plantas textiles ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('348', '0119', 'Otros cultivos transitorios n.c.p.', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('349', '0121', 'Cultivo de frutas tropicales y subtropicales', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('350', '0122', 'Cultivo de plátano y banano', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('351', '0123', 'Cultivo de café', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('352', '0124', 'Cultivo de caña de azúcar', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('353', '0125', 'Cultivo de flor de corte', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('354', '0126', 'Cultivo de palma para aceite (palma africana) y otros frutos oleaginosos', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('355', '0127', 'Cultivo de plantas con las que se preparan bebidas', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('356', '0128', 'Cultivo de especias y de plantas aromáticas y medicinales ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('357', '0129', 'Otros cultivos permanentes n.c.p.', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('358', '0130', 'Propagación de plantas (actividades de los viveros, excepto viveros forestales) ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('359', '0141', 'Cría de ganado bovino y bufalino', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('360', '0142', 'Cría de caballos y otros equinos ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('361', '0143', 'Cría de ovejas y cabras ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('362', '0144', 'Cría de ganado porcino', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('363', '0145', 'Cría de aves de corral', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('364', '0149', 'Cría de otros animales n.c.p.', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('365', '0150', 'Explotación mixta (agrícola y pecuaria) ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('366', '0161', 'Actividades de apoyo a la agricultura ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('367', '0162', 'Actividades de apoyo a la ganadería', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('368', '0163', 'Actividades posteriores a la cosecha ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('369', '0164', 'Tratamiento de semillas para propagación ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('370', '0170', 'Caza ordinaria y mediante trampas y actividades de servicios conexas ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('371', '0210', 'Silvicultura y otras actividades forestales', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('372', '0220', 'Extracción de madera ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('373', '0230', 'Recolección de productos forestales diferentes a la madera', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('374', '0240', 'Servicios de apoyo a la silvicultura ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('375', '0311', 'Pesca marítima ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('376', '0312', 'Pesca de agua dulce ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('377', '0321', 'Acuicultura marítima ', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('378', '0322', 'Acuicultura de agua dulce', '3', '1');
INSERT INTO `cnt_ciiu` VALUES ('379', '0510', 'Extracción de hulla (carbón de piedra)', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('380', '0520', 'Extracción de carbón lignito', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('381', '0610', 'Extracción de petróleo crudo', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('382', '0620', 'Extracción de gas natural', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('383', '0710', 'Extracción de minerales de hierro', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('384', '0721', 'Extracción de minerales de uranio y de torio', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('385', '0722', 'Extracción de oro y otros metales preciosos', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('386', '0723', 'Extracción de minerales de níquel', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('387', '0729', 'Extracción de otros minerales metalíferos no ferrosos n.c.p.', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('388', '0811', 'Extracción de piedra, arena, arcillas comunes, yeso y anhidrita', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('389', '0812', 'Extracción de arcillas de uso industrial, caliza, caolín y bentonitas', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('390', '0820', 'Extracción de esmeraldas, piedras preciosas y semipreciosas', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('391', '0891', 'Extracción de minerales para la fabricación de abonos y productos químicos', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('392', '0892', 'Extracción de halita (sal)', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('393', '0899', 'Extracción de otros minerales no metálicos n.c.p.', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('394', '0910', 'Actividades de apoyo para la extracción de petróleo y de gas natural', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('395', '0990', 'Actividades de apoyo para otras actividades de explotación de minas y canteras', '3', '2');
INSERT INTO `cnt_ciiu` VALUES ('396', '1011', 'Procesamiento y conservación de carne y productos cárnicos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('397', '1012', 'Procesamiento y conservación de pescados, crustáceos y moluscos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('398', '1020', 'Procesamiento y conservación de frutas, legumbres, hortalizas y tubérculos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('399', '1030', 'Elaboración de aceites y grasas de origen vegetal y animal', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('400', '1040', 'Elaboración de productos lácteos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('401', '1051', 'Elaboración de productos de molinería', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('402', '1052', 'Elaboración de almidones y productos derivados del almidón', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('403', '1061', 'Trilla de café', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('404', '1062', 'Descafeinado, tostión y molienda del café', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('405', '1063', 'Otros derivados del café', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('406', '1071', 'Elaboración y refinación de azúcar', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('407', '1072', 'Elaboración de panela', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('408', '1081', 'Elaboración de productos de panadería', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('409', '1082', 'Elaboración de cacao, chocolate y productos de confitería', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('410', '1083', 'Elaboración de macarrones, fideos, alcuzcuz y productos farináceos similares', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('411', '1084', 'Elaboración de comidas y platos preparados', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('412', '1089', 'Elaboración de otros productos alimenticios n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('413', '1090', 'Elaboración de alimentos preparados para animales', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('414', '1101', 'Destilación, rectificación y mezcla de bebidas alcohólicas', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('415', '1102', 'Elaboración de bebidas fermentadas no destiladas', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('416', '1103', 'Producción de malta, elaboración de cervezas y otras bebidas malteadas', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('417', '1104', 'Elaboración de bebidas no alcohólicas, producción de aguas minerales y de otras aguas embotelladas', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('418', '1200', 'Elaboración de productos de tabaco', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('419', '1311', 'Preparación e hilatura de fibras textiles', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('420', '1312', 'Tejeduría de productos textiles', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('421', '1313', 'Acabado de productos textiles', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('422', '1391', 'Fabricación de tejidos de punto y ganchillo', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('423', '1392', 'Confección de artículos con materiales textiles, excepto prendas de vestir', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('424', '1393', 'Fabricación de tapetes y alfombras para pisos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('425', '1394', 'Fabricación de cuerdas, cordeles, cables, bramantes y redes', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('426', '1399', 'Fabricación de otros artículos textiles n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('427', '1410', 'Confección de prendas de vestir, excepto prendas de piel', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('428', '1420', 'Fabricación de artículos de piel', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('429', '1430', 'Fabricación de artículos de punto y ganchillo', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('430', '1511', 'Curtido y recurtido de cueros; recurtido y teñido de pieles', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('431', '1512', 'Fabricación de artículos de viaje, bolsos de mano y artículos similares elaborados en cuero, y fabricación de artículos de talabartería y guarnicionería', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('432', '1513', 'Fabricación de artículos de viaje, bolsos de mano y artículos similares; artículos de talabartería y guarnicionería elaborados en otros materiales', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('433', '1521', 'Fabricación de calzado de cuero y piel, con cualquier tipo de suela', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('434', '1522', 'Fabricación de otros tipos de calzado, excepto calzado de cuero y piel', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('435', '1523', 'Fabricación de partes del calzado', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('436', '1610', 'Aserrado, acepillado e impregnación de la madera', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('437', '1620', 'Fabricación de hojas de madera para enchapado; fabricación de tableros contrachapados, tableros laminados, tableros de partículas y otros tableros y paneles', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('438', '1630', 'Fabricación de partes y piezas de madera, de carpintería y ebanistería para la construcción', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('439', '1640', 'Fabricación de recipientes de madera', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('440', '1690', 'Fabricación de otros productos de madera; fabricación de artículos de corcho, cestería y espartería', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('441', '1701', 'Fabricación de pulpas (pastas) celulósicas; papel y cartón', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('442', '1702', 'Fabricación de papel y cartón ondulado (corrugado); fabricación de envases, empaques y de embalajes de papel y cartón.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('443', '1709', 'Fabricación de otros artículos de papel y cartón', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('444', '1811', 'Actividades de impresión', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('445', '1812', 'Actividades de servicios relacionados con la impresión', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('446', '1820', 'Producción de copias a partir de grabaciones originales ', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('447', '1910', 'Fabricación de productos de hornos de coque', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('448', '1921', 'Fabricación de productos de la refinación del petróleo', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('449', '1922', 'Actividad de mezcla de combustibles', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('450', '2011', 'Fabricación de sustancias y productos químicos básicos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('451', '2012', 'Fabricación de abonos y compuestos inorgánicos nitrogenados', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('452', '2013', 'Fabricación de plásticos en formas primarias', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('453', '2014', 'Fabricación de caucho sintético en formas primarias', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('454', '2021', 'Fabricación de plaguicidas y otros productos químicos de uso agropecuario', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('455', '2022', 'Fabricación de pinturas, barnices y revestimientos similares, tintas para impresión y masillas', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('456', '2023', 'Fabricación de jabones y detergentes, preparados para limpiar y pulir; perfumes y preparados de tocador', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('457', '2029', 'Fabricación de otros productos químicos n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('458', '2030', 'Fabricación de fibras sintéticas y artificiales', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('459', '2100', 'Fabricación de productos farmacéuticos, sustancias químicas medicinales y productos botánicos de uso farmacéutico', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('460', '2211', 'Fabricación de llantas y neumáticos de caucho', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('461', '2212', 'Reencauche de llantas usadas', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('462', '2219', 'Fabricación de formas básicas de caucho y otros productos de caucho n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('463', '2221', 'Fabricación de formas básicas de plástico', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('464', '2229', 'Fabricación de artículos de plástico n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('465', '2310', 'Fabricación de vidrio y productos de vidrio', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('466', '2391', 'Fabricación de productos refractarios', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('467', '2392', 'Fabricación de materiales de arcilla para la construcción', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('468', '2393', 'Fabricación de otros productos de cerámica y porcelana', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('469', '2394', 'Fabricación de cemento, cal y yeso', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('470', '2395', 'Fabricación de artículos de hormigón, cemento y yeso', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('471', '2396', 'Corte, tallado y acabado de la piedra', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('472', '2399', 'Fabricación de otros productos minerales no metálicos n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('473', '2410', 'Industrias básicas de hierro y de acero', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('474', '2421', 'Industrias básicas de metales preciosos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('475', '2429', 'Industrias básicas de otros metales no ferrosos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('476', '2431', 'Fundición de hierro y de acero', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('477', '2432', 'Fundición de metales no ferrosos ', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('478', '2511', 'Fabricación de productos metálicos para uso estructural', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('479', '2512', 'Fabricación de tanques, depósitos y recipientes de metal, excepto los utilizados para el envase o transporte de mercancías', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('480', '2513', 'Fabricación de generadores de vapor, excepto calderas de agua caliente para calefacción central', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('481', '2520', 'Fabricación de armas y municiones', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('482', '2591', 'Forja, prensado, estampado y laminado de metal; pulvimetalurgia', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('483', '2592', 'Tratamiento y revestimiento de metales; mecanizado', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('484', '2593', 'Fabricación de artículos de cuchillería, herramientas de mano y artículos de ferretería', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('485', '2599', 'Fabricación de otros productos elaborados de metal n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('486', '2610', 'Fabricación de componentes y tableros electrónicos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('487', '2620', 'Fabricación de computadoras y de equipo periférico', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('488', '2630', 'Fabricación de equipos de comunicación', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('489', '2640', 'Fabricación de aparatos electrónicos de consumo', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('490', '2651', 'Fabricación de equipo de medición, prueba, navegación y control', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('491', '2652', 'Fabricación de relojes', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('492', '2660', 'Fabricación de equipo de irradiación y equipo electrónico de uso médico y terapéutico', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('493', '2670', 'Fabricación de instrumentos ópticos y equipo fotográfico', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('494', '2680', 'Fabricación de medios magnéticos y ópticos para almacenamiento de datos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('495', '2711', 'Fabricación de motores, generadores y transformadores eléctricos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('496', '2712', 'Fabricación de aparatos de distribución y control de la energía eléctrica', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('497', '2720', 'Fabricación de pilas, baterías y acumuladores eléctricos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('498', '2731', 'Fabricación de hilos y cables eléctricos y de fibra óptica', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('499', '2732', 'Fabricación de dispositivos de cableado', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('500', '2740', 'Fabricación de equipos eléctricos de iluminación', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('501', '2750', 'Fabricación de aparatos de uso doméstico', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('502', '2790', 'Fabricación de otros tipos de equipo eléctrico n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('503', '2811', 'Fabricación de motores, turbinas, y partes para motores de combustión interna', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('504', '2812', 'Fabricación de equipos de potencia hidráulica y neumática', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('505', '2813', 'Fabricación de otras bombas, compresores, grifos y válvulas', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('506', '2814', 'Fabricación de cojinetes, engranajes, trenes de engranajes y piezas de transmisión', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('507', '2815', 'Fabricación de hornos, hogares y quemadores industriales', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('508', '2816', 'Fabricación de equipo de elevación y manipulación', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('509', '2817', 'Fabricación de maquinaria y equipo de oficina (excepto computadoras y equipo periférico)', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('510', '2818', 'Fabricación de herramientas manuales con motor', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('511', '2819', 'Fabricación de otros tipos de maquinaria y equipo de uso general n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('512', '2821', 'Fabricación de maquinaria agropecuaria y forestal', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('513', '2822', 'Fabricación de máquinas formadoras de metal y de máquinas herramienta', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('514', '2823', 'Fabricación de maquinaria para la metalurgia', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('515', '2824', 'Fabricación de maquinaria para explotación de minas y canteras y para obras de construcción', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('516', '2825', 'Fabricación de maquinaria para la elaboración de alimentos, bebidas y tabaco', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('517', '2826', 'Fabricación de maquinaria para la elaboración de productos textiles, prendas de vestir y cueros', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('518', '2829', 'Fabricación de otros tipos de maquinaria y equipo de uso especial n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('519', '2910', 'Fabricación de vehículos automotores y sus motores', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('520', '2920', 'Fabricación de carrocerías para vehículos automotores; fabricación de remolques y semirremolques ', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('521', '2930', 'Fabricación de partes, piezas (autopartes) y accesorios (lujos) para vehículos automotores', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('522', '3011', 'Construcción de barcos y de estructuras flotantes', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('523', '3012', 'Construcción de embarcaciones de recreo y deporte', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('524', '3020', 'Fabricación de locomotoras y de material rodante para ferrocarriles', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('525', '3030', 'Fabricación de aeronaves, naves espaciales y de maquinaria conexa', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('526', '3040', 'Fabricación de vehículos militares de combate', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('527', '3091', 'Fabricación de motocicletas', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('528', '3092', 'Fabricación de bicicletas y de sillas de ruedas para personas con discapacidad', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('529', '3099', 'Fabricación de otros tipos de equipo de transporte n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('530', '3110', 'Fabricación de muebles ', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('531', '3120', 'Fabricación de colchones y somieres', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('532', '3210', 'Fabricación de joyas, bisutería y artículos conexos', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('533', '3220', 'Fabricación de instrumentos musicales', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('534', '3230', 'Fabricación de artículos y equipo para la práctica del deporte', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('535', '3240', 'Fabricación de juegos, juguetes y rompecabezas', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('536', '3250', 'Fabricación de instrumentos, aparatos y materiales médicos y odontológicos (incluido mobiliario)', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('537', '3290', 'Otras industrias manufactureras n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('538', '3311', 'Mantenimiento y reparación especializado de productos elaborados en metal', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('539', '3312', 'Mantenimiento y reparación especializado de maquinaria y equipo', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('540', '3313', 'Mantenimiento y reparación especializado de equipo electrónico y óptico', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('541', '3314', 'Mantenimiento y reparación especializado de equipo eléctrico', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('542', '3315', 'Mantenimiento y reparación especializado de equipo de transporte, excepto los vehículos automotores, motocicletas y bicicletas', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('543', '3319', 'Mantenimiento y reparación de otros tipos de equipos y sus componentes n.c.p.', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('544', '3320', 'Instalación especializada de maquinaria y equipo industrial ', '3', '3');
INSERT INTO `cnt_ciiu` VALUES ('545', '3511', 'Generación de energía eléctrica', '3', '4');
INSERT INTO `cnt_ciiu` VALUES ('546', '3512', 'Transmisión de energía eléctrica', '3', '4');
INSERT INTO `cnt_ciiu` VALUES ('547', '3513', 'Distribución de energía eléctrica', '3', '4');
INSERT INTO `cnt_ciiu` VALUES ('548', '3514', 'Comercialización de energía eléctrica', '3', '4');
INSERT INTO `cnt_ciiu` VALUES ('549', '3520', 'Producción de gas; distribución de combustibles gaseosos por tuberías', '3', '4');
INSERT INTO `cnt_ciiu` VALUES ('550', '3530', 'Suministro de vapor y aire acondicionado', '3', '4');
INSERT INTO `cnt_ciiu` VALUES ('551', '3600', 'Captación, tratamiento y distribución de agua', '3', '5');
INSERT INTO `cnt_ciiu` VALUES ('552', '3700', 'Evacuación y tratamiento de aguas residuales', '3', '5');
INSERT INTO `cnt_ciiu` VALUES ('553', '3811', 'Recolección de desechos no peligrosos', '3', '5');
INSERT INTO `cnt_ciiu` VALUES ('554', '3812', 'Recolección de desechos peligrosos', '3', '5');
INSERT INTO `cnt_ciiu` VALUES ('555', '3821', 'Tratamiento y disposición de desechos no peligrosos', '3', '5');
INSERT INTO `cnt_ciiu` VALUES ('556', '3822', 'Tratamiento y disposición de desechos peligrosos', '3', '5');
INSERT INTO `cnt_ciiu` VALUES ('557', '3830', 'Recuperación de materiales', '3', '5');
INSERT INTO `cnt_ciiu` VALUES ('558', '3900', 'Actividades de saneamiento ambiental y otros servicios de gestión de desechos', '3', '5');
INSERT INTO `cnt_ciiu` VALUES ('559', '4111', 'Construcción de edificios residenciales', '3', '6');
INSERT INTO `cnt_ciiu` VALUES ('560', '4112', 'Construcción de edificios no residenciales', '3', '6');
INSERT INTO `cnt_ciiu` VALUES ('561', '4210', 'Construcción de carreteras y vías de ferrocarril', '3', '6');
INSERT INTO `cnt_ciiu` VALUES ('562', '4220', 'Construcción de proyectos de servicio público', '3', '6');
INSERT INTO `cnt_ciiu` VALUES ('563', '4290', 'Construcción de otras obras de ingeniería civil', '3', '6');
INSERT INTO `cnt_ciiu` VALUES ('564', '4311', 'Demolición', '3', '6');
INSERT INTO `cnt_ciiu` VALUES ('565', '4312', 'Preparación del terreno', '3', '6');
INSERT INTO `cnt_ciiu` VALUES ('566', '4321', 'Instalaciones eléctricas', '3', '6');
INSERT INTO `cnt_ciiu` VALUES ('567', '4322', 'Instalaciones de fontanería, calefacción y aire acondicionado', '3', '6');
INSERT INTO `cnt_ciiu` VALUES ('568', '4329', 'Otras instalaciones especializadas', '3', '6');
INSERT INTO `cnt_ciiu` VALUES ('569', '4330', 'Terminación y acabado de edificios y obras de ingeniería civil', '3', '6');
INSERT INTO `cnt_ciiu` VALUES ('570', '4390', 'Otras actividades especializadas para la construcción de edificios y obras de ingeniería civil', '3', '6');
INSERT INTO `cnt_ciiu` VALUES ('571', '4511', 'Comercio de vehículos automotores nuevos', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('572', '4512', 'Comercio de vehículos automotores usados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('573', '4520', 'Mantenimiento y reparación de vehículos automotores', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('574', '4530', 'Comercio de partes, piezas (autopartes) y accesorios (lujos) para vehículos automotores', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('575', '4541', 'Comercio de motocicletas y de sus partes, piezas y accesorios', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('576', '4542', 'Mantenimiento y reparación de motocicletas y de sus partes y piezas', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('577', '4610', 'Comercio al por mayor a cambio de una retribución o por contrata', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('578', '4620', 'Comercio al por mayor de materias primas agropecuarias; animales vivos', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('579', '4631', 'Comercio al por mayor de productos alimenticios', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('580', '4632', 'Comercio al por mayor de bebidas y tabaco', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('581', '4641', 'Comercio al por mayor de productos textiles, productos confeccionados para uso doméstico', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('582', '4642', 'Comercio al por mayor de prendas de vestir', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('583', '4643', 'Comercio al por mayor de calzado', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('584', '4644', 'Comercio al por mayor de aparatos y equipo de uso doméstico', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('585', '4645', 'Comercio al por mayor de productos farmacéuticos, medicinales, cosméticos y de tocador', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('586', '4649', 'Comercio al por mayor de otros utensilios domésticos n.c.p.', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('587', '4651', 'Comercio al por mayor de computadores, equipo periférico y programas de informática', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('588', '4652', 'Comercio al por mayor de equipo, partes y piezas electrónicos y de telecomunicaciones', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('589', '4653', 'Comercio al por mayor de maquinaria y equipo agropecuarios', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('590', '4659', 'Comercio al por mayor de otros tipos de maquinaria y equipo n.c.p.', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('591', '4661', 'Comercio al por mayor de combustibles sólidos, líquidos, gaseosos y productos conexos', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('592', '4662', 'Comercio al por mayor de metales y productos metalíferos', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('593', '4663', 'Comercio al por mayor de materiales de construcción, artículos de ferretería, pinturas, productos de vidrio, equipo y materiales de fontanería y calefacción', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('594', '4664', 'Comercio al por mayor de productos químicos básicos, cauchos y plásticos en formas primarias y productos químicos de uso agropecuario', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('595', '4665', 'Comercio al por mayor de desperdicios, desechos y chatarra', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('596', '4669', 'Comercio al por mayor de otros productos n.c.p.', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('597', '4690', 'Comercio al por mayor no especializado', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('598', '4711', 'Comercio al por menor en establecimientos no especializados con surtido compuesto principalmente por alimentos, bebidas o tabaco', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('599', '4719', 'Comercio al por menor en establecimientos no especializados, con surtido compuesto principalmente por productos diferentes de alimentos (víveres en general), bebidas y tabaco', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('600', '4721', 'Comercio al por menor de productos agrícolas para el consumo en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('601', '4722', 'Comercio al por menor de leche, productos lácteos y huevos, en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('602', '4723', 'Comercio al por menor de carnes (incluye aves de corral), productos cárnicos, pescados y productos de mar, en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('603', '4724', 'Comercio al por menor de bebidas y productos del tabaco, en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('604', '4729', 'Comercio al por menor de otros productos alimenticios n.c.p., en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('605', '4731', 'Comercio al por menor de combustible para automotores', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('606', '4732', 'Comercio al por menor de lubricantes (aceites, grasas), aditivos y productos de limpieza para vehículos automotores', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('607', '4741', 'Comercio al por menor de computadores, equipos periféricos, programas de informática y equipos de telecomunicaciones en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('608', '4742', 'Comercio al por menor de equipos y aparatos de sonido y de video, en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('609', '4751', 'Comercio al por menor de productos textiles en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('610', '4752', 'Comercio al por menor de artículos de ferretería, pinturas y productos de vidrio en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('611', '4753', 'Comercio al por menor de tapices, alfombras y cubrimientos para paredes y pisos en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('612', '4754', 'Comercio al por menor de electrodomésticos y gasodomésticos de uso doméstico, muebles y equipos de iluminación', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('613', '4755', 'Comercio al por menor de artículos y utensilios de uso doméstico', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('614', '4759', 'Comercio al por menor de otros artículos domésticos en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('615', '4761', 'Comercio al por menor de libros, periódicos, materiales y artículos de papelería y escritorio, en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('616', '4762', 'Comercio al por menor de artículos deportivos, en establecimientos especializados ', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('617', '4769', 'Comercio al por menor de otros artículos culturales y de entretenimiento n.c.p. en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('618', '4771', 'Comercio al por menor de prendas de vestir y sus accesorios (incluye artículos de piel) en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('619', '4772', 'Comercio al por menor de todo tipo de calzado y artículos de cuero y sucedáneos del cuero en establecimientos especializados.', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('620', '4773', 'Comercio al por menor de productos farmacéuticos y medicinales, cosméticos y artículos de tocador en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('621', '4774', 'Comercio al por menor de otros productos nuevos en establecimientos especializados', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('622', '4775', 'Comercio al por menor de artículos de segunda mano', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('623', '4781', 'Comercio al por menor de alimentos, bebidas y tabaco, en puestos de venta móviles', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('624', '4782', 'Comercio al por menor de productos textiles, prendas de vestir y calzado, en puestos de venta móviles', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('625', '4789', 'Comercio al por menor de otros productos en puestos de venta móviles', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('626', '4791', 'Comercio al por menor realizado a través de Internet', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('627', '4792', 'Comercio al por menor realizado a través de casas de venta o por correo', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('628', '4799', 'Otros tipos de comercio al por menor no realizado en establecimientos, puestos de venta o mercados.', '3', '7');
INSERT INTO `cnt_ciiu` VALUES ('629', '4911', 'Transporte férreo de pasajeros', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('630', '4912', 'Transporte férreo de carga ', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('631', '4921', 'Transporte de pasajeros', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('632', '4922', 'Transporte mixto', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('633', '4923', 'Transporte de carga por carretera', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('634', '4930', 'Transporte por tuberías', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('635', '5011', 'Transporte de pasajeros marítimo y de cabotaje ', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('636', '5012', 'Transporte de carga marítimo y de cabotaje ', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('637', '5021', 'Transporte fluvial de pasajeros', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('638', '5022', 'Transporte fluvial de carga', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('639', '5111', 'Transporte aéreo nacional de pasajeros ', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('640', '5112', 'Transporte aéreo internacional de pasajeros ', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('641', '5121', 'Transporte aéreo nacional de carga ', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('642', '5122', 'Transporte aéreo internacional de carga ', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('643', '5210', 'Almacenamiento y depósito', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('644', '5221', 'Actividades de estaciones, vías y servicios complementarios para el transporte terrestre', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('645', '5222', 'Actividades de puertos y servicios complementarios para el transporte acuático', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('646', '5223', 'Actividades de aeropuertos, servicios de navegación aérea y demás actividades conexas al transporte aéreo', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('647', '5224', 'Manipulación de carga', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('648', '5229', 'Otras actividades complementarias al transporte', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('649', '5310', 'Actividades postales nacionales', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('650', '5320', 'Actividades de mensajería', '3', '8');
INSERT INTO `cnt_ciiu` VALUES ('651', '5511', 'Alojamiento en hoteles ', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('652', '5512', 'Alojamiento en apartahoteles', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('653', '5513', 'Alojamiento en centros vacacionales ', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('654', '5514', 'Alojamiento rural', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('655', '5519', 'Otros tipos de alojamientos para visitantes', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('656', '5520', 'Actividades de zonas de camping y parques para vehículos recreacionales', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('657', '5530', 'Servicio por horas ', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('658', '5590', 'Otros tipos de alojamiento n.c.p.', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('659', '5611', 'Expendio a la mesa de comidas preparadas', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('660', '5612', 'Expendio por autoservicio de comidas preparadas', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('661', '5613', 'Expendio de comidas preparadas en cafeterías', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('662', '5619', 'Otros tipos de expendio de comidas preparadas n.c.p.', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('663', '5621', 'Catering para eventos', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('664', '5629', 'Actividades de otros servicios de comidas', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('665', '5630', 'Expendio de bebidas alcohólicas para el consumo dentro del establecimiento', '3', '9');
INSERT INTO `cnt_ciiu` VALUES ('666', '5811', 'Edición de libros', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('667', '5812', 'Edición de directorios y listas de correo', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('668', '5813', 'Edición de periódicos, revistas y otras publicaciones periódicas', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('669', '5819', 'Otros trabajos de edición', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('670', '5820', 'Edición de programas de informática (software)', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('671', '5911', 'Actividades de producción de películas cinematográficas, videos, programas, anuncios y comerciales de televisión', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('672', '5912', 'Actividades de posproducción de películas cinematográficas, videos, programas, anuncios y comerciales de televisión', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('673', '5913', 'Actividades de distribución de películas cinematográficas, videos, programas, anuncios y comerciales de televisión', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('674', '5914', 'Actividades de exhibición de películas cinematográficas y videos', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('675', '5920', 'Actividades de grabación de sonido y edición de música', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('676', '6010', 'Actividades de programación y transmisión en el servicio de radiodifusión sonora', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('677', '6020', 'Actividades de programación y transmisión de televisión', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('678', '6110', 'Actividades de telecomunicaciones alámbricas', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('679', '6120', 'Actividades de telecomunicaciones inalámbricas', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('680', '6130', 'Actividades de telecomunicación satelital', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('681', '6190', 'Otras actividades de telecomunicaciones', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('682', '6201', 'Actividades de desarrollo de sistemas informáticos (planificación, análisis, diseño, programación, pruebas)', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('683', '6202', 'Actividades de consultoría informática y actividades de administración de instalaciones informáticas', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('684', '6209', 'Otras actividades de tecnologías de información y actividades de servicios informáticos', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('685', '6311', 'Procesamiento de datos, alojamiento (hosting) y actividades relacionadas', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('686', '6312', 'Portales web', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('687', '6391', 'Actividades de agencias de noticias', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('688', '6399', 'Otras actividades de servicio de información n.c.p.', '3', '10');
INSERT INTO `cnt_ciiu` VALUES ('689', '6411', 'Banco Central', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('690', '6412', 'Bancos comerciales', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('691', '6421', 'Actividades de las corporaciones financieras', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('692', '6422', 'Actividades de las compañías de financiamiento', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('693', '6423', 'Banca de segundo piso', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('694', '6424', 'Actividades de las cooperativas financieras', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('695', '6431', 'Fideicomisos, fondos y entidades financieras similares', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('696', '6432', 'Fondos de cesantías', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('697', '6491', 'Leasing financiero (arrendamiento financiero)', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('698', '6492', 'Actividades financieras de fondos de empleados y otras formas asociativas del sector solidario', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('699', '6493', 'Actividades de compra de cartera o factoring', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('700', '6494', 'Otras actividades de distribución de fondos', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('701', '6495', 'Instituciones especiales oficiales', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('702', '6496', 'Capitalización', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('703', '6499', 'Otras actividades de servicio financiero, excepto las de seguros y pensiones n.c.p.', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('704', '6511', 'Seguros generales ', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('705', '6512', 'Seguros de vida', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('706', '6513', 'Reaseguros', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('707', '6515', 'Seguros de salud', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('708', '6521', 'Servicios de seguros sociales de salud', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('709', '6522', 'Servicios de seguros sociales de riesgos laborales', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('710', '6523', 'Servicios de seguros sociales en riesgos de familia', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('711', '6531', 'Régimen de prima media con prestación definida (RPM)', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('712', '6532', 'Régimen de ahorro con solidaridad (RAIS).', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('713', '6611', 'Administración de mercados financieros', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('714', '6612', 'Corretaje de valores y de contratos de productos básicos', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('715', '6613', 'Otras actividades relacionadas con el mercado de valores', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('716', '6614', 'Actividades de las sociedades de intermediación cambiaria y de servicios financieros especiales', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('717', '6615', 'Actividades de los profesionales de compra y venta de divisas', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('718', '6619', 'Otras actividades auxiliares de las actividades de servicios financieros n.c.p.', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('719', '6621', 'Actividades de agentes y corredores de seguros', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('720', '6629', 'Evaluación de riesgos y daños, y otras actividades de servicios auxiliares', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('721', '6630', 'Actividades de administración de fondos', '3', '11');
INSERT INTO `cnt_ciiu` VALUES ('722', '6810', 'Actividades inmobiliarias realizadas con bienes propios o arrendados', '3', '12');
INSERT INTO `cnt_ciiu` VALUES ('723', '6820', 'Actividades inmobiliarias realizadas a cambio de una retribución o por contrata', '3', '12');
INSERT INTO `cnt_ciiu` VALUES ('724', '6910', 'Actividades jurídicas', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('725', '6920', 'Actividades de contabilidad, teneduría de libros, auditoría financiera y asesoría tributaria', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('726', '7010', 'Actividades de administración empresarial', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('727', '7020', 'Actividades de consultoría de gestión', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('728', '7111', 'Actividades de arquitectura', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('729', '7112', 'Actividades de ingeniería y otras actividades conexas de consultoría técnica', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('730', '7120', 'Ensayos y análisis técnicos', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('731', '7210', 'Investigaciones y desarrollo experimental en el campo de las ciencias naturales y la ingeniería ', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('732', '7220', 'Investigaciones y desarrollo experimental en el campo de las ciencias sociales y las humanidades', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('733', '7310', 'Publicidad', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('734', '7320', 'Estudios de mercado y realización de encuestas de opinión pública', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('735', '7410', 'Actividades especializadas de diseño ', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('736', '7420', 'Actividades de fotografía', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('737', '7490', 'Otras actividades profesionales, científicas y técnicas n.c.p.', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('738', '7500', 'Actividades veterinarias', '3', '13');
INSERT INTO `cnt_ciiu` VALUES ('739', '7710', 'Alquiler y arrendamiento de vehículos automotores', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('740', '7721', 'Alquiler y arrendamiento de equipo recreativo y deportivo', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('741', '7722', 'Alquiler de videos y discos ', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('742', '7729', 'Alquiler y arrendamiento de otros efectos personales y enseres domésticos n.c.p.', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('743', '7730', 'Alquiler y arrendamiento de otros tipos de maquinaria, equipo y bienes tangibles n.c.p.', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('744', '7740', 'Arrendamiento de propiedad intelectual y productos similares, excepto obras protegidas por derechos de autor', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('745', '7810', 'Actividades de agencias de gestión y colocación de empleo', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('746', '7820', 'Actividades de empresas de servicios temporales', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('747', '7830', 'Otras actividades de provisión de talento humano', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('748', '7911', 'Actividades de las agencias de viaje', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('749', '7912', 'Actividades de operadores turísticos', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('750', '7990', 'Otros servicios de reserva y actividades relacionadas', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('751', '8010', 'Actividades de seguridad privada', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('752', '8020', 'Actividades de servicios de sistemas de seguridad', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('753', '8030', 'Actividades de detectives e investigadores privados', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('754', '8110', 'Actividades combinadas de apoyo a instalaciones', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('755', '8121', 'Limpieza general interior de edificios', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('756', '8129', 'Otras actividades de limpieza de edificios e instalaciones industriales', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('757', '8130', 'Actividades de paisajismo y servicios de mantenimiento conexos', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('758', '8211', 'Actividades combinadas de servicios administrativos de oficina', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('759', '8219', 'Fotocopiado, preparación de documentos y otras actividades especializadas de apoyo a oficina', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('760', '8220', 'Actividades de centros de llamadas (Call center)', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('761', '8230', 'Organización de convenciones y eventos comerciales', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('762', '8291', 'Actividades de agencias de cobranza y oficinas de calificación crediticia', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('763', '8292', 'Actividades de envase y empaque', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('764', '8299', 'Otras actividades de servicio de apoyo a las empresas n.c.p.', '3', '14');
INSERT INTO `cnt_ciiu` VALUES ('765', '8411', 'Actividades legislativas de la administración pública', '3', '15');
INSERT INTO `cnt_ciiu` VALUES ('766', '8412', 'Actividades ejecutivas de la administración pública', '3', '15');
INSERT INTO `cnt_ciiu` VALUES ('767', '8413', 'Regulación de las actividades de organismos que prestan servicios de salud, educativos, culturales y otros servicios sociales, excepto servicios de seguridad social ', '3', '15');
INSERT INTO `cnt_ciiu` VALUES ('768', '8414', 'Actividades reguladoras y facilitadoras de la actividad económica', '3', '15');
INSERT INTO `cnt_ciiu` VALUES ('769', '8415', 'Actividades de los otros órganos de control y otras instituciones', '3', '15');
INSERT INTO `cnt_ciiu` VALUES ('770', '8421', 'Relaciones exteriores ', '3', '15');
INSERT INTO `cnt_ciiu` VALUES ('771', '8422', 'Actividades de defensa', '3', '15');
INSERT INTO `cnt_ciiu` VALUES ('772', '8423', 'Orden público y actividades de seguridad', '3', '15');
INSERT INTO `cnt_ciiu` VALUES ('773', '8424', 'Administración de justicia', '3', '15');
INSERT INTO `cnt_ciiu` VALUES ('774', '8430', 'Actividades de planes de seguridad social de afiliación obligatoria', '3', '15');
INSERT INTO `cnt_ciiu` VALUES ('775', '8511', 'Educación de la primera infancia', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('776', '8512', 'Educación preescolar', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('777', '8513', 'Educación básica primaria', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('778', '8521', 'Educación básica secundaria ', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('779', '8522', 'Educación media académica', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('780', '8523', 'Educación media técnica ', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('781', '8530', 'Establecimientos que combinan diferentes niveles de educación ', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('782', '8541', 'Educación técnica profesional', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('783', '8542', 'Educación tecnológica', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('784', '8543', 'Educación de instituciones universitarias o de escuelas tecnológicas', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('785', '8544', 'Educación de universidades', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('786', '8551', 'Formación para el trabajo', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('787', '8552', 'Enseñanza deportiva y recreativa', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('788', '8553', 'Enseñanza cultural', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('789', '8559', 'Otros tipos de educación n.c.p.', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('790', '8560', 'Actividades de apoyo a la educación', '3', '16');
INSERT INTO `cnt_ciiu` VALUES ('791', '8610', 'Actividades de hospitales y clínicas, con internación', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('792', '8621', 'Actividades de la práctica médica, sin internación', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('793', '8622', 'Actividades de la práctica odontológica', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('794', '8691', 'Actividades de apoyo diagnóstico', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('795', '8692', 'Actividades de apoyo terapéutico', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('796', '8699', 'Otras actividades de atención de la salud humana', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('797', '8710', 'Actividades de atención residencial medicalizada de tipo general', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('798', '8720', 'Actividades de atención residencial, para el cuidado de pacientes con retardo mental, enfermedad mental y consumo de sustancias psicoactivas', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('799', '8730', 'Actividades de atención en instituciones para el cuidado de personas mayores y/o discapacitadas', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('800', '8790', 'Otras actividades de atención en instituciones con alojamiento', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('801', '8810', 'Actividades de asistencia social sin alojamiento para personas mayores y discapacitadas', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('802', '8891', 'Actividades de guarderías para niños y niñas', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('803', '8899', 'Otras actividades de asistencia social n.c.p.', '3', '17');
INSERT INTO `cnt_ciiu` VALUES ('804', '9001', 'Creación literaria', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('805', '9002', 'Creación musical', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('806', '9003', 'Creación teatral', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('807', '9004', 'Creación audiovisual', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('808', '9005', 'Artes plásticas y visuales', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('809', '9006', 'Actividades teatrales', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('810', '9007', 'Actividades de espectáculos musicales en vivo', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('811', '9008', 'Otras actividades de espectáculos en vivo n.c.p.', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('812', '9101', 'Actividades de bibliotecas y archivos', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('813', '9102', 'Actividades y funcionamiento de museos, conservación de edificios y sitios históricos', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('814', '9103', 'Actividades de jardines botánicos, zoológicos y reservas naturales', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('815', '9200', 'Actividades de juegos de azar y apuestas', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('816', '9311', 'Gestión de instalaciones deportivas', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('817', '9312', 'Actividades de clubes deportivos', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('818', '9319', 'Otras actividades deportivas', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('819', '9321', 'Actividades de parques de atracciones y parques temáticos', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('820', '9329', 'Otras actividades recreativas y de esparcimiento n.c.p.', '3', '18');
INSERT INTO `cnt_ciiu` VALUES ('821', '9411', 'Actividades de asociaciones empresariales y de empleadores', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('822', '9412', 'Actividades de asociaciones profesionales', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('823', '9420', 'Actividades de sindicatos de empleados', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('824', '9491', 'Actividades de asociaciones religiosas', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('825', '9492', 'Actividades de asociaciones políticas', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('826', '9499', 'Actividades de otras asociaciones n.c.p.', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('827', '9511', 'Mantenimiento y reparación de computadores y de equipo periférico', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('828', '9512', 'Mantenimiento y reparación de equipos de comunicación', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('829', '9521', 'Mantenimiento y reparación de aparatos electrónicos de consumo', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('830', '9522', 'Mantenimiento y reparación de aparatos y equipos domésticos y de jardinería ', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('831', '9523', 'Reparación de calzado y artículos de cuero', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('832', '9524', 'Reparación de muebles y accesorios para el hogar', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('833', '9529', 'Mantenimiento y reparación de otros efectos personales y enseres domésticos', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('834', '9601', 'Lavado y limpieza, incluso la limpieza en seco, de productos textiles y de piel', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('835', '9602', 'Peluquería y otros tratamientos de belleza', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('836', '9603', 'Pompas fúnebres y actividades relacionadas', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('837', '9609', 'Otras actividades de servicios personales n.c.p.', '3', '19');
INSERT INTO `cnt_ciiu` VALUES ('838', '9700', 'Actividades de los hogares individuales como empleadores de personal doméstico', '3', '20');
INSERT INTO `cnt_ciiu` VALUES ('839', '9810', 'Actividades no diferenciadas de los hogares individuales como productores de bienes para uso propio', '3', '20');
INSERT INTO `cnt_ciiu` VALUES ('840', '9820', 'Actividades no diferenciadas de los hogares individuales como productores de servicios para uso propio', '3', '20');
INSERT INTO `cnt_ciiu` VALUES ('841', '9900', 'Actividades de organizaciones y entidades extraterritoriales', '3', '21');
INSERT INTO `cnt_ciiu` VALUES ('842', '0010', 'Asalariados', '3', '22');
INSERT INTO `cnt_ciiu` VALUES ('843', '0020', 'Pensionados', '3', '22');
INSERT INTO `cnt_ciiu` VALUES ('844', '0081', 'Personas naturales y sucesiones ilíquidas sin actividad económica', '3', '22');
INSERT INTO `cnt_ciiu` VALUES ('845', '0082', 'Personas naturales subsidiadas por terceros', '3', '22');
INSERT INTO `cnt_ciiu` VALUES ('846', '0090', 'Rentistas de capital, solo para personas naturales y sucesiones ilíquidas', '3', '22');

-- ----------------------------
-- Table structure for cnt_comprobante
-- ----------------------------
DROP TABLE IF EXISTS `cnt_comprobante`;
CREATE TABLE `cnt_comprobante` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_sucursal` int NOT NULL DEFAULT '1',
  `id_tipocomprobante` int NOT NULL,
  `id_modulo` int NOT NULL DEFAULT '1',
  `id_tercero` int NOT NULL,
  `id_reversion` int DEFAULT NULL,
  `cco_ano` char(4) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '0000',
  `cco_mes` char(2) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '00',
  `cco_consecutivo` int NOT NULL DEFAULT '0',
  `cco_fecha` date DEFAULT NULL,
  `cco_documento` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' COMMENT 'Documento referncia',
  `cco_detalle` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `id_usuario` varchar(255) NOT NULL DEFAULT '0',
  `estado` varchar(1) NOT NULL DEFAULT 'A',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `tipoanomesconsecutivo` (`id_sucursal`,`id_tipocomprobante`,`cco_ano`,`cco_mes`,`cco_consecutivo`),
  KEY `fk_cnt_comprobante_cnf_usuario_1` (`id_usuario`),
  KEY `fk_cnt_comprobante_cnt_tipocomprobante_1` (`id_tipocomprobante`),
  KEY `fk_cnt_comprobante_cnf_sucursal_1` (`id_sucursal`),
  CONSTRAINT `fk_cnt_comprobante_cnf_sucursal_1` FOREIGN KEY (`id_sucursal`) REFERENCES `cnf_sucursal` (`id`) ON UPDATE RESTRICT,
  CONSTRAINT `fk_cnt_comprobante_cnf_usuario_1` FOREIGN KEY (`id_usuario`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `fk_cnt_comprobante_cnt_tipocomprobante_1` FOREIGN KEY (`id_tipocomprobante`) REFERENCES `cnt_tipocomprobante` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=91 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_comprobante
-- ----------------------------
INSERT INTO `cnt_comprobante` VALUES ('2', '2', '8', '1', '2', '63', '2021', '02', '1', '2021-02-19', 'fte90999', 'detalle general REModificado', '2021-02-19 11:46:20', '2021-10-20 22:19:09', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'R');
INSERT INTO `cnt_comprobante` VALUES ('7', '2', '5', '1', '2', null, '2021', '02', '2', '2021-01-19', 'NOOEDITABLE 2020', 'sietee', '2021-06-28 20:30:13', '2021-10-20 22:19:09', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'N');
INSERT INTO `cnt_comprobante` VALUES ('20', '2', '2', '1', '2', '68', '2021', '02', '5', '2021-02-19', 'prueba INSETARDETALLE', 'DETALLES SIN MODELO transaccion', '2021-08-31 20:58:45', '2021-10-20 22:19:09', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'R');
INSERT INTO `cnt_comprobante` VALUES ('30', '2', '9', '1', '2', null, '2021', '02', '16', '2021-02-19', 'prueba INSETARDETALLE', 'DETALLES SIN MODELO transaccion', '2021-09-03 17:59:50', '2021-10-20 22:19:09', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('36', '2', '8', '1', '2', null, '2021', '02', '6', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-05 14:58:47', '2021-10-20 22:19:09', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'N');
INSERT INTO `cnt_comprobante` VALUES ('40', '2', '8', '1', '2', '67', '2021', '02', '7', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-05 18:37:29', '2021-10-20 22:19:09', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'R');
INSERT INTO `cnt_comprobante` VALUES ('43', '2', '2', '1', '2', null, '2021', '02', '10', '2021-02-19', '43-05-04', '43 Modificado', '2021-09-07 10:49:02', '2021-10-20 22:19:09', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('44', '2', '2', '1', '2', null, '2021', '02', '11', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-07 10:53:54', '2021-10-20 22:19:10', 'cf090fd0-11ca-48b9-b596-480ec320d187', 'A');
INSERT INTO `cnt_comprobante` VALUES ('46', '2', '2', '1', '2', null, '2021', '02', '13', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-07 11:44:55', '2021-10-20 22:19:10', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('47', '2', '2', '1', '2', null, '2021', '02', '14', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-07 14:25:26', '2021-10-20 22:19:10', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('48', '2', '2', '1', '2', null, '2021', '02', '15', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-07 15:37:00', '2021-10-20 22:19:10', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('49', '2', '2', '1', '2', null, '2021', '02', '17', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-07 15:56:27', '2021-10-20 22:19:10', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('50', '2', '2', '1', '5', null, '2021', '02', '18', '2021-02-15', '45-05-04', '555 Modificado', '2021-09-07 15:59:16', '2021-10-20 22:19:10', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('53', '2', '2', '1', '2', null, '2021', '02', '19', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-07 16:43:13', '2021-10-20 22:19:10', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('55', '2', '2', '1', '2', null, '2021', '02', '20', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-07 21:52:12', '2021-10-20 22:19:10', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('58', '2', '8', '1', '2', '66', '2021', '00', '3', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-08 17:22:31', '2021-10-20 22:19:11', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'R');
INSERT INTO `cnt_comprobante` VALUES ('59', '2', '8', '1', '2', '65', '2021', '00', '4', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-08 17:23:48', '2021-10-20 22:19:11', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'R');
INSERT INTO `cnt_comprobante` VALUES ('60', '2', '8', '1', '2', '64', '2021', '00', '5', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-08 21:48:11', '2021-10-20 22:19:11', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'R');
INSERT INTO `cnt_comprobante` VALUES ('62', '2', '3', '1', '2', null, '2021', '00', '1', '2021-02-19', 'prueba tx INSETARDETALLE', 'DETALLES SIN MODELO transaccion', '2021-09-26 18:36:20', '2021-10-20 22:19:11', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('63', '2', '3', '1', '2', null, '2021', '02', '99', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-09-28 11:22:01', '2021-10-21 09:49:37', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('64', '2', '9', '1', '2', null, '2021', '00', '99', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-28 11:23:30', '2021-10-20 22:19:11', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('65', '2', '9', '1', '2', null, '2021', '00', '1', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-28 11:38:05', '2021-10-20 22:19:11', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('66', '2', '9', '1', '2', null, '2021', '00', '2', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-28 11:41:05', '2021-10-20 22:19:12', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('67', '2', '9', '1', '2', null, '2021', '00', '3', '2021-02-19', 'prueba2020', '2020detalle general REModificado', '2021-09-29 15:31:54', '2021-10-20 22:19:12', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('68', '2', '9', '1', '2', null, '2021', '00', '4', '2021-02-19', 'prueba INSETARDETALLE', 'DETALLES SIN MODELO transaccion', '2021-10-08 17:15:06', '2021-10-20 22:19:12', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'R');
INSERT INTO `cnt_comprobante` VALUES ('70', '2', '3', '1', '2', null, '2021', '00', '2', '2021-02-19', 'prueba INSETARDETALLE', 'DETALLES SIN MODELO transaccion', '2021-10-20 23:02:22', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('71', '2', '8', '1', '2', null, '2021', '00', '6', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-21 11:01:59', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('72', '2', '8', '1', '2', null, '2021', '00', '7', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-21 11:05:57', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('73', '2', '8', '1', '2', null, '2021', '00', '8', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-21 16:42:46', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('76', '2', '8', '1', '2', null, '2021', '00', '9', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-21 16:50:29', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('77', '2', '8', '1', '2', null, '2021', '00', '10', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-21 16:54:46', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('78', '2', '8', '1', '2', null, '2021', '00', '11', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-21 20:41:58', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('83', '2', '8', '1', '2', null, '2021', '00', '12', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-21 21:15:58', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('84', '2', '8', '1', '2', null, '2021', '00', '13', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-24 08:06:25', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('85', '2', '8', '1', '2', null, '2021', '00', '14', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-24 08:15:57', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('86', '2', '8', '1', '2', null, '2021', '00', '15', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-24 08:23:40', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('87', '2', '8', '1', '2', null, '2021', '00', '16', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-24 09:49:21', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('88', '2', '8', '1', '2', null, '2021', '00', '17', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-24 09:51:55', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('89', '2', '8', '1', '2', null, '2021', '00', '18', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-24 10:01:58', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');
INSERT INTO `cnt_comprobante` VALUES ('90', '2', '8', '1', '2', null, '2021', '00', '19', '2021-10-19', 'fte90999', 'detalle general REModificado', '2021-10-24 10:04:56', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8', 'A');

-- ----------------------------
-- Table structure for cnt_conceptocuenta
-- ----------------------------
DROP TABLE IF EXISTS `cnt_conceptocuenta`;
CREATE TABLE `cnt_conceptocuenta` (
  `id` int NOT NULL AUTO_INCREMENT,
  `IdExogenaconcepto` int NOT NULL,
  `id_puc` int NOT NULL,
  `IdFormatocolumna` int NOT NULL,
  `IdTipooperacion` int NOT NULL DEFAULT '3' COMMENT '1=suma debito periodo 2=suma cr periodo 3=db periodo - cr periodo 4=saldo final',
  `estado` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_conceptocuenta_cnt_exogenaconcepto_1` (`IdExogenaconcepto`),
  KEY `fk_cnt_conceptocuenta_cnt_formatocolumna_1` (`IdFormatocolumna`),
  KEY `fk_cnt_conceptocuenta_cnt_pucauxcuenta_1` (`id_puc`),
  KEY `fk_cnt_conceptocuenta_cnt_tipooperacion_1` (`IdTipooperacion`),
  CONSTRAINT `cnt_conceptocuenta_ibfk_1` FOREIGN KEY (`IdExogenaconcepto`) REFERENCES `cnt_exogenaconcepto` (`id`),
  CONSTRAINT `cnt_conceptocuenta_ibfk_2` FOREIGN KEY (`IdFormatocolumna`) REFERENCES `cnt_formatocolumna` (`id`),
  CONSTRAINT `cnt_conceptocuenta_ibfk_3` FOREIGN KEY (`id_puc`) REFERENCES `cnt_puc` (`id`),
  CONSTRAINT `cnt_conceptocuenta_ibfk_4` FOREIGN KEY (`IdTipooperacion`) REFERENCES `cnt_tipooperacion` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_conceptocuenta
-- ----------------------------
INSERT INTO `cnt_conceptocuenta` VALUES ('1', '1', '1', '13', '2', '1');
INSERT INTO `cnt_conceptocuenta` VALUES ('2', '1', '1', '13', '2', '1');
INSERT INTO `cnt_conceptocuenta` VALUES ('4', '2', '1', '13', '2', '1');
INSERT INTO `cnt_conceptocuenta` VALUES ('5', '2', '1', '13', '2', '1');

-- ----------------------------
-- Table structure for cnt_consecutivo
-- ----------------------------
DROP TABLE IF EXISTS `cnt_consecutivo`;
CREATE TABLE `cnt_consecutivo` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_tipocomprobante` int NOT NULL,
  `id_sucursal` int NOT NULL DEFAULT '0',
  `co_ano` char(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0000',
  `co_mes` char(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '00',
  `co_consecutivo` int DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_consecutivo_cnt_tipocomprobante_1` (`id_tipocomprobante`),
  KEY `fk_cnt_consecutivo_cnf_sucursal_1` (`id_sucursal`),
  CONSTRAINT `cnt_consecutivo_ibfk_1` FOREIGN KEY (`id_tipocomprobante`) REFERENCES `cnt_tipocomprobante` (`id`),
  CONSTRAINT `fk_cnt_consecutivo_cnf_sucursal_1` FOREIGN KEY (`id_sucursal`) REFERENCES `cnf_sucursal` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_consecutivo
-- ----------------------------
INSERT INTO `cnt_consecutivo` VALUES ('1', '2', '2', '2020', '02', '1');
INSERT INTO `cnt_consecutivo` VALUES ('2', '2', '2', '2021', '02', '2');
INSERT INTO `cnt_consecutivo` VALUES ('5', '8', '2', '2021', '01', '1');
INSERT INTO `cnt_consecutivo` VALUES ('6', '3', '2', '2021', '02', '4');
INSERT INTO `cnt_consecutivo` VALUES ('7', '3', '2', '2021', '01', '1');
INSERT INTO `cnt_consecutivo` VALUES ('8', '8', '2', '2021', '02', '20');
INSERT INTO `cnt_consecutivo` VALUES ('10', '8', '2', '2021', '00', '19');
INSERT INTO `cnt_consecutivo` VALUES ('11', '3', '2', '0000', '00', '1');
INSERT INTO `cnt_consecutivo` VALUES ('12', '3', '2', '2021', '00', '2');
INSERT INTO `cnt_consecutivo` VALUES ('13', '9', '2', '2021', '00', '4');

-- ----------------------------
-- Table structure for cnt_cuentaimpuesto
-- ----------------------------
DROP TABLE IF EXISTS `cnt_cuentaimpuesto`;
CREATE TABLE `cnt_cuentaimpuesto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_puc` int NOT NULL,
  `id_tipoimpuesto` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_cuentaimpuesto_cnt_pucauxcuenta_1` (`id_puc`),
  KEY `fk_cnt_cuentaimpuesto_cnt_tipoimpuesto_1` (`id_tipoimpuesto`),
  CONSTRAINT `cnt_cuentaimpuesto_ibfk_1` FOREIGN KEY (`id_puc`) REFERENCES `cnt_puc` (`id`),
  CONSTRAINT `cnt_cuentaimpuesto_ibfk_2` FOREIGN KEY (`id_tipoimpuesto`) REFERENCES `cnt_tipoimpuesto` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_cuentaimpuesto
-- ----------------------------
INSERT INTO `cnt_cuentaimpuesto` VALUES ('6', '16', '1');
INSERT INTO `cnt_cuentaimpuesto` VALUES ('7', '17', '2');

-- ----------------------------
-- Table structure for cnt_departamento
-- ----------------------------
DROP TABLE IF EXISTS `cnt_departamento`;
CREATE TABLE `cnt_departamento` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(3) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_departamento
-- ----------------------------
INSERT INTO `cnt_departamento` VALUES ('1', '05', 'ANTIOQUIA');
INSERT INTO `cnt_departamento` VALUES ('2', '08', 'ATLANTICO');
INSERT INTO `cnt_departamento` VALUES ('3', '11', 'BOGOTA');
INSERT INTO `cnt_departamento` VALUES ('4', '13', 'BOLIVAR');
INSERT INTO `cnt_departamento` VALUES ('5', '15', 'BOYACA');
INSERT INTO `cnt_departamento` VALUES ('6', '17', 'CALDAS');
INSERT INTO `cnt_departamento` VALUES ('7', '18', 'CAQUETA');
INSERT INTO `cnt_departamento` VALUES ('8', '19', 'CAUCA');
INSERT INTO `cnt_departamento` VALUES ('9', '20', 'CESAR');
INSERT INTO `cnt_departamento` VALUES ('10', '23', 'CORDOBA');
INSERT INTO `cnt_departamento` VALUES ('11', '25', 'CUNDINAMARCA');
INSERT INTO `cnt_departamento` VALUES ('12', '27', 'CHOCO');
INSERT INTO `cnt_departamento` VALUES ('13', '41', 'HUILA');
INSERT INTO `cnt_departamento` VALUES ('14', '44', 'LA GUAJIRA');
INSERT INTO `cnt_departamento` VALUES ('15', '47', 'MAGDALENA');
INSERT INTO `cnt_departamento` VALUES ('16', '50', 'META');
INSERT INTO `cnt_departamento` VALUES ('17', '52', 'NARIÑO');
INSERT INTO `cnt_departamento` VALUES ('18', '54', 'N. DE SANTANDER');
INSERT INTO `cnt_departamento` VALUES ('19', '63', 'QUINDIO');
INSERT INTO `cnt_departamento` VALUES ('20', '66', 'RISARALDA');
INSERT INTO `cnt_departamento` VALUES ('21', '68', 'SANTANDER');
INSERT INTO `cnt_departamento` VALUES ('22', '70', 'SUCRE');
INSERT INTO `cnt_departamento` VALUES ('23', '73', 'TOLIMA');
INSERT INTO `cnt_departamento` VALUES ('24', '76', 'VALLE DEL CAUCA');
INSERT INTO `cnt_departamento` VALUES ('25', '81', 'ARAUCA');
INSERT INTO `cnt_departamento` VALUES ('26', '85', 'CASANARE');
INSERT INTO `cnt_departamento` VALUES ('27', '86', 'PUTUMAYO');
INSERT INTO `cnt_departamento` VALUES ('28', '88', 'SAN ANDRES');
INSERT INTO `cnt_departamento` VALUES ('29', '91', 'AMAZONAS');
INSERT INTO `cnt_departamento` VALUES ('30', '94', 'GUAINIA');
INSERT INTO `cnt_departamento` VALUES ('31', '95', 'GUAVIARE');
INSERT INTO `cnt_departamento` VALUES ('32', '97', 'VAUPES');
INSERT INTO `cnt_departamento` VALUES ('33', '99', 'VICHADA');

-- ----------------------------
-- Table structure for cnt_detallecomprobante
-- ----------------------------
DROP TABLE IF EXISTS `cnt_detallecomprobante`;
CREATE TABLE `cnt_detallecomprobante` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_comprobante` int NOT NULL DEFAULT '0',
  `id_centrocosto` int NOT NULL,
  `id_puc` int NOT NULL,
  `id_tercero` int NOT NULL,
  `dco_base` double(20,2) NOT NULL DEFAULT '0.00',
  `dco_tarifa` double(5,2) NOT NULL DEFAULT '0.00',
  `dco_debito` double(20,2) NOT NULL DEFAULT '0.00',
  `dco_credito` double(20,2) NOT NULL DEFAULT '0.00',
  `dco_detalle` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_detallecomprobante_cnt_centrocosto_1` (`id_centrocosto`),
  KEY `fk_cnt_detallecomprobante_cnt_pucauxcuenta_1` (`id_puc`),
  KEY `fk_cnt_detallecomprobante_cnt_tercero_1` (`id_tercero`),
  KEY `fk_cnt_detallecomprobante_cnt_comprobante_1` (`id_comprobante`),
  CONSTRAINT `cnt_detallecomprobante_ibfk_1` FOREIGN KEY (`id_centrocosto`) REFERENCES `cnt_centrocosto` (`id`) ON UPDATE RESTRICT,
  CONSTRAINT `cnt_detallecomprobante_ibfk_2` FOREIGN KEY (`id_comprobante`) REFERENCES `cnt_comprobante` (`id`),
  CONSTRAINT `cnt_detallecomprobante_ibfk_3` FOREIGN KEY (`id_puc`) REFERENCES `cnt_puc` (`id`),
  CONSTRAINT `cnt_detallecomprobante_ibfk_4` FOREIGN KEY (`id_tercero`) REFERENCES `cnt_tercero` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=173 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_detallecomprobante
-- ----------------------------
INSERT INTO `cnt_detallecomprobante` VALUES ('1', '2', '1', '20', '2', '0.00', '0.00', '1000.00', '0.00', 'uni');
INSERT INTO `cnt_detallecomprobante` VALUES ('3', '2', '1', '22', '2', '0.00', '0.00', '0.00', '200.00', 'Ortyo');
INSERT INTO `cnt_detallecomprobante` VALUES ('4', '2', '1', '2', '2', '0.00', '0.00', '0.00', '800.00', 'Ortyc');
INSERT INTO `cnt_detallecomprobante` VALUES ('18', '20', '1', '17', '2', '0.00', '50.00', '9000.00', '0.00', 'Primer registro transacc');
INSERT INTO `cnt_detallecomprobante` VALUES ('19', '20', '1', '19', '5', '0.00', '0.00', '0.00', '9000.00', 'Segundo registro transacc');
INSERT INTO `cnt_detallecomprobante` VALUES ('37', '7', '1', '17', '5', '0.00', '10.00', '5200000.00', '0.00', 'sieteee');
INSERT INTO `cnt_detallecomprobante` VALUES ('38', '7', '1', '19', '5', '0.00', '0.00', '0.00', '5200000.00', 'sieteee');
INSERT INTO `cnt_detallecomprobante` VALUES ('39', '30', '1', '19', '5', '0.00', '0.00', '9000.00', '0.00', 'Segundo registro transacc');
INSERT INTO `cnt_detallecomprobante` VALUES ('40', '30', '1', '17', '2', '0.00', '50.00', '0.00', '9000.00', 'Primer registro transacc');
INSERT INTO `cnt_detallecomprobante` VALUES ('41', '36', '1', '20', '5', '0.00', '0.00', '0.00', '35000.00', 'nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('42', '36', '1', '20', '5', '0.00', '0.00', '35000.00', '0.00', 'nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('43', '40', '1', '20', '5', '0.00', '0.00', '0.00', '36000.00', 'nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('44', '40', '1', '20', '5', '0.00', '0.00', '36000.00', '0.00', 'nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('51', '44', '1', '2', '5', '0.00', '0.00', '0.00', '940000.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('52', '44', '1', '20', '5', '0.00', '0.00', '940000.00', '0.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('55', '46', '1', '2', '5', '0.00', '0.00', '0.00', '2940000.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('56', '46', '1', '16', '5', '0.00', '0.00', '2940000.00', '0.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('57', '47', '1', '16', '5', '0.00', '0.00', '990000.00', '0.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('58', '47', '1', '2', '5', '0.00', '0.00', '0.00', '990000.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('59', '48', '1', '2', '5', '0.00', '0.00', '0.00', '1990000.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('60', '48', '1', '16', '5', '0.00', '0.00', '1990000.00', '0.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('61', '49', '1', '22', '5', '0.00', '0.00', '0.00', '1990000.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('62', '49', '1', '16', '5', '0.00', '0.00', '1990000.00', '0.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('65', '53', '1', '22', '5', '0.00', '0.00', '0.00', '3990000.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('66', '53', '1', '17', '5', '0.00', '0.00', '3990000.00', '0.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('67', '55', '1', '22', '5', '0.00', '0.00', '0.00', '3990000.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('68', '55', '1', '17', '5', '0.00', '0.00', '3990000.00', '0.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('73', '58', '1', '20', '5', '0.00', '0.00', '0.00', '3990000.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('74', '58', '1', '16', '5', '0.00', '0.00', '3990000.00', '0.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('75', '59', '1', '22', '5', '0.00', '0.00', '0.00', '3990000.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('76', '59', '1', '17', '5', '0.00', '0.00', '3990000.00', '0.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('77', '60', '1', '22', '5', '0.00', '0.00', '0.00', '3990000.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('78', '60', '1', '17', '5', '0.00', '0.00', '3990000.00', '0.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('81', '62', '1', '19', '5', '0.00', '0.00', '0.00', '5000.00', 'Segundo registro tx');
INSERT INTO `cnt_detallecomprobante` VALUES ('82', '62', '1', '17', '2', '0.00', '50.00', '5000.00', '0.00', 'Primer registro tx');
INSERT INTO `cnt_detallecomprobante` VALUES ('91', '64', '1', '2', '5', '0.00', '0.00', '0.00', '3990000.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('92', '64', '1', '17', '5', '0.00', '0.00', '3990000.00', '0.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('93', '65', '1', '17', '5', '0.00', '0.00', '3990000.00', '0.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('94', '65', '1', '2', '5', '0.00', '0.00', '0.00', '3990000.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('95', '66', '1', '2', '5', '0.00', '0.00', '0.00', '3990000.00', 'nuevo 54detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('96', '66', '1', '16', '5', '0.00', '0.00', '3990000.00', '0.00', '54nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('97', '67', '1', '2', '5', '0.00', '0.00', '0.00', '36000.00', 'nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('98', '67', '1', '20', '5', '0.00', '0.00', '36000.00', '0.00', 'nuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('103', '43', '1', '20', '5', '0.00', '0.00', '430000.00', '0.00', '4xuevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('104', '43', '1', '2', '5', '0.00', '0.00', '0.00', '430000.00', '44xxevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('107', '50', '1', '20', '5', '0.00', '0.00', '650000.00', '0.00', '5uevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('108', '50', '1', '2', '5', '0.00', '0.00', '0.00', '650000.00', '499xxevo detalle');
INSERT INTO `cnt_detallecomprobante` VALUES ('109', '68', '1', '19', '5', '0.00', '0.00', '9000.00', '0.00', 'Segundo registro transacc');
INSERT INTO `cnt_detallecomprobante` VALUES ('110', '68', '1', '17', '2', '0.00', '50.00', '0.00', '9000.00', 'Primer registro transacc');
INSERT INTO `cnt_detallecomprobante` VALUES ('111', '70', '1', '17', '2', '0.00', '50.00', '10000.00', '0.00', 'Primer registro transacc');
INSERT INTO `cnt_detallecomprobante` VALUES ('112', '70', '1', '19', '5', '0.00', '0.00', '0.00', '10000.00', 'Segundo registro transacc');
INSERT INTO `cnt_detallecomprobante` VALUES ('116', '76', '1', '22', '5', '0.00', '0.00', '0.00', '5000.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('117', '76', '1', '16', '5', '0.00', '0.00', '4000.00', '0.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('118', '76', '1', '20', '5', '0.00', '0.00', '1000.00', '0.00', 'tercero');
INSERT INTO `cnt_detallecomprobante` VALUES ('119', '77', '1', '22', '5', '0.00', '0.00', '0.00', '5000.00', 'interf2');
INSERT INTO `cnt_detallecomprobante` VALUES ('120', '77', '1', '16', '5', '0.00', '0.00', '4000.00', '0.00', 'interf2');
INSERT INTO `cnt_detallecomprobante` VALUES ('121', '77', '1', '20', '5', '0.00', '0.00', '1000.00', '0.00', 'tercero2');
INSERT INTO `cnt_detallecomprobante` VALUES ('122', '78', '1', '22', '5', '0.00', '0.00', '0.00', '5000.00', 'interf2');
INSERT INTO `cnt_detallecomprobante` VALUES ('123', '78', '1', '16', '5', '0.00', '0.00', '4000.00', '0.00', 'interf2');
INSERT INTO `cnt_detallecomprobante` VALUES ('124', '78', '1', '20', '5', '0.00', '0.00', '1000.00', '0.00', 'tercero2');
INSERT INTO `cnt_detallecomprobante` VALUES ('125', '83', '1', '22', '5', '0.00', '0.00', '0.00', '5000.00', 'interf2');
INSERT INTO `cnt_detallecomprobante` VALUES ('126', '83', '1', '16', '5', '0.00', '0.00', '4000.00', '0.00', 'interf2');
INSERT INTO `cnt_detallecomprobante` VALUES ('127', '83', '1', '20', '5', '0.00', '0.00', '1000.00', '0.00', 'tercero2');
INSERT INTO `cnt_detallecomprobante` VALUES ('128', '84', '1', '22', '5', '0.00', '0.00', '0.00', '5000.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('129', '84', '1', '16', '5', '0.00', '0.00', '4000.00', '0.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('130', '84', '1', '20', '5', '0.00', '0.00', '1000.00', '0.00', 'tercero');
INSERT INTO `cnt_detallecomprobante` VALUES ('131', '85', '1', '22', '5', '0.00', '0.00', '0.00', '6000.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('132', '85', '1', '16', '5', '0.00', '0.00', '5000.00', '0.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('133', '85', '1', '20', '5', '0.00', '0.00', '1000.00', '0.00', 'tercero');
INSERT INTO `cnt_detallecomprobante` VALUES ('134', '86', '1', '22', '5', '0.00', '0.00', '0.00', '6000.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('135', '86', '1', '16', '5', '0.00', '0.00', '5000.00', '0.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('136', '86', '1', '20', '5', '0.00', '0.00', '1000.00', '0.00', 'tercero');
INSERT INTO `cnt_detallecomprobante` VALUES ('140', '87', '1', '22', '5', '0.00', '0.00', '0.00', '20000.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('141', '87', '1', '16', '5', '0.00', '0.00', '15000.00', '0.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('142', '87', '1', '20', '5', '0.00', '0.00', '5000.00', '0.00', 'tercero');
INSERT INTO `cnt_detallecomprobante` VALUES ('143', '87', '1', '20', '5', '0.00', '0.00', '5000.00', '0.00', 'tercero');
INSERT INTO `cnt_detallecomprobante` VALUES ('144', '87', '1', '16', '5', '0.00', '0.00', '15000.00', '0.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('145', '87', '1', '22', '5', '0.00', '0.00', '0.00', '20000.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('146', '88', '1', '22', '5', '0.00', '0.00', '0.00', '20000.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('147', '88', '1', '16', '5', '0.00', '0.00', '15000.00', '0.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('148', '88', '1', '20', '5', '0.00', '0.00', '5000.00', '0.00', 'tercero');
INSERT INTO `cnt_detallecomprobante` VALUES ('149', '88', '1', '20', '5', '0.00', '0.00', '5000.00', '0.00', 'tercero');
INSERT INTO `cnt_detallecomprobante` VALUES ('150', '88', '1', '16', '5', '0.00', '0.00', '15000.00', '0.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('151', '88', '1', '22', '5', '0.00', '0.00', '0.00', '20000.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('152', '89', '1', '22', '5', '0.00', '0.00', '0.00', '2000.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('153', '89', '1', '16', '5', '0.00', '0.00', '15000.00', '0.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('154', '89', '1', '20', '5', '0.00', '0.00', '5000.00', '0.00', 'tercero');
INSERT INTO `cnt_detallecomprobante` VALUES ('155', '89', '1', '20', '5', '0.00', '0.00', '5000.00', '0.00', 'tercero');
INSERT INTO `cnt_detallecomprobante` VALUES ('156', '89', '1', '16', '5', '0.00', '0.00', '15000.00', '0.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('157', '89', '1', '22', '5', '0.00', '0.00', '0.00', '2000.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('158', '90', '1', '22', '5', '0.00', '0.00', '0.00', '2000.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('159', '90', '1', '16', '5', '0.00', '0.00', '15000.00', '0.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('160', '90', '1', '20', '5', '0.00', '0.00', '5000.00', '0.00', 'tercero');
INSERT INTO `cnt_detallecomprobante` VALUES ('161', '90', '1', '20', '5', '0.00', '0.00', '5000.00', '0.00', 'tercero');
INSERT INTO `cnt_detallecomprobante` VALUES ('162', '90', '1', '16', '5', '0.00', '0.00', '15000.00', '0.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('163', '90', '1', '22', '5', '0.00', '0.00', '0.00', '2000.00', 'interf');
INSERT INTO `cnt_detallecomprobante` VALUES ('170', '63', '1', '22', '5', '0.00', '0.00', '0.00', '7000.00', 'modif63');
INSERT INTO `cnt_detallecomprobante` VALUES ('171', '63', '1', '16', '5', '0.00', '0.00', '2000.00', '0.00', 'dbmodif63');
INSERT INTO `cnt_detallecomprobante` VALUES ('172', '63', '1', '20', '5', '0.00', '0.00', '5000.00', '0.00', 'tercero');

-- ----------------------------
-- Table structure for cnt_entidad
-- ----------------------------
DROP TABLE IF EXISTS `cnt_entidad`;
CREATE TABLE `cnt_entidad` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_tercero` int NOT NULL,
  `id_tipoimpuesto` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_entidades_cnt_tercero_1` (`id_tercero`),
  KEY `fk_cnt_entidad_cnt_tipoimpuesto_1` (`id_tipoimpuesto`),
  CONSTRAINT `cnt_entidad_ibfk_1` FOREIGN KEY (`id_tipoimpuesto`) REFERENCES `cnt_tipoimpuesto` (`id`),
  CONSTRAINT `cnt_entidad_ibfk_2` FOREIGN KEY (`id_tercero`) REFERENCES `cnt_tercero` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_entidad
-- ----------------------------
INSERT INTO `cnt_entidad` VALUES ('1', '2', '2');
INSERT INTO `cnt_entidad` VALUES ('2', '5', '4');

-- ----------------------------
-- Table structure for cnt_errores
-- ----------------------------
DROP TABLE IF EXISTS `cnt_errores`;
CREATE TABLE `cnt_errores` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Records of cnt_errores
-- ----------------------------
INSERT INTO `cnt_errores` VALUES ('1', '100', 'Proyecto Aplicacion, NameSpace CntCategoriaComprobante. Clase  Insertar:SaveChangesAsync ');
INSERT INTO `cnt_errores` VALUES ('2', '101', 'Proyecto Aplicacion, NameSpace Aplicacion.Contabilidad.TipoComprobantes. Clase  Insertar:SaveChangesAsync ');
INSERT INTO `cnt_errores` VALUES ('3', '103', 'Proyecto Aplicacion, NameSpace Aplicacion.Confituracion.Usuarios. Clase  Insertar:SaveChangesAsync ');

-- ----------------------------
-- Table structure for cnt_exogenaconcepto
-- ----------------------------
DROP TABLE IF EXISTS `cnt_exogenaconcepto`;
CREATE TABLE `cnt_exogenaconcepto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `estado` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=82 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_exogenaconcepto
-- ----------------------------
INSERT INTO `cnt_exogenaconcepto` VALUES ('1', '5055', 'Viáticos:  El valor  acumulado efectivamente  pagado que no constituye  ingreso  para el trabajador.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('2', '5056', 'Gastos de representación: El valor acumulado efectivamente pagado que no constituye ingreso para el trabajador', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('3', '5002', 'Honorarios: El valor acumulado pagado o abonado en cuenta. No debe incluir valores de rentas de trabajo y de pensiones.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('4', '1301', 'Retenciones por salarios y demàs pagos laborales', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('5', '1302', 'Retenciones por ventas', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('6', '1303', 'Retenciones por Servicios', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('9', '1304', 'Retenciones por Honorarios', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('10', '1305', 'Retenciones por Comisiones', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('11', '1306', 'Retenciones por Intereses y Rendimientos Financieros', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('12', '1307', 'Retenciones por Arrendamientos', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('13', '1308', 'Retencion por Otros conceptos', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('14', '1309', 'Retención en la fuente en el  Impuesto a las ventas.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('15', '1310', 'Retención por dividendos y participaciones', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('16', '1311', 'Retención por enajenación de activos fijos de personas naturales ante oficinas de tránsito y otras entidades autorizadas', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('17', '1312', 'Retención por ingresos de tarjetas débito y crédito', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('18', '1313', 'Retención por loterías, rifas, apuestas y similares', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('19', '1314', 'Retención por Impuesto de Timbre', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('20', '1320', 'Retención por dividendos y participaciones recibidas por sociedades nacionales art. 242-1 del E.T.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('21', '8305', 'Descuento tributario empresas de servicios públicos domiciliarios que presten servicios de acueducto y alcantarillado. L. 788/2002, art. 104. ', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('22', '8316', 'Descuento tributario por donaciones dirigida a programas de becas o créditos condonables. Art. 256, Parágrafo 1 y 2 del 158-1 del E.T. ', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('23', '8317', 'Descuento tributario por inversiones en investigación, desarrollo tecnológico e innovación. E.T., art. 158-1 y 256, modificado L. 1819/2016, art. 91 y 104.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('24', '8318', 'Descuento por donaciones efectuadas a entidades sin ánimo de lucro pertenecientes al régimen tributario especial. E.T., art. 257, creado L.1819/2016, art. 105. ', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('25', '8319', 'Descuento tributario por donaciones efectuadas a entidades sin ánimo de lucro no contribuyentes de que tratan los artículos 22 y 23 del estatuto tributario. E.T., art. 257, creado L. 1819/2016, art. 105.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('26', '8320', 'Descuento tributario para inversiones realizadas en control, conservación y mejoramiento del medio ambiente. E.T., Art. 255, creado L. 1819/2016, art. 103.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('27', '8321', 'Descuento tributario por donaciones en la red nacional de bibliotecas públicas y biblioteca nacional E.T., art. 257, parágrafo, creado L. 1819/2016, art. 105.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('28', '8322', 'Descuento tributario por donaciones a favor del fondo para reparación de víctimas. Art 177, ley 1448 de 2011 y art. 2.2.10.6. DUR 1084 de 2015.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('29', '8323', 'Descuento tributario por impuestos pagados en el exterior por la Entidad controlada del Exterior (ECE). E.T., art.892, adicionado L 1819/2016, art. 139. Y Art. 254 E.T.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('30', '8324', 'Descuento tributario por donación a la Corporación General Gustavo Matamoros D’ Costa y demás fundaciones dedicadas a la defensa, protección de derechos humanos. E.T., art 126-2, inciso 1', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('31', '8325', 'Descuento tributario por donación a organismos de deporte aficionado. E.T., art. 126- 2, inciso. 2.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('32', '8326', 'Descuento tributario por donación a organismos deportivos y recreativos o culturales personas jurídicas sin ánimo de lucro, E.T., art. 126-2, inciso 3.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('33', '8327', 'Descuento tributario por donaciones efectuadas para el apadrinamiento de parques naturales y conservación de bosques naturales. E.T., art. 126-5.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('34', '8328', 'Descuento tributario por aportes al sistema general de pensiones a cargo del empleador que sea contribuyente del impuesto unificado bajo el régimen simple de tributación. E.T., art. 903.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('35', '8329', 'Descuento tributario por ventas de bienes o servicios realizados a través de los sistemas de tarjetas de crédito y/o débito y otros mecanismos electrónicos de pagos ART. 912 E.T. ', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('36', '8330', 'Descuento tributario por impuesto de industria, comercio, avisos y tableros. E.T., art. 115 del E.T.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('37', '8331', 'Descuento tributario por impuesto sobre las ventas en la importación, formación, construcción, o adquisición de activos fijos reales productivos. Art. 258-1 del E.T.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('38', '8332', 'Descuento tributario por convenios con Coldeportes para asignar becas de estudio y manutención a deportistas talento o reserva deportiva. E.T., art. 257-1, L. 2010, art. 94', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('39', '4001', 'Ingresos brutos operacionales', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('40', '4002', 'Ingresos no operacionales diferentes de intereses y rendimientos financieros', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('41', '4003', 'Ingresos por intereses y rendimientos financieros', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('42', '4004', 'Ingresos por intereses correspondientes a créditos hipotecarios', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('43', '4010', 'Ingresos de consorcios y uniones temporales', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('44', '4040', 'Ingresos a través de contratos de mandato o de administración delegada', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('45', '4050', 'Ingresos en contratos de exploración y explotación minera', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('46', '1315', 'Cuentas por Cobrar-Clientes', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('47', '1316', 'Cuentas por Cobrar  Compañías accionistas, socios y compañías vinculadas', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('48', '1317', 'Otras Cuentas por Cobrar', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('49', '1318', 'Saldo fiscal provisión de cartera', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('50', '1340', 'Cuentas por cobrar en contratos de mandato o de administración delegada', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('51', '1350', 'Cuentas por cobrar en contratos de asociación por exploración y explotación minera', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('52', '2201', 'Saldo de los pasivos con proveedores', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('53', '2202', 'Saldo de los pasivos con compañías vinculadas accionistas y socios', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('54', '2203', 'Saldo de las obligaciones financieras', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('55', '2204', 'Saldo de los pasivos por impuestos, gravámenes y tasas', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('56', '2205', 'Saldo de los pasivos laborales,', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('57', '2206', 'Saldo de los demás pasivos', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('58', '2207', 'Saldo del Pasivo determinado por el cálculo Actuarial', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('59', '2208', 'Pasivos respaldados en documento de fecha cierta', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('60', '2209', 'Pasivos exclusivos de las compañías de seguros', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('61', '2211', 'Valor de los pasivos por depósitos judiciales', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('62', '2212', 'valor del pasivo por ingresos diferidos por puntos premio otorgados en programas de fidelización', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('63', '2213', 'valor del pasivo por ingresos diferidos contemplados en el art. 23-1 del E.T.,', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('64', '1601', 'Inversiones Zomac realizadas en el año representadas en inventarios, propiedad planta y equipo', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('65', '1602', 'Inversiones en Megainversiones en el año representadas en propiedad, planta y equipo.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('66', '1603', 'Inversiones realizadas por empresas de economía naranja de que trata el numeral 1 del artículo 235-2 del E.T., en propiedad, planta y equipo, intangibles de que trata el numeral 1 del artículo 74 e inversiones del numeral 3 del artículo 74-1, del E.T', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('67', '1604', 'Inversiones realizadas por empresas dedicas al desarrollo del campo colombiano de que trata el numeral 2 del artículo 235-2 del E.T., en propiedad, planta y equipo y activos biológicos productores', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('68', '8104', 'Renta exenta por venta energía eléctrica generada con base en energía eólica, biomasa o residuos agrícolas, solar, geotérmica o de los mares. Art.235-2 numeral 3.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('69', '8106', 'Renta exenta por aprovechamiento de nuevas plantaciones forestales incluida la guadua el caucho y el marañón. Art. 235-2 numeral 5, Inciso 1', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('70', '8109', 'Renta exenta por prestación de servicio de transporte fluvial con embarcaciones y planchones de bajo calado Art. 235-2 numeral 6.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('71', '8111', 'Rentas exentas por la utilidad en la enajenación de predios destinados a fines de utilidad pública. Num 9 Art. 207-2 E.T. Sentencia C-083 del 2018', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('72', '8120', 'Rentas exentas por aplicación de algún convenio para evitar la doble tributación. ', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('73', '8121', 'Renta exenta por creaciones literarias dela economía naranja contenidas en el artículo 28 de la Ley 98 de 1993. Art. 235-2 numeral 8.', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('74', '8125', 'Rentas exentas por Intereses, comisiones y pagos por deuda pública externa, E.T. art. 218 E.T.  ', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('75', '8127', 'Rentas exentas por inversión en nuevos aserríos, plantas de procesamiento y plantaciones de árboles maderables y árboles en producción de frutos. E.T., art. 235-2, numeral 5.Incisos 2 y 3 ', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('76', '8133', 'Rentas exentas por servicios prestados en hoteles nuevos. E.T., Art. 207-2, Num 3 Sentencia C 235 del 29 de mayo de 2019', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('77', '8134', 'Rentas exentas por servicios prestados en hoteles remodelado y/o ampliados. E.T., Art. 207-2 E.T, Num. 4. Sentencia C 235 del 29 de mayo de 2019', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('78', '8140', 'Rentas exentas por aportes voluntarios a los fondos de pensiones. E.T. art. 126-1, inc. 2', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('79', '8141', 'Rentas exentas por los ahorros a largo plazo para el fomento de la construcción ', '1');
INSERT INTO `cnt_exogenaconcepto` VALUES ('80', '8142', 'Rentas exentas del beneficio neto o excedente para las entidades sin ánimo de lucro. ', '1');

-- ----------------------------
-- Table structure for cnt_exogenaformato
-- ----------------------------
DROP TABLE IF EXISTS `cnt_exogenaformato`;
CREATE TABLE `cnt_exogenaformato` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_exogenaformato
-- ----------------------------
INSERT INTO `cnt_exogenaformato` VALUES ('1', '1001', 'Pagos o abonos en cuenta y retenciones practicadas');
INSERT INTO `cnt_exogenaformato` VALUES ('2', '1003', 'Retenciones en la fuente que le practicaron');
INSERT INTO `cnt_exogenaformato` VALUES ('3', '1004', 'Descuentos tributarios');
INSERT INTO `cnt_exogenaformato` VALUES ('4', '1005', 'Impuesto a las ventas por pagar(Descontable)');
INSERT INTO `cnt_exogenaformato` VALUES ('5', '1006', 'Impuesto a las ventas por pagar(Generado)');
INSERT INTO `cnt_exogenaformato` VALUES ('6', '1007', 'Ingresos recibidos');
INSERT INTO `cnt_exogenaformato` VALUES ('7', '1008', 'Saldo cuentas por cobrar');
INSERT INTO `cnt_exogenaformato` VALUES ('8', '1009', 'Saldo cuentas por pagar');
INSERT INTO `cnt_exogenaformato` VALUES ('9', '1010', 'Información de socios,  accionistas, comuneros y/o cooperados');
INSERT INTO `cnt_exogenaformato` VALUES ('10', '1011', 'Información de las declaraciones Tributarias');
INSERT INTO `cnt_exogenaformato` VALUES ('11', '1012', 'Información de declaraciones tributarias, acciones, inversiones ');
INSERT INTO `cnt_exogenaformato` VALUES ('12', '1647', 'Ingresos recibidos para terceros');
INSERT INTO `cnt_exogenaformato` VALUES ('13', '2275', 'Ingresos No Constitutivos de Renta Ni Ganancia Ocasional');
INSERT INTO `cnt_exogenaformato` VALUES ('14', '2276', 'Información de rentas de trabajo y pensiones');

-- ----------------------------
-- Table structure for cnt_formatocolumna
-- ----------------------------
DROP TABLE IF EXISTS `cnt_formatocolumna`;
CREATE TABLE `cnt_formatocolumna` (
  `id` int NOT NULL AUTO_INCREMENT,
  `IdExogenaformato` int NOT NULL,
  `FcoColumna` char(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `FcoCampo` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `FcoTipo` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_formatocolumna_cnt_exogenaformato_1` (`IdExogenaformato`),
  CONSTRAINT `cnt_formatocolumna_ibfk_1` FOREIGN KEY (`IdExogenaformato`) REFERENCES `cnt_exogenaformato` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_formatocolumna
-- ----------------------------
INSERT INTO `cnt_formatocolumna` VALUES ('1', '1', 'B', 'concepto', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('2', '1', 'C', 'tipodocumento', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('3', '1', 'D', 'documento', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('4', '1', 'E', 'priapellido', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('5', '1', 'F', 'segapellido', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('6', '1', 'G', 'prinombre', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('7', '1', 'H', 'segnombre', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('8', '1', 'I', 'razonsocial', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('9', '1', 'J', 'direccion', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('10', '1', 'K', 'codigo_departamento', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('11', '1', 'L', 'codigo_municipio', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('12', '1', 'M', 'pais', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('13', '1', 'N', 'Pago o abono en cuenta deducible', '1');
INSERT INTO `cnt_formatocolumna` VALUES ('14', '1', 'O', 'Pago o abono en cuenta NO deducible', '1');
INSERT INTO `cnt_formatocolumna` VALUES ('15', '1', 'P', 'Iva mayor valor del costo o gasto deducible', '1');
INSERT INTO `cnt_formatocolumna` VALUES ('16', '1', 'Q', 'Iva mayor valor del costo o gasto NO deducible', '1');
INSERT INTO `cnt_formatocolumna` VALUES ('17', '1', 'R', 'Retención en la fuente practicada Renta', '1');
INSERT INTO `cnt_formatocolumna` VALUES ('18', '1', 'S', 'Retención en la fuente Asumida Renta', '1');
INSERT INTO `cnt_formatocolumna` VALUES ('19', '1', 'T', 'Retención en la fuente Practicada Iva Regimen Comun', '1');
INSERT INTO `cnt_formatocolumna` VALUES ('20', '1', 'U', 'Retención en la fuente Practicada Iva No Domiciliados', '1');
INSERT INTO `cnt_formatocolumna` VALUES ('21', '2', 'B', 'concepto', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('22', '2', 'C', 'tipodocumento', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('23', '2', 'D', 'documento', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('24', '2', 'E', 'dv', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('25', '2', 'F', 'priapellido', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('26', '2', 'G', 'segapellido', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('27', '2', 'H', 'prinombre', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('28', '2', 'I', 'segnombre', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('29', '2', 'J', 'razonsocial', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('30', '2', 'K', 'direccion', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('31', '2', 'L', 'codigo_departamento', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('32', '2', 'M', 'codigo_municipio', '0');
INSERT INTO `cnt_formatocolumna` VALUES ('33', '2', 'N', 'Valor acumulado del pago sujeto a Retención en la Fuente', '1');
INSERT INTO `cnt_formatocolumna` VALUES ('34', '2', 'O', 'Retención que le practicaron', '1');

-- ----------------------------
-- Table structure for cnt_formatoconcepto
-- ----------------------------
DROP TABLE IF EXISTS `cnt_formatoconcepto`;
CREATE TABLE `cnt_formatoconcepto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `IdExogenaformato` int NOT NULL,
  `IdExogenaconcepto` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_formatoconcepto_cnt_exogenaformato_1` (`IdExogenaformato`),
  KEY `fk_cnt_formatoconcepto_cnt_exogenaconcepto_1` (`IdExogenaconcepto`),
  CONSTRAINT `cnt_formatoconcepto_ibfk_1` FOREIGN KEY (`IdExogenaconcepto`) REFERENCES `cnt_exogenaconcepto` (`id`),
  CONSTRAINT `cnt_formatoconcepto_ibfk_2` FOREIGN KEY (`IdExogenaformato`) REFERENCES `cnt_exogenaformato` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_formatoconcepto
-- ----------------------------
INSERT INTO `cnt_formatoconcepto` VALUES ('1', '1', '1');
INSERT INTO `cnt_formatoconcepto` VALUES ('2', '1', '2');
INSERT INTO `cnt_formatoconcepto` VALUES ('3', '1', '3');
INSERT INTO `cnt_formatoconcepto` VALUES ('4', '2', '4');
INSERT INTO `cnt_formatoconcepto` VALUES ('5', '2', '5');
INSERT INTO `cnt_formatoconcepto` VALUES ('6', '2', '6');
INSERT INTO `cnt_formatoconcepto` VALUES ('7', '2', '9');
INSERT INTO `cnt_formatoconcepto` VALUES ('8', '2', '10');
INSERT INTO `cnt_formatoconcepto` VALUES ('9', '2', '11');
INSERT INTO `cnt_formatoconcepto` VALUES ('10', '2', '12');
INSERT INTO `cnt_formatoconcepto` VALUES ('11', '2', '13');
INSERT INTO `cnt_formatoconcepto` VALUES ('12', '2', '14');
INSERT INTO `cnt_formatoconcepto` VALUES ('13', '2', '15');
INSERT INTO `cnt_formatoconcepto` VALUES ('14', '2', '16');
INSERT INTO `cnt_formatoconcepto` VALUES ('15', '2', '17');
INSERT INTO `cnt_formatoconcepto` VALUES ('16', '2', '18');
INSERT INTO `cnt_formatoconcepto` VALUES ('17', '2', '19');
INSERT INTO `cnt_formatoconcepto` VALUES ('18', '2', '20');
INSERT INTO `cnt_formatoconcepto` VALUES ('19', '3', '21');
INSERT INTO `cnt_formatoconcepto` VALUES ('20', '3', '22');
INSERT INTO `cnt_formatoconcepto` VALUES ('21', '3', '23');
INSERT INTO `cnt_formatoconcepto` VALUES ('22', '3', '24');
INSERT INTO `cnt_formatoconcepto` VALUES ('23', '3', '25');
INSERT INTO `cnt_formatoconcepto` VALUES ('24', '3', '26');
INSERT INTO `cnt_formatoconcepto` VALUES ('25', '3', '27');
INSERT INTO `cnt_formatoconcepto` VALUES ('26', '3', '28');
INSERT INTO `cnt_formatoconcepto` VALUES ('27', '3', '29');
INSERT INTO `cnt_formatoconcepto` VALUES ('28', '3', '30');
INSERT INTO `cnt_formatoconcepto` VALUES ('29', '3', '31');
INSERT INTO `cnt_formatoconcepto` VALUES ('30', '3', '32');
INSERT INTO `cnt_formatoconcepto` VALUES ('31', '3', '33');
INSERT INTO `cnt_formatoconcepto` VALUES ('32', '3', '34');
INSERT INTO `cnt_formatoconcepto` VALUES ('33', '3', '35');
INSERT INTO `cnt_formatoconcepto` VALUES ('34', '3', '36');
INSERT INTO `cnt_formatoconcepto` VALUES ('35', '3', '37');
INSERT INTO `cnt_formatoconcepto` VALUES ('36', '3', '38');
INSERT INTO `cnt_formatoconcepto` VALUES ('37', '6', '39');
INSERT INTO `cnt_formatoconcepto` VALUES ('38', '6', '40');
INSERT INTO `cnt_formatoconcepto` VALUES ('39', '6', '41');
INSERT INTO `cnt_formatoconcepto` VALUES ('40', '6', '42');
INSERT INTO `cnt_formatoconcepto` VALUES ('41', '6', '43');
INSERT INTO `cnt_formatoconcepto` VALUES ('42', '6', '44');
INSERT INTO `cnt_formatoconcepto` VALUES ('43', '6', '45');
INSERT INTO `cnt_formatoconcepto` VALUES ('45', '7', '46');
INSERT INTO `cnt_formatoconcepto` VALUES ('46', '7', '47');
INSERT INTO `cnt_formatoconcepto` VALUES ('47', '7', '48');
INSERT INTO `cnt_formatoconcepto` VALUES ('48', '7', '49');
INSERT INTO `cnt_formatoconcepto` VALUES ('49', '7', '50');
INSERT INTO `cnt_formatoconcepto` VALUES ('50', '7', '51');
INSERT INTO `cnt_formatoconcepto` VALUES ('51', '8', '52');
INSERT INTO `cnt_formatoconcepto` VALUES ('52', '8', '53');
INSERT INTO `cnt_formatoconcepto` VALUES ('53', '8', '54');
INSERT INTO `cnt_formatoconcepto` VALUES ('54', '8', '55');
INSERT INTO `cnt_formatoconcepto` VALUES ('55', '8', '56');
INSERT INTO `cnt_formatoconcepto` VALUES ('56', '8', '57');
INSERT INTO `cnt_formatoconcepto` VALUES ('57', '8', '58');
INSERT INTO `cnt_formatoconcepto` VALUES ('58', '8', '59');
INSERT INTO `cnt_formatoconcepto` VALUES ('59', '8', '60');
INSERT INTO `cnt_formatoconcepto` VALUES ('60', '8', '61');
INSERT INTO `cnt_formatoconcepto` VALUES ('61', '8', '62');
INSERT INTO `cnt_formatoconcepto` VALUES ('62', '8', '63');
INSERT INTO `cnt_formatoconcepto` VALUES ('63', '10', '64');
INSERT INTO `cnt_formatoconcepto` VALUES ('64', '10', '65');
INSERT INTO `cnt_formatoconcepto` VALUES ('65', '10', '66');
INSERT INTO `cnt_formatoconcepto` VALUES ('66', '10', '67');
INSERT INTO `cnt_formatoconcepto` VALUES ('67', '10', '68');
INSERT INTO `cnt_formatoconcepto` VALUES ('68', '10', '69');
INSERT INTO `cnt_formatoconcepto` VALUES ('69', '10', '70');
INSERT INTO `cnt_formatoconcepto` VALUES ('70', '10', '71');
INSERT INTO `cnt_formatoconcepto` VALUES ('71', '10', '72');
INSERT INTO `cnt_formatoconcepto` VALUES ('72', '10', '73');
INSERT INTO `cnt_formatoconcepto` VALUES ('73', '10', '74');
INSERT INTO `cnt_formatoconcepto` VALUES ('74', '10', '75');
INSERT INTO `cnt_formatoconcepto` VALUES ('75', '10', '76');
INSERT INTO `cnt_formatoconcepto` VALUES ('76', '10', '77');
INSERT INTO `cnt_formatoconcepto` VALUES ('77', '10', '78');
INSERT INTO `cnt_formatoconcepto` VALUES ('78', '10', '79');
INSERT INTO `cnt_formatoconcepto` VALUES ('79', '10', '80');

-- ----------------------------
-- Table structure for cnt_genero
-- ----------------------------
DROP TABLE IF EXISTS `cnt_genero`;
CREATE TABLE `cnt_genero` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_genero
-- ----------------------------
INSERT INTO `cnt_genero` VALUES ('1', 'F', 'FEMENINO');
INSERT INTO `cnt_genero` VALUES ('2', 'M', 'MASCULINO');
INSERT INTO `cnt_genero` VALUES ('3', 'NB', 'NO BINARIO');
INSERT INTO `cnt_genero` VALUES ('4', 'NA', 'NO APLICA');

-- ----------------------------
-- Table structure for cnt_liquidaimpuesto
-- ----------------------------
DROP TABLE IF EXISTS `cnt_liquidaimpuesto`;
CREATE TABLE `cnt_liquidaimpuesto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_tipoimpuesto` int NOT NULL,
  `id_comprobante` int NOT NULL,
  `id_puc` int NOT NULL,
  `id_tercero` int NOT NULL,
  `lim_fechainicial` date NOT NULL DEFAULT '0000-00-00',
  `lim_fechafinal` date NOT NULL DEFAULT '0000-00-00',
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `estado` varchar(1) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'A',
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_liquidaimpuesto_cnt_tipoimpuesto_1` (`id_tipoimpuesto`),
  KEY `fk_cnt_liquidaimpuesto_cnt_tercero_1` (`id_tercero`),
  KEY `fk_cnt_liquidaimpuesto_cnt_pucauxcuenta_1` (`id_puc`),
  KEY `fk_cnt_liquidaimpuesto_cnt_comprobante_1` (`id_comprobante`),
  CONSTRAINT `fk_cnt_liquidaimpuesto_cnt_comprobante_1` FOREIGN KEY (`id_comprobante`) REFERENCES `cnt_comprobante` (`id`),
  CONSTRAINT `fk_cnt_liquidaimpuesto_cnt_pucauxcuenta_1` FOREIGN KEY (`id_puc`) REFERENCES `cnt_puc` (`id`),
  CONSTRAINT `fk_cnt_liquidaimpuesto_cnt_tercero_1` FOREIGN KEY (`id_tercero`) REFERENCES `cnt_tercero` (`id`),
  CONSTRAINT `fk_cnt_liquidaimpuesto_cnt_tipoimpuesto_1` FOREIGN KEY (`id_tipoimpuesto`) REFERENCES `cnt_tipoimpuesto` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_liquidaimpuesto
-- ----------------------------
INSERT INTO `cnt_liquidaimpuesto` VALUES ('2', '1', '20', '20', '5', '2021-10-05', '2021-10-31', '2021-10-05 16:32:50', '2021-10-16 09:42:58', 'A');
INSERT INTO `cnt_liquidaimpuesto` VALUES ('3', '5', '43', '7', '2', '2021-10-07', '2021-10-27', '2021-10-05 16:33:41', '2021-10-15 10:41:54', 'A');
INSERT INTO `cnt_liquidaimpuesto` VALUES ('4', '5', '44', '27', '2', '2021-10-07', '2021-10-27', '2021-10-05 16:33:41', '2021-10-15 10:41:54', 'A');

-- ----------------------------
-- Table structure for cnt_mes
-- ----------------------------
DROP TABLE IF EXISTS `cnt_mes`;
CREATE TABLE `cnt_mes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `mes_ano` int NOT NULL,
  `mes_mes` int NOT NULL,
  `mes_cerrado` tinyint(1) NOT NULL DEFAULT '0',
  `id_usuario` varchar(255) NOT NULL DEFAULT '',
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_mes_cnf_usuario_1` (`id_usuario`),
  CONSTRAINT `fk_cnt_mes_cnf_usuario_1` FOREIGN KEY (`id_usuario`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_mes
-- ----------------------------
INSERT INTO `cnt_mes` VALUES ('1', '2020', '12', '0', '1', '2021-06-28 16:25:53', '2021-06-28 16:26:23');

-- ----------------------------
-- Table structure for cnt_modulos
-- ----------------------------
DROP TABLE IF EXISTS `cnt_modulos`;
CREATE TABLE `cnt_modulos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` int NOT NULL DEFAULT '0',
  `nombre` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of cnt_modulos
-- ----------------------------
INSERT INTO `cnt_modulos` VALUES ('1', '1', 'Contabilidad');
INSERT INTO `cnt_modulos` VALUES ('2', '2', 'Liquidacion de impuestos ');

-- ----------------------------
-- Table structure for cnt_municipio
-- ----------------------------
DROP TABLE IF EXISTS `cnt_municipio`;
CREATE TABLE `cnt_municipio` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(3) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `codigo_departamento` char(3) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `id_departamento` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_municipio_cnt_departamento_1` (`codigo_departamento`) USING BTREE,
  KEY `cnt_municipio_ibfk_1` (`id_departamento`) USING BTREE,
  CONSTRAINT `cnt_municipio_ibfk_1` FOREIGN KEY (`id_departamento`) REFERENCES `cnt_departamento` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=1123 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_municipio
-- ----------------------------
INSERT INTO `cnt_municipio` VALUES ('1', '001', 'MEDELLIN', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('2', '002', 'ABEJORRAL', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('3', '004', 'ABRIAQUI', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('4', '021', 'ALEJANDRIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('5', '030', 'AMAGA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('6', '031', 'AMALFI', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('7', '034', 'ANDES', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('8', '036', 'ANGELOPOLIS', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('9', '038', 'ANGOSTURA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('10', '040', 'ANORI', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('11', '042', 'SANTAFE DE ANTIOQUIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('12', '044', 'ANZA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('13', '045', 'APARTADO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('14', '051', 'ARBOLETES', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('15', '055', 'ARGELIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('16', '059', 'ARMENIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('17', '079', 'BARBOSA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('18', '086', 'BELMIRA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('19', '088', 'BELLO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('20', '091', 'BETANIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('21', '093', 'BETULIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('22', '101', 'CIUDAD BOLIVAR', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('23', '107', 'BRICEÑO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('24', '113', 'BURITICA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('25', '120', 'CACERES', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('26', '125', 'CAICEDO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('27', '129', 'CALDAS', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('28', '134', 'CAMPAMENTO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('29', '138', 'CAÑASGORDAS', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('30', '142', 'CARACOLI', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('31', '145', 'CARAMANTA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('32', '147', 'CAREPA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('33', '148', 'EL CARMEN DE VIBORAL', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('34', '150', 'CAROLINA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('35', '154', 'CAUCASIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('36', '172', 'CHIGORODO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('37', '190', 'CISNEROS', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('38', '197', 'COCORNA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('39', '206', 'CONCEPCION', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('40', '209', 'CONCORDIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('41', '212', 'COPACABANA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('42', '234', 'DABEIBA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('43', '237', 'DON MATIAS', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('44', '240', 'EBEJICO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('45', '250', 'EL BAGRE', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('46', '264', 'ENTRERRIOS', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('47', '266', 'ENVIGADO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('48', '282', 'FREDONIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('49', '284', 'FRONTINO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('50', '306', 'GIRALDO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('51', '308', 'GIRARDOTA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('52', '310', 'GOMEZ PLATA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('53', '313', 'GRANADA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('54', '315', 'GUADALUPE', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('55', '318', 'GUARNE', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('56', '321', 'GUATAPE', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('57', '347', 'HELICONIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('58', '353', 'HISPANIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('59', '360', 'ITAGUI', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('60', '361', 'ITUANGO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('61', '364', 'JARDIN', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('62', '368', 'JERICO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('63', '376', 'LA CEJA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('64', '380', 'LA ESTRELLA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('65', '390', 'LA PINTADA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('66', '400', 'LA UNION', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('67', '411', 'LIBORINA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('68', '425', 'MACEO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('69', '440', 'MARINILLA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('70', '467', 'MONTEBELLO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('71', '475', 'MURINDO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('72', '480', 'MUTATA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('73', '483', 'NARIÑO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('74', '490', 'NECOCLI', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('75', '495', 'NECHI', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('76', '501', 'OLAYA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('77', '541', 'PEÐOL', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('78', '543', 'PEQUE', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('79', '576', 'PUEBLORRICO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('80', '579', 'PUERTO BERRIO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('81', '585', 'PUERTO NARE', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('82', '591', 'PUERTO TRIUNFO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('83', '604', 'REMEDIOS', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('84', '607', 'RETIRO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('85', '615', 'RIONEGRO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('86', '628', 'SABANALARGA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('87', '631', 'SABANETA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('88', '642', 'SALGAR', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('89', '647', 'SAN ANDRES DE CUERQUIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('90', '649', 'SAN CARLOS', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('91', '652', 'SAN FRANCISCO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('92', '656', 'SAN JERONIMO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('93', '658', 'SAN JOSE DE LA MONTAÑA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('94', '659', 'SAN JUAN DE URABA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('95', '660', 'SAN LUIS', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('96', '664', 'SAN PEDRO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('97', '665', 'SAN PEDRO DE URABA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('98', '667', 'SAN RAFAEL', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('99', '670', 'SAN ROQUE', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('100', '674', 'SAN VICENTE', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('101', '679', 'SANTA BARBARA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('102', '686', 'SANTA ROSA DE OSOS', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('103', '690', 'SANTO DOMINGO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('104', '697', 'EL SANTUARIO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('105', '736', 'SEGOVIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('106', '756', 'SONSON', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('107', '761', 'SOPETRAN', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('108', '789', 'TAMESIS', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('109', '790', 'TARAZA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('110', '792', 'TARSO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('111', '809', 'TITIRIBI', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('112', '819', 'TOLEDO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('113', '837', 'TURBO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('114', '842', 'URAMITA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('115', '847', 'URRAO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('116', '854', 'VALDIVIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('117', '856', 'VALPARAISO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('118', '858', 'VEGACHI', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('119', '861', 'VENECIA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('120', '873', 'VIGIA DEL FUERTE', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('121', '885', 'YALI', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('122', '887', 'YARUMAL', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('123', '890', 'YOLOMBO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('124', '893', 'YONDO', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('125', '895', 'ZARAGOZA', '05', '1');
INSERT INTO `cnt_municipio` VALUES ('126', '001', 'DISTRITO DE BARRANQUILLA', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('127', '078', 'BARANOA', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('128', '137', 'CAMPO DE LA CRUZ', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('129', '141', 'CANDELARIA', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('130', '296', 'GALAPA', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('131', '372', 'JUAN DE ACOSTA', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('132', '421', 'LURUACO', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('133', '433', 'MALAMBO', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('134', '436', 'MANATI', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('135', '520', 'PALMAR DE VARELA', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('136', '549', 'PIOJO', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('137', '558', 'POLONUEVO', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('138', '560', 'PONEDERA', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('139', '573', 'PUERTO COLOMBIA', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('140', '606', 'REPELON', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('141', '634', 'SABANAGRANDE', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('142', '638', 'SABANALARGA', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('143', '675', 'SANTA LUCIA', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('144', '685', 'SANTO TOMAS', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('145', '758', 'SOLEDAD', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('146', '770', 'SUAN', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('147', '832', 'TUBARA', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('148', '849', 'USIACURI', '08', '2');
INSERT INTO `cnt_municipio` VALUES ('149', '001', 'BOGOTA, D.C.', '11', '3');
INSERT INTO `cnt_municipio` VALUES ('150', '001', 'CARTAGENA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('151', '006', 'ACHI', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('152', '030', 'ALTOS DEL ROSARIO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('153', '042', 'ARENAL', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('154', '052', 'ARJONA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('155', '062', 'ARROYOHONDO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('156', '074', 'BARRANCO DE LOBA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('157', '140', 'CALAMAR', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('158', '160', 'CANTAGALLO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('159', '188', 'CICUCO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('160', '212', 'CORDOBA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('161', '222', 'CLEMENCIA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('162', '244', 'EL CARMEN DE BOLIVAR', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('163', '248', 'EL GUAMO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('164', '268', 'EL PEÑON', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('165', '300', 'HATILLO DE LOBA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('166', '430', 'MAGANGUE', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('167', '433', 'MAHATES', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('168', '440', 'MARGARITA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('169', '442', 'MARIA LA BAJA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('170', '458', 'MONTECRISTO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('171', '468', 'MOMPOS', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('172', '473', 'MORALES', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('173', '490', 'NOROSI', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('174', '549', 'PINILLOS', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('175', '580', 'REGIDOR', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('176', '600', 'RIO VIEJO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('177', '620', 'SAN CRISTOBAL', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('178', '647', 'SAN ESTANISLAO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('179', '650', 'SAN FERNANDO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('180', '654', 'SAN JACINTO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('181', '655', 'SAN JACINTO DEL CAUCA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('182', '657', 'SAN JUAN NEPOMUCENO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('183', '667', 'SAN MARTIN DE LOBA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('184', '670', 'SAN PABLO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('185', '673', 'SANTA CATALINA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('186', '683', 'SANTA ROSA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('187', '688', 'SANTA ROSA DEL SUR', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('188', '744', 'SIMITI', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('189', '760', 'SOPLAVIENTO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('190', '780', 'TALAIGUA NUEVO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('191', '810', 'TIQUISIO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('192', '836', 'TURBACO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('193', '838', 'TURBANA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('194', '873', 'VILLANUEVA', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('195', '894', 'ZAMBRANO', '13', '4');
INSERT INTO `cnt_municipio` VALUES ('196', '001', 'TUNJA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('197', '022', 'ALMEIDA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('198', '047', 'AQUITANIA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('199', '051', 'ARCABUCO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('200', '087', 'BELEN', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('201', '090', 'BERBEO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('202', '092', 'BETEITIVA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('203', '097', 'BOAVITA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('204', '104', 'BOYACA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('205', '106', 'BRICEÑO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('206', '109', 'BUENAVISTA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('207', '114', 'BUSBANZA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('208', '131', 'CALDAS', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('209', '135', 'CAMPOHERMOSO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('210', '162', 'CERINZA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('211', '172', 'CHINAVITA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('212', '176', 'CHIQUINQUIRA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('213', '180', 'CHISCAS', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('214', '183', 'CHITA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('215', '185', 'CHITARAQUE', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('216', '187', 'CHIVATA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('217', '189', 'CIENEGA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('218', '204', 'COMBITA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('219', '212', 'COPER', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('220', '215', 'CORRALES', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('221', '218', 'COVARACHIA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('222', '223', 'CUBARA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('223', '224', 'CUCAITA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('224', '226', 'CUITIVA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('225', '232', 'CHIQUIZA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('226', '236', 'CHIVOR', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('227', '238', 'DUITAMA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('228', '244', 'EL COCUY', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('229', '248', 'EL ESPINO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('230', '272', 'FIRAVITOBA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('231', '276', 'FLORESTA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('232', '293', 'GACHANTIVA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('233', '296', 'GAMEZA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('234', '299', 'GARAGOA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('235', '317', 'GUACAMAYAS', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('236', '322', 'GUATEQUE', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('237', '325', 'GUAYATA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('238', '332', 'GsICAN', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('239', '362', 'IZA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('240', '367', 'JENESANO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('241', '368', 'JERICO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('242', '377', 'LABRANZAGRANDE', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('243', '380', 'LA CAPILLA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('244', '401', 'LA VICTORIA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('245', '403', 'LA UVITA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('246', '407', 'VILLA DE LEYVA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('247', '425', 'MACANAL', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('248', '442', 'MARIPI', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('249', '455', 'MIRAFLORES', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('250', '464', 'MONGUA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('251', '466', 'MONGUI', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('252', '469', 'MONIQUIRA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('253', '476', 'MOTAVITA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('254', '480', 'MUZO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('255', '491', 'NOBSA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('256', '494', 'NUEVO COLON', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('257', '500', 'OICATA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('258', '507', 'OTANCHE', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('259', '511', 'PACHAVITA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('260', '514', 'PAEZ', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('261', '516', 'PAIPA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('262', '518', 'PAJARITO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('263', '522', 'PANQUEBA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('264', '531', 'PAUNA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('265', '533', 'PAYA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('266', '537', 'PAZ DE RIO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('267', '542', 'PESCA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('268', '550', 'PISBA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('269', '572', 'PUERTO BOYACA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('270', '580', 'QUIPAMA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('271', '599', 'RAMIRIQUI', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('272', '600', 'RAQUIRA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('273', '621', 'RONDON', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('274', '632', 'SABOYA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('275', '638', 'SACHICA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('276', '646', 'SAMACA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('277', '660', 'SAN EDUARDO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('278', '664', 'SAN JOSE DE PARE', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('279', '667', 'SAN LUIS DE GACENO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('280', '673', 'SAN MATEO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('281', '676', 'SAN MIGUEL DE SEMA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('282', '681', 'SAN PABLO DE BORBUR', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('283', '686', 'SANTANA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('284', '690', 'SANTA MARIA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('285', '693', 'SANTA ROSA DE VITERBO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('286', '696', 'SANTA SOFIA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('287', '720', 'SATIVANORTE', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('288', '723', 'SATIVASUR', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('289', '740', 'SIACHOQUE', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('290', '753', 'SOATA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('291', '755', 'SOCOTA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('292', '757', 'SOCHA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('293', '759', 'SOGAMOSO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('294', '761', 'SOMONDOCO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('295', '762', 'SORA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('296', '763', 'SOTAQUIRA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('297', '764', 'SORACA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('298', '774', 'SUSACON', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('299', '776', 'SUTAMARCHAN', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('300', '778', 'SUTATENZA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('301', '790', 'TASCO', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('302', '798', 'TENZA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('303', '804', 'TIBANA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('304', '806', 'TIBASOSA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('305', '808', 'TINJACA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('306', '810', 'TIPACOQUE', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('307', '814', 'TOCA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('308', '816', 'TOGsI', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('309', '820', 'TOPAGA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('310', '822', 'TOTA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('311', '832', 'TUNUNGUA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('312', '835', 'TURMEQUE', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('313', '837', 'TUTA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('314', '839', 'TUTAZA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('315', '842', 'UMBITA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('316', '861', 'VENTAQUEMADA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('317', '879', 'VIRACACHA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('318', '897', 'ZETAQUIRA', '15', '5');
INSERT INTO `cnt_municipio` VALUES ('319', '001', 'MANIZALES', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('320', '013', 'AGUADAS', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('321', '042', 'ANSERMA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('322', '050', 'ARANZAZU', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('323', '088', 'BELALCAZAR', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('324', '174', 'CHINCHINA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('325', '272', 'FILADELFIA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('326', '380', 'LA DORADA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('327', '388', 'LA MERCED', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('328', '433', 'MANZANARES', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('329', '442', 'MARMATO', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('330', '444', 'MARQUETALIA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('331', '446', 'MARULANDA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('332', '486', 'NEIRA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('333', '495', 'NORCASIA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('334', '513', 'PACORA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('335', '524', 'PALESTINA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('336', '541', 'PENSILVANIA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('337', '614', 'RIOSUCIO', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('338', '616', 'RISARALDA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('339', '653', 'SALAMINA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('340', '662', 'SAMANA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('341', '665', 'SAN JOSE', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('342', '777', 'SUPIA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('343', '867', 'VICTORIA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('344', '873', 'VILLAMARIA', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('345', '877', 'VITERBO', '17', '6');
INSERT INTO `cnt_municipio` VALUES ('346', '001', 'FLORENCIA', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('347', '029', 'ALBANIA', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('348', '094', 'BELEN DE LOS ANDAQUIES', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('349', '150', 'CARTAGENA DEL CHAIRA', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('350', '205', 'CURILLO', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('351', '247', 'EL DONCELLO', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('352', '256', 'EL PAUJIL', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('353', '410', 'LA MONTAÑITA', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('354', '460', 'MILAN', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('355', '479', 'MORELIA', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('356', '592', 'PUERTO RICO', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('357', '610', 'SAN JOSE DEL FRAGUA', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('358', '753', 'SAN VICENTE DEL CAGUAN', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('359', '756', 'SOLANO', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('360', '785', 'SOLITA', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('361', '860', 'VALPARAISO', '18', '7');
INSERT INTO `cnt_municipio` VALUES ('362', '001', 'POPAYAN', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('363', '022', 'ALMAGUER', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('364', '050', 'ARGELIA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('365', '075', 'BALBOA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('366', '100', 'BOLIVAR', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('367', '110', 'BUENOS AIRES', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('368', '130', 'CAJIBIO', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('369', '137', 'CALDONO', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('370', '142', 'CALOTO', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('371', '212', 'CORINTO', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('372', '256', 'EL TAMBO', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('373', '290', 'FLORENCIA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('374', '300', 'GUACHENE', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('375', '318', 'GUAPI', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('376', '355', 'INZA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('377', '364', 'JAMBALO', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('378', '392', 'LA SIERRA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('379', '397', 'LA VEGA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('380', '418', 'LOPEZ', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('381', '450', 'MERCADERES', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('382', '455', 'MIRANDA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('383', '473', 'MORALES', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('384', '513', 'PADILLA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('385', '517', 'PAEZ', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('386', '532', 'PATIA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('387', '533', 'PIAMONTE', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('388', '548', 'PIENDAMO', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('389', '573', 'PUERTO TEJADA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('390', '585', 'PURACE', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('391', '622', 'ROSAS', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('392', '693', 'SAN SEBASTIAN', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('393', '698', 'SANTANDER DE QUILICHAO', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('394', '701', 'SANTA ROSA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('395', '743', 'SILVIA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('396', '760', 'SOTARA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('397', '780', 'SUAREZ', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('398', '785', 'SUCRE', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('399', '807', 'TIMBIO', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('400', '809', 'TIMBIQUI', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('401', '821', 'TORIBIO', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('402', '824', 'TOTORO', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('403', '845', 'VILLA RICA', '19', '8');
INSERT INTO `cnt_municipio` VALUES ('404', '001', 'VALLEDUPAR', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('405', '011', 'AGUACHICA', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('406', '013', 'AGUSTIN CODAZZI', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('407', '032', 'ASTREA', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('408', '045', 'BECERRIL', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('409', '060', 'BOSCONIA', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('410', '175', 'CHIMICHAGUA', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('411', '178', 'CHIRIGUANA', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('412', '228', 'CURUMANI', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('413', '238', 'EL COPEY', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('414', '250', 'EL PASO', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('415', '295', 'GAMARRA', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('416', '310', 'GONZALEZ', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('417', '383', 'LA GLORIA', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('418', '400', 'LA JAGUA DE IBIRICO', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('419', '443', 'MANAURE', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('420', '517', 'PAILITAS', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('421', '550', 'PELAYA', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('422', '570', 'PUEBLO BELLO', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('423', '614', 'RIO DE ORO', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('424', '621', 'LA PAZ', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('425', '710', 'SAN ALBERTO', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('426', '750', 'SAN DIEGO', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('427', '770', 'SAN MARTIN', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('428', '787', 'TAMALAMEQUE', '20', '9');
INSERT INTO `cnt_municipio` VALUES ('429', '001', 'MONTERIA', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('430', '068', 'AYAPEL', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('431', '079', 'BUENAVISTA', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('432', '090', 'CANALETE', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('433', '162', 'CERETE', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('434', '168', 'CHIMA', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('435', '182', 'CHINU', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('436', '189', 'CIENAGA DE ORO', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('437', '300', 'COTORRA', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('438', '350', 'LA APARTADA', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('439', '417', 'SANTA CRUZ DE LORICA', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('440', '419', 'LOS CORDOBAS', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('441', '464', 'MOMIL', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('442', '466', 'MONTELIBANO', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('443', '500', 'MOÑITOS', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('444', '555', 'PLANETA RICA', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('445', '570', 'PUEBLO NUEVO', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('446', '574', 'PUERTO ESCONDIDO', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('447', '580', 'PUERTO LIBERTADOR', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('448', '586', 'PURISIMA', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('449', '660', 'SAHAGUN', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('450', '670', 'SAN ANDRES SOTAVENTO', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('451', '672', 'SAN ANTERO', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('452', '675', 'SAN BERNARDO DEL VIENTO', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('453', '678', 'SAN CARLOS', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('454', '682', 'SAN JOSE DE URE', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('455', '686', 'SAN PELAYO', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('456', '807', 'TIERRALTA', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('457', '815', 'TUCHIN', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('458', '855', 'VALENCIA', '23', '10');
INSERT INTO `cnt_municipio` VALUES ('459', '001', 'AGUA DE DIOS', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('460', '019', 'ALBAN', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('461', '035', 'ANAPOIMA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('462', '040', 'ANOLAIMA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('463', '053', 'ARBELAEZ', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('464', '086', 'BELTRAN', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('465', '095', 'BITUIMA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('466', '099', 'BOJACA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('467', '120', 'CABRERA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('468', '123', 'CACHIPAY', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('469', '126', 'CAJICA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('470', '148', 'CAPARRAPI', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('471', '151', 'CAQUEZA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('472', '154', 'CARMEN DE CARUPA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('473', '168', 'CHAGUANI', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('474', '175', 'CHIA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('475', '178', 'CHIPAQUE', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('476', '181', 'CHOACHI', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('477', '183', 'CHOCONTA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('478', '200', 'COGUA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('479', '214', 'COTA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('480', '224', 'CUCUNUBA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('481', '245', 'EL COLEGIO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('482', '258', 'EL PEÑON', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('483', '260', 'EL ROSAL', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('484', '269', 'FACATATIVA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('485', '279', 'FOMEQUE', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('486', '281', 'FOSCA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('487', '286', 'FUNZA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('488', '288', 'FUQUENE', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('489', '290', 'FUSAGASUGA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('490', '293', 'GACHALA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('491', '295', 'GACHANCIPA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('492', '297', 'GACHETA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('493', '299', 'GAMA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('494', '307', 'GIRARDOT', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('495', '312', 'GRANADA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('496', '317', 'GUACHETA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('497', '320', 'GUADUAS', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('498', '322', 'GUASCA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('499', '324', 'GUATAQUI', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('500', '326', 'GUATAVITA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('501', '328', 'GUAYABAL DE SIQUIMA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('502', '335', 'GUAYABETAL', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('503', '339', 'GUTIERREZ', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('504', '368', 'JERUSALEN', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('505', '372', 'JUNIN', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('506', '377', 'LA CALERA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('507', '386', 'LA MESA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('508', '394', 'LA PALMA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('509', '398', 'LA PEÑA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('510', '402', 'LA VEGA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('511', '407', 'LENGUAZAQUE', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('512', '426', 'MACHETA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('513', '430', 'MADRID', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('514', '436', 'MANTA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('515', '438', 'MEDINA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('516', '473', 'MOSQUERA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('517', '483', 'NARIÑO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('518', '486', 'NEMOCON', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('519', '488', 'NILO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('520', '489', 'NIMAIMA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('521', '491', 'NOCAIMA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('522', '506', 'VENECIA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('523', '513', 'PACHO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('524', '518', 'PAIME', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('525', '524', 'PANDI', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('526', '530', 'PARATEBUENO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('527', '535', 'PASCA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('528', '572', 'PUERTO SALGAR', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('529', '580', 'PULI', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('530', '592', 'QUEBRADANEGRA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('531', '594', 'QUETAME', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('532', '596', 'QUIPILE', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('533', '599', 'APULO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('534', '612', 'RICAURTE', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('535', '645', 'SAN ANTONIO DEL TEQUENDAMA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('536', '649', 'SAN BERNARDO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('537', '653', 'SAN CAYETANO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('538', '658', 'SAN FRANCISCO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('539', '662', 'SAN JUAN DE RIO SECO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('540', '718', 'SASAIMA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('541', '736', 'SESQUILE', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('542', '740', 'SIBATE', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('543', '743', 'SILVANIA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('544', '745', 'SIMIJACA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('545', '754', 'SOACHA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('546', '758', 'SOPO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('547', '769', 'SUBACHOQUE', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('548', '772', 'SUESCA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('549', '777', 'SUPATA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('550', '779', 'SUSA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('551', '781', 'SUTATAUSA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('552', '785', 'TABIO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('553', '793', 'TAUSA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('554', '797', 'TENA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('555', '799', 'TENJO', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('556', '805', 'TIBACUY', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('557', '807', 'TIBIRITA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('558', '815', 'TOCAIMA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('559', '817', 'TOCANCIPA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('560', '823', 'TOPAIPI', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('561', '839', 'UBALA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('562', '841', 'UBAQUE', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('563', '843', 'VILLA DE SAN DIEGO DE UBATE', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('564', '845', 'UNE', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('565', '851', 'UTICA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('566', '862', 'VERGARA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('567', '867', 'VIANI', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('568', '871', 'VILLAGOMEZ', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('569', '873', 'VILLAPINZON', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('570', '875', 'VILLETA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('571', '878', 'VIOTA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('572', '885', 'YACOPI', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('573', '898', 'ZIPACON', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('574', '899', 'ZIPAQUIRA', '25', '11');
INSERT INTO `cnt_municipio` VALUES ('575', '001', 'QUIBDO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('576', '006', 'ACANDI', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('577', '025', 'ALTO BAUDO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('578', '050', 'ATRATO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('579', '073', 'BAGADO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('580', '075', 'BAHIA SOLANO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('581', '077', 'BAJO BAUDO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('582', '099', 'BOJAYA', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('583', '135', 'EL CANTON DEL SAN PABLO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('584', '150', 'CARMEN DEL DARIEN', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('585', '160', 'CERTEGUI', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('586', '205', 'CONDOTO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('587', '245', 'EL CARMEN DE ATRATO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('588', '250', 'EL LITORAL DEL SAN JUAN', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('589', '361', 'ISTMINA', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('590', '372', 'JURADO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('591', '413', 'LLORO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('592', '425', 'MEDIO ATRATO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('593', '430', 'MEDIO BAUDO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('594', '450', 'MEDIO SAN JUAN', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('595', '491', 'NOVITA', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('596', '495', 'NUQUI', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('597', '580', 'RIO IRO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('598', '600', 'RIO QUITO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('599', '615', 'RIOSUCIO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('600', '660', 'SAN JOSE DEL PALMAR', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('601', '745', 'SIPI', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('602', '787', 'TADO', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('603', '800', 'UNGUIA', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('604', '810', 'UNION PANAMERICANA', '27', '12');
INSERT INTO `cnt_municipio` VALUES ('605', '001', 'NEIVA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('606', '006', 'ACEVEDO', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('607', '013', 'AGRADO', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('608', '016', 'AIPE', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('609', '020', 'ALGECIRAS', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('610', '026', 'ALTAMIRA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('611', '078', 'BARAYA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('612', '132', 'CAMPOALEGRE', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('613', '206', 'COLOMBIA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('614', '244', 'ELIAS', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('615', '298', 'GARZON', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('616', '306', 'GIGANTE', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('617', '319', 'GUADALUPE', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('618', '349', 'HOBO', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('619', '357', 'IQUIRA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('620', '359', 'ISNOS', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('621', '378', 'LA ARGENTINA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('622', '396', 'LA PLATA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('623', '483', 'NATAGA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('624', '503', 'OPORAPA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('625', '518', 'PAICOL', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('626', '524', 'PALERMO', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('627', '530', 'PALESTINA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('628', '548', 'PITAL', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('629', '551', 'PITALITO', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('630', '615', 'RIVERA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('631', '660', 'SALADOBLANCO', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('632', '668', 'SAN AGUSTIN', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('633', '676', 'SANTA MARIA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('634', '770', 'SUAZA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('635', '791', 'TARQUI', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('636', '797', 'TESALIA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('637', '799', 'TELLO', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('638', '801', 'TERUEL', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('639', '807', 'TIMANA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('640', '872', 'VILLAVIEJA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('641', '885', 'YAGUARA', '41', '13');
INSERT INTO `cnt_municipio` VALUES ('642', '001', 'RIOHACHA', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('643', '035', 'ALBANIA', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('644', '078', 'BARRANCAS', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('645', '090', 'DIBULLA', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('646', '098', 'DISTRACCION', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('647', '110', 'EL MOLINO', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('648', '279', 'FONSECA', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('649', '378', 'HATONUEVO', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('650', '420', 'LA JAGUA DEL PILAR', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('651', '430', 'MAICAO', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('652', '560', 'MANAURE', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('653', '650', 'SAN JUAN DEL CESAR', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('654', '847', 'URIBIA', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('655', '855', 'URUMITA', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('656', '874', 'VILLANUEVA', '44', '14');
INSERT INTO `cnt_municipio` VALUES ('657', '001', 'SANTA MARTA', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('658', '030', 'ALGARROBO', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('659', '053', 'ARACATACA', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('660', '058', 'ARIGUANI', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('661', '161', 'CERRO SAN ANTONIO', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('662', '170', 'CHIBOLO', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('663', '189', 'CIENAGA', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('664', '205', 'CONCORDIA', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('665', '245', 'EL BANCO', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('666', '258', 'EL PIÑON', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('667', '268', 'EL RETEN', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('668', '288', 'FUNDACION', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('669', '318', 'GUAMAL', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('670', '460', 'NUEVA GRANADA', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('671', '541', 'PEDRAZA', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('672', '545', 'PIJIÑO DEL CARMEN', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('673', '551', 'PIVIJAY', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('674', '555', 'PLATO', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('675', '570', 'PUEBLOVIEJO', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('676', '605', 'REMOLINO', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('677', '660', 'SABANAS DE SAN ANGEL', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('678', '675', 'SALAMINA', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('679', '692', 'SAN SEBASTIAN DE BUENAVISTA', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('680', '703', 'SAN ZENON', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('681', '707', 'SANTA ANA', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('682', '720', 'SANTA BARBARA DE PINTO', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('683', '745', 'SITIONUEVO', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('684', '798', 'TENERIFE', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('685', '960', 'ZAPAYAN', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('686', '980', 'ZONA BANANERA', '47', '15');
INSERT INTO `cnt_municipio` VALUES ('687', '001', 'VILLAVICENCIO', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('688', '006', 'ACACIAS', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('689', '110', 'BARRANCA DE UPIA', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('690', '124', 'CABUYARO', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('691', '150', 'CASTILLA LA NUEVA', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('692', '223', 'CUBARRAL', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('693', '226', 'CUMARAL', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('694', '245', 'EL CALVARIO', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('695', '251', 'EL CASTILLO', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('696', '270', 'EL DORADO', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('697', '287', 'FUENTE DE ORO', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('698', '313', 'GRANADA', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('699', '318', 'GUAMAL', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('700', '325', 'MAPIRIPAN', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('701', '330', 'MESETAS', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('702', '350', 'LA MACARENA', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('703', '370', 'URIBE', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('704', '400', 'LEJANIAS', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('705', '450', 'PUERTO CONCORDIA', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('706', '568', 'PUERTO GAITAN', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('707', '573', 'PUERTO LOPEZ', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('708', '577', 'PUERTO LLERAS', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('709', '590', 'PUERTO RICO', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('710', '606', 'RESTREPO', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('711', '680', 'SAN CARLOS DE GUAROA', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('712', '683', 'SAN JUAN DE ARAMA', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('713', '686', 'SAN JUANITO', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('714', '689', 'SAN MARTIN', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('715', '711', 'VISTAHERMOSA', '50', '16');
INSERT INTO `cnt_municipio` VALUES ('716', '001', 'PASTO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('717', '019', 'ALBAN', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('718', '022', 'ALDANA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('719', '036', 'ANCUYA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('720', '051', 'ARBOLEDA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('721', '079', 'BARBACOAS', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('722', '083', 'BELEN', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('723', '110', 'BUESACO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('724', '203', 'COLON', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('725', '207', 'CONSACA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('726', '210', 'CONTADERO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('727', '215', 'CORDOBA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('728', '224', 'CUASPUD', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('729', '227', 'CUMBAL', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('730', '233', 'CUMBITARA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('731', '240', 'CHACHAGsI', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('732', '250', 'EL CHARCO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('733', '254', 'EL PEÑOL', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('734', '256', 'EL ROSARIO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('735', '258', 'EL TABLON DE GOMEZ', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('736', '260', 'EL TAMBO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('737', '287', 'FUNES', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('738', '317', 'GUACHUCAL', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('739', '320', 'GUAITARILLA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('740', '323', 'GUALMATAN', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('741', '352', 'ILES', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('742', '354', 'IMUES', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('743', '356', 'IPIALES', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('744', '378', 'LA CRUZ', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('745', '381', 'LA FLORIDA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('746', '385', 'LA LLANADA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('747', '390', 'LA TOLA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('748', '399', 'LA UNION', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('749', '405', 'LEIVA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('750', '411', 'LINARES', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('751', '418', 'LOS ANDES', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('752', '427', 'MAGsI', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('753', '435', 'MALLAMA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('754', '473', 'MOSQUERA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('755', '480', 'NARIÑO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('756', '490', 'OLAYA HERRERA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('757', '506', 'OSPINA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('758', '520', 'FRANCISCO PIZARRO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('759', '540', 'POLICARPA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('760', '560', 'POTOSI', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('761', '565', 'PROVIDENCIA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('762', '573', 'PUERRES', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('763', '585', 'PUPIALES', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('764', '612', 'RICAURTE', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('765', '621', 'ROBERTO PAYAN', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('766', '678', 'SAMANIEGO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('767', '683', 'SANDONA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('768', '685', 'SAN BERNARDO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('769', '687', 'SAN LORENZO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('770', '693', 'SAN PABLO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('771', '694', 'SAN PEDRO DE CARTAGO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('772', '696', 'SANTA BARBARA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('773', '699', 'SANTACRUZ', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('774', '720', 'SAPUYES', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('775', '786', 'TAMINANGO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('776', '788', 'TANGUA', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('777', '835', 'SAN ANDRES DE TUMACO', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('778', '838', 'TUQUERRES', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('779', '885', 'YACUANQUER', '52', '17');
INSERT INTO `cnt_municipio` VALUES ('780', '001', 'CUCUTA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('781', '003', 'ABREGO', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('782', '051', 'ARBOLEDAS', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('783', '099', 'BOCHALEMA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('784', '109', 'BUCARASICA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('785', '125', 'CACOTA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('786', '128', 'CACHIRA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('787', '172', 'CHINACOTA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('788', '174', 'CHITAGA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('789', '206', 'CONVENCION', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('790', '223', 'CUCUTILLA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('791', '239', 'DURANIA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('792', '245', 'EL CARMEN', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('793', '250', 'EL TARRA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('794', '261', 'EL ZULIA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('795', '313', 'GRAMALOTE', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('796', '344', 'HACARI', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('797', '347', 'HERRAN', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('798', '377', 'LABATECA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('799', '385', 'LA ESPERANZA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('800', '398', 'LA PLAYA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('801', '405', 'LOS PATIOS', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('802', '418', 'LOURDES', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('803', '480', 'MUTISCUA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('804', '498', 'OCAÑA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('805', '518', 'PAMPLONA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('806', '520', 'PAMPLONITA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('807', '553', 'PUERTO SANTANDER', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('808', '599', 'RAGONVALIA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('809', '660', 'SALAZAR', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('810', '670', 'SAN CALIXTO', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('811', '673', 'SAN CAYETANO', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('812', '680', 'SANTIAGO', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('813', '720', 'SARDINATA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('814', '743', 'SILOS', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('815', '800', 'TEORAMA', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('816', '810', 'TIBU', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('817', '820', 'TOLEDO', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('818', '871', 'VILLA CARO', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('819', '874', 'VILLA DEL ROSARIO', '54', '18');
INSERT INTO `cnt_municipio` VALUES ('820', '001', 'ARMENIA', '63', '19');
INSERT INTO `cnt_municipio` VALUES ('821', '111', 'BUENAVISTA', '63', '19');
INSERT INTO `cnt_municipio` VALUES ('822', '130', 'CALARCA', '63', '19');
INSERT INTO `cnt_municipio` VALUES ('823', '190', 'CIRCASIA', '63', '19');
INSERT INTO `cnt_municipio` VALUES ('824', '212', 'CORDOBA', '63', '19');
INSERT INTO `cnt_municipio` VALUES ('825', '272', 'FILANDIA', '63', '19');
INSERT INTO `cnt_municipio` VALUES ('826', '302', 'GENOVA', '63', '19');
INSERT INTO `cnt_municipio` VALUES ('827', '401', 'LA TEBAIDA', '63', '19');
INSERT INTO `cnt_municipio` VALUES ('828', '470', 'MONTENEGRO', '63', '19');
INSERT INTO `cnt_municipio` VALUES ('829', '548', 'PIJAO', '63', '19');
INSERT INTO `cnt_municipio` VALUES ('830', '594', 'QUIMBAYA', '63', '19');
INSERT INTO `cnt_municipio` VALUES ('831', '690', 'SALENTO', '63', '19');
INSERT INTO `cnt_municipio` VALUES ('832', '001', 'PEREIRA', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('833', '045', 'APIA', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('834', '075', 'BALBOA', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('835', '088', 'BELEN DE UMBRIA', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('836', '170', 'DOSQUEBRADAS', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('837', '318', 'GUATICA', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('838', '383', 'LA CELIA', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('839', '400', 'LA VIRGINIA', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('840', '440', 'MARSELLA', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('841', '456', 'MISTRATO', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('842', '572', 'PUEBLO RICO', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('843', '594', 'QUINCHIA', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('844', '682', 'SANTA ROSA DE CABAL', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('845', '687', 'SANTUARIO', '66', '20');
INSERT INTO `cnt_municipio` VALUES ('846', '001', 'BUCARAMANGA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('847', '013', 'AGUADA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('848', '020', 'ALBANIA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('849', '051', 'ARATOCA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('850', '077', 'BARBOSA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('851', '079', 'BARICHARA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('852', '081', 'BARRANCABERMEJA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('853', '092', 'BETULIA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('854', '101', 'BOLIVAR', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('855', '121', 'CABRERA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('856', '132', 'CALIFORNIA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('857', '147', 'CAPITANEJO', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('858', '152', 'CARCASI', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('859', '160', 'CEPITA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('860', '162', 'CERRITO', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('861', '167', 'CHARALA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('862', '169', 'CHARTA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('863', '176', 'CHIMA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('864', '179', 'CHIPATA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('865', '190', 'CIMITARRA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('866', '207', 'CONCEPCION', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('867', '209', 'CONFINES', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('868', '211', 'CONTRATACION', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('869', '217', 'COROMORO', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('870', '229', 'CURITI', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('871', '235', 'EL CARMEN DE CHUCURI', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('872', '245', 'EL GUACAMAYO', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('873', '250', 'EL PEÑON', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('874', '255', 'EL PLAYON', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('875', '264', 'ENCINO', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('876', '266', 'ENCISO', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('877', '271', 'FLORIAN', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('878', '276', 'FLORIDABLANCA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('879', '296', 'GALAN', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('880', '298', 'GAMBITA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('881', '307', 'GIRON', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('882', '318', 'GUACA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('883', '320', 'GUADALUPE', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('884', '322', 'GUAPOTA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('885', '324', 'GUAVATA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('886', '327', 'GsEPSA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('887', '344', 'HATO', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('888', '368', 'JESUS MARIA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('889', '370', 'JORDAN', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('890', '377', 'LA BELLEZA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('891', '385', 'LANDAZURI', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('892', '397', 'LA PAZ', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('893', '406', 'LEBRIJA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('894', '418', 'LOS SANTOS', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('895', '425', 'MACARAVITA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('896', '432', 'MALAGA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('897', '444', 'MATANZA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('898', '464', 'MOGOTES', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('899', '468', 'MOLAGAVITA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('900', '498', 'OCAMONTE', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('901', '500', 'OIBA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('902', '502', 'ONZAGA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('903', '522', 'PALMAR', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('904', '524', 'PALMAS DEL SOCORRO', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('905', '533', 'PARAMO', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('906', '547', 'PIEDECUESTA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('907', '549', 'PINCHOTE', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('908', '572', 'PUENTE NACIONAL', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('909', '573', 'PUERTO PARRA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('910', '575', 'PUERTO WILCHES', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('911', '615', 'RIONEGRO', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('912', '655', 'SABANA DE TORRES', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('913', '669', 'SAN ANDRES', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('914', '673', 'SAN BENITO', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('915', '679', 'SAN GIL', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('916', '682', 'SAN JOAQUIN', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('917', '684', 'SAN JOSE DE MIRANDA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('918', '686', 'SAN MIGUEL', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('919', '689', 'SAN VICENTE DE CHUCURI', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('920', '705', 'SANTA BARBARA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('921', '720', 'SANTA HELENA DEL OPON', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('922', '745', 'SIMACOTA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('923', '755', 'SOCORRO', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('924', '770', 'SUAITA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('925', '773', 'SUCRE', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('926', '780', 'SURATA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('927', '820', 'TONA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('928', '855', 'VALLE DE SAN JOSE', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('929', '861', 'VELEZ', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('930', '867', 'VETAS', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('931', '872', 'VILLANUEVA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('932', '895', 'ZAPATOCA', '68', '21');
INSERT INTO `cnt_municipio` VALUES ('933', '001', 'SINCELEJO', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('934', '110', 'BUENAVISTA', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('935', '124', 'CAIMITO', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('936', '204', 'COLOSO', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('937', '215', 'COROZAL', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('938', '221', 'COVEÑAS', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('939', '230', 'CHALAN', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('940', '233', 'EL ROBLE', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('941', '235', 'GALERAS', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('942', '265', 'GUARANDA', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('943', '400', 'LA UNION', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('944', '418', 'LOS PALMITOS', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('945', '429', 'MAJAGUAL', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('946', '473', 'MORROA', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('947', '508', 'OVEJAS', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('948', '523', 'PALMITO', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('949', '670', 'SAMPUES', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('950', '678', 'SAN BENITO ABAD', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('951', '702', 'SAN JUAN DE BETULIA', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('952', '708', 'SAN MARCOS', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('953', '713', 'SAN ONOFRE', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('954', '717', 'SAN PEDRO', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('955', '742', 'SAN LUIS DE SINCE', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('956', '771', 'SUCRE', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('957', '820', 'SANTIAGO DE TOLU', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('958', '823', 'TOLU VIEJO', '70', '22');
INSERT INTO `cnt_municipio` VALUES ('959', '001', 'IBAGUE', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('960', '024', 'ALPUJARRA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('961', '026', 'ALVARADO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('962', '030', 'AMBALEMA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('963', '043', 'ANZOATEGUI', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('964', '055', 'ARMERO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('965', '067', 'ATACO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('966', '124', 'CAJAMARCA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('967', '148', 'CARMEN DE APICALA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('968', '152', 'CASABIANCA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('969', '168', 'CHAPARRAL', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('970', '200', 'COELLO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('971', '217', 'COYAIMA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('972', '226', 'CUNDAY', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('973', '236', 'DOLORES', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('974', '268', 'ESPINAL', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('975', '270', 'FALAN', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('976', '275', 'FLANDES', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('977', '283', 'FRESNO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('978', '319', 'GUAMO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('979', '347', 'HERVEO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('980', '349', 'HONDA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('981', '352', 'ICONONZO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('982', '408', 'LERIDA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('983', '411', 'LIBANO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('984', '443', 'MARIQUITA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('985', '449', 'MELGAR', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('986', '461', 'MURILLO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('987', '483', 'NATAGAIMA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('988', '504', 'ORTEGA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('989', '520', 'PALOCABILDO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('990', '547', 'PIEDRAS', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('991', '555', 'PLANADAS', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('992', '563', 'PRADO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('993', '585', 'PURIFICACION', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('994', '616', 'RIOBLANCO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('995', '622', 'RONCESVALLES', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('996', '624', 'ROVIRA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('997', '671', 'SALDAÑA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('998', '675', 'SAN ANTONIO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('999', '678', 'SAN LUIS', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('1000', '686', 'SANTA ISABEL', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('1001', '770', 'SUAREZ', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('1002', '854', 'VALLE DE SAN JUAN', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('1003', '861', 'VENADILLO', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('1004', '870', 'VILLAHERMOSA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('1005', '873', 'VILLARRICA', '73', '23');
INSERT INTO `cnt_municipio` VALUES ('1006', '001', 'CALI', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1007', '020', 'ALCALA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1008', '036', 'ANDALUCIA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1009', '041', 'ANSERMANUEVO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1010', '054', 'ARGELIA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1011', '100', 'BOLIVAR', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1012', '109', 'BUENAVENTURA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1013', '111', 'GUADALAJARA DE BUGA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1014', '113', 'BUGALAGRANDE', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1015', '122', 'CAICEDONIA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1016', '126', 'CALIMA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1017', '130', 'CANDELARIA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1018', '147', 'CARTAGO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1019', '233', 'DAGUA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1020', '243', 'EL AGUILA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1021', '246', 'EL CAIRO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1022', '248', 'EL CERRITO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1023', '250', 'EL DOVIO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1024', '275', 'FLORIDA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1025', '306', 'GINEBRA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1026', '318', 'GUACARI', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1027', '364', 'JAMUNDI', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1028', '377', 'LA CUMBRE', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1029', '400', 'LA UNION', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1030', '403', 'LA VICTORIA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1031', '497', 'OBANDO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1032', '520', 'PALMIRA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1033', '563', 'PRADERA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1034', '606', 'RESTREPO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1035', '616', 'RIOFRIO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1036', '622', 'ROLDANILLO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1037', '670', 'SAN PEDRO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1038', '736', 'SEVILLA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1039', '823', 'TORO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1040', '828', 'TRUJILLO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1041', '834', 'TULUA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1042', '845', 'ULLOA', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1043', '863', 'VERSALLES', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1044', '869', 'VIJES', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1045', '890', 'YOTOCO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1046', '892', 'YUMBO', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1047', '895', 'ZARZAL', '76', '24');
INSERT INTO `cnt_municipio` VALUES ('1048', '001', 'ARAUCA', '81', '25');
INSERT INTO `cnt_municipio` VALUES ('1049', '065', 'ARAUQUITA', '81', '25');
INSERT INTO `cnt_municipio` VALUES ('1050', '220', 'CRAVO NORTE', '81', '25');
INSERT INTO `cnt_municipio` VALUES ('1051', '300', 'FORTUL', '81', '25');
INSERT INTO `cnt_municipio` VALUES ('1052', '591', 'PUERTO RONDON', '81', '25');
INSERT INTO `cnt_municipio` VALUES ('1053', '736', 'SARAVENA', '81', '25');
INSERT INTO `cnt_municipio` VALUES ('1054', '794', 'TAME', '81', '25');
INSERT INTO `cnt_municipio` VALUES ('1055', '001', 'YOPAL', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1056', '010', 'AGUAZUL', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1057', '015', 'CHAMEZA', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1058', '125', 'HATO COROZAL', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1059', '136', 'LA SALINA', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1060', '139', 'MANI', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1061', '162', 'MONTERREY', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1062', '225', 'NUNCHIA', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1063', '230', 'OROCUE', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1064', '250', 'PAZ DE ARIPORO', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1065', '263', 'PORE', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1066', '279', 'RECETOR', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1067', '300', 'SABANALARGA', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1068', '315', 'SACAMA', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1069', '325', 'SAN LUIS DE PALENQUE', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1070', '400', 'TAMARA', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1071', '410', 'TAURAMENA', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1072', '430', 'TRINIDAD', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1073', '440', 'VILLANUEVA', '85', '26');
INSERT INTO `cnt_municipio` VALUES ('1074', '001', 'MOCOA', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1075', '219', 'COLON', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1076', '320', 'ORITO', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1077', '568', 'PUERTO ASIS', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1078', '569', 'PUERTO CAICEDO', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1079', '571', 'PUERTO GUZMAN', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1080', '573', 'LEGUIZAMO', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1081', '749', 'SIBUNDOY', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1082', '755', 'SAN FRANCISCO', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1083', '757', 'SAN MIGUEL', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1084', '760', 'SANTIAGO', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1085', '865', 'VALLE DEL GUAMUEZ', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1086', '885', 'VILLAGARZON', '86', '27');
INSERT INTO `cnt_municipio` VALUES ('1087', '001', 'SAN ANDRES', '88', '28');
INSERT INTO `cnt_municipio` VALUES ('1088', '564', 'PROVIDENCIA', '88', '28');
INSERT INTO `cnt_municipio` VALUES ('1089', '001', 'LETICIA', '91', '29');
INSERT INTO `cnt_municipio` VALUES ('1090', '263', 'EL ENCANTO', '91', '29');
INSERT INTO `cnt_municipio` VALUES ('1091', '405', 'LA CHORRERA', '91', '29');
INSERT INTO `cnt_municipio` VALUES ('1092', '407', 'LA PEDRERA', '91', '29');
INSERT INTO `cnt_municipio` VALUES ('1093', '430', 'LA VICTORIA', '91', '29');
INSERT INTO `cnt_municipio` VALUES ('1094', '460', 'MIRITI - PARANA', '91', '29');
INSERT INTO `cnt_municipio` VALUES ('1095', '530', 'PUERTO ALEGRIA', '91', '29');
INSERT INTO `cnt_municipio` VALUES ('1096', '536', 'PUERTO ARICA', '91', '29');
INSERT INTO `cnt_municipio` VALUES ('1097', '540', 'PUERTO NARIÑO', '91', '29');
INSERT INTO `cnt_municipio` VALUES ('1098', '669', 'PUERTO SANTANDER', '91', '29');
INSERT INTO `cnt_municipio` VALUES ('1099', '798', 'TARAPACA', '91', '29');
INSERT INTO `cnt_municipio` VALUES ('1100', '001', 'INIRIDA', '94', '30');
INSERT INTO `cnt_municipio` VALUES ('1101', '343', 'BARRANCO MINAS', '94', '30');
INSERT INTO `cnt_municipio` VALUES ('1102', '663', 'MAPIRIPANA', '94', '30');
INSERT INTO `cnt_municipio` VALUES ('1103', '883', 'SAN FELIPE', '94', '30');
INSERT INTO `cnt_municipio` VALUES ('1104', '884', 'PUERTO COLOMBIA', '94', '30');
INSERT INTO `cnt_municipio` VALUES ('1105', '885', 'LA GUADALUPE', '94', '30');
INSERT INTO `cnt_municipio` VALUES ('1106', '886', 'CACAHUAL', '94', '30');
INSERT INTO `cnt_municipio` VALUES ('1107', '887', 'PANA PANA', '94', '30');
INSERT INTO `cnt_municipio` VALUES ('1108', '888', 'MORICHAL', '94', '30');
INSERT INTO `cnt_municipio` VALUES ('1109', '001', 'SAN JOSE DEL GUAVIARE', '95', '31');
INSERT INTO `cnt_municipio` VALUES ('1110', '015', 'CALAMAR', '95', '31');
INSERT INTO `cnt_municipio` VALUES ('1111', '025', 'EL RETORNO', '95', '31');
INSERT INTO `cnt_municipio` VALUES ('1112', '200', 'MIRAFLORES', '95', '31');
INSERT INTO `cnt_municipio` VALUES ('1113', '001', 'MITU', '97', '32');
INSERT INTO `cnt_municipio` VALUES ('1114', '161', 'CARURU', '97', '32');
INSERT INTO `cnt_municipio` VALUES ('1115', '511', 'PACOA', '97', '32');
INSERT INTO `cnt_municipio` VALUES ('1116', '666', 'TARAIRA', '97', '32');
INSERT INTO `cnt_municipio` VALUES ('1117', '777', 'PAPUNAUA', '97', '32');
INSERT INTO `cnt_municipio` VALUES ('1118', '889', 'YAVARATE', '97', '32');
INSERT INTO `cnt_municipio` VALUES ('1119', '001', 'PUERTO CARREÑO', '99', '33');
INSERT INTO `cnt_municipio` VALUES ('1120', '524', 'LA PRIMAVERA', '99', '33');
INSERT INTO `cnt_municipio` VALUES ('1121', '624', 'SANTA ROSALIA', '99', '33');
INSERT INTO `cnt_municipio` VALUES ('1122', '773', 'CUMARIBO', '99', '33');

-- ----------------------------
-- Table structure for cnt_notaaclaratoria
-- ----------------------------
DROP TABLE IF EXISTS `cnt_notaaclaratoria`;
CREATE TABLE `cnt_notaaclaratoria` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nac_consecutivo` int NOT NULL,
  `nac_fecha` date NOT NULL,
  `id_puc` int DEFAULT '0',
  `id_notaaclaratoriatipo` int NOT NULL,
  `nac_titulo` varchar(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nac_detalle` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL,
  `id_usuario` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '0',
  `estado` varchar(1) COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'A',
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_notaaclaratoria_cnt_notaaclaratoriatipo_1` (`id_notaaclaratoriatipo`),
  KEY `fk_cnt_notaaclaratoria_cnf_usuario_1` (`id_usuario`),
  KEY `fk_cnt_notaaclaratoria_cnt_puc` (`id_puc`),
  CONSTRAINT `fk_cnt_notaaclaaratoria_cnf_usuario_1` FOREIGN KEY (`id_usuario`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `fk_cnt_notaaclaratoria_cnt_notaaclaratoriatipo_1` FOREIGN KEY (`id_notaaclaratoriatipo`) REFERENCES `cnt_notaaclaratoriatipo` (`id`),
  CONSTRAINT `fk_cnt_notaaclaratoria_cnt_puc` FOREIGN KEY (`id_puc`) REFERENCES `cnt_puc` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_notaaclaratoria
-- ----------------------------

-- ----------------------------
-- Table structure for cnt_notaaclaratoriacuenta
-- ----------------------------
DROP TABLE IF EXISTS `cnt_notaaclaratoriacuenta`;
CREATE TABLE `cnt_notaaclaratoriacuenta` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_notaaclaratoria` int NOT NULL,
  `id_puc` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_notaaclaratoriatipo_copy_1_copy_1_cnt_notaaclaratoria_1` (`id_notaaclaratoria`),
  KEY `fk_cnt_notaaclaratoriatipo_copy_1_copy_1_cnt_pucauxcuenta_1` (`id_puc`),
  CONSTRAINT `cnt_notaaclaratoriacuenta_ibfk_1` FOREIGN KEY (`id_notaaclaratoria`) REFERENCES `cnt_notaaclaratoria` (`id`),
  CONSTRAINT `cnt_notaaclaratoriacuenta_ibfk_2` FOREIGN KEY (`id_puc`) REFERENCES `cnt_puc` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_notaaclaratoriacuenta
-- ----------------------------

-- ----------------------------
-- Table structure for cnt_notaaclaratoriatipo
-- ----------------------------
DROP TABLE IF EXISTS `cnt_notaaclaratoriatipo`;
CREATE TABLE `cnt_notaaclaratoriatipo` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_notaaclaratoriatipo
-- ----------------------------
INSERT INTO `cnt_notaaclaratoriatipo` VALUES ('1', 'GEN', 'GENERAL');
INSERT INTO `cnt_notaaclaratoriatipo` VALUES ('2', 'CUE', 'CUENTA');

-- ----------------------------
-- Table structure for cnt_puc
-- ----------------------------
DROP TABLE IF EXISTS `cnt_puc`;
CREATE TABLE `cnt_puc` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `nombre` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `id_puctipo` int DEFAULT NULL,
  `id_tipoimpuesto` int NOT NULL,
  `id_tipocuenta` int DEFAULT NULL,
  `pac_activa` tinyint(1) unsigned zerofill NOT NULL DEFAULT '1' COMMENT 'Cuenta esta activa\n No=0',
  `pac_base` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'Exige valor base\n  No=0',
  `pac_ajusteniif` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'Cuenta diferencia fiscal o ajuste niif\n  No=0',
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `id_usuario` varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo_UNIQUE` (`codigo`) USING BTREE,
  KEY `fk_cnt_puc_cnt_tipocuenta_1` (`id_tipocuenta`),
  KEY `fk_cnt_puc_cnf_usuario_1` (`id_usuario`),
  KEY `fk_cnt_pucauxcuenta_cnt_puctipo_1` (`id_puctipo`),
  KEY `fk_cnt_puc_cnt_tipoimpuesto` (`id_tipoimpuesto`),
  CONSTRAINT `fk_cnt_puc_cnf_usuario_1` FOREIGN KEY (`id_usuario`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `fk_cnt_puc_cnt_tipocuenta_1` FOREIGN KEY (`id_tipocuenta`) REFERENCES `cnt_tipocuenta` (`id`),
  CONSTRAINT `fk_cnt_puc_cnt_tipoimpuesto` FOREIGN KEY (`id_tipoimpuesto`) REFERENCES `cnt_tipoimpuesto` (`id`),
  CONSTRAINT `fk_cnt_pucauxcuenta_cnt_puctipo_1` FOREIGN KEY (`id_puctipo`) REFERENCES `cnt_puctipo` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_puc
-- ----------------------------
INSERT INTO `cnt_puc` VALUES ('1', '1', 'ACTIVO', null, '0', '1', '1', '0', '0', '2021-02-26 13:29:20', '2021-07-20 16:23:28', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('2', '2', 'PASIVO', null, '0', '1', '1', '0', '0', '2021-02-26 13:32:08', '2021-07-20 16:23:39', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('3', '3', 'PATRIMONIO', null, '0', '1', '1', '0', '0', '2021-02-26 13:39:46', '2021-07-20 16:23:39', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('4', '4', 'INGRESO', null, '0', '1', '1', '0', '0', '2021-02-26 13:39:47', '2021-07-20 16:23:39', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('5', '5', 'GASTO', null, '0', '1', '1', '0', '0', '2021-02-26 13:39:47', '2021-07-20 16:23:40', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('6', '6', 'COSTO DE VENTA', null, '0', '1', '1', '0', '0', '2021-02-26 13:39:47', '2021-07-20 16:23:40', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('7', '7', 'COSTO DE PRODUCCION', null, '0', '1', '1', '0', '0', '2021-02-26 13:39:47', '2021-07-20 16:23:41', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('8', '8', 'CUENTAS DE ORDEN DEUDORAS', null, '0', '1', '1', '0', '0', '2021-02-26 13:39:47', '2021-07-20 16:23:41', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('9', '9', 'CUENTAS DE ORDEN ACREEDORAS', null, '0', '1', '1', '0', '0', '2021-02-26 13:39:48', '2021-10-11 15:47:11', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('12', '11', 'CORRIENTE', null, '0', '2', '1', '0', '0', '2021-02-26 13:29:20', '2021-07-20 16:23:41', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('14', '1105', 'CAJA', null, '0', '3', '1', '0', '0', '2021-02-26 13:29:20', '2021-07-20 16:23:41', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('15', '110505', 'CAJA GENERAL', null, '0', '4', '1', '0', '0', '2021-02-26 13:29:20', '2021-07-20 16:23:41', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('16', '11050501', 'CAJA GENERAL 1', '1', '3', '5', '1', '0', '0', '2021-07-02 16:40:14', '2021-10-18 20:51:16', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('17', '11050502', 'CAJA GENERAL 42', '1', '3', '5', '1', '0', '0', '2021-07-02 16:40:14', '2021-10-18 20:51:23', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('19', '45', 'INGRESO45', null, '0', '2', '1', '0', '0', '2021-08-26 10:35:24', '2021-08-26 10:35:24', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('20', '11050503', 'CAJA GENERAL 02', '1', '2', '5', '1', '0', '0', '2021-09-30 16:42:37', '2021-10-18 20:50:49', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('22', '11050505', 'CAJA GENERAL 05', '1', '2', '5', '1', '0', '0', '2021-10-11 15:42:36', '2021-10-18 20:51:00', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('23', '20', 'PASIVOS 20 ', '8', '0', '2', '1', '0', '0', '2021-10-11 15:44:07', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('24', '2005', 'PASIVOS 2005 ', '8', '0', '3', '1', '1', '0', '2021-10-11 15:44:47', '2021-10-14 15:10:13', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('26', '200505', 'PASIVOS 200505 ', '8', '0', '4', '1', '0', '0', '2021-10-11 15:45:34', null, '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');
INSERT INTO `cnt_puc` VALUES ('27', '20050501', 'PASIVOS 20050501 ', '8', '2', '5', '1', '0', '0', '2021-10-11 15:45:58', '2021-10-18 20:52:03', '78bcb9b3-a7ab-4a62-ae60-145372cb37e8');

-- ----------------------------
-- Table structure for cnt_puctipo
-- ----------------------------
DROP TABLE IF EXISTS `cnt_puctipo`;
CREATE TABLE `cnt_puctipo` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` varchar(4) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_puctipo
-- ----------------------------
INSERT INTO `cnt_puctipo` VALUES ('1', 'CJA', 'CAJA', '2021-02-17 17:00:44', '2021-02-17 17:00:44');
INSERT INTO `cnt_puctipo` VALUES ('2', 'BCO', 'BANCO', '2021-02-17 17:00:51', '2021-02-17 17:00:51');
INSERT INTO `cnt_puctipo` VALUES ('3', 'CXC', 'CUENTAS POR COBRAR', '2021-02-17 17:01:04', '2021-02-17 17:01:04');
INSERT INTO `cnt_puctipo` VALUES ('4', 'INV', 'INVENTARIOS', '2021-02-17 17:01:15', '2021-02-17 17:01:15');
INSERT INTO `cnt_puctipo` VALUES ('5', 'OAC', 'OTROS ACTIVOS CORRIENTES', '2021-02-17 17:01:28', '2021-02-17 17:01:28');
INSERT INTO `cnt_puctipo` VALUES ('6', 'AFJ', 'ACTIVOS FIJOS', '2021-02-17 17:01:37', '2021-02-17 17:01:37');
INSERT INTO `cnt_puctipo` VALUES ('7', 'OAC', 'OTROS ACTIVOS', '2021-02-17 17:01:43', '2021-02-17 17:01:43');
INSERT INTO `cnt_puctipo` VALUES ('8', 'CXP', 'CUENTAS POR PAGAR', '2021-02-17 17:01:53', '2021-02-17 17:01:53');
INSERT INTO `cnt_puctipo` VALUES ('9', 'PCP', 'PASIVOS A CORTO PLAZO', '2021-02-17 17:02:04', '2021-02-17 17:02:04');
INSERT INTO `cnt_puctipo` VALUES ('10', 'PLP', 'PASIVOS A LARGO PLAZO', '2021-02-17 17:02:13', '2021-02-17 17:02:13');
INSERT INTO `cnt_puctipo` VALUES ('11', 'OPC', 'OTROS PASIVOS CORRIENTES', '2021-02-17 17:02:19', '2021-02-17 17:02:19');
INSERT INTO `cnt_puctipo` VALUES ('12', 'OPV', 'OTROS PASIVOS', '2021-02-17 17:02:25', '2021-02-17 17:02:25');
INSERT INTO `cnt_puctipo` VALUES ('13', 'PAT', 'PATRIMONIO', '2021-02-17 17:02:31', '2021-02-17 17:02:31');
INSERT INTO `cnt_puctipo` VALUES ('14', 'ING', 'INGRESOS', '2021-02-17 17:02:35', '2021-02-17 17:02:35');
INSERT INTO `cnt_puctipo` VALUES ('15', 'OIG', 'OTROS INGRESOS', '2021-02-17 17:02:40', '2021-02-17 17:02:40');
INSERT INTO `cnt_puctipo` VALUES ('16', 'GTO', 'GASTOS', '2021-02-17 17:02:43', '2021-02-17 17:02:43');
INSERT INTO `cnt_puctipo` VALUES ('17', 'OGT', 'OTROS GASTOS', '2021-02-17 17:02:48', '2021-02-17 17:02:48');
INSERT INTO `cnt_puctipo` VALUES ('18', 'GNM', 'GASTOS DE NOMINA', '2021-02-17 17:02:55', '2021-02-17 17:02:55');
INSERT INTO `cnt_puctipo` VALUES ('19', 'CDV', 'COSTO DE VENTAS', '2021-02-17 17:03:01', '2021-02-17 17:03:01');
INSERT INTO `cnt_puctipo` VALUES ('20', 'ORD', 'ORDEN', '2021-02-17 17:03:04', '2021-02-17 17:03:04');
INSERT INTO `cnt_puctipo` VALUES ('21', 'PRU', 'PRUEBAS', '2021-02-17 17:00:51', '2021-02-17 17:00:51');
INSERT INTO `cnt_puctipo` VALUES ('22', 'PRU', 'PRUEBA', null, null);

-- ----------------------------
-- Table structure for cnt_regimen
-- ----------------------------
DROP TABLE IF EXISTS `cnt_regimen`;
CREATE TABLE `cnt_regimen` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(3) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_regimen
-- ----------------------------
INSERT INTO `cnt_regimen` VALUES ('1', 'RI', 'RESPONSABLE DE IVA');
INSERT INTO `cnt_regimen` VALUES ('2', 'NI', 'NO RESPONSABLE DE IVA');

-- ----------------------------
-- Table structure for cnt_responsabilidad
-- ----------------------------
DROP TABLE IF EXISTS `cnt_responsabilidad`;
CREATE TABLE `cnt_responsabilidad` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(3) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_responsabilidad
-- ----------------------------
INSERT INTO `cnt_responsabilidad` VALUES ('1', '13', 'GRAN CONTRIBUYENTE');
INSERT INTO `cnt_responsabilidad` VALUES ('2', '15', 'AUTORETENEDOR');
INSERT INTO `cnt_responsabilidad` VALUES ('3', '23', 'AGENTE RETENEDOR DE IVA');
INSERT INTO `cnt_responsabilidad` VALUES ('4', '47', 'REGIMEN SIMPLE DE TRIBUTACION');
INSERT INTO `cnt_responsabilidad` VALUES ('5', '99', 'NO RESPONSABLE');

-- ----------------------------
-- Table structure for cnt_responsabilidad_ter
-- ----------------------------
DROP TABLE IF EXISTS `cnt_responsabilidad_ter`;
CREATE TABLE `cnt_responsabilidad_ter` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_tercero` int NOT NULL DEFAULT '0',
  `id_responsabilidad` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `terceroresp` (`id_tercero`,`id_responsabilidad`),
  KEY `fk_cnt_responsabilidad_ter_cnt_responsabilidad_1` (`id_responsabilidad`),
  KEY `fk_cnt_responsabilidad_ter_cnt_tercero_1` (`id_tercero`),
  CONSTRAINT `cnt_responsabilidad_ter_ibfk_1` FOREIGN KEY (`id_responsabilidad`) REFERENCES `cnt_responsabilidad` (`id`),
  CONSTRAINT `cnt_responsabilidad_ter_ibfk_2` FOREIGN KEY (`id_tercero`) REFERENCES `cnt_tercero` (`id`),
  CONSTRAINT `fk_cnt_responsabilidad_ter_cnt_responsabilidad_1` FOREIGN KEY (`id_responsabilidad`) REFERENCES `cnt_responsabilidad` (`id`),
  CONSTRAINT `fk_cnt_responsabilidad_ter_cnt_tercero_1` FOREIGN KEY (`id_tercero`) REFERENCES `cnt_tercero` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_responsabilidad_ter
-- ----------------------------

-- ----------------------------
-- Table structure for cnt_seccionciiu
-- ----------------------------
DROP TABLE IF EXISTS `cnt_seccionciiu`;
CREATE TABLE `cnt_seccionciiu` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_seccionciiu
-- ----------------------------
INSERT INTO `cnt_seccionciiu` VALUES ('1', 'A', 'AGRICULTURA, GANADERÍA, CAZA, SILVICULTURA Y PESCA');
INSERT INTO `cnt_seccionciiu` VALUES ('2', 'B', 'EXPLOTACIÓN DE MINAS Y CANTERAS');
INSERT INTO `cnt_seccionciiu` VALUES ('3', 'C', 'INDUSTRIAS MANUFACTURERAS');
INSERT INTO `cnt_seccionciiu` VALUES ('4', 'D', 'SUMINISTRO DE ELECTRICIDAD, GAS, VAPOR Y AIRE ACONDICIONADO');
INSERT INTO `cnt_seccionciiu` VALUES ('5', 'E', 'DISTRIBUCIÓN DE AGUA; EVACUACIÓN Y TRATAMIENTO DE AGUAS RESIDUALES, GESTIÓN DE DESECHOS Y ACTIVIDADES DE SANEAMIENTO AMBIENTAL');
INSERT INTO `cnt_seccionciiu` VALUES ('6', 'F', 'CONSTRUCCIÓN');
INSERT INTO `cnt_seccionciiu` VALUES ('7', 'G', 'COMERCIO AL POR MAYOR Y AL POR MENOR; REPARACIÓN DE VEHÍCULOS AUTOMOTORES Y MOTOCICLETAS');
INSERT INTO `cnt_seccionciiu` VALUES ('8', 'H', 'TRANSPORTE Y ALMACENAMIENTO');
INSERT INTO `cnt_seccionciiu` VALUES ('9', 'I', 'ALOJAMIENTO Y SERVICIOS DE COMIDA');
INSERT INTO `cnt_seccionciiu` VALUES ('10', 'J', 'INFORMACIÓN Y COMUNICACIONES');
INSERT INTO `cnt_seccionciiu` VALUES ('11', 'K', 'ACTIVIDADES FINANCIERAS Y DE SEGUROS');
INSERT INTO `cnt_seccionciiu` VALUES ('12', 'L', 'ACTIVIDADES INMOBILIARIAS');
INSERT INTO `cnt_seccionciiu` VALUES ('13', 'M', 'ACTIVIDADES PROFESIONALES, CIENTÍFICAS Y TÉCNICAS');
INSERT INTO `cnt_seccionciiu` VALUES ('14', 'N', 'ACTIVIDADES DE SERVICIOS ADMINISTRATIVOS Y DE APOYO');
INSERT INTO `cnt_seccionciiu` VALUES ('15', 'O', 'ADMINISTRACIÓN PÚBLICA Y DEFENSA; PLANES DE SEGURIDAD SOCIAL DE AFILIACIÓN OBLIGATORIA');
INSERT INTO `cnt_seccionciiu` VALUES ('16', 'P', 'EDUCACIÓN');
INSERT INTO `cnt_seccionciiu` VALUES ('17', 'Q', 'ACTIVIDADES DE ATENCIÓN DE LA SALUD HUMANA Y DE ASISTENCIA SOCIAL');
INSERT INTO `cnt_seccionciiu` VALUES ('18', 'R', 'ACTIVIDADES ARTÍSTICAS, DE ENTRETENIMIENTO Y RECREACIÓN');
INSERT INTO `cnt_seccionciiu` VALUES ('19', 'S', 'OTRAS ACTIVIDADES DE SERVICIOS');
INSERT INTO `cnt_seccionciiu` VALUES ('20', 'T', 'ACTIVIDADES DE LOS HOGARES INDIVIDUALES EN CALIDAD DE EMPLEADORES; ACTIVIDADES NO DIFERENCIADAS DE LOS HOGARES INDIVIDUALES COMO PRODUCTORES DE BIENES Y SERVICIOS PARA USO PROPIO');
INSERT INTO `cnt_seccionciiu` VALUES ('21', 'U', 'ACTIVIDADES DE ORGANIZACIONES Y ENTIDADES EXTRATERRITORIALES ');
INSERT INTO `cnt_seccionciiu` VALUES ('22', 'DIAN', 'OTRAS CLASIFICACIONES ');

-- ----------------------------
-- Table structure for cnt_tercero
-- ----------------------------
DROP TABLE IF EXISTS `cnt_tercero`;
CREATE TABLE `cnt_tercero` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_tippersona` int DEFAULT NULL,
  `id_genero` int DEFAULT NULL,
  `id_tipodocumento` int DEFAULT NULL,
  `id_municipio` int NOT NULL,
  `id_regimen` int NOT NULL DEFAULT '0',
  `id_tipotercero` int DEFAULT NULL,
  `id_ciiu` int NOT NULL,
  `ter_documento` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ter_digitoverificacion` varchar(1) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ter_prinombre` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ter_segnombre` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ter_priapellido` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ter_segapellido` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ter_razonsocial` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ter_direccion` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ter_barrio` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ter_telfijo` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ter_telcelular` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ter_email` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `ter_email_fe` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `ter_contacto_fe` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `id_usuario` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_cnt_tercero_cnt_generos_1` (`id_genero`),
  KEY `fk_cnt_tercero_cnt_tipodocumento_1` (`id_tipodocumento`),
  KEY `fk_cnt_tercero_cnt_tipopersona_1` (`id_tippersona`),
  KEY `fk_cnt_tercero_cnt_regimen_1` (`id_regimen`),
  KEY `fk_cnt_tercero_cnt_ciiu_1` (`id_ciiu`),
  KEY `fk_cnt_tercero_cnt_tipotercero_1` (`id_tipotercero`),
  KEY `fk_cnt_tercero_cnt_municipio_1` (`id_municipio`),
  KEY `fk_cnt_tercero_aspnetusers_1` (`id_usuario`),
  CONSTRAINT `fk_cnt_tercero_aspnetusers_1` FOREIGN KEY (`id_usuario`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `fk_cnt_tercero_cnt_ciiu_1` FOREIGN KEY (`id_ciiu`) REFERENCES `cnt_ciiu` (`id`),
  CONSTRAINT `fk_cnt_tercero_cnt_generos_1` FOREIGN KEY (`id_genero`) REFERENCES `cnt_genero` (`id`),
  CONSTRAINT `fk_cnt_tercero_cnt_municipio_1` FOREIGN KEY (`id_municipio`) REFERENCES `cnt_municipio1` (`id`),
  CONSTRAINT `fk_cnt_tercero_cnt_regimen_1` FOREIGN KEY (`id_regimen`) REFERENCES `cnt_regimen` (`id`),
  CONSTRAINT `fk_cnt_tercero_cnt_tipodocumento_1` FOREIGN KEY (`id_tipodocumento`) REFERENCES `cnt_tipodocumento` (`id`),
  CONSTRAINT `fk_cnt_tercero_cnt_tipopersona_1` FOREIGN KEY (`id_tippersona`) REFERENCES `cnt_tipopersona` (`id`),
  CONSTRAINT `fk_cnt_tercero_cnt_tipotercero_1` FOREIGN KEY (`id_tipotercero`) REFERENCES `cnt_tipotercero` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_tercero
-- ----------------------------
INSERT INTO `cnt_tercero` VALUES ('2', '1', '1', '1', '1', '1', '1', '1', '123456789', '1', 'ANGEL', 'GABRIEL', 'GIL', 'DIAZ', 'GIL DIAZ ANGEL GABRIEL', '1', '1', '1', '1', '1', '1', '1', '2021-05-10 15:59:33', '2021-10-22 11:43:23', '0c93133b-2354-4cc8-9805-4971169ff4b6');
INSERT INTO `cnt_tercero` VALUES ('5', '1', '4', '4', '4', '1', '1', '1', '123456789', '4', 'SEGUNDO', 'CUADRADO', 'REDONDO', 'GORDILLO', 'LA GOLONDRINA', '4', '4', '4', '4', '4', '4', '4', '2021-06-04 20:21:48', '2021-09-14 12:14:37', '1');

-- ----------------------------
-- Table structure for cnt_tipociiu
-- ----------------------------
DROP TABLE IF EXISTS `cnt_tipociiu`;
CREATE TABLE `cnt_tipociiu` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_tipociiu
-- ----------------------------
INSERT INTO `cnt_tipociiu` VALUES ('1', 'DIV', 'DIVISION');
INSERT INTO `cnt_tipociiu` VALUES ('2', 'GRU', 'GRUPO');
INSERT INTO `cnt_tipociiu` VALUES ('3', 'CLA', 'CLASE');

-- ----------------------------
-- Table structure for cnt_tipocomprobante
-- ----------------------------
DROP TABLE IF EXISTS `cnt_tipocomprobante`;
CREATE TABLE `cnt_tipocomprobante` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_categoriacomprobante` int NOT NULL,
  `codigo` varchar(3) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `nombre` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `tco_incremento` char(1) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'M' COMMENT 'Mensual,Unico,Anual',
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `editable` char(1) NOT NULL DEFAULT 'V',
  `borrable` char(1) NOT NULL DEFAULT 'F',
  `anulable` char(1) DEFAULT 'F',
  `id_usuario` varchar(250) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`),
  KEY `fk_cnt_tipocomprobante_cnt_categoriacomprobante_1` (`id_categoriacomprobante`),
  KEY `fk_cnt_tipocomprobante_cnf_usuario_1` (`id_usuario`),
  CONSTRAINT `cnt_tipocomprobante_ibfk_2` FOREIGN KEY (`id_categoriacomprobante`) REFERENCES `cnt_categoriacomprobante` (`id`),
  CONSTRAINT `cnt_tipocomprobante_user` FOREIGN KEY (`id_usuario`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_tipocomprobante
-- ----------------------------
INSERT INTO `cnt_tipocomprobante` VALUES ('2', '2', 'LIM', 'LIQUIDACION IMPUESTOS', 'A', '2021-02-18 11:03:23', '2021-10-16 11:18:50', 'F', 'F', 'F', '0c93133b-2354-4cc8-9805-4971169ff4b6');
INSERT INTO `cnt_tipocomprobante` VALUES ('3', '5', 'CEE', 'CBTE. EGRESO ESTADERO', 'A', '2021-02-18 11:06:13', '2021-09-28 11:12:02', 'V', 'V', 'F', '0c93133b-2354-4cc8-9805-4971169ff4b6');
INSERT INTO `cnt_tipocomprobante` VALUES ('5', '7', 'CAN', 'CIERRE ANUAL', 'C', '2021-02-19 15:19:32', '2021-09-10 15:40:41', 'V', 'V', 'F', '0c93133b-2354-4cc8-9805-4971169ff4b6');
INSERT INTO `cnt_tipocomprobante` VALUES ('7', '7', 'CNT', 'NOTA AJUSTE P 13', 'M', '2021-02-19 15:20:01', '2021-08-30 17:07:57', 'V', 'F', 'F', '0c93133b-2354-4cc8-9805-4971169ff4b6');
INSERT INTO `cnt_tipocomprobante` VALUES ('8', '2', 'LT', 'LIQUIDACION TARIFA', 'A', '2021-02-19 00:00:00', '2021-09-08 17:20:08', 'V', 'F', 'V', '0c93133b-2354-4cc8-9805-4971169ff4b6');
INSERT INTO `cnt_tipocomprobante` VALUES ('9', '2', 'RVD', 'REVERSOPMES', 'A', '2021-02-19 00:00:00', '2021-09-02 15:43:51', 'F', 'F', 'F', '0c93133b-2354-4cc8-9805-4971169ff4b6');
INSERT INTO `cnt_tipocomprobante` VALUES ('11', '2', 'LB', 'LIQUIDACION BOLETA', 'U', '2021-09-24 17:33:44', '2021-09-24 17:33:48', 'V', 'V', 'V', '0c93133b-2354-4cc8-9805-4971169ff4b6');
INSERT INTO `cnt_tipocomprobante` VALUES ('12', '2', 'LG', 'LIQUIDACION GARAGE', 'U', '2021-09-24 17:46:10', null, 'V', 'V', 'V', '0c93133b-2354-4cc8-9805-4971169ff4b6');

-- ----------------------------
-- Table structure for cnt_tipocuenta
-- ----------------------------
DROP TABLE IF EXISTS `cnt_tipocuenta`;
CREATE TABLE `cnt_tipocuenta` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(3) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_tipocuenta
-- ----------------------------
INSERT INTO `cnt_tipocuenta` VALUES ('1', 'CLA', 'CLASE');
INSERT INTO `cnt_tipocuenta` VALUES ('2', 'GRU', 'GRUPO');
INSERT INTO `cnt_tipocuenta` VALUES ('3', 'CUE', 'CUENTA');
INSERT INTO `cnt_tipocuenta` VALUES ('4', 'SUB', 'SUBCUENTA');
INSERT INTO `cnt_tipocuenta` VALUES ('5', 'AUX', 'AUXILIAR');

-- ----------------------------
-- Table structure for cnt_tipodocumento
-- ----------------------------
DROP TABLE IF EXISTS `cnt_tipodocumento`;
CREATE TABLE `cnt_tipodocumento` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` int NOT NULL,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `update_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_tipodocumento
-- ----------------------------
INSERT INTO `cnt_tipodocumento` VALUES ('1', '13', 'CEDULA DE CIUDADANIA', '2021-02-17 17:10:25', '2021-02-17 17:10:25');
INSERT INTO `cnt_tipodocumento` VALUES ('2', '31', 'NIT', '2021-02-17 17:10:25', '2021-02-17 17:10:25');
INSERT INTO `cnt_tipodocumento` VALUES ('3', '12', 'TARJETA DE IDENTIDAD', '2021-02-17 17:10:25', '2021-02-17 17:10:25');
INSERT INTO `cnt_tipodocumento` VALUES ('4', '22', 'CEDULA DE EXTRANJERIA', '2021-02-17 17:10:25', '2021-02-17 17:10:25');
INSERT INTO `cnt_tipodocumento` VALUES ('5', '21', 'TARJETA DE EXTRANJERIA', '2021-02-17 17:10:26', '2021-02-17 17:10:26');
INSERT INTO `cnt_tipodocumento` VALUES ('6', '11', 'REGISTRO CIVIL DE NACIMIENTO', '2021-02-17 17:10:26', '2021-02-17 17:10:26');
INSERT INTO `cnt_tipodocumento` VALUES ('7', '41', 'PASAPORTE', '2021-02-17 17:10:26', '2021-02-17 17:10:26');
INSERT INTO `cnt_tipodocumento` VALUES ('8', '42', 'DOCUMENTO DE IDENTIFICACION EXTRANJERO', '2021-02-17 17:10:26', '2021-02-17 17:10:26');
INSERT INTO `cnt_tipodocumento` VALUES ('9', '43', 'SIN IDENTIFICACION DEL EXTERIOR O PARA USO DEFINIDO DIAN', '2021-02-17 17:10:26', '2021-02-17 17:10:26');
INSERT INTO `cnt_tipodocumento` VALUES ('10', '14', 'CERTIFICADO   DE   LA   REGISTRADURÍA   PARA   SUCESIONES   ILÍQUIDAS   DE   PERSONAS NATURALES QUE NO TIENEN NINGÚN DOCUMENTO DE IDENTIFICACIÓN', '2021-02-19 11:04:21', '2021-02-19 11:04:21');
INSERT INTO `cnt_tipodocumento` VALUES ('11', '15', 'TIPO  DE  DOCUMENTO  QUE  IDENTIFICA  UNA  SUCESIÓN  ILÍQUIDA,  EXPEDIDO  POR  LA NOTARIA O POR UN JUZGADO', '2021-02-19 11:04:38', '2021-02-19 11:04:38');
INSERT INTO `cnt_tipodocumento` VALUES ('12', '44', 'DOCUMENTO DE IDENTIFICACIÓN EXTRANJERO PERSONA JURÍDI', '2021-02-19 11:05:08', '2021-02-19 11:05:08');
INSERT INTO `cnt_tipodocumento` VALUES ('13', '46', 'CARNÉ  DIPLOMÁTICO', '2021-02-19 11:05:33', '2021-02-19 11:05:33');

-- ----------------------------
-- Table structure for cnt_tipoimpuesto
-- ----------------------------
DROP TABLE IF EXISTS `cnt_tipoimpuesto`;
CREATE TABLE `cnt_tipoimpuesto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(3) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_tipoimpuesto
-- ----------------------------
INSERT INTO `cnt_tipoimpuesto` VALUES ('1', 'NA', 'NO APLICA');
INSERT INTO `cnt_tipoimpuesto` VALUES ('2', 'IVA', 'IVA');
INSERT INTO `cnt_tipoimpuesto` VALUES ('3', 'RFC', 'RETENCION EN LA FUENTE COMPRA');
INSERT INTO `cnt_tipoimpuesto` VALUES ('4', 'RFV', 'RETENCION EN LA FUENTE VENTAS');
INSERT INTO `cnt_tipoimpuesto` VALUES ('5', 'RIC', 'RETENCION DE IVA COMPRA');
INSERT INTO `cnt_tipoimpuesto` VALUES ('6', 'RIV', 'RETENCION DE IVA VENTAS');
INSERT INTO `cnt_tipoimpuesto` VALUES ('7', 'RIM', 'RETENCION INDUSTRIA Y COMERCIO');
INSERT INTO `cnt_tipoimpuesto` VALUES ('11', 'PR', 'PRUEBA');
INSERT INTO `cnt_tipoimpuesto` VALUES ('12', 'RES', 'RETENCION SOLEDAD ');

-- ----------------------------
-- Table structure for cnt_tipooperacion
-- ----------------------------
DROP TABLE IF EXISTS `cnt_tipooperacion`;
CREATE TABLE `cnt_tipooperacion` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `formula` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_tipooperacion
-- ----------------------------
INSERT INTO `cnt_tipooperacion` VALUES ('1', 'SDB', 'Suma Débitos del Periodo', '');
INSERT INTO `cnt_tipooperacion` VALUES ('2', 'SCR', 'Suma Créditos del Periodo', '');
INSERT INTO `cnt_tipooperacion` VALUES ('3', 'DCD', 'Débitos periodo - Créditos periodo', '');
INSERT INTO `cnt_tipooperacion` VALUES ('4', 'SFN', 'Saldo Final', '');

-- ----------------------------
-- Table structure for cnt_tipopersona
-- ----------------------------
DROP TABLE IF EXISTS `cnt_tipopersona`;
CREATE TABLE `cnt_tipopersona` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` char(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_tipopersona
-- ----------------------------
INSERT INTO `cnt_tipopersona` VALUES ('1', 'N', 'NATURAL');
INSERT INTO `cnt_tipopersona` VALUES ('2', 'J', 'JURIDICA');

-- ----------------------------
-- Table structure for cnt_tipotercero
-- ----------------------------
DROP TABLE IF EXISTS `cnt_tipotercero`;
CREATE TABLE `cnt_tipotercero` (
  `id` int NOT NULL,
  `codigo` char(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `nombre` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`),
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Records of cnt_tipotercero
-- ----------------------------
INSERT INTO `cnt_tipotercero` VALUES ('1', '1', 'tipo1');

-- ----------------------------
-- Table structure for cnt_uvt
-- ----------------------------
DROP TABLE IF EXISTS `cnt_uvt`;
CREATE TABLE `cnt_uvt` (
  `id` int NOT NULL,
  `uvt_ano` int NOT NULL,
  `uvt_valor` double(15,2) NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of cnt_uvt
-- ----------------------------

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20210714191201_IdentityCoreInicial', '5.0.5');

-- ----------------------------
-- View structure for viewtercero
-- ----------------------------
DROP VIEW IF EXISTS `viewtercero`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `viewtercero` AS select `cnt_tercero`.`id_genero` AS `id_genero`,`cnt_genero`.`nombre` AS `nombre`,`cnt_tercero`.`ter_prinombre` AS `ter_prinombre`,`cnt_tercero`.`ter_segnombre` AS `ter_segnombre`,`cnt_tercero`.`ter_priapellido` AS `ter_priapellido` from (`cnt_tercero` join `cnt_genero`) ;

-- ----------------------------
-- Procedure structure for sp_insertarpuc
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_insertarpuc`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertarpuc`(IN _codigo varchar(20), IN `_nombre` varchar(250), IN `_id_puctipo` int, IN `_id_tipocuenta` int, IN `_pac_activa` tinyint(1),IN `_pac_base` tinyint(1), IN `_pac_ajusteniif` tinyint(1), IN `_id_usuario` varchar(250))
BEGIN
	#Routine body goes here...
insert into cnt_puc 
(codigo,nombre,id_puctipo,id_tipocuenta,pac_activa,pac_base,pac_ajusteniif,id_usuario) 
VALUES
(_codigo,_nombre,_id_puctipo,_id_tipocuenta,_pac_activa,_pac_base,_pac_ajusteniif,_id_usuario) ;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_obtener_pucs
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_obtener_pucs`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_obtener_pucs`()
BEGIN
select 
p.codigo,p.nombre,p.id_usuario
from cnt_puc p; 	#Routine body goes here...
END
;;
DELIMITER ;
