using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barn.Services
{
    public interface ISpotifyAcoountService 
    {
        Task<string> GetToken(string clientId, string clientSecret);
    }
}
