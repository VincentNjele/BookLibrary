﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BookWEBAPI.WEB
{
    public partial class UsersTable
    {
        public UsersTable()
        {
            Rents = new HashSet<Rents>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }

        public virtual ICollection<Rents> Rents { get; set; }
    }
}