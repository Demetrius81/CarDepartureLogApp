using CarDepartureLogApp.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDepartureLogApp.Models
{
    public class Car : ICar
    {        
        public Car(string registrationNumber, string brand, string model)
        {            
            RegistrationNumber = registrationNumber;
            Brand = brand;
            Model = model;
            Away = false;
        }

        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool Away { get; set; }

        public List<DepartureRecord> DepartureRecords { get; set; } = new();

        public override string ToString()
        {
            return $"{Id}\t {RegistrationNumber} {Brand} {Model}";
        }

        public override bool Equals(object? obj)
        {
            var car = obj as Car;

            if (car == null)
            return false;
            if (car.GetType() != typeof(Car))
            return false;
            if (car.Id == this.Id 
                && car.Model == this.Model 
                && car.Brand == this.Brand 
                && car.RegistrationNumber == this.RegistrationNumber
                && car.Away == this.Away)
            {
                return true;
            }
            return false;
        }
        public bool Equals(Car car)
        {            
            if (car == null)
                return false;
            if (car.GetType() != typeof(Car))
                return false;
            if (car.Id == this.Id
                && car.Model == this.Model
                && car.Brand == this.Brand
                && car.RegistrationNumber == this.RegistrationNumber
                && car.Away == this.Away)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return RegistrationNumber.GetHashCode()^Id;
        }

    }
}
