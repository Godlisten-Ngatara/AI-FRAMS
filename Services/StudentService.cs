using AI_FRAMS.Data;
using AI_FRAMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
namespace AI_FRAMS.Services
{
    public class StudentService
    {
        // Injecting DbContext using a constructor
        private readonly AppDbContext _appDbContext;

        public StudentService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Student> FetchStudentAsync()
        {
            try
            {
                var student = await _appDbContext.students.FirstOrDefaultAsync();
                return student;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching student: {ex.Message}");
                return null; // Return null in case of failure
            }
        }

        public async Task<string> AddStudentAsync(Student student)
        {
            student.Password = BCrypt.Net.BCrypt.HashPassword(student.Password);
            _appDbContext.students.Add(student);
            await _appDbContext.SaveChangesAsync();
            return "operation succesful";
        }
    }
}
