using GraphQL.Types;

namespace bachelorproject{
    public class CommentType : ObjectGraphType<Comment> {
        public CommentType(){
            Name = "comment";

            Field(x => x.id, type: typeof(IdGraphType)).Description("ID of comment");
            Field(x => x.threadId, type: typeof(IdGraphType)).Description("id of thread");
            Field(x => x.userId, type: typeof(IdGraphType)).Description("id of user");
            Field(x => x.body, type: typeof(IdGraphType)).Description("body of comment");
            Field(x => x.datemade, type: typeof(IdGraphType)).Description("comment date created");
            Field(x => x.datelastupdated, type: typeof(IdGraphType)).Description("comment last updated date");
            
        }
    }
}