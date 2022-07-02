using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }= DateTime.Now;
        public string Title { get; set; } = string.Empty;
        public string? content { get; set; };
    }
}
