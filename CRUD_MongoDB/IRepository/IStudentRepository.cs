using CRUD_MongoDB.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_MongoDB.IRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAsync();
        Task<Student> GetAsync(string id);
        Task AddAsync(Student student);
        Task<string> Update(string id, Student student);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();


    }
}
