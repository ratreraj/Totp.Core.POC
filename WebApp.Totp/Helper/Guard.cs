using System;

namespace WebApp.Totp.Helper
{
    internal static class Guard
    {
        internal static void NotNull(object testee)
        {
            if (testee == null)
            {
                throw new NullReferenceException();
            }
        }
    }
}
