using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers.Forms
{
    public class PoolPickHandleForm
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
