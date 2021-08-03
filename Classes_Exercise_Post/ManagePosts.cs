using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes_Exercise_Post
{
    public class ManagePosts
    {
        private readonly List<Post> _posts = new List<Post>();

        public void CreatePost(string title, string desc)
        {
            var postID = _posts.Count + 1;
            _posts.Add(new Post(postID, title, desc, DateTime.Now, 0));
            Console.Clear();
            GetAllPosts();
        }

        public void EditPost(int id, string newTitle, string newDesc)
        {
            var numOfVotes = _posts[id - 1].NumOfVotes;
            RemovePost(id);
            _posts.Add(new Post(id, newTitle, newDesc, DateTime.Now, numOfVotes));
            Console.Clear();
            Console.WriteLine("Post edited successfully!!");
            GetAllPosts();
        }

        public void UpVote(int postId, string vote)
        {
            //var currentNumOfVotes = _posts[postId - 1].NumOfVotes;

            if (!CheckIfPostExist(postId))
                Console.WriteLine("ID not found");
            else
            {
                switch (vote.ToLower())
                {
                    case "up":
                        _posts[postId - 1].NumOfVotes += 1;
                        Console.Clear();
                        Console.WriteLine("Post up-voted successfully");
                        GetAllPosts();
                        break;
                    case "down":
                        if (_posts[postId - 1].NumOfVotes > 0)
                        {
                            _posts[postId - 1].NumOfVotes -= 1;
                            Console.Clear();
                            Console.WriteLine("Post down-voted successfully");
                            GetAllPosts();
                        }
                        else
                        {
                            Console.WriteLine("Nothing to down-vote");
                        }
                        break;
                }
            }


        }

        public void RemovePost(int id)
        {
            if (CheckIfPostExist(id))
            {
                _posts.RemoveAt(id - 1);
                Console.Clear();
                Console.WriteLine("Post Removed successfully");
                GetAllPosts();
            }
            else
                Console.WriteLine("ID not found");

        }
        public bool CheckIfPostExist(int postId)
        {
            return _posts.Count >= postId && postId != 0;
        }

        public void GetAllPosts()
        {
            var sortedList = _posts.OrderBy(o => o.Id).ToList();
            //_posts.Sort();


            foreach (var post in sortedList)
            {
                Console.WriteLine("[{0}] Title: {1} --- Description: {2} --- CreationDate: {3} --- Votes: {4} ",
                    post.Id,
                    post.Title,
                    post.Description,
                    post.CreationDate,
                    post.NumOfVotes);
            }

        }
    }
}
