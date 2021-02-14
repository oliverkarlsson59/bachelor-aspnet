using GraphQL.Types;

namespace bachelorproject{
    public class UserType : ObjectGraphType<User> {
        public UserType(){
            Name = "user";

            Field(x => x.id, type: typeof(IdGraphType)).Description("ID of user");
            Field(x => x.name, type: typeof(IdGraphType)).Description("name of user");
            Field(x => x.email, type: typeof(IdGraphType)).Description("email of user");
            Field(x => x.phone, type: typeof(IdGraphType)).Description("phone of user");
            Field(x => x.datemade, type: typeof(IdGraphType)).Description("user profile date created");
            Field(x => x.datelastupdated, type: typeof(IdGraphType)).Description("user profile last updated date");
            
        }
    }
}