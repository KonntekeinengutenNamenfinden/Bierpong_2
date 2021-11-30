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
        public int GruppenphasePunkte = 0;
        public int GruppenphaseTreffer = 0;
        public int GruppenphaseGegentreffer = 0;
        public int GruppenphaseTordifferenz = 0;

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

        /// <summary>
        /// Füge "GruppenphaseTreffer" für ein Team hinzu.
        /// </summary>
        /// <param name="hits"></param>
        public void AddHits(string hits)
        {
            if (UserDontInsertNegativeIntsOrLetters(hits))
            {
                GruppenphaseTreffer += int.Parse(hits);
            }

        }

        /// <summary>
        /// Ziehe GruppenphaseTreffer für ein Team ab.
        /// Überprüfe vorher: "HitsNotSmaller0AfterSub".
        /// </summary>
        /// <param name="subHits"></param>
        public void SubHits(string subHits)
        {
            if (UserDontInsertNegativeIntsOrLetters(subHits) && HitsNotSmaller0AfterSub(subHits))
            {
                GruppenphaseTreffer -= int.Parse(subHits);
            }

        }

        /// <summary>
        /// Wenn die "GruppenphaseTreffer" nach Abzug von Treffern unter 0 fallen könnte,
        /// dann führe den Abzug der Treffer nicht aus.
        /// </summary>
        /// <param name="subHits"></param>
        /// <returns></returns>
        public bool HitsNotSmaller0AfterSub(string subHits)
        {
            if (GruppenphaseTreffer - int.Parse(subHits) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Wenn die "Gruppenphasegegentreffer nach Abzug von Gegentreffern unter 0 fallen könnte,
        /// dann führe den Abzug der gegentreffer nicht aus.
        /// </summary>
        /// <param name="subAntiHits"></param>
        /// <returns></returns>
        public bool AntiHitsNotSmaller0AfterSub(string subAntiHits)
        {
            if (GruppenphaseGegentreffer - int.Parse(subAntiHits) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Füge "Gegentreffer" für ein Team hinzu.
        /// </summary>
        /// <param name="antihits"></param>
        public void AddAntiHits(string antihits)
        {
            if (UserDontInsertNegativeIntsOrLetters(antihits))
            {
                GruppenphaseGegentreffer += int.Parse(antihits);
            }

        }

        /// <summary>
        /// Ziehe "Gegentreffer" für ein Team ab.
        /// </summary>
        /// <param name="antihits"></param>
        public void SubAntiHits(string antihits)
        {
            if (UserDontInsertNegativeIntsOrLetters(antihits) && AntiHitsNotSmaller0AfterSub(antihits))
            {
                GruppenphaseGegentreffer -= int.Parse(antihits);
            }

        }

        /// <summary>
        /// Zeige die Tordifferenz eines Teams.
        /// </summary>
        public int GetHitDifference()
        {
            return GruppenphaseTreffer - GruppenphaseGegentreffer;
        }

        /// <summary>
        /// Wird aufgerufen, wenn der Benutzer die Werte "GruppenphaseTreffer" oder "Gegentreffer" verändern möchte.
        /// Sollte er Buchstaben oder eine negative Zahl eingeben, wird die Änderung nicht durchgeführt.
        /// </summary>
        /// <param name="insert"></param>
        /// <returns></returns>
        public bool UserDontInsertNegativeIntsOrLetters(string insert)
        {
            if (int.TryParse(insert, out int zahl))
            {
                if (zahl >= 0)
                {
                    return true;
                }
                else return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Innerhalb eines Matches kann ein Team höchstens 13 Treffer landen.
        /// Wenn der Benutzer mehr als 13 Treffer hinzufügen will: Unterbinde es.
        /// </summary>
        /// <param name="insert"></param>
        /// <returns></returns>
        public bool UserDontTryToAddMoreThan13HitsFor1Match(string insert)
        {
            if (UserDontInsertNegativeIntsOrLetters(insert))
            {
                if(int.Parse(insert) <= 13)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
