using DDCatalogue.Model.Auth;

namespace DDCatalogue.Model
{
    public interface IOwned : IBase
    {
        Account Owner { get; set; }
    }
}