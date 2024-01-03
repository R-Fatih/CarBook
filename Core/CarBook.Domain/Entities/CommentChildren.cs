using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CommentChildren
    {
        public int CommentChildrenId { get; set; }
        public int CommentId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public Comment Comment { get; set; }
    }
}
