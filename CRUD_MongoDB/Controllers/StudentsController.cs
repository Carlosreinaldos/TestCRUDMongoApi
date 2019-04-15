using CRUD_MongoDB.IRepository;
using CRUD_MongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_MongoDB.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController
    {
        
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public Task<string> Get()
        {
            return this.GetStudent();
        }

        private async Task<string> GetStudent()
        {
            var students = await _studentRepository.GetAsync();
            return JsonConvert.SerializeObject(students);
        }

        [HttpGet]
        public Task<string> Get(string id)
        {
            return this.GetStudentById(id);
        }

        private async Task<string> GetStudentById(string id)
        {
            var student = await _studentRepository.GetAsync(id) ?? new Student();
            return JsonConvert.SerializeObject(student);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] Student student)
        {
            await _studentRepository.AddAsync(student);
            return "";
        }

        [HttpPut("{id}")]
        public async Task<string> Put( string id, [FromBody] Student student)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid id!!!";
            return await _studentRepository.Update(id,student);
        }

        [HttpDelete]
        public async Task<string> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid id!!!";
            await _studentRepository.Remove(id);
            return "";
        }
    }
}
