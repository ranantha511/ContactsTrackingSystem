using ContactTrackingSystem.Data;
using ContactTrackingSystem.Models;
using ContactTrackingSystem.ViewModels;
using ContactTrackingSystem.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ContactTrackingSystem.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly CTSDbContext _dbContext;
        private ILogger<ContactsRepository> _logger;

        //constructor
        public ContactsRepository(CTSDbContext ctsDbContext,ILogger<ContactsRepository> logger) 
        {
            _dbContext = ctsDbContext;
            _logger = logger;
        }

        public CTSDbContext CtsDbContext { get; }

        public async Task AddContact(ContactViewModel? contactAddRequest)
        {
            //Validation: Contact parameter can't be null
            if (contactAddRequest == null)
            {
                _logger.LogError("Contact request cannot be null");
                throw new ArgumentNullException(nameof(contactAddRequest));
            }

            //Validation: Contact first Name can't be null
            if (contactAddRequest.FirstName == null)
            {
                _logger.LogError("First name cannot be blank");
                throw new ArgumentException(nameof(contactAddRequest.FirstName));
            }

            //Validation: Contact last Name can't be null
            if (contactAddRequest.LastName == null)
            {
                _logger.LogError("Last name cannot be blank");
                throw new ArgumentException(nameof(contactAddRequest.LastName));
            }

            //generate ContactID
            contactAddRequest.ContactId = Guid.NewGuid();

            var newContact = new Contact() { 
                ContactId = contactAddRequest.ContactId,
                FirstName = contactAddRequest.FirstName, 
                LastName = contactAddRequest.LastName, 
                EmailAddress = contactAddRequest.EmailAddress,
                PhoneNumber = contactAddRequest.PhoneNumber,
                ZipCode = contactAddRequest.ZipCode
            };


            //Add Contact object into _countries
            await _dbContext.Contacts.AddAsync(newContact);
            await _dbContext.SaveChangesAsync();

        }

        public IQueryable<ContactViewModel> GetAllContacts()
        {
            // convert contact to contactviewmodel
            var Allcontacts = _dbContext.Contacts.OrderBy(x => x.FirstName)
                .Select(temp => new ContactViewModel
                {
                    ContactId = temp.ContactId,
                    FirstName = temp.FirstName,
                    LastName = temp.LastName,
                    EmailAddress = temp.EmailAddress,
                    PhoneNumber = temp.PhoneNumber,
                    ZipCode = temp.ZipCode
                });
            return Allcontacts;
        }

        public async Task<ContactViewModel> GetContactByID(Guid? contactId)
        {
          

            Contact? contact_response = await _dbContext.Contacts
              .FirstOrDefaultAsync(temp => temp.ContactId == contactId);

            

            if (contact_response != null) {
                return new ContactViewModel()
                {
                    ContactId = contact_response.ContactId,
                    FirstName = contact_response.FirstName,
                    LastName = contact_response.LastName,
                    EmailAddress = contact_response.EmailAddress,
                    PhoneNumber = contact_response.PhoneNumber,
                    ZipCode = contact_response.ZipCode
                };
            }
            return new ContactViewModel();
             

        }

        public IQueryable<ContactViewModel> GetFilteredContacts(string searchBy, string? searchString)
        {
            IQueryable<ContactViewModel>? contacts = GetAllContacts();

            if (contacts != null && contacts.Count() > 0)
            {
                if (!string.IsNullOrEmpty(searchString))
                {

                    switch (searchBy)
                    {
                        case nameof(Contact.FirstName):
                            contacts = contacts.Where(x => !string.IsNullOrEmpty(x.FirstName) && x.FirstName.Contains(searchString));                  
                            break;
                        case nameof(Contact.LastName):
                            contacts = contacts.Where(x => !string.IsNullOrEmpty(x.LastName) && x.LastName.Contains(searchString));
                            break;
                        case nameof(Contact.EmailAddress):
                            contacts = contacts.Where(x => !string.IsNullOrEmpty (x.EmailAddress) && x.EmailAddress.Contains(searchString));
                            break;
                        case nameof(Contact.PhoneNumber):
                            contacts = contacts.Where(x => !string.IsNullOrEmpty(x.PhoneNumber) && x.PhoneNumber.Contains(searchString));
                            break;
                        case nameof(Contact.ZipCode):
                            contacts = contacts.Where(x => !string.IsNullOrEmpty(x.ZipCode) && x.ZipCode.Contains(searchString));
                            break;
                        default:
                            return contacts;
                    }
                    return contacts;
                }
                else { return contacts; }
            }
            else { return null; }
        }

        public async Task UpdateContact(ContactViewModel? contactUpdateRequest)
        {
            if (contactUpdateRequest == null)
                throw new ArgumentNullException(nameof(contactUpdateRequest));


            //get matching contact object to update
            Contact? matchingContact = _dbContext.Contacts
              .FirstOrDefault(temp => temp.ContactId == contactUpdateRequest.ContactId);
            
            if (matchingContact == null)
            {
                throw new ArgumentException("ContactId doesn't exist");
            }

            //update all details
            matchingContact.FirstName = contactUpdateRequest.FirstName;
            matchingContact.LastName = contactUpdateRequest.LastName;
            matchingContact.PhoneNumber = contactUpdateRequest.PhoneNumber;
            matchingContact.EmailAddress = contactUpdateRequest.EmailAddress;
            matchingContact.ZipCode = contactUpdateRequest.ZipCode;

            await _dbContext.SaveChangesAsync(); //UPDATE
        }

        //Task<ContactViewModel> IContactsRepository.GetContactByID(Guid? contactId)
        //{
        //    if (contactId == null)
        //        return null;

        //    Contact? matchingContact = _dbContext.Contacts
        //      .FirstOrDefault(temp => temp.ContactId == contactId);

        //    return ContactViewModel(contactId);

        //}
    }
}
