using ToDoList;

namespace Tests;

public class UnitTestToDoList
{
    [Fact]
    public void Task_AddNewTask_NewTaskAdded()
    {
        // Arrange
        Reminders list = new Reminders();
        ToDo newTask = new ToDo() {
            Task = "Study for the math exams",
            Date = DateTime.Parse("2024-11-01"),
            Priority = true,
            Completed = false
        };

        // Act
        int idTask = list.Add(newTask);
        ToDo? findToDo = list.Get(idTask);

        // Assert
        Assert.NotNull(findToDo);
        Assert.Equal(newTask, findToDo);
    }

    [Fact]
    public void Task_AddTwoNewTasksAndRemoveOne_ThereHasToBeOneTaskLeft()
    {
        // Arrange
        Reminders list = new Reminders();
        ToDo newTask = new ToDo() {
            Task = "Study for the math exams",
            Date = DateTime.Parse("2024-11-01"),
            Priority = true,
            Completed = false
        };
        ToDo newTask2 = new ToDo() {
            Task = "Clean the house",
            Date = DateTime.Parse("2024-09-20"),
            Priority = false,
            Completed = false
        };

        // Act
        int idTask = list.Add(newTask);
        list.Add(newTask2);
        int qtdBefore = list.List().Count;
        list.Remove(idTask);
        int qtdAfter = list.List().Count;

        // Assert
        Assert.Equal(2, qtdBefore);
        Assert.Equal(1, qtdAfter);
    }

    [Fact]
    public void Task_AddThreeNewTasksUncompletedAndCompleteOne_ThereHasToBeOneTaskCompleted()
    {
        // Arrange
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
            Priority = false,
            Completed = false
        };

        // Act
        list.Add(newTask);
        int idTask2 = list.Add(newTask2);
        list.Add(newTask3);
        int qtdCompletedBefore = list.CompletedList(true).Count;
        list.Complete(idTask2);
        int qtdCompletedAfter = list.CompletedList(true).Count;

        // Assert
        Assert.Equal(0, qtdCompletedBefore);
        Assert.Equal(1, qtdCompletedAfter);
    }

    [Fact]
    public void Task_AddFourNewTasksAndFindTasksByBirthdayDescription_ThereHaveToBeTwoTasksReturned()
    {
        // Arrange
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
        var birthdaysList = list.List("Birthday");

        // Assert
        Assert.NotNull(birthdaysList);
        Assert.NotEmpty(birthdaysList);
        Assert.Equal(2, birthdaysList.Count);
    }
}