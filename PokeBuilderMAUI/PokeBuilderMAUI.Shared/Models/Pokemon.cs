﻿using System;
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
        public Pokemon(bool isPopulated = true) {
            if(!isPopulated)
            {
                Name = "Testasaur";
                Primary = Type.GRASS;
                Secondary = Type.TYPELESS;
                Ability = "Overgrow";
                Moves = ["Tackle", "Growl", "Leech Seed", "Vine Whip"];
                BaseHealth = 45;
                BaseAttack = 49;
                BaseDefense = 49;
                BaseSpAttack = 65;
                BaseSpDefense = 65;
                BaseSpeed = 45;
                Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/1.png";
            }
        }
        private static string? name;

        public string? Name { get; private set; }
        public Type Primary { get; private set; }
        public Type Secondary { get; private set; }
        public string? Ability { get; private set; }
        public string[] Moves { get; private set; }
        public int BaseHealth { get; private set; }
        public int BaseAttack { get; private set; }
        public int BaseDefense { get; private set; }
        public int BaseSpAttack { get; private set; }
        public int BaseSpDefense { get; private set; }
        public int BaseSpeed { get; private set; }
        public string? Image { get; private set; }

        public Pokemon(string name, Type primary, Type secondary,
                            string ability, string[] moves, int baseHP,
                            int baseATK, int baseDEF, int baseSPATK,
                            int baseSPDEF, int baseSPD, string image)
        {
            Name = name; Primary = primary; Secondary = secondary;
            Ability = ability; Moves = moves;
            BaseHealth = baseHP; BaseAttack = baseATK; BaseDefense = baseDEF;
            BaseSpAttack = baseSPATK; BaseSpDefense = baseSPDEF;
            BaseSpeed = baseSPD; Image = image;
        }
    }
}
