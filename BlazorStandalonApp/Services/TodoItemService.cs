using System.Net.Http.Json;
using BlazorStandalonApp.Shared;

namespace BlazorStandalonApp.Services;

public class TodoItemService(HttpClient http)
{
    public async Task<List<TodoItem>> GetTodoItemsAsync()
    {
        return await http.GetFromJsonAsync<List<TodoItem>>("http://localhost:5298/api/todoitems");
    }

    public async Task AddTodoItemAsync(TodoItem item)
    {
        await http.PostAsJsonAsync("http://localhost:5298/api/todoitems", item);
    }
}