using SuperHeroAPI_DotNet7.Models;

namespace SuperHeroAPI_DotNet7.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoinsts { get; set; } = 100;
        public int Strenght { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelliegence { get; set; } = 10;
        public RpgClass RpgClass { get; set; } = RpgClass.Knight;

    }
}
