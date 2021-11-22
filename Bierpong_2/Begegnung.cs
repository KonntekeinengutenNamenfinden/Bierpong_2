using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bierpong_2
{
    public class Begegnung
    {
        public List<Team> BeideTeams = new();

        public int HitsTeamA;
        public int HitsTeamB;
        public Team Sieger;
        public Team Verlierer;

        string Ergebnis;

        public Begegnung(Team a, Team b)
        {
            AddTeamsToTheList(a, b);
        }

        /// <summary>
        /// Füge die beiden Teams der Liste für das Match hinzu.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void AddTeamsToTheList(Team a, Team b)
        {
            BeideTeams.Add(a);
            BeideTeams.Add(b);
        }

        /// <summary>
        /// Ermittle den Gewinner der Begegnung.
        /// </summary>
        public void DetermineWinnerAndLoser()
        {
            if(HitsTeamA > HitsTeamB && NoDraw())
            {
                Sieger = BeideTeams[0];
                Verlierer = BeideTeams[1];
            }
            else if(HitsTeamB > HitsTeamA && NoDraw())
            {
                Sieger = BeideTeams[1];
                Verlierer = BeideTeams[0];
            }
        }

        /// <summary>
        /// Ein Match darf NIEMALS unentschieden enden.
        /// </summary>
        /// <returns></returns>
        public bool NoDraw()
        {
            if(HitsTeamA == HitsTeamB)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string WriteTheResult()
        {
            return BeideTeams[0].Teamname + "   " + HitsTeamA + "   -   " + HitsTeamB + "   " + BeideTeams[1].Teamname;
        }
    }
}
