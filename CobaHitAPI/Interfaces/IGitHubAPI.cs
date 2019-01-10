using CobaHitAPI.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CobaHitAPI.Interfaces
{
    public interface IGitHubAPI
    {
        [Headers("User-Agent: CobaHitAPI")]
        [Get("/users/{user}")]
        Task<User> GetUser(string user);
    }
}
