using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Totp.Interface
{
    public interface ITotpGenerator
    {
        /// <summary>
        /// Generates a valid TOTP. 
        /// </summary>
        /// <param name="accountSecretKey">User's secret key. Same as used to create the setup.</param>
        /// <returns>Creates a 6 digit one time password.</returns>
        int Generate(string accountSecretKey);


        int Generate(string accountSecretKey,long counter, int digit);

        /// <summary>
        /// Gets valid valid TOTPs. 
        /// </summary>
        /// <param name="accountSecretKey">User's secret key. Same as used to create the setup.</param>
        /// <param name="timeTolerance">Time tolerance in seconds to acceppt before and after now.</param>
        /// <returns>List of valid totps.</returns>
        IEnumerable<int> GetValidTotps(string accountSecretKey, TimeSpan timeTolerance);


        long GetCurrentCounter();
    }
}
