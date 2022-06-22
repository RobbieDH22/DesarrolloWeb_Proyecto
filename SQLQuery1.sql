create database GYM;
use GYM;


create table tb_persona(
	dni int not null primary key,
    nombre nvarchar(100) not null,
	apellidos nvarchar(100) not null,
    direccion nvarchar(100),
    telefono int,
    correo nvarchar(100),
	contrasena nvarchar(50),
    fecha_nacimiento date not null,
    sexo varchar(1),
);

create table tb_empleado(
	codigoEmp int not null primary key,
	nombreCompleto nvarchar(100) not null,
    dniPersona int not null,
	contrasena nvarchar(50),
    fecha_ing date not null,
    fecha_fin date,
	cargo nvarchar(50),
	estado nvarchar(50),
	CONSTRAINT fk_empleado_tb_persona FOREIGN KEY (dniPersona) REFERENCES tb_persona (dni)
);

create table tb_cliente(
	codigoCliente int not null primary key,
    nombreCompleto nvarchar(100) not null,
	contrasena nvarchar(50),
	dniCliente int not null,
    fecha_ini date not null,
    fecha_fin date,
	estado nvarchar(50),
	CONSTRAINT fk_cliente_tb_persona FOREIGN KEY (dniCliente) REFERENCES tb_persona (dni)
);



create table tb_sede(
	codigoSede int not null primary key,
	provincia nvarchar(100) not null,
	distrito nvarchar(100) not null,
	direccion nvarchar(100) not null
);

create table tb_planes(
	codigoPlan int not null primary key,
    nombre nvarchar(100) not null,
    descripcion nvarchar(2000) not null,
    precio float not null 
);

create table tb_promocion(
	codigoProm int not null primary key,
    nombre varchar(100) not null,
    descripcion nvarchar(2000),
    descuento int not null,
    fecha_ini date not null,
    fecha_fin date not null
);

create table tb_bienes_gimnasio(
	codigoBien int not null primary key,
	nombre varchar(100) not null,
    descripcion nvarchar(2000),
    fecha_adquisicion date not null,
    estado nvarchar(100)
);

create table tb_productos(
	codigoProd int not null primary key,
    nombre nvarchar(100) not null,
    descripcion nvarchar(2000) not null,
    stock int not null,
	precio float not null,
	fecha_ingreso time not null,
	estado nvarchar(50) not null
);

create table tb_servicios(
	codigoServicio int not null primary key,
    nombre nvarchar(100) not null,
    descripcion nvarchar(2000) not null,
    estado nvarchar(50) not null
);

create table tb_proveedor(
	codigoProv int not null primary key,
    nombre nvarchar(100) not null,
    telefono int not null,
	correo int,
    descripcion nvarchar(100) not null
);


create table tb_evento(
	codigoEvento int not null primary key,
    nombre nvarchar(100) not null,
    descripcion nvarchar(2000) not null,
    fecha_ini date not null,
    fecha_fin date not null,
    hora_ini time not null,
    hora_fin time not null,
    costo_entrada float not null,
    codigo_sede int not null,
	cant_limite int not null,
	codigo_servicio int not null,
	CodigoInstructor int not null
	CONSTRAINT fk_evento_tb_sede FOREIGN KEY (codigo_sede) REFERENCES tb_sede (codigoSede),
	CONSTRAINT fk_evento_tb_empleado FOREIGN KEY (CodigoInstructor) REFERENCES tb_empleado (codigoEmp),
	CONSTRAINT fk_evento_tb_servicios FOREIGN KEY (codigo_servicio) REFERENCES tb_servicios (codigoServicio)
);

create table tb_inscripcionMembresia(
	codigoMembresia int not null primary key,
    dniMiembro nvarchar(100) not null,
    codCliente int not null,
	codEmpleadoGestor int not null,
	fechaRegistro date not null,
	fechaInic date not null,
	fechaFin date not null,
	codServicio int not null,
	codPlan int not null,
	codProm int not null,
	CONSTRAINT fk_inscMemb_tb_cliente FOREIGN KEY (codCliente) REFERENCES tb_cliente (codigoCliente),
	CONSTRAINT fk_inscMemb_tb_empleado FOREIGN KEY (codEmpleadoGestor) REFERENCES tb_empleado (codigoEmp),
	CONSTRAINT fk_inscMemb_tb_servicios FOREIGN KEY (codServicio) REFERENCES tb_servicios (codigoServicio),
	CONSTRAINT fk_inscMemb_tb_planes FOREIGN KEY (codPlan) REFERENCES tb_planes (codigoPlan),
	CONSTRAINT fk_inscMemb_tb_promocion FOREIGN KEY (codPlan) REFERENCES tb_promocion (codigoProm)
);

create table tb_venta(
	codigoVenta int not null primary key,
    codProducto int not null,
    fechaVenta date not null,
    dniCliente int not null,
	cantidad int not null,
	precioVenta float not null
	CONSTRAINT fk_venta_tb_productos FOREIGN KEY (codProducto) REFERENCES tb_productos (codigoProd),
);

create table tb_compra(
	codigoCompra int not null primary key,
    CodProveedor int not null,
    fechaCompra date not null,
	codgBien int,
	codgProducto int,
	cantidad int not null,
	precioCompra float not null
	CONSTRAINT fk_compra_tb_productos FOREIGN KEY (codgProducto) REFERENCES tb_productos (codigoProd),
	CONSTRAINT fk_compra_tb_proveedor FOREIGN KEY (codgProducto) REFERENCES tb_proveedor (codigoProv),
	CONSTRAINT fk_compra_tb_bienes_gimnasio FOREIGN KEY (codgBien) REFERENCES tb_bienes_gimnasio (codigoBien)
);

create table tb_Inscrip_Evento(
	codigoInscripcion int not null primary key,
    CodEvento int not null,
    CodCliente int not null,
	CodigoInstructor int not null,
	CONSTRAINT fk_Inscrip_Evento_tb_empleado FOREIGN KEY (CodigoInstructor) REFERENCES tb_empleado (codigoEmp),
	CONSTRAINT fk_Inscrip_Evento_tb_cliente FOREIGN KEY (CodCliente) REFERENCES tb_cliente (codigoCliente),
	CONSTRAINT fk_Inscrip_Evento_tb_evento FOREIGN KEY (CodEvento) REFERENCES tb_evento (codigoEvento)
);


create table tb_Asistencia(
	codigoAsistencia int not null primary key,
    Fecha date not null,
    CodCliente int not null,
	CodMembresia int not null,
	CONSTRAINT fk_tb_Asistencia_tb_cliente FOREIGN KEY (CodCliente) REFERENCES tb_cliente (codigoCliente),
	CONSTRAINT fk_tb_Asistencia_tb_inscripcionMembresia FOREIGN KEY (CodMembresia) REFERENCES tb_inscripcionMembresia (codigoMembresia)
);


