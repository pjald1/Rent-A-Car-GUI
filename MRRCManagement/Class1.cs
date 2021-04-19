using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MRRCManagement
{
    public class Vehicle
    {
        //Author: Paolo Jaldon

        private string _vehicleRego;
        private string _make;
        private string _model;
        private int _year;
        public enum VehicleClass { Economy, Family, Luxury, Commercial }
        private int _numSeats;
        public enum TransmissionType { Automatic, Manual, Hybrid }
        public enum FuelType { Petrol, Diesel }
        private bool _GPS;
        private bool _sunRoof;
        private double _dailyRate;
        private string _colour;
        private TransmissionType _transmissionType;
        private VehicleClass _vehicleClass;
        private FuelType _fuelType;
        public static string vehicleRegoPub;
        public static List<string> _vehicleRegos = new List<string>();
        public static Dictionary<Vehicle, string> _vehicleAndRegoDict = new Dictionary<Vehicle, string>();

        public bool _GPSat;
        public bool _sunRoofat;

        public string _VehicleRego { get; set; }
        public VehicleClass _VehicleClass { get; set; }
        public string _Make { get; set; }
        public string _Model { get; set; }
        public int _Year { get; set; }
        public int _NumSeats { get; set; }
        public TransmissionType _Transmissiontype { get; set; }
        public FuelType _FuelType { get; set; }
        public bool _gps { get; set; }
        public bool _SunRoof { get; set; }
        public double _DailyRate { get; set; }
        public string _Colour { get; set; }


        public Vehicle(string vehicleRego, VehicleClass vehicleClass, string make,
                       string model, int year, int numSeats, TransmissionType transmissionType,
                       FuelType fuelType, bool GPS, bool sunRoof, double dailyRate, string colour)
        {
            //private variables
            _vehicleRego = vehicleRego;
            _vehicleClass = vehicleClass;
            _make = make;
            _model = model;
            _year = year;
            _numSeats = numSeats;
            _transmissionType = transmissionType;
            _fuelType = fuelType;
            _GPS = GPS;
            _sunRoof = sunRoof;
            _dailyRate = dailyRate;
            _colour = colour;
            vehicleRegoPub = vehicleRego;
            _GPSat = GPS;
            _sunRoofat = sunRoof;

            //getters/setters
            _VehicleRego = vehicleRego;
            _VehicleClass = vehicleClass;
            _Make = make;
            _Model = model;
            _Year = year;
            _NumSeats = numSeats;
            _Transmissiontype = transmissionType;
            _FuelType = fuelType;
            _gps = GPS;
            _SunRoof = sunRoof;
            _DailyRate = dailyRate;
            _Colour = colour;
        }

        public Vehicle(string vehicleRego, VehicleClass vehicleClass, string make, string model,
                       int year)
        {
            _vehicleRego = vehicleRego;
            _make = make;
            _model = model;
            _year = year;
            _numSeats = 4;
            _vehicleClass = vehicleClass;
            _transmissionType = TransmissionType.Automatic;
            _fuelType = FuelType.Petrol;
            _GPS = false;
            _sunRoof = false;
            _colour = "black";
            if (vehicleClass == VehicleClass.Economy)
            {
                _transmissionType = TransmissionType.Automatic;
            }

            _dailyRate = 50;

            if (vehicleClass == VehicleClass.Family)
            {
                _transmissionType = TransmissionType.Automatic | TransmissionType.Manual;

                _dailyRate = 80;
            }

            if (vehicleClass == VehicleClass.Luxury)
            {
                _GPS = true;
                _sunRoof = true;
                _dailyRate = 120;
            }

            if (vehicleClass == VehicleClass.Commercial)
            {
                _fuelType = FuelType.Diesel;
                _dailyRate = 130;
            }

            vehicleRegoPub = vehicleRego;
            _GPSat = _GPS;
            _sunRoofat = _sunRoof;
        }


        public string TOCSVString()
        {
            string CSV = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", _vehicleRego, _make,
                _model, _year, _vehicleClass, _numSeats, _transmissionType, _fuelType, _GPS, _sunRoof, _colour, _dailyRate);
            return CSV;
        }

        public override string ToString()
        {
            string attributes = "Rego: " + _vehicleRego + "\n" + "make: " + _make + "\n" + "model: " + _model + "\n"
                                + "year: " + _year + "\n" + "numSeats: " + _numSeats
                                + "\n" + "Vehicle Class: " + _vehicleClass + "\n" + "transmission type: "
                                + _transmissionType + "\n" + "fuel type: "
                                + _fuelType + "\n" + "GPS: " + _GPS + "\n" + "sunRoof: "
                                + _sunRoof + "\n" + "colour: " + _colour + "\n";
            return attributes;
        }

        public List<string> GetAttributeList()
        {
            bool _GPS = true;
            bool _sunRoof = true;
            //Create new list of vehicle attributes
            List<string> VehicleAttributes = new List<string>();

            string regoAttr = _vehicleRego.ToString();
            string makeAttr = _make.ToString();
            string modelAttr = _model.ToString();
            string yearAttr = _year.ToString();
            string vehicleClassAttr = _vehicleClass.ToString();
            string numSeatsAttr = _numSeats.ToString() + "-Seater";
            string transmissionAttr = _transmissionType.ToString();
            string fuelAttr = _fuelType.ToString();
            string gpsAttr = "GPS";
            string sunroofAttr = "Sunroof";
            string dailyRateAttr = _dailyRate.ToString();
            string colourAttr = _colour.ToString();

            //Add strings to list
            VehicleAttributes.Add(regoAttr);
            VehicleAttributes.Add(makeAttr);
            VehicleAttributes.Add(modelAttr);
            VehicleAttributes.Add(yearAttr);
            VehicleAttributes.Add(vehicleClassAttr);
            VehicleAttributes.Add(numSeatsAttr);
            VehicleAttributes.Add(transmissionAttr);
            VehicleAttributes.Add(fuelAttr);
            VehicleAttributes.Add(dailyRateAttr);
            VehicleAttributes.Add(colourAttr);

            //Only Add GPS and Sunroof if true
            if (_GPSat)
            {
                VehicleAttributes.Add(gpsAttr);
            }
            if (_sunRoofat)
            {
                VehicleAttributes.Add(sunroofAttr);
            }

            for (int i = 0; i < VehicleAttributes.Count; i++)
            {
                Console.WriteLine(VehicleAttributes[i]);
            }
            return VehicleAttributes;
        }
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    public class Customer
    {
        //Author: Paolo Jaldon

        //private variables
        private int _customerID;
        private string _title;
        private string _firstNames;
        private string _lastName;
        public enum Gender { male, female };
        private string _dateOfBirth;
        private Gender _gender;

        //getters/setters
        public int _CustomerID { get; set; }
        public string _Title { get; set; }
        public string _FirstNames { get; set; }
        public string _LastName { get; set; }
        public Gender _Gender { get; set; }
        public string _DateOfBirth { get; set; }

        public static int customerIDPub;
        public static List<int> _customerIDList = new List<int>();

        public Customer(int customerID, string title, string firstNames, string
                        lastName, Gender gender, string dateOfBirth)
        {
            _customerID = customerID;
            _title = title;
            _firstNames = firstNames;
            _lastName = lastName;
            _gender = gender;
            _dateOfBirth = dateOfBirth;
            customerIDPub = customerID;

            _CustomerID = customerID;
            _Title = title;
            _FirstNames = firstNames;
            _LastName = lastName;
            _Gender = gender;
            _DateOfBirth = dateOfBirth;
        }

        public string ToCSVString()
        {
            string CSV = string.Format("{0},{1},{2},{3},{4},{5}", _customerID, _title,
               _firstNames, _lastName, _gender, _dateOfBirth);
            return CSV;
        }



        public override string ToString()
        {
            string attributes = "CustomerID: " + _customerID + "\n" + "Title: " + _title + "\n"
                              + "FirstName: " + _firstNames + "\n" + "LastName: " + _lastName
                              + "\n" + "Gender: " + _gender + "\n" + "DOB: "
                              + _dateOfBirth;
            return attributes;
        }




    }

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    public class CRM
    {
        //Author: Paolo Jaldon

        private List<Customer> _customers = new List<Customer>();
        string crmFile = @"C:\Users\pjald\Documents\C# solutions\Data\customer.csv";

        public static int customerIDfleet;
        public static Dictionary<Customer, int> CustomersandCustID = new Dictionary<Customer, int>();

        public CRM()
        {
            _customers = new List<Customer>();
            //LoadFromFile();
        }

        public bool AddCustomer(Customer customer)
        {
            if (Customer._customerIDList.Contains(Customer.customerIDPub))
            {

                return false;
            }

            else
            {
                _customers.Add(customer);
                Customer._customerIDList.Add(Customer.customerIDPub);
                CustomersandCustID.Add(customer, Customer.customerIDPub);
                return true;
            }

        }

        public bool RemoveCustomer(Customer customer, Fleet fleet)
        {
            //if customer is renting a car in a fleet, do not remove. else, remove customer
            var myvalue = CustomersandCustID.FirstOrDefault(x => x.Key == customer).Value;
            if (fleet.IsRenting(myvalue))
            {
                return false;
            }
            else
            {
                _customers.Remove(customer);
                Customer._customerIDList.Remove(myvalue);
                CustomersandCustID.Remove(customer);
                return true;
            }

        }

        public bool RemoveCustomer(int customerID, Fleet fleet)
        {
            if (fleet.IsRenting(customerID))
            {
                return false;
            }
            else
            {
                var mykey = CustomersandCustID.FirstOrDefault(x => x.Value == customerID).Key;
                _customers.Remove(mykey);
                Customer._customerIDList.Remove(customerID);
                CustomersandCustID.Remove(mykey);
                return true;
            }
        }


        public List<Customer> GetCustomers()
        {
            return _customers;
        }

        public void SaveToFile()
        {

            using (StreamReader rw = new StreamReader(crmFile))
            {
                rw.ReadLine();
            }
            using (StreamWriter sw = File.CreateText(crmFile))
            {
                for (int i = 0; i < _customers.Count; i++)
                {
                    var line = _customers[i].ToCSVString();

                    sw.WriteLine(line);
                }
            }

        }



        public void LoadFromFile()
        {
            try
            {
                Console.WriteLine("Loading" + crmFile);

                System.IO.StreamReader fileReader = new System.IO.StreamReader(crmFile);

          

                string line;
                while ((line = fileReader.ReadLine()) != null)
                {
                    string[] column = line.Split(',');
                    Customer newCustomer = new Customer(int.Parse(column[0]), column[1], column[2], column[3], (Customer.Gender)Enum.Parse(typeof(Customer.Gender), column[4]), column[5]);
                    _customers.Add(newCustomer);
                }

                fileReader.Close();

            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine("Could not load file" + crmFile);
            }

        }

        public Customer GetCustomer(int customerID)
        {
            foreach (Customer customer in _customers)
            {
                if (customer._CustomerID == customerID)
                {
                    return customer;
                }
            }
            return null;
        }



    }

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    public class Fleet
    {
        //Author: Paolo Jaldon

        private List<Vehicle> _vehicleFleet = new List<Vehicle>();
        private Dictionary<string, int> rentals = new Dictionary<string, int>();
        private string fleetFile = @"C:\Users\pjald\Documents\C# solutions\Data\fleet.csv";
        private string rentalFile = @"C:\Users\pjald\Documents\C# solutions\Data\rentals.csv";

        public static List<Vehicle> _vehiclesRented = new List<Vehicle>();
        public static List<Vehicle> _vehiclesNotRented = new List<Vehicle>();



        public bool _rented = true;

        public Fleet()
        {
            //LoadFromFile();
        }

       
        public bool AddVehicle(Vehicle vehicle)
        {
            if (Vehicle._vehicleRegos.Contains(Vehicle.vehicleRegoPub))
            {

                return false;
            }

            else
            {

                _vehicleFleet.Add(vehicle);
                //list of vehicleRegos
                Vehicle._vehicleRegos.Add(Vehicle.vehicleRegoPub);
                //Dictionary <Vehicle, string> of vehicle and vehicleRego
                Vehicle._vehicleAndRegoDict.Add(vehicle, Vehicle.vehicleRegoPub);
                //List of vehicles
                _vehiclesNotRented.Add(vehicle);
                return true;
            }

        }

        public bool RemoveVehicle(Vehicle vehicle)
        {

            if (rentals.ContainsKey(Vehicle.vehicleRegoPub))
            {

                return false;
            }

            else
            {
                _vehicleFleet.Remove(vehicle);
                _vehiclesNotRented.Remove(vehicle);
                return true;
            }

        }

        public bool RemoveVehicle(string vehicleRego)
        {
            if (rentals.ContainsKey(vehicleRego))
            {
                return false;
            }
            else
            {
                var mykey = Vehicle._vehicleAndRegoDict.FirstOrDefault(x => x.Value == vehicleRego).Key;

                _vehicleFleet.Remove(mykey);
                _vehiclesNotRented.Remove(mykey);
                return true;
            }

        }


        public List<Vehicle> GetFleet()
        {
            /*for (int i = 0; i < _vehicleFleet.Count; i++)
            {
                Console.WriteLine(_vehicleFleet[i]);
            }*/
            return _vehicleFleet;
        }

        public List<Vehicle> GetFleet(bool rented)
        {
            if (rented == true)
            {
                for (int i = 0; i < _vehiclesRented.Count; i++)
                {
                    Console.WriteLine(_vehiclesRented[i]);
                }
                return _vehiclesRented;
            }
            else
            {
                for (int i = 0; i < _vehiclesNotRented.Count; i++)
                {
                    Console.WriteLine(_vehiclesNotRented[i]);
                }
                return _vehiclesNotRented;
            }

        }

        public int ReturnCar(string vehicleRego)
        {
            if (rentals.ContainsKey(vehicleRego))
            {
                var myvalue = rentals.FirstOrDefault(x => x.Key == vehicleRego).Value;
                return myvalue;
            }

            else
            {
                return -1;
            }
        }


        public bool IsRented(string vehicleRego)
        {
            if (rentals.ContainsKey(vehicleRego))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsRenting(int customerID)
        {
            if (rentals.ContainsValue(customerID))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public int RentedBy(string vehicleRego)
        {
            int value;
            if (rentals.ContainsKey(vehicleRego))
            {
                value = rentals[vehicleRego];
                return value;
            }
            else
            {
                return -1;
            }
        }

        public bool RentCar(string vehicleRego, int customerID)
        {
            if (rentals.ContainsKey(vehicleRego) || rentals.ContainsValue(customerID))
            {

                return false;
            }
            else if (!Vehicle._vehicleRegos.Contains(vehicleRego) || !Customer._customerIDList.Contains(customerID))
            {
                return false;
            }
            else
            {
                var mykey = Vehicle._vehicleAndRegoDict.FirstOrDefault(x => x.Value == vehicleRego).Key;

                rentals.Add(vehicleRego, customerID);
                _vehiclesRented.Add(mykey);
                _vehiclesNotRented.Remove(mykey);
                return true;
            }
        }

        public Vehicle GetVehicle(string vehicleRego)
        {
            foreach (Vehicle vehicle in _vehicleFleet)
            {
                if (vehicle._VehicleRego == vehicleRego)
                {
                    return vehicle;
                }
            }
            return null;
        }
        

        public void SaveToFile()
        {

            using (StreamWriter sw = File.CreateText(fleetFile))
            {
                for (int i = 0; i < _vehicleFleet.Count; i++)
                {
                    var line = _vehicleFleet[i].TOCSVString();

                    sw.WriteLine(line);
                }
            }
        }

        public void LoadFromFile()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(fleetFile);

                for (int lineNum = 0; lineNum < lines.Length; lineNum++)
                {
                    string[] vehColumns = lines[lineNum].Split(',');

                    string rego = vehColumns[0];
                    string make = vehColumns[1];
                    string model = vehColumns[2];
                    int year = int.Parse(vehColumns[3]);
                    Vehicle.VehicleClass vehicleClass = (Vehicle.VehicleClass)Enum.Parse(typeof(Vehicle.VehicleClass), vehColumns[4]);
                    int numseat = int.Parse(vehColumns[5]);
                    Vehicle.TransmissionType transmissionType = (Vehicle.TransmissionType)Enum.Parse(typeof(Vehicle.TransmissionType), vehColumns[6]);
                    Vehicle.FuelType fuelType = (Vehicle.FuelType)Enum.Parse(typeof(Vehicle.FuelType), vehColumns[7]);
                    bool gps = bool.Parse(vehColumns[8]);
                    bool sunroof = bool.Parse(vehColumns[9]);
                    string colour = vehColumns[10];
                    double dailyRate = double.Parse(vehColumns[11]);

                    _vehicleFleet.Add(new Vehicle(rego, vehicleClass, make, model, year, numseat, transmissionType, fuelType, gps, sunroof, dailyRate, colour));


                }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine("Could not load file" + fleetFile);
            }


        }

    }
}





