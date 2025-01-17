﻿using Microsoft.AspNetCore.Mvc;
using MiniProject5Company.Domain.Entities;
using MiniProject5Company.Domain.Interfaces;

namespace MiniProject5Company.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartment()
        {
            var department = await _departmentRepository.GetAllDepartment();
            return Ok(department);
        }

        [HttpGet("{deptNo}")]
        public async Task<ActionResult<Department>> GetEmployeeById(int deptNo)
        {
            var department = await _departmentRepository.GetDepartmentById(deptNo);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            var createdDepartment = await _departmentRepository.AddDepartment(department);
            return Ok(createdDepartment);
        }

        [HttpPut("{deptNo}")]
        public async Task<IActionResult> UpdateEmployee(int deptNo, Department department)
        {
            if (deptNo != department.Deptno) return BadRequest();

            var updatedDepartment = await _departmentRepository.UpdateDepartment(department);
            return Ok(updatedDepartment);
        }

        [HttpDelete("{deptNo}")]
        public async Task<ActionResult<bool>> DeleteBook(int deptNo)
        {
            var deleted = await _departmentRepository.DeleteDepartment(deptNo);
            if (!deleted) return NotFound();
            return Ok("department has been deleted !");
        }
        [HttpGet("manager/{deptNo}")]
        public async Task<IActionResult> GetManagerByDeptNo(int deptNo)
        {
            var manager = await _departmentRepository.GetManagerByDeptNoAsync(deptNo);
            if (manager == null)
            {
                return NotFound($"No manager found for department number {deptNo}");
            }
            return Ok(manager);
        }
    }
}
