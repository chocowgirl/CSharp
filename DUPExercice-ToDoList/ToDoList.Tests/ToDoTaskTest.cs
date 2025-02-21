using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Tests
{
    public class ToDoTaskTest
    {
        [Theory]
        [InlineData(ToDoStatus.Executing)]
        [InlineData(ToDoStatus.Finished)]
        [InlineData(ToDoStatus.Validated)]
        public void Execute_WithStatusExecutingOrFinishedOrValidated_ShouldThrowInvalidOperationException(ToDoStatus arg1)
        {
            //Arrange (arrange the circumstances being tested)
            ToDoTask TestTask = new ToDoTask("Test");
            TestTask.Status = arg1;

            //Act (goal to execute the action)
            Assert.Throws<InvalidOperationException> (() => TestTask.Execute());

            //Assert (is the result obtained what was expected?)
        }

        ////Below is the way to test with only the initial status of a new ToDoTask, which is Waiting.
        //[Fact]
        //public void Execute_ShouldChangeStatusToExecuting()
        //{
        //    //Arrange
        //    ToDoTask TestTask = new ToDoTask("Test");
        //    //Act
        //    TestTask.Execute();
        //    //Assert
        //    Assert.Equal(ToDoStatus.Executing, TestTask.Status);
        //}

        ////Below is the way to test with only the initial status of a new ToDoTask, which is Waiting.
        //[Fact]
        //public void Execute_WhenStatusRefused_ShouldChangeStatusToExecuting()
        //{
        //    //Arrange
        //    ToDoTask TestTask = new ToDoTask("Test");
        //    TestTask.Status = ToDoStatus.Refused;
        //    //Act
        //    TestTask.Execute();
        //    //Assert
        //    Assert.Equal(ToDoStatus.Executing, TestTask.Status);
        //}

        //Below is how to test the above two but using the Theory structure to insert the relevant infos re:Status
        [Theory]
        [InlineData(ToDoStatus.Waiting)]
        [InlineData(ToDoStatus.Refused)]
        public void Execute_WithStatusWaitingOrRefused_ShouldChangeStatusToExecuting(ToDoStatus arg1)
        {
            //Arrange
            ToDoTask TestTask = new ToDoTask("Test");
            TestTask.Status = arg1;

            //Act (goal to execute the action)
            TestTask.Execute();

            //Assert (is the result obtained what was expected?)
            Assert.Equal(ToDoStatus.Executing, TestTask.Status);
        }


        [Fact]
        public void Finish_WhenStatusExecuting_ShouldChangeStatusToFinished()
        {
            //Arrange
            ToDoTask TestTask = new ToDoTask("Test");
            TestTask.Status = ToDoStatus.Executing;

            //Act (goal to execute the action)
            TestTask.Finish();

            //Assert (is the result obtained what was expected?)
            Assert.Equal(ToDoStatus.Finished, TestTask.Status);
        }

        [Theory]
        [InlineData(ToDoStatus.Waiting)]
        [InlineData(ToDoStatus.Finished)]
        [InlineData(ToDoStatus.Validated)]
        [InlineData(ToDoStatus.Refused)]
        public void Finish_WhenStatusIsInvalid_ShouldThrowInvalidOperationException(ToDoStatus arg1)
        {
            //Arrange
            ToDoTask TestTask = new ToDoTask("Test");
            TestTask.Status = arg1;

            //Act + Assert
            Assert.Throws<InvalidOperationException>(() => TestTask.Finish());
        }


        [Fact]
        public void Validate_WhenStatusFinished_ShouldChangeStatusToValidated()
        {
            //Arrange
            ToDoTask TestTask = new ToDoTask("Test");
            TestTask.Status = ToDoStatus.Finished;

            //Act (goal to execute the action)
            TestTask.Validate();

            //Assert (is the result obtained what was expected?)
            Assert.Equal(ToDoStatus.Validated, TestTask.Status);
        }

        [Theory]
        [InlineData(ToDoStatus.Waiting)]
        [InlineData(ToDoStatus.Executing)]
        [InlineData(ToDoStatus.Validated)]
        [InlineData(ToDoStatus.Refused)]
        public void Validate_WhenStatusIsInvalid_ShouldThrowInvalidOperationException(ToDoStatus arg1)
        {
            //Arrange
            ToDoTask TestTask = new ToDoTask("Test");
            TestTask.Status = arg1;

            //Act + Assert
            Assert.Throws<InvalidOperationException>(() => TestTask.Validate());
        }


        [Fact]
        public void Refused_WhenStatusFinished_ShouldChangeStatusToRefused()
        {
            //Arrange
            ToDoTask TestTask = new ToDoTask("Test");
            TestTask.Status = ToDoStatus.Finished;

            //Act (goal to execute the action)
            TestTask.Refuse();

            //Assert (is the result obtained what was expected?)
            Assert.Equal(ToDoStatus.Refused, TestTask.Status);
        }

        [Theory]
        [InlineData(ToDoStatus.Waiting)]
        [InlineData(ToDoStatus.Executing)]
        [InlineData(ToDoStatus.Validated)]
        [InlineData(ToDoStatus.Refused)]
        public void Refused_WhenStatusIsInvalid_ShouldThrowInvalidOperationException(ToDoStatus arg1)
        {
            //Arrange
            ToDoTask TestTask = new ToDoTask("Test");
            TestTask.Status = arg1;

            //Act + Assert
            Assert.Throws<InvalidOperationException>(() => TestTask.Refuse());
        }


        //Below we test that the constructor works
        [Theory]
        [InlineData("test 1")]
        [InlineData("test 2")]
        [InlineData("test 3")]
        [InlineData("test 4")]
        [InlineData("test 5")]
        public void ToDoTaskConstructor_WithStringTitle_ShouldTitleSaveAndStatusToWaiting(string arg1)
        {
            //arrange
            ToDoTask task;

            //act
            task = new ToDoTask(arg1);

            //assert
            Assert.Equal(arg1, task.Title); //Assert.Equal cites two things that should be compared for identical value
            Assert.Equal(ToDoStatus.Waiting, task.Status);
        }




    }
}
