using DssProjectElephant.Models;

namespace DssProjectElephant.Controllers
{
    internal class News : TheNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}