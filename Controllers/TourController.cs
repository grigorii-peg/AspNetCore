using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController: ControllerBase
    {
        private static readonly IList<Tour> Tours = new List<Tour>();

        [HttpGet]
        public IEnumerable<Tour> Get()
        {
            return Tours;
        }

        [HttpGet("statistics")]
        public StatusTour GetStatistics()
        {
            var status = new StatusTour()
            {
                NumberOfToursStatus = Tours.Count(),
                TotalCostStatus = Tours.Sum(x => (x.NumberOfNights * x.NumberOfVacationers * x.CostVacationer) + x.Surcharges),
                NumberOfToursWithSurchargesStatus = Tours.Where(x => x.Surcharges != 0).Count(),
                TotalCostSurchargesStatus = Tours.Sum(x => x.Surcharges),
            };
           return status;
        } 
        [HttpPost]
        public Tour AddTours(AddTourRequestModel model)
        {
            var ModelTours = new Tour()
            {
                Id = Guid.NewGuid(),
                Direction = model.Direction,
                Departure = model.Departure,
                NumberOfNights = model.NumberOfNights,
                CostVacationer = model.CostVacationer,
                NumberOfVacationers = model.NumberOfVacationers,
                WiFi = model.WiFi,
                Surcharges = model.Surcharges,
                TotalCostAmount = (model.NumberOfNights * model.NumberOfVacationers * model.CostVacationer) + model.Surcharges,
            };
            Tours.Add(ModelTours);
            return ModelTours;
        }
        [HttpPut("{id}")]
        public Tour EditTours([FromRoute] Guid id, [FromBody] AddTourRequestModel model)
        {
            var TargetTour = Tours.FirstOrDefault(x => x.Id == id);
            if (TargetTour != null)
            {
                TargetTour.Direction = model.Direction;
                TargetTour.Departure = model.Departure;
                TargetTour.NumberOfNights = model.NumberOfNights;
                TargetTour.CostVacationer = model.CostVacationer;
                TargetTour.NumberOfVacationers = model.NumberOfVacationers;
                TargetTour.WiFi = model.WiFi;
                TargetTour.Surcharges = model.Surcharges;
                TargetTour.TotalCostAmount = (model.NumberOfNights * model.NumberOfVacationers * model.CostVacationer) + model.Surcharges;

                var index = Tours.IndexOf(TargetTour);
                Tours[index] = TargetTour;
            }
            return TargetTour;
        }

        [HttpDelete("{id}")]
        public bool DeleteTours(Guid id)
        {
            var TargetTour = Tours.FirstOrDefault(x => x.Id == id);
            if (TargetTour != null)
            {
                return Tours.Remove(TargetTour);
            }
            return false;
        }

    }
}
