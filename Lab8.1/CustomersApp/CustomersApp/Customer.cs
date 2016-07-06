using System;

namespace customersApp
{
    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        public string Name { get; }
        public int Id { get; }
        public string Address { get; }

        public Customer(int id, string name, string address)
        {
            Name = name;
            Id = id;
            Address = address;
        }

        public int CompareTo(Customer other)
        {
            // If other is not a valid object reference, this instance is greater, else the names are compared in a case insensitive way.
            return other == null ? 1 : Name.ToLower().CompareTo(other.Name.ToLower());
        }

        public bool Equals(Customer other)
        {
            if (other == null)
                return false;

            return Name == other.Name && Id == other.Id;
        }
    }
}
