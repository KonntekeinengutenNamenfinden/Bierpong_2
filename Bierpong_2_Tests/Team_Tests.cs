﻿using System;
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

            tm.AddHits(4);
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

            tm.SubHits(SubHits);
            bool result = tmp > tm.GruppenphaseTreffer;

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

            bool result =tm.HitsNotSmaller0AfterSub(SubHits);

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
    }
}
