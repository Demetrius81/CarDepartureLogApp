using CarDepartureLogApp.Context;
using CarDepartureLogApp.Models;
using CarDepartureLogApp.Models.Interfaces;

namespace CarDepartureLogApp.Controllers
{
    public class DepartureLogController
    {
        private readonly AppMySqlContext _context;

        public DepartureLogController()
        {
            _context = AppMySqlContext.GetAppContext();
        }
        public void Create(DateTime departureTime,
                               int odometerBeforeLeaving,
                               string purposeOfDeparture,
                               string description,
                               ICar car,
                               IDriver driver)
        {
            using (_context)
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
        public IDepartureRecord Read(int id)
        {
            IDepartureRecord departureRecord = new DepartureRecord();

            using (_context)
            {
                departureRecord = _context.DepartureRecords.Where(x => x.Id == id).FirstOrDefault();
            }
            return departureRecord;
        }
        public void Update(IDepartureRecord departureRecord, DateTime returnTime, int odometerAfterLeaving, bool away)
        {
            using (_context)
            {
                _context.DepartureRecords.Where(x => x.Equals(departureRecord)).FirstOrDefault()
                    .Car.Away = away;

                _context.DepartureRecords.Where(x => x.Equals(departureRecord)).FirstOrDefault()
                    .ReturnTime = returnTime;

                _context.DepartureRecords.Where(x => x.Equals(departureRecord)).FirstOrDefault()
                    .OdometerAfterLeaving = odometerAfterLeaving;

                _context.SaveChanges();
            }
        }
        public void Delete(IDepartureRecord departureRecord)
        {
            using (_context)
            {
                _context.Remove<IDepartureRecord>(departureRecord);

                _context.SaveChanges();
            }
        }
    }
}
