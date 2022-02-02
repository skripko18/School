using LAMS.DataAccess.Common.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Repositories.Teacher
{
    public interface ITeacherRepository : IDisposable
    {
        Task<int> AddTeacherDirection(TeacherDirectionDb direction);
        Task<IEnumerable<TeacherDirectionDb>> GetTeacherDirections(string id);

        Task<int> AddCourse(CourseDb course);
        Task<IEnumerable<CourseDb>> GetCourses(int id);
        Task<IEnumerable<CourseDb>> GetActiveCourses();
        Task<CourseDb> GetCourseInfo(int id);
        Task<CourseDb> DelCourse(int id);
        Task<int> FinishCreateCourse(int id);
        Task<int> StartCourse(int id);
        Task<int> EndCourse(int id);
        Task<int> EditCourse(CourseDb course);

        Task<int> AddProgram(CourseProgramDb program);
        Task<IEnumerable<CourseProgramDb>> GetPrograms(int id);
        Task<CourseProgramDb> DelProgram(int id);

        Task<int> AddHomework(HomeworkDb homework);
        Task<IEnumerable<HomeworkDb>> GetHomeworks(int id);
        Task<HomeworkDb> DelHomework(int id);

        Task<int> AddMaterial(MaterialDb homework);
        Task<IEnumerable<MaterialDb>> GetMaterials(int id);
        Task<MaterialDb> DelMaterial(int id);

        Task<int> OrderCourse(LearnerCourseDb course);

        Task<bool> IsOrderCourse(int IdCourse, string IdUser);

        Task<IEnumerable<LearnerCourseDb>> GetLearnerCourses(string id);
    }
}
