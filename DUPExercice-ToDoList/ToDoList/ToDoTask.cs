namespace ToDoList
{
    public class ToDoTask
    {
        public string Title { get; private set; }
        public ToDoStatus Status { get; set; }

        public ToDoTask(string title)
        {
            Title = title;
            Status = ToDoStatus.Waiting;
        }

        public void Execute()
        {
            if (Status != ToDoStatus.Waiting && Status != ToDoStatus.Refused) throw new InvalidOperationException("Can't be executed.");
            else
            {
                Status = ToDoStatus.Executing;
            }
        }

        public void Finish()
        {
            if(Status != ToDoStatus.Executing) throw new InvalidOperationException("Can't be finished.");
            else
            {
                Status = ToDoStatus.Finished;
            }
        }

        public void Validate()
        {
            if (Status != ToDoStatus.Finished) throw new InvalidOperationException("Can't be validated.");
            else
            {
                Status = ToDoStatus.Validated;
            }
        }

        public void Refuse()
        {
            if (Status != ToDoStatus.Finished) throw new InvalidOperationException("Can't be refused.");
            else
            {
                Status = ToDoStatus.Refused;
            }
        }
    }
}