Insert into Provincias (Nombre) Values
('San Jos�'),
('Alajuela'),
('Heredia'),
('Cartago'),
('Guanacaste'),
('Puntarenas'),
('Lim�n')


-- Inserciones para la tabla Cantones
INSERT INTO Cantones (Nombre, provinciaID) VALUES
('San Jos�', 1),
('Escaz�', 1),
('Desamparados', 1),
('Puriscal', 1),
('Tarraz�', 1),
('Aserr�', 1),
('Mora', 1),
('Goicoechea', 1),
('Santa Ana', 1),
('Alajuelita', 1),
('V�zquez de Coronado', 1),
('Acosta', 1),
('Tib�s', 1),
('Moravia', 1),
('Montes de Oca', 1),
('Turrubares', 1),
('Dota', 1),
('Curridabat', 1),
('P�rez Zeled�n', 1),
('Le�n Cort�s', 1),
('Alajuela', 2),
('San Ram�n', 2),
('Grecia', 2),
('San Mateo', 2),
('Atenas', 2),
('Naranjo', 2),
('Palmares', 2),
('Po�s', 2),
('Orotina', 2),
('San Carlos', 2),
('Zarcero', 2),
('Valverde Vega', 2),
('Upala', 2),
('Los Chiles', 2),
('Guatuso', 2),
('R�o Cuarto', 2),
('Cartago', 3),
('Para�so', 3),
('La Uni�n', 3),
('Jim�nez', 3),
('Turrialba', 3),
('Alvarado', 3),
('Oreamuno', 3),
('El Guarco', 3),
('Heredia', 4),
('Barva', 4),
('Santo Domingo', 4),
('Santa B�rbara', 4),
('San Rafael', 4),
('San Isidro', 4),
('Bel�n', 4),
('Flores', 4),
('San Pablo', 4),
('Sarapiqu�', 4),
('Liberia', 5),
('Nicoya', 5),
('Santa Cruz', 5),
('Bagaces', 5),
('Carrillo', 5),
('Ca�as', 5),
('Abangares', 5),
('Tilar�n', 5),
('Nandayure', 5),
('La Cruz', 5),
('Hojancha', 5),
('Puntarenas', 6),
('Esparza', 6),
('Buenos Aires', 6),
('Montes de Oro', 6),
('Osa', 6),
('Quepos', 6),
('Golfito', 6),
('Coto Brus', 6),
('Parrita', 6),
('Corredores', 6),
('Garabito', 6),
('Monteverde', 6),
('Puerto Jim�nez', 6),
('Lim�n', 7),
('Pococ�', 7),
('Siquirres', 7),
('Talamanca', 7),
('Matina', 7),
('Gu�cimo', 7);


INSERT INTO Distritos (Nombre, CantonID) VALUES
-- San Jos� (Provincia 1)
('Carmen', 1),   -- San Jos�
('San Rafael', 2), -- Escaz�
('San Pedro', 15), -- Montes de Oca

-- Alajuela (Provincia 2)
('Alajuela', 21), -- Alajuela
('San Ram�n', 22), -- San Ram�n
('Ciudad Quesada', 30), -- San Carlos

-- Cartago (Provincia 3)
('Oriental', 36), -- Cartago
('Tres R�os', 38), -- La Uni�n
('Turrialba', 40), -- Turrialba

-- Heredia (Provincia 4)
('Heredia', 44), -- Heredia
('San Francisco', 49), -- San Isidro
('Barva', 45), -- Barva

-- Guanacaste (Provincia 5)
('Liberia', 53), -- Liberia
('Santa Cruz', 55), -- Santa Cruz
('Nicoya', 54), -- Nicoya

-- Puntarenas (Provincia 6)
('Puntarenas', 64), -- Puntarenas
('Quepos', 69), -- Quepos
('Golfito', 70), -- Golfito

-- Lim�n (Provincia 7)
('Lim�n', 75), -- Lim�n
('Gu�piles', 76), -- Pococ�
('Bribri', 78); -- Talamanca

