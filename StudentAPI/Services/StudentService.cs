using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StudentAPI.Models;

namespace StudentAPI.Services
{
    public class StudentService : IStudentService
    {
        private int _nextId = 3;

        private List<Student> _students = new List<Student>()
        {
            new Student
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Birthdate = new DateTime(2010, 1, 1),
                    Email = "john.doe@test.com",
                    Phone = "555.555.5555"
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Birthdate = new DateTime(2012, 1, 1),
                    Email = "jane.smith@test.com",
                    Phone = "555.555.5555"
                }
        };


        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student Get(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public Student Add(Student newStudent)
        {
            
            ValidateStudentBirthDate(newStudent);
            newStudent.Id = _nextId++;
            _students.Add(newStudent);

            return newStudent;
        }

        private void ValidateStudentBirthDate(Student newStudent)
        {
            
            if (newStudent.Birthdate.Year >= DateTime.Now.Year)
            {
                throw new ApplicationException("Birthdate cannot be in the future.");
            }
            if (DateTime.Now.Year - newStudent.Birthdate.Year > 18)
            {
                throw new ApplicationException("You're too old to be a student.");
            }
        }

        public Student Update(Student updatedStudent)
        {
          var currentStudent = _students.FirstOrDefault(s => s.Id == updatedStudent.Id);

            if(currentStudent == null)
            {
                return null;
            }

            currentStudent.FirstName = updatedStudent.FirstName;
            currentStudent.LastName = updatedStudent.LastName;
            currentStudent.Birthdate = updatedStudent.Birthdate;
            currentStudent.Email = updatedStudent.Email;
            currentStudent.Phone = updatedStudent.Phone;

            return currentStudent;
        }

        public void Remove(Student student)
        {
            var delStudent = _students.FirstOrDefault(s => s.Id == student.Id);

            if(delStudent != null)
            {
                _students.Remove(student);
            }
            else
            {
                throw new ApplicationException("Student does not exist");
            }
        }

    }
}
