﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestmonitorTests.Models
{
    public class ProjectBuilder
    {
        private Project project;
        public ProjectBuilder()
        {
            project = new Project();
        }

        public ProjectBuilder SetUsername(string name)
        {
            project.Name = name;
            return this;
        }
        public ProjectBuilder SetPassword(string description)
        {
            project.Description = description;
            return this;
        }

        public Project Build()
        {
            return project;
        }
    }
}
