-- Versión de MySQL: 10.4.24-MariaDB

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `inmobiliaria`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contratos`
--

CREATE TABLE `contratos` (
  `Id_Contrato` int(11) NOT NULL,
  `Fecha_Inicio` date NOT NULL,
  `Fecha_Fin` date NOT NULL,
  `Monto` decimal(10,0) NOT NULL,
  `Id_Inmueble` int(11) NOT NULL,
  `Id_Inquilino` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `contratos`
--

INSERT INTO `contratos` (`Id_Contrato`, `Fecha_Inicio`, `Fecha_Fin`, `Monto`, `Id_Inmueble`, `Id_Inquilino`) VALUES
(1, '0001-01-01', '0001-01-01', 21, 3, 1),
(3, '2010-01-01', '2010-01-26', 200000, 1, 2),
(4, '2022-10-14', '2024-10-14', 210000, 2, 5),
(5, '2024-02-14', '2024-12-25', 225000, 5, 6),
(6, '2024-05-25', '2024-12-31', 178999, 8, 7),
(8, '2021-01-01', '2021-12-31', 100000, 7, 4),
(9, '2022-01-01', '2022-12-31', 150000, 7, 4),
(10, '2024-01-01', '2024-12-31', 200000, 7, 4),
(11, '0001-01-01', '0001-01-01', 5677, 7, 1),
(18, '2024-04-15', '2024-04-23', 150000, 1, 1),
(32, '2024-04-03', '2024-04-07', 12, 1, 1),
(35, '2024-04-01', '2024-04-02', 123, 1, 1),
(37, '2025-05-01', '2025-09-17', 188888, 1, 1),
(38, '2024-04-01', '2025-04-22', 21, 3, 1),
(39, '2025-04-01', '2025-04-22', 5677, 1, 1),
(40, '2025-05-01', '2025-05-10', 5677, 3, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inmuebles`
--

