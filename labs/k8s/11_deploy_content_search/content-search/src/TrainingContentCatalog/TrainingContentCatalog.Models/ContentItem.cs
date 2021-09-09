using System;
using System.Collections.Generic;

namespace TrainingContentCatalog.Models
{
    public class ContentItem
    {
        private List<string> _tags;

        public string Id { get; set; }
        public string Title { get; set; }
        public Person Author { get; set; }
        public Organization Publisher { get; set; }
        public string Format { get; set; }
        public Uri Url { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public IEnumerable<string> Tags { get; init; }
        public bool Active { get; set; } = true;

        public ContentItem() {
            _tags = new List<string>();
        }

        public ContentItem AddTag(string tag) {
            _tags.Add(tag);
            return this;
        }

        public ContentItem ClearTags() {
            _tags.Clear();
            return this;
        }
    }
}
