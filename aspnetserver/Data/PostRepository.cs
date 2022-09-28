using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal static class PostRepository
    {

        //get all the posts

        internal async static Task<List<Post>> GetPostsAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.Posts.ToListAsync();
            }
        }

        //get just one post
        internal async static Task<Post> GetPostByIdAsync(int postId)
        {
            using (var db = new AppDbContext())
            {
                return await db.Posts.FirstOrDefaultAsync(post => post.PostId == postId); //this can return null. just set to silent in editor
            }
        }

        //create post
        internal async static Task<bool> CreatePostAync(Post post)
        {
            using(var db = new AppDbContext())
            {
                try
                {
                    await db.Posts.AddAsync(post);
                    return await db.SaveChangesAsync() >= 1;//this will presist the changes to the database.
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        //update post
        internal async static Task<bool> UpdatePostAync(Post post)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.Posts.Update(post);
                    return await db.SaveChangesAsync() >= 1;//this will presist the changes to the database.
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        //delete post
        internal async static Task<bool> DeletePostAync(int postId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    Post post = await GetPostByIdAsync(postId);
                    db.Remove(post);
                    return await db.SaveChangesAsync() >= 1;//this will presist the changes to the database.
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
