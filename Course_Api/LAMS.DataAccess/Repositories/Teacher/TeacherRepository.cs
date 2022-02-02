
using LAMS.DataAccess.Common.Models.Teacher;
using LAMS.DataAccess.Common.Repositories.Teacher;
using LAMS.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Repositories.Teacher
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DBContext _context;


        private bool _disposed;

        public TeacherRepository(DBContext context) => _context = context;

        public async Task<int> AddTeacherDirection(TeacherDirectionDb direction)
        {
            _context.TeacherDirections.Add(direction);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return direction.Id;
        }

        public async Task<IEnumerable<TeacherDirectionDb>> GetTeacherDirections(string id)
        {
            return await _context.TeacherDirections.Where(o => o.IdUser == id).ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> AddCourse(CourseDb course)
        {
            _context.Courses.Add(course);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return course.Id;
        }

        public async Task<IEnumerable<CourseDb>> GetCourses(int id)
        {
            return await _context.Courses.Where(o => o.IdTeacherDirection == id).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<CourseDb>> GetActiveCourses()
        {
            return await _context.Courses.Where(o => o.Status == "Активен").ToListAsync().ConfigureAwait(false);
        }
        public async Task<CourseDb> GetCourseInfo(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);
        }
        public async Task<CourseDb> DelCourse(int id)
        {
            CourseDb course = await _context.Courses.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            var result = _context.Courses.Remove(course);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> FinishCreateCourse(int id)
        {
            var info = await _context.Courses.FirstOrDefaultAsync(p => p.Id == id && p.Status == "Новый").ConfigureAwait(false);
            info.Status = "Ожидает размещения";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> StartCourse(int id)
        {
            var info = await _context.Courses.FirstOrDefaultAsync(p => p.Id == id && p.Status == "Активен").ConfigureAwait(false);
            info.Status = "Стартовал";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> EndCourse(int id)
        {
            var info = await _context.Courses.FirstOrDefaultAsync(p => p.Id == id && p.Status == "Стартовал").ConfigureAwait(false);
            info.Status = "Завершен";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<int> EditCourse(CourseDb course)
        {
            var courseInDb = await _context.Courses.FirstOrDefaultAsync(p => p.Id == course.Id).ConfigureAwait(false);

            var entry = _context.Entry(courseInDb);
            entry.CurrentValues.SetValues(course);
            entry.Property(p => p.Name).IsModified = true;
            entry.Property(p => p.Description).IsModified = true;
            entry.Property(p => p.IdDirection).IsModified = true;
            entry.Property(p => p.DateStart).IsModified = true;
            entry.Property(p => p.Skills).IsModified = true;


            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<int> AddProgram(CourseProgramDb program)
        {
            _context.CoursePrograms.Add(program);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return program.Id;
        }

        public async Task<IEnumerable<CourseProgramDb>> GetPrograms(int id)
        {
            return await _context.CoursePrograms.Where(o => o.IdCourse == id).ToListAsync().ConfigureAwait(false);
        }
        public async Task<CourseProgramDb> DelProgram(int id)
        {
            CourseProgramDb program = await _context.CoursePrograms.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            var result = _context.CoursePrograms.Remove(program);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> AddHomework(HomeworkDb homework)
        {
            _context.Homeworks.Add(homework);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return homework.Id;
        }

        public async Task<IEnumerable<HomeworkDb>> GetHomeworks(int id)
        {
            return await _context.Homeworks.Where(o => o.IdCourse == id).ToListAsync().ConfigureAwait(false);
        }
        public async Task<HomeworkDb> DelHomework(int id)
        {
            HomeworkDb homework = await _context.Homeworks.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            var result = _context.Homeworks.Remove(homework);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> AddMaterial(MaterialDb material)
        {
            _context.Materials.Add(material);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return material.Id;
        }

        public async Task<IEnumerable<MaterialDb>> GetMaterials(int id)
        {
            return await _context.Materials.Where(o => o.IdCourse == id).ToListAsync().ConfigureAwait(false);
        }
        public async Task<MaterialDb> DelMaterial(int id)
        {
            MaterialDb material = await _context.Materials.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            var result = _context.Materials.Remove(material);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }
        public async Task<int> OrderCourse(LearnerCourseDb course)
        {
            _context.LearnerCourses.Add(course);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return course.Id;
        }
        public async Task<bool> IsOrderCourse(int IdCourse, string IdUser)
        {
            return !(await _context.LearnerCourses.AnyAsync(u => u.IdCourse == IdCourse && u.IdUser == IdUser).ConfigureAwait(false));
        }
        public async Task<IEnumerable<LearnerCourseDb>> GetLearnerCourses(string id)
        {
            return await _context.LearnerCourses.Where(o => o.IdUser == id).ToListAsync().ConfigureAwait(false);
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        ~TeacherRepository()
        {
            Dispose();
        }
    }
}

