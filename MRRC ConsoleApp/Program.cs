using System;
using System.Collections.Generic;
using System.Linq;
using MRRCManagement;
using System.Text;
using System.Threading.Tasks;

namespace MRRC_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle myVehicle = new Vehicle("KDA571", Vehicle.VehicleClass.Family, "Mazda", "3", 1990);

           // myVehicle.GetAttributeList();

            Customer Paolo = new Customer(0, "Mr", "Paolo", "Jaldon", Customer.Gender.male, "01/04/1999");

            //Console.WriteLine(BughattiVehicle.TOCSVString());
            //Console.WriteLine(BughattiVehicle.ToString());
            //Console.WriteLine(Paolo.ToCSVString());
            // Console.WriteLine(Paolo.ToString());

            Fleet myFleet = new Fleet();
            CRM myCustomers = new CRM();
            Console.WriteLine(myCustomers.AddCustomer(Paolo));
           
            Customer Luigi = new Customer(1, "Mr", "Luigi", "Jaldon", Customer.Gender.male, "01/04/1999");

            Console.WriteLine(myCustomers.AddCustomer(Luigi));
            Console.WriteLine(myFleet.AddVehicle(myVehicle));

            Vehicle BughattiVehicle = new Vehicle("123HCB", Vehicle.VehicleClass.Luxury, "Bughatti", "Veyron",
                                                    2017, 2, Vehicle.TransmissionType.Automatic, Vehicle.FuelType.Diesel,
                                                    true, true, 20000, "red"); 
           //Console.WriteLine(myFleet.AddVehicle(BughattiVehicle));
             myFleet.AddVehicle(BughattiVehicle);

            //BughattiVehicle.GetAttributeList();
            // Console.WriteLine(myFleet.GetFleet()); 

             Vehicle AstonMartinVehicle = new Vehicle("JBL121", Vehicle.VehicleClass.Commercial, "Aston Martin", "DB9",
                                                    2017, 2, Vehicle.TransmissionType.Automatic, Vehicle.FuelType.Diesel,
                                                    true, false, 8000, "grey"); 
            //Console.WriteLine(myFleet.AddVehicle(AstonMartinVehicle));
            //Console.WriteLine(myFleet.RemoveVehicle(AstonMartinVehicle));
            //myFleet.ListReturn();
            //myCustomers.ListReturn();
            //myCustomers.RemoveCustomer(Paolo, myFleet);
            myFleet.AddVehicle(AstonMartinVehicle);

             Vehicle LamborghiniVehicle = new Vehicle("100MIL", Vehicle.VehicleClass.Luxury, "Lamborgini", "Aventador",
                                                    2017, 2, Vehicle.TransmissionType.Manual, Vehicle.FuelType.Diesel,
                                                    true, true, 15000, "orange"); 

            myFleet.AddVehicle(LamborghiniVehicle);
           //Console.WriteLine(myFleet.RemoveVehicle("JBL121"));
           // Console.WriteLine(myFleet.RentCar("KDA571", 1));
           //Console.WriteLine(myFleet.IsRenting(1));
           //Console.WriteLine(myFleet.RentCar("123HCB", 0));
           //Console.WriteLine(myFleet.IsRenting(1));
           //Console.WriteLine(myFleet.RentedBy("KDA571"));
           //Console.WriteLine(myFleet.RentedBy("123HCB"));
           //Console.WriteLine(myFleet.IsRented("KDA571"));
           //Console.WriteLine();
           //myCustomers.ListReturn();

            //Console.WriteLine();
            Customer LeBron = new Customer(2, "Mr", "LeBron", "James", Customer.Gender.male, "01/01/2016");
            myCustomers.AddCustomer(LeBron);
            //myCustomers.ListReturn();
            //Console.WriteLine();
            //myCustomers.RemoveCustomer(1, myFleet);
            //myCustomers.ListReturn();
            //Console.WriteLine(myCustomers.RemoveCustomer(1, myFleet));
            //myFleet.GetFleet(false);
            //Console.WriteLine();
            //Console.WriteLine(myFleet.RemoveVehicle("JBL121"));
            //Console.WriteLine(myFleet.GetFleet());
            //Console.WriteLine("ssssssss");
            //myFleet.GetFleet(false);

            //Console.WriteLine(myFleet.RemoveVehicle("KDA571"));
            //Console.WriteLine(myFleet.ReturnCar("KDA571"));
            myFleet.ListReturn();
            //myCustomers.ListReturn();

            //string fleetFile = @"C:\Users\pjald\Documents\C# solutions\Data\fleet.csv";
            //string rentalFile = @"C:\Users\pjald\Documents\C# solutions\Data\rentals.csv";
            //string crmFile = @"C:\Users\pjald\Documents\C# solutions\Data\customer.csv";

            myFleet.SaveToFile();
            myCustomers.SaveToFile();
            //myFleet.LoadFromFile();

            //BughattiVehicle.GetAttributeList();
            //Console.WriteLine();
            //myVehicle.GetAttributeList();





            Console.ReadLine();
            
        }
    }
}
