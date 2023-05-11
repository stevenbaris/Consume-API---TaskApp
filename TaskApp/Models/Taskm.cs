namespace TaskApp.Models
{
    public class Taskm
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

        public Taskm() { }

        public Taskm(int userId, int id, string title, bool completed)
        {
            this.userId = userId;
            this.id = id;
            this.title = title;
            this.completed = completed;
        }
    }
}
