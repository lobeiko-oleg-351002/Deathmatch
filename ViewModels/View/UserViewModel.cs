using System;

namespace ViewModels.View
{
    public class UserViewModel : ViewModel
    {
        public string Name { get; set; }

        public RoleViewModel Role { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            var model = (UserViewModel)obj;
            return model.Id.Equals(Id) && (model.Name == Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
