using System;

public class StartUp
{
    public static void Main()
    {
        Spy spy = new Spy();
        string result = spy.CollectGettersAndSetter("Hacker");
        Console.WriteLine(result);
    }

}