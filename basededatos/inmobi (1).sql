-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 17-04-2023 a las 07:34:54
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `inmobi`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contrato`
--

CREATE TABLE `contrato` (
  `ContratoId` int(11) NOT NULL,
  `InmuId` int(11) NOT NULL,
  `InquiId` int(11) NOT NULL,
  `FechaInicio` datetime NOT NULL,
  `FechaFinal` datetime NOT NULL,
  `MontoAlquiler` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `contrato`
--

INSERT INTO `contrato` (`ContratoId`, `InmuId`, `InquiId`, `FechaInicio`, `FechaFinal`, `MontoAlquiler`) VALUES
(3, 8, 7, '2023-04-06 22:40:00', '2023-04-21 22:40:00', 40000),
(4, 9, 8, '2023-04-11 14:55:00', '2023-04-21 14:55:00', 300000),
(5, 10, 6, '2023-04-16 19:34:00', '2023-04-19 19:34:00', 1500);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inmueble`
--

CREATE TABLE `inmueble` (
  `InmuId` int(11) NOT NULL,
  `PropId` int(11) NOT NULL,
  `Direccion` varchar(2000) NOT NULL,
  `UsoComercial` varchar(400) NOT NULL,
  `TipoLocal` varchar(400) NOT NULL,
  `CantidadAmbientes` int(11) NOT NULL,
  `Latitud` int(11) NOT NULL,
  `Longitud` int(11) NOT NULL,
  `Precio` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inmueble`
--

INSERT INTO `inmueble` (`InmuId`, `PropId`, `Direccion`, `UsoComercial`, `TipoLocal`, `CantidadAmbientes`, `Latitud`, `Longitud`, `Precio`) VALUES
(8, 17, 'Barrio dos venados manzana j casa 2', 'Negocio', 'Comercio', 2, 4556, 33212, 150000),
(9, 16, '500 Viviendas Norte casa 1', 'Garaje', 'Almacen', 1, 230, 5540, 300000),
(10, 18, 'Barrio Universitario casa 15', 'Comercial', 'Local', 2, 352, 1121, 163221);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilino`
--

CREATE TABLE `inquilino` (
  `InquiId` int(11) NOT NULL,
  `Nombre` varchar(200) NOT NULL,
  `Apellido` varchar(200) NOT NULL,
  `DNI` varchar(200) NOT NULL,
  `Domicilio` varchar(500) NOT NULL,
  `Telefono` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inquilino`
--

INSERT INTO `inquilino` (`InquiId`, `Nombre`, `Apellido`, `DNI`, `Domicilio`, `Telefono`) VALUES
(6, 'Marito', 'Gonzales1', '39855007', 'calle Elm 1500', '2664236544'),
(7, 'Rodrigo', 'Azucar', '35124811', 'Barrio 3 venados manzana i casa 1', '2664153250'),
(8, 'Riquelme ', 'Rosales', '42113564', 'Barrio Candado casa 12', '2664789526');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pago`
--

CREATE TABLE `pago` (
  `PagoId` int(11) NOT NULL,
  `ContratoId` int(11) NOT NULL,
  `NumeroPago` bigint(20) NOT NULL,
  `FechaPago` datetime NOT NULL,
  `Importe` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `pago`
--

INSERT INTO `pago` (`PagoId`, `ContratoId`, `NumeroPago`, `FechaPago`, `Importe`) VALUES
(1, 3, 2, '2023-04-11 21:31:07', '15210');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `propietario`
--

CREATE TABLE `propietario` (
  `PropId` int(11) NOT NULL,
  `Nombre` varchar(200) NOT NULL,
  `Apellido` varchar(200) NOT NULL,
  `Direccion` varchar(200) NOT NULL,
  `Telefono` varchar(200) NOT NULL,
  `Dni` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `propietario`
--

INSERT INTO `propietario` (`PropId`, `Nombre`, `Apellido`, `Direccion`, `Telefono`, `Dni`) VALUES
(16, 'Pepito', 'Elmes', 'Barrio Liberta 1432', '2664131342', '36145685'),
(17, 'Maria', 'Algarrobo', 'Mitre 854', '2665789523', '40123486'),
(18, 'Tony', 'Stark', 'calle lomada 132', '2664134562', '33445121');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `UsuarioId` int(11) NOT NULL,
  `Nombre` varchar(200) NOT NULL,
  `Apellido` varchar(200) NOT NULL,
  `Password` varchar(2000) NOT NULL,
  `Correo` varchar(1000) NOT NULL,
  `Rol` int(200) NOT NULL,
  `Avatar` varchar(10000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`UsuarioId`, `Nombre`, `Apellido`, `Password`, `Correo`, `Rol`, `Avatar`) VALUES
(7, 'elAdmin2', 'Crack', 'rnV+gxtZCGow18aCB3Q29YOH3LifUokSPbayKVdIYQ8=', 'elAdmin2@gmail.com', 1, '/Uploads\\avatar_b22a148d-8fbf-4ff3-a8de-a40586f90adc.jpg'),
(10, 'cadete2', 'cad', 'wVWgBHLChSd1demn0UPydU/n69UQxgDW3v0rfWivJpw=', 'cadete@gmail.com', 2, '/Uploads\\avatar_dc10c2ee-3991-49f7-8224-c3482c637e7f.jpg');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD PRIMARY KEY (`ContratoId`),
  ADD KEY `Id_inmu` (`InmuId`),
  ADD KEY `Id_inqui` (`InquiId`);

--
-- Indices de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD PRIMARY KEY (`InmuId`),
  ADD KEY `id_propietario` (`PropId`);

--
-- Indices de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  ADD PRIMARY KEY (`InquiId`);

--
-- Indices de la tabla `pago`
--
ALTER TABLE `pago`
  ADD PRIMARY KEY (`PagoId`),
  ADD KEY `Id_contrato` (`ContratoId`);

--
-- Indices de la tabla `propietario`
--
ALTER TABLE `propietario`
  ADD PRIMARY KEY (`PropId`),
  ADD UNIQUE KEY `Dni` (`Dni`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`UsuarioId`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `contrato`
--
ALTER TABLE `contrato`
  MODIFY `ContratoId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  MODIFY `InmuId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  MODIFY `InquiId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `pago`
--
ALTER TABLE `pago`
  MODIFY `PagoId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `propietario`
--
ALTER TABLE `propietario`
  MODIFY `PropId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `UsuarioId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD CONSTRAINT `contrato_ibfk_1` FOREIGN KEY (`InmuId`) REFERENCES `inmueble` (`InmuId`),
  ADD CONSTRAINT `contrato_ibfk_3` FOREIGN KEY (`InquiId`) REFERENCES `inquilino` (`InquiId`);

--
-- Filtros para la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD CONSTRAINT `inmueble_ibfk_1` FOREIGN KEY (`PropId`) REFERENCES `propietario` (`PropId`);

--
-- Filtros para la tabla `pago`
--
ALTER TABLE `pago`
  ADD CONSTRAINT `pago_ibfk_2` FOREIGN KEY (`ContratoId`) REFERENCES `contrato` (`ContratoId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
