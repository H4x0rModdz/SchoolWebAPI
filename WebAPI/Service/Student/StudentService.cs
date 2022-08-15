﻿using WebAPI.Models;
using WebAPI.Repository.Student;

namespace WebAPI.Service.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student Add(Student student)
        {
            if (student.Password is null)
                throw new ArgumentException("The Password field is required");

            if (_studentRepository.VerifyIfEmailAlreadyExists(student))
                throw new ArgumentException("Email already exists");

            if (_studentRepository.VerifyIfCpfAlreadyExists(student))
                throw new ArgumentException("CPF already exists");

            student.Id = Guid.NewGuid();
            //student.BirthDate = student.BirthDate;
            //student.AddedIn = DateTime.Now;

            _studentRepository.Add(student);

            return student;
        }

        public void Delete(Guid id)
        {
            _studentRepository.Delete(id);
        }

        public Student Edit(Student student)
        {
            if (_studentRepository.VerifyIfEmailAlreadyExists(student))
                throw new ArgumentException("Email already exists");

            if (_studentRepository.VerifyIfCpfAlreadyExists(student))
                throw new ArgumentException("CPF already exists");

            _studentRepository.Edit(student);

            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(Guid id)
        {
            if (_studentRepository.VerifyIfStudentAlreadyExists(id))
                throw new ArgumentException("Id does not exists");

            return _studentRepository.GetById(id);
        }
    }
}