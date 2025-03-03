USE MASTER

GO

CREATE DATABASE MATRICULA_2024

GO
USE MATRICULA_2024

GO

CREATE TABLE PERIODOS (
                ID_PERIODO INT IDENTITY(1,1) NOT NULL,
                NUM_PERIODO TINYINT NOT NULL,
                ANIO SMALLINT NOT NULL,
                FECHAI_MATRICULA DATE NOT NULL,
                FECHAF_MATRICULA DATE NOT NULL,
                FECHAI_EXTRAORDINARIO DATE NOT NULL,
                FECHAF_EXTRAORDINARIO DATE NOT NULL,
                CONSTRAINT PK_PERIODOS PRIMARY KEY (ID_PERIODO)
)

CREATE TABLE MATERIAS (
                ID_MATERIA VARCHAR(10) NOT NULL,
                NOMBRE_MATERIA VARCHAR(120) NOT NULL,
                CREDITOS TINYINT NOT NULL,
                BORRADO BIT DEFAULT 0 NOT NULL,
                CONSTRAINT PK_MATERIAS PRIMARY KEY (ID_MATERIA)
)

CREATE TABLE PROFESORES (
                COD_PROFESOR INT IDENTITY(1,1) NOT NULL,
                ID_PROFESOR VARCHAR(20) NOT NULL,
                NOMBRE_P VARCHAR(25) NOT NULL,
                APELLIDO1_P VARCHAR(20) NOT NULL,
                APELLIDO2_P VARCHAR(20),
                TELEFONO_P VARCHAR(8) NOT NULL,
                CORREO_P VARCHAR(25) NOT NULL,
                ESTADO_P VARCHAR(3) DEFAULT 'ACT' NOT NULL,
                BORRADO BIT DEFAULT 0 NOT NULL,
                CONSTRAINT PK_PROFESORES PRIMARY KEY (COD_PROFESOR)
)

CREATE TABLE ESTUDIANTES (
                ID_ESTUDIANTE VARCHAR(20) NOT NULL,
                NOMBRE_E VARCHAR(25) NOT NULL,
                APELLIDO1_E VARCHAR(20) NOT NULL,
                APELLIDO2_E VARCHAR(20),
                TELEFONO1_E VARCHAR(8) NOT NULL,
                TELEFONO2_E VARCHAR(8),
                CORREO_E VARCHAR(25) NOT NULL,
                PROVINCIA VARCHAR(12) NOT NULL DEFAULT 'ALAJUELA',
                CANTON VARCHAR(20),
                DISTRITO VARCHAR(25),
                OTRAS_SENIAS VARCHAR(80),
                FECHA_NACIMIENTO DATE NOT NULL,
                FECHA_INGRESO DATE NOT NULL,
                ESTADO_E VARCHAR(3) NOT NULL DEFAULT 'ACT',
                BORRADO BIT DEFAULT 0 NOT NULL,
                CONSTRAINT PK_ESTUDIANTES PRIMARY KEY (ID_ESTUDIANTE)
)

CREATE TABLE MATRICULAS (
                NUM_RECIBO INT IDENTITY(1,1) NOT NULL,
                ID_ESTUDIANTE VARCHAR(20) NOT NULL,
                FECHA_MATRICULA DATETIME NOT NULL,
                ID_PERIODO INT NOT NULL,
                COSTO_MATRICULA DECIMAL(10,2) NOT NULL,
                DESCUENTO DECIMAL(4,2) DEFAULT 0 NOT NULL,
                ESTADO_M VARCHAR(3) NOT NULL DEFAULT 'ACT',
                CONSTRAINT PK_MATRICULAS PRIMARY KEY (NUM_RECIBO)
)

CREATE TABLE CARRERAS (
                ID_CARRERA INT IDENTITY(1,1) NOT NULL,
                NOMBRE_CARRERA VARCHAR(100) NOT NULL,
                TOTAL_CREDITOS SMALLINT NOT NULL,
                GRADO VARCHAR(14) DEFAULT 'BACHILLERATO' NOT NULL,
                ESTADO_C VARCHAR(3) DEFAULT 'ACT' NOT NULL,
                BORRADO BIT DEFAULT 0 NOT NULL,
                CONSTRAINT PK_CARRERAS PRIMARY KEY (ID_CARRERA)
)

