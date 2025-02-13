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
}
