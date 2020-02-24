using Clean_Architecture_Task.Application.Common.Mappings;
using Clean_Architecture_Task.Domain.Entities;
using System.Collections.Generic;

namespace Clean_Architecture_Task.Application.TodoLists.Queries.GetTodos
{
    public class TodoListDto : IMapFrom<TodoList>
    {
        public TodoListDto()
        {
            Items = new List<TodoItemDto>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public IList<TodoItemDto> Items { get; set; }
    }
}
