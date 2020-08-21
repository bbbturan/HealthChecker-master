using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HealthChecker.Entities
{
    public class Log
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name="Log Date")]
        public DateTime Date { get; set; }
        [Display(Name="Error Message")]
        public string ErrorMessage { get; set; }
    }
}
