namespace bachelorproject {
    public class Thread{
        public int id {get; set;}
        public int categoryId {get; set;}
        public int userId {get; set;}
        public string title {get; set;}
        public string body {get; set;}
        public string datemade {get; set;}
        public string datelastupdated {get; set;}
        public Thread(int id, int categoryId, int userId, string title, string body, string datemade, string datelastupdated) {
           this.id = id;
           this.categoryId = categoryId;
           this.userId = userId;
           this.title = title;
           this.body = body;
           this.datemade = datemade;
           this.datelastupdated = datelastupdated;
         }
    }
}