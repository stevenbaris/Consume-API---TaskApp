using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Text;
using TaskApp.Data;
using TaskApp.Models;
using TaskApp.ViewModel;

namespace TaskApp.Repository.MsSQL
{
    public class TaskRestRepository : ITaskRepository
    {
        // interact with database and perform CRUD 

        string baseURL = "https://jsonplaceholder.typicode.com";
        HttpClient httpClient = new HttpClient();
        public TaskRestRepository() 
        {
        }

        public Taskm AddTask(Taskm newTaskm)
        {
            TaskViewModel todoVM = new TaskViewModel();
            todoVM.userid = newTaskm.userId;
            todoVM.title = newTaskm.title;
            todoVM.completed = newTaskm.completed;

            string data = JsonConvert.SerializeObject(todoVM);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(baseURL + "/todos", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                Taskm todo = JsonConvert.DeserializeObject<Taskm>(responsecontent);
                return todo;
            }
            return null;
        }

        public Taskm DeleteTask(int taskmId)
        {
            var response = httpClient.DeleteAsync(baseURL + "/todos/" + taskmId).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;// json standard
                Taskm todo = JsonConvert.DeserializeObject<Taskm>(data);
                return todo;
            }
            return null;
        }

        public List<Taskm> GetAllTasks()
        {
            // fetch todos from rest service -> http request message
            var response = httpClient.GetAsync(baseURL + "/todos").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                List<Taskm> todos = JsonConvert.DeserializeObject<List<Taskm>>(data);
                return todos;
            }
            return null;
        }

        public Taskm GetTaskById(int Taskm) 
        {
            var response = httpClient.GetAsync(baseURL + "/todos/" + Taskm).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;// json standard
                Taskm todo = JsonConvert.DeserializeObject<Taskm>(data);
                return todo;
            }
            return null;
        }

        public Taskm UpdateTask(int taskmId, Taskm newTaskm)
        {
            string data = JsonConvert.SerializeObject(newTaskm);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(baseURL + "/todos/" + taskmId, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                Taskm todo = JsonConvert.DeserializeObject<Taskm>(responsecontent);
                return todo;
            }
            return null;
        }
    }
}
