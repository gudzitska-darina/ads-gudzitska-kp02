using System;
using static System.Console;
namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.InitHashtable();
            while (true)
            {
                WriteLine("Enter the selected hashtable\n\r[control|user|exit]");
                string input = ReadLine();
                switch (input)
                {
                    case "control":
                        Control();
                        break;
                    case "user":
                        User(hashtable);
                        break;
                    case "exit":
                        WriteLine("Goodbye.");
                        return;
                    default:
                        WriteLine("Incorrect input");
                        break;
                }
            }
        }
        static void Control()
        {
            Hashtable controlHash = new Hashtable();
            controlHash.InitHashtable();
            HashtableGate checkGate = new HashtableGate();
            checkGate.InitHashtable();

            for(int i = 0; i < 6; i++)
            {
                string[] m = {"May","June","July","August"};
                int x = new Random().Next(00, 24);
                Key newKey = new Key();
                Value value = new Value();
                if(i % 2 == 0)
                {
                    value.aeroportOfArrival = "Kyiv";
                    newKey.flightCode = "AHY2300" + (i % 6);
                    value.gate = "A13";
                    value.departureTime = new TimeData {
                        year = 2021,
                        month = m[new Random().Next(0, m.Length)],
                        day = new Random().Next(1, 30),
                        time = x + ((new Random().NextDouble() * (0.59 - 0.01)) + 0.01),   
                    };
                    controlHash.InsertEntry(newKey, value);
                    Key gateTableKey = new Key(value.gate);
                    Value gateTableValue = new Value(newKey.flightCode);
                    gateTableValue.aeroportOfArrival = value.aeroportOfArrival;
                    gateTableValue.departureTime = value.departureTime;
                    gateTableValue.isDelayed = value.isDelayed;
                    checkGate.InsertEntry(gateTableKey, gateTableValue);
                }
                if(i % 2 == 1)
                {
                    value.aeroportOfArrival = "Kuala";
                    newKey.flightCode = "ABF2345" + (i ^ 2);
                    value.gate = "D34";
                    value.departureTime = new TimeData {
                        year = 2021,
                        month = m[new Random().Next(0, m.Length)],
                        day = new Random().Next(1, 30),
                        time = x + ((new Random().NextDouble() * (0.59 - 0.01)) + 0.01),   
                    };
                    controlHash.InsertEntry(newKey, value);
                    Key gateTableKey = new Key(value.gate);
                    Value gateTableValue = new Value(newKey.flightCode);
                    gateTableValue.aeroportOfArrival = value.aeroportOfArrival;
                    gateTableValue.departureTime = value.departureTime;
                    gateTableValue.isDelayed = value.isDelayed;
                    checkGate.InsertEntry(gateTableKey,gateTableValue);
                }

            }
            controlHash.LogHashtable();
            
            WriteLine($"Flight for gate D34:");
            checkGate.SameGateFlights("D34");
            WriteLine($"\tFull information:");
            checkGate.LogHashtable("D34");
            WriteLine($"Flight for gate A13:");
            checkGate.SameGateFlights("A13");
        }
        static void User(Hashtable hashtable)
        {
            HashtableGate checkGate = new HashtableGate();
            checkGate.InitHashtable();
            while(true)
            {
               WriteLine("\nEnter command");
                string command = ReadLine();
                string[] sub = command.Split(' ');
                
                if(sub.Length == 3)
                {
                    if(sub[0] == "add")
                    {
                        if(sub[1] == "" || sub[2] == "")
                        {
                            WriteLine("You miss sth.");
                        }
                        else
                        {
                            Key key = new Key();
                            Value value = new Value();
                            key.flightCode = sub[1];
                            value.aeroportOfArrival = sub[2];
                            key.flightCode = sub[1];
                            value.aeroportOfArrival = sub[2];

                            WriteLine("Please, enter date (YYYY.Month.DD.HH,MM)");
                            string time = ReadLine();
                            string[] t = time.Split('.');
                            int num1;
                            double num2;
                            
                            bool success1 = Int32.TryParse(t[0], out num1);
                            bool success2 = Int32.TryParse(t[2], out num1);
                            bool success3 = double.TryParse(t[3], out num2);
                            if (success1 && success2 && success3)
                            {
                                value.departureTime.year = int.Parse(t[0]);
                                value.departureTime.month = t[1];
                                value.departureTime.day = int.Parse(t[2]);
                                value.departureTime.time = double.Parse(t[3]);

                                hashtable.InsertEntry(key, value);
                                WriteLine("Success");

                                Key gateTableKey = new Key(value.gate);
                                Value gateTableValue = new Value(key.flightCode);
                                gateTableValue.aeroportOfArrival = value.aeroportOfArrival;
                                gateTableValue.departureTime = value.departureTime;
                                gateTableValue.isDelayed = value.isDelayed;
                                checkGate.InsertEntry(gateTableKey,gateTableValue);
                            }
                            else
                            {
                                WriteLine("Incorrect TimeData values");
                                continue;
                            }
                            
                            
                        }
                    }
                }
                else if(sub.Length == 2)
                {
                    if(sub[0] == "remove")
                    {
                        Key keyRem = new Key();
                        keyRem.flightCode = sub[1];
                        Entry enRem = hashtable.FindEntry(keyRem);
                        WriteLine(enRem.ToString());
                        Key gateKRem = new Key(enRem.value.gate);
                        checkGate.RemoveEntry(gateKRem);

                        hashtable.RemoveEntry(keyRem);
                        WriteLine("Success");
                    }
                    else if(sub[0] == "find")
                    {
                        Key findKey = new Key();
                        findKey.flightCode = sub[1];
                        Entry f = hashtable.FindEntry(findKey);
                        if (f == null)
                        {
                            WriteLine($"Not found : {sub[1]}");
                            continue;
                        }
                        WriteLine(f.ToString());                        
                    }
                    else if(sub[0] == "findGate")
                    {
                        Key keyG = new Key(sub[1]);
                        if(checkGate.FindEntry(keyG) == null)
                        {
                            WriteLine("There are no flights for this gate yet");
                            continue;
                        }
                        WriteLine($"\tFlight for gate {keyG.gate}:");
                        checkGate.SameGateFlights(keyG.gate);
                        WriteLine("Do you want view fuul info? (y/n)");
                        string ans = ReadLine();
                        if(ans == "y")
                        {
                            WriteLine($"\tFull information:");
                            checkGate.LogHashtable(keyG.gate);
                        }
                        else continue;
                    }
                }
                else if(sub.Length == 1)
                {
                    if(sub[0] == "log")
                    {
                        hashtable.LogHashtable();
                    }
                    
                    else if(sub[0] == "exit")
                    {
                        return;
                    }
                    else
                    {
                        WriteLine($"Nonexistent command: {sub[0]}");
                    }
                }    
                else   WriteLine($"Nonexistent command: {command}");
                
            }
        }
    }
}
