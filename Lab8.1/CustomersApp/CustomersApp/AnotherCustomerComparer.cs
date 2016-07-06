using System.Collections.Generic;

namespace customersApp
{
    public class AnotherCustomerComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return x.Id.CompareTo(y.Id) != 0 ? x.Id.CompareTo(y.Id) : 0;
        }
    }
}