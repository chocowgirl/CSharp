using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    public class CalculatriceTests
    {

        public Calculatrice CalcTest { get; set; }
        
        public CalculatriceTests()
        {
            CalcTest = new Calculatrice();
        }

        [Fact]
        public void Addition_With4and2_ShouldReturn6()
        {
            //Arrange (arrange the circumstances being tested)
            int nb1 = 4;
            int nb2 = 2;
            int result;


            //Act (goal to execute the action)
            result = Calculatrice.Addition(nb1, nb2);


            //Assert (is the result obtained what was expected?)
            //if (result == 8)
            //{
            //    Console.WriteLine($"Test réussi!");
            //}
            //else
            //{
            //    Console.WriteLine($"Test échoué :( ");
            //}

            Assert.Equal(6,result);
        }

        [Fact]
        public void Addition_WithTwoBigValue_ShouldThrowOverflowException()
        {
            //Arrange
            int nb1 = 1_500_000_000;
            int nb2 = 1_500_000_000; //reminder that underscore can be used to clarify numbers without consequence in c#
            int result;

            //Act + Assert
            Assert.Throws<OverflowException>(() => result= Calculatrice.Addition(nb1,nb2));

            //try
            //{
            //    result = Calculatrice.Addition(nb1, nb2);
            //}
            //catch (Exception ex)
            //{
            //    //Assert
            //    if (ex is OverflowException)
            //    {
            //        Console.WriteLine("Test réussi");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Test échoué ... ");
            //    }
            //}
        }


        [Fact]
        public void Multiply_WithIntsValue_ShouldReturnInt()
        {
            //arrange
            int nb1 = 4;
            int nb2 = 2;
            int result;

            //act
            result = (int)Calculatrice.Multiply(nb1, nb2);

            //assert
            Assert.Equal(8,result);
        }

        [Theory]
        [InlineData(4,2,8)]
        [InlineData(6, 2, 12)]
        [InlineData(1, 2, 2)]
        [InlineData(30, 20, 600)]
        [InlineData(30, -2, -60)]
        [InlineData(-1, -2, 2)]
        public void MultiplyT_WithIntsValue_ShouldReturnInt(int arg1, int arg2, int expected)
        {
            //arrange
            int nb1 = arg1;
            int nb2 = arg2;
            int result;

            //act
            result = (int)Calculatrice.Multiply(nb1, nb2);

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculatriceConstructor_ShouldInitiateList()
        {
            //Arrange
            Calculatrice calc;
            
            //Act
            calc = new Calculatrice();

            //Assert
            Assert.NotNull(calc.Operations);
            Assert.Empty(calc.Operations);
        }

        [Fact]
        public void OperationsProp_ReturnsArray()
        {
            //Arrange
            Calculatrice calculatrice = new Calculatrice();
            Operation[] result;

            //Act
            result = calculatrice.Operations;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Operation[]>(result);
        }

        [Theory]
        [InlineData(5.2, OperatorEnum.Multiply, 3.1)]
        [InlineData(2.5, OperatorEnum.Divide, 0)]
        [InlineData(2.14, OperatorEnum.Sub, 1.3)]
        [InlineData(14.21, OperatorEnum.Plus, 1.76)]
        public void AddOperation_WithValues_ShouldAddNewOperation(double arg1, OperatorEnum arg2, double arg3)
        {
            //Arrange
            Calculatrice calc = new Calculatrice();

            //Act
            calc.AddOperation(arg1, arg2, arg3);

            //Assert
            Assert.NotEmpty(calc.Operations);
            Assert.Single(calc.Operations);
            Assert.Equal(arg1, calc.Operations[0].LeftValue);
            Assert.Equal(arg2, calc.Operations[0].Operator);
            Assert.Equal(arg3, calc.Operations[0].RightValue);
        }


        [Theory]
        [InlineData(5.2, OperatorEnum.Multiply, 3.1)]
        [InlineData(2.5, OperatorEnum.Divide, 0)]
        [InlineData(2.14, OperatorEnum.Sub, 1.3)]
        [InlineData(14.21, OperatorEnum.Plus, 1.76)]
        public void AddOperation_WithValues_ShouldAddNewOperationToTheList(double arg1, OperatorEnum arg2, double arg3)
        {
            //arrange
            Calculatrice calc = CalcTest;
            int count = calc.Operations.Length;

            //Act
            calc.AddOperation(arg1, arg2, arg3);

            //assert
            Assert.NotNull(calc.Operations);
            Assert.NotEmpty(calc.Operations);
            Assert.Equal(count + 1, calc.Operations.Length);
            int length = calc.Operations.Length;
            Assert.Equal(arg1, calc.Operations[length - 1].LeftValue);
            Assert.Equal(arg2, calc.Operations[length -1].Operator);
            Assert.Equal(arg3, calc.Operations[length -1].RightValue);
        }
    }
}
