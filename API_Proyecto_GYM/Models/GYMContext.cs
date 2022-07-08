using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Proyecto_GYM.Models
{
    public partial class GYMContext : DbContext
    {
        public GYMContext()
        {
        }

        public GYMContext(DbContextOptions<GYMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAsistencia> TbAsistencia { get; set; } = null!;
        public virtual DbSet<TbBienesGimnasio> TbBienesGimnasio { get; set; } = null!;
        public virtual DbSet<TbCliente> TbCliente { get; set; } = null!;
        public virtual DbSet<TbCompra> TbCompra { get; set; } = null!;
        public virtual DbSet<TbEmpleado> TbEmpleado { get; set; } = null!;
        public virtual DbSet<TbEvento> TbEvento { get; set; } = null!;
        public virtual DbSet<TbInscripEvento> TbInscripEvento { get; set; } = null!;
        public virtual DbSet<TbInscripcionMembresia> TbInscripcionMembresia { get; set; } = null!;
        public virtual DbSet<TbPersona> TbPersona { get; set; } = null!;
        public virtual DbSet<TbPlanes> TbPlanes { get; set; } = null!;
        public virtual DbSet<TbProductos> TbProductos { get; set; } = null!;
        public virtual DbSet<TbPromocion> TbPromocion { get; set; } = null!;
        public virtual DbSet<TbProveedor> TbProveedor { get; set; } = null!;
        public virtual DbSet<TbSede> TbSede { get; set; } = null!;
        public virtual DbSet<TbServicios> TbServicios { get; set; } = null!;
        public virtual DbSet<TbVenta> TbVenta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-S1DROK0\\SQLEXPRESS;Database=GYM;Trusted_Connection=true;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAsistencia>(entity =>
            {
                entity.HasKey(e => e.CodigoAsistencia)
                    .HasName("PK__tb_Asist__64AFB868142CA286");

                entity.ToTable("tb_Asistencia");

                entity.Property(e => e.CodigoAsistencia)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoAsistencia");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.TbAsistencia)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_Asistencia_tb_cliente");

                entity.HasOne(d => d.CodMembresiaNavigation)
                    .WithMany(p => p.TbAsistencia)
                    .HasForeignKey(d => d.CodMembresia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_Asistencia_tb_inscripcionMembresia");
            });

            modelBuilder.Entity<TbBienesGimnasio>(entity =>
            {
                entity.HasKey(e => e.CodigoBien)
                    .HasName("PK__tb_biene__53AF6E9F17870277");

                entity.ToTable("tb_bienes_gimnasio");

                entity.Property(e => e.CodigoBien)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoBien");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2000)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaAdquisicion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_adquisicion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.CodigoCliente)
                    .HasName("PK__tb_clien__6B8A31ADC04E40FB");

                entity.ToTable("tb_cliente");

                entity.Property(e => e.CodigoCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoCliente");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(50)
                    .HasColumnName("contrasena");

                entity.Property(e => e.DniCliente).HasColumnName("dniCliente");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaIni)
                    .HasColumnType("date")
                    .HasColumnName("fecha_ini");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(100)
                    .HasColumnName("nombreCompleto");

                entity.HasOne(d => d.DniClienteNavigation)
                    .WithMany(p => p.TbCliente)
                    .HasForeignKey(d => d.DniCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente_tb_persona");
            });

            modelBuilder.Entity<TbCompra>(entity =>
            {
                entity.HasKey(e => e.CodigoCompra)
                    .HasName("PK__tb_compr__A495602361BA3436");

                entity.ToTable("tb_compra");

                entity.Property(e => e.CodigoCompra)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoCompra");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CodgBien).HasColumnName("codgBien");

                entity.Property(e => e.CodgProducto).HasColumnName("codgProducto");

                entity.Property(e => e.FechaCompra)
                    .HasColumnType("date")
                    .HasColumnName("fechaCompra");

                entity.Property(e => e.PrecioCompra).HasColumnName("precioCompra");

                entity.HasOne(d => d.CodgBienNavigation)
                    .WithMany(p => p.TbCompra)
                    .HasForeignKey(d => d.CodgBien)
                    .HasConstraintName("fk_compra_tb_bienes_gimnasio");

                entity.HasOne(d => d.CodgProductoNavigation)
                    .WithMany(p => p.TbCompra)
                    .HasForeignKey(d => d.CodgProducto)
                    .HasConstraintName("fk_compra_tb_productos");

                entity.HasOne(d => d.CodgProducto1)
                    .WithMany(p => p.TbCompra)
                    .HasForeignKey(d => d.CodgProducto)
                    .HasConstraintName("fk_compra_tb_proveedor");
            });

            modelBuilder.Entity<TbEmpleado>(entity =>
            {
                entity.HasKey(e => e.CodigoEmp)
                    .HasName("PK__tb_emple__73407B8FB9426326");

                entity.ToTable("tb_empleado");

                entity.Property(e => e.CodigoEmp)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoEmp");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .HasColumnName("cargo");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(50)
                    .HasColumnName("contrasena");

                entity.Property(e => e.DniPersona).HasColumnName("dniPersona");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaIng)
                    .HasColumnType("date")
                    .HasColumnName("fecha_ing");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(100)
                    .HasColumnName("nombreCompleto");

                entity.HasOne(d => d.DniPersonaNavigation)
                    .WithMany(p => p.TbEmpleado)
                    .HasForeignKey(d => d.DniPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_empleado_tb_persona");
            });

            modelBuilder.Entity<TbEvento>(entity =>
            {
                entity.HasKey(e => e.CodigoEvento)
                    .HasName("PK__tb_event__58E5324F2A92CDF2");

                entity.ToTable("tb_evento");

                entity.Property(e => e.CodigoEvento)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoEvento");

                entity.Property(e => e.CantLimite).HasColumnName("cant_limite");

                entity.Property(e => e.CodigoSede).HasColumnName("codigo_sede");

                entity.Property(e => e.CodigoServicio).HasColumnName("codigo_servicio");

                entity.Property(e => e.CostoEntrada).HasColumnName("costo_entrada");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2000)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaIni)
                    .HasColumnType("date")
                    .HasColumnName("fecha_ini");

                entity.Property(e => e.HoraFin).HasColumnName("hora_fin");

                entity.Property(e => e.HoraIni).HasColumnName("hora_ini");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.CodigoInstructorNavigation)
                    .WithMany(p => p.TbEvento)
                    .HasForeignKey(d => d.CodigoInstructor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evento_tb_empleado");

                entity.HasOne(d => d.CodigoSedeNavigation)
                    .WithMany(p => p.TbEvento)
                    .HasForeignKey(d => d.CodigoSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evento_tb_sede");

                entity.HasOne(d => d.CodigoServicioNavigation)
                    .WithMany(p => p.TbEvento)
                    .HasForeignKey(d => d.CodigoServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evento_tb_servicios");
            });

            modelBuilder.Entity<TbInscripEvento>(entity =>
            {
                entity.HasKey(e => e.CodigoInscripcion)
                    .HasName("PK__tb_Inscr__730F83D812B8AEC7");

                entity.ToTable("tb_Inscrip_Evento");

                entity.Property(e => e.CodigoInscripcion)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoInscripcion");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.TbInscripEvento)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Inscrip_Evento_tb_cliente");

                entity.HasOne(d => d.CodEventoNavigation)
                    .WithMany(p => p.TbInscripEvento)
                    .HasForeignKey(d => d.CodEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Inscrip_Evento_tb_evento");

                entity.HasOne(d => d.CodigoInstructorNavigation)
                    .WithMany(p => p.TbInscripEvento)
                    .HasForeignKey(d => d.CodigoInstructor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Inscrip_Evento_tb_empleado");
            });

            modelBuilder.Entity<TbInscripcionMembresia>(entity =>
            {
                entity.HasKey(e => e.CodigoMembresia)
                    .HasName("PK__tb_inscr__12E93D3970BFC105");

                entity.ToTable("tb_inscripcionMembresia");

                entity.Property(e => e.CodigoMembresia)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoMembresia");

                entity.Property(e => e.CodCliente).HasColumnName("codCliente");

                entity.Property(e => e.CodEmpleadoGestor).HasColumnName("codEmpleadoGestor");

                entity.Property(e => e.CodPlan).HasColumnName("codPlan");

                entity.Property(e => e.CodProm).HasColumnName("codProm");

                entity.Property(e => e.CodServicio).HasColumnName("codServicio");

                entity.Property(e => e.DniMiembro)
                    .HasMaxLength(100)
                    .HasColumnName("dniMiembro");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaInic)
                    .HasColumnType("date")
                    .HasColumnName("fechaInic");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fechaRegistro");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.TbInscripcionMembresia)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inscMemb_tb_cliente");

                entity.HasOne(d => d.CodEmpleadoGestorNavigation)
                    .WithMany(p => p.TbInscripcionMembresia)
                    .HasForeignKey(d => d.CodEmpleadoGestor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inscMemb_tb_empleado");

                entity.HasOne(d => d.CodPlanNavigation)
                    .WithMany(p => p.TbInscripcionMembresia)
                    .HasForeignKey(d => d.CodPlan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inscMemb_tb_planes");

                entity.HasOne(d => d.CodPlan1)
                    .WithMany(p => p.TbInscripcionMembresia)
                    .HasForeignKey(d => d.CodPlan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inscMemb_tb_promocion");

                entity.HasOne(d => d.CodServicioNavigation)
                    .WithMany(p => p.TbInscripcionMembresia)
                    .HasForeignKey(d => d.CodServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inscMemb_tb_servicios");
            });

            modelBuilder.Entity<TbPersona>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("PK__tb_perso__D87608A6A7FAFD23");

                entity.ToTable("tb_persona");

                entity.Property(e => e.Dni)
                    .ValueGeneratedNever()
                    .HasColumnName("dni");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(50)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .HasColumnName("direccion");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("sexo");

                entity.Property(e => e.Telefono).HasColumnName("telefono");
            });

            modelBuilder.Entity<TbPlanes>(entity =>
            {
                entity.HasKey(e => e.CodigoPlan)
                    .HasName("PK__tb_plane__D2CC91D4D8F2565E");

                entity.ToTable("tb_planes");

                entity.Property(e => e.CodigoPlan)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoPlan");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2000)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnName("precio");
            });

            modelBuilder.Entity<TbProductos>(entity =>
            {
                entity.HasKey(e => e.CodigoProd)
                    .HasName("PK__tb_produ__DC3C8ED770CDE260");

                entity.ToTable("tb_productos");

                entity.Property(e => e.CodigoProd)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoProd");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2000)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<TbPromocion>(entity =>
            {
                entity.HasKey(e => e.CodigoProm)
                    .HasName("PK__tb_promo__DC3C8EDCEE88E571");

                entity.ToTable("tb_promocion");

                entity.Property(e => e.CodigoProm)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoProm");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2000)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Descuento).HasColumnName("descuento");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaIni)
                    .HasColumnType("date")
                    .HasColumnName("fecha_ini");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TbProveedor>(entity =>
            {
                entity.HasKey(e => e.CodigoProv)
                    .HasName("PK__tb_prove__DC3C8EC5995A8179");

                entity.ToTable("tb_proveedor");

                entity.Property(e => e.CodigoProv)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoProv");

                entity.Property(e => e.Correo).HasColumnName("correo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono).HasColumnName("telefono");
            });

            modelBuilder.Entity<TbSede>(entity =>
            {
                entity.HasKey(e => e.CodigoSede)
                    .HasName("PK__tb_sede__C512C0C926B63E8F");

                entity.ToTable("tb_sede");

                entity.Property(e => e.CodigoSede)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoSede");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .HasColumnName("direccion");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(100)
                    .HasColumnName("distrito");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(100)
                    .HasColumnName("provincia");
            });

            modelBuilder.Entity<TbServicios>(entity =>
            {
                entity.HasKey(e => e.CodigoServicio)
                    .HasName("PK__tb_servi__BC11CF88ED00FCF4");

                entity.ToTable("tb_servicios");

                entity.Property(e => e.CodigoServicio)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoServicio");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2000)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TbVenta>(entity =>
            {
                entity.HasKey(e => e.CodigoVenta)
                    .HasName("PK__tb_venta__F6C85C9CF0D75553");

                entity.ToTable("tb_venta");

                entity.Property(e => e.CodigoVenta)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoVenta");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CodProducto).HasColumnName("codProducto");

                entity.Property(e => e.DniCliente).HasColumnName("dniCliente");

                entity.Property(e => e.FechaVenta)
                    .HasColumnType("date")
                    .HasColumnName("fechaVenta");

                entity.Property(e => e.PrecioVenta).HasColumnName("precioVenta");

                entity.HasOne(d => d.CodProductoNavigation)
                    .WithMany(p => p.TbVenta)
                    .HasForeignKey(d => d.CodProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venta_tb_productos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
