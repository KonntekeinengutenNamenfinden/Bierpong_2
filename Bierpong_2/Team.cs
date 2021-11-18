using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bierpong_2
{
    public enum TeamProperties
    {
        Kapitän,
        Teamname
    };
    public class Team
    {
        public string Kapitän;
        public string Teamname;
        public int GruppenphasePunkte;

        public static List<Team> AlleTeams = new();

        public Team(string tmn, string cptname)
        {
            try
            {
                if (CaptainOrTeamNameIsNotEmptyOrNull(tmn))
                {
                    Teamname = tmn;
                }
                else
                {
                    ///
                }

                if (CaptainOrTeamNameIsNotEmptyOrNull(cptname))
                {
                    Kapitän = cptname;
                }
                else
                {
                    ///
                }
                AddTeamToTheList(this);
            }
            catch
            {

            }

        }

        public bool CaptainOrTeamNameIsNotEmptyOrNull(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name.Trim()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public void ChangeTeamOrCaptainName(string name, TeamProperties property)
        {
            if (property == TeamProperties.Kapitän)
            {
                if (this.CaptainOrTeamNameIsNotEmptyOrNull(name))
                {
                    Kapitän = name;
                }
            }

            else
            {
                if (this.CaptainOrTeamNameIsNotEmptyOrNull(name))
                {
                    Teamname = name;
                }
            }
        }

        public void AddTeamToTheList(Team tm)
        {
            AlleTeams.Add(tm);
        }

        public void DeleteTeamFromTheList()
        {
            AlleTeams.Remove(this);
        }

        public void AddGroupphasePoints()
        {
            GruppenphasePunkte += 3;
        }

        public void SubstractGroupphasePoints()
        {
            GruppenphasePunkte -= 3;
        }
    }
}
