using System;
using SQLite;
namespace ICT13580044FinalA.Models
{
    public class Profile
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(200)]
        public String Name { get; set; }
        public String Sur { get; set; }
        public String Address { get; set; }
        public double Mail { get; set; }

		[NotNull]
		[MaxLength(100)]
        public String Sex { get; set; }
        public int Age { get; set; }
        public String Zone { get; set; }
        public int Tel { get; set; }
        public String Status { get; set; }
        public int Child { get; set; }
        public int Salary { get; set; }
    }
}
