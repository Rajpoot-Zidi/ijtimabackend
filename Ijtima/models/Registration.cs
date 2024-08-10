using static System.Net.Mime.MediaTypeNames;

namespace Ijtima.models
{
    public class Registration
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? NameUrdu { get; set; }
        public string FatherName { get; set; }
        public string? FatherNameUrdu { get; set; }
        public string PhoneNumber { get; set; }
        public string Cnic { get; set; }
        public string? Status { get; set; }
        public string? Verified { get; set; }
        public string Department { get; set; }
        public bool? ThumbScan { get; set; }
        public byte? image { get; set; }
        public string? FormNumber { get; set; }

    }

}
