using System;

namespace Mc2.CrudTest.Application.Infrastructure
{
    public interface ICommand<TDto> 
    {
        void Execute(TDto dto);
        void Execute(Guid id, TDto dto);
    }
}
