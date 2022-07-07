using System;
using Cogensoft.SnippetManager.Domain.Common;

namespace Cogensoft.SnippetManager.Domain.Snippets
{
    public class Snippet : IEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }
        
        public string SnippetBody { get; set; }
    }
}
