using System.Threading.Tasks;

namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ToDoList Manager !");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            ToDoListManager tdlm = new ToDoListManager();
            ConsoleKey key;
            do
            {
                Console.Clear();
                ShowList(tdlm);
                key = ShowOptions(["ajouter", "modifier", "quitter"]);
                Console.Clear();
                switch (key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("Quelle tâche souhaitez-vous ajouter ?");
                        string taskTitle = Console.ReadLine();
                        tdlm.AddTask(taskTitle);
                        break;
                    case ConsoleKey.M:
                        Console.WriteLine("Quelle tâche souhaitez-vous modifier le status ?");
                        ToDoTask? task = tdlm[Console.ReadLine()];
                        if (task is null)
                        {
                            Console.WriteLine("La tâche n'a pas été trouvée...");
                        }
                        else
                        {
                            Console.WriteLine("Le status de la tache est actuellement :");
                            ChangeColorForStatus(task.Status);
                            Console.WriteLine(task.Status);
                            Console.ResetColor();
                            Console.WriteLine("Le changer ?");
                            switch (task.Status)
                            {
                                case ToDoStatus.Waiting:
                                    task.Execute();
                                    break;
                                case ToDoStatus.Executing:
                                    task.Finish();
                                    break;
                                case ToDoStatus.Finished:
                                    ConsoleKey statusKey = ShowOptions(["valider", "refuser"]);
                                    if (statusKey == ConsoleKey.V) task.Validate();
                                    else task.Refuse();
                                    break;
                                case ToDoStatus.Validated:
                                    Console.WriteLine("Le status ne peut être changer.");
                                    break;
                                case ToDoStatus.Refused:
                                    task.Execute();
                                    break;
                            }
                        }
                        break;
                }
            } while (key != ConsoleKey.Q);
        }

        public static void ChangeColorForStatus(ToDoStatus status)
        {
            switch (status)
            {
                case ToDoStatus.Waiting:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case ToDoStatus.Executing:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case ToDoStatus.Finished:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case ToDoStatus.Validated:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case ToDoStatus.Refused:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        public static void ShowList(ToDoListManager tdlm)
        {
            Console.WriteLine("Voici la liste des tâches :");
            if (tdlm.Tasks.Length > 0)
            {
                foreach (ToDoTask task in tdlm.Tasks)
                {
                    ChangeColorForStatus(task.Status);
                    Console.WriteLine($"{task.Title} : {task.Status}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("Aucune tâche actuellement...");
            }
        }

        public static ConsoleKey ShowOptions(string[] options)
        {
            ConsoleKey key;
            List<string> keys;
            do
            {
                Console.WriteLine("Que souhaitez-vous faire ?");
                bool first = true;
                keys = new List<string>();
                foreach (string option in options)
                {
                    string letterKey = option.ToUpper()[0].ToString();
                    keys.Add(letterKey);
                    string formattedOption = $"({letterKey}){option.Substring(1).ToLower()}";
                    Console.Write((first) ? formattedOption : $" - {formattedOption}");
                    first = false;
                }
                Console.WriteLine();
                key = Console.ReadKey(true).Key; 
            } while (!keys.Contains(key.ToString()));

            return key;
        }
    }
}
