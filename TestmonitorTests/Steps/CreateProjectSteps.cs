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
    public class CreateProjectSteps : BaseStep
    {
        public CreateProjectSteps(IWebDriver driver) : base(driver)
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

    }
}
