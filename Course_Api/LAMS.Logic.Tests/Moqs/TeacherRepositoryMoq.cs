using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAMS.DataAccess.Common.Models.Teacher;
using LAMS.DataAccess.Common.Repositories.Teacher;

namespace LAMS.Logic.Tests.Moqs
{
   public class TeacherRepositoryMoq:ITeacherRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddTeacherDirection(TeacherDirectionDb direction)
        {
            return 1;
        }

        public async Task<IEnumerable<TeacherDirectionDb>> GetTeacherDirections(string id)
        {
            return new List<TeacherDirectionDb>()
            {
                new TeacherDirectionDb()
                {
                    Id = 1
                }
            };
        }

        public async Task<int> AddCourse(CourseDb course)
        {
            return 1111;
        }

        public Task<IEnumerable<CourseDb>> GetCourses(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseDb>> GetActiveCourses()
        {
            throw new NotImplementedException();
        }

        public Task<CourseDb> GetCourseInfo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CourseDb> DelCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> FinishCreateCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> StartCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> EndCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditCourse(CourseDb course)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddProgram(CourseProgramDb program)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseProgramDb>> GetPrograms(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CourseProgramDb> DelProgram(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddHomework(HomeworkDb homework)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HomeworkDb>> GetHomeworks(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HomeworkDb> DelHomework(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddMaterial(MaterialDb homework)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MaterialDb>> GetMaterials(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MaterialDb> DelMaterial(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> OrderCourse(LearnerCourseDb course)
        {
            return 1;
        }

        public async Task<bool> IsOrderCourse(int IdCourse, string IdUser)
        {
            return true;
        }

        public Task<IEnumerable<LearnerCourseDb>> GetLearnerCourses(string id)
        {
            throw new NotImplementedException();
        }
    }
}
