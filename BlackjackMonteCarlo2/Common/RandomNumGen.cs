using System;

namespace BlackjackMonteCarlo2.Common
{
    public static class RandomNumGen
    {
        private static Random randomGlobal = new Random(); //Creates a random class which will be unanimous between threads
        [ThreadStatic]
        private static Random randomLocal; //Creates a random class which will be local to individual threads.

        private static Random GetRandom()
        {
            Random random = randomLocal;
            if (random == null) //If a random number hasn't yet been set for the currently running thread, create one by using the randomGlobal to create a seed.
            {
                int seed;
                lock (randomGlobal) seed = randomGlobal.Next(); //lock keyword means this can only be used by one thread at a time
                randomLocal = random = new Random(seed);
            }
            return random;
        }

        public static int Next()
        {
            return GetRandom().Next(); //Gets next random number
        }

        public static int Next(int min, int max)
        {
            return GetRandom().Next(min, max); //Gets next random number between ranges
        }

        public static int Next(int max)
        {
            return GetRandom().Next(max); //Gets next random number with max being the input maximum.
        }
    }
}
