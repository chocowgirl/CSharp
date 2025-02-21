using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Tests
{
    public class ToDoListManagerTest
    {
        [Fact]
        public void ToDoListManagerConstructor_ShouldInitiateTasksProp()
        {
            //Arrange
            ToDoListManager manager;

            //Act
            manager = new ToDoListManager();

            //Assert
            Assert.NotNull(manager);
            Assert.Empty(manager.Tasks);

        }

        [Theory]
        [InlineData("test1")]
        [InlineData("test2")]
        [InlineData("test3")]
        [InlineData("test4")]
        [InlineData("test5")]
        public void AddTask_WithStringTaskName_ShouldAddToDoTaskIntoTasksProp(string arg1)
        {
            //Arrange
            ToDoListManager manager = new ToDoListManager();
            bool result;

            //Act
            result = manager.AddTask(arg1); //b/c AddTask has a boolean return, we catch it here and make sure it works.

            //Assert
            Assert.True(result);
            Assert.NotNull(manager.Tasks);
            Assert.Single(manager.Tasks);
            Assert.IsType<ToDoTask>(manager.Tasks[0]);
            Assert.Equal(arg1, manager.Tasks[0].Title);
            Assert.Equal(ToDoStatus.Waiting, manager.Tasks[0].Status);
        }


        [Theory]
        [InlineData("test1")]
        [InlineData("test2")]
        [InlineData("test3")]
        [InlineData("test4")]
        [InlineData("test5")]
        public void AddTask_WithStringTaskName_ShouldNotAddToDoTaskIntoTasksProp(string arg1)
        {
            //Arrange
            ToDoListManager manager = new ToDoListManager();
            bool result = manager.AddTask(arg1);
            int count = manager.Tasks.Length;
            //Act
            result = manager.AddTask(arg1); //b/c AddTask has a boolean return, we catch it here and make sure it works.

            //Assert
            Assert.False(result);
            Assert.NotNull(manager.Tasks);
            Assert.Equal(count, manager.Tasks.Length);

        }
    }
}
