﻿namespace FrontTest.Extensions.Exceptions
{
    public class MyNotFoundException : Exception
    {
        public MyNotFoundException(string message) : base(message)
        { }
    }
}
