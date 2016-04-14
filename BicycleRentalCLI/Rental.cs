using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRentalCLI
{
  class Rental : Persistable
  {
    private int RentalID { get; set; }
    private string VehicleID { get; set; }
    private string RenterID { get; set; }
    private string DateRented { get; set; }
    private string TimeRented { get; set; }
    private string DateDue { get; set; }
    private string TimeDue { get; set; }
    private string DateReturned { get; set; }
    private string TimeReturned { get; set; }
    private string CheckoutWorkerID { get; set; }
    private string CheckinWorkerID { get; set; }

    public Rental()
      : base() // call parent default constructor
    {
      connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
          @"Data source=..\BicycleRental.accdb";
    }
    //------------------------------------------------------------------
    public Rental(string vehicleId, string renterId, string dateRented, string timeRented, string dateDue, string timeDue, string dateReturned, string timeReturned, string checkoutWorkerId, string checkinWorkerId)
      : base()
    {
      connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
          @"Data source=..\BicycleRental.accdb";

      this.VehicleID = vehicleId;
      this.RenterID = renterId;
      this.DateRented = dateRented;
      this.TimeRented = timeRented;
      this.DateDue = dateDue;
      this.TimeDue = timeDue;
      this.DateReturned = dateReturned;
      this.TimeReturned = timeReturned;
      this.CheckoutWorkerID = checkoutWorkerId;
      this.CheckinWorkerID = checkinWorkerId;
    }
    //------------------------------------------------------------------
    public void populate(int Id)
    {
      string queryString = "SELECT * FROM Rental WHERE (RentalID = " + Id + ")";
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
              RentalID = Convert.ToInt32(rowValue);
            else if (count == 1)
              VehicleID = Convert.ToString(rowValue);
            else if (count == 2)
              RenterID = Convert.ToString(rowValue);
            else if (count == 3)
              DateRented = Convert.ToString(rowValue);
            else if (count == 4)
              TimeRented = Convert.ToString(rowValue);
            else if (count == 5)
              DateDue = Convert.ToString(rowValue);
            else if (count == 6)
              TimeDue = Convert.ToString(rowValue);
            else if (count == 7)
              DateReturned = Convert.ToString(rowValue);
            else if (count == 8)
              TimeReturned = Convert.ToString(rowValue);
            else if (count == 9)
              CheckoutWorkerID = Convert.ToString(rowValue);
            else if (count == 10)
              CheckinWorkerID = Convert.ToString(rowValue);
            count = count + 1;
          }
        }
      }
    }

    public void insert()
    {

      string insertQuery =
      "INSERT INTO Rental (VehicleID, RenterID, DateRented, TimeRented, DateDue, TimeDue, DateReturned, TimeReturned, CheckoutWorkerID, CheckinWorkerID) " +
      "VALUES (" +
      "'" + this.VehicleID + "', '" +
      this.RenterID + "', '" +
      this.DateRented + "', '" +
      this.TimeRented + "', '" +
      this.DateDue + "', '" +
      this.TimeDue + "', '" +
      this.DateReturned + "', '" +
      this.TimeReturned + "', '" +
      this.CheckoutWorkerID + "', '" +
      this.CheckinWorkerID + "')";
      int returnCode = modifyDatabase(insertQuery);
      if (returnCode != 0)
      {
        Console.WriteLine("Error in inserting Rental object into database");
      }
      else
      {
        Console.WriteLine("Rental object successfully inserted");
        string idQueryString = "SELECT MAX(ID) FROM Rental";
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
              this.RentalID = Convert.ToInt32(rowValue);
            }
          }
        }
      }
    }

    public void update()
    {
      string updateQuery = "UPDATE Rental SET " +
          " VehicleID = '" + this.VehicleID + "' ," +
          " RenterID = '" + this.RenterID + "' ," +
          " DateRented = '" + this.DateRented +"' ," +
          " TimeRented = '" + this.TimeRented + "' ," +
          " DateDue = '" + this.DateDue + "', " +
          " TimeDue = '" + this.TimeDue + "', " +
          " TimeDue = '" + this.DateReturned + "', " +
          " TimeDue = '" + this.TimeReturned + "', " +
          " TimeDue = '" + this.CheckoutWorkerID + "', " +
          " DOB = '" + this.CheckinWorkerID + "' " +
          " WHERE " +
          " RentalID = " + this.RentalID;
      Console.WriteLine(updateQuery);
      int returnCode = modifyDatabase(updateQuery);
      if (returnCode != 0)
        Console.WriteLine("Error in updating Rental object into database");
      else
        Console.WriteLine("Rental object successfully updated");
    }

    public void delete()
    {
      string deleteQuery = "DELETE FROM Rental WHERE " +
          " RentalID = " + this.RentalID;
      Console.WriteLine(deleteQuery);
      int returnCode = modifyDatabase(deleteQuery);
      if (returnCode != 0)
        Console.WriteLine("Error in deleting Rental object from database");
      else
        Console.WriteLine("Rental object successfully deleted");
    }

    public string getVehicleID()
    {
      return this.VehicleID;
    }

    public string getRenterID()
    {
      return this.RenterID;
    }

    public string getDateRented()
    {
      return this.DateRented;
    }

    public string getTimeRented()
    {
      return this.TimeRented;
    }

    public string getDateDue()
    {
      return this.DateDue;
    }

    public string getTimeDue()
    {
      return this.TimeDue;
    }

    public string getDateReturned()
    {
      return this.DateReturned;
    }

    public string getTimeReturned()
    {
      return this.TimeReturned;
    }

    public string getCheckoutWorkerId()
    {
      return this.CheckoutWorkerID;
    }

    public string getCheckinWorkerId()
    {
      return this.CheckinWorkerID;
    }

    public void setVehicleId(string vehicleId)
    {
      this.VehicleID = vehicleId;
    }

    public void setRenterId(string renterId)
    {
      this.RenterID = renterId;
    }

    public void setDateRented(string dateRented)
    {
      this.DateRented = dateRented;
    }

    public void setTimeRented(string timeRented)
    {
      this.TimeRented = timeRented;
    }

    public void setDateDue(string dateDue)
    {
      this.DateDue = dateDue;
    }

    public void setTimeDue(string timeDue)
    {
      this.TimeDue = timeDue;
    }

    public void setDateReturned(string dateReturned)
    {
      this.DateReturned = dateReturned;
    }

    public void setTimeReturned(string timeReturned)
    {
      this.TimeReturned = timeReturned;
    }

    public void setCheckoutWorkerId(string checkoutWorkerId)
    {
      this.CheckoutWorkerID = checkoutWorkerId;
    }

    public void setCheckinWorkerId(string checkinWorkerId)
    {
      this.CheckinWorkerID = checkinWorkerId;
    }
  }
}
