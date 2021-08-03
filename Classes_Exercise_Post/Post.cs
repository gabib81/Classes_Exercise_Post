using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_Exercise_Post
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int NumOfVotes { get; set; }

        public Post(int id, string title, string description, DateTime creationDate, int numOfVotes)
        {
            Id = id;
            Title = title;
            Description = description;
            CreationDate = creationDate;
            NumOfVotes = numOfVotes;
        }


    }
}
