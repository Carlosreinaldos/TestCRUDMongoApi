using CRUD_MongoDB.DbModels;
using CRUD_MongoDB.IRepository;
using CRUD_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_MongoDB.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ObjectContext _context = null;

        public StudentRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.InsertOneAsync(student);
        }

        public async Task<IEnumerable<Student>> GetAsync()
        {
            return await _context.Students.Find(x => true).ToListAsync();
        }

        public async Task<Student> GetAsync(string id)
        {
            var student = Builders<Student>.Filter.Eq("id", id);
            return await _context.Students.Find(student).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.Students.DeleteOneAsync(Builders<Student>.Filter.Eq("id", id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Students.DeleteManyAsync(new BsonDocument());
        }

        public async Task<string> Update(string id, Student student)
        {
            await _context.Students.ReplaceOneAsync(zz => zz.Id == id, student);
            return "";
        }
    }
}
