using SCABaseApplication.DataAccess.DataModels;
using SCABaseApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCABaseApplication.DataAccess.DataServices
{
    /// <summary>
    /// A Data Access Service to get the Schedules
    /// </summary>
    public class ScheduleService
    {
        /// <summary>
        /// Get all the schedules for a specific Facility and week
        /// </summary>
        /// <param name="FacilityId">The Facility to use</param>
        /// <param name="Day"></param>
        /// <returns></returns>
        public List<ScheduleModel> GetSchedules(string FacilityId, DateTime Day)
        {            
            //TODO this should have Access Control based on who is logged in

            // Get teh DB context, this would normally be injected in.
            SchedulingDbContext scheduleContext = new SchedulingDbContext();

            //Determine the start and end of the week
            DateTime start = Day;
            if (Day.DayOfWeek != DayOfWeek.Monday)
            {
                start.AddDays(0 - (Day.DayOfWeek - 1));
            }

            DateTime end = start.AddDays(6);

            // Get the facility they want the schedule for
            FacilityDataModel facility = (from facil in scheduleContext.Facilities
                                          where facil.FacilityId == FacilityId
                                          select facil).Single();

            // Get teh TeamMembers for that facility
            List<TeamMemberDataModel> team = (from member in scheduleContext.TeamMember
                                              where member.CurrentFacility == facility
                                              select member).ToList();

            List<ScheduleModel> results = new List<ScheduleModel>();

            // yes this isn't the most effeicent way to do this, but it's the most straight forward and readable
            // Normally I'd set up something like auto mapper for this
            foreach (TeamMemberDataModel member in team)
            {
                // set up a default object for the team member
                ScheduleModel schedule = new ScheduleModel()
                {
                    TeammateName = member.TeammateName,
                    TeammateType = member.TeammateType,
                    Monday = "None",
                    Tuesday = "None",
                    Wednesday = "None",
                    Thursday = "None",
                    Friday = "None",
                    Saturday = "None",
                    Sunday = "None",
                };

                // Get each day in their schedule
                List<TeamMemberDayScheduleDataModel> daily = (from day in scheduleContext.TeamMemberDaySchedule
                                                  where day.TeamMember == member
                                                    && day.Date >= start && day.Date <= end
                                                  select day).ToList();

                // Assign the values for each Day
                foreach (TeamMemberDayScheduleDataModel day in daily)
                {
                    if (day.Date.DayOfWeek == DayOfWeek.Monday)
                        schedule.Monday = day.Schedule;
                    if (day.Date.DayOfWeek == DayOfWeek.Tuesday)
                        schedule.Tuesday = day.Schedule;
                    if (day.Date.DayOfWeek == DayOfWeek.Wednesday)
                        schedule.Wednesday = day.Schedule;
                    if (day.Date.DayOfWeek == DayOfWeek.Thursday)
                        schedule.Thursday = day.Schedule;
                    if (day.Date.DayOfWeek == DayOfWeek.Friday)
                        schedule.Friday = day.Schedule;
                    if (day.Date.DayOfWeek == DayOfWeek.Saturday)
                        schedule.Saturday = day.Schedule;
                    if (day.Date.DayOfWeek == DayOfWeek.Sunday)
                        schedule.Sunday = day.Schedule;
                }

                results.Add(schedule);
            }
                        
            return results;
        }
    }
}
