namespace AspNetCore.Models
{       /// <summary>
        /// Статистика по всем турам
        /// </summary>
    public class StatusTour
    {
        /// <summary>
        /// Общее кол-во туров
        /// </summary>
        public int NumberOfToursStatus { get; set; }
        /// <summary>
        /// Общая сумма
        /// </summary>
        public decimal TotalCostStatus { get; set; }
        /// <summary>
        /// Общее кол-во туров c доплатами
        /// </summary>
        public int NumberOfToursWithSurchargesStatus { get; set; }
        /// <summary>
        /// Общая сумма доплат
        /// </summary>
        public decimal TotalCostSurchargesStatus { get; set; }
    }
}
