﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.User
{
    public class UserListItem
    {
        [ScaffoldColumn(false)] //this makes this champs not visible to the user
        public Guid User_Id { get; set; }


        [DisplayName("Prénom")]
        public string First_Name { get; set; }


        [DisplayName("Nom de famille")]
        public string Last_Name { get; set; }
    }
}
