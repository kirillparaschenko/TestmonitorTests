﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Models;
using TestmonitorTests.Pages;

namespace TestmonitorTests.Steps
{
    public class ProjectSteps : BaseStep
    {
        public ProjectSteps(IWebDriver driver) : base(driver)
        {
        }

        public SettingsProjetsPage CreateProject(Project project)
        {
            ProjectsPage.OpenSettingsProjetsPage();
            SettingsProjetsPage.CreateProjectButton().Click();
            CreateProjectModal.FillCreateProjectForm(project);
            CreateProjectModal.FeaturetButton().Click();
            CreateProjectModal.FeaturetButton().Click();
            CreateProjectModal.FeaturetButton().Click();
            return SettingsProjetsPage;
        }

        public SettingsProjetsPage ArchieveProject()
        {
            ProjectsPage.OpenSettingsProjetsPage();
            SettingsProjetsPage.FindLastProject().Click();
            ProjectPage.ArchiveProject();
            return SettingsProjetsPage;
        }

        public CreateProjectModal OpenCreateProjectModal()
        {
            ProjectsPage.OpenSettingsProjetsPage();
            SettingsProjetsPage.CreateProjectButton().Click();
            return CreateProjectModal;
        }
    }
}