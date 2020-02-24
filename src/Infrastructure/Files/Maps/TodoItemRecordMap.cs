using Clean_Architecture_Task.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace Clean_Architecture_Task.Infrastructure.Files.Maps
{
    public class TodoItemRecordMap : ClassMap<TodoItemRecord>
    {
        public TodoItemRecordMap()
        {
            AutoMap();
            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
