using Moq;
using System;
using Xunit;

namespace P28E01.Tests
{
    public class DeskFanTest
    {
        [Fact]
        public void PowerLowerThanZero_OK()
        {
            var fan = new DeskFan(new PowerSupplyLowerThanZero());
            var expected = "Won't work.";
            var actual = fan.Work();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PowerHigherThan200_Warning()
        {
            var fan = new DeskFan(new PowerSupplyHigherThan200());
            // 注：此处为了演示，实际程序那边先故意改成了 Exploded!
            var expected = "Warning";
            //var expected = "Exploded";
            var actual = fan.Work();
            Assert.Equal(expected, actual);
        }

        // Mock（模拟） Framework
        [Fact]
        public void PowerHigherThan200_Warning2()
        {
            //  nuget moq
            var mock = new Mock<IPowerSupply>();
            mock.Setup(ps => ps.GetPower()).Returns(() => 220);
            var fan = new DeskFan(mock.Object);
            var expected = "Warning";
            var actual = fan.Work();
            Assert.Equal(expected, actual);
        }

    }

    class PowerSupplyLowerThanZero : IPowerSupply
    {
        public int GetPower()
        {
            return 0;
        }
    }

    class PowerSupplyHigherThan200 : IPowerSupply
    {
        public int GetPower()
        {
            return 220;
        }
    }
}
