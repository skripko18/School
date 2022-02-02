using AutoMapper;
using LAMS.DataAccess.Common.Models.Teacher;
using LAMS.DataAccess.Common.Repositories.Teacher;
using LAMS.Logic.Common.Models.Teacher;
using LAMS.Logic.Common.Services.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Services.Teacher
{
    public class TeacherService : ITeacherService
    {
        private IMapper _mapper;
        private ITeacherRepository _repo;

        public TeacherService(ITeacherRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> AddTeacherDirection(TeacherDirectionBLL direction)
        {
            try
            {
                var id = await _repo.AddTeacherDirection(_mapper.Map<TeacherDirectionDb>(direction)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TeacherDirectionBLL>> GetTeacherDirections(string id)
        {
            return await _repo.GetTeacherDirections(id)
                .ContinueWith(t => _mapper.Map<IEnumerable<TeacherDirectionBLL>>(t.Result));
        }

        public async Task<int> AddCourse(CourseBLL course)
        {
            try
            {
                var id = await _repo.AddCourse(_mapper.Map<CourseDb>(course)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CourseBLL>> GetCourses(int id)
        {
            return await _repo.GetCourses(id)
                .ContinueWith(t => _mapper.Map<IEnumerable<CourseBLL>>(t.Result));
        }
        public async Task<IEnumerable<CourseBLL>> GetActiveCourses()
        {
            return await _repo.GetActiveCourses()
                .ContinueWith(t => _mapper.Map<IEnumerable<CourseBLL>>(t.Result));
        }
        public async Task<CourseBLL> GetCourseInfo(int id)
        {
            return await _repo.GetCourseInfo(id)
                .ContinueWith(t => _mapper.Map<CourseBLL>(t.Result));
        }

        public async Task<int> FinishCreateCourse(int id)
        {
            return await _repo.FinishCreateCourse(_mapper.Map<int>(id)).ContinueWith(t => t.Result);
        }

        public async Task<int> StartCourse(int id)
        {
            return await _repo.StartCourse(_mapper.Map<int>(id)).ContinueWith(t => t.Result);
        }

        public async Task<int> EndCourse(int id)
        {
            return await _repo.EndCourse(_mapper.Map<int>(id)).ContinueWith(t => t.Result);
        }

        public async Task<int> EditCourse(CourseBLL course)
        {
            return await _repo.EditCourse(_mapper.Map<CourseDb>(course)).ContinueWith(t => t.Result);
        }
        public async Task<CourseBLL> DelCourse(int id)
        {
            return await _repo.DelCourse(id)
                .ContinueWith(t => _mapper.Map<CourseBLL>(t.Result));
        }
        public async Task<int> AddProgram(CourseProgramBLL program)
        {
            try
            {
                var id = await _repo.AddProgram(_mapper.Map<CourseProgramDb>(program)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CourseProgramBLL>> GetPrograms(int id)
        {
            return await _repo.GetPrograms(id)
                .ContinueWith(t => _mapper.Map<IEnumerable<CourseProgramBLL>>(t.Result));
        }
        public async Task<CourseProgramBLL> DelProgram(int id)
        {
            return await _repo.DelProgram(id)
                .ContinueWith(t => _mapper.Map<CourseProgramBLL>(t.Result));
        }
        public async Task<int> AddHomework(HomeworkBLL homework)
        {
            try
            {
                var id = await _repo.AddHomework(_mapper.Map<HomeworkDb>(homework)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<HomeworkBLL>> GetHomeworks(int id)
        {
            return await _repo.GetHomeworks(id)
                .ContinueWith(t => _mapper.Map<IEnumerable<HomeworkBLL>>(t.Result));
        }
        public async Task<HomeworkBLL> DelHomework(int id)
        {
            return await _repo.DelHomework(id)
                .ContinueWith(t => _mapper.Map<HomeworkBLL>(t.Result));
        }

        public async Task<int> AddMaterial(MaterialBLL material)
        {
            try
            {
                var id = await _repo.AddMaterial(_mapper.Map<MaterialDb>(material)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MaterialBLL>> GetMaterials(int id)
        {
            return await _repo.GetMaterials(id)
                .ContinueWith(t => _mapper.Map<IEnumerable<MaterialBLL>>(t.Result));
        }
        public async Task<MaterialBLL> DelMaterial(int id)
        {
            return await _repo.DelMaterial(id)
                .ContinueWith(t => _mapper.Map<MaterialBLL>(t.Result));
        }
        public async Task<int> OrderCourse(LearnerCourseBLL course)
        {
            
                if (!await _repo.IsOrderCourse(course.IdCourse, course.IdUser))
                {
                    return 0;
                }
                var id = await _repo.OrderCourse(_mapper.Map<LearnerCourseDb>(course)).ContinueWith(t => t.Result);

                return id;
          
        }
        public async Task<IEnumerable<LearnerCourseBLL>> GetLearnerCourses(string id)
        {
            return await _repo.GetLearnerCourses(id)
                .ContinueWith(t => _mapper.Map<IEnumerable<LearnerCourseBLL>>(t.Result));
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
