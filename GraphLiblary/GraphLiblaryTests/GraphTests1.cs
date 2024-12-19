using Moq;
using GraphLibrary;
using Xunit;
using System.Collections.Generic;

namespace GraphLibrary.Tests
{
    public class ContainerTests
    {
        [Fact]
        public void Container_Add_Top_Element_Verify_Interaction()
        {
            var mockContainer = new Mock<IContainer>();  
            var top = new Top(1); 

            mockContainer.Object.Add(top); 

            mockContainer.Verify(c => c.Add(It.IsAny<Graph>()), Times.Once); 
        }

        [Fact]
        public void Container_Remove_Element_Verify_Interaction()
        {
            var mockContainer = new Mock<IContainer>();  
            var top = new Top(1); 

            mockContainer.Object.Remove(top);  

            mockContainer.Verify(c => c.Remove(It.IsAny<Graph>()), Times.Once);  
        }

        [Fact]
        public void Container_FindNumber_Finds_Existing_Element()
        {
            var mockContainer = new Mock<IContainer>();  
            var top = new Top(1);  
            mockContainer.Setup(c => c.FindNumber(1)).Returns(top); 

            var result = mockContainer.Object.FindNumber(1); 

            Assert.Equal(top, result);
            mockContainer.Verify(c => c.FindNumber(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Container_GetAdjacentArcCount_Returns_Correct_Count()
        {
            var mockContainer = new Mock<IContainer>(); 
            var top = new Top(1);  
            var arc1 = new Arc(1, 1, 2);  
            var arc2 = new Arc(2, 1, 3);  
            mockContainer.Setup(c => c.GetAdjacentArcCount(1)).Returns(2);  

            var result = mockContainer.Object.GetAdjacentArcCount(1); 

            Assert.Equal(2, result); 
            mockContainer.Verify(c => c.GetAdjacentArcCount(It.IsAny<int>()), Times.Once); 
        }

        [Fact]
        public void Container_CountTop_Returns_Correct_Count()
        {
            var mockContainer = new Mock<IContainer>();  
            mockContainer.Setup(c => c.Counttop()).Returns(1);

            var result = mockContainer.Object.Counttop();  

            Assert.Equal(1, result);  
            mockContainer.Verify(c => c.Counttop(), Times.Once);  
        }

        [Fact]
        public void Container_GetAll_Returns_Correct_Elements()
        {
            var mockContainer = new Mock<IContainer>();  
            var top = new Top(1);  
            var arc = new Arc(1, 1, 2); 
            var elements = new List<Graph> { top, arc }; 
            mockContainer.Setup(c => c.GetAll()).Returns(elements); 

            var result = mockContainer.Object.GetAll(); 

            Assert.Contains(result, e => e is Top && ((Top)e).Number == 1); 
            Assert.Contains(result, e => e is Arc && ((Arc)e).Number == 1); 
            mockContainer.Verify(c => c.GetAll(), Times.Once);  
        }
    }
}
