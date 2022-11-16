namespace AspNetCore.Models
{   

    public class AddTourRequestModel
    {
        public Direction Direction { get; set; }
        /// <summary>
        /// Дату вылета
        /// </summary>
        public DateTime Departure { get; set; }
        /// <summary>
        /// Кол-во ночей
        /// </summary>
        public int NumberOfNights { get; set; }
        /// <summary>
        /// Стоимость за отдыхающего (₽)
        /// </summary>
        public decimal CostVacationer { get; set; }
        /// <summary>
        /// Кол-во отдыхающих
        /// </summary>
        public int NumberOfVacationers { get; set; }
        /// <summary>
        /// Наличие Wi-Fi
        /// </summary>
        public bool WiFi { get; set; }
        /// <summary>
        /// Доплаты (₽)
        /// </summary>
        public decimal Surcharges { get; set; }
    }
}
