namespace HLO_API.Dtos
{
    public class CharacterDtos
    {
        public int PlayerID { get; set; }

        public string PlayerName { get; set; } = null!;

        public int Level { get; set; }

        public float? HP { get; set; }

        public float? MP { get; set; }

        public double? Exp { get; set; }

        //public int? JobId { get; set; }

        public int? RaceId { get; set; }

        public int? Coin { get; set; }
        public int? BagCount { get; set; }

        public string JobName { get; set; }
        public string RaceName { get; set; }

    }
}
