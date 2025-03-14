﻿using System.Text.Json.Serialization;

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

    public class Pokemon
    {
        public static List<Pokemon> AllPokemon { get; set; } = null;
        public Pokemon(bool isPopulated = true) {
            Id = _nextId++;
            if (!isPopulated)
            {
                Name = "Testasaur";
                Primary = Type.GRASS;
                Secondary = Type.TYPELESS;
                Ability = null;
                Abilities = new List<string> { "Overgrow", "Chlorophyll" };
                Move1 = null;
                Move2 = null;
                Move3 = null;
                Move4 = null;
                Moves = new List<string> { "Tackle", "Razor Leaf", "Growl", "Leech Seed", "Vine Whip", "Poison Powder", "Sleep Powder", "Sweet Scent", "Growth", "Synthesis", "Solarbeam" };
                BaseHealth = 45;
                BaseAttack = 49;
                BaseDefense = 49;
                BaseSpAttack = 65;
                BaseSpDefense = 65;
                BaseSpeed = 45;
                Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/1.png";
            }
        }
        public int Id { get; private set; }
        private int _nextId = 0;

        [JsonPropertyName("name")]
        public string? Name { get; set; }
        public Type Primary { get; private set; }
        public Type Secondary { get; private set; }
        public string? Ability { get; set; }
        public List<string>? Abilities { get; set; }
        public List<string> Moves { get; set; }
        public string? Move1 { get; set; }
        public string? Move2 { get; set; }
        public string? Move3 { get; set; }
        public string? Move4 { get; set; }
        public int BaseHealth { get; private set; }
        public int BaseAttack { get; private set; }
        public int BaseDefense { get; private set; }
        public int BaseSpAttack { get; private set; }
        public int BaseSpDefense { get; private set; }
        public int BaseSpeed { get; private set; }
        public string? Image { get; private set; }
        public int NationalDexNumber { get; set; } 

        public Pokemon(string name, Type primary, Type secondary,
                            string ability, List<string> moves, int baseHP,
                            int baseATK, int baseDEF, int baseSPATK,
                            int baseSPDEF, int baseSPD, string image, int nationalDexNumber)
        {
            Name = name; Primary = primary; Secondary = secondary;
            Ability = ability; Moves = moves;
            BaseHealth = baseHP; BaseAttack = baseATK; BaseDefense = baseDEF;
            BaseSpAttack = baseSPATK; BaseSpDefense = baseSPDEF;
            BaseSpeed = baseSPD; Image = image;
            NationalDexNumber = nationalDexNumber;
        }

        public Pokemon(string name, Type primary, Type secondary, string ability,
    string move1, string move2, string move3, string move4,
    int baseHP, int baseATK, int baseDEF, int baseSPATK, int baseSPDEF, int baseSPD,
    string image, int nationalDexNumber)
        {
            Name = name; Primary = primary; Secondary = secondary; ability = ability;
            Move1 = move1; Move2 = move2; Move3 = move3; Move4 = move4;
            BaseHealth = baseHP; BaseAttack = baseATK; BaseDefense = baseDEF; BaseSpAttack = baseSPATK; BaseSpDefense = baseSPDEF; BaseSpeed = baseSPD;
            Image = image; NationalDexNumber = nationalDexNumber;
        }

    }
}
