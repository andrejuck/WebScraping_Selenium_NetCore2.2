using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebScrapingRobot.Model;

namespace WebScrapingRobot
{
    internal class PaginaFBO
    {
        private SeleniumConfigurations _seleniumConfigurations;
        private IWebDriver _driver;

        public PaginaFBO(SeleniumConfigurations seleniumConfigurations)
        {
            _seleniumConfigurations = seleniumConfigurations;

            ChromeOptions optionsFF = new ChromeOptions();
            //optionsFF.AddArgument("--headless");

            _driver = new ChromeDriver(
                _seleniumConfigurations.CaminhoDriverChrome,
                optionsFF);
        }

        public void CarregarPagina()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_seleniumConfigurations.Timeout);

            _driver.Navigate().GoToUrl(_seleniumConfigurations.Url);
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }

        public int GetLastPage()
        {
            var divLstPg = _driver
                .FindElement(By.ClassName("lst-head"))
                .FindElement(By.ClassName("lst-pg"));

            var tagA = divLstPg
                .FindElements(By.TagName("a"));

            var valor = Convert.ToInt32(divLstPg
                .FindElements(By.TagName("a"))[tagA.Count - 1].Text
                .Replace("[", "")
                .Replace("]", ""));

            return valor;
        }

        public Post GetPost(int j)
        {
            var columns = _driver
                    .FindElement(By.ClassName("solr-lst"))
                    .FindElement(By.ClassName("list"))
                    .FindElement(By.Id($"row_{j}"))
                    .FindElements(By.TagName("td"));

            var post = new Post();
            var opportunity = new Opportunity();
            var agencyOfficeLocation = new AgencyOfficeLocation();

            foreach (var item in columns)
            {
                switch (item.GetAttribute("headers"))
                {
                    case "lh_id":
                        GetOpportunity(ref opportunity, item);
                        break;
                    case "lh_agency_name":
                        GetAgencyOfficeLocation(ref agencyOfficeLocation, item);
                        break;
                    case "lh_base_type":
                        post.Type = item.Text;
                        break;
                    case "lh_current_posted_date":
                        post.PostedDate = Convert.ToDateTime(item.Text);
                        break;
                }
            }

            post.Opportunity = opportunity;
            post.AgencyOfficeLocation = agencyOfficeLocation;

            return post;
        }

        private static void GetAgencyOfficeLocation(ref AgencyOfficeLocation agencyOfficeLocation, IWebElement item)
        {
            var text = item.Text.Split("\r\n");
            agencyOfficeLocation.Agency = text[0];
            if (text.Length == 2)
                agencyOfficeLocation.Office = text[1];
            if (text.Length == 3)
                agencyOfficeLocation.Location = text[2];
        }

        private void GetOpportunity(ref Opportunity opportunity, IWebElement item)
        {
            opportunity.Name = item.FindElement(By.ClassName("solt")).Text;
            opportunity.SolicitationNumber = item.FindElement(By.ClassName("soln")).Text;
            opportunity.Category = item.FindElement(By.ClassName("solcc")).Text;
        }

        public void MudarPagina(int i)
        {
            _driver
                .Navigate()
                .GoToUrl($"https://www.fbo.gov/index.php?s=opportunity&mode=list&tab=list&pageID={i}");
        }

        public void PreencheFiltroPesquisa()
        {
            var postedDate =
                new SelectElement(_driver
                        .FindElement(By.Id("homesearch"))
                        .FindElement(By.Id("qs-posted"))
                );

            postedDate.SelectByValue("30");

            _driver.FindElement(By.Id("qs-submit")).Click();

            var showing = new SelectElement(_driver.FindElement(By.Name("setPerPage")));
            showing.SelectByValue("100");
        }
    }
}