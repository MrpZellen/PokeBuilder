using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeBuilderMAUI.Shared.Models
{
    public class PokemonTeam
    {
        public Pokemon[] Team { get; set; } = new Pokemon[6];
    }
}
