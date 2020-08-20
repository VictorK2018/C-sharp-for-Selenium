﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests: AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            // prepare to test
            app.Navigator.GoToHomePage();

            //get list before deleting
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            Console.WriteLine(oldContacts);

            //uncomment for test:

            //// check if no one contact is present
            //if (!app.Contacts.IsContactPresent())
            //{
            //    // action - create contact 
            //    app.Contacts.InitContactCreation();
            //    ContactData contact = new ContactData("firstNameBytest", "lastNameBytest");
            //    contact.Middlename = "OtchestvoBytest";
            //    app.Contacts.CreateContact(contact);

            //}                   

            ////delete created/existing contact
            //app.Contacts.RemoveContact();

            ////check if no contact left
            //Assert.IsFalse(app.Contacts.IsContactPresent());

        }

    }
}
