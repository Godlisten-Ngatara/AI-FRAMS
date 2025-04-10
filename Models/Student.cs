

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_FRAMS.Models
{
    public class Student
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("regno")]
        public string RegNo { get; set; }

        [Column("first_name")]
        public string First_name { get; set; }

        [Column("middle_name")]
        public string Middle_name { get; set; }
        [Column("last_name")]
        public string Last_name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("programme")]
        public string Programme { get; set; }

        [Column("year_of_study")]
        public int Year_of_study { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [Column("phone_number")]
        public string Phone_number { get; set; }



    
    public Student()
        {
            Role = "student";
        }
    }
}
