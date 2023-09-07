using Domain.Interfaces.Generics;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infra.Repositorio.Generics
{
    public class RepositoryGenerics<T> : InterfaceGeneric<T>, IDisposable where T : class 
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryGenerics() {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task Add(T objeto)
        {
             using (var data = new ContextBase(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T objeto)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                 data.Set<T>().Remove(objeto);
                await data.SaveChangesAsync();
            }
        }



        public async Task<T> GetEntityById(long id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                var entity = await data.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with ID {id} not found");
                }
                return entity;
            }
        }


        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
               return  await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T objeto)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                  data.Set<T>().Update(objeto);
                await data.SaveChangesAsync();
            }
        }
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }
    }
}