CREATE TABLE MATERIAS_CARRERAS (
                ID_MATERIA_CARRERA INT IDENTITY(1,1) NOT NULL,
                ID_CARRERA INT NOT NULL,
                ID_MATERIA VARCHAR(10) NOT NULL,
                BORRADO BIT DEFAULT 0 NOT NULL,
                REQUISITO VARCHAR(10) NULL,
                CONSTRAINT PK_MATERIAS_CARRERAS PRIMARY KEY (ID_MATERIA_CARRERA)
)

CREATE TABLE MATERIAS_ABIERTAS (
                ID_MATERIA_ABIERTA INT IDENTITY(1,1) NOT NULL,
                GRUPO TINYINT NOT NULL,
                CUPO TINYINT NOT NULL,
                COSTO DECIMAL(10,2) NOT NULL,
                DESCUENTO DECIMAL(4,2) DEFAULT 0 NOT NULL,
                CANT_MATRICULADOS TINYINT DEFAULT 0 NOT NULL,
                ID_PERIODO INT NOT NULL,
                COD_PROFESOR INT NULL,
                ID_MATERIA_CARRERA INT NOT NULL,
				ID_AULA INT NULL
                CONSTRAINT PK_MATERIAS_ABIERTAS PRIMARY KEY (ID_MATERIA_ABIERTA)
)

CREATE TABLE DETALLES_MATRICULA (
                NUM_RECIBO INT NOT NULL,
                ID_MATERIA_ABIERTA INT NOT NULL,
                NOTA_FINAL DECIMAL(5,2) DEFAULT 0 NOT NULL,
                ESTADO_D VARCHAR(3) NOT NULL DEFAULT 'ACT',
                OBSERVACIONES VARCHAR(500),
				CONSTRAINT PK_DETALLES_MATRICULA PRIMARY KEY (NUM_RECIBO,ID_MATERIA_ABIERTA)
)

CREATE TABLE HORARIOS (
                ID_MATERIA_ABIERTA INT NOT NULL,
                DIA VARCHAR NOT NULL,
                HORA_INICIO TIME NOT NULL,
                HORA_FIN TIME NOT NULL,
                CONSTRAINT PK_HORARIOS PRIMARY KEY (ID_MATERIA_ABIERTA, DIA, HORA_INICIO, HORA_FIN)
)

CREATE TABLE AULAS (
                ID_AULA INT IDENTITY(1,1) NOT NULL,
                CAPACIDAD SMALLINT NOT NULL,
                TIPO VARCHAR(20) NOT NULL,
                CONSTRAINT PK_AULAS PRIMARY KEY (ID_AULA)
)

-- FOREIGN KEY

ALTER TABLE MATERIAS_ABIERTAS ADD CONSTRAINT PERIODOS_MATERIAS_ABIERTAS_fk
FOREIGN KEY (ID_PERIODO)
REFERENCES PERIODOS (ID_PERIODO)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE MATERIAS_ABIERTAS ADD CONSTRAINT PROFESORES_MATERIAS_ABIERTAS_fk
FOREIGN KEY (COD_PROFESOR)
REFERENCES PROFESORES (COD_PROFESOR)

ALTER TABLE MATERIAS_ABIERTAS ADD CONSTRAINT AULAS_MATERIAS_ABIERTAS_fk
FOREIGN KEY (ID_AULA)
REFERENCES AULAS (ID_AULA)


ALTER TABLE MATERIAS_ABIERTAS ADD CONSTRAINT MATERIAS_CARRERAS_MATERIAS_ABIERTAS_fk
FOREIGN KEY (ID_MATERIA_CARRERA)
REFERENCES MATERIAS_CARRERAS (ID_MATERIA_CARRERA)


ALTER TABLE MATRICULAS ADD CONSTRAINT PERIODOS_MATRICULAS_fk
FOREIGN KEY (ID_PERIODO)
REFERENCES PERIODOS (ID_PERIODO)


ALTER TABLE MATRICULAS ADD CONSTRAINT ESTUDIANTES_MATRICULAS_fk
FOREIGN KEY (ID_ESTUDIANTE)
REFERENCES ESTUDIANTES (ID_ESTUDIANTE)


