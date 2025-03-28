﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyHandshake
{
    public class CPerson : IDisposable
    {
        public static int nextID = 1;
        private bool disposedValue;

        public int ID { get;}
        public string Name { get; set; }

        public int age { get; set; }

        public CPerson(string name, int age)
        {
            ID = nextID++;
            this.Name = name;
            this.age = age;
        }
        public CPerson()
        {
                
        }
        public override bool Equals(object obj)
        {
            if(obj is CPerson otherPerson)
            {
                return this.ID == otherPerson.ID;
            }
            return false;
        }
        public override string ToString()
        {
            return ($"ID: {ID} Name: {Name} Age: {age} ").ToString();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CPerson()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
