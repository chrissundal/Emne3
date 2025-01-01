
using Interface;


var vehiclesList  = new List<Itransportation>()
{
    new Car("Ford","KH32351",Color.Red),
    new Boat("Skarpnes","KJD124",Color.Blue),
    new Plane("Cessna","N-54124",Color.Green),

};
foreach (var vehicle in vehiclesList)
{
    vehicle.Show();
}