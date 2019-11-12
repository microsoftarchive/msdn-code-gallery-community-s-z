//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: DataLoader.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace BabyNames
{
    /// <summary>Represents the number of babies with a given name board in a given state in a given year.</summary>
    internal class BabyInfo
    {
        public string Name { get; set; }
        public string State { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
    }

    /// <summary>
    /// Loads data.  In order to limit distribution size, "loading" entails randomly generating.
    /// </summary>
    internal class DataLoader
    {
        /// <summary>Generates a data set with numRecords baby infos, between the specified years.</summary>
        /// <param name="numRecords">The number of records to generate.</param>
        /// <param name="minYear">The starting year.</param>
        /// <param name="maxYear">The ending year.</param>
        /// <returns>The generated list of babies.</returns>
        public static List<BabyInfo> GenerateRandom(int numRecords, int minYear, int maxYear)
        {
            Random rand = new Random();

            // Enumerate all possible combinations of year, state, name, in a random-ish order
            var allCombinations = from year in Enumerable.Range(minYear, maxYear - minYear + 1)
                                  from state in _stateIdentifiers
                                  from name in _commonPeopleNames
                                  orderby rand.Next()
                                  select new BabyInfo { Name = name, State = state, Year = year, Count = rand.Next(200, 1000) };

            // Return a subset of size numRecords as a list
            return allCombinations.Take(numRecords).ToList();
        }

        /// <summary>An array of state identifiers (plus Washington, DC).</summary>
        private static string[] _stateIdentifiers =
        {            
            "AK", "AL", "AR", "AZ", "CA", "CO", "CT", 
            "DC", "DE", "FL", "GA", "HI", "IA", "ID", 
            "IL", "IN", "KS", "KY", "LA", "MA", "MD", 
            "ME", "MI", "MN", "MO", "MS", "MT", "NC", 
            "ND", "NE", "NH", "NJ", "NM", "NV", "NY", 
            "OH", "OK", "OR", "PA", "RI", "SC", "SD", 
            "TN", "TX", "UT", "VA", "VT", "WA", "WI", 
            "WV", "WY"
        };

        /// <summary>An array of common names given to babies.</summary>
        private static string[] _commonPeopleNames = 
        {            
            "Aaliyah", "Aaron", "Abbey", "Abbie", "Abby", "Abigail", "Abigale", 
            "Abigayle", "Abraham", "Adam", "Addison", "Aden", "Adrian", "Adriana", 
            "Adrianna", "Adrienne", "Agnes", "Aidan", "Aiden", "Aimee", "Aisha", 
            "Alaina", "Alan", "Alana", "Albert", "Alberto", "Alec", "Alejandra", 
            "Alejandro", "Alex", "Alexa", "Alexande", "Alexander", "Alexandr", "Alexandra", 
            "Alexandria", "Alexia", "Alexis", "Alexus", "Alfred", "Ali", "Alice", 
            "Alicia", "Alika", "Alisha", "Alison", "Alissa", "Alivia", "Aliyah", 
            "Allan", "Allen", "Allie", "Allison", "Allyson", "Alondra", "Alvin", 
            "Alyson", "Alyssa", "Amanda", "Amari", "Amaya", "Amber", "Amelia", 
            "Amie", "Amir", "Amy", "Amya", "Ana", "Anahi", "Anastasia", 
            "Andre", "Andrea", "Andres", "Andrew", "Andy", "Anela", "Angel", 
            "Angela", "Angelia", "Angelica", "Angelina", "Angelique", "Angelo", "Angie", 
            "Anita", "Aniya", "Aniyah", "Ann", "Anna", "Annabelle", "Anne", 
            "Annette", "Annie", "Annika", "Annmarie", "Ansley", "Anthony", "Antoine", 
            "Antoinette", "Antonio", "Antwan", "April", "Ariana", "Arianna", "Ariel", 
            "Arielle", "Arlene", "Armando", "Arnold", "Aron", "Arthur", "Arturo", 
            "Ashanti", "Ashlee", "Ashleigh", "Ashley", "Ashlyn", "Ashlynn", "Ashton", 
            "Asia", "Aspen", "Aubrey", "Audra", "Audrey", "Aurora", "Austin", 
            "Autumn", "Ava", "Avery", "Ayanna", "Ayden", "Ayla", "Baby", 
            "Babyboy", "Babygirl", "Bailee", "Bailey", "Barbara", "Barry", "Bart", 
            "Baylee", "Beau", "Becky", "Belinda", "Benjamin", "Bernadette", "Bernard", 
            "Bertha", "Beth", "Bethany", "Betsy", "Betty", "Beverly", "Bianca", 
            "Bill", "Billie", "Billy", "Blaine", "Blake", "Blaze", "Bob", 
            "Bobbi", "Bobbie", "Bobby", "Bonnie", "Boston", "Boyd", "Brad", 
            "Braden", "Bradford", "Bradley", "Brady", "Branden", "Brandi", "Brandie", 
            "Brandon", "Brandy", "Braxton", "Brayden", "Breanna", "Breanne", "Brenda", 
            "Brendan", "Brenden", "Brendon", "Brenna", "Brennan", "Brent", "Brenton", 
            "Bret", "Brett", "Bria", "Brian", "Briana", "Brianna", "Brianne", 
            "Bridger", "Bridget", "Brinley", "Britney", "Brittany", "Brittney", "Brock", 
            "Brodie", "Brody", "Bronson", "Brooke", "Brooklyn", "Brooklynn", "Bruce", 
            "Bryan", "Bryanna", "Bryant", "Bryce", "Brynlee", "Brynn", "Bryon", 
            "Bryson", "Byron", "Cade", "Caden", "Cadence", "Cael", "Caitlin", 
            "Caitlyn", "Caleb", "Callie", "Calvin", "Camden", "Cameron", "Cami", 
            "Camila", "Camille", "Camryn", "Candace", "Candice", "Cara", "Carissa", 
            "Carl", "Carla", "Carlos", "Carlton", "Carly", "Carmen", "Carol", 
            "Carole", "Caroline", "Carolyn", "Carrie", "Carson", "Carter", "Casey", 
            "Cassandra", "Cassidy", "Cassie", "Catherine", "Cathy", "Catina", "Cayden", 
            "Cecilia", "Cedric", "Celeste", "Cesar", "Chad", "Chance", "Chandler", 
            "Chanel", "Chantel", "Chantelle", "Charity", "Charlene", "Charles", "Charlie", 
            "Charlotte", "Charmaine", "Chase", "Chasity", "Chaya", "Chelsea", "Chelsey", 
            "Chelsie", "Cheri", "Cherie", "Cheryl", "Cheyanne", "Cheyenne", "Chiquita", 
            "Chloe", "Chris", "Christa", "Christi", "Christian", "Christie", "Christin", 
            "Christina", "Christine", "Christopher", "Christy", "Chuck", "Ciara", "Cierra", 
            "Cindy", "Claire", "Clara", "Clarence", "Clarissa", "Clark", "Claudia", 
            "Clay", "Clayton", "Clifford", "Clifton", "Clint", "Clinton", "Clyde", 
            "Cody", "Colby", "Cole", "Colin", "Colleen", "Collin", "Colten", 
            "Colter", "Colton", "Conner", "Connie", "Connor", "Conor", "Constance", 
            "Cooper", "Cora", "Corbin", "Corey", "Corinne", "Cornelius", "Cortney", 
            "Cory", "Coty", "Courtney", "Craig", "Cristian", "Cristina", "Crystal", 
            "Curt", "Curtis", "Cynthia", "Cyrus", "Daisy", "Dakota", "Dale", 
            "Dallas", "Dallin", "Dalton", "Damari", "Damian", "Damien", "Damon", 
            "Dan", "Dana", "Dane", "Dangelo", "Daniel", "Daniela", "Danielle", 
            "Danny", "Dante", "Daquan", "Darcy", "Daren", "Darian", "Darin", 
            "Darius", "Darla", "Darlene", "Darnell", "Darrell", "Darren", "Darrin", 
            "Darryl", "Darwin", "Daryl", "Dave", "David", "Davon", "Dawn", 
            "Dawson", "Dayna", "Dean", "Deandre", "Deangelo", "Deann", "Deanna", 
            "Debbie", "Debora", "Deborah", "Debra", "Declan", "Deja", "Delaney", 
            "Delonte", "Demarcus", "Demetrius", "Denali", "Deneen", "Denis", "Denise", 
            "Dennis", "Denzel", "Derek", "Derrick", "Desiree", "Desmond", "Destinee", 
            "Destiny", "Devante", "Devin", "Devon", "Devonte", "Dexter", "Diamond", 
            "Diana", "Diane", "Dianna", "Dianne", "Diego", "Dillon", "Dina", 
            "Dionne", "Dixie", "Dolores", "Domenic", "Dominic", "Dominick", "Dominique", 
            "Don", "Donald", "Donna", "Donnell", "Donnie", "Donovan", "Donte", 
            "Dora", "Doreen", "Doris", "Dorothy", "Doug", "Douglas", "Drake", 
            "Drew", "Duane", "Duke", "Dustin", "Dusty", "Dwayne", "Dwight", 
            "Dylan", "Earl", "Earnest", "Easton", "Ebony", "Ed", "Eddie", "Eden", 
            "Edgar", "Edmund", "Edna", "Eduardo", "Edward", "Edwin", "Eileen", 
            "Elaine", "Eleanor", "Elena", "Eli", "Elias", "Elijah", "Elise", 
            "Eliza", "Elizabet", "Elizabeth", "Ella", "Ellen", "Ellie", "Elton", 
            "Emilee", "Emilio", "Emily", "Emma", "Emmanuel", "Enrique", "Eric", 
            "Erica", "Erick", "Erik", "Erika", "Erin", "Ernest", "Esmeralda", 
            "Esperanza", "Estevan", "Esther", "Estrella", "Ethan", "Eugene", "Eva", 
            "Evan", "Evelyn", "Everett", "Ezekiel", "Ezra", "Fabian", "Faith", 
            "Farrah", "Felicia", "Female", "Fernando", "Finn", "Fiona", "Floyd", 
            "Forrest", "Frances", "Francesca", "Francine", "Francis", "Francisco", "Frank", 
            "Franklin", "Fred", "Freddie", "Frederick", "Fredrick", "Gabriel", "Gabriela", 
            "Gabriella", "Gabrielle", "Gage", "Gail", "Garrett", "Gary", "Gavin", 
            "Gayla", "Gayle", "Gene", "Genesis", "Geoffrey", "George", "Gerald", 
            "Geraldine", "Gerard", "Gerardo", "Gianna", "Gilbert", "Gillian", "Gina", 
            "Ginger", "Giovanni", "Giselle", "Glen", "Glenda", "Glenn", "Gloria", 
            "Gordon", "Grace", "Gracie", "Graham", "Grant", "Grayson", "Greg", 
            "Gregg", "Gregory", "Greta", "Gretchen", "Griffin", "Guadalupe", "Guy", 
            "Gwen", "Gwendolyn", "Hailee", "Hailey", "Haleigh", "Haley", "Halle", 
            "Hallie", "Hanna", "Hannah", "Harley", "Harmony", "Harold", "Harrison", 
            "Harry", "Hayden", "Haylee", "Hayley", "Heath", "Heather", "Heaven", 
            "Hector", "Heidi", "Helen", "Henry", "Herbert", "Hilary", "Hillary", 
            "Holly", "Hope", "Howard", "Hudson", "Hunter", "Ian", "Iesha", "Igor",
            "Ikaika", "Imani", "India", "Infant", "Ira", "Irene", "Iris", 
            "Irma", "Isaac", "Isabel", "Isabella", "Isabelle", "Isaiah", "Isiah", 
            "Israel", "Ivan", "Ivy", "Jace", "Jack", "Jackie", "Jackson", 
            "Jaclyn", "Jacob", "Jacqueline", "Jada", "Jade", "Jaden", "Jadyn", 
            "Jaheim", "Jaime", "Jakayla", "Jake", "Jakob", "Jalen", "Jamaal", 
            "Jamal", "Jamar", "Jamarion", "James", "Jami", "Jamia", "Jamie", 
            "Jan", "Jana", "Janae", "Janay", "Jane", "Janelle", "Janet", 
            "Janice", "Janiya", "Jaquan", "Jaqueline", "Jared", "Jarrod", "Jarvis", 
            "Jasmin", "Jasmine", "Jason", "Javier", "Javon", "Jaxon", "Jay", 
            "Jayden", "Jayla", "Jaylen", "Jaylon", "Jayme", "Jayson", "Jazmin", 
            "Jazmine", "Jean", "Jeanette", "Jeanne", "Jeannine", "Jeff", "Jeffery", 
            "Jeffrey", "Jenifer", "Jenna", "Jennie", "Jennifer", "Jenny", "Jeremiah", 
            "Jeremy", "Jermaine", "Jerome", "Jerry", "Jess", "Jesse", "Jessica", 
            "Jessie", "Jesus", "Jill", "Jillian", "Jim", "Jimmie", "Jimmy", 
            "Jo", "Joan", "Joann", "Joanna", "Joanne", "Jocelyn", "Jodi", 
            "Jodie", "Jody", "Joe", "Joel", "Joey", "Johanna", "John", 
            "Johnathan", "Johnathon", "Johnnie", "Johnny", "Jolene", "Jon", "Jonah", 
            "Jonathan", "Jonathon", "Joni", "Jordan", "Jordyn", "Jorge", "Jory", 
            "Jose", "Joseph", "Josephine", "Josette", "Joshua", "Josiah", "Josie", 
            "Joy", "Joyce", "Juan", "Juanita", "Judith", "Judy", "Julia", 
            "Julian", "Juliana", "Julianna", "Julie", "Julio", "Julissa", "Julius", 
            "June", "Justice", "Justin", "Justine", "Juwan", "Kade", "Kaden", 
            "Kadence", "Kadijah", "Kahealani", "Kai", "Kaila", "Kailee", "Kailey", 
            "Kaimana", "Kainalu", "Kainoa", "Kaitlin", "Kaitlyn", "Kalani", "Kaleb", 
            "Kalena", "Kamalani", "Kameron", "Kamryn", "Kanani", "Kapena", "Kara", 
            "Karen", "Kari", "Karin", "Karina", "Karissa", "Karl", "Karla", 
            "Karlee", "Kasey", "Kassandra", "Kassidy", "Kate", "Katelyn", "Katelynn", 
            "Katharine", "Katherin", "Katherine", "Kathleen", "Kathryn", "Kathy", "Katie", 
            "Katina", "Katlyn", "Katrina", "Kawena", "Kawika", "Kay", "Kaya", 
            "Kaycee", "Kayden", "Kaydence", "Kayla", "Kaylee", "Kayleigh", "Keanu", 
            "Keaton", "Keegan", "Keenan", "Kehaulani", "Keira", "Keisha", "Keith", 
            "Kekoa", "Kelley", "Kelli", "Kellie", "Kelly", "Kelsey", "Kelsie", 
            "Kelvin", "Ken", "Kendall", "Kendra", "Kendrick", "Kennedy", "Kenneth", 
            "Kenny", "Kent", "Kenya", "Keola", "Keoni", "Keri", "Kerri", 
            "Kerry", "Kevin", "Kevon", "Khadijah", "Khalil", "Kia", "Kiana", 
            "Kiani", "Kiara", "Kierra", "Kim", "Kimberlee", "Kimberley", "Kimberly", 
            "Kira", "Kirk", "Kirsten", "Kisha", "Kizzy", "Kobe", "Kody", 
            "Kory", "Kris", "Krista", "Kristen", "Kristi", "Kristie", "Kristin", 
            "Kristina", "Kristine", "Kristopher", "Kristy", "Krystal", "Krystle", "Kurt", 
            "Kyla", "Kyle", "Kylee", "Kyleigh", "Kyler", "Kylie", "Kyra", 
            "Lacey", "Laci", "Lacy", "Ladarius", "Ladonna", "Laila", "Lakeisha", 
            "Lakesha", "Lakisha", "Lamar", "Lamont", "Lana", "Lance", "Landen", 
            "Landon", "Lane", "Lani", "Larry", "Lashawn", "Lashonda", "Latasha", 
            "Latisha", "Latonya", "Latoya", "Laura", "Laurel", "Lauren", "Laurie", 
            "Lauryn", "Lawanda", "Lawrence", "Layla", "Leah", "Leann", "Lee", 
            "Leigh", "Leila", "Leilani", "Lena", "Leo", "Leon", "Leona", 
            "Leonard", "Leonardo", "Leroy", "Lesley", "Leslie", "Leticia", "Levi", 
            "Lewis", "Lexi", "Liam", "Liana", "Liliana", "Lillian", "Lillie", 
            "Lilly", "Lily", "Linda", "Lindsay", "Lindsey", "Lisa", "Liza", 
            "Lizbeth", "Lloyd", "Logan", "Lois", "London", "Lonnie", "Lora", 
            "Loren", "Lorena", "Lorenzo", "Loretta", "Lori", "Loriann", "Lorna", 
            "Lorraine", "Lorrie", "Louis", "Louise", "Lucas", "Lucia", "Lucy", 
            "Luis", "Luke", "Lydia", "Lyle", "Lynda", "Lynette", "Lynn", 
            "Lynne", "Mackenzie", "Macy", "Maddison", "Madeleine", "Madeline", "Madelyn", 
            "Madison", "Madisyn", "Maeve", "Maggie", "Mahealani", "Mahina", "Maia", 
            "Maile", "Makana", "Makayla", "Makenna", "Makenzie", "Makoa", "Malachi", 
            "Malcolm", "Male", "Malia", "Malik", "Mallory", "Mandi", "Mandy", 
            "Manuel", "Marc", "Marcel", "Marcella", "Marci", "Marcia", "Marco", 
            "Marcos", "Marcus", "Marcy", "Margaret", "Mari", "Maria", "Mariah", 
            "Mariana", "Marianne", "Maribel", "Marie", "Marilyn", "Marina", "Mario", 
            "Marion", "Marisa", "Marisol", "Marissa", "Mark", "Marlene", "Marlon", 
            "Marquis", "Marquise", "Marquita", "Marsha", "Marshall", "Martha", "Martin", 
            "Marty", "Marvin", "Mary", "Maryann", "Mason", "Mathew", "Matt", 
            "Matthew", "Maureen", "Maurice", "Max", "Maxwell", "Maya", "Mayra", 
            "Mckay", "Mckayla", "Mckenna", "Mckenzie", "Meagan", "Meaghan", "Megan", 
            "Meghan", "Mekhi", "Melanie", "Melia", "Melinda", "Melissa", "Melody", 
            "Melvin", "Mercedes", "Meredith", "Mia", "Micah", "Michael", "Michaela", 
            "Micheal", "Michele", "Michelle", "Miguel", "Mikaela", "Mikayla", "Mike", 
            "Miles", "Milton", "Mindy", "Miracle", "Miranda", "Misti", "Misty", 
            "Mitchell", "Molly", "Monica", "Monique", "Monte", "Morgan", "Moshe", 
            "Mya", "Myles", "Myra", "Myron", "Nadia", "Nadine", "Nainoa", 
            "Nakia", "Nalani", "Nancy", "Nanea", "Naomi", "Nasir", "Natalia", 
            "Natalie", "Natasha", "Nathan", "Nathaniel", "Nayeli", "Neal", "Neil", 
            "Nelson", "Nevaeh", "Nia", "Nicholas", "Nichole", "Nick", "Nickolas", 
            "Nicolas", "Nicole", "Nikita", "Nikki", "Nina", "Noa", "Noah", 
            "Nolan", "Nora", "Norma", "Norman", "Normand", "Notnamed", "Nyasia", 
            "Oliver", "Olivia", "Omar", "Omarion", "Orlando", "Oscar", "Owen", 
            "Paige", "Pam", "Pamela", "Paris", "Parker", "Pat", "Patrice", 
            "Patricia", "Patrick", "Patti", "Patty", "Paul", "Paula", "Pauline", 
            "Payton", "Pedro", "Peggy", "Penny", "Perry", "Peter", "Peyton", 
            "Philip", "Phillip", "Phoebe", "Phyllis", "Piper", "Pooja", "Porter", "Precious", 
            "Preston", "Priscilla", "Quentin", "Quinn", "Quinton", "Rachael", "Rachel", 
            "Rachelle", "Raekwon", "Rafael", "Raheem", "Ralph", "Ramon", "Ramona", 
            "Randal", "Randall", "Randi", "Randy", "Raquel", "Rashad", "Raul", 
            "Raven", "Ray", "Raymond", "Reagan", "Rebecca", "Rebekah", "Reed", 
            "Reese", "Regina", "Reginald", "Reid", "Renae", "Renata", "Rene", 
            "Renee", "Rex", "Rhonda", "Ricardo", "Richard", "Rick", "Rickey", 
            "Ricky", "Riley", "Rita", "Robert", "Roberta", "Roberto", "Robin", 
            "Robyn", "Rochelle", "Roderick", "Rodney", "Roger", "Roland", "Ron", 
            "Ronald", "Ronda", "Ronnie", "Roosevelt", "Rory", "Rosa", "Rose", 
            "Rosemary", "Rosie", "Ross", "Rowena", "Roxanne", "Roy", "Royce", 
            "Ruben", "Ruby", "Rudy", "Russell", "Ruth", "Ryan", "Ryder", 
            "Ryker", "Rylan", "Rylee", "Rylie", "Sabrina", "Sade", "Sadie", 
            "Sage", "Sally", "Salvador", "Salvatore", "Sam", "Samantha", "Sammy", 
            "Samuel", "Sandra", "Sandy", "Saniya", "Santana", "Santiago", "Sara", 
            "Sarah", "Sasha", "Savanna", "Savannah", "Sawyer", "Scott", "Scottie", 
            "Scotty", "Sean", "Sebastian", "Selena", "Serena", "Serenity", "Sergio", 
            "Seth", "Shana", "Shane", "Shania", "Shanice", "Shaniqua", "Shanna", 
            "Shannon", "Shantel", "Shaquille", "Shari", "Sharon", "Shaun", "Shauna", 
            "Shawn", "Shawna", "Shayden", "Shayla", "Shaylee", "Shayna", "Sheena", 
            "Sheila", "Shelbi", "Shelby", "Sheldon", "Shelia", "Shelley", "Shelly", 
            "Sheri", "Sherri", "Sherrie", "Sherry", "Sheryl", "Shirley", "Shyla", 
            "Sidney", "Sienna", "Sierra", "Silas", "Simone", "Skylar", "Skyler", 
            "Sofia", "Sonia", "Sonja", "Sonya", "Sophia", "Sophie", "Spencer", 
            "Stacey", "Staci", "Stacie", "Stacy", "Stanley", "Stefanie", "Stella", 
            "Stephani", "Stephanie", "Stephen", "Stephon", "Steve", "Steven", "Stuart", 
            "Sue", "Summer", "Susan", "Suzanne", "Sydney", "Sylvia", "Tabitha", 
            "Talia", "Tamara", "Tameka", "Tami", "Tamia", "Tamika", "Tammie", 
            "Tammy", "Tania", "Tanner", "Tanya", "Tara", "Taryn", "Tasha", 
            "Tate", "Tatiana", "Tatum", "Tatyana", "Tavon", "Tayla", "Taylor", 
            "Teagan", "Ted", "Teddy", "Tehani", "Teresa", "Teri", "Terrance", 
            "Terrell", "Terrence", "Terri", "Terry", "Tessa", "Tevin", "Thad", 
            "Theodore", "Theresa", "Thomas", "Tia", "Tiana", "Tiara", "Tiare", 
            "Tierra", "Tiffany", "Tim", "Timmy", "Timothy", "Tina", "Toby", 
            "Todd", "Tom", "Tommie", "Tommy", "Toni", "Tonia", "Tony", 
            "Tonya", "Tori", "Tracey", "Traci", "Tracie", "Tracy", "Travis", 
            "Trent", "Trenton", "Trevon", "Trevor", "Trey", "Tricia", "Trina", 
            "Trinity", "Trisha", "Trista", "Tristan", "Tristen", "Troy", "Tucker", 
            "Ty", "Tyler", "Tyra", "Tyree", "Tyrel", "Tyrell", "Tyrese", 
            "Tyrone", "Tyson", "Unknown", "Unnamed", "Valeria", "Valerie", "Vanessa", 
            "Vera", "Vernon", "Veronica", "Vicki", "Vickie", "Vicky", "Victor", 
            "Victoria", "Vincent", "Virginia", "Vivian", "Wade", "Walker", "Walter", 
            "Wanda", "Warren", "Wassillie", "Wayne", "Wendell", "Wendy", "Wesley", 
            "Weston", "Whitney", "Willa", "William", "Willie", "Willow", "Wyatt", 
            "Xander", "Xavier", "Yesenia", "Yolanda", "Yvette", "Yvonne", "Zachariah", 
            "Zachary", "Zachery", "Zackary", "Zander", "Zane", "Zion", "Zoe", "Zoey"
        };
    }
}