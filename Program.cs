using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfVisit
{
    class Program
    {
        static void Main(string[] args)
        {
            var counts = new string[] {
            "900,google.com",
            "60,mail.yahoo.com",
            "10,mobile.sports.yahoo.com",
            "40,sports.yahoo.com",
            "300,yahoo.com",
            "10,stackoverflow.com",
            "20,overflow.com",
            "5,com.com",
            "2,en.wikipedia.org",
            "1,m.wikipedia.org",
            "1,mobile.sports",
            "1,google.co.uk"
        };
            var domainWithValues = NumberOfDomain(counts);

            foreach (var dValue in domainWithValues)
            {
                Console.WriteLine(dValue.Key + " : " + dValue.Value);
            }
        }
        public static Dictionary<string, int> NumberOfDomain(string[] domainCount)
        {
            var domainValues = new Dictionary<string, int>();

            foreach (var domain in domainCount)
            {
                string[] siteDomainVisit = domain.Split(',');

                int numOfVisit = Int32.Parse(siteDomainVisit[0]);
                string fullDomain = siteDomainVisit[1];

                int domainValue;

                domainValues[fullDomain] = domainValues.TryGetValue(fullDomain, out domainValue) ? domainValue + numOfVisit : numOfVisit;

                //domainValues.Add(fullDomain, numOfVisit);

                string[] subDomains = fullDomain.Split('.').Skip(1).ToArray();


                int value;

                while (subDomains.Length != 0)
                {
                    string subdomain = string.Join(".", subDomains);
                    domainValues[subdomain] = domainValues.TryGetValue(subdomain, out value) ? value + numOfVisit : numOfVisit;
                    subDomains = subdomain.Split('.').Skip(1).ToArray();
                }

            }
            return domainValues;
        }

    }
}
