using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using PracticalExam3.Pages;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using WebDriverManager.Helpers;
using PracticalExam3.BrowserFactory;

namespace PracticalExam3.Tests
{
    public abstract class BaseTest
    {
        protected Browser Browser => BrowserService.Browser;
        protected HomePage HomePage { get; private set; }
        protected CardPage CardPage { get; private set; }

        protected BaseTest() { }

        [SetUp]
        public void Setup()
        {
            HomePage = new HomePage();
            CardPage = new CardPage();
        }
/*
        [TearDown]
        public void TearDown()
        {
            Browser.Quit();
        }*/
    }
}
