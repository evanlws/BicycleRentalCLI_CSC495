using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRentalCLI
{
  class Worker : Persistable
  {
    private int ID { get; set; }
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private string Address { get; set; }
    private string City { get; set; }
    private string State { get; set; }
    private string Zip { get; set; }
    private string DOB { get; set; }
    public Worker()
      : base() // call parent default constructor
    {
      connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
          @"Data source=C:\Workers\Public\Documents\Visual Studio Assets" +
          @"\Vehicle-noQueries.accdb";
    }
    //------------------------------------------------------------------
    public Worker(string firstName, string lastName, string address,
       string city, string state, string dob, string zip)
      : base()
    {
      connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
          @"Data source=C:\Workers\Public\Documents\Visual Studio Assets" +
          @"\Vehicle-noQueries.accdb";
      this.FirstName = firstName;
      this.LastName = lastName;
      this.Address = address;
      this.City = city;
      this.State = state;
      this.DOB = dob;
      this.Zip = zip;
    }
    //------------------------------------------------------------------
    public void populate(int ID)
    {
      string queryString = "SELECT * FROM Worker WHERE (ID = " + ID + ")";
      List<Object> results = getValues(queryString);
      if (results != null)
      {
        foreach (object result in results)
        {
          IEnumerable<Object> row = result as IEnumerable<Object>;
          int count = 0;
          foreach (object rowValue in row)
          {
            // DEBUG Console.WriteLine(rowValue);
            if (count == 0)
              this.ID = Convert.ToInt32(rowValue);
            else if (count == 1)
              FirstName = Convert.ToString(rowValue);
            else if (count == 2)
              LastName = Convert.ToString(rowValue);
            else if (count == 3)
              Address = Convert.ToString(rowValue);
            else if (count == 4)
              City = Convert.ToString(rowValue);
            else if (count == 5)
              State = Convert.ToString(rowValue);
            else if (count == 6)
              DOB = Convert.ToString(rowValue);
            else if (count == 7)
              Zip = Convert.ToString(rowValue);
            count = count + 1;
          }
        }
      }
    }

    public void insert()
    {

      string insertQuery =
      "INSERT INTO Worker (FirstName, LastName, Address, City, State, Zip, DOB) " +
      "VALUES (" +
      "'" + this.FirstName + "', '" +
      this.LastName + "', '" +
      this.Address + "', '" +
      this.City + "', '" +
      this.State + "', '" +
      this.Zip + "', '" +
      this.DOB + "')";
      int returnCode = modifyDatabase(insertQuery);
      if (returnCode != 0)
      {
        Console.WriteLine("Error in inserting Worker object into database");
      }
      else
      {
        Console.WriteLine("Worker object successfully inserted");
        string idQueryString = "SELECT MAX(ID) FROM Worker";
        List<Object> results = getValues(idQueryString);
        if (results != null)
        {
          // DEBUG Console.WriteLine("Got an id from id query");
          foreach (object result in results)
          {
            IEnumerable<Object> row = result as IEnumerable<Object>;
            foreach (object rowValue in row)
            {
              // DEBUG Console.WriteLine("Retrieved id = " + rowValue);
              this.ID = Convert.ToInt32(rowValue);
            }
          }
        }
      }
    }

    public void update()
    {
      string updateQuery = "UPDATE Worker SET " +
          " FirstName = '" + this.FirstName + "' ," +
          " LastName = '" + this.LastName + "' ," +
          " Address = '" + this.Address + "' ," +
          " City = '" + this.City + "' ," +
          " State = '" + this.State + "', " +
          " Zip = '" + this.Zip + "', " +
          " DOB = '" + this.DOB + "' " +
          " WHERE " +
          " ID = " + this.ID;
      Console.WriteLine(updateQuery);
      int returnCode = modifyDatabase(updateQuery);
      if (returnCode != 0)
        Console.WriteLine("Error in updating Worker object into database");
      else
        Console.WriteLine("Worker object successfully updated");
    }

    public void delete()
    {
      string deleteQuery = "DELETE FROM Worker WHERE " +
          " ID = " + this.ID;
      Console.WriteLine(deleteQuery);
      int returnCode = modifyDatabase(deleteQuery);
      if (returnCode != 0)
        Console.WriteLine("Error in deleting Worker object from database");
      else
        Console.WriteLine("Worker object successfully deleted");
    }

    public string getFirstName()
    {
      return this.FirstName;
    }

    public string getLastName()
    {
      return this.LastName;
    }

    public string getAddress()
    {
      return this.Address;
    }

    public string getCity()
    {
      return this.City;
    }

    public string getState()
    {
      return this.State;
    }

    public string getZip()
    {
      return this.Zip;
    }

    public string getDOB()
    {
      return this.DOB;
    }

    public void setFirstName(string firstName)
    {
      this.FirstName = firstName;
    }

    public void setLastName(string lastName)
    {
      this.LastName = lastName;
    }

    public void setAddress(string address)
    {
      this.Address = address;
    }

    public void setCity(string city)
    {
      this.City = city;
    }

    public void setState(string state)
    {
      this.State = state;
    }

    public void setZip(string zip)
    {
      this.Zip = zip;
    }

    public void setDOB(string dob)
    {
      this.DOB = dob;
    }
  }
}

