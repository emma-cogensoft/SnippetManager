namespace Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetDetail
{
    public interface IGetSnippetDetailQuery
    {
        SnippetDetailModel Execute(int id);
    }
}