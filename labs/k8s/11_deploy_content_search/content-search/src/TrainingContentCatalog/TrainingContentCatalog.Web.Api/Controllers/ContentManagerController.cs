using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using TrainingContentCatalog.Common;
using TrainingContentCatalog.Models;
using TrainingContentCatalog.Services;

namespace TrainingContentCatalog.Web.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContentManagerController: ControllerBase
  {
    private readonly IContentManager _contentManager;

    public ContentManagerController(IContentManager contentManager)
    {
      _contentManager = contentManager;
    }

    [HttpGet]
    public async Task<IEnumerable<ContentItem>> All()
    {
      return await _contentManager.All();
    }

    [HttpGet("{contentItemId}")]
    public async Task<ContentItem> One(string contentItemId)
    {
      return await _contentManager.One(contentItemId);
    }

    [HttpPost]
    public async Task<string> Append(ContentItem contentItem)
    {
      return await _contentManager.Append(contentItem);
    }

    [HttpPut("{contentItemId}")]
    public async Task Replace(string contentItemId, ContentItem contentItem)
    {
      await _contentManager.Replace(contentItem);
    }

    [HttpDelete("{contentItemId}")]
    public async Task Remove(string contentItemId)
    {
      await _contentManager.Remove(contentItemId);
    }

    [HttpPost("activate/{contentItemId}")]
    public async Task Activate(string contentItemId)
    {
      await _contentManager.Activate(contentItemId);
    }

    [HttpPost("deactivate/{contentItemId}")]
    public async Task Deactivate(string contentItemId)
    {
      await _contentManager.Deactivate(contentItemId);
    }

    [HttpGet("all_authors")]
    public async Task<IEnumerable<Person>> AllAuthors()
    {
      return await _contentManager.AllAuthors();
    }

    [HttpGet("all_publishers")]
    public async Task<IEnumerable<Organization>> AllPublishers()
    {
      return await _contentManager.AllPublishers();
    }

    [HttpGet("all_formats")]
    public async Task<IEnumerable<string>> AllFormats()
    {
      return await _contentManager.AllFormats();
    }

    [HttpGet("all_tags")]
    public async Task<IEnumerable<string>> AllTags()
    {
      return await _contentManager.AllTags();
    }
  }
}