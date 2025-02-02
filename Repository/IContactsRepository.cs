using ContactTrackingSystem.Models;
using ContactTrackingSystem.ViewModels;

namespace ContactTrackingSystem.Repository
{
    public interface IContactsRepository
    {
        /// <summary>
        /// Returns the Contact object based on the given contact id
        /// </summary>
        /// <param name="id">Contact id to search</param>
        /// <returns>Returns matching Contact object</returns>
        Task<ContactViewModel> GetContactByID(Guid? contactId);


        /// <summary>
        /// Returns all contacts from the list
        /// </summary>
        /// <returns>All contacts from the list as List of contact objects</returns>
        /// 
        IQueryable<ContactViewModel> GetAllContacts();

        /// <summary>
        /// Returns all contact objects that matches with the given search field and search string
        /// </summary>
        /// <param name="searchBy">Search field to search</param>
        /// <param name="searchString">Search string to search</param>
        /// <returns>Returns all matching contacts based on the given search field and search string</returns>
        IQueryable<ContactViewModel> GetFilteredContacts(string searchBy, string? searchString);


        /// <summary>
        /// Adds a Contact object to the list of Contacts
        /// </summary>
        /// <param name="contact">Contact object to add</param>
        /// <returns>Returns the contact object after adding it (including newly generated contactid)</returns>
        /// 
        Task AddContact(ContactViewModel contact);


        /// <summary>
        /// Updates the specified Contact details based on the given Contact ID
        /// </summary>
        /// <param name="contact">contact details to update, including contact id</param>
        /// <returns> updates the database</returns>
        Task UpdateContact(ContactViewModel contact);
    }
}
