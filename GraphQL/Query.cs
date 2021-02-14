using GraphQL.Types;
using GraphQL;
using System.Collections.Generic;


namespace bachelorproject {
    public class Query : ObjectGraphType {
        private DbHandler dbHandler;
        public Query() {
            dbHandler = new DbHandler();


            //Fetches first comment made by a user
            FieldAsync<CommentType>(
                "commentByUserId",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> {Name = "id"}
                ),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    return await dbHandler.getCommentByJoinUserId(id);
                }
            );

            //fetches x comments made by user
            FieldAsync<ListGraphType<CommentType>>(
                "commentsByUserId",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> {Name = "id"},
                    new QueryArgument<IdGraphType> {Name = "limit"}
                ),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    var limit = context.GetArgument<int>("limit");
                    return await dbHandler.getCommentsByJoinUserId(id, limit);
                    //return null;
                }
            );

            //fetches x comments
            FieldAsync<ListGraphType<CommentType>>(
                "comments",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> {Name = "limit"}
                ),
                resolve: async context =>
                {
                    var limit = context.GetArgument<int>("limit");
                    return await dbHandler.getComments(limit);
                }
            );

            //fetches comment by id
            FieldAsync<CommentType>(
                "commentById",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> {Name = "id"}
                ),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    return await dbHandler.getCommentByJoinUserId(id);
                }
            );

        }
    }
}