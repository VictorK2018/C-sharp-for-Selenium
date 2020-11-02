﻿using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            // prepare to test
            app.Navigator.GoToHomePage();

            // uncomment for test:     
            // check if no one contact is present
            if (!app.Contacts.IsContactPresent())
            {
                // action - create contact 
                app.Contacts.InitContactCreation();
                ContactData contact = new ContactData("firstNameBytest", "lastNameBytest");
                contact.Middlename = "OtchestvoBytest";
                app.Contacts.CreateContact(contact);
            }

            //get old list before deleting
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            //Console.WriteLine(oldContacts);

            //delete created/existing contact
            app.Contacts.RemoveContact(0);

            //get new list after deleting
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            ////check if no contact left
            // Assert.IsFalse(app.Contacts.IsContactPresent());

        }

    }
}
