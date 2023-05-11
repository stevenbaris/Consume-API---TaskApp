using TaskApp.Models;

namespace TaskApp.Repository
{
    public interface ITaskRepository // contract 
    {
        List<Taskm> GetAllTasks();

        // get any specific todo
        Taskm GetTaskById(int Taskm);

        // add todo into the list
        Taskm AddTask(Taskm newTaskm);

        // update todo in the list
        Taskm UpdateTask(int taskmId, Taskm newTaskm);

        // delete 
        Taskm DeleteTask(int taskmId);
    }
}
