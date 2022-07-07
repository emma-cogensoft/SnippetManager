namespace Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet
{
    public interface ICreateSnippetCommand
    {
        void Execute(CreateSnippetModel model);
    }
}