using System;

namespace Mc2.CrudTest.TestTools
{
    public static class Try
    {
        public static Exception CatchOrNull(Action action)
        {
            try
            {
                action();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
