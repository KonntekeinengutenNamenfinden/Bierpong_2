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
                    //
                }

                if (CaptainOrTeamNameIsNotEmptyOrNull(cptname))
                {
                    Kapitän = cptname;
                }
                else
                {
                    //
                }
                AddTeamToTheList(this);
            }
            catch
            {

            }

        }

        /// <summary>
        /// Überprüfe, ob ein eingegebener Team- oder Kapitänsname Zeichen enthält.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Ändere den Namen eines Teams oder eines Kapitäns.
        /// Führe dabei auch die Überprüfung "CaptainOrTeamNameIsNotEmptyOrNull" aus.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="property"></param>
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

        /// <summary>
        /// Füge ein Team zur Liste "AlleTeams" hinzu.
        /// </summary>
        /// <param name="tm"></param>
        public void AddTeamToTheList(Team tm)
        {
            AlleTeams.Add(tm);
        }

        /// <summary>
        /// Lösche ein Team aus der Liste "AlleTeams".
        /// </summary>
        public void DeleteTeamFromTheList()
        {
            AlleTeams.Remove(this);
        }

        /// <summary>
        /// Wenn ein Team ein Gruppenspiel gewonnen  hat, füge 3 Punkte für die Teameigenschaft "GruppenphasePunkte" hinzu.
        /// </summary>
        public void AddGroupphasePoints()
        {
            GruppenphasePunkte += 3;
        }

        /// <summary>
        /// Falls beispielsweise ein Fehler beim Auswerten eines Spiels passiert ist: Ziehe 3 Punkte für ein Team ab.
        /// </summary>
        public void SubstractGroupphasePoints()
        {
            GruppenphasePunkte -= 3;
        }
    }
}
