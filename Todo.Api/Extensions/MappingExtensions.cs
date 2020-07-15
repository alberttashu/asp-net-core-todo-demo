using Todo.Api.Contracts;

namespace Todo.Api.Extensions
{
    public static class MappingExtensions
    {
        public static TodoOutputContract ToTodoOutputContract(this Model.Todo source)
        {
            return new TodoOutputContract()
            {
                Id = source.Id,
                Description = source.Description,
                Title = source.Summary
            };
        }

        public static TodoWithoutDescriptionOutputContract ToTodoWithoutDescriptionOutputContract(this Model.Todo source)
        {
            return new TodoWithoutDescriptionOutputContract()
            {
                Id = source.Id,
                Title = source.Summary
            };
        }
    }
}
