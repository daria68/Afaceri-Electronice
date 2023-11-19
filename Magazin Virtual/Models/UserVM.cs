using System.ComponentModel.DataAnnotations;

namespace Seminar_2.Models
{
    public class UserVM
    {
        public UserVM()
        {
            UserName = string.Empty;
            Password = string.Empty;
            Surname = string.Empty;
            Name = string.Empty;
        }

        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(256)]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(256)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(256)]

        public string ConfirmPassword { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(256)]

        public string Surname { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(256)]

        public string Name { get; set; }

        public DateTime? LastLogin { get; set; }

        public static User VMUserToUser(UserVM vm)
        {
            var user = new User();

            user.UserName = vm.UserName;
            user.Password = vm.Password;
            user.Surname = vm.Surname;
            user.Name = vm.Name;

            return user;
        }

        public UserVM UserToUserVM(User? user)
        {
            if (user == null)
                return new UserVM();

            var vm = new UserVM();

            vm.Id = user.Id;
            vm.UserName = user.UserName;
            vm.Password = user.Password;
            vm.Surname = user.Surname;
            vm.Name = user.Name;
           
            return vm;
        }
    }

}
