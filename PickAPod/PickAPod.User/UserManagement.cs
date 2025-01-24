namespace PickAPod.User
{
    public class UserManagement
    {
        private User _user;

        public User GetUser()
        {
            return _user;
        }

        public void SetUser(User user)
        {
            _user = user;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

}