INSERT INTO Estudiantes (Id_Estudiante, Nombre, Apellido1_E, Apellido2_E, Telefono1_E, Telefono2_E, Correo_E, Otras_Senias, DistritoID, Fecha_Nacimiento, Fecha_Ingreso, Estado_E, Borrado) VALUES
('20240001', 'Juan', 'P�rez', 'G�mez', '87654321', NULL, 'juan.perez@email.com', 'Cerca del parque central', 1, '2002-05-15', '2024-02-01', 'Act', 0),
('20240002', 'Mar�a', 'Rodr�guez', 'L�pez', '88997766', '22334455', 'maria.rodriguez@email.com', 'Frente a la iglesia', 5, '2001-08-20', '2024-02-05', 'Act', 0),
('20240003', 'Carlos', 'Fern�ndez', NULL, '87878787', NULL, 'carlos.fernandez@email.com', 'A 200m del supermercado', 10, '2003-01-10', '2024-02-10', 'Act', 0),
('20240004', 'Ana', 'S�nchez', 'Morales', '88776655', '66554433', 'ana.sanchez@email.com', 'Barrio Las Flores', 15, '2000-11-25', '2024-02-15', 'Ina', 0),
('20240005', 'Pedro', 'G�mez', 'Ram�rez', '89998877', NULL, 'pedro.gomez@email.com', 'Urbanizaci�n El Bosque', 19, '2002-07-05', '2024-02-20', 'Act', 0);

Insert into Periodo (Num_Periodo, Anio, FechaI_Matricula, FechaF_Matricula, FechaI_Extraordinaria, FechaF_Extraordinaria) values
(1, 2025, '2025-03-10', '2025-03-21', '2025-03-22', '2025-03-28'),
(2, 2025, '2025-05-10', '2025-05-21', '2025-05-22', '2025-05-28')



INSERT INTO Carreras (Nombre_Carrera, Total_Creditos, Grado, Estado_C, Borrado) VALUES
('Ingenier�a en Sistemas', 180, 'Licenciatura', 'Act', 0),
('Administraci�n de Empresas', 150, 'Bachillerato', 'Act', 0),
('Psicolog�a', 160, 'Licenciatura', 'Act', 0),
('Enfermer�a', 140, 'Diplomado', 'Ina', 0),
('Derecho', 170, 'Maestr�a', 'Act', 0);

INSERT INTO Materias (Id_Materia, Nombre_Materia, Creditos, Borrado) VALUES
-- Materias generales
('MAT101', 'Matem�ticas B�sicas', 4, 0),
('ESP102', 'Espa�ol T�cnico', 3, 0),
('HIS103', 'Historia Universal', 3, 0),
('ING104', 'Ingl�s T�cnico', 3, 0),
('FIL105', 'Filosof�a y �tica', 2, 0),

-- Materias espec�ficas para Ingenier�a en Sistemas
('SIS201', 'Programaci�n Orientada a Objetos', 4, 0),
('SIS202', 'Estructuras de Datos', 4, 0),
('SIS203', 'Bases de Datos', 4, 0),
('SIS204', 'Redes de Computadoras', 3, 0),
('SIS205', 'Seguridad Inform�tica', 3, 0),

-- Materias espec�ficas para Administraci�n de Empresas
('ADM301', 'Contabilidad Financiera', 4, 0),
('ADM302', 'Marketing Digital', 3, 0),
('ADM303', 'Gesti�n de Recursos Humanos', 3, 0),
('ADM304', 'Emprendimiento e Innovaci�n', 3, 0),
('ADM305', 'An�lisis Financiero', 4, 0),

-- Materias espec�ficas para Psicolog�a
('PSI401', 'Psicolog�a General', 3, 0),
('PSI402', 'Neuropsicolog�a', 4, 0),
('PSI403', 'Psicolog�a Cl�nica', 4, 0),
('PSI404', 'Psicolog�a del Desarrollo', 3, 0),
('PSI405', 'Terapias Cognitivo-Conductuales', 3, 0),

-- Materias espec�ficas para Enfermer�a
('ENF501', 'Fundamentos de Enfermer�a', 4, 0),
('ENF502', 'Farmacolog�a', 3, 0),
('ENF503', 'Enfermer�a Comunitaria', 3, 0),
('ENF504', 'Cuidados Intensivos', 4, 0),
('ENF505', '�tica en Enfermer�a', 2, 0),

-- Materias espec�ficas para Derecho
('DER601', 'Derecho Civil', 4, 0),
('DER602', 'Derecho Penal', 4, 0),
('DER603', 'Derecho Constitucional', 3, 0),
('DER604', 'Derecho Mercantil', 3, 0),
('DER605', 'Derecho Internacional', 3, 0);


INSERT INTO Materias_Carreras (Id_Materia, Id_Carrera, Id_Requisito, Borrado) VALUES
-- Ingenier�a en Sistemas
('MAT101', 1, NULL, 0),
('ESP102', 1, NULL, 0),
('SIS201', 1, NULL, 0),
('SIS202', 1, 'SIS201', 0),
('SIS203', 1, 'SIS202', 0),
('SIS204', 1, NULL, 0),
('SIS205', 1, 'SIS203', 0),

