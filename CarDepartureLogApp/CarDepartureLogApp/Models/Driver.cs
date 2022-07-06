using CarDepartureLogApp.Models.Interfaces;

namespace CarDepartureLogApp.Models
{
    public class Driver : IDriver
    {
        public Driver(string name, string middleName, string surName)
        {
            Name = name;
            MiddleName = middleName;
            SurName = surName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public List<DepartureRecord> DepartureRecords { get; set; } = new();

        public override string ToString()
        {
            return $"{Id}\t {SurName} {Name.FirstOrDefault()}.{MiddleName.FirstOrDefault()}.";
        }
        public override bool Equals(object? obj)
        {
            var driver = obj as Driver;

            if (driver == null)
                return false;
            if (driver.GetType() != typeof(Driver))
                return false;
            if (driver.Id == this.Id
                && driver.Name == this.Name
                && driver.MiddleName == this.MiddleName
                && driver.SurName == this.SurName)                
            {
                return true;
            }
            return false;
        }
        public bool Equals(Driver driver)
        {
            if (driver == null)
                return false;
            if (driver.GetType() != typeof(Driver))
                return false;
            if (driver.Id == this.Id
                && driver.Name == this.Name
                && driver.MiddleName == this.MiddleName
                && driver.SurName == this.SurName)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return SurName.GetHashCode() ^ Id;
        }
    }
}
