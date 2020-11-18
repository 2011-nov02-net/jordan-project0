using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Library;
using Xunit;

namespace UnitTests
{
    public class CustomerTest
    {
        [Fact]
        public void ValidCustomer()
        {
            Customer NoName = new Customer(2);
            Assert.False(NoName.isValid());
        }

    }
}
