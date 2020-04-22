﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisTempus.Data.Entities
{
    public class Case
    {
        public int Id { get; set; }
        //[Required]
        public string FileNumber { get; set; }
        public CaseStatus Status { get; set; }

        public Client Client { get; set; }
    }
}
