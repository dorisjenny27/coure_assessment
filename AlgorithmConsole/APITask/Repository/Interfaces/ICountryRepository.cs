using APITask.Models.DTOs;

namespace APITask.Repository.Interfaces
{
    public interface ICountryRepository
    {
        Task<Response> GetCountryByNumber(string number);
    }
}