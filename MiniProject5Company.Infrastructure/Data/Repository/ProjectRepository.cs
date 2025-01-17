﻿using Microsoft.EntityFrameworkCore;
using MiniProject5Company.Domain.Entities;
using MiniProject5Company.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5Company.Infrastructure.Data.Repository
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly CompanyFinancialContext _context;

        public ProjectRepository(CompanyFinancialContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllProject()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task<Project> GetProjectById(int projNo)
        {
            return await _context.Projects.FindAsync(projNo);
        }
        public async Task<Project> AddProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }
        public async Task<Project> UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }
        public async Task<bool> DeleteProject(int projNo)
        {
            var deleted = await _context.Projects.FindAsync(projNo);
            if (deleted == null)
            {
                return false;
            }
            _context.Projects.Remove(deleted);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
