using Tinker_Back.Models;
using System.Linq;
namespace Tinker_Back
{
    public class ChatCommunicator
    {
        private TinkerDbContext _context;
        public ChatCommunicator(TinkerDbContext dbContext)
        {
            _context = dbContext;
        }
        private void ProcessChatIfExist(int chatID, Action<Chat> func)
        {
            Chat? chat = _context.Chats.Find(chatID);
            if(chat == null)
            {
                func(chat);
            }
            _context.SaveChanges();
        }
        private void ProcessPinChat(int chatID, bool pinned)
        {
            ProcessChatIfExist(chatID, (Chat chat) => chat.IsPinned = pinned);
        }
        public void CreateChat(string name, string description)
        {
            Chat chat = new Chat(name, description);
            _context.Chats.Add(chat);
            _context.SaveChanges();
        }
        public void DeleteChat(int chatID)
        {
            ProcessChatIfExist(chatID, (Chat chat) => _context.Chats.Remove(chat));
        }
        public void ChangeDescription(int chatID, string newDescription)
        {
            ProcessChatIfExist(chatID, (Chat chat) => chat.Description = newDescription);
        }
        public void ChangeName(int chatID, string newName)
        {
            ProcessChatIfExist(chatID, (Chat chat) => chat.Name = newName);
        }
        public void PinChat(int chatID)
        {
            ProcessPinChat(chatID, true);
        }
        public void UnPinChat(int chatID)
        {
            ProcessPinChat(chatID, false);
        }
        public IEnumerable<Chat>? SearcChat(string name)
        {
            Chat? chat = _context.Chats.Find(name);
            if(chat == null)
            {
                return null;
            }
            return chat.Name.Where(x=>x.Name.Contains(name)).ToList();
        }
        public void AddUserToChat(int chatID, int userID)
        {
            ProcessChatIfExist(chatID, (Chat chat) => chat.UserToChats.Add(userID));
        }
        public void RemoveUserFromChat(int chatID, int userID)
        {
            ProcessChatIfExist(chatID, (Chat chat) => chat.UserToChats.Remove(userID));
        }
        public void CleanChat(int chatID)
        {
            Chat? chat = _context.Chats.Find(chatID);
            if(chat == null )
            {
                return;
            }
            chat.Messages.Clear();
        }

    }
}