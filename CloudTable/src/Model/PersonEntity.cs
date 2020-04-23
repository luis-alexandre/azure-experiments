﻿using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudTableConsole.Model
{
    public class PersonEntity : TableEntity
    {

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public PersonEntity() { }

        public PersonEntity(string lastName, string firstName)
        {
            PartitionKey = lastName;
            RowKey = firstName;
        }
    }
}
