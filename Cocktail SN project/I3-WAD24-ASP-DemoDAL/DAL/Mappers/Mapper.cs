﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal static class Mapper
    {
        public static User ToUser(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            //if (record is null) return null;
            return new User()
            {
                User_Id = (Guid)record[nameof(User.User_Id)],
                First_Name = (string)record[nameof(User.First_Name)],
                Last_Name = (string)record[nameof(User.Last_Name)],
                Email = (string)record[nameof(User.Email)],
                Password = "********",
                CreatedAt = (DateTime)record[nameof(User.CreatedAt)],
                DisabledAt = (record[nameof(User.DisabledAt)] is DBNull) ? null : (DateTime?)record[nameof(User.DisabledAt)],
                Role = (string)record[nameof(User.Role)]
            };
        }

        public static Cocktail ToCocktail(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Cocktail()
            {
                Cocktail_Id = (Guid)record[nameof(Cocktail.Cocktail_Id)],
                Name = (string)record[nameof(Cocktail.Name)],
                Description = (record[nameof(Cocktail.Description)] is DBNull) ? null : (string?)record[nameof(Cocktail.Description)],
                Instructions = (string)record[nameof(Cocktail.Instructions)],
                CreatedAt = (DateTime)record[nameof(Cocktail.CreatedAt)],
                CreatedBy = (record[nameof(Cocktail.CreatedBy)] is DBNull) ? null : (Guid?)record[nameof(Cocktail.CreatedBy)]
            };
        }

        public static Comment ToComment(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Comment()
            {
                Comment_Id = (Guid)record[nameof(Comment.Comment_Id)],
                Title = (string)record[nameof(Comment.Title)],
                Content = (string)record[nameof(Comment.Content)],
                Concern = (Guid)record[nameof(Comment.Concern)],
                CreatedAt = (DateTime)record[nameof(Comment.CreatedAt)],
                CreatedBy = (record[nameof(Comment.CreatedBy)] is DBNull) ? null : (Guid?)record[nameof(Comment.CreatedBy)],
                Note = (record[nameof(Comment.Note)] is DBNull) ? null : (byte?)record[nameof(Comment.Note)]    
            };
        }
    }
}
