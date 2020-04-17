using System;
using System.Collections.Generic;
using System.Text;

namespace CovidTP.DAL.EntityModels
{
    public class UserItems
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
    }
}
