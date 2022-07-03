namespace CarDepartureLogApp.Models.Interfaces
{
    public interface IDepartureRecord
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Время выезда
        /// </summary>
        public DateTime DepartureTime { get; set; }
        /// <summary>
        /// Время возвращения
        /// </summary>
        public DateTime ReturnTime { get; set; }
        /// <summary>
        /// Показания одометра при выезде
        /// </summary>
        public int OdometerBeforeLeaving { get; set; }
        /// <summary>
        /// Показания одометра по возвращении
        /// </summary>
        public int OdometerAfterLeaving { get; set; }
        /// <summary>
        /// Цель выезда
        /// </summary>
        public string PurposeOfDeparture { get; set; }
        /// <summary>
        /// Примечания
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Внешний ключ к таблице Cars
        /// </summary>
        public int CarId { get; set; }
        /// <summary>
        /// Внешний ключ к таблице Driver
        /// </summary>
        public int DriverId { get; set; }
        
        /// <summary>
        /// Навигационное свойство автомобиль в текущей записи
        /// </summary>
        public Car? Car { get; set; }
        /// <summary>
        /// Навигационное свойство водитель автомобиля в текущей записи
        /// </summary>
        public Driver? Driver { get; set; }       
    }
}
