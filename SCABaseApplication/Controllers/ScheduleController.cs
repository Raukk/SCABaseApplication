using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCABaseApplication.DataAccess.DataServices;
using SCABaseApplication.Models;

namespace SCABaseApplication.Controllers
{

    //TODO there should be access control on this if it were a real app
    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {
        private ScheduleService service { get; set; }

        public ScheduleController()
        {
            //TODO this should use Dependency Injection
            service = new ScheduleService();
        }

        [HttpGet("[action]/{FacilityId}/{Date}")]
        public IEnumerable<ScheduleModel> Schedules(string FacilityId, string Date)
        {
            DateTime day = DateTime.Parse(Date);

            return service.GetSchedules(FacilityId, day);
        }

        [HttpGet("[action]/{FacilityId}/{Date}")]
        public HttpResponseMessage SchedulesCsv(string FacilityId, string Date)
        {
            DateTime day = DateTime.Parse(Date);
            string csvString = "";
            foreach (var Schedule in service.GetSchedules(FacilityId, day))
            {
                if (false == string.IsNullOrEmpty(csvString))
                {
                    csvString += Environment.NewLine;
                }

                // create a quick array of the values
                string[] myValues = new string[]
                {
                    Schedule.TeammateName,
                    Schedule.TeammateType,
                    Schedule.Monday,
                    Schedule.Tuesday,
                    Schedule.Wednesday,
                    Schedule.Thursday,
                    Schedule.Friday,
                    Schedule.Saturday,
                    Schedule.Sunday
                };

                List<string> cleanedValues = new List<string>();
                // Replace and " in the data with "" (escaped quote)
                // If the value contains a comma then Qote the whole value to escape that quote
                foreach (string value in myValues)
                {

                    string cleanValue = value.Replace("\"", "\"\"");

                    if (cleanValue.Contains(','))
                    {
                        cleanValue = '"' + cleanValue + '"';
                    }

                    cleanedValues.Add(cleanValue);

                }                

                // yes string builder is more efficent
                csvString += string.Join(",", cleanedValues);
            }

            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(csvString);
            writer.Flush();
            stream.Position = 0;

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StringContent(csvString);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/csv");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Export.csv" };
            return result;

        }       

    }
}
