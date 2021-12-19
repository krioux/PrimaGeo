using System.Linq;
using PrimaGeo.Rest;

namespace PrimaGeo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            GeoDB test = new GeoDB();
            var result = test.Cities.ToList();
        }
    }
}
