using System;
using Bierpong_2;
using NUnit.Framework;

namespace Bierpong_2_Tests
{
    public class Team_Tests
    {
        private Team MakeTeam(string tmn = "Alkoholis", string cptn = "Egon")
        {
            return new Team(tmn, cptn);
        }

        [TestCase("Egon", true)]
        [TestCase("      ", false)]
        [TestCase(".", true)]
        [TestCase("", false)]
        public void CaptainOrTeamNameNotEmptyOrNull_Various_CheckThem(string name, bool expected)
        {
             Team myTeam = MakeTeam(name);

            bool result = myTeam.CaptainOrTeamNameIsNotEmptyOrNull(name);

            Assert.AreEqual(expected, result);
        }


        [TestCase("       ", false, TeamProperties.Kapitän)]
        [TestCase("Manfred", true, TeamProperties.Kapitän)]
        [TestCase(null, false, TeamProperties.Kapitän)]
        public void ChangeTeamOrCaptainName_CheckVariousCaptainNames_CheckThem(string changedname, bool expected, TeamProperties prop = TeamProperties.Kapitän)
        {
            Team myTeam = MakeTeam();

            var tmp = myTeam.Kapitän;
            myTeam.ChangeTeamOrCaptainName(changedname, prop);
            bool result = (tmp != myTeam.Kapitän);

            Assert.AreEqual(expected, result);
        }

        [TestCase(" ", false, TeamProperties.Teamname)]
        [TestCase("PrimaDonnas", true, TeamProperties.Teamname)]
        [TestCase(null, false, TeamProperties.Teamname)]
        public void ChangeTeamOrCaptainName_CheckVariousTeamNames_CheckThem(string changedname, bool expected, TeamProperties prop = TeamProperties.Teamname)
        {
            Team myTeam = MakeTeam();

            var tmp = myTeam.Teamname;
            myTeam.ChangeTeamOrCaptainName(changedname, prop);
            bool result = (tmp != myTeam.Teamname);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddGroupphasePoints_CheckIfTheMethodAddsThePoints_ReturnTrue()
        {
            Team myt = MakeTeam();

            myt.AddGroupphasePoints();
            bool result = (myt.GruppenphasePunkte == 3);

            Assert.IsTrue(result);
        }

        [Test]
        public void SubstractGroupphasePoints_CheckIfTheMethodSubstractThePoints_ReturnTrue()
        {
            Team myt = MakeTeam();

            myt.SubstractGroupphasePoints();
            bool result = myt.GruppenphasePunkte == -3;

            Assert.IsTrue(result);
        }

        [Test]
        public void AddTeamToTheList_CheckIfTheMethodAddsTheTeamToTheList_ReturnTrue()
        {
            Team myt = MakeTeam();

            bool result = Team.AlleTeams.Count > 1;

            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteTeamFromTheList_CheckIfTheMethodDeletesTheTeamFromTheList_ReturnTrue()
        {
            Team myt = MakeTeam();

            myt.DeleteTeamFromTheList();
            bool result = (Team.AlleTeams.Count == 0);

            Assert.IsTrue(result);

        }
    }
}
