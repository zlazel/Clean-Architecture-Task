using Clean_Architecture_Task.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Clean_Architecture_Task.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
