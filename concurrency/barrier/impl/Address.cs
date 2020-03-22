using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_concepts.concurrency.barrier.impl
{
    public class Address
    {
        private string building,street,city;
        private long zip;

        public Address(string building, string street, string city, long zip)
        {
            this.building = building;
            this.street = street;
            this.city = city;
            this.zip = zip;
        }

        public string getBuilding() {
            return building;
        }

        public string getStreet()
        {
            return street;
        }

        public string getCity()
        {
            return city;
        }

    }
}
