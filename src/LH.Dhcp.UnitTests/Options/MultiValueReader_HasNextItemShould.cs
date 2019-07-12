using System;
using Xunit;

namespace LH.Dhcp.UnitTests.Options
{
    // ReSharper disable once InconsistentNaming
    public class MultiValueReader_HasNextItemShould
    {
        [Fact]
        public void ReturnFalse_WhenThereIsNoNextItem()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void ReturnFalse_WhenNextItemIsEndOption()
        {
            throw new NotImplementedException();
        }
    }

    public class MultiValueReader_GetNextItemShould
    {
        [Fact]
        public void ThrowInvalidOperationException_WhenThereIsNoNextItem()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void ThrowInvalidOperationException_WhenNextItemIsEndOption()
        {
            throw new NotImplementedException();
        }
    }
}