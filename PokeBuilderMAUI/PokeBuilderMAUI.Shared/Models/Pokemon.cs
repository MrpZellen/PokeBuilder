using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeBuilderMAUI.Shared.Models
{
    enum Type
    {
        TYPELESS,
        NORMAL,
        GRASS,
        WATER,
        FIRE,
        BUG,
        GROUND,
        ROCK,
        FLYING,
        FIGHTING,
        PSYCHIC,
        GHOST,
        STEEL,
        DARK,
        DRAGON,
        FAIRY,
        ICE,
        ELECTRIC,
        POISON
    }

    class Pokemon
    {
        string? name { get; set; }
        Type primary { get; set; }
        Type secondary { get; set; } = Type.TYPELESS;
        string? ability { get; set; }
        List<string>? abilities { get; set; }
        string[] moves = new string[4];
        int baseHealth { get; set; }
        int baseAttack { get; set; }
        int baseDefense { get; set; }
        int baseSpAttack { get; set; }
        int baseSpDefense { get; set; }
        int baseSpeed { get; set; }
        string? image { get; set; }
    }
}
