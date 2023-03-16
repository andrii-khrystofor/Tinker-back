using Tinker_Back.Models;

namespace Tinker_Back
{
    public class MessageCommunicator
    {
        public MessageCommunicator(TinkerDbContext dbContext) 
        {
            DbContext = dbContext;
        }
        private void ProcessMessageIfExists(int messageId, Action<Message> func)
        {
            Message? message = DbContext.Messages.Find(messageId);
            if (message != null)
            {
                func(message);
            }
            DbContext.SaveChanges();
        }

        private void ProcessPinMessage(int messageId, bool needPin) 
        {
            ProcessMessageIfExists(messageId, (Message message)
                => message.IsPinned = needPin);
        }
        public void SendMessage(string text, DateTime timeSent, int senderId, int chatId)
        {
            Message message = new Message(text, timeSent, senderId, chatId);
            DbContext.Messages.Add(message);
            DbContext.SaveChanges();
        }

        public void DeleteMessage(int messageId)
        {
            ProcessMessageIfExists(messageId, (Message message) 
                => DbContext.Messages.Remove(message));
        }

        public void EditMessage(int messageId, String newText)
        {
            ProcessMessageIfExists(messageId, (Message message)
                => message.Text = newText);
        }

        public void PinMessage(int messageId)
        {
            ProcessPinMessage(messageId, true);
        }

        public void UnPinMessage(int messageId)
        {
            ProcessPinMessage(messageId, false);
        }

        public void ForwardMessage(int messageId, DateTime timeSent, int chatId, int senderId)
        {
            ProcessMessageIfExists(messageId,
              (Message message) =>
              {
                  Message NewMessage = new Message(message.Text, timeSent, chatId, senderId);
                  DbContext.Messages.Add(NewMessage);
              }
            );
        }

        public void ReplyToMessage(string text, DateTime timeSent, int senderId, int repliedToMessageId)
        {
            ProcessMessageIfExists(repliedToMessageId,
                (Message message) =>
                {
                    Message NewMessage = new Message(text, timeSent, senderId, message.ChatId);
                    NewMessage.RepliesToMessageId = repliedToMessageId;
                    DbContext.Messages.Add(NewMessage);
                });
        }

        public IEnumerable<Message>? SearchMessages(string text, int chatId)
        {
            Chat? chat = DbContext.Chats.Find(chatId);
            if (chat == null)
            {
                return null;
            }

            return chat.Messages.Where(x => x.Text.Contains(text)).ToList();
        }
        private TinkerDbContext DbContext;
    }
}
