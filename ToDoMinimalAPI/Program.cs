using ToDoMinimalAPI.Data;
using ToDoMinimalAPI.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//GERENCIA CONECXÃO COM BANCO DE DADOS
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("v1/todos", (AppDbContext context) =>
{
    var todos = context.Todos.ToList();
    return Results.Ok(todos);
});

app.MapPost("v1/todos", (
    AppDbContext context,
    CreateTodoViewModel model) =>
{
    var todo = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);

    context.Todos.Add(todo);
    context.SaveChanges();

    return Results.Created($"/v1/todos/{todo.Id}", todo);
});





app.Run();

