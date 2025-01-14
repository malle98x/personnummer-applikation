using System;
using Xunit;

namespace PersonnummerValidering.Tests
{
    public class PersonnummerTester90Tal
    {
        // Testar att datumdelen i personnumret är ett giltigt datum i personnumret
        [Theory]
        [InlineData("9001011234", true)]   // Giltigt födelsedatum
        [InlineData("9105056789", true)]   // Giltigt födelsedatum
        [InlineData("9202299999", true)]   // Datumvalidering
        [InlineData("9213123456", false)]  // Ogiltigt datum
        public void ValideraFodelsedatum_SkaReturneraRattResultat(string pnr, bool forvantatResultat)
        {
            string datepart = pnr.Substring(0, 6);
            string dateformat = "yyMMdd";

            bool resultat = DateTime.TryParseExact(datepart, dateformat, null, System.Globalization.DateTimeStyles.None, out _);

            Assert.Equal(forvantatResultat, resultat);
        }

        // Testar könsbestämning baserat på den nästsista siffran
        [Theory]
        [InlineData("9001011234", "Man")]
        [InlineData("9105056789", "Kvinna")]
        [InlineData("9201012345", "Kvinna")]
        public void KontrolleraKön_SkaReturneraKorrektKön(string pnr, string forvantatKön)
        {
            int genderDigit = int.Parse(pnr[^2].ToString());
            string kon = genderDigit % 2 == 0 ? "Kvinna" : "Man";

            Assert.Equal(forvantatKon, kon);
        }
    }
}