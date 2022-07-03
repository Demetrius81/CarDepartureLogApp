using CarDepartureLogApp.Context;
using CarDepartureLogApp.Models;
using CarDepartureLogApp.Models.Interfaces;

namespace CarDepartureLogApp.Controllers
{
    public class DepartureLogController
    {        
        public void Create(DateTime departureTime,
                           int odometerBeforeLeaving,
                           string purposeOfDeparture,
                           string description,
                           Car car,
                           Driver driver)
        {
            using (var _context = new AppMySqlContext())
            {
                _context.DepartureRecords.Add(new DepartureRecord(departureTime,
                                                                  odometerBeforeLeaving,
                                                                  purposeOfDeparture,
                                                                  description,
                                                                  car,
                                                                  driver));

                _context.SaveChanges();
            }
        }

        public void CreateNew(DateTime departureTime,
                              DateTime returnTime,
                              int odometerBeforeLeaving,
                              int odometerAfterLeaving,
                              string purposeOfDeparture,
                              string description,
                              Car car,
                              Driver driver)
        {
            using (var _context = new AppMySqlContext())
            {
                _context.DepartureRecords.Add(new DepartureRecord(departureTime,
                                                                  returnTime,
                                                                  odometerBeforeLeaving,
                                                                  odometerAfterLeaving,
                                                                  purposeOfDeparture,
                                                                  description,
                                                                  car,
                                                                  driver));

                _context.SaveChanges();
            }
        }

        public DepartureRecord Read(int id)
        {
            DepartureRecord departureRecord = new DepartureRecord();

            using (var _context = new AppMySqlContext())
            {
                departureRecord = _context.DepartureRecords.Where(x => x.Id == id).FirstOrDefault();
            }
            return departureRecord;
        }

        public List<DepartureRecord> ReadLastDay()
        {
            List<DepartureRecord> records = new List<DepartureRecord>();

            using (var _context = new AppMySqlContext())
            {
                records = _context.DepartureRecords
                    .Where(x => x.DepartureTime > DateTime.Now.AddHours(-24)
                             && x.DepartureTime <= DateTime.Now)
                    .ToList();
            }
            return records;
        }

        public List<DepartureRecord> ReadLastAway()
        {
            List<DepartureRecord> records = new List<DepartureRecord>();

            using (var _context = new AppMySqlContext())
            {
                records = _context.DepartureRecords
                    .Where(x => x.Car.Away == true)
                    .ToList();
            }
            return records;
        }

        public List<DepartureRecord> ReadLastAll()
        {
            List<DepartureRecord> records = new List<DepartureRecord>();

            using (var _context = new AppMySqlContext())
            {
                records = _context.DepartureRecords.ToList();
            }
            return records;
        }

        public void Update(DepartureRecord departureRecord, DateTime returnTime, int odometerAfterLeaving, bool away)
        {
            using (var _context = new AppMySqlContext())
            {
                var record = _context.DepartureRecords.Where(x => x.Equals(departureRecord)).FirstOrDefault();

                record.Car.Away = away;

                record.ReturnTime = returnTime;

                record.OdometerAfterLeaving = odometerAfterLeaving;

                _context.SaveChanges();
            }
        }
        public void Delete(DepartureRecord departureRecord)
        {
            using (var _context = new AppMySqlContext())
            {
                _context.Remove<DepartureRecord>(departureRecord);

                _context.SaveChanges();
            }
        }

        public void DeleteByTwoYearsOldAndOlder()
        {
            List<DepartureRecord> recordsToRemove = new List<DepartureRecord>();

            using (var _context = new AppMySqlContext())
            {
                recordsToRemove = _context.DepartureRecords
                    .Where(x => x.DepartureTime < DateTime.Now.AddYears(-2))
                    .ToList();

                foreach (var item in recordsToRemove)
                {
                    _context.Remove<DepartureRecord>(item);

                }

                _context.SaveChanges();
            }
        }
    }
}
