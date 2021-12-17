using System;
using System.Collections.Generic;
using System.Text;

namespace ANOMS.Domain.Entities
{
    public class ResponseModel
    {
        public int MessageCode { get; set; }
        public string MessageText { get; set; }
        public bool DatabseTracking { get; set; } = true;
        public int TotalCount { get; set; }
        public dynamic Data { get; set; }
    }
}
