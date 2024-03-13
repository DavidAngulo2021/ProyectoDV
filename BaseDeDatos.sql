

create database DB_pruebaDV

use DB_pruebaDV;

CREATE TABLE TRACE (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Identificador VARCHAR(20),
    FechaYHora DATETIME,
    Longitud DECIMAL(9, 6),
    Latitud DECIMAL(8, 6),
    Dispositivo NVARCHAR(100)
);

select * from TRACE