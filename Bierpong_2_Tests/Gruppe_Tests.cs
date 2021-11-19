using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bierpong_2;
using NUnit.Framework;

namespace Bierpong_2_Tests
{
    public class Gruppe_Tests
    {
        public Gruppe MakeGroup(string grpn = "A")
        {
            return new Gruppe(grpn);
        }

        [Test]
        public void AddTeamToGroup_CheckIfTheMethodAddsATeamToTheGroup()
        {
            Team tm = Team_Tests.MakeTeam();
            Gruppe grp = MakeGroup();
            int TeamsVorher = grp.AktiveTeams;

            grp.AddTeamToGroup(tm);
            bool result = TeamsVorher < Gruppe.TeamsInGruppe.Count;

            Assert.IsTrue(result);
        }

        [Test]
        public void SubTeamFromTheGroup_CheckIfTheMethodSubsATeamFromTheGroup()
        {
            Team tm = Team_Tests.MakeTeam();
            Gruppe grp = MakeGroup();

            grp.AddTeamToGroup(tm);
            int TeamsVorher = Gruppe.TeamsInGruppe.Count;
            grp.SubTeamFromGroup(tm);
            bool result = TeamsVorher > Gruppe.TeamsInGruppe.Count;

            Assert.IsTrue(result);
        }

        [Test]
        public void IncrementActiveTeamsBy1()
        {
            Team tm = Team_Tests.MakeTeam();
            Gruppe grp = MakeGroup();
            int AktiveTeamsVorher = grp.AktiveTeams;

            grp.AddTeamToGroup(tm);
            bool result = AktiveTeamsVorher < grp.AktiveTeams;

            Assert.IsTrue(result);
        }

        [Test]
        public void SubstractActiveTeamsBy1()
        {
            Team tm = Team_Tests.MakeTeam();
            Gruppe grp = MakeGroup();
            int AktiveTeamsVorher = grp.AktiveTeams;

            grp.SubTeamFromGroup(tm);
            bool result = AktiveTeamsVorher > grp.AktiveTeams;

            Assert.IsTrue(result);
        }
    }
}
