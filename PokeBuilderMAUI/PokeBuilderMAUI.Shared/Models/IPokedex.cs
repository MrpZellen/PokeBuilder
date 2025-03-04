using Microsoft.AspNetCore.Components;

namespace PokeBuilderMAUI.Shared.Models
{
    public interface IPokedex
    {
        RenderFragment RenderPokedex { get; }
    }
}