ALTER TABLE MATERIAS_CARRERAS ADD CONSTRAINT MATERIAS_MATERIAS_CARRERAS_fk
FOREIGN KEY (ID_MATERIA)
REFERENCES MATERIAS (ID_MATERIA)


ALTER TABLE MATERIAS_CARRERAS ADD CONSTRAINT CARRERAS_MATERIAS_CARRERAS_fk
FOREIGN KEY (ID_CARRERA)
REFERENCES CARRERAS (ID_CARRERA)


ALTER TABLE MATERIAS_CARRERAS ADD CONSTRAINT MATERIAS_CARRERAS_REQUISITO_fk
FOREIGN KEY (REQUISITO)
REFERENCES MATERIAS (ID_MATERIA)


ALTER TABLE DETALLES_MATRICULA ADD CONSTRAINT MATRICULAS_DETALLES_MATRICULA_fk
FOREIGN KEY (NUM_RECIBO)
REFERENCES MATRICULAS (NUM_RECIBO)


ALTER TABLE DETALLES_MATRICULA ADD CONSTRAINT MATERIAS_ABIERTAS_DETALLES_MATRICULA_fk
FOREIGN KEY (ID_MATERIA_ABIERTA)
REFERENCES MATERIAS_ABIERTAS (ID_MATERIA_ABIERTA)


ALTER TABLE HORARIOS ADD CONSTRAINT MATERIAS_ABIERTAS_HORARIOS_fk
FOREIGN KEY (ID_MATERIA_ABIERTA)
REFERENCES MATERIAS_ABIERTAS (ID_MATERIA_ABIERTA)


--Restricciones check

alter table CARRERAS
   add constraint CK_GRADO_CARRERA check (Grado in ('Diplomado','Bachillerato','Licenciatura','Maestr�a'))

alter table CARRERAS
   add constraint CK_TOTAL_CREDITOS_CARRERA check (Total_Creditos >= 0 and Total_Creditos<=1000)

alter table CARRERAS
   add constraint CK_ESTADO_CARRERA check (ESTADO_C in ('ACT','INA') and ESTADO_C = upper(ESTADO_C))

alter table PROFESORES
   add constraint CK_ESTADO_PROFESOR check (ESTADO_P in ('ACT','INA') and ESTADO_P = upper(ESTADO_P))


alter table Estudiantes
   add constraint CK_ESTADO_ESTUDIAN check (ESTADO_E in ('ACT','INA') and ESTADO_E = upper(ESTADO_E))


alter table Estudiantes
   add constraint CK_provincia_est check (Provincia is null or 
   (Provincia in ('San Jos�','Alajuela','Heredia','Cartago','Guanacaste','Puntarenas','Lim�n')))

alter table Materias
   add constraint CKC_CANTIDAD_CREDITOS check (CREDITOS between 0 and 12)


alter table Horarios
   add constraint CK_DIA_HORARIO_ check (DIA in ('L','K','M','J','V','S') and DIA = upper(DIA))


alter table PERIODOS
   add constraint CKC_PERIODO check (NUM_PERIODO between 1 and 3)


alter table Materias_Abiertas
   add constraint CKC_COSTO_MATERIA_ check (COSTO > 0)

alter table Materias_Abiertas
   add constraint CKC_DESCUENTO_MATERIA_ check (DESCUENTO >= 0 AND DESCUENTO<=100)

alter table PERIODOS
   add constraint CKC_anio check (ANIO >= Year(getDate()))


alter table Matriculas
   add constraint CKC_COSTO_MATRICULA check (COSTO_MATRICULA >= 0)

alter table Matriculas
   add constraint CKC_DESCUENTO_MATRICULA check (DESCUENTO >= 0 AND DESCUENTO<=100)


alter table Matriculas
   add constraint CKC_ESTADO_MATRICUL check (ESTADO_M in ('Act','Ina','Anu'))


alter table Detalles_Matricula
   add constraint CK_ESTADO_DETALLE_ check (Estado_D in ('ACT','RET','APR','REP','DST') and ESTADO_D = upper(ESTADO_D))


alter table Detalles_Matricula
   add constraint CK_NOTA_FINAL_DETALLE_ check (Nota_Final is null or (Nota_Final BETWEEN 0 and 100))


