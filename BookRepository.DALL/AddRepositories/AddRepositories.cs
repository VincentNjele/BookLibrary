using BookRepository.DALL.Repositories;
using BookService.DALL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookRepository.DALL.AddRepositories
{
    public static class AddRepositories
    {
        public static IServiceCollection AddRepository ( this IServiceCollection service)
        {
            service.AddTransient<IBookService, BookRepositories>();
            return service;
        }
    }
}
