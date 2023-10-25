namespace BilleteraVirtualSofttekBack.Helpers
{

    /// <summary>
    /// A statis class that creates Aliases for the new accounts.
    /// </summary>
    public static class AliasCreatorHelper
    {
        /// <summary>
        /// A method that creates aliases from a string array.
        /// </summary>
        /// <returns>Returns a three word compounded alias.</returns>
        public static string CreateAlias()
        {
            Random rng = new Random();

            string[] aliasWords =
            {
                "apple", "banana", "chocolate", "dinosaur", "elephant",
                "flower", "guitar", "happiness", "island", "jazz",
                "kangaroo", "lemon", "mountain", "ninja", "ocean",
                "penguin", "quokka", "rainbow", "sunshine", "tiger",
                "umbrella", "volcano", "waterfall", "xylophone", "zebra",
                "airplane", "butterfly", "carousel", "dolphin", "eagle",
                "forest", "giraffe", "harmony", "iguana", "jungle",
                "koala", "lighthouse", "moonlight", "nightingale", "octopus",
                "paradise", "quasar", "raccoon", "starry", "telescope",
                "unicorn", "violet", "watermelon", "x-ray", "yacht",
                "zeppelin", "acoustic", "blueberry", "caterpillar", "dragon",
                "firefly", "goldfish", "hurricane", "independence", "jigsaw",
                "kaleidoscope", "lumberjack", "marvelous", "nightmare", "opulent",
                "pandemonium", "quicksilver", "rhapsody", "silhouette", "tambourine",
                "umbrella", "veranda", "wanderlust", "xenophobia", "yellowstone",
                "zephyr", "alabaster", "boulevard", "candelabra", "dandelion",
                "eucalyptus", "flamenco", "gazelle", "honeysuckle", "incandescent",
                "jackal", "kaleidoscope", "limousine", "magnolia", "nightshade",
                "octopus", "peppermint", "quicksilver", "radiance", "sunflower",
                "tangerine", "umbrella", "velvet", "watermelon", "xylophone",
                "yacht", "zeppelin"
            };

            string completeAlias = "";

            for(int i = 0; i < 3; i++)
            {

                string word = aliasWords[rng.Next(0, aliasWords.Length - 1)];

                if(i == 3)
                {
                    completeAlias = completeAlias + word;
                }
                else
                {
                    completeAlias = completeAlias + word + ".";

                }


            }

            return completeAlias;

        }

       


       


    }
}
