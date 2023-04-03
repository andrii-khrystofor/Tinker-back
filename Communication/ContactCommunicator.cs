using Tinker_Back.Models;

namespace Tinker_Back.Communication
{
    public class ContactCommunicator
    {
        private TinkerDbContext DbContext { get; set; }
        public ContactCommunicator(TinkerDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void AddContact(int firstUserId,  int secondUserId)
        {
            Contact contact = new Contact(firstUserId, secondUserId);
            DbContext.Add(contact);
            DbContext.SaveChanges();
        }

        public void RemoveContact(int contactId)
        {
            Contact? contact = DbContext.Contacts.Find(contactId);
            if (contact != null)
            {
                DbContext.Remove(contact);
                DbContext.SaveChanges();
            }
        }

    }
}
