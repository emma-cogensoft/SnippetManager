using System;

namespace Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetDetail
{
    public class SnippetDetailModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string SnippetBody { get; set; }
    }
}