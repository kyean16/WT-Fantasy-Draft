namespace HelloWPFApp
{
    internal class NFLPlayers
    {
        private string firstName;
        private string lastName;
        private string position;
        private string team;
        private double projectedPoints;

        public NFLPlayers(string newFirstName, string newLastName, string newPosition, string newTeam, double newProjectedPoints)
        {
            firstName = newFirstName;
            lastName = newLastName;
            position = newPosition;
            team = newTeam;
            projectedPoints = newProjectedPoints;
        }

        public double getProjectedPoints()
        {
            return projectedPoints;
        }

        public string getFullName()
        {
            return getFirstName() + " " + getLastName() + " " + getPosition();
        }

        public string getFullNameAndPosition()
        {
            return getFirstName() + " " + getLastName() + ", " + getPosition();
        }

        public string getFirstName()
        {
            return firstName;
        }
        
        public string getLastName()
        {
            return lastName;
        }

        public string getPosition()
        {
            return position;
        }
    }
}