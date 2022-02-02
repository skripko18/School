using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Models.Teacher;
using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Repositories.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DBContext _context;

        public AdminRepository(DBContext context) => _context = context;

        public async Task<bool> IsDirectionAvailable(string direction)
        {
            return !(await _context.Directions.AnyAsync(u => u.Direction == direction).ConfigureAwait(false));
        }

        public async Task<int> AddDirection(DirectionDb direction)
        {
            _context.Directions.Add(direction);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return direction.Id;
        }

        public async Task<IEnumerable<DirectionDb>> GetDirections()
        {
            return await _context.Directions.ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<CourseDb>> GetCourses()
        {
            return await _context.Courses.OrderByDescending(o => o.Id).ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> ApproveCourse(int id)
        {
            var info = await _context.Courses.FirstOrDefaultAsync(p => p.Id == id && p.Status == "Ожидает размещения").ConfigureAwait(false);
            info.Status = "Активен";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<int> RejectCourse(int id)
        {
            var info = await _context.Courses.FirstOrDefaultAsync(p => p.Id == id && p.Status == "Ожидает размещения").ConfigureAwait(false);
            info.Status = "Не прошел проверку";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<string> Block(string id)
        {
            var info = await _context.Users.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);
            info.Status = "Заблокирован";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true; 
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return info.Id;
               
        }
        public async Task<string> Unblock(string id)
        {
            var info = await _context.Users.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);
            info.Status = "Активен";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return info.Id;
        }
        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~DocumentRepository() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        void IDisposable.Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
