namespace CarDepartureLogApp.Models.Interfaces
{
    public interface ICar
    {
        /// <summary>
        /// ID автомобиля
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Регистрационный номер автомобиля
        /// </summary>
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// Марка автомобиля
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// Модель автомобиля
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Состояние на выезде/в гараже
        /// </summary>
        public bool Away { get; set; }

        /// <summary>
        /// Навигационное свойство список записей о выездах данного автомобиля
        /// </summary>
        public List<IDepartureRecord> DepartureRecords { get; set; }
    }
}
