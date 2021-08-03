using System;
using System.Threading;

namespace Classes_Exercise_Post
{
    /*
     Design a class called Post. This class models a StackOverflow post. It should have properties
    for title, description and the date/time it was created. We should be able to up-vote or down-vote
    a post. We should also be able to see the current vote value. In the main method, create a post,
    up-vote and down-vote it a few times and then display the the current vote value. 
     */
    class Program
    {
        static void Main(string[] args)
        {
            var userPosts = new ManagePosts();
            bool done = false;

            Console.WriteLine("This program allows you to mange your posts.");
            while (!done)
            {

                Console.WriteLine("- [C]reate a post.\n" +
                                  "- [E]dit a post.\n" +
                                  "- [d]elete a post.\n" +
                                  "- [U]pvote or downvote a post.\n" +
                                  "- [L]ist all posts.\n" +
                                  "- [Ex]it the program.\n ");
                Console.WriteLine("Select an option from the menu");

                var userSelection = Console.ReadLine().ToLower();
                int postId;
                string postTitle;
                string postDescription;

                switch (userSelection)
                {
                    case "c":
                        Console.Clear();
                        Console.WriteLine("Please enter a post title: ");
                        while (true)
                        {
                            postTitle = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(postTitle))
                            {
                                Console.WriteLine("Invalid name, Please enter a valid post title: ");
                                continue;
                            }

                            break;
                        }

                        Console.WriteLine("Please enter a post description");
                        postDescription = Console.ReadLine();
                        userPosts.CreatePost(postTitle, postDescription);
                        Console.WriteLine("Post created!!!");
                        break;

                    case "e":
                        Console.Clear();
                        Console.WriteLine("Please enter post ID: ");
                        try
                        {
                            postId = Convert.ToInt32(Console.ReadLine());
                            if (!userPosts.CheckIfPostExist(postId))
                                Console.WriteLine("Invalid ID");
                            else
                            {
                                Console.WriteLine("Please enter a new post title: ");
                                while (true)
                                {
                                    postTitle = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(postTitle))
                                    {
                                        Console.WriteLine("Invalid name, Please enter a valid post title: ");
                                        continue;
                                    }

                                    break;
                                }

                                Console.WriteLine("Please enter a new post description");
                                postDescription = Console.ReadLine();
                                userPosts.EditPost(postId, postTitle, postDescription);

                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid!!");
                        }


                        break;
                    case "u":
                        Console.Clear();
                        Console.WriteLine("Please enter post ID: ");
                        try
                        {
                            postId = Convert.ToInt32(Console.ReadLine());
                            if (!userPosts.CheckIfPostExist(postId))
                                Console.WriteLine("Invalid ID");
                            else
                            {
                                Console.WriteLine("Please type \"Up\" for up-vote or \"Down\" for down-vote ");
                                while (true)
                                {
                                    var voteSelection = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(voteSelection))
                                    {
                                        Console.WriteLine("Invalid operation");
                                        continue;
                                    }

                                    if (voteSelection.ToLower() != "up" && voteSelection.ToLower() != "down")
                                    {
                                        Console.WriteLine("Please type \"Up\" for upvote or \"Down\" for downvote ");
                                        continue;
                                    }

                                    if (voteSelection == "up")
                                    {
                                        userPosts.UpVote(postId, voteSelection);
                                    }
                                    else if (voteSelection == "down")
                                    {
                                        userPosts.UpVote(postId, voteSelection);
                                    }

                                    break;

                                }

                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid!!!");

                        }
                        break;

                    case "d":
                        Console.Clear();
                        Console.WriteLine("Please enter post ID: ");
                        try
                        {
                            postId = Convert.ToInt32(Console.ReadLine());
                            if (!userPosts.CheckIfPostExist(postId))
                                Console.WriteLine("Invalid ID");
                            else
                            {
                                userPosts.RemovePost(postId);
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Invalid!!");
                        }
                        break;

                    case "l":
                        Console.Clear();
                        userPosts.GetAllPosts();
                        Thread.Sleep(4000);
                        break;

                    case "ex":
                        done = true;
                        Console.WriteLine("Have a great day!!");
                        break;
                }
            }
        }
    }
}
