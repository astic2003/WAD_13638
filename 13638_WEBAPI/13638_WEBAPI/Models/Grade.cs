using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace _13638_WEBAPI.Models
{
    public class Grade
    {
        public int ID { get; set; }

        private int _grade;
        // Grade is out of 0 to 100
        public int GradeNum
        {
            get => _grade;
            set
            {
                if (value < 0 | value > 100)
                {
                    throw new ArgumentException("Grade cannot be more 100 or less than 0");
                }

                _grade = value;
            }
        }
    }
}
