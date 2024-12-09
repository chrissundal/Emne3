using Debugging;

var stats = new Stats();
while (true)
{
    Console.WriteLine("Skriv tall: ");
    var number = Convert.ToInt32(Console.ReadLine());
    stats.Add(number);
    Console.WriteLine(stats.GetDescription());
}
