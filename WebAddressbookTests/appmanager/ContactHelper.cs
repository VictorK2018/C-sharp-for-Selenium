﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {

        }
        public ContactHelper CreateContact(ContactData contact)
        {
            FillContactForm(contact);
            SubmitContactForm();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper ModifyContact(int p, ContactData modifContact)
        {
            manager.Navigator.GoToHomePage();
            ModifContact(p);
            FillContactForm(modifContact);
            SubmitModifiedContact();
            ReturnToHomePage();

            return this;
        }
        public ContactHelper RemoveContact(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            DeleteContact();
            //ReturnToHomePage();                        
            driver.FindElement(By.CssSelector("div.msgbox"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            //WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //driver.FindElement(By.Name("firstname")).Click();
            //driver.FindElement(By.Name("firstname")).Clear();
            Type(By.Name("firstname"), contact.Firstname);
            //driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);

            //driver.FindElement(By.Name("lastname")).Click();
            //driver.FindElement(By.Name("lastname")).Clear();
            Type(By.Name("lastname"), contact.Lastname);
            //driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);

            //driver.FindElement(By.Name("middlename")).Click();
            //driver.FindElement(By.Name("middlename")).Clear();
            Type(By.Name("middlename"), contact.Middlename);
            //driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);

            return this;
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        // select contact for delete, send e-mail etc.
        public ContactHelper SelectContact( int index)
        {            
            // add '2' to be 1-st row names in XPath     
            //driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ (index + 2) + "]/td/input")).Click();
            return this;
        }

        // select contact for editing
        public ContactHelper ModifContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td[8]/a/img")).Click();
            return this; 
        }

        // Zadanie#8     
        //    // select 1-st contact to Edit/Modify
        //    driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();



        public ContactHelper SubmitModifiedContact()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        //// Zadanie#7 - delete contact from main page
        //public ContactHelper SelectDeleteContact()
        //{
        //    // select 1-st contact to Delete
        //    driver.FindElement(By.Name("selected[]")).Click();
        //    return this;
        //}
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
                
        public bool IsContactPresent()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();

            //Задание 8
            //ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("td:nth-of-type(2)"));

            // get all names into collection:
            //ICollection<IWebElement> elements = driver.FindElements(By.CssSelector
            //    (("tr[name=entry] > td:nth-of-type(3), tr[name=entry] > td:nth-of-type(2)")));          

            //get rows:
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=entry]"));

            //get names, text
            foreach (IWebElement element in elements)
            {
                IList<IWebElement> names = element.FindElements(By.CssSelector("td"));
                contacts.Add(new ContactData(names[2].Text, names[1].Text));
            }
            
            //Console.WriteLine("row's number--->>" + elements.Count);

            return contacts;
        }

    }
}
