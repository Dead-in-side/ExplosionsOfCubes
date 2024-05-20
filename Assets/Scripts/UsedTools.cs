using System;

public class UsedTools
{
    private static Random s_random = new Random();

    public static int GetRandomNumber(int min, int max) => s_random.Next(min, max);
}
