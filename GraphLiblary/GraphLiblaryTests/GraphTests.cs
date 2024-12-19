using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphLibrary;

namespace GraphLibraryTests
{
    [TestClass()]
    public class GraphTests
    {
        [TestClass()]
        public class GraphTest
        {
            [TestMethod]
            public void AddAndGetAllElements_ShouldContainAddedElements()
            {
                // Arrange
                var container = new Container();
                var top1 = new Top(1);
                var top2 = new Top(2);
                var arc1 = new Arc(1, 1, 2);

                // Act
                container.Add(top1);
                container.Add(top2);
                container.Add(arc1);

                // Assert
                var allElements = container.GetAll();
                Assert.IsTrue(allElements.Exists(e => e is Top && ((Top)e).Number == 1));
                Assert.IsTrue(allElements.Exists(e => e is Top && ((Top)e).Number == 2));
                Assert.IsTrue(allElements.Exists(e => e is Arc && ((Arc)e).Number == 1));
            }

            [TestMethod]
            public void RemoveElement_ShouldNotContainRemovedElement()
            {
                // Arrange
                var container = new Container();
                var top1 = new Top(1);
                var arc1 = new Arc(1, 1, 2);

                container.Add(top1);
                container.Add(arc1);

                // Act
                container.Remove(top1);

                // Assert
                var allElements = container.GetAll();
                Assert.IsFalse(allElements.Exists(e => e is Top && ((Top)e).Number == 1));
                Assert.IsFalse(allElements.Exists(e => e is Arc && ((Arc)e).Number == 1));
            }

            [TestMethod]
            public void FindElementByNumber_ShouldReturnCorrectElement()
            {
                // Arrange
                var container = new Container();
                var top1 = new Top(1);
                container.Add(top1);

                // Act
                var foundElement = container.FindNumber(1);

                // Assert
                Assert.IsNotNull(foundElement);
                Assert.IsInstanceOfType(foundElement, typeof(Top));
                Assert.AreEqual(1, ((Top)foundElement).Number);
            }

            [TestMethod]
            public void CountAdjacentArcs_ShouldReturnCorrectCount()
            {
                // Arrange
                var container = new Container();
                var top1 = new Top(1);
                var top2 = new Top(2);
                var arc1 = new Arc(1, 1, 2);
                var arc2 = new Arc(2, 2, 1);
                container.Add(top1);
                container.Add(top2);
                container.Add(arc1);
                container.Add(arc2);

                // Act
                var adjacentArcsForTop1 = container.GetAdjacentArcCount(1);
                var adjacentArcsForTop2 = container.GetAdjacentArcCount(2);

                // Assert
                Assert.AreEqual(2, adjacentArcsForTop1);
                Assert.AreEqual(2, adjacentArcsForTop2); 
            }

            [TestMethod]
            public void CountTops_ShouldReturnCorrectCount()
            {
                // Arrange
                var container = new Container();
                var top1 = new Top(1);
                var top2 = new Top(2);
                var arc1 = new Arc(1, 1, 2);

                container.Add(top1);
                container.Add(top2);
                container.Add(arc1);

                // Act
                var countOfTops = container.Counttop();

                // Assert
                Assert.AreEqual(2, countOfTops); 
            }

            [TestMethod]
            public void EmptyContainer_ShouldReturnZeroAdjacentArcs()
            {
                // Arrange
                var container = new Container();

                // Act
                var adjacentArcsForTop1 = container.GetAdjacentArcCount(1); 

                // Assert
                Assert.AreEqual(0, adjacentArcsForTop1); 
            }

            [TestMethod]
            public void ContainerWithNoMatchingArcs_ShouldReturnZeroAdjacentArcs()
            {
                // Arrange
                var container = new Container();
                var top1 = new Top(1);
                var top2 = new Top(2);
                container.Add(top1);
                container.Add(top2);

                // Act
                var adjacentArcsForTop1 = container.GetAdjacentArcCount(1); 

                // Assert
                Assert.AreEqual(0, adjacentArcsForTop1); 
            }

            [TestMethod]
            public void ContainerWithMultipleArcs_ShouldReturnCorrectAdjacentArcsCount()
            {
                // Arrange
                var container = new Container();
                var top1 = new Top(1);
                var top2 = new Top(2);
                var top3 = new Top(3);
                var arc1 = new Arc(1, 1, 2);
                var arc2 = new Arc(2, 2, 1);
                var arc3 = new Arc(3, 2, 3);
                container.Add(top1);
                container.Add(top2);
                container.Add(top3);
                container.Add(arc1);
                container.Add(arc2);
                container.Add(arc3);

                // Act
                var adjacentArcsForTop1 = container.GetAdjacentArcCount(1); 
                var adjacentArcsForTop2 = container.GetAdjacentArcCount(2); 
                var adjacentArcsForTop3 = container.GetAdjacentArcCount(3); 

                // Assert
                Assert.AreEqual(2, adjacentArcsForTop1); 
                Assert.AreEqual(3, adjacentArcsForTop2); 
                Assert.AreEqual(1, adjacentArcsForTop3);
            }

            [TestMethod]
            public void RemoveArcWhileKeepingTops_ShouldRemoveArcOnly()
            {
                // Arrange
                var container = new Container();
                var top1 = new Top(1);
                var top2 = new Top(2);
                var arc1 = new Arc(1, 1, 2);
                container.Add(top1);
                container.Add(top2);
                container.Add(arc1);

                // Act
                container.Remove(arc1);

                // Assert
                Assert.IsTrue(container.GetAll().Exists(e => e is Top && ((Top)e).Number == 1)); 
                Assert.IsTrue(container.GetAll().Exists(e => e is Top && ((Top)e).Number == 2)); 
                Assert.IsFalse(container.GetAll().Exists(e => e is Arc && ((Arc)e).Number == 1));
            }
        }

    }
}
