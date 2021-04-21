using System;
using static System.Console;
using System.Collections.Generic;
using System.Globalization;
namespace lab7
{
    public struct TimeData
    {   
        public int year; 
        public string month; 
        public int day;
        public double time;
        public override string ToString()
        {
            return $"{year}.{month}.{day} {time.ToString("00.00", CultureInfo.InvariantCulture)}";
        }

    }
    
    public class Hashtable
    {
        public List<Entry>[] table;
        int loadness;
        int size;
        public void InitHashtable()
        {
            this.table = new List<Entry>[2];
            this.loadness = 0;
            this.size = 0;
        }
        public int GetHash(Key key)
        {
            int index = (int)HashCode(key) % table.Length;
            return index;
        }
        public long HashCode(Key key)
        {
            long hashCode = 0;
            string keyString = key.flightCode;
            for (int i = 0; i < keyString.Length; i++)
            {
                hashCode += (int)keyString[i];
            }
            return hashCode;
        }
        public bool Rehashing()
        {
            Hashtable newHash = new Hashtable();
            newHash.InitHashtable();
            Array.Resize(ref newHash.table, table.Length + 1);

            for (int i = 0; i < this.table.Length; i++)
            {
                if (this.table[i] == null) continue;
                foreach (Entry it in this.table[i])
                {
                    int index = GetHash(it.key);
                    newHash.InsertEntry(it.key, it.value);
                }
            }
            this.table = newHash.table;
            return true;
        }
        public bool InsertEntry(Key key, Value value)
        {
            if (loadness >= table.Length * 5)
            {
                if (Rehashing())
                {
                    WriteLine("Rehashing sucsessful");
                }
            }
            Entry newEntry = new Entry(key, value);
            CheckFlight(newEntry);

            int index = GetHash(key);
            if (this.table[index] == null)
            {
                this.table[index] = new List<Entry>();

                this.table[index].Add(newEntry);
                this.loadness++;
                this.size++;
            }
            else
            {
                table[index].Add(newEntry);
                this.loadness++;
            }
            return true;
        }
        public Entry RemoveEntry(Key key)
        {
            int index = GetHash(key);
            Entry findEntry = FindEntry(key);

            if (findEntry == null)
            {
                WriteLine($"Key {key.flightCode} not found"); 
                return null;
            }
            else
            {
                table[index].Remove(findEntry);
                if (table[index] == null) 
                { 
                    this.size--; 
                }
                this.loadness--;
                return findEntry;
            }
        }
        public Entry FindEntry(Key key)
        {
            int index = GetHash(key);
            if (this.table[index] != null)
            {
                foreach (Entry it in this.table[index])
                {
                    if (it.key.flightCode == key.flightCode)
                    {
                        return it;
                    }
                }
            }
            return null;
        }
        private void CheckFlight(Entry entry)
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (this.table[i] != null)
                {
                    foreach (Entry it in this.table[i])
                    {
                        if (it.value.gate == entry.value.gate)
                        {
                      
                            entry.value.isDelayed = 01.45;
                                                                   
                        }
                        
                        if(it.value.isDelayed == 01.45 && it.value.gate == entry.value.gate)
                        {
                            entry.value.isDelayed += 01.45;
                        }
                    }
                    
                }
            }
        }
        public void LogHashtable()
        {
            if(this.loadness == 0)
            {
                WriteLine("Hashtable is empty");
            }
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    foreach (Entry it in table[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        WriteLine($"Key: {it.key.flightCode} --->    |{it.value.departureTime}| {it.value.aeroportOfArrival} - {it.value.gate}    |Delay: {it.value.isDelayed.ToString("00.00", CultureInfo.InvariantCulture)}");
                        Console.ResetColor();
                    }
                }                 
            }
        }
    }
    public class Key
    {
        public string gate;

        public string flightCode;
        public Key()
        {
            this.gate = "";
        }
        public Key(string input)
        {
            this.gate = input;
        }
    }
    public class Value
    {
        public string aeroportOfArrival;
        public string gate; 
        public TimeData departureTime;
        public double isDelayed;
        public string flightCode;
        public Value(string flightCode)
        {
            this.flightCode = flightCode;
        }
        public Value()
        {
            this.aeroportOfArrival = "";
            this.gate = ChoiceGate();
            this.flightCode = "";
            this.departureTime = new TimeData{ 
                year = 0,
                month = "",
                day = 0,
                time = 0.0, };
            this.isDelayed = 00.00;
        }
        public string ChoiceGate()
        {
            string[] a = {"A13", "B05", "D34", "A21", "C03"};           
            return (a[new Random().Next(0, a.Length)]);
        }
    }
    public class Entry
    {
        public Key key;
        public Value value;
         public Entry(Key key, Value value)
        {
            this.key = key;
            this.value = value;
        }
        public override string ToString()
        {
            return $"Key : {key.flightCode} --->    |{value.departureTime}| {value.aeroportOfArrival} - {value.gate}  |Delay: {value.isDelayed.ToString("00.00", CultureInfo.InvariantCulture)}";
        }
    }
}