using Bogus;
using MetaMapper.Tests.TestModels;

namespace MetaMapper.Tests.Infrastructure;

public static class DataGenerator
{
    private static int _nextId = 1;

    private static int GetNextId() => _nextId++;

    private static Guid GetNextGlobalId() => Guid.NewGuid();

    public static TodoListEntity GenerateTodoList()
    {
        var userFaker = new Faker<UserEntity>()
                .RuleFor(u => u.Id, _ => GetNextId())
                .RuleFor(u => u.GlobalId, _ => GetNextGlobalId())
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Email, f => f.Internet.Email());

        var tagFaker = new Faker<TagEntity>()
                .RuleFor(t => t.Id, _ => GetNextId())
                .RuleFor(t => t.GlobalId, _ => GetNextGlobalId())
                .RuleFor(t => t.Name, f => f.Random.Word());

        var commentFaker = new Faker<CommentEntity>()
                .RuleFor(c => c.Id, _ => GetNextId())
                .RuleFor(c => c.GlobalId, _ => GetNextGlobalId())
                .RuleFor(c => c.Content, f => f.Lorem.Paragraph());

        var todoItemFaker = new Faker<TodoItemEntity>()
                .RuleFor(t => t.Id, _ => GetNextId())
                .RuleFor(t => t.GlobalId, _ => GetNextGlobalId())
                .RuleFor(t => t.Description, f => f.Lorem.Sentence())
                .RuleFor(t => t.DueDate, f => f.Date.Future())
                .RuleFor(t => t.IsCompleted, f => f.Random.Bool());

        var todoItems = todoItemFaker.Generate(5);
        var comments = commentFaker.Generate(2);
        var tags = tagFaker.Generate(3);
        var user = userFaker.Generate();

        var todoList = new TodoListEntity
        {
            Id = GetNextId(),
            GlobalId = GetNextGlobalId(),
            Title = "black white 24/7",
            Description =
                    "Sequi quia et qui qui tempore accusamus. Molestiae necessitatibus ut. Quia sint fugiat consequuntur perferendis at omnis est. Similique est qui temporibus autem occaecati ex eum.",
            CreatedAt = DateTime.Now,
            DueDate = DateTime.Now.AddDays(80),
            IsCompleted = true,
            Priority = 10,
            Category = "Colombian Peso",
            AssignedTo = "Melba Buckridge",
            CreatedBy = "Melba Buckridge",
            UserId = user.Id,
            User = user,
            Tags = tags,
            Comments = comments,
            Items = todoItems,
            ModifiedBy = "fooBar"
        };

        foreach (var item in todoItems)
        {
            item.Id = GetNextId();
            item.GlobalId = GetNextGlobalId();
            item.TodoListId = todoList.Id;
            item.TodoList = todoList;
            item.Comments = comments;
            foreach (var comment in comments)
            {
                comment.Id = GetNextId();
                comment.GlobalId = GetNextGlobalId();
                comment.TodoListId = todoList.Id;
                comment.TodoItemId = item.Id;
                comment.TodoList = todoList;
                comment.TodoItem = item;
            }
        }

        foreach (var comment in comments)
        {
            comment.TodoListId = todoList.Id;
        }

        foreach (var tag in tags)
        {
            tag.TodoLists = new List<TodoListEntity> { todoList };
        }

        todoList.User = user;
        user.TodoLists = new List<TodoListEntity> { todoList };

        return todoList;
    }
}