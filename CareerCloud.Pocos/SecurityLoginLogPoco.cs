﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Log")]
    public class SecurityLoginLogPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Login { get; set; }

        [Column("Source_IP")]
        public string SourceIP { get; set; }

        [Column("Logon_Date")]
        public DateTime LogonDate { get; set; }

        [Column("Is_Succesful")]
        public bool IsSuccesful { get; set; }

    }
}
