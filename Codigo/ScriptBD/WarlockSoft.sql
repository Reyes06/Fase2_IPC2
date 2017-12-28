/*
USE practica;
DROP DATABASE WarlockSoft;
CREATE DATABASE WarlockSoft;
USE WarlockSoft;
*/

CREATE TABLE Usuario(
id_usuario bigint  AUTO_INCREMENT PRIMARY KEY NOT NULL,
nombre varchar(50) NOT NULL,
correo varchar(50) NOT NULL,
fecha date NOT NULL, 
password varchar(50) NOT NULL,
nickname varchar(50) NOT NULL
);

CREATE TABLE Asociacion(
id_asociacion bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
nombre varchar(50) NOT NULL
);

CREATE TABLE UsuariosPorAsociacion(
id_UPA bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
tipo varchar(50) NOT NULL,
id_usuario bigint NOT NULL,
id_asociacion bigint NOT NULL,
FOREIGN KEY (id_usuario) REFERENCES Usuario (id_usuario),
FOREIGN KEY (id_asociacion) REFERENCES Asociacion (id_asociacion)
);

CREATE TABLE Publicacion(
id_publicacion bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
contenido varchar(250) NOT NULL,
id_usuario bigint NOT NULL,
FOREIGN KEY (id_usuario) REFERENCES Usuario (id_usuario)
);

CREATE TABLE Comentario(
id_comentario bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
contenido varchar(250) NOT NULL,
id_usuario bigint NOT NULL,
id_publicacion bigint NOT NULL,
FOREIGN KEY (id_usuario) REFERENCES Usuario (id_usuario),
FOREIGN KEY (id_publicacion) REFERENCES Publicacion (id_publicacion)
);

CREATE TABLE Mensaje(
id_mensaje bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
contenido varchar(250) NOT NULL,
id_emisor bigint NOT NULL,
id_receptor bigint NOT NULL,
FOREIGN KEY (id_emisor) REFERENCES Usuario (id_usuario),
FOREIGN KEY (id_receptor) REFERENCES Usuario (id_usuario)
);

CREATE TABLE Habilidad(
id_habilidad bigint AUTO_INCREMENT  PRIMARY KEY NOT NULL,
nombre varchar(50) NOT NULL
);

CREATE TABLE Conocimiento(
id_conocimiento bigint AUTO_INCREMENT  PRIMARY KEY NOT NULL,
nombre varchar(50) NOT NULL,
id_habilidad bigint NOT NULL,
FOREIGN KEY (id_habilidad) REFERENCES Habilidad (id_habilidad)
);

CREATE TABLE ConocimientosPorUsuario(
id_conPorU bigint AUTO_INCREMENT PRIMARY KEY,
karma int not null,
id_usuario int not null,
id_conocimiento int not null,
FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario),
foreign key (id_conocimiento) references conocimiento(id_conocimiento)
);

CREATE TABLE KarmaExtra(
id_karmaExtra bigint AUTO_INCREMENT  PRIMARY KEY NOT NULL,
karma int NOT NULL,
id_CPU bigint NOT NULL,
id_conPorU bigint NOT NULL,
FOREIGN KEY (id_CPU) REFERENCES ContactosPorUsuario (id_CPU),
FOREIGN KEY (id_conPorU) REFERENCES ConocimientosPorUsuario (id_conPorU)
);



CREATE TABLE ContactosPorUsuario(
id_CPU bigint AUTO_INCREMENT  PRIMARY KEY NOT NULL,
id_usuario bigint NOT NULL,
id_contacto bigint NOT NULL,
FOREIGN KEY (id_usuario) REFERENCES Usuario (id_usuario),
FOREIGN KEY (id_contacto) REFERENCES Usuario (id_usuario)
);

CREATE TABLE Tarea(
id_tarea bigint AUTO_INCREMENT  PRIMARY KEY NOT NULL,
nombre varchar(50) NOT NULL,
descripcion varchar(250) NOT NULL,
fecha_ini Date NOT NULL,
precio double NOT NULL,
tiempoEstimado int not null,
cantidadParticipantes int not null,
estado varchar(50) not null,
id_usuario bigint NOT NULL,
FOREIGN KEY (id_usuario) REFERENCES Usuario (id_usuario)
);

CREATE TABLE ConocimientoNecesario(
id_CN bigint AUTO_INCREMENT  PRIMARY KEY NOT NULL,
id_conocimiento bigint NOT NULL,
id_tarea bigint NOT NULL,
FOREIGN KEY (id_conocimiento) REFERENCES Conocimiento (id_conocimiento),
FOREIGN KEY (id_tarea) REFERENCES Tarea (id_tarea)
);

CREATE TABLE Proyecto(
id_proyecto bigint AUTO_INCREMENT  PRIMARY KEY NOT NULL,
nombre varchar(50) NOT NULL,
fecha_ini Date NOT NULL,
fecha_fin DATE NOT NULL,
estado varchar(50) not null,
salario double not null,
modoPago varchar(50) not null,
id_usuario bigint NOT NULL,
FOREIGN KEY (id_usuario) REFERENCES Usuario (id_usuario)
);

CREATE TABLE TareasPorProyecto(
id_TPP bigint AUTO_INCREMENT  PRIMARY KEY NOT NULL,
id_tarea bigint NOT NULL,
id_proyecto bigint NOT NULL,
FOREIGN KEY (id_tarea) REFERENCES Tarea (id_tarea),
FOREIGN KEY (id_proyecto) REFERENCES Proyecto(id_proyecto)
);

