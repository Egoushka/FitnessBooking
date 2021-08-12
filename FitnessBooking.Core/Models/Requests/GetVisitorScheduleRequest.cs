using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessBooking.Core.Models.Requests
{
    public class GetVisitorScheduleRequest
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? VisitorScheduleId { get; set; }
        public GetVisitorScheduleRequest(int? id, int? userId, int? visitorScheduleId)
        {
            this.Id = id;
            this.UserId = userId;
            this.VisitorScheduleId = visitorScheduleId;
        }
    }
}
