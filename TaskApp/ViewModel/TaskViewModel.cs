using Microsoft.AspNetCore.Mvc;

namespace TaskApp.ViewModel
{
    public class TaskViewModel : Controller
    {
        public int userid { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

        public TaskViewModel() { }

        public TaskViewModel(int userid, string title, bool completed)
        {
            this.userid = userid;
            this.title = title;
            this.completed = completed;
        }
    }
}
