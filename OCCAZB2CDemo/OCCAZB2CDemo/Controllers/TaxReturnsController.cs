using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OCCAZB2CDemo.Model;

namespace OCCAZB2CDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/TaxReturns")]
    public class TaxReturnsController : Controller
    {
        [HttpGet]
        [Authorize]

        public IEnumerable<TaxReturns> GetAllTaxReturns()
        {
            var allTaxReturns = new List<TaxReturns>()
            {
                new TaxReturns{Year="2010" , TaxPaid="You gotta be kidding me"},
                new TaxReturns{Year="2011" , TaxPaid="Your're Fired !"},
                new TaxReturns{Year="2012" , TaxPaid="King Kong Ain't got nothing on me!"},
                new TaxReturns{Year = "2013", TaxPaid="Can you believe Mueller ? "},
                new TaxReturns{Year = "2014", TaxPaid="ZILCH !"},
                new TaxReturns{Year="2015", TaxPaid="Nada"},
                new TaxReturns{Year="2016",TaxPaid="$0"},
                new TaxReturns{Year="2017", TaxPaid="$1"},
                new TaxReturns{Year="2018", TaxPaid="The country owes me, I don't pay Jack!"}
            };

            return allTaxReturns;
        }
    }
}