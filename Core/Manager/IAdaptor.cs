using Model;

namespace Core.Manager
{
    public interface IAdaptor<I,O>
    {
        /// <summary>
        /// Adapt soecifed input 
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        O adapt(I entry);
    }
}