CREATE TABLE `inmuebles` (
  `Id_Inmueble` int(11) NOT NULL,
  `Direccion` varchar(150) NOT NULL,
  `Id_Uso` int(11) NOT NULL,
  `Id_Tipo` int(11) NOT NULL,
  `Ambientes` int(11) NOT NULL,
  `Latitud` decimal(10,0) NOT NULL,
  `Longitud` decimal(10,0) NOT NULL,
  `Precio` decimal(10,0) NOT NULL,
  `Activo` tinyint(1) NOT NULL,
  `Id_Propietario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `inmuebles`
--

INSERT INTO `inmuebles` (`Id_Inmueble`, `Direccion`, `Id_Uso`, `Id_Tipo`, `Ambientes`, `Latitud`, `Longitud`, `Precio`, `Activo`, `Id_Propietario`) VALUES
(1, 'Caseros 123', 2, 4, 7, 11, 12, 150000, 1, 1),
(2, 'Av Centenario 555', 2, 3, 6, 22, 21, 235000, 0, 2),
(3, 'Chacabuco 456', 1, 2, 2, 33, 31, 478000, 1, 2),
(5, 'Caseros 230', 1, 1, 0, 23, 23, 1500, 1, 1),
(6, 'Ayacucho', 2, 4, 2, 156, 321, 175000, 1, 5),
(7, 'Juan G Funes', 2, 4, 4, 478, 458, 100000, 1, 5),
(8, 'Belgrano 999', 1, 1, 3, 156, 123, 350000, 1, 4),
(10, 'Los paraisos m 173 c17', 2, 1, 2, 333, 11, 56000, 1, 4);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilinos`
--

CREATE TABLE `inquilinos` (
  `Id_Inquilino` int(11) NOT NULL,
  `Apellido` varchar(150) NOT NULL,
  `Nombre` varchar(150) NOT NULL,
  `Dni` varchar(10) NOT NULL,
  `Telefono` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `inquilinos`
--

INSERT INTO `inquilinos` (`Id_Inquilino`, `Apellido`, `Nombre`, `Dni`, `Telefono`) VALUES
(1, 'Perez', 'Susanas', '25789321', '2664781435'),
(2, 'Carlos', 'Gomez', '48966123', '2664786954'),
(4, 'Rodriguez', 'Marta', '14586795', '2664787878'),
(5, 'Pizza', 'Raul', '69852741', '2664333214'),
(6, 'Donas', 'Pedro', '25666444', '2664888888'),
(7, 'Asado', 'Cintia', '45789789', '2664555555');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pagos`
--

CREATE TABLE `pagos` (
  `Id_Pago` int(11) NOT NULL,
  `Fecha` date NOT NULL,
  `Importe` decimal(10,0) NOT NULL,
  `Id_Contrato` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `pagos`
--

INSERT INTO `pagos` (`Id_Pago`, `Fecha`, `Importe`, `Id_Contrato`) VALUES
(1, '2024-04-03', 2600, 1),
(2, '2024-04-03', 2500, 1),
(3, '2024-04-15', 445554, 1),
(4, '2024-04-15', 445554, 1),
(5, '2024-04-15', 445554, 1),
(6, '2024-04-08', 2000, 1),
(7, '2024-04-08', 2000, 1),
(8, '2024-04-02', 110000, 1),
(9, '2024-04-08', 11212121, 1),
(10, '2024-04-09', 33333, 1),
(11, '2024-04-10', 65655656, 1),
(12, '2022-01-05', 100000, 8),
(13, '2022-02-05', 100000, 8),
(14, '2022-03-05', 100000, 8),
(15, '2024-04-07', 38000, 6),
(17, '2024-04-10', 40000, 6),
(18, '0001-01-01', 0, 4),
(19, '2024-04-02', 55, 1),
(22, '2025-04-22', 999, 6);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `propietarios`
--

CREATE TABLE `propietarios` (
  `Id_Propietario` int(11) NOT NULL,
  `Apellido` varchar(150) NOT NULL,
  `Nombre` varchar(150) NOT NULL,
  `Dni` varchar(10) NOT NULL,
  `Telefono` varchar(20) NOT NULL,
  `Email` varchar(150) NOT NULL,
  `Clave` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `propietarios`
--

INSERT INTO `propietarios` (`Id_Propietario`, `Apellido`, `Nombre`, `Dni`, `Telefono`, `Email`, `Clave`) VALUES
(1, 'Matias', 'Brianzo', '3588888887', '2664658749', 'v@mail.com', '11'),
(2, 'Tomas', 'Perez', '10456789', '2664321654', 'ln@mail.com', '12'),
(4, 'Carlo', 'Homero', '11222333', '2664332211', 'homer@g.com', '13'),
(5, 'Jose', 'Miranda', '56222147', '2664485976', 'gok@g.com', '14'),
(12, 'demo', 'www', '23234', '1111', 'matias.brianzo@gmail.com', '4444444444');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipos`
--

CREATE TABLE `tipos` (
  `Id_Tipo` int(11) NOT NULL,
  `Nombre` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tipos`
--

INSERT INTO `tipos` (`Id_Tipo`, `Nombre`) VALUES
(1, 'Local'),
(2, 'Depósito'),
(3, 'Casa'),
(4, 'Departamento');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usos`
--

CREATE TABLE `usos` (
  `Id_Uso` int(11) NOT NULL,
  `Nombre` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usos`
--

INSERT INTO `usos` (`Id_Uso`, `Nombre`) VALUES
(1, 'Comercial'),
(2, 'Residencial');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `Id_Usuario` int(11) NOT NULL,
  `Apellido` varchar(150) NOT NULL,
  `Nombre` varchar(150) NOT NULL,
  `Mail` varchar(150) NOT NULL,
  `Password` varchar(150) NOT NULL,
  `Rol` int(11) NOT NULL,
  `Avatar` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`Id_Usuario`, `Apellido`, `Nombre`, `Mail`, `Password`, `Rol`, `Avatar`) VALUES
(14, 'Admin', 'Admin', 'admin@gmail.com', 'GAKKw6Co5EiIGNiZC1OfQC6offL+e8CoEs3SX0LIrHA=', 1, '/Uploads\\avatar_414ce472-5e2d-46e9-a447-9410387ea22d.jpg'),
(15, 'Brianzo', 'Matias', 'usuario@gmail.com', 'GAKKw6Co5EiIGNiZC1OfQC6offL+e8CoEs3SX0LIrHA=', 2, '/Uploads\\avatar_a9883a62-6db4-405e-b0d0-96fba0064b55.jpg');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contratos`
--
ALTER TABLE `contratos`
  ADD PRIMARY KEY (`Id_Contrato`),
  ADD KEY `Id_Inmueble` (`Id_Inmueble`,`Id_Inquilino`),
  ADD KEY `Id_Inquilino` (`Id_Inquilino`);

--
-- Indices de la tabla `inmuebles`
--
ALTER TABLE `inmuebles`
  ADD PRIMARY KEY (`Id_Inmueble`),
  ADD KEY `Id_Uso` (`Id_Uso`,`Id_Tipo`,`Id_Propietario`),
  ADD KEY `Id_Tipo` (`Id_Tipo`),
  ADD KEY `Id_Propietario` (`Id_Propietario`);

--
-- Indices de la tabla `inquilinos`
--
ALTER TABLE `inquilinos`
  ADD PRIMARY KEY (`Id_Inquilino`);

--
-- Indices de la tabla `pagos`
--
ALTER TABLE `pagos`
  ADD PRIMARY KEY (`Id_Pago`),
  ADD KEY `Id_Contrato` (`Id_Contrato`);

--
-- Indices de la tabla `propietarios`
--
ALTER TABLE `propietarios`
  ADD PRIMARY KEY (`Id_Propietario`);

--
-- Indices de la tabla `tipos`
--
ALTER TABLE `tipos`
  ADD PRIMARY KEY (`Id_Tipo`);

--
-- Indices de la tabla `usos`
--
ALTER TABLE `usos`
  ADD PRIMARY KEY (`Id_Uso`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id_Usuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `contratos`
--
ALTER TABLE `contratos`
  MODIFY `Id_Contrato` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT de la tabla `inmuebles`
--
ALTER TABLE `inmuebles`
  MODIFY `Id_Inmueble` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `inquilinos`
--
ALTER TABLE `inquilinos`
  MODIFY `Id_Inquilino` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `pagos`
--
ALTER TABLE `pagos`
  MODIFY `Id_Pago` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT de la tabla `propietarios`
--
ALTER TABLE `propietarios`
  MODIFY `Id_Propietario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `tipos`
--
ALTER TABLE `tipos`
  MODIFY `Id_Tipo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `usos`
--
ALTER TABLE `usos`
  MODIFY `Id_Uso` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id_Usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `contratos`
--
ALTER TABLE `contratos`
  ADD CONSTRAINT `CONTRATOS_ibfk_1` FOREIGN KEY (`Id_Inquilino`) REFERENCES `inquilinos` (`Id_Inquilino`) ON UPDATE CASCADE,
  ADD CONSTRAINT `CONTRATOS_ibfk_2` FOREIGN KEY (`Id_Inmueble`) REFERENCES `inmuebles` (`Id_Inmueble`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `inmuebles`
--
ALTER TABLE `inmuebles`
  ADD CONSTRAINT `INMUEBLES_ibfk_1` FOREIGN KEY (`Id_Uso`) REFERENCES `usos` (`Id_Uso`) ON UPDATE CASCADE,
  ADD CONSTRAINT `INMUEBLES_ibfk_2` FOREIGN KEY (`Id_Tipo`) REFERENCES `tipos` (`Id_Tipo`) ON UPDATE CASCADE,
  ADD CONSTRAINT `INMUEBLES_ibfk_3` FOREIGN KEY (`Id_Propietario`) REFERENCES `propietarios` (`Id_Propietario`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `pagos`
--
ALTER TABLE `pagos`
  ADD CONSTRAINT `PAGOS_ibfk_1` FOREIGN KEY (`Id_Contrato`) REFERENCES `contratos` (`Id_Contrato`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
