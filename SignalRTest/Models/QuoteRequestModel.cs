using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRTest.Models
{
    public class QuoteRequestModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string[] SubscribedGroups { get; set; }
    }
}