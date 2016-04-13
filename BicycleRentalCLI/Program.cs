using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRentalCLI
{
  class Program
  {
    static void Main(string[] args)
    {
      User u = new User();
      u.populate(1);
      Console.WriteLine("name " + u.getFirstName());
    }
  }
}
