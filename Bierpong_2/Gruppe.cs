using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bierpong_2
{
    public class Gruppe
    {
        public string Gruppenname;
        public int AktiveTeams = 0;

        public List<Team> TeamsInGruppe = new();

        public Gruppe(string grpn)
        {
            Gruppenname = grpn;
        }

        /// <summary>
        /// Füge ein Team einer Gruppe hinzu.
        /// </summary>
        /// <param name="tm"></param>
        public void AddTeamToGroup(Team tm)
        {
            TeamsInGruppe.Add(tm);
            IncrementActiveTeamsBy1();
        }

        /// <summary>
        /// Entferne ein Team aus der Gruppe.
        /// </summary>
        /// <param name="tm"></param>
        public void SubTeamFromGroup(Team tm)
        {
            TeamsInGruppe.Remove(tm);
            SubstractActiveTeamsBy1();
        }

        /// <summary>
        /// Inkrementiere die Eigenschaft "AktiveTeams" um 1.
        /// </summary>
        public void IncrementActiveTeamsBy1()
        {
            AktiveTeams++;
        }

        /// <summary>
        /// Subtrahiere die Eigenschaft "AktiveTeams" um 1.
        /// </summary>
        public void SubstractActiveTeamsBy1()
        {
            AktiveTeams--;
        }
    }
}
