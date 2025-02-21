using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeBuilderMAUI.Shared.Models
{
    public enum Type
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
        private static Type primary;
        private static Type secondary = Type.TYPELESS;
        private static string? ability;
        private static List<string>? abilities;
        private static List<string> moves;
        private static string[] finalMoves = new string[4];
        private static int baseHealth;
        private static int baseAttack;
        private static int baseDefense;
        private static int baseSPAttack;
        private static int baseSPDefense;
        private static int baseSpeed;
        private static string? image;

        public readonly string? Name = name;
        public readonly Type Primary = primary;
        public readonly Type Secondary = secondary;
        public readonly string? Ability = ability;
        public readonly string[] Moves = finalMoves;
        public readonly int BaseHealth = baseHealth;
        public readonly int BaseAttack = baseAttack;
        public readonly int BaseDefense = baseDefense;
        public readonly int BaseSpAttack = baseSPAttack;
        public readonly int BaseSpDefense = baseSPDefense;
        public readonly int BaseSpeed = baseSpeed;
        public readonly string? Image = image;

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
