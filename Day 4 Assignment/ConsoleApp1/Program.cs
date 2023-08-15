namespace ConsoleApp1
{
    public class Athlete
    {
        public int AthleteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sport { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
    }
    public class SportzClubManager
    {
        private List<Athlete> athletes = new List<Athlete>();
        private List<Event> events = new List<Event>();
        private Dictionary<int, Dictionary<int, string>> athletePerformance = new Dictionary<int, Dictionary<int, string>>();

        
        public int RegisterAthlete(string firstName, string lastName, int age, string sport, DateTime registrationDate)
        {
            int athleteId = athletes.Count + 1;
            var athlete = new Athlete
            {
                AthleteId = athleteId,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Sport = sport,
                RegistrationDate = registrationDate
            };
            athletes.Add(athlete);
            return athleteId;
        }

        public string ViewAthleteDetails(int athleteId)
        {
            Athlete athlete = athletes.FirstOrDefault(a => a.AthleteId == athleteId);
            if (athlete != null)
            {
                return $"Name: {athlete.FirstName} {athlete.LastName}\nAge: {athlete.Age}\nSport: {athlete.Sport}\nRegistration Date: {athlete.RegistrationDate}";
            }
            else
            {
                return "Athlete not found.";
            }
        }

        public string UpdateAthleteDetails(int athleteId, string firstName, string lastName, int age, string sport)
        {
            Athlete athlete = athletes.FirstOrDefault(a => a.AthleteId == athleteId);
            if (athlete != null)
            {
                athlete.FirstName = firstName;
                athlete.LastName = lastName;
                athlete.Age = age;
                athlete.Sport = sport;
                return "Update successful.";
            }
            else
            {
                return "Athlete not found.";
            }
        }

        public string RemoveAthlete(int athleteId)
        {
            Athlete athlete = athletes.FirstOrDefault(a => a.AthleteId == athleteId);
            if (athlete != null)
            {
                athletes.Remove(athlete);
               
                athletePerformance.Remove(athleteId);
                return "Athlete removed successfully.";
            }
            else
            {
                return "Athlete not found.";
            }
        }

        
        public int CreateEvent(string eventName, string eventType, DateTime eventDate)
        {
            int eventId = events.Count + 1;
            var newEvent = new Event
            {
                EventId = eventId,
                EventName = eventName,
                EventType = eventType,
                EventDate = eventDate
            };
            events.Add(newEvent);
            return eventId;
        }

        public string ViewEventDetails(int eventId)
        {
            Event evnt = events.FirstOrDefault(e => e.EventId == eventId);
            if (evnt != null)
            {
                return $"Event Name: {evnt.EventName}\nEvent Type: {evnt.EventType}\nEvent Date: {evnt.EventDate}";
            }
            else
            {
                return "Event not found.";
            }
        }

        public string UpdateEventDetails(int eventId, string eventName, string eventType, DateTime eventDate)
        {
            Event evnt = events.FirstOrDefault(e => e.EventId == eventId);
            if (evnt != null)
            {
                evnt.EventName = eventName;
                evnt.EventType = eventType;
                evnt.EventDate = eventDate;
                return "Update successful.";
            }
            else
            {
                return "Event not found.";
            }
        }

        public string RemoveEvent(int eventId)
        {
            Event evnt = events.FirstOrDefault(e => e.EventId == eventId);
            if (evnt != null)
            {
                events.Remove(evnt);
                
                foreach (var performanceData in athletePerformance.Values)
                {
                    performanceData.Remove(eventId);
                }
                return "Event removed successfully.";
            }
            else
            {
                return "Event not found.";
            }
        }

       
        public void RecordAthletePerformance(int athleteId, int eventId, string performanceData)
        {
            if (!athletePerformance.ContainsKey(athleteId))
            {
                athletePerformance[athleteId] = new Dictionary<int, string>();
            }
            athletePerformance[athleteId][eventId] = performanceData;
        }

        public string ViewAthletePerformance(int athleteId, int eventId)
        {
            if (athletePerformance.ContainsKey(athleteId) && athletePerformance[athleteId].ContainsKey(eventId))
            {
                return athletePerformance[athleteId][eventId];
            }
            else
            {
                return "Performance data not found.";
            }
        }

        // Data Analysis using LINQ
        public List<Athlete> GetAthletesBySport(string sport)
        {
            return athletes.Where(a => a.Sport == sport).ToList();
        }

        public List<Event> GetEventsByType(string eventType)
        {
            return events.Where(e => e.EventType == eventType).ToList();
        }

        public Dictionary<string, string> GetAthletePerformanceInAllEvents(int athleteId)
        {
            Dictionary<string, string> performanceInAllEvents = new Dictionary<string, string>();
            if (athletePerformance.ContainsKey(athleteId))
            {
                foreach (var eventId in athletePerformance[athleteId].Keys)
                {
                    Event evnt = events.FirstOrDefault(e => e.EventId == eventId);
                    if (evnt != null)
                    {
                        performanceInAllEvents[evnt.EventName] = athletePerformance[athleteId][eventId];
                    }
                }
            }
            return performanceInAllEvents;
        }

        public List<Event> GetUpcomingEvents()
        {
            DateTime currentDate = DateTime.Now;
            return events.Where(e => e.EventDate > currentDate).ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SportzClubManager clubManager = new SportzClubManager();

            int athleteId1 = clubManager.RegisterAthlete("Dhruv", "Solanki", 25, "Cricket", DateTime.Now.AddDays(-100));
            int athleteId2 = clubManager.RegisterAthlete("Shruti", "Chaube", 22, "Cricket", DateTime.Now.AddDays(-150));

            int eventId1 = clubManager.CreateEvent("IPL Tournament", "Tournament", DateTime.Now.AddDays(30));
            

            int eventId2 = clubManager.CreateEvent("IPL Session", "Practice", DateTime.Now.AddDays(15));

            clubManager.RecordAthletePerformance(athleteId1, eventId1, "Scored 2 goals");
            clubManager.RecordAthletePerformance(athleteId1, eventId2, "Participated actively");
            clubManager.RecordAthletePerformance(athleteId2, eventId1, "Made 5 goals");

           
            Console.WriteLine(clubManager.ViewAthleteDetails(athleteId1));
            Console.WriteLine(clubManager.ViewAthleteDetails(athleteId2));

           
            Console.WriteLine(clubManager.UpdateAthleteDetails(athleteId1, "Aditya", "Pandey", 26, "Football"));
            Console.WriteLine(clubManager.UpdateAthleteDetails(3, "Invalid", "Athlete", 30, "Invalid Sport"));

           
            Console.WriteLine(clubManager.RemoveAthlete(athleteId2));
            Console.WriteLine(clubManager.RemoveAthlete(3));

      
            Console.WriteLine(clubManager.ViewEventDetails(eventId1));
            Console.WriteLine(clubManager.ViewEventDetails(3));

        
            Console.WriteLine(clubManager.UpdateEventDetails(eventId1, "EPL Tournament", "Tournament", DateTime.Now.AddDays(60)));
            Console.WriteLine(clubManager.UpdateEventDetails(3, "Invalid Event", "Invalid Type", DateTime.Now));


            Console.WriteLine(clubManager.RemoveEvent(eventId2));
            Console.WriteLine(clubManager.RemoveEvent(3));

            
            Console.WriteLine(clubManager.ViewAthletePerformance(athleteId1, eventId1));
            Console.WriteLine(clubManager.ViewAthletePerformance(athleteId1, eventId2));
            Console.WriteLine(clubManager.ViewAthletePerformance(3, eventId1));

         
            List<Athlete> soccerPlayers = clubManager.GetAthletesBySport("Football");
            foreach (var athlete in soccerPlayers)
            {
                Console.WriteLine($"{athlete.FirstName} {athlete.LastName}");
            }

      
            List<Event> tournamentEvents = clubManager.GetEventsByType("Tournament");
            foreach (var evnt in tournamentEvents)
            {
                Console.WriteLine($"{evnt.EventName} - {evnt.EventType}");
            }

            Dictionary<string, string> athletePerformance = clubManager.GetAthletePerformanceInAllEvents(athleteId1);
            foreach (var kvp in athletePerformance)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            List<Event> upcomingEvents = clubManager.GetUpcomingEvents();
            foreach (var evnt in upcomingEvents)
            {
                Console.WriteLine($"{evnt.EventName} - {evnt.EventDate}");
            }
        }
    }
}

