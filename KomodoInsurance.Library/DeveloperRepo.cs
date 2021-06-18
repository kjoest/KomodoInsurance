using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.Library
{
    public class DeveloperRepo
    {
        private List<Developer> _listOfDevelopers = new List<Developer>();

        public void AddDeveloper(Developer developer)
        {
            _listOfDevelopers.Add(developer);
        }

        public List<Developer> GetDeveloperList()
        {
            return _listOfDevelopers;
        }

        public bool UpdateDevelopers(string originalDeveloper, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperByDevName(originalDeveloper);

            if (originalDeveloper != null)
            {
                oldDeveloper.DevName = newDeveloper.DevName;
                oldDeveloper.DevID = newDeveloper.DevID;
                oldDeveloper.Pluralsight = newDeveloper.Pluralsight;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDevelopersFromListByName(string devName)
        {
            Developer developer = GetDeveloperByDevName(devName);

            if(developer == null)
            {
                return false;
            }

            int intialDeveloper = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if(_listOfDevelopers.Count < intialDeveloper)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDevelopersFromListByID(string devID)
        {
            Developer developer = GetDeveloperByID(devID);

            if(developer == null)
            {
                return false;
            }

            int initialDeveloperID = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if(_listOfDevelopers.Count < initialDeveloperID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Developer> GetAllDevelopersThatDontHavePluralsight()
        {
            List<Developer> DevelopersHasPluralsight = new List<Developer>();

            foreach (Developer developer in _listOfDevelopers)
            {
                if (!developer.Pluralsight)
                {
                    DevelopersHasPluralsight.Add(developer);
                }
            }

            return DevelopersHasPluralsight;
        }

        //Helper Method
        public Developer GetDeveloperByDevName(string devName)
        {
            foreach(Developer developer in _listOfDevelopers)
            {
                if(developer.DevName.ToLower() == devName.ToLower())
                {
                    return developer;
                }
            }

            return null;
        }

        //Helper Method
        public Developer GetDeveloperByID (string devID)
        {
            foreach(Developer developer in _listOfDevelopers)
            {
                if (developer.DevID.ToLower() == devID.ToLower())
                {
                    return developer;
                } 
            }

            return null;
        }

    }
}
