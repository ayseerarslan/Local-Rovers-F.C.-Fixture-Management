using CA3Sample.Models;
using System.Collections.Generic;
using System.Linq;


namespace CA3Sample.Services
{
    public static class FixtureService
    {
        private static List<Fixture> fixtures = new List<Fixture>();
        private static int nextId = 1;

        public static List<Fixture> GetAll() => fixtures;

        public static Fixture GetById(int id) => fixtures.FirstOrDefault(f => f.MatchId == id);

        public static void Add(Fixture fixture)
        {
            fixture.MatchId = nextId++;
            fixtures.Add(fixture);
        }

        public static void Update(Fixture fixture)
        {
            var existing = GetById(fixture.MatchId);
            if (existing != null)
            {
                existing.Venue = fixture.Venue;
                existing.OpponentTeam = fixture.OpponentTeam;
                existing.DateTime = fixture.DateTime;
                existing.GoalsFor = fixture.GoalsFor;
                existing.GoalsAgainst = fixture.GoalsAgainst;
            }
        }
    }
}