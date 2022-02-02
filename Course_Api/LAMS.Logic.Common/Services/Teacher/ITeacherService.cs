using LAMS.Logic.Common.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Services.Teacher
{
    public interface ITeacherService : IDisposable
    {
        Task<int> AddTeacherDirection(TeacherDirectionBLL direction);
        Task<IEnumerable<TeacherDirectionBLL>> GetTeacherDirections(string id);

        Task<int> AddCourse(CourseBLL course);
        Task<IEnumerable<CourseBLL>> GetCourses(int id);
        Task<IEnumerable<CourseBLL>> GetActiveCourses();
        Task<CourseBLL> GetCourseInfo(int id);
        Task<CourseBLL> DelCourse(int id);
        Task<int> FinishCreateCourse(int id);
        Task<int> StartCourse(int id);
        Task<int> EndCourse(int id);

        Task<int> EditCourse(CourseBLL course);

        Task<int> AddProgram(CourseProgramBLL program);
        Task<IEnumerable<CourseProgramBLL>> GetPrograms(int id);
        Task<CourseProgramBLL> DelProgram(int id);

        Task<int> AddHomework(HomeworkBLL homework);
        Task<IEnumerable<HomeworkBLL>> GetHomeworks(int id);
        Task<HomeworkBLL> DelHomework(int id);

        Task<int> AddMaterial(MaterialBLL material);
        Task<IEnumerable<MaterialBLL>> GetMaterials(int id);
        Task<MaterialBLL> DelMaterial(int id);

        Task<int> OrderCourse(LearnerCourseBLL course);

        Task<IEnumerable<LearnerCourseBLL>> GetLearnerCourses(string id);
    }
}
