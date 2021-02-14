using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Data;
namespace bachelorproject {
    public class DbHandler {
        private string Server {get; set;}
        private string User {get; set;}
        private string Database {get; set;}
        private int Port {get; set;}
        private string Password {get; set;}
        private string connectionStr {get; set;}
        public DbHandler(){
            this.Server = "localhost";
            this.User = "root";
            this.Database = "bachelorproject_db";
            this.Port = 3306;
            this.Password = "password";

            this.connectionStr = "server=" + this.Server + ";user=" + this.User + ";database="+this.Database+";port="+this.Port+";password="+this.Password+";pooling=true;maxpoolsize=100";
        }
        
        //fetches a single comment through id
        public async Task<Comment> getCommentById(int id){
            try{
                string sql = "SELECT comment_id, thread_id, user_id, body, datemade, datelastupdated FROM comment WHERE comment_id="+id;
                var result = await MySqlHelper.ExecuteDatasetAsync(this.connectionStr, sql);
                var reader = result.CreateDataReader();
                reader.Read();
                Comment comment = new Comment(int.Parse(reader[0].ToString()),
                        int.Parse(reader[1].ToString()), 
                        int.Parse(reader[2].ToString()),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString()
                );
                reader.Close();
                return comment;
            }
            catch {
                return null;
            }
        }

        //fetches a list of the first x comments
        public async Task<List<Comment>> getComments(int limit){
            try{
                string sql = "SELECT comment_id, thread_id, user_id, body, datemade, datelastupdated FROM comment LIMIT " + limit;
                var result = await MySqlHelper.ExecuteDatasetAsync(this.connectionStr, sql);
                var reader = result.CreateDataReader();
                List<Comment> comments = new List<Comment>();
                while(reader.Read()){
                    comments.Add(new Comment(int.Parse(reader[0].ToString()),
                        int.Parse(reader[1].ToString()), 
                        int.Parse(reader[2].ToString()),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString()
                    ));
                }
                reader.Close();
                return comments;
            }
            catch {
                return null;
            }
        }

        //fetches first comment made by a user
        public async Task<Comment> getCommentByJoinUserId(int userId){
            try{
                string sql = "SELECT comment.comment_id, comment.thread_id, user.user_id, comment.body, comment.datemade, comment.datelastupdated FROM comment INNER JOIN user on comment.user_id=user.user_id WHERE user.user_id="+userId + " LIMIT 1";
                var result = await MySqlHelper.ExecuteDatasetAsync(this.connectionStr, sql);
                var reader = result.CreateDataReader();
                reader.Read();
                Comment comment = new Comment(int.Parse(reader[0].ToString()),
                        int.Parse(reader[1].ToString()), 
                        int.Parse(reader[2].ToString()),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString()
                );
                Console.WriteLine(comment);
                reader.Close();
                return comment;
    
            }
            catch {
                return null;
            }
        }
        //fetches a limited amount of comments made by a user
        public async Task<List<Comment>> getCommentsByJoinUserId(int userId, int limit){
            try{
                string sql = "SELECT comment.comment_id, comment.thread_id, user.user_id, comment.body, comment.datemade, comment.datelastupdated FROM comment INNER JOIN user on comment.user_id=user.user_id WHERE user.user_id="+userId + " LIMIT " + limit;
                var result = await MySqlHelper.ExecuteDatasetAsync(this.connectionStr, sql);
                var reader = result.CreateDataReader();
                List<Comment> comments =  new List<Comment>();
                while(reader.Read()){
                    comments.Add(new Comment(int.Parse(reader[0].ToString()),
                        int.Parse(reader[1].ToString()), 
                        int.Parse(reader[2].ToString()),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString()
                    ));
                }
                reader.Close();
                return comments;
            }
            catch {
                return null;
            }
        } 
    }
}