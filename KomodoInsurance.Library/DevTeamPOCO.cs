using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.Library
{
    public class DevTeamPOCO
    {

    }

    public class DeveloperTeam
    {
        public string TeamName { get; set; }

        public List<Developer> TeamMembers { get; set; }

        public string TeamID { get; set; }



        public DeveloperTeam()
        {

        }

        public DeveloperTeam (string teamName, List<Developer> teamMembers, string teamID)
        {
            this.TeamName = teamName;
            this.TeamMembers = teamMembers;
            this.TeamID = teamID;
        }
    }

    
}




