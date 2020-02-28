using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers.Views
{
    public class PoolPickHandleView
    {
        public int Id { get; set; }

        public UserView picker { get; set; }

        public QuestionView question { get; set; }

        public int AvailableFor { get; set; }

        public DateTime InsertedAt { get; set; }
    }
}
