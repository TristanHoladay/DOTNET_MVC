using System;
using Xunit;
using StudentAPI.Controllers;
using StudentAPI.Models;
using StudentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace StudentAPI_UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void Post_ShouldReturnBadRequestIfBirthdateIsInFuture()
        {
            //controller
            

            Student student = new Student
            {

                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Birthdate = new DateTime(2020, 1, 1),
                Email = "john.doe@test.com",
                Phone = "555.555.5555"

            };

            var result = TryPost(student);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_ShouldReturnBadRequestIfBirthDateIsTooOld()
        {

            Student student = new Student
            {

                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Birthdate = new DateTime(2000, 1, 1),
                Email = "john.doe@test.com",
                Phone = "555.555.5555"

            };

            var result = TryPost(student);

            Assert.IsType<BadRequestObjectResult>(result);

        }


        [Fact]
        public void Post_ShouldReturnBadResultWhenEmailNotInRightFormat()
        {
            Student student = new Student
            {
                Id = 3,
                FirstName = "John",
                LastName = "Doe",
                Birthdate = new DateTime(2007, 1, 1),
                Email = "",
                Phone = "555.555.5555"

            };

            var result = TryPost(student);

            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public void Post_ShouldReturnCreatedAtAction()
        {
            Student student = new Student
            {
                Id = 3,
                FirstName = "John",
                LastName = "Doe",
                Birthdate = new DateTime(2007, 1, 1),
                Email = "john.doe@test.com",
                Phone = "555.555.5555"

            };

            var result = TryPost(student);

            Assert.IsType<CreatedAtActionResult>(result);
        }

        public IActionResult TryPost(Student student)
        {
            StudentsController controller = new StudentsController(new StudentService());

            return controller.Post(student);

        }
    }
}
