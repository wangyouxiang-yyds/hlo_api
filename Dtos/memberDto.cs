namespace HLO_API.Dtos
{
    public class memberDto
    {

        public string? Account { get; set; }

        public string? password { get; set; }

        public string? username { get; set; }

        public DateTime? createtime { get; set; }

        public string? GUID { get; set; }

        public ICollection<CharacterDtos> Character { get; set; }
    }
}
