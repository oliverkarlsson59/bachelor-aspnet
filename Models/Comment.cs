namespace bachelorproject {
    public class Comment{
        public int id {get; set;}
        public int threadId {get; set;}
        public int userId {get; set;}
        public string body {get; set;}
        public string datemade {get; set;}
        public string datelastupdated {get; set;}
        public Comment(int id, int threadId, int userId, string body, string datemade, string datelastupdated) {
           this.id = id;
           this.threadId = threadId;
           this.userId = userId;
           this.body = body;
           this.datemade = datemade;
           this.datelastupdated = datelastupdated;
         }
    }
}