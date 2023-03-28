-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 28-03-2023 a las 04:21:59
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
-- Base de datos: `inmo`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contrato_inmu`
--

CREATE TABLE `contrato_inmu` (
  `Id_contrato` int(11) NOT NULL,
  `Id_inmu` int(11) NOT NULL,
  `Id_inqui` int(11) NOT NULL,
  `Fecha_inicio` datetime NOT NULL,
  `Fecha_final` datetime NOT NULL,
  `Monto_alquiler` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inmueble`
--

CREATE TABLE `inmueble` (
  `Id_inmu` int(11) NOT NULL,
  `Id_prop` int(11) NOT NULL,
  `Direccion` varchar(2000) NOT NULL,
  `Uso_comercial` varchar(400) NOT NULL,
  `Tipo_local` varchar(400) NOT NULL,
  `Cantidad_ambientes` int(11) NOT NULL,
  `Coordenadas` varchar(400) NOT NULL,
  `Precio` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilino`
--

CREATE TABLE `inquilino` (
  `Id_inqui` int(11) NOT NULL,
  `Nombre` varchar(200) NOT NULL,
  `Apellido` varchar(200) NOT NULL,
  `DNI` varchar(200) NOT NULL,
  `Domicilio` varchar(500) NOT NULL,
  `Telefono` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inquilino`
--

INSERT INTO `inquilino` (`Id_inqui`, `Nombre`, `Apellido`, `DNI`, `Domicilio`, `Telefono`) VALUES
(1, 'capo', 'funciono', '4465', 'vivo en la casa', '1234');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pago`
--

CREATE TABLE `pago` (
  `Id_pago` int(11) NOT NULL,
  `Id_contrato` int(11) NOT NULL,
  `Numero_pago` bigint(20) NOT NULL,
  `Fecha_pago` datetime NOT NULL,
  `Importe` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `propietario`
--

CREATE TABLE `propietario` (
  `Id_prop` int(11) NOT NULL,
  `Nombre` varchar(200) NOT NULL,
  `Apellido` varchar(200) NOT NULL,
  `Direccion` varchar(200) NOT NULL,
  `Telefono` varchar(200) NOT NULL,
  `Dni` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `propietario`
--

INSERT INTO `propietario` (`Id_prop`, `Nombre`, `Apellido`, `Direccion`, `Telefono`, `Dni`) VALUES
(2, 'Williams12', 'García', '500 Viviendas Norte', '(266) 5045512', '123'),
(3, 'Pepes', 'Jose', 'Calle jojo 123', '16425478', '123'),
(4, 'ash', 'kepchut', '0', 'sin tel', '0321');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contrato_inmu`
--
ALTER TABLE `contrato_inmu`
  ADD PRIMARY KEY (`Id_contrato`),
  ADD KEY `Id_inmu` (`Id_inmu`),
  ADD KEY `Id_inqui` (`Id_inqui`);

--
-- Indices de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD PRIMARY KEY (`Id_inmu`),
  ADD KEY `id_propietario` (`Id_prop`);

--
-- Indices de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  ADD PRIMARY KEY (`Id_inqui`);

--
-- Indices de la tabla `pago`
--
ALTER TABLE `pago`
  ADD PRIMARY KEY (`Id_pago`),
  ADD KEY `Id_contrato` (`Id_contrato`);

--
-- Indices de la tabla `propietario`
--
ALTER TABLE `propietario`
  ADD PRIMARY KEY (`Id_prop`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `contrato_inmu`
--
ALTER TABLE `contrato_inmu`
  MODIFY `Id_contrato` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  MODIFY `Id_inmu` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  MODIFY `Id_inqui` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `pago`
--
ALTER TABLE `pago`
  MODIFY `Id_pago` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `propietario`
--
ALTER TABLE `propietario`
  MODIFY `Id_prop` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `contrato_inmu`
--
ALTER TABLE `contrato_inmu`
  ADD CONSTRAINT `contrato_inmu_ibfk_1` FOREIGN KEY (`Id_inmu`) REFERENCES `inmueble` (`Id_inmu`),
  ADD CONSTRAINT `contrato_inmu_ibfk_3` FOREIGN KEY (`Id_inqui`) REFERENCES `inquilino` (`Id_inqui`);

--
-- Filtros para la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD CONSTRAINT `inmueble_ibfk_1` FOREIGN KEY (`Id_prop`) REFERENCES `propietario` (`Id_prop`);

--
-- Filtros para la tabla `pago`
--
ALTER TABLE `pago`
  ADD CONSTRAINT `pago_ibfk_2` FOREIGN KEY (`Id_contrato`) REFERENCES `contrato_inmu` (`Id_contrato`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
