using AutoMapper;
using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.Logic.Common.Models.Admin;
using LAMS.Logic.Common.Models.Teacher;
using LAMS.Logic.Common.Services.Admin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LAMS.Logic.Services.Admin
{
    public class AdminService : IAdminService
    {
        private IMapper _mapper;
        private IAdminRepository _repo;

        public AdminService(IAdminRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> AddDirection(DirectionBLL direction)
        {
            try
            {
                if (!await _repo.IsDirectionAvailable(direction.Direction))
                {
                    return 0;
                }
                var id = await _repo.AddDirection(_mapper.Map<DirectionDb>(direction)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<DirectionBLL>> GetDirections()
        {
            return await _repo.GetDirections()
                .ContinueWith(t => _mapper.Map<IEnumerable<DirectionBLL>>(t.Result));
        }
        public async Task<IEnumerable<CourseBLL>> GetCourses()
        {
            return await _repo.GetCourses()
                .ContinueWith(t => _mapper.Map<IEnumerable<CourseBLL>>(t.Result));
        }

        public async Task<int> ApproveCourse(int id)
        {
            return await _repo.ApproveCourse(_mapper.Map<int>(id)).ContinueWith(t => t.Result);
        }
        public async Task<int> RejectCourse(int id)
        {
            return await _repo.RejectCourse(_mapper.Map<int>(id)).ContinueWith(t => t.Result);
        }
        public async Task<string> Block(string id)
        {
            return await _repo.Block(_mapper.Map<string>(id)).ContinueWith(t => t.Result);

        }
        public async Task<string> Unblock(string id)
        {
            return await _repo.Unblock(_mapper.Map<string>(id)).ContinueWith(t => t.Result);
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
        // ~DocumentService() {
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
