using BTL_WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_WEB.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageAPIController : ControllerBase
	{
		SocialMediaContext db = new SocialMediaContext();

		//Get all group on DB
		[HttpGet("group")]
		public IEnumerable<ChatGroup> GetAllChatGroup()
		{
			var listChatGr = db.ChatGroups.ToList();
			
			return listChatGr;
        }

        //Get all group of a user by userId
        [HttpGet("group/{id}")]
        public IEnumerable<ChatGroup> GetChatGroupByUserId(int id)
        {
            var listGroup = new List<ChatGroup>();
            var listChatMember = db.ChatMembers.Where(x=>x.UserId == id).ToList();

            foreach(var chatMember in listChatMember)
            {
                var chatGroup = db.ChatGroups.Find(chatMember.GroupId);
                listGroup.Add(chatGroup);
            }

            return listGroup.ToList();
        }

        //Get all user on DB
        [HttpGet("users")]
        public IEnumerable<User> GetAllUser()
        {
            return db.Users.ToList();
        }

        //Get user info by message senderId
        [HttpGet("users/{senderId}")]
        public User GetUserByMessageSenderId(int senderId)
        {
            var user = db.Users.Find(senderId);
            return user;
        }

        //Get all messages on DB
        [HttpGet("messages")]
		public IEnumerable<Message> GetAllMessages()
		{
			return db.Messages.ToList();
		}

        //Get mesages of Group
        [HttpGet("messages/{groupId}")]
        public IEnumerable<Message> GetMessagesrByGroupId(int groupId)
        {
            return db.Messages.Where(x=>x.GroupId == groupId).OrderBy(x=>x.SentDatetime).ToList();
        }

        [HttpPost("messages")]
        public String PostNewMessage(Message message)
        {
            var id = message.SenderId;
            try
            {
                db.Messages.Add(message);
                db.SaveChanges();
                var user = db.Users.Find(id);
                return user.AvatarImg;
                
            }
            catch(Exception ex)
            {
                return null;
            }
        }


    }
}
