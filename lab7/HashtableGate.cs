using System;
using static System.Console;
using System.Collections.Generic;
using System.Globalization;
namespace lab7
{
    public class HashtableGate
    {
        public List<Entry>[] table;
        int loadness;
        int size;
        public void InitHashtable()
        {
            this.table = new List<Entry>[2];
            this.loadness = 0;
            this.size = 5;
        }
        public int GetHash(Key key)
        {
            int index = (int)HashCode(key) % table.Length;
            return index;
        }
        public long HashCode(Key key)
        {
            double a = 0.63689;
            double b = 0.378551;
            long hash = 0;
            string keyString = key.gate;
            for (int i = 0; i < keyString.Length; i++)
            {
                hash = (int)(hash * a + keyString[i]);
                a = a * b;
            }
            return hash;
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

            int index = GetHash(key);
            if (this.table[index] == null)
            {
                this.table[index] = new List<Entry>();

                this.table[index].Add(newEntry);
                this.loadness++;
                size++;
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
                WriteLine($"Key {key.gate} not found"); 
                return null;
            }
            else
            {
                table[index].Remove(findEntry);
                if (table[index] == null) 
                { 
                    this.size--; 
                }
                table[index].Remove(findEntry);
                table[index].Remove(findEntry);
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
                    if (it.key.gate == key.gate)
                    {
                        return it;
                    }
                }
            }
            return null;
        }
        public void LogHashtable(string keyG)
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
                        if(it.key.gate == keyG)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            WriteLine($"Key: {it.key.gate} --->    |{it.value.departureTime}|   <{it.value.flightCode}> {it.value.aeroportOfArrival}    |Delay: {it.value.isDelayed.ToString("00.00", CultureInfo.InvariantCulture)}");
                            Console.ResetColor();
                        }
                        
                    }
                }
            }
        }
        public void SameGateFlights(string gate)
        {
            if(this.loadness == 0)
            {
                WriteLine("Hashtable is empty");
                return;
            }
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    foreach (Entry it in table[i])
                    {
                        if(it.key.gate == gate)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            WriteLine($"\t|{it.value.flightCode}|");
                            Console.ResetColor();
                        }
                    }
                }
            }
        }
    }
}