-- Administraci�n de Empresas
('MAT101', 2, NULL, 0),
('ESP102', 2, NULL, 0),
('ADM301', 2, NULL, 0),
('ADM302', 2, NULL, 0),
('ADM303', 2, NULL, 0),
('ADM304', 2, NULL, 0),
('ADM305', 2, 'ADM301', 0),

-- Psicolog�a
('ESP102', 3, NULL, 0),
('PSI401', 3, NULL, 0),
('PSI402', 3, 'PSI401', 0),
('PSI403', 3, 'PSI402', 0),
('PSI404', 3, NULL, 0),
('PSI405', 3, 'PSI403', 0),

-- Enfermer�a
('MAT101', 4, NULL, 0),
('ESP102', 4, NULL, 0),
('ENF501', 4, NULL, 0),
('ENF502', 4, 'ENF501', 0),
('ENF503', 4, NULL, 0),
('ENF504', 4, 'ENF502', 0),
('ENF505', 4, NULL, 0),

-- Derecho
('ESP102', 5, NULL, 0),
('FIL105', 5, NULL, 0),
('DER601', 5, NULL, 0),
('DER602', 5, 'DER601', 0),
('DER603', 5, NULL, 0),
('DER604', 5, 'DER603', 0),
('DER605', 5, 'DER602', 0);

INSERT INTO Profesores (Id_Profesor, Nombre, Apellido1_P, Apellido2_P, Telefono_P, Correo_E, Estado_P, Borrado) VALUES
('1-1234-5678', 'Carlos', 'Ram�rez', 'G�mez', '88887777', 'carlos.ramirez@uni.ac.cr', 'Act', 0),
('2-2345-6789', 'Mar�a', 'Fern�ndez', 'Soto', '88776655', 'maria.fernandez@uni.ac.cr', 'Act', 0),
('3-3456-7890', 'Andr�s', 'L�pez', NULL, '89998877', 'andres.lopez@uni.ac.cr', 'Ina', 0),
('4-4567-8901', 'Luc�a', 'Castro', 'Mora', '87654321', 'lucia.castro@uni.ac.cr', 'Act', 0),
('5-5678-9012', 'Javier', 'Hern�ndez', NULL, '84567890', 'javier.hernandez@uni.ac.cr', 'Act', 0),
('6-6789-0123', 'Sof�a', 'Vargas', 'Jim�nez', '85432167', 'sofia.vargas@uni.ac.cr', 'Ina', 0),
('7-7890-1234', 'Esteban', 'Salazar', NULL, '81234567', 'esteban.salazar@uni.ac.cr', 'Act', 0),
('8-8901-2345', 'Ana', 'Guzm�n', 'Rodr�guez', '89990011', 'ana.guzman@uni.ac.cr', 'Act', 0),
('9-9012-3456', 'Roberto', 'S�enz', NULL, '83334455', 'roberto.saenz@uni.ac.cr', 'Ina', 0),
('10-0123-4567', 'Daniela', 'Montoya', 'Ruiz', '82223344', 'daniela.montoya@uni.ac.cr', 'Act', 0);

INSERT INTO Aulas (Capacidad, Tipo) VALUES
(30, 'Aula Regular'),
(50, 'Laboratorio de C�mputo'),
(40, 'Aula Multimedia'),
(20, 'Sala de Conferencias'),
(35, 'Laboratorio de Qu�mica'),
(45, 'Aula de Idiomas'),
(25, 'Sala de M�sica'),
(60, 'Auditorio'),
(30, 'Taller de Electr�nica'),
(50, 'Biblioteca');

INSERT INTO Materias_Abiertas (Grupo, Cupos, Costo, Descuento, id_Periodo, id_Profesor, id_Aula, id_MateriaCarrera, Estado) VALUES
(1, 30, 200.00, 10.00, 1, 7, 1, 1, 'ACT'),
(2, 25, 180.00, 5.00, 1, 8, 2, 2, 'ACT'),
(1, 40, 250.00, 15.00, 1, 11, 3, 3, 'ACT'),
(2, 20, 220.00, 8.00, 1, 10, 4, 4, 'ACT'),
(1, 35, 190.00, 12.00, 1, 16, 5, 5, 'ACT'),
(2, 50, 270.00, 10.00, 1, 16, 6, 6, 'ACT'),
(1, 25, 160.00, 7.00, 1, 14, 7, 7, 'ACT'),
(2, 30, 200.00, 5.00, 1, 13, 8, 8, 'ACT')
