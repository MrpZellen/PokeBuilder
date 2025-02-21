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
        private static string? name;

        public readonly string? Name = name;
        public readonly Type Primary;
        public readonly Type Secondary = Type.TYPELESS;
        public readonly string? Ability;
        public readonly List<string>? Abilities;
        public readonly string[] Moves = new string[4];
        public readonly int BaseHealth;
        public readonly int BaseAttack;
        public readonly int BaseDefense;
        public readonly int BaseSpAttack;
        public readonly int BaseSpDefense;
        public readonly int BaseSpeed;
        public readonly string? Image;

        Pokemon GetPokemon(string name, Type primary, Type secondary,
                            string ability, string[] moves, int baseHP,
                            int baseATK, int baseDEF, int baseSPATK,
                            int baseSPDEF, int baseSPD, string image)
        {
            moves = new string[4];

            throw new NotImplementedException();
        }
    }
}
