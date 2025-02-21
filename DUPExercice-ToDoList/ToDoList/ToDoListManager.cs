namespace ToDoList
{
    public class ToDoListManager
    {
        private List<ToDoTask> _todos;

        public ToDoTask[] Tasks
        {
            get
            {
                return _todos.ToArray();
            }
        }
        public ToDoTask? this[string taskTitle]
        {
            get
            {
                return Tasks.SingleOrDefault(t => t.Title == taskTitle);
            }
        }

        public ToDoListManager()
        {
            _todos = new List<ToDoTask>();
        }

        public bool AddTask(string taskTitle)
        {
            taskTitle = taskTitle.Trim();
            if (string.IsNullOrWhiteSpace(taskTitle)) throw new ArgumentException("Le format du titre de la tâche est incorrect.");
            if (Tasks.Select(t => t.Title).Contains(taskTitle)) return false;
            _todos.Add(new ToDoTask(taskTitle));
            return true;
        }

        public ToDoTask[] FilterTask(ToDoStatus status)
        {
            return _todos.Where(t => t.Status == status).ToArray();
        }

    }
}
