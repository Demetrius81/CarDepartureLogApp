namespace CarDepartureLogApp.Models.Interfaces
{
    public interface IDriver
    {
        /// <summary>
        /// ID водителя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя водителя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество водителя
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Фамилия водителя
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Навигационное свойство список записей о выездах данного водителя
        /// </summary>
        public List<DepartureRecord> DepartureRecords { get; set; }
    }
}
