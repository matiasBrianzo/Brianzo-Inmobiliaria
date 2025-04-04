
--
-- Base de datos: `inmobiliaria`
--

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

CREATE TABLE `Propietarios` (
  `IdPropietario` int(11) NOT NULL,
  `Apellido` varchar(150) NOT NULL,
  `Nombre` varchar(150) NOT NULL,
  `Dni` varchar(10) NOT NULL,
  `Telefono` varchar(20) NOT NULL,
  `Email` varchar(150) NOT NULL,
  `Clave` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;



--
-- Volcado de datos para la tabla `Propietarios`
--

INSERT INTO `Propietarios` (`Apellido`, `Nombre`, `Dni`, `Telefono`, `Email`,`Clave`) VALUES
( 'Matias', 'Brianzo', '3588888887', '2664658749', 'b@gmail.com','11'),
('juan', 'Funes', '10456789', '2664321654', 'jf@gmail.com','12'),
('Elena', 'Demo', '11222333', '2664332211', 'ed@gmail.com','13'),
('Tomas', 'Nestor', '56222147', '2664485976', 'tn@gmail.com','14')


CREATE TABLE `Inquilinos` (
  `IdInquilino` int(11) NOT NULL,
  `Apellido` varchar(150) NOT NULL,
  `Nombre` varchar(150) NOT NULL,
  `Dni` varchar(10) NOT NULL,
  `Telefono` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


--
-- Volcado de datos para la tabla `inquilinos`
--

INSERT INTO `inquilinos` ( `Apellido`, `Nombre`, `Dni`, `Telefono`) VALUES
('Perez', 'Susanas', '25789321', '2664781435'),
('Carlos', 'Gomez', '48966123', '2664786954'),
('Rodriguez', 'Marta', '14586795', '2664787878'),
('Tomas', 'Raul', '69852741', '2664333214'),
('Jose', 'Pedro', '25666444', '2664888888'),
('Pedro', 'Tomas', '45789789', '2664555555');


Alter Table `Propietarios` 
Modify `IdPropietario` int NOT NULL AUTO_INCREMENT,
Add Primary key (`IdPropietario`); 

Alter Table `Inquilinos` 
Modify `IdInquilino` int NOT NULL AUTO_INCREMENT,
Add Primary key (`IdInquilino`); 