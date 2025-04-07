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
        public async Task<string> TestConnectionAsync()
        {
            try
            {
                var student = await _appDbContext.students.FirstOrDefaultAsync();
                return student != null
                ? $"Connected! First student: {student.First_name}"
                : "Connected, but no students found.";

            }
            catch (Exception ex)
            {
                return $"Database error: {ex.Message}";
            }
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            student.Password_hash = BCrypt.Net.BCrypt.HashPassword(student.Password_hash);
            _appDbContext.students.Add(student);
            await _appDbContext.SaveChangesAsync();
            return student;
        }
    }
}
