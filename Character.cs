namespace Game
{
    public class Character
    {
        public string name;
        public string type;
        public int level;
        public int health;
        public List<Ability> abilities;

        public Character(string characterName, string characterType, int characterLevel)
        {
            name = characterName;
            type = characterType;
            level = characterLevel;
            health = CalculateHealth(level); // Calculate Health Based ON Level
            abilities = new List<Ability>();
        }

        private int CalculateHealth(int level)
        {
            return 100 + (level - 1) * 20;
        }

        public void ResetHealth()
        {
            health = CalculateHealth(level);
        }

        public void AddAbility(string abilityName, int abilityLevel)
        {
            if (abilities.Count >= 4)
            {
                Console.WriteLine("Ability Limit Reached");
                return;
            }

            Ability ability = new Ability(abilityName, abilityLevel);
            abilities.Add(ability);
        }
    }

    public class Ability
    {
        public string abilityName;
        public int abilityLevel;

        public Ability(string name, int level)
        {
            abilityName = name;
            abilityLevel = level;
        }
    }
}
