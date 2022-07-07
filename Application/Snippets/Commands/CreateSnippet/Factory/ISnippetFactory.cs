using System;
using Cogensoft.SnippetManager.Domain.Snippets;

namespace Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet.Factory
{
    public interface ISnippetFactory
    {
        Snippet Create(DateTime date, string description, string snippetBody);
    }
}