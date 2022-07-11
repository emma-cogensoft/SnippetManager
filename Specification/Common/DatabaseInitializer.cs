using System;
using System.Collections.Generic;
using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Domain.Snippets;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Cogensoft.SnippetManager.Specification.Common
{
    public class DatabaseInitializer
    {
        private readonly Mock<IDatabaseService> _mockDatabase;
        
        public DatabaseInitializer(Mock<IDatabaseService> mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public void Seed()
        {
            CreateSnippets();
        }

        private void CreateSnippets()
        {
            var snippets = new InMemoryDbSet<Snippet>();

            CreateSnippet(snippets, 3, 1, "Snippet description", "Snippet body");

            _mockDatabase.Setup(p => p.Snippets)
                .Returns(snippets);
        }

        private void CreateSnippet(
            InMemoryDbSet<Snippet> snippets,
            int dateOffset,
            int id,
            string description,
            string snippetBody
          )
        {

            var date = new DateTime(2022, 2, 3);

            var snippet = new Snippet
            {
                Id = id,
                Date = date.AddDays(dateOffset),
                Description = description,
                SnippetBody = snippetBody
            };

            snippets.Add(snippet);
        }
    }
}
