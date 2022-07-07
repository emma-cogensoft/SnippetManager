using System;
using Cogensoft.SnippetManager.Domain.Snippets;

namespace Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet.Factory
{
    public class SnippetFactory : ISnippetFactory
    {
        public Snippet Create(DateTime date, string description, string snippetBody)
        {
            var snippet = new Snippet
            {
                Date = date,
                Description = description,
                SnippetBody = snippetBody
            };

            return snippet;
        }
    }
}
