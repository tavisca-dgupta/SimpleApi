using HelloHiApi.Controllers;
using HelloHiApi;
using System;
using Xunit;
//using Microsoft.AspNetCore.Mvc;


namespace HelloHiApi.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_If_User_Say_hello()
        {   
            Assert.Equal("hi", Greet.greetPeople("hello"));
        }

        [Fact]
        public void Test_If_User_Say_hi()
        {
            Assert.Equal("hello", Greet.greetPeople("hi"));
        }

        
    }
}
