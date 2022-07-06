using CarDepartureLogApp.Models.Interfaces;

namespace CarDepartureLogApp.Models
{
    public class DepartureRecord : IDepartureRecord
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public int OdometerBeforeLeaving { get; set; }
        public int OdometerAfterLeaving { get; set; }
        public string PurposeOfDeparture { get; set; }
        public string Description { get; set; }

        public DepartureRecord()
        {

        }

        public DepartureRecord(DateTime departureTime,
                               int odometerBeforeLeaving,
                               string purposeOfDeparture,
                               string description,
                               int carId,
                               int driverId)
        {
            DepartureTime = departureTime;
            OdometerBeforeLeaving = odometerBeforeLeaving;
            PurposeOfDeparture = purposeOfDeparture;
            Description = description;
            CarId = carId;
            DriverId = driverId;
        }

        public DepartureRecord(DateTime departureTime,
                               DateTime returnTime,
                               int odometerBeforeLeaving,
                               int odometerAfterLeaving,
                               string purposeOfDeparture,
                               string description,
                               int carId,
                               int driverId)
        {
            DepartureTime = departureTime;
            ReturnTime = returnTime;
            OdometerBeforeLeaving = odometerBeforeLeaving;
            OdometerAfterLeaving = odometerAfterLeaving;
            PurposeOfDeparture = purposeOfDeparture;
            Description = description;
            CarId = carId;
            DriverId = driverId;
        }

        public Car Car { get; set; }
        public Driver Driver { get; set; }

        public int CarId { get; set; }
        public int DriverId { get; set; }

        public string ToStringAway()
        {
            return $"{Id} {Car?.RegistrationNumber} {Car?.Brand} {Driver} {PurposeOfDeparture} {DepartureTime} {OdometerBeforeLeaving}";
        }

        public override string ToString()
        {
            return $"{Id} {Car?.RegistrationNumber} {Car?.Brand} {Car?.Model} {Driver} {PurposeOfDeparture} {DepartureTime} {(ReturnTime == default ? "на выезде" : ReturnTime)} {Description}";
        }
        public override bool Equals(object? obj)
        {
            var departureRecord = obj as DepartureRecord;

            if (departureRecord == null)
                return false;
            if (departureRecord.GetType() != typeof(DepartureRecord))
                return false;
            if (departureRecord.Id == this.Id
                && departureRecord.DepartureTime == this.DepartureTime
                && departureRecord.ReturnTime == this.ReturnTime
                && departureRecord.OdometerBeforeLeaving == this.OdometerBeforeLeaving
                && departureRecord.OdometerAfterLeaving == this.OdometerAfterLeaving
                && departureRecord.PurposeOfDeparture == this.PurposeOfDeparture
                && departureRecord.Description == this.Description)
            {
                return true;
            }
            return false;
        }
        public bool Equals(DepartureRecord departureRecord)
        {
            if (departureRecord == null)
                return false;
            if (departureRecord.GetType() != typeof(DepartureRecord))
                return false;
            if (departureRecord.Id == this.Id
                && departureRecord.DepartureTime == this.DepartureTime
                && departureRecord.ReturnTime == this.ReturnTime
                && departureRecord.OdometerBeforeLeaving == this.OdometerBeforeLeaving
                && departureRecord.OdometerAfterLeaving == this.OdometerAfterLeaving
                && departureRecord.PurposeOfDeparture == this.PurposeOfDeparture
                && departureRecord.Description == this.Description)
            {
                return true;
            }
            return false;
        }
    }
}
