using System;
using System.Collections.Generic;
using System.Text;

namespace CovidTP.DAL.EntityModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string FavoriteBrand { get; set; }
        public int NumberOfPurchases { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
