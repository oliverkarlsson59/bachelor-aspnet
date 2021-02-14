namespace bachelorproject {
    public class User{
        public int id {get; set;}
        public string name {get; set;}
        public string email {get; set;}
        public string phone {get; set;}
        public string datemade {get; set;}
        public string datelastupdated {get; set;}
        public User(int id, string name, string email, string phone, string datemade, string datelastupdated) {
           this.id = id;
           this.name = name;
           this.email = email;
           this.phone = phone;
           this.datemade = datemade;
           this.datelastupdated = datelastupdated;
         }
    }
}