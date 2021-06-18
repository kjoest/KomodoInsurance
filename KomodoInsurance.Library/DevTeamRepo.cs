using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.Library
{
    public class DevTeamRepo
    {
        private List<DeveloperTeam> _listOfDeveloperTeams = new List<DeveloperTeam>();

        public void AddDevelopersToTeam (DeveloperTeam developerTeam)
        {
            _listOfDeveloperTeams.Add(developerTeam);
        }

        public List<DeveloperTeam> GetDeveloperTeams()
        {
            return _listOfDeveloperTeams;
        }

        public bool UpdateDeveloperTeam(string originalTeam, DeveloperTeam newDeveloperTeam)
        {
            DeveloperTeam oldDeveloperTeam = GetDeveloperByTeamName(originalTeam);

            if(oldDeveloperTeam != null)
            {
                oldDeveloperTeam.TeamMembers = newDeveloperTeam.TeamMembers;
                oldDeveloperTeam.TeamID = newDeveloperTeam.TeamID;
                oldDeveloperTeam.TeamName = newDeveloperTeam.TeamName;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveDeveloperFromTeam(string teamMember)
        {
            DeveloperTeam developerTeam = GetDeveloperByTeamName(teamMember);

            if (developerTeam == null)
            {
                return false;
            }

            int initialDeveloperTeam = _listOfDeveloperTeams.Count;
            _listOfDeveloperTeams.Remove(developerTeam);

            if (initialDeveloperTeam > _listOfDeveloperTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DeveloperTeam GetDeveloperByTeamName(string teamName)
        {
            foreach(DeveloperTeam developerTeam in _listOfDeveloperTeams)
            {
                if (developerTeam.TeamName.ToLower() == teamName.ToLower());
                {
                    return developerTeam;
                }
            }

            return null;
        }
    }
}
