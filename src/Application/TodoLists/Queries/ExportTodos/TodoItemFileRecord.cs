using Clean_Architecture_Task.Application.Common.Mappings;
using Clean_Architecture_Task.Domain.Entities;

namespace Clean_Architecture_Task.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
