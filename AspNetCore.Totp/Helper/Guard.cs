﻿using System;

namespace AspNetCore.Totp.Helper
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
