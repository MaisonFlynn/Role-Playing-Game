namespace Game
{
    public class GameMenu
    {
        private List<Character> characters = new List<Character>();

        // Test Data
        public GameMenu()
        {
            TestData();
        }

        private void TestData()
        {
            characters.Add(new Character("Blaze", "Fire", 3));
            characters[0].abilities.Add(new Ability("Fireball", 1));
            characters[0].abilities.Add(new Ability("Flame Burst", 2));
            characters[0].abilities.Add(new Ability("Heat Wave", 2));
            characters[0].abilities.Add(new Ability("Inferno", 3));

            characters.Add(new Character("Aqua", "Water", 4));
            characters[1].abilities.Add(new Ability("Watergun", 1));
            characters[1].abilities.Add(new Ability("Bubble Beam", 2));
            characters[1].abilities.Add(new Ability("Hydro Pump", 3));
            characters[1].abilities.Add(new Ability("Aqua Ring", 3));

            characters.Add(new Character("Leafy", "Grass", 2));
            characters[2].abilities.Add(new Ability("Leaf Tornado", 1));
            characters[2].abilities.Add(new Ability("Vine Whip", 1));
            characters[2].abilities.Add(new Ability("Solar Beam", 2));
            characters[2].abilities.Add(new Ability("Seed Bomb", 2));

            characters.Add(new Character("Terra", "Normal", 5));
            characters[3].abilities.Add(new Ability("Tackle", 2));
            characters[3].abilities.Add(new Ability("Headbutt", 3));
            characters[3].abilities.Add(new Ability("Barrage", 3));
            characters[3].abilities.Add(new Ability("Stomp", 4));
        }

        // Game Menu
        public void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Role-Playing Game");
                Console.WriteLine("   1.   Add New Character");
                Console.WriteLine("   2.   Edit Existing Character");
                Console.WriteLine("   3.   Delete Character");
                Console.WriteLine("   4.   Display All Characters");
                Console.WriteLine("   5.   Battle");
                Console.WriteLine("   6.   Exit");
                Console.WriteLine("-----------------------------------");

                Console.Write("Enter Option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddNewCharacter();
                        break;
                    case "2":
                        EditExistingCharacter();
                        break;
                    case "3":
                        DeleteCharacter();
                        break;
                    case "4":
                        DisplayAllCharacters();
                        break;
                    case "5":
                        Battle();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option, Please Try Again");
                        break;
                }
            }
        }

        private void AddNewCharacter()
        {
            Console.Write("Enter Character Name: ");
            string name = Console.ReadLine();

            // Check IF Character Exists
            bool exists = false;
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].name.ToLower() == name.ToLower())
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
            {
                Console.WriteLine("Character Exists");
                return;
            }

            Console.Write("Enter Character Type (Fire, Water, Grass OR Normal): ");
            string type = Console.ReadLine();

            // Validate Type
            while (type.ToLower() != "fire" && type.ToLower() != "water" && type.ToLower() != "grass" && type.ToLower() != "normal")
            {
                Console.WriteLine("Invalid Type, Please Try Again");
                Console.Write("Enter Character Type (Fire, Water, Grass OR Normal): ");
                type = Console.ReadLine();
            }

            int level;
            while (true)
            {
                Console.Write("Enter Characer Level (1 - 7): ");
                level = int.Parse(Console.ReadLine());

                // Check IF Level IS Valid
                if (level >= 1 && level <= 7)
                {
                    break;
                }
                Console.WriteLine("Invalid Level, Please Try Again");
            }

            Character newCharacter = new Character(name, type, level);

            // Abilities
            while (newCharacter.abilities.Count < 4)
            {
                Console.Write("Enter Ability Name OR 'Done': ");
                string abilityName = Console.ReadLine();

                if (abilityName.ToLower() == "done" || newCharacter.abilities.Count >= 4)
                {
                    break;
                }

                int abilityLevel;
                while (true)
                {
                    Console.Write("Enter Ability Level (0 - 5): ");
                    abilityLevel = int.Parse(Console.ReadLine());

                    if (abilityLevel >= 0 && abilityLevel <= 5)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid Ability Level, Please Try Again");
                }

                newCharacter.AddAbility(abilityName, abilityLevel);

                if (newCharacter.abilities.Count == 4)
                {
                    Console.WriteLine("Ability Limit Reached");
                    break;
                }
            }

            characters.Add(newCharacter);
            Console.WriteLine("Character Saved");
        }

        private void EditExistingCharacter()
        {
            Console.Write("Enter Name OF Character TO Edit: ");
            string name = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].name.ToLower() == name.ToLower())
                {
                    found = true;
                    Character character = characters[i];
                    bool edit = true;

                    while (edit)
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine($"Edit Character: {name}");
                        Console.WriteLine("   1.   Edit Name");
                        Console.WriteLine("   2.   Edit Type");
                        Console.WriteLine("   3.   Edit Abilities");
                        Console.WriteLine("   4.   Edit Level");
                        Console.WriteLine("   5.   Exit");
                        Console.WriteLine("-----------------------------------");

                        Console.Write("Enter Option: ");
                        string option = Console.ReadLine();

                        switch (option)
                        {
                            case "1": // Edit Name
                                Console.Write("Enter NEW Name: ");
                                character.name = Console.ReadLine();
                                Console.WriteLine("Name Updated");
                                break;
                            case "2": // Edit Type
                                Console.Write("Enter NEW Type (Fire, Water, Grass OR Normal): ");
                                string newType = Console.ReadLine();

                                while (newType.ToLower() != "fire" && newType.ToLower() != "water" && newType.ToLower() != "grass" && newType.ToLower() != "normal")
                                {
                                    Console.WriteLine("Invalid Type, Please Try Again");
                                    Console.Write("Enter NEW Type (Fire, Water, Grass OR Normal): ");
                                    newType = Console.ReadLine();
                                }

                                character.type = newType;
                                Console.WriteLine("Type Updated");
                                break;
                            case "3": // Edit Abilities
                                EditAbilities(character);
                                break;
                            case "4": // Edit Level & Health
                                int newLevel;
                                while (true)
                                {
                                    Console.Write("Enter NEW Level (1 - 7): ");
                                    newLevel = int.Parse(Console.ReadLine());

                                    // Check IF NEW Level IS Valid
                                    if (newLevel >= 1 && newLevel <= 7)
                                    {
                                        character.level = newLevel;
                                        character.health = 100 + (newLevel - 1) * 20;
                                        Console.WriteLine("Level & Health Updated");
                                        break;
                                    }
                                    Console.WriteLine("Invalid Level, Please Try Again");
                                }
                                break;
                            case "5": // Exit
                                edit = false;
                                break;
                            default:
                                Console.WriteLine("Invalid Option, Please Try Again");
                                break;
                        }
                    }
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Character NOT Found");
            }
        }
        private void EditAbilities(Character character)
        {
            Console.WriteLine($"Current Abilities: {character.abilities.Count}");
            if (character.abilities.Count == 0)
            {
                Console.WriteLine("   No Abilities.");
            }
            else
            {
                for (int i = 0; i < character.abilities.Count; i++)
                {
                    Console.WriteLine($"   {i + 1}.   {character.abilities[i].abilityName} - Level: {character.abilities[i].abilityLevel}");
                }
            }

            Console.WriteLine("'Add' OR 'Edit' Ability?");
            string action = Console.ReadLine();

            if (action.ToLower() == "add")
            {
                // Add NEW Ability
                while (true)
                {
                    if (character.abilities.Count >= 4)
                    {
                        Console.WriteLine("Ability Limit Reached");
                        return;
                    }

                    Console.Write("Enter NEW Ability Name OR 'Done': ");
                    string abilityName = Console.ReadLine();

                    if (abilityName.ToLower() == "done")
                    {
                        break;
                    }

                    int abilityLevel;
                    while (true)
                    {
                        Console.Write("Enter NEW Ability Level (0 - 5): ");
                        abilityLevel = int.Parse(Console.ReadLine());

                        if (abilityLevel >= 0 && abilityLevel <= 5)
                        {
                            break;
                        }
                        Console.WriteLine("Invalid Ability Level, Please Try Again");
                    }

                    character.abilities.Add(new Ability(abilityName, abilityLevel));
                    Console.WriteLine("NEW Ability Added");
                }
            }
            else if (action.ToLower() == "edit")
            {
                // Edit Ability
                Console.Write("Enter Ability Number: ");
                int index = int.Parse(Console.ReadLine()) - 1; // Zero-Based

                if (index >= 0 && index < character.abilities.Count)
                {
                    Console.Write("Enter NEW Ability Name: ");
                    string newAbilityName = Console.ReadLine();
                    character.abilities[index].abilityName = newAbilityName;
                    Console.WriteLine("Ability Name Updated");

                    int newAbilityLevel;
                    while (true)
                    {
                        Console.Write("Enter NEW Ability Level (0 - 5): ");
                        newAbilityLevel = int.Parse(Console.ReadLine());

                        if (newAbilityLevel >= 0 && newAbilityLevel <= 5)
                        {
                            character.abilities[index].abilityLevel = newAbilityLevel;
                            Console.WriteLine("Ability Level Updated");
                            break;
                        }
                        Console.WriteLine("Invalid Ability Level, Please Try Again");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Option, Please Try Again");
            }
        }

        private void DeleteCharacter()
        {
            Console.Write("Enter Name OF Character TO Delete: ");
            string name = Console.ReadLine();
            bool found = false;
            int index = -1;

            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].name.ToLower() == name.ToLower())
                {
                    found = true;
                    index = i;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Character NOT Found");
            }
            else
            {
                // Confirmation
                Console.WriteLine($"Character Found: {characters[index].name}");
                Console.WriteLine("Confirm Delete? 'Yes' OR 'No'");
                string confirmation = Console.ReadLine().ToLower();

                if (confirmation == "yes" || confirmation == "y")
                {
                    // Delete Character FROM List USING Index
                    Console.WriteLine($"Character {characters[index].name}, Level: {characters[index].level} IS Deleted");
                    characters.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Delete Character Canceled");
                }
            }
        }

        private void DisplayAllCharacters()
        {
            if (characters.Count == 0)
            {
                Console.WriteLine("NO Characters Found");
                return;
            }

            for (int i = 0; i < characters.Count; i++)
            {
                // Add Space Above Subsequent Characters FOR Readability
                if (i > 0) // Check IF IT'S NOT First Character
                {
                    Console.WriteLine(); // Space
                }

                // [Name] [Type] [Health] [Level]
                Character character = characters[i];
                Console.Write($"{character.name} "); // Name
                TypeColor(character.type); // Console Foreground Color(s)
                Console.Write($"[{character.type}] "); // Type
                Console.ResetColor(); // Reset Console Foreground Color(s)
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"[HP {character.health}] "); // Health
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[LV {character.level}]"); // Level
                Console.ResetColor();
                Console.WriteLine(); // NEW Line
                Console.WriteLine("Abilities"); // Abilities

                if (character.abilities.Count == 0)
                {
                    Console.WriteLine("   NO Abilities");
                }
                else
                {
                    for (int j = 0; j < character.abilities.Count; j++)
                    {
                        Ability ability = character.abilities[j];
                        Console.Write($"   {j + 1}. {ability.abilityName} "); // Ability
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"[LV {ability.abilityLevel}]"); // Level
                        Console.ResetColor();
                        Console.WriteLine(); // NEW Line
                    }
                }
            }
        }

        private void TypeColor(string type)
        {
            switch (type.ToLower())
            {
                case "fire":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "water":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "grass":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "normal":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }

        private void Battle()
        {
            if (characters.Count < 2)
            {
                Console.WriteLine("NOT Enough Characters TO Battle");
                return;
            }

            DisplayAllCharacters();

            // Player
            Console.WriteLine(); // Space
            Console.Write("Choose YOUR Character: ");
            string player = Console.ReadLine();
            int playerIndex = -1;

            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].name.ToLower() == player.ToLower())
                {
                    playerIndex = i;
                    break;
                }
            }

            if (playerIndex == -1)
            {
                Console.WriteLine("Character NOT Found");
                return;
            }

            // Random Opponent
            Random random = new Random();
            int opponentIndex = random.Next(characters.Count);

            // IF Opponent = Player, Select Next Character IN List
            if (opponentIndex == playerIndex)
            {
                opponentIndex = (opponentIndex + 1) % characters.Count;
            }

            // Announcement
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{characters[playerIndex].name} ");
            Console.ResetColor();
            TypeColor(characters[playerIndex].type); // Console Foreground Color(s)
            Console.Write($"[{characters[playerIndex].type}] "); // Type
            Console.ResetColor(); // Reset Console Foreground Color(s)
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"[HP {characters[playerIndex].health}]");
            Console.ResetColor();
            Console.Write(" VS ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"{characters[opponentIndex].name} ");
            Console.ResetColor();
            TypeColor(characters[opponentIndex].type); // Console Foreground Color(s)
            Console.Write($"[{characters[opponentIndex].type}] "); // Type
            Console.ResetColor(); // Reset Console Foreground Color(s)
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"[HP {characters[opponentIndex].health}]");
            Console.ResetColor();
            Console.WriteLine(); // Space

            // First Turn (Random)
            bool first = random.Next(2) == 0;
            if (first)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{characters[playerIndex].name}'s ");
                Console.ResetColor();
                Console.Write("First");
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{characters[opponentIndex].name}'s ");
                Console.ResetColor();
                Console.Write("First");
                Console.WriteLine();
            }

            // Battle Logic
            while (characters[playerIndex].health > 0 && characters[opponentIndex].health > 0)
            {
                if (first)
                {
                    // Player's Turn
                    Console.WriteLine("Abilities");
                    for (int i = 0; i < characters[playerIndex].abilities.Count; i++)
                    {
                        Console.Write($"   {i + 1}. {characters[playerIndex].abilities[i].abilityName} ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"[LV {characters[playerIndex].abilities[i].abilityLevel}]"); // Level
                        Console.ResetColor();
                        Console.WriteLine(); // NEW Line
                    }
                    Console.Write("Enter Option: ");
                    int option = int.Parse(Console.ReadLine()) - 1;
                    int damage = Damage(characters[playerIndex], characters[opponentIndex], characters[playerIndex].abilities[option]);

                    // Apply Damage TO Opponent's Health
                    characters[opponentIndex].health -= damage;

                    // Player's Move
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"{characters[playerIndex].name} ");
                    Console.ResetColor();
                    Console.Write($"Used {characters[playerIndex].abilities[option].abilityName} ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"[LV {characters[playerIndex].abilities[option].abilityLevel}] ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"[DMG {damage}]");
                    Console.ResetColor();
                    Console.WriteLine() ;
                    
                    // IF Opponent Faints
                    if (characters[opponentIndex].health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"{characters[opponentIndex].name} ");
                        Console.ResetColor();
                        Console.Write("Fainted!");
                        Console.WriteLine();
                        break;
                    }

                    first = false; // Switch Turn
                }
                else
                {
                    // Opponent's Turn
                    int abilityIndex = random.Next(characters[opponentIndex].abilities.Count);
                    int damage = Damage(characters[opponentIndex], characters[playerIndex], characters[opponentIndex].abilities[abilityIndex]);

                    // Apply Damage TO Player's Health
                    characters[playerIndex].health -= damage;

                    // Opponent's Move
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{characters[opponentIndex].name} ");
                    Console.ResetColor();
                    Console.Write($"Used {characters[opponentIndex].abilities[abilityIndex].abilityName} ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"[LV {characters[opponentIndex].abilities[abilityIndex].abilityLevel}] ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"[DMG {damage}]");
                    Console.ResetColor();
                    Console.WriteLine();

                    // IF Player Faints
                    if (characters[playerIndex].health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write($"{characters[playerIndex].name} ");
                        Console.ResetColor();
                        Console.Write("Fainted!");
                        Console.WriteLine();
                        break;
                    }

                    first = true; // Switch Turn
                }

                // Display Health AFTER Turn
                // Player
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{characters[playerIndex].name} ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"[HP {characters[playerIndex].health}]");
                Console.ResetColor();
                Console.WriteLine();
                // Opponent
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{characters[opponentIndex].name} ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"[HP {characters[opponentIndex].health}]");
                Console.ResetColor();
                Console.WriteLine();
            }

            // Winner
            if (characters[playerIndex].health > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{characters[playerIndex].name} ");
                Console.ResetColor();
                Console.Write("Wins!");
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{characters[opponentIndex].name} ");
                Console.ResetColor();
                Console.Write("Wins!");
                Console.WriteLine();
            }
        }    

        private int Damage(Character attack, Character defend, Ability ability)
        {
            // Base Damage
            int baseDamage = ability.abilityLevel * 10;

            // Base Miss Chance
            double miss = 10.0; // 10% Chance TO Miss

            // Type Effective
            double effective = 1.0;
            if (attack.type == "Fire" && defend.type == "Grass" ||
                attack.type == "Water" && defend.type == "Fire" ||
                attack.type == "Grass" && defend.type == "Water")
            {
                effective = 1.5; // Super Effective
                miss += 5; // 15% Chance TO Miss
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Super Effective!");
                Console.ResetColor();
            }
            else if (attack.type == "Grass" && defend.type == "Fire" ||
                     attack.type == "Fire" && defend.type == "Water" ||
                     attack.type == "Water" && defend.type == "Grass")
            {
                effective = 0.5; // NOT Effective
                miss -= 5; // 5% Chance TO Miss
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("NOT Effective!");
                Console.ResetColor();
            }

            // Calculate Miss Chance
            Random rnd = new Random();
            if (rnd.Next(100) < miss)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Missed!");
                Console.ResetColor();
                return 0; // N0 Damage IF Missed
            }


            int damage = (int)(baseDamage * effective);

            // Crit Chance (Normal Type ONLY)
            if (attack.type == "Normal")
            {
                Random random = new Random();
                bool crit = random.Next(100) < 20; // 20% Chance TO Crit
                if (crit)
                {
                    damage = (int)(damage * 1.5);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Critical Hit!");
                    Console.ResetColor();
                }
            }

            return damage;
        }
    }
}
