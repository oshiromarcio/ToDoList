
// Arrange
using ToDoList;

Reminders list = new Reminders();
ToDo newTask = new ToDo() {
    Task = "Study for the math exams",
    Date = DateTime.Parse("2024-11-01"),
    Priority = false,
    Completed = false
};
ToDo newTask2 = new ToDo() {
    Task = "Clean the house",
    Date = DateTime.Parse("2024-09-20"),
    Priority = false,
    Completed = false
};
ToDo newTask3 = new ToDo() {
    Task = "Melissa's Birthday",
    Date = DateTime.Parse("2024-09-21"),
    Priority = true,
    Completed = false
};
ToDo newTask4 = new ToDo() {
    Task = "Caroline's Birthday",
    Date = DateTime.Parse("2025-04-04"),
    Priority = true,
    Completed = false
};

// Act
list.Add(newTask);
list.Add(newTask2);
list.Add(newTask3);
list.Add(newTask4);
foreach (var task in list.List())
{
    Console.WriteLine($"Task: {task.Task} in {task.Date.ToShortDateString()}, Priority: {task.Priority}, Completed: {task.Completed}");
}