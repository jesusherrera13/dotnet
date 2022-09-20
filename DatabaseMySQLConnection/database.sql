DROP DATABASE IF EXISTS beisbol;
CREATE DATABASE beisbol;
USE beisbol;
CREATE TABLE jugadores (
	id INT NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(50),
    apellido1 VARCHAR(50),
    PRIMARY KEY (id)
);

INSERT INTO jugadores (nombre,apellido1) VALUES ('Leon S.','Kennedy');
INSERT INTO jugadores (nombre,apellido1) VALUES ('Thomas A.','Anderson');
INSERT INTO jugadores (nombre,apellido1) VALUES ('Bruce','Wayne');