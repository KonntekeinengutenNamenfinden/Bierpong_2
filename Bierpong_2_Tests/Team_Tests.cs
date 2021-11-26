using System;
using Bierpong_2;
using NUnit.Framework;

namespace Bierpong_2_Tests
{
    public class Team_Tests
    {
        public static Team MakeTeam(string tmn = "Alkoholis", string cptn = "Egon")
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

            int teamCountBeforeDelete = Team.AlleTeams.Count;
            myt.DeleteTeamFromTheList();
            bool result = Team.AlleTeams.Count < teamCountBeforeDelete;

            Assert.IsTrue(result);

        }

        [Test]
        public void AddHits_CheckIfTheMethodAddTheHitsForTheTeam_ReturnTrue()
        {
            Team tm = MakeTeam();

            tm.AddHits("4");
            bool result = tm.GruppenphaseTreffer == 4;

            Assert.IsTrue(result);
        }

        [TestCase(10, false)]
        [TestCase(3, true)]
        [TestCase(5, true)]
        public void SubHits_VariousChecks_CheckThem(int SubHits, bool expected)
        {
            Team tm = MakeTeam();
            tm.GruppenphaseTreffer = 5;
            int tmp = tm.GruppenphaseTreffer;

            tm.SubHits(SubHits.ToString());
            bool result = tmp > tm.GruppenphaseTreffer;

            Assert.AreEqual(expected, result);
        }

        [TestCase(-4, false)]
        [TestCase(0, false)]
        [TestCase(5, true)]
        public void AddAntiHits_VariousChecks_CheckThem(int AddAntiHits, bool expected)
        {
            Team myt = MakeTeam();
            myt.GruppenphaseGegentreffer = 5;
            int tmp = myt.GruppenphaseGegentreffer;

            myt.AddAntiHits(AddAntiHits.ToString());
            bool result = myt.GruppenphaseGegentreffer > tmp;

            Assert.AreEqual(expected, result);
        }

        [TestCase(10, false)]
        [TestCase(3, true)]
        [TestCase(0, false)]
        public void SubAntiHits_VariousChecks_CheckThem(int SubAntiHits, bool expected)
        {
            Team myt = MakeTeam();
            myt.GruppenphaseGegentreffer = 5;
            myt.SubAntiHits(SubAntiHits.ToString());

            bool result = myt.GruppenphaseGegentreffer < 5;

            Assert.AreEqual(expected, result);
        }

        [TestCase(10, false)]
        [TestCase(3, true)]
        [TestCase(5, true)]
        [TestCase(6, false)]
        public void HitsNotSmaller0AfterSub_VariousChecks_CheckThem(int SubHits, bool expected)
        {
            Team tm = MakeTeam();
            tm.GruppenphaseTreffer = 5;

            bool result =tm.HitsNotSmaller0AfterSub(SubHits.ToString());

            Assert.AreEqual(expected, result);
        }

        [TestCase(5, true)]
        [TestCase(4, true)]
        [TestCase(6, false)]
        [TestCase(10, false)]
        public void AntiHitsNotSmaller0AfterSub_VariousChecks_CheckThem(int SubAntiHits, bool expected)
        {
            Team myt = MakeTeam();
            myt.GruppenphaseGegentreffer = 5;

            bool result = myt.AntiHitsNotSmaller0AfterSub(SubAntiHits.ToString());

            Assert.AreEqual(expected, result);
        }

        [TestCase(7,10)]
        [TestCase(11, 9)]
        [TestCase(1,21)]
        [TestCase(21, 1)]
        public void GetHitDifference_VariousChecks_CheckThem(int Hits, int AntiHits)
        {
            Team myt = MakeTeam();
            myt.GruppenphaseTreffer = Hits;
            myt.GruppenphaseGegentreffer = AntiHits;

            int difference = Hits - AntiHits;
            bool result = difference == myt.GetHitDifference();

            Assert.IsTrue(result);
        }

        [TestCase("4", true)]
        [TestCase("heh", false)]
        [TestCase("", false)]
        [TestCase("-4", false)]
        [TestCase("                 5                ", true)]
        public void UserDontInsertNegativeIntsOrLetters_VariousChecks_CheckThem(string eingabe, bool expected)
        {
            Team myt = MakeTeam();

            bool result = myt.UserDontInsertNegativeIntsOrLetters(eingabe);

            Assert.AreEqual(expected, result);
        }
    }
}
