using System;

public static class Utility
{
   private static Random _random;
   
   public static int Probability()
   {
      int maxProbability = 100;
      return _random.Next(maxProbability);
   }
}
