using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bierpong_2;
using NUnit.Framework;

namespace Bierpong_2_Tests
{
    public class Begegnung_Tests
    {
        public Begegnung MakeMatch()
        {
            return new Begegnung(new Team("Alpha", "Fritz"), new Team("Bravo", "Egon"));
        }

        [Test]
        public void AddTeamsToTheList_CheckIfTheMethodAddsThe2TeamsToTheMatchList_True()
        {
            Begegnung match = new Begegnung(new Team("AL", "Fritz"), new Team("BR", "Egon"));

            bool result = match.BeideTeams.Count == 2;

            Assert.IsTrue(result);
        }

        [TestCase(5, 11, false)]
        [TestCase(11, 4, true)]
        [TestCase(11, 11, false)]
        [TestCase(10, 9, true)]
        public void DetermineWinnerAndLoser_CheckIfTheMethodCanDetermineTheWinnerCorrectly_VariousCheks(int hitA, int hitB, bool expected)
        {
            Begegnung match = MakeMatch();
            match.HitsTeamA = hitA;
            match.HitsTeamB = hitB;

            match.DetermineWinnerAndLoser();
            bool result = match.Sieger == match.BeideTeams[0] && match.Verlierer == match.BeideTeams[1];

            Assert.AreEqual(expected, result);
        }

        [TestCase(9, 5, true)]
        [TestCase(5, 5, false)]
        [TestCase(0, 0, false)]
        [TestCase(4, 9, true)]
        public void NoDraw_CheckIfMatchCanEndsDraw_VariousChecks(int hitA, int hitB, bool expected)
        {
            Begegnung match = MakeMatch();
            match.HitsTeamA = hitA;
            match.HitsTeamB = hitB;

            bool result = match.NoDraw();

            Assert.AreEqual(expected, result);
        }
    }
}
