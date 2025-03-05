using Microsoft.AspNetCore.Components;

namespace PokeBuilderMAUI.Shared.Models
{
    public interface IDisplayPokemon
    {
        public RenderFragment ChildContent { get; }
        public Pokemon GetPokemon { get; }
    }
}
