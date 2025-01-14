﻿using Sale.Domain.Entities;
using Sale.Domain.Repository;
using System.Collections.Generic;
using Sale.Infrastructure.Interfaces;
using System.Linq.Expressions;
using System;
using Sale.Infrastructure.Context;
using System.Linq;
using Sale.Infrastructure.Core;

namespace Sale.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SaleContext context;

        public UsuarioRepository(SaleContext context) : base(context)
        {
           
            this.context = context;

        }
    
        public override void Save(Usuario entity)
        {
            context.Usuarios.Add(entity);
            context.SaveChanges();
            Console.WriteLine("Los datos han sido guardados");
        }
        public override void Update(Usuario entity)
        {
            var usuarioToUpdate = base.GetEntity(entity.Id);

            usuarioToUpdate.Nombre = entity.Nombre;
            usuarioToUpdate.Correo = entity.Correo;
            usuarioToUpdate.Telefono = entity.Telefono;
            usuarioToUpdate.Correo = entity.Correo;
            usuarioToUpdate.FechaRegistro = entity.FechaRegistro;

            context.Usuarios.Update(usuarioToUpdate);
            context.SaveChanges();
            Console.WriteLine("Los datos han sido actualizados");
        }
        public override void Delete(Usuario entity)
        {
            var usuarioToDelete = base.GetEntity(entity.Id);

            usuarioToDelete.Id = entity.Id;
            usuarioToDelete.Eliminado = entity.Eliminado;

            this.context.Usuarios.Update(usuarioToDelete);
            this.context.SaveChanges();
            Console.WriteLine("Los datos han sido eliminados");

        }

        public override List<Usuario> GetEntities()
        {
            return this.context.Usuarios.Where(st => !st.Eliminado)
                                        .OrderByDescending(st => st.FechaRegistro)
                                            .ToList();
            Console.WriteLine("Obtener los datos del estudiante de la base de datos como una lista");
        }
    }

